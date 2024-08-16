using DevDev.Extensions;
using DevDev.Extensions.Editor;
using DevDev.Table.Editor.TypeParser;
using NPOI.SS.UserModel;
using UnityEngine;

namespace DevDev.Table.Editor.Meta
{
    public class Column
    {
        public int Index { get; }
        public int CellNum { get; }
        public string Name { get; }
        public string TypeName => IsArray ? $"global::{Parser.SerializeType.FullName}[]" : $"global::{Parser.SerializeType.FullName}";
        public string Description { get; }
        public ITypeParser Parser { get; }

        public bool IsArray { get; }
        public int CellRange { get; }


        public Column(int index, int cellNum, IRow nameRow, IRow descRow, IRow typeRow)
        {
            Index = index;
            CellNum = cellNum;
            
            //배열인지 확인쓰
            IsArray = CheckArray(typeRow, cellNum);
            string typeCellValue = typeRow.GetCell(CellNum).StringCellValue;
            string excelTypeName = IsArray ? typeCellValue.Replace("[]", string.Empty) : typeCellValue;
            Parser = SupportedType.Get(excelTypeName ?? string.Empty);
            if (Parser == null)
            {
                Debug.LogError($"Parser Not Found:{excelTypeName}::CellNum:{CellNum}");
            }
            
            CellRange = IsArray ? GetCellRange(typeRow, cellNum) : Parser.CellRange;
            Name = nameRow.GetCell(CellNum).StringCellValue;
            Description = descRow.GetCell(CellNum).GetStringValue();
        }

        private bool CheckArray(IRow typeRow, int cellNum)
        {
            string typeCellValue = typeRow.GetCell(CellNum).StringCellValue;
            return typeCellValue.Contains("[]");
        }

        private int GetCellRange(IRow typeRow, int cellNum)
        {
            int currentCellNum = cellNum + 1;
            while (true)
            {
                var cell = typeRow.GetCell(currentCellNum);
                if (cell == null || cell.IsMergedCell == false || cell.StringCellValue.IsNullOrWhiteSpace() == false)
                {
                    break;
                }

                currentCellNum++;
            }

            return currentCellNum - cellNum;
        }

        public string GetParserVariableName() => $"{Name}Parser";
    }
}