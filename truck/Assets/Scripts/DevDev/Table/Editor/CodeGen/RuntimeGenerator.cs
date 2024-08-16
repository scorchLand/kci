using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using DevDev.Extensions;
using DevDev.Table.Editor.Meta;
using UnityEngine;

namespace DevDev.Table.Editor.CodeGen
{
	public class RuntimeGenerator
	{
		private readonly List<Scheme> _schemes = new List<Scheme>();

		public RuntimeGenerator(IReadOnlyDictionary<string, Scheme> schemes)
		{
			_schemes.AddRange(schemes.Values);
		}

		public void Generate()
		{
			string outputPath = Path.Combine(Application.dataPath, Define.GENERATE_FOLDER_PATH);
			if (Directory.Exists(outputPath) == false)
			{
				Directory.CreateDirectory(outputPath);
			}
			
			string filePath = Path.Combine(outputPath, $"Tables.cs");
			string text = CreateClass();
			File.WriteAllText(filePath, text);
		}
		
		private string CreateClass([CallerFilePath] string filePath = "")
		{
			string directoryName = Path.GetDirectoryName(filePath);
			string templatePath = Path.Combine(directoryName, Define.TEMPLATE_RUNTIME_FILE_NAME);
			string templateText = File.ReadAllText(templatePath);
            
			var builder = new StringBuilder(templateText);
			builder.Replace(Define.TOKEN_NAMESPACE, Define.NAME_SPACE);
			builder.Replace(Define.TOKEN_TABLE_IMPLEMENT, CreateTableProperties());
			builder.Replace(Define.TOKEN_METHOD_IMPLEMENT, CreateLoadFromPath());
			builder.Replace(Define.TOKEN_METHOD_IMPLEMENT_2, CreateLoadFromResources());
            
			return builder.ToString();
		}

		private string CreateTableProperties()
		{
			var builder = new StringBuilder();
			foreach (var scheme in _schemes)
			{
				builder.AppendIndent(2)
					.Append($@"public static {scheme.GetTableName()} {scheme.Name} {{ get; }} = new {scheme.GetTableName()}();")
					.AppendLine();
			}
			
			return builder.ToString();
		}

		private string CreateLoadFromPath()
		{
			var builder = new StringBuilder();
			foreach (var scheme in _schemes)
			{
				string exportPath = $"{{path}}/{scheme.GetTableName()}.bytes";
				
				builder.AppendIndent(3)
					.Append($@"{scheme.Name}.LoadFromPath($""{exportPath}"");")
					.AppendLine();
			}

			return builder.ToString();
		}

		private string CreateLoadFromResources()
		{
			var builder = new StringBuilder();
			foreach (var scheme in _schemes)
			{
				string exportPath = $"{Define.EXPORT_PATH_FOR_RUNTIME}/{scheme.GetTableName()}";
				
				builder.AppendIndent(3)
					.Append($@"{scheme.Name}.LoadFromResources($""{exportPath}"");")
					.AppendLine();
			}

			return builder.ToString();
		}
	}
}
