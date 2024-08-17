namespace DevDev.Table
{
    public interface IRow<out TKey>
    {
        TKey Key { get; }
        int Index { get; set; }
    }
}