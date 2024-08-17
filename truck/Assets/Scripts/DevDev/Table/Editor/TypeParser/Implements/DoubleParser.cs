using System;
using System.Collections.Generic;
using DevDev.Extensions.Editor;
using DevDev.Table.Editor.Meta;
using NPOI.SS.UserModel;

namespace DevDev.Table.Editor.TypeParser.Implements
{
    public class DoubleParser : ITypeParser<double>
    {
        public Type SerializeType { get; } = typeof(double);
        public int CellRange => 1;

        public string[] TableTypes { get; } = {
            "Double"
        };
        
        private readonly List<double> _list = new List<double>();

        public double Parse(Column column, IRow row)
        {
            return row.GetCell(column.CellNum).GetDoubleValue();
        }

        public double[] ParseArray(Column column, IRow row)
        {
            _list.Clear();
            
            for (int i = column.CellNum; i < column.CellNum + column.CellRange; i++)
            {
                var cell = row.GetCell(i);
                if (cell.IsNullOrEmpty())
                {
                    continue;
                }
                
                _list.Add(cell.GetDoubleValue());
            }
            return _list.ToArray();
        }
        
        public string GetParserTypeName()
        {
            return GetType().FullName;
        }
    }
}