using System;
using System.Collections.Generic;
using System.Linq;
using DevDev.Extensions;
using DevDev.Table.Editor.TypeParser.Implements;

namespace DevDev.Table.Editor.TypeParser
{
    public static class SupportedType
    {
        private static readonly Dictionary<string, ITypeParser> _parsers
            = new Dictionary<string, ITypeParser>();

        private static readonly Dictionary<string, ITypeParser> _enumParsers 
            = new Dictionary<string, ITypeParser>();

        static SupportedType()
        {
            var typeParser = typeof(ITypeParser);
            var supportedTypes = typeof(SupportedType).Assembly.GetTypes()
                .Where(type => type.IsClass 
                               && type.IsAbstract == false 
                               && type.IsGenericType == false
                               && typeParser.IsAssignableFrom(type));

            foreach (var type in supportedTypes)
            {
                var instance = Activator.CreateInstance(type) as ITypeParser;
                if (instance == null)
                {
                    continue;
                }
                
                foreach (string tableType in instance.TableTypes)
                {
                    _parsers.Add(tableType.ToLower(), instance);
                }
            }
        }

        public static ITypeParser Get(string name)
        {
            const string ENUM_PREFIX = "enum:";
            string lowerName = name.ToLower();
            if (name.StartsWith(ENUM_PREFIX))
            {
                return GetFromEnum(name.Remove(0, ENUM_PREFIX.Length).Trim());
            }
            
            return _parsers.Get(lowerName);
        }

        private static ITypeParser GetFromEnum(string enumName)
        {
            var parser = _enumParsers.Get(enumName);
            if (parser != null)
            {
                return parser;
            }

            var enumParserType = typeof(EnumParser<>);
            var enumType = GetTypeFromAllAssembly(enumName);
            var type = enumParserType.MakeGenericType(enumType);
            parser = Activator.CreateInstance(type) as ITypeParser;
            _enumParsers.Add(enumName, parser);
            return parser;
        }

        private static Type GetTypeFromAllAssembly(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null)
            {
                return type;
            }

            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName);
                if (type != null)
                {
                    return type;
                }
            }
            
            return null;
        }
    }
}