//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowStat : IRow<global::System.String>
    {
		public global::System.String Key => _Key;

		public global::System.String Name => _Name;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.String _Name;


        public int Index { get; set; }
        
        public RowStat() {}

        public RowStat(global::System.String __Key, global::System.String __Name)
        {
			_Key = __Key;
			_Name = __Name;

        }
    }

    [SerializeAbleClass]
    public partial class TableStat : Table<RowStat, global::System.String>
    {

    }
}