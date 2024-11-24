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
			SerializeCharacter(schemes["Character"]);
			SerializeCharacterSpecial(schemes["CharacterSpecial"]);
			SerializeMove(schemes["Move"]);
			SerializeSkill(schemes["Skill"]);
			SerializeSpwaner(schemes["Spwaner"]);

            AssetDatabase.Refresh();
        }
        
        private static void SerializeCharacter(Scheme scheme)
        {
            var list = new List<RowCharacter>();
            var sheet = scheme.Sheet;
            int firstDataRowNum = sheet.FirstRowNum + 3;
            int lastDataRowNum = sheet.LastRowNum;
            
            int columnIndex = 0;
			var KeyParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var NameParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var MonsterParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var HPParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var ATKParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var DEFParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var SPEEDParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var PrefabsParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var IconParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var IsSpecialParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.BoolParser;
			var SpecialMonsterTagParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;


            for (int i = firstDataRowNum; i <= lastDataRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row.GetCell(0).IsNullOrEmpty())
                {
                    continue;
                }
                                
                columnIndex = 0;
                var rowObj = new RowCharacter(
					KeyParser.Parse(scheme.Columns[columnIndex++], row),
					NameParser.Parse(scheme.Columns[columnIndex++], row),
					MonsterParser.Parse(scheme.Columns[columnIndex++], row),
					HPParser.Parse(scheme.Columns[columnIndex++], row),
					ATKParser.Parse(scheme.Columns[columnIndex++], row),
					DEFParser.Parse(scheme.Columns[columnIndex++], row),
					SPEEDParser.Parse(scheme.Columns[columnIndex++], row),
					PrefabsParser.Parse(scheme.Columns[columnIndex++], row),
					IconParser.Parse(scheme.Columns[columnIndex++], row),
					IsSpecialParser.Parse(scheme.Columns[columnIndex++], row),
					SpecialMonsterTagParser.Parse(scheme.Columns[columnIndex++], row)
                );
                
                list.Add(rowObj);
            }

            if (Directory.Exists("Assets/Resources/Table") == false)
            {
                Directory.CreateDirectory("Assets/Resources/Table");
            }

            using (var stream = new FileStream("Assets/Resources/Table/TableCharacter.bytes", FileMode.Create))
            {
                Serializer.SerializeToStream(stream, list, _Encrypt: true, _EncryptionKey: TableManager.SECURE_KEY);
            }
            
            //if (Directory.Exists("Assets/Resources/Table/Json") == false)
            //{
            //    Directory.CreateDirectory("Assets/Resources/Table/Json");
            //}
            
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText("Assets/Resources/Table/Json/TableCharacter.json.txt", json, System.Text.Encoding.UTF8);
        }
        
        private static void SerializeCharacterSpecial(Scheme scheme)
        {
            var list = new List<RowCharacterSpecial>();
            var sheet = scheme.Sheet;
            int firstDataRowNum = sheet.FirstRowNum + 3;
            int lastDataRowNum = sheet.LastRowNum;
            
            int columnIndex = 0;
			var KeyParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var TagParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var RateParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var RewardValueParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var PrefabsParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var IconParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;


            for (int i = firstDataRowNum; i <= lastDataRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row.GetCell(0).IsNullOrEmpty())
                {
                    continue;
                }
                                
                columnIndex = 0;
                var rowObj = new RowCharacterSpecial(
					KeyParser.Parse(scheme.Columns[columnIndex++], row),
					TagParser.Parse(scheme.Columns[columnIndex++], row),
					RateParser.Parse(scheme.Columns[columnIndex++], row),
					RewardValueParser.Parse(scheme.Columns[columnIndex++], row),
					PrefabsParser.Parse(scheme.Columns[columnIndex++], row),
					IconParser.Parse(scheme.Columns[columnIndex++], row)
                );
                
                list.Add(rowObj);
            }

            if (Directory.Exists("Assets/Resources/Table") == false)
            {
                Directory.CreateDirectory("Assets/Resources/Table");
            }

            using (var stream = new FileStream("Assets/Resources/Table/TableCharacterSpecial.bytes", FileMode.Create))
            {
                Serializer.SerializeToStream(stream, list, _Encrypt: true, _EncryptionKey: TableManager.SECURE_KEY);
            }
            
            //if (Directory.Exists("Assets/Resources/Table/Json") == false)
            //{
            //    Directory.CreateDirectory("Assets/Resources/Table/Json");
            //}
            
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText("Assets/Resources/Table/Json/TableCharacterSpecial.json.txt", json, System.Text.Encoding.UTF8);
        }
        
        private static void SerializeMove(Scheme scheme)
        {
            var list = new List<RowMove>();
            var sheet = scheme.Sheet;
            int firstDataRowNum = sheet.FirstRowNum + 3;
            int lastDataRowNum = sheet.LastRowNum;
            
            int columnIndex = 0;
			var KeyParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var DestXParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.FloatParser;
			var DestYParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.FloatParser;
			var SpeedParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.IntParser;


            for (int i = firstDataRowNum; i <= lastDataRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row.GetCell(0).IsNullOrEmpty())
                {
                    continue;
                }
                                
                columnIndex = 0;
                var rowObj = new RowMove(
					KeyParser.Parse(scheme.Columns[columnIndex++], row),
					DestXParser.Parse(scheme.Columns[columnIndex++], row),
					DestYParser.Parse(scheme.Columns[columnIndex++], row),
					SpeedParser.Parse(scheme.Columns[columnIndex++], row)
                );
                
                list.Add(rowObj);
            }

            if (Directory.Exists("Assets/Resources/Table") == false)
            {
                Directory.CreateDirectory("Assets/Resources/Table");
            }

            using (var stream = new FileStream("Assets/Resources/Table/TableMove.bytes", FileMode.Create))
            {
                Serializer.SerializeToStream(stream, list, _Encrypt: true, _EncryptionKey: TableManager.SECURE_KEY);
            }
            
            //if (Directory.Exists("Assets/Resources/Table/Json") == false)
            //{
            //    Directory.CreateDirectory("Assets/Resources/Table/Json");
            //}
            
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText("Assets/Resources/Table/Json/TableMove.json.txt", json, System.Text.Encoding.UTF8);
        }
        
        private static void SerializeSkill(Scheme scheme)
        {
            var list = new List<RowSkill>();
            var sheet = scheme.Sheet;
            int firstDataRowNum = sheet.FirstRowNum + 3;
            int lastDataRowNum = sheet.LastRowNum;
            
            int columnIndex = 0;
			var KeyParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var CoolTimeParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var CoolTimeDurationParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var PrefabParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var DmgParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var EffectPrefabParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var SkillTypeParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var TargetingTypeParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var SkillCategoryParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var SkillKeyParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var SkillValueParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var UpgradeCurerencyParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var UpgradeCostParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var NextLevelParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;


            for (int i = firstDataRowNum; i <= lastDataRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row.GetCell(0).IsNullOrEmpty())
                {
                    continue;
                }
                                
                columnIndex = 0;
                var rowObj = new RowSkill(
					KeyParser.Parse(scheme.Columns[columnIndex++], row),
					CoolTimeParser.Parse(scheme.Columns[columnIndex++], row),
					CoolTimeDurationParser.Parse(scheme.Columns[columnIndex++], row),
					PrefabParser.Parse(scheme.Columns[columnIndex++], row),
					DmgParser.Parse(scheme.Columns[columnIndex++], row),
					EffectPrefabParser.Parse(scheme.Columns[columnIndex++], row),
					SkillTypeParser.Parse(scheme.Columns[columnIndex++], row),
					TargetingTypeParser.Parse(scheme.Columns[columnIndex++], row),
					SkillCategoryParser.Parse(scheme.Columns[columnIndex++], row),
					SkillKeyParser.Parse(scheme.Columns[columnIndex++], row),
					SkillValueParser.Parse(scheme.Columns[columnIndex++], row),
					UpgradeCurerencyParser.Parse(scheme.Columns[columnIndex++], row),
					UpgradeCostParser.Parse(scheme.Columns[columnIndex++], row),
					NextLevelParser.Parse(scheme.Columns[columnIndex++], row)
                );
                
                list.Add(rowObj);
            }

            if (Directory.Exists("Assets/Resources/Table") == false)
            {
                Directory.CreateDirectory("Assets/Resources/Table");
            }

            using (var stream = new FileStream("Assets/Resources/Table/TableSkill.bytes", FileMode.Create))
            {
                Serializer.SerializeToStream(stream, list, _Encrypt: true, _EncryptionKey: TableManager.SECURE_KEY);
            }
            
            //if (Directory.Exists("Assets/Resources/Table/Json") == false)
            //{
            //    Directory.CreateDirectory("Assets/Resources/Table/Json");
            //}
            
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText("Assets/Resources/Table/Json/TableSkill.json.txt", json, System.Text.Encoding.UTF8);
        }
        
        private static void SerializeSpwaner(Scheme scheme)
        {
            var list = new List<RowSpwaner>();
            var sheet = scheme.Sheet;
            int firstDataRowNum = sheet.FirstRowNum + 3;
            int lastDataRowNum = sheet.LastRowNum;
            
            int columnIndex = 0;
			var KeyParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var DistanceMinParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var DistanceMaxParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var RepeatDistanceParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var RateParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.FloatParser;
			var MaxSpwanParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var MonsterParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var ScoreParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.LongParser;
			var IncreaseAtkScaleParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.FloatParser;
			var IncreaseHpScaleParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.FloatParser;
			var LoodParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var MoveKeyParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;
			var PrefabsParser = scheme.Columns[columnIndex++].Parser as global::DevDev.Table.Editor.TypeParser.Implements.StringParser;


            for (int i = firstDataRowNum; i <= lastDataRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row.GetCell(0).IsNullOrEmpty())
                {
                    continue;
                }
                                
                columnIndex = 0;
                var rowObj = new RowSpwaner(
					KeyParser.Parse(scheme.Columns[columnIndex++], row),
					DistanceMinParser.Parse(scheme.Columns[columnIndex++], row),
					DistanceMaxParser.Parse(scheme.Columns[columnIndex++], row),
					RepeatDistanceParser.Parse(scheme.Columns[columnIndex++], row),
					RateParser.Parse(scheme.Columns[columnIndex++], row),
					MaxSpwanParser.Parse(scheme.Columns[columnIndex++], row),
					MonsterParser.Parse(scheme.Columns[columnIndex++], row),
					ScoreParser.Parse(scheme.Columns[columnIndex++], row),
					IncreaseAtkScaleParser.Parse(scheme.Columns[columnIndex++], row),
					IncreaseHpScaleParser.Parse(scheme.Columns[columnIndex++], row),
					LoodParser.Parse(scheme.Columns[columnIndex++], row),
					MoveKeyParser.Parse(scheme.Columns[columnIndex++], row),
					PrefabsParser.Parse(scheme.Columns[columnIndex++], row)
                );
                
                list.Add(rowObj);
            }

            if (Directory.Exists("Assets/Resources/Table") == false)
            {
                Directory.CreateDirectory("Assets/Resources/Table");
            }

            using (var stream = new FileStream("Assets/Resources/Table/TableSpwaner.bytes", FileMode.Create))
            {
                Serializer.SerializeToStream(stream, list, _Encrypt: true, _EncryptionKey: TableManager.SECURE_KEY);
            }
            
            //if (Directory.Exists("Assets/Resources/Table/Json") == false)
            //{
            //    Directory.CreateDirectory("Assets/Resources/Table/Json");
            //}
            
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText("Assets/Resources/Table/Json/TableSpwaner.json.txt", json, System.Text.Encoding.UTF8);
        }
        

    }
}