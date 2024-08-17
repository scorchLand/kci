using System.Collections.Generic;
using NPOI.SS.UserModel;
using DevDev.Extensions;

namespace DevDev.Table.Editor.Meta
{
    public class Scheme
    {
        public string Name { get; }
        public Column KeyColumn => Columns[0];
        public List<Column> Columns { get; } = new List<Column>();
        public ISheet Sheet { get; }

        public Scheme(ISheet sheet)
        {
            Sheet = sheet;
            Name = sheet.SheetName.Remove(0, 1);
            
            int rowNum = sheet.FirstRowNum;
            var nameRow = sheet.GetRow(rowNum++);
            var descRow = sheet.GetRow(rowNum++);
            var typeRow = sheet.GetRow(rowNum);

            int index = 0;
            int lastCellNum = nameRow.LastCellNum;
            for (int cellNum = nameRow.FirstCellNum; cellNum < lastCellNum; )
            {
                var nameCell = nameRow.GetCell(cellNum);
                if (nameCell?.StringCellValue.IsNullOrWhiteSpace() ?? true)
                {
                    cellNum++;
                    continue;
                }

                var column = new Column(index++, cellNum, nameRow, descRow, typeRow);
                Columns.Add(column);
                cellNum += column.CellRange;
            }
        }

        public string GetRowName() => $"Row{Name}";

        public string GetTableName() => $"Table{Name}";
    }
}