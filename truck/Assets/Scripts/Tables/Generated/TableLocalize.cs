//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowLocalize : IRow<global::System.String>
    {
		public global::System.String Key => _Key;

		public global::System.String Korean => _Korean;

		public global::System.String English => _English;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.String _Korean;
		[SerializeAbleField(2)] private global::System.String _English;


        public int Index { get; set; }
        
        public RowLocalize() {}

        public RowLocalize(global::System.String __Key, global::System.String __Korean, global::System.String __English)
        {
			_Key = __Key;
			_Korean = __Korean;
			_English = __English;

        }
    }

    [SerializeAbleClass]
    public partial class TableLocalize : Table<RowLocalize, global::System.String>
    {

    }
}