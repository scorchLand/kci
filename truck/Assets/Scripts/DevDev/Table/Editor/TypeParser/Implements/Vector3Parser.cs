using System;
using System.Collections.Generic;
using DevDev.Extensions.Editor;
using DevDev.Table.Editor.Meta;
using NPOI.SS.UserModel;
using UnityEngine;

namespace DevDev.Table.Editor.TypeParser.Implements
{
    public class Vector3Parser : ITypeParser<Vector3>
    {
        public Type SerializeType { get; } = typeof(Vector3);
        public int CellRange => 1;
        public string[] TableTypes => new[] { "Vector3" };
        private readonly List<Vector3> _list = new List<Vector3>();

        public Vector3 Parse(Column column, IRow row)
        {
            return ParseInternal(row.GetCell(column.CellNum).StringCellValue);
        }

        public Vector3[] ParseArray(Column column, IRow row)
        {
            _list.Clear();
            for (int i = column.CellNum; i < column.CellNum + column.CellRange; i++)
            {
                var cell = row.GetCell(i);
                if (cell.IsNullOrEmpty())
                {
                    continue;
                }
                
                _list.Add(ParseInternal(cell.StringCellValue));
            }

            return _list.ToArray();
        }

        public string GetParserTypeName()
        {
            return GetType().FullName;
        }

        private Vector3 ParseInternal(string stringCellValue)
        {
            Vector3 result;
            string[] elements = stringCellValue.Split(Define.separators,StringSplitOptions.RemoveEmptyEntries);
            float.TryParse(elements[0], out result.x);
            float.TryParse(elements[1], out result.y);
            float.TryParse(elements[2], out result.z);
            return result;
        }
    }
}