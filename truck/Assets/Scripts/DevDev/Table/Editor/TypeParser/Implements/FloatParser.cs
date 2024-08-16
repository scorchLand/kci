using System;
using System.Collections.Generic;
using DevDev.Extensions.Editor;
using DevDev.Table.Editor.Meta;
using NPOI.SS.UserModel;

namespace DevDev.Table.Editor.TypeParser.Implements
{
    public class FloatParser : ITypeParser<float>
    {
        public Type SerializeType { get; } = typeof(float);
        public int CellRange => 1;
        public string[] TableTypes { get; } = {
            "Float"
        };
        
        private readonly List<float> _list = new List<float>();

        
        public float Parse(Column column, IRow row)
        {
            return row.GetCell(column.CellNum).GetFloatValue();
        }

        public float[] ParseArray(Column column, IRow row)
        {
            _list.Clear();
            for (int i = column.CellNum; i < column.CellNum + column.CellRange; i++)
            {
                var cell = row.GetCell(i);
                if (cell.IsNullOrEmpty())
                {
                    continue;
                }
                
                _list.Add(cell.GetFloatValue());
            }
            return _list.ToArray();
        }
        
        public string GetParserTypeName()
        {
            return GetType().FullName;
        }
    }
}