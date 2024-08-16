using System;
using System.Collections.Generic;
using DevDev.Extensions.Editor;
using DevDev.Table.Editor.Meta;
using NPOI.SS.UserModel;

namespace DevDev.Table.Editor.TypeParser.Implements
{
    public class LongParser : ITypeParser<long>
    {
        public Type SerializeType { get; } = typeof(long);
        public int CellRange => 1;
        public string[] TableTypes { get; } = {
            "Long"
        };
        
        private readonly List<long> _list = new List<long>();

        
        public long Parse(Column column, IRow row)
        {
            return row.GetCell(column.CellNum).GetLongValue();
        }

        public long[] ParseArray(Column column, IRow row)
        {
            _list.Clear();
            for (int i = column.CellNum; i < column.CellNum + column.CellRange; i++)
            {
                var cell = row.GetCell(i);
                if (cell.IsNullOrEmpty())
                {
                    continue;
                }
                
                _list.Add(cell.GetLongValue());
            }

            return _list.ToArray();
        }
        
        public string GetParserTypeName()
        {
            return GetType().FullName;
        }
    }
}