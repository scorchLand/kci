//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowBanWord : IRow<global::System.String>
    {
		public global::System.String Key => _Key;


		[SerializeAbleField(0)] private global::System.String _Key;


        public int Index { get; set; }
        
        public RowBanWord() {}

        public RowBanWord(global::System.String __Key)
        {
			_Key = __Key;

        }
    }

    [SerializeAbleClass]
    public partial class TableBanWord : Table<RowBanWord, global::System.String>
    {

    }
}