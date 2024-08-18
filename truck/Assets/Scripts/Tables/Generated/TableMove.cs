//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowMove : IRow<global::System.String>
    {
		public global::System.String Key => _Key;

		public global::System.Single DestX => _DestX;

		public global::System.Single DestY => _DestY;

		/// <summary>
		/// 완료시간(이동시간)
		/// </summary>
		public global::System.Int32 DurationTime => _DurationTime;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.Single _DestX;
		[SerializeAbleField(2)] private global::System.Single _DestY;
		[SerializeAbleField(3)] private global::System.Int32 _DurationTime;


        public int Index { get; set; }
        
        public RowMove() {}

        public RowMove(global::System.String __Key, global::System.Single __DestX, global::System.Single __DestY, global::System.Int32 __DurationTime)
        {
			_Key = __Key;
			_DestX = __DestX;
			_DestY = __DestY;
			_DurationTime = __DurationTime;

        }
    }

    [SerializeAbleClass]
    public partial class TableMove : Table<RowMove, global::System.String>
    {

    }
}