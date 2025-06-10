//This code was automatically generated.
//Don't edit this code.

using System.Collections.Generic;
using DevDev.Table.Editor.Meta;
using DevDev.Extensions.Editor;
using System.IO;
using OPS.Serialization.IO;
using UnityEditor;


namespace Grooz.Editor
{
    public static class SerializeMenuItem
    {
        [MenuItem("Table/Serialize All")]
        public static void SerializeAll()
        {
            var schemes = DevDev.Table.Editor.TableMenuItem.GetExcelSchemes();
            SerializeAll(schemes);
        }
    
        private static void SerializeAll(IReadOnlyDictionary<string, Scheme> schemes)
        {
			SerializeHero(schemes["Hero"]);
			SerializeHeroTower(schemes["HeroTower"]);
			SerializeStatus(schemes["Status"]);
			SerializeStat(schemes["Stat"]);
			SerializeWave(schemes["Wave"]);

            AssetDatabase.Refresh();
        }
        
        private static void SerializeHero(Scheme scheme)
        {
            var list = new List<RowHero>();
            var sheet = scheme.Sheet;
            int firstDataRowNum = sheet.FirstRowNum + 3;
            int lastDataRowNum = sheet.LastRowNum;
            
            int columnIndex = 0;
			var KeyParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var NameParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var DescParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var PortraitAddrParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var FullImageAddrParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var TierParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var MaxRankParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var RankEffectNumParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var TableHeroRankEffectParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var TableHeroTowerParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var TableHeroAbilityParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;


            for (int i = firstDataRowNum; i <= lastDataRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row.GetCell(0).IsNullOrEmpty())
                {
                    continue;
                }
                                
                columnIndex = 0;
                var rowObj = new RowHero(
					KeyParser.Parse(scheme.Columns[columnIndex++], row),
					NameParser.Parse(scheme.Columns[columnIndex++], row),
					DescParser.Parse(scheme.Columns[columnIndex++], row),
					PortraitAddrParser.Parse(scheme.Columns[columnIndex++], row),
					FullImageAddrParser.Parse(scheme.Columns[columnIndex++], row),
					TierParser.Parse(scheme.Columns[columnIndex++], row),
					MaxRankParser.Parse(scheme.Columns[columnIndex++], row),
					RankEffectNumParser.ParseArray(scheme.Columns[columnIndex++], row),
					TableHeroRankEffectParser.ParseArray(scheme.Columns[columnIndex++], row),
					TableHeroTowerParser.Parse(scheme.Columns[columnIndex++], row),
					TableHeroAbilityParser.Parse(scheme.Columns[columnIndex++], row)
                );
                
                list.Add(rowObj);
            }

            if (Directory.Exists("Assets/Resources/Table") == false)
            {
                Directory.CreateDirectory("Assets/Resources/Table");
            }

            using (var stream = new FileStream("Assets/Resources/Table/TableHero.bytes", FileMode.Create))
            {
                Serializer.SerializeToStream(stream, list, _Encrypt: true, _EncryptionKey: TableManager.SECURE_KEY);
            }
            
            //if (Directory.Exists("Assets/Resources/Table/Json") == false)
            //{
            //    Directory.CreateDirectory("Assets/Resources/Table/Json");
            //}
            
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText("Assets/Resources/Table/Json/TableHero.json.txt", json, System.Text.Encoding.UTF8);
        }
        
        private static void SerializeHeroTower(Scheme scheme)
        {
            var list = new List<RowHeroTower>();
            var sheet = scheme.Sheet;
            int firstDataRowNum = sheet.FirstRowNum + 3;
            int lastDataRowNum = sheet.LastRowNum;
            
            int columnIndex = 0;
			var KeyParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var TagParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var RateParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var NameParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var GridXParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.IntParser;
			var GridYParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.IntParser;
			var PrefabAddrParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var ThumbnailAddrParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var SkillParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;


            for (int i = firstDataRowNum; i <= lastDataRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row.GetCell(0).IsNullOrEmpty())
                {
                    continue;
                }
                                
                columnIndex = 0;
                var rowObj = new RowHeroTower(
					KeyParser.Parse(scheme.Columns[columnIndex++], row),
					TagParser.Parse(scheme.Columns[columnIndex++], row),
					RateParser.Parse(scheme.Columns[columnIndex++], row),
					NameParser.Parse(scheme.Columns[columnIndex++], row),
					GridXParser.Parse(scheme.Columns[columnIndex++], row),
					GridYParser.Parse(scheme.Columns[columnIndex++], row),
					PrefabAddrParser.Parse(scheme.Columns[columnIndex++], row),
					ThumbnailAddrParser.Parse(scheme.Columns[columnIndex++], row),
					SkillParser.Parse(scheme.Columns[columnIndex++], row)
                );
                
                list.Add(rowObj);
            }

            if (Directory.Exists("Assets/Resources/Table") == false)
            {
                Directory.CreateDirectory("Assets/Resources/Table");
            }

            using (var stream = new FileStream("Assets/Resources/Table/TableHeroTower.bytes", FileMode.Create))
            {
                Serializer.SerializeToStream(stream, list, _Encrypt: true, _EncryptionKey: TableManager.SECURE_KEY);
            }
            
            //if (Directory.Exists("Assets/Resources/Table/Json") == false)
            //{
            //    Directory.CreateDirectory("Assets/Resources/Table/Json");
            //}
            
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText("Assets/Resources/Table/Json/TableHeroTower.json.txt", json, System.Text.Encoding.UTF8);
        }
        
        private static void SerializeStatus(Scheme scheme)
        {
            var list = new List<RowStatus>();
            var sheet = scheme.Sheet;
            int firstDataRowNum = sheet.FirstRowNum + 3;
            int lastDataRowNum = sheet.LastRowNum;
            
            int columnIndex = 0;
			var KeyParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;


            for (int i = firstDataRowNum; i <= lastDataRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row.GetCell(0).IsNullOrEmpty())
                {
                    continue;
                }
                                
                columnIndex = 0;
                var rowObj = new RowStatus(
					KeyParser.Parse(scheme.Columns[columnIndex++], row)
                );
                
                list.Add(rowObj);
            }

            if (Directory.Exists("Assets/Resources/Table") == false)
            {
                Directory.CreateDirectory("Assets/Resources/Table");
            }

            using (var stream = new FileStream("Assets/Resources/Table/TableStatus.bytes", FileMode.Create))
            {
                Serializer.SerializeToStream(stream, list, _Encrypt: true, _EncryptionKey: TableManager.SECURE_KEY);
            }
            
            //if (Directory.Exists("Assets/Resources/Table/Json") == false)
            //{
            //    Directory.CreateDirectory("Assets/Resources/Table/Json");
            //}
            
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText("Assets/Resources/Table/Json/TableStatus.json.txt", json, System.Text.Encoding.UTF8);
        }
        
        private static void SerializeStat(Scheme scheme)
        {
            var list = new List<RowStat>();
            var sheet = scheme.Sheet;
            int firstDataRowNum = sheet.FirstRowNum + 3;
            int lastDataRowNum = sheet.LastRowNum;
            
            int columnIndex = 0;
			var KeyParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var NameParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;


            for (int i = firstDataRowNum; i <= lastDataRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row.GetCell(0).IsNullOrEmpty())
                {
                    continue;
                }
                                
                columnIndex = 0;
                var rowObj = new RowStat(
					KeyParser.Parse(scheme.Columns[columnIndex++], row),
					NameParser.Parse(scheme.Columns[columnIndex++], row)
                );
                
                list.Add(rowObj);
            }

            if (Directory.Exists("Assets/Resources/Table") == false)
            {
                Directory.CreateDirectory("Assets/Resources/Table");
            }

            using (var stream = new FileStream("Assets/Resources/Table/TableStat.bytes", FileMode.Create))
            {
                Serializer.SerializeToStream(stream, list, _Encrypt: true, _EncryptionKey: TableManager.SECURE_KEY);
            }
            
            //if (Directory.Exists("Assets/Resources/Table/Json") == false)
            //{
            //    Directory.CreateDirectory("Assets/Resources/Table/Json");
            //}
            
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText("Assets/Resources/Table/Json/TableStat.json.txt", json, System.Text.Encoding.UTF8);
        }
        
        private static void SerializeWave(Scheme scheme)
        {
            var list = new List<RowWave>();
            var sheet = scheme.Sheet;
            int firstDataRowNum = sheet.FirstRowNum + 3;
            int lastDataRowNum = sheet.LastRowNum;
            
            int columnIndex = 0;
			var KeyParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var NameParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var PathParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var DurationParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.FloatParser;
			var StatusKeyParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;


            for (int i = firstDataRowNum; i <= lastDataRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row.GetCell(0).IsNullOrEmpty())
                {
                    continue;
                }
                                
                columnIndex = 0;
                var rowObj = new RowWave(
					KeyParser.Parse(scheme.Columns[columnIndex++], row),
					NameParser.Parse(scheme.Columns[columnIndex++], row),
					PathParser.Parse(scheme.Columns[columnIndex++], row),
					DurationParser.Parse(scheme.Columns[columnIndex++], row),
					StatusKeyParser.Parse(scheme.Columns[columnIndex++], row)
                );
                
                list.Add(rowObj);
            }

            if (Directory.Exists("Assets/Resources/Table") == false)
            {
                Directory.CreateDirectory("Assets/Resources/Table");
            }

            using (var stream = new FileStream("Assets/Resources/Table/TableWave.bytes", FileMode.Create))
            {
                Serializer.SerializeToStream(stream, list, _Encrypt: true, _EncryptionKey: TableManager.SECURE_KEY);
            }
            
            //if (Directory.Exists("Assets/Resources/Table/Json") == false)
            //{
            //    Directory.CreateDirectory("Assets/Resources/Table/Json");
            //}
            
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText("Assets/Resources/Table/Json/TableWave.json.txt", json, System.Text.Encoding.UTF8);
        }
        

    }
}