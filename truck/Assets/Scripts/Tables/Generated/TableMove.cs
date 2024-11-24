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
		/// 이동속도
		/// </summary>
		public global::System.Int32 Speed => _Speed;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.Single _DestX;
		[SerializeAbleField(2)] private global::System.Single _DestY;
		[SerializeAbleField(3)] private global::System.Int32 _Speed;


        public int Index { get; set; }
        
        public RowMove() {}

        public RowMove(global::System.String __Key, global::System.Single __DestX, global::System.Single __DestY, global::System.Int32 __Speed)
        {
			_Key = __Key;
			_DestX = __DestX;
			_DestY = __DestY;
			_Speed = __Speed;

        }
    }

    [SerializeAbleClass]
    public partial class TableMove : Table<RowMove, global::System.String>
    {

    }
}