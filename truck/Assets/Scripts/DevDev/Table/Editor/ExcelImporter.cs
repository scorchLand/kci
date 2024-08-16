using System.Collections.Generic;
using System.IO;
using DevDev.Table.Editor.CodeGen;
using DevDev.Table.Editor.Meta;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using UnityEngine;


namespace DevDev.Table.Editor
{
    public class ExcelImporter
    {
        
        private static IWorkbook GetWorkbook(string path)
        {
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            
            string ext = Path.GetExtension(path);

            IWorkbook result;
            if (ext.Equals(".xls"))
            {
                result = new HSSFWorkbook(stream);
            }
            else
            {
                result = new XSSFWorkbook(stream);
            }

            result.MissingCellPolicy = MissingCellPolicy.RETURN_NULL_AND_BLANK;
            return result;
        }

        public IReadOnlyList<Scheme> Schemes => _schemes;

        private readonly List<ISheet> _sheets = new List<ISheet>();
        private readonly List<Scheme> _schemes = new List<Scheme>();
        

        public ExcelImporter(string path)
        {
            var workbook = GetWorkbook(path);
            //외부 시트 참조의 경우
            //http://poi.apache.org/components/spreadsheet/eval.html
            
            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                string sheetName = workbook.GetSheetName(i);
                if (sheetName.StartsWith("#"))
                {
                    _sheets.Add(workbook.GetSheetAt(i));
                }
            }

            foreach (var sheet in _sheets)
            {
                Debug.Log($"Sheet:{sheet.SheetName}\nPath:{path}\n");
            }
            
            workbook.MissingCellPolicy = MissingCellPolicy.CREATE_NULL_AS_BLANK;
        }

        public void LoadMetaData()
        {
            foreach (var sheet in _sheets)
            {
                var metadata = new Scheme(sheet);
                _schemes.Add(metadata);
            }
        }
    }
}