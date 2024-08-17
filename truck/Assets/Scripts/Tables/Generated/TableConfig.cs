//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowConfig : IRow<global::System.String>
    {
		public global::System.String Key => _Key;

		public global::System.String Value => _Value;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.String _Value;


        public int Index { get; set; }
        
        public RowConfig() {}

        public RowConfig(global::System.String __Key, global::System.String __Value)
        {
			_Key = __Key;
			_Value = __Value;

        }
    }

    [SerializeAbleClass]
    public partial class TableConfig : Table<RowConfig, global::System.String>
    {

    }
}