//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowProduct : IRow<global::System.String>
    {
		public global::System.String Key => _Key;

		public global::System.String IAPKey_Google => _IAPKey_Google;

		/// <summary>
		/// 패키지 키값
		/// </summary>
		public global::System.String IAPKey_Apple => _IAPKey_Apple;

		public global::System.String IAPKey_Onestore => _IAPKey_Onestore;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.String _IAPKey_Google;
		[SerializeAbleField(2)] private global::System.String _IAPKey_Apple;
		[SerializeAbleField(3)] private global::System.String _IAPKey_Onestore;


        public int Index { get; set; }
        
        public RowProduct() {}

        public RowProduct(global::System.String __Key, global::System.String __IAPKey_Google, global::System.String __IAPKey_Apple, global::System.String __IAPKey_Onestore)
        {
			_Key = __Key;
			_IAPKey_Google = __IAPKey_Google;
			_IAPKey_Apple = __IAPKey_Apple;
			_IAPKey_Onestore = __IAPKey_Onestore;

        }
    }

    [SerializeAbleClass]
    public partial class TableProduct : Table<RowProduct, global::System.String>
    {

    }
}