using System.Collections.Generic;
using System.IO;
using DevDev.Table.Editor.CodeGen;
using DevDev.Table.Editor.Meta;
using UnityEditor;
using UnityEngine;
using Grooz;

namespace DevDev.Table.Editor
{
	public static class TableMenuItem
	{
		private static string FolderPath { get; } = Path.Combine(Application.dataPath, "../Table");

		[MenuItem("Table/Open Excel Folder", priority = -2)]
		private static void OpenExcelFolder()
		{
			if (Directory.Exists(FolderPath) == false)
			{
				Directory.CreateDirectory(FolderPath);
			}

			EditorUtility.RevealInFinder(FolderPath + "/");
		}

		[MenuItem("Table/Generate Code", priority = -1)]
		private static void GenerateTableClass()
		{
			if (Directory.Exists(FolderPath) == false)
			{
				Directory.CreateDirectory(FolderPath);
			}

			var schemes = GetExcelSchemes();

			//변경사항 없을시 패스해도 됨.
			var classGenerator = new ClassGenerator(schemes);
			classGenerator.Generate();

			//이건 무조건 있어야 함.
			//생성되는 코드에서 해쉬값 비교해서 시리얼라이즈 패스해도 됨
			var serializerGenerator = new SerializerGenerator(schemes);
			serializerGenerator.Generate();

			var runtimeGenerator = new RuntimeGenerator(schemes);
			runtimeGenerator.Generate();
			//로드
			AssetDatabase.Refresh();
		}

		public static Dictionary<string, Scheme> GetExcelSchemes()
		{
			var schemes = new Dictionary<string, Scheme>();

			string[] filePaths = Directory.GetFiles(FolderPath);
			foreach (string path in filePaths)
			{
				//익스포트시 파일 수정 일자, 해쉬 비교?... 스키마 내부에서 확인

				string ext = Path.GetExtension(path);
				if (ext.Contains("xls") == false)
				{
					continue;
				}

				string fileName = Path.GetFileNameWithoutExtension(path);
				if (fileName.StartsWith("~$") || fileName.StartsWith(".") || fileName.StartsWith("_"))
				{
					continue;
				}
				
				var importer = new ExcelImporter(path);
				importer.LoadMetaData();

				foreach (var scheme in importer.Schemes)
				{
					schemes.Add(scheme.Name, scheme);
				}
			}

			return schemes;
		}
		
		[MenuItem("Table/Reload Table For Editor", priority = 10)]
		public static void ReloadTables()
		{
			Tables.LoadFromResources();
		}
	}
}
