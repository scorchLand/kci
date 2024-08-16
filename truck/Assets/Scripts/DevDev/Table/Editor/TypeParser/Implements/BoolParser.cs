using System;
using System.Collections.Generic;
using DevDev.Extensions.Editor;
using DevDev.Table.Editor.Meta;
using NPOI.SS.UserModel;

namespace DevDev.Table.Editor.TypeParser.Implements
{
    public class BoolParser : ITypeParser<bool>
    {
        public Type SerializeType { get; } = typeof(bool);
        public int CellRange => 1;
        public string[] TableTypes { get; } = {
            "Bool",
            "Boolean"
        };
        
        private readonly List<bool> _list = new List<bool>();

        
        public bool Parse(Column column, IRow row)
        {
            return row.GetCell(column.CellNum).BooleanCellValue;
        }

        public bool[] ParseArray(Column column, IRow row)
        {
            _list.Clear();
            for (int i = column.CellNum; i < column.CellNum + column.CellRange; i++)
            {
                var cell = row.GetCell(i);
                if (cell.IsNullOrEmpty())
                {
                    continue;
                }
                
                _list.Add(cell.BooleanCellValue);
            }
            
            return _list.ToArray();
        }
        
        public string GetParserTypeName()
        {
            return GetType().FullName;
        }
    }
}