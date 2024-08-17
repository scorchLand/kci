using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using DevDev.Extensions;
using DevDev.Table.Editor.Meta;
using UnityEngine;

namespace DevDev.Table.Editor.CodeGen
{
    public class ClassGenerator
    {
        private readonly List<Scheme> _schemes = new List<Scheme>();

        public ClassGenerator(IReadOnlyDictionary<string, Scheme> schemes)
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

            foreach (var scheme in _schemes)
            {
                string text = CreateClass(scheme);
                string filePath = Path.Combine(outputPath, $"{scheme.GetTableName()}.cs");
                File.WriteAllText(filePath, text);
            }
        }
        
        

        private string CreateClass(Scheme scheme, [CallerFilePath] string filePath = "")
        {
            string directoryName = Path.GetDirectoryName(filePath);
            string templatePath = Path.Combine(directoryName, Define.TEMPLATE_CLASS_FILE_NAME);
            string templateText = File.ReadAllText(templatePath);

            var builder = new StringBuilder(templateText);
            builder.Replace(Define.TOKEN_NAMESPACE, Define.NAME_SPACE)
                .Replace(Define.TOKEN_ROW_NAME, scheme.GetRowName())
                .Replace(Define.TOKEN_KEY_TYPE, scheme.KeyColumn.TypeName)
                .Replace(Define.TOKEN_TABLE_NAME, scheme.GetTableName())
                .Replace(Define.TOKEN_TABLE_IMPLEMENT, string.Empty)
                .Replace(Define.TOKEN_ROW_IMPLEMENT, CreateRowImplement(scheme))
                .Replace(Define.TOKEN_ROW_CONSTRUCTOR_PARAM, CreateRowConstructorParam(scheme))
                .Replace(Define.TOKEN_ROW_CONSTRUCTOR_IMPLEMENT, CreateRowConstructorImplement(scheme));

            return builder.ToString();
        }

        private string CreateRowImplement(Scheme scheme)
        {
            var builder = new StringBuilder();
            const int TAB_INDENT = 2;
            int index = 0;

            foreach (var column in scheme.Columns)
            {
                if (column.Description.IsNullOrWhiteSpace() == false)
                {
                    builder.AppendIndent(TAB_INDENT).Append("/// <summary>\n");

                    foreach (string line in column.Description.Split('\n'))
                    {
                        builder.AppendIndent(TAB_INDENT).Append($"/// {line}\n");
                    }

                    builder.AppendIndent(TAB_INDENT).Append("/// </summary>\n");
                }

                try
                {
                    builder.AppendIndent(TAB_INDENT).Append($"public {column.TypeName} {column.Name} => _{column.Name};\n")
                        .AppendLine();
                }
                catch (Exception)
                {
                    Debug.LogError($"TypeName missing. Scheme:{scheme.Name} Column:{column.Name}");
                    throw;
                }
            }

            builder.AppendLine();
            foreach (var column in scheme.Columns)
            {
                builder.AppendIndent(TAB_INDENT)
                    .Append($"[SerializeAbleField({index++})] private {column.TypeName} _{column.Name};\n");
            }

            return builder.ToString();
        }

        private string CreateRowConstructorParam(Scheme scheme)
        {
            var builder = new StringBuilder();
            foreach (var column in scheme.Columns)
            {
                builder.Append($"{column.TypeName} __{column.Name}");
                if (scheme.Columns.Last() == column)
                {
                    continue;
                }

                builder.Append(", ");
            }

            return builder.ToString();
        }

        private string CreateRowConstructorImplement(Scheme scheme)
        {
            const int TAB_INDENT = 3;

            var builder = new StringBuilder();
            foreach (var column in scheme.Columns)
            {
                builder.AppendIndent(TAB_INDENT).Append($"_{column.Name} = __{column.Name};\n");
            }

            return builder.ToString();
        }
    }
}