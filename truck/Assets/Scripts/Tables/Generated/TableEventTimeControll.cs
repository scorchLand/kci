//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowEventTimeControll : IRow<global::System.String>
    {
		/// <summary>
		/// 주의
		/// 상용에 적용 시
		/// 테이블 키 추가하고
		/// 지워선 안됨
		/// 기간끝나도 남겨둘 것
		/// </summary>
		public global::System.String Key => _Key;

		/// <summary>
		/// UTC 시작시간
		/// </summary>
		public global::System.Int64 StartDate => _StartDate;

		/// <summary>
		/// UTC 끝 시간
		/// </summary>
		public global::System.Int64 EndDate => _EndDate;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.Int64 _StartDate;
		[SerializeAbleField(2)] private global::System.Int64 _EndDate;


        public int Index { get; set; }
        
        public RowEventTimeControll() {}

        public RowEventTimeControll(global::System.String __Key, global::System.Int64 __StartDate, global::System.Int64 __EndDate)
        {
			_Key = __Key;
			_StartDate = __StartDate;
			_EndDate = __EndDate;

        }
    }

    [SerializeAbleClass]
    public partial class TableEventTimeControll : Table<RowEventTimeControll, global::System.String>
    {

    }
}