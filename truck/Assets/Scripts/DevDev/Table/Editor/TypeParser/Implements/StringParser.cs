using System;
using System.Collections.Generic;
using DevDev.Extensions.Editor;
using DevDev.Table.Editor.Meta;
using NPOI.SS.UserModel;

namespace DevDev.Table.Editor.TypeParser.Implements
{
    public class StringParser : ITypeParser<string>
    {
        public Type SerializeType { get; } = typeof(string);
        public int CellRange => 1;
        public string[] TableTypes { get; } = {
            "String"
        };

        private readonly List<string> _list = new List<string>();
        
        public string Parse(Column column, IRow row)
        {
            return row.GetCell(column.CellNum).GetStringValue();
        }

        public string[] ParseArray(Column column, IRow row)
        {
            _list.Clear();
            for (int i = column.CellNum; i < column.CellNum + column.CellRange; i++)
            {
                var cell = row.GetCell(i);
                if (cell.IsNullOrEmpty())
                {
                    continue;
                }
                
                _list.Add(cell.GetStringValue());
            }

            return _list.ToArray();
        }
        
        public string GetParserTypeName()
        {
            return GetType().FullName;
        }
    }
}