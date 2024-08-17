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
    public class SerializerGenerator
    {
        private readonly List<Scheme> _schemes = new List<Scheme>();

        public SerializerGenerator(IReadOnlyDictionary<string, Scheme> schemes)
        {
            _schemes.AddRange(schemes.Values);
        }

        public void Generate()
        {
            string outputPath = Path.Combine(Application.dataPath, Define.GENERATE_FOLDER_PATH, "Editor");
            if (Directory.Exists(outputPath) == false)
            {
                Directory.CreateDirectory(outputPath);
            }
            
            string filePath = Path.Combine(outputPath, $"TableSerializer.cs");
            string text = CreateClass();
            File.WriteAllText(filePath, text);
        }

        private string CreateClass([CallerFilePath] string filePath = "")
        {
            string directoryName = Path.GetDirectoryName(filePath);
            string templatePath = Path.Combine(directoryName, Define.TEMPLATE_SERIALIZER_FILE_NAME);
            string templateText = File.ReadAllText(templatePath);
            
            var builder = new StringBuilder(templateText);
            builder.Replace(Define.TOKEN_NAMESPACE, Define.NAME_SPACE_EDITOR);
            builder.Replace(Define.TOKEN_CALL_IMPLEMENT, CreateCallImplement());
            builder.Replace(Define.TOKEN_METHOD_IMPLEMENT, CreateMethodImplement());
            
            return builder.ToString();
        }

        private string CreateCallImplement()
        {
            var builder = new StringBuilder();
            foreach (var scheme in _schemes)
            {
                builder.AppendIndent(3)
                    .Append($"Serialize{scheme.Name}(schemes[\"{scheme.Name}\"]);")
                    .AppendLine();
            }

            return builder.ToString();
        }

        private string CreateMethodImplement()
        {
            var builder = new StringBuilder();
            foreach (var scheme in _schemes)
            {
                builder.Append(CreateSerializeTable(scheme))
                    .AppendLine();
            }
            return builder.ToString();
        }

        private string CreateSerializeTable(Scheme scheme, [CallerFilePath] string filePath = "")
        {
            string directoryName = Path.GetDirectoryName(filePath);
            string templatePath = Path.Combine(directoryName, Define.TEMPLATE_SERIALIZER_METHOD_FILE_NAME);
            string templateText = File.ReadAllText(templatePath);
            var builder = new StringBuilder(templateText);

            builder.Replace(Define.TOKEN_NAME, scheme.Name);
            builder.Replace(Define.TOKEN_ROW_NAME, scheme.GetRowName());
            builder.Replace(Define.TOKEN_DEFINE_PARSER, CreateDefineParser(scheme));
            builder.Replace(Define.TOKEN_CONSTRUCTOR_PARAM, CreateConstructorParam(scheme));
            builder.Replace(Define.TOKEN_TABLE_NAME, scheme.GetTableName());
            builder.Replace(Define.TOKEN_EXPORT_PATH, Define.EXPORT_PATH);
            
            return builder.ToString();
        }

        private string CreateDefineParser(Scheme scheme)
        {
            var builder = new StringBuilder();
            foreach (var column in scheme.Columns)
            {
                builder.AppendIndent(3)
                    .Append($"var {column.GetParserVariableName()} = scheme.Columns[columnIndex++].Parser as global::{column.Parser.GetParserTypeName()};")
                    .AppendLine();
            }
            return builder.ToString();
        }

        private string CreateConstructorParam(Scheme scheme)
        {
            var builder = new StringBuilder();
            foreach (var column in scheme.Columns)
            {
                builder.AppendIndent(5);
                builder.Append(column.IsArray
                    ? $"{column.GetParserVariableName()}.ParseArray(scheme.Columns[columnIndex++], row)"
                    : $"{column.GetParserVariableName()}.Parse(scheme.Columns[columnIndex++], row)"
                );

                if (column != scheme.Columns.Last())
                {
                    builder.Append(",")
                        .AppendLine();
                }
            }
            return builder.ToString();
        }
    }
}