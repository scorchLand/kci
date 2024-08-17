using DevDev.Table.Editor.Meta;
using NPOI.SS.UserModel;

namespace DevDev.Table.Editor.TypeParser
{
    public interface ITypeParser
    {
        System.Type SerializeType { get; }
        int CellRange { get; }
        string[] TableTypes { get; }
        string GetParserTypeName();
    }

    public interface ITypeParser<out T> : ITypeParser
    {
        T Parse(Column column, IRow row);
        T[] ParseArray(Column column, IRow row);
    }
}