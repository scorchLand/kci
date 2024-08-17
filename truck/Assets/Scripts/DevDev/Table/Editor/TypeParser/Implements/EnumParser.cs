using System;
using System.Collections.Generic;
using DevDev.Extensions.Editor;
using DevDev.Table.Editor.Meta;
using NPOI.SS.UserModel;
using UnityEngine;

namespace DevDev.Table.Editor.TypeParser.Implements
{
    public class EnumParser<TEnum> : ITypeParser<TEnum> where TEnum : struct
    {
        public Type SerializeType { get; } = typeof(TEnum);
        public int CellRange => 1;
        public string[] TableTypes { get; } = { typeof(TEnum).FullName }; 

        private readonly List<TEnum> _list = new List<TEnum>();

        
        public TEnum Parse(Column column, IRow row)
        {
            return ParseEnum(row.GetCell(column.CellNum));
        }

        public TEnum[] ParseArray(Column column, IRow row)
        {
            _list.Clear();

            for (int i = column.CellNum; i < column.CellNum + column.CellRange; i++)
            {
                var cell = row.GetCell(i);
                if (cell.IsNullOrEmpty())
                {
                    continue;
                }
                
                _list.Add(ParseEnum(cell));
            }
            
            return _list.ToArray();
        }
        
        public TEnum ParseEnum(ICell cell)
        {
            if (cell.IsNullOrEmpty())
            {
                return default;
            }

            bool isSuccess = Enum.TryParse<TEnum>(cell.StringCellValue, out var result);
            if (isSuccess == false)
            {
                Debug.LogError($"Enum:{SerializeType.Name} 파싱 실패: {cell.GetDetailInfo()}");
            }
            return result;
        }
        
        public string GetParserTypeName()
        {
            return $"DevDev.Table.Editor.TypeParser.Implements.EnumParser<global::{typeof(TEnum).FullName}>";
        }
    }
}