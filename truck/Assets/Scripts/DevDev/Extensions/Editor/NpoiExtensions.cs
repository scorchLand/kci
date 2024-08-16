using System;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace DevDev.Extensions.Editor
{
    public static class NpoiExtensions
    {
        public static string GetStringValue(this ICell cell)
        {
            return cell.CellType switch
            {
                CellType.Numeric => cell.NumericCellValue.ToString(),
                CellType.String => cell.StringCellValue,
                CellType.Formula => cell.StringCellValue,
                CellType.Boolean => cell.BooleanCellValue.ToString(),
                _ => string.Empty
            };
        }

        public static int GetIntValue(this ICell cell)
        {
            return cell.CellType switch
            {
                CellType.Numeric => (int)cell.NumericCellValue,
                CellType.String => int.Parse(cell.StringCellValue),
                CellType.Boolean => cell.BooleanCellValue ? 1 : 0,
                CellType.Formula => (int)cell.NumericCellValue,
                _ => default
            };
        }
        
        public static long GetLongValue(this ICell cell)
        {
            return cell.CellType switch
            {
                CellType.Numeric => (long)cell.NumericCellValue,
                CellType.String => long.Parse(cell.StringCellValue),
                CellType.Boolean => cell.BooleanCellValue ? 1 : 0,
                CellType.Formula => (long)cell.NumericCellValue,
                _ => default
            };
        }
        
        public static float GetFloatValue(this ICell cell)
        {
            return cell.CellType switch
            {
                CellType.Numeric => (float)cell.NumericCellValue,
                CellType.String => float.Parse(cell.StringCellValue),
                CellType.Boolean => cell.BooleanCellValue ? 1 : 0,
                CellType.Formula => (float)cell.NumericCellValue,
                _ => default
            };
        }
        
        public static double GetDoubleValue(this ICell cell)
        {
            return cell.CellType switch
            {
                CellType.Numeric => cell.NumericCellValue,
                CellType.String => double.Parse(cell.StringCellValue),
                CellType.Boolean => cell.BooleanCellValue ? 1 : 0,
                CellType.Formula => cell.NumericCellValue,
                _ => default
            };
        }

        public static bool IsNullOrEmpty(this ICell cell)
        {
            return cell == null || cell.CellType == CellType.Blank || cell.ToString().IsNullOrWhiteSpace();
        }

        public static string GetDetailInfo(this ICell cell)
        {
            int columnIndex = cell.ColumnIndex;
            int last = 'z';
            int first = 'a';
            int size = last - first;
            int quotient = columnIndex / size;
            int remainder = columnIndex % size;
            
            int lastChar = (first + (char)remainder);
            string columnAddress = $"{(char)lastChar}";
            if (quotient > 0)
            {
                int firstChar = (first + (char)quotient - 1);
                columnAddress = $"{(char)firstChar}{(char)lastChar}";
            }

            columnAddress = columnAddress.ToUpper();

            return $"{cell.Sheet.SheetName}:{columnAddress}{cell.RowIndex + 1} value:{cell}";
        }
    }
}