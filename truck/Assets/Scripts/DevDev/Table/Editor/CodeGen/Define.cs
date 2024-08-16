namespace DevDev.Table.Editor.CodeGen
{
    public static class Define
    {
        public const string TEMPLATE_CLASS_FILE_NAME = "TemplateClass.cs.txt";
        public const string TEMPLATE_SERIALIZER_FILE_NAME = "TemplateSerializer.cs.txt";
        public const string TEMPLATE_RUNTIME_FILE_NAME = "RuntimeLoader.cs.txt";
        public const string TEMPLATE_SERIALIZER_METHOD_FILE_NAME = "TemplateSerializerMethod.cs.txt";

        public const string NAME_SPACE = "Grooz";
        public const string NAME_SPACE_EDITOR = "Grooz.Editor";
        public const string GENERATE_FOLDER_PATH = "Scripts/Tables/Generated";
        public const string EXPORT_PATH = "Assets/Resources/" + EXPORT_PATH_FOR_RUNTIME;
        public const string EXPORT_PATH_FOR_RUNTIME = "Table";
        
        public const string TOKEN_NAMESPACE = "@Namespace";
        public const string TOKEN_ROW_NAME = "@RowName";
        public const string TOKEN_KEY_TYPE = "@KeyType";
        public const string TOKEN_ROW_IMPLEMENT = "@RowImplement";
        public const string TOKEN_ROW_CONSTRUCTOR_PARAM = "@RowConstructorParam";
        public const string TOKEN_ROW_CONSTRUCTOR_IMPLEMENT = "@RowConstructorImpl";
        public const string TOKEN_TABLE_NAME = "@TableName";
        public const string TOKEN_TABLE_IMPLEMENT = "@TableImplement";

        public const string TOKEN_CALL_IMPLEMENT = "@CallImplement";
        public const string TOKEN_METHOD_IMPLEMENT = "@MethodImplement";
        public const string TOKEN_METHOD_IMPLEMENT_2 = "@2MethodImplement";
        

        public const string TOKEN_NAME = "@Name";
        public const string TOKEN_DEFINE_PARSER = "@DefineParser";
        public const string TOKEN_CONSTRUCTOR_PARAM = "@ConstructorParam";
        public const string TOKEN_EXPORT_PATH = "@ExportPath";
    }
}