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

            AssetDatabase.Refresh();
        }
        

    }
}