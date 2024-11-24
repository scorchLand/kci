//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowSpwaner : IRow<global::System.String>
    {
		public global::System.String Key => _Key;

		/// <summary>
		/// 해당 거리부터 등장
		/// </summary>
		public global::System.Int64 DistanceMin => _DistanceMin;

		/// <summary>
		/// 해당 거리까지 등장
		/// </summary>
		public global::System.Int64 DistanceMax => _DistanceMax;

		/// <summary>
		/// 해당 거리마다 스폰실행
		/// </summary>
		public global::System.Int64 RepeatDistance => _RepeatDistance;

		/// <summary>
		/// 스폰 확률
		/// </summary>
		public global::System.Single Rate => _Rate;

		/// <summary>
		/// 최대 스폰 횟수
		/// 0 = 제한없음
		/// </summary>
		public global::System.Int64 MaxSpwan => _MaxSpwan;

		/// <summary>
		/// 등장시킬 몬스터
		/// </summary>
		public global::System.String Monster => _Monster;

		/// <summary>
		/// 점수
		/// </summary>
		public global::System.Int64 Score => _Score;

		/// <summary>
		/// 공격력 증가 배율
		/// </summary>
		public global::System.Single IncreaseAtkScale => _IncreaseAtkScale;

		/// <summary>
		/// 체력 증가 배율
		/// </summary>
		public global::System.Single IncreaseHpScale => _IncreaseHpScale;

		/// <summary>
		/// 등장 좌표
		/// </summary>
		public global::System.String Lood => _Lood;

		/// <summary>
		/// 이동패턴
		/// </summary>
		public global::System.String MoveKey => _MoveKey;

		/// <summary>
		/// 인게임 캐릭터 프리팹
		/// </summary>
		public global::System.String Prefabs => _Prefabs;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.Int64 _DistanceMin;
		[SerializeAbleField(2)] private global::System.Int64 _DistanceMax;
		[SerializeAbleField(3)] private global::System.Int64 _RepeatDistance;
		[SerializeAbleField(4)] private global::System.Single _Rate;
		[SerializeAbleField(5)] private global::System.Int64 _MaxSpwan;
		[SerializeAbleField(6)] private global::System.String _Monster;
		[SerializeAbleField(7)] private global::System.Int64 _Score;
		[SerializeAbleField(8)] private global::System.Single _IncreaseAtkScale;
		[SerializeAbleField(9)] private global::System.Single _IncreaseHpScale;
		[SerializeAbleField(10)] private global::System.String _Lood;
		[SerializeAbleField(11)] private global::System.String _MoveKey;
		[SerializeAbleField(12)] private global::System.String _Prefabs;


        public int Index { get; set; }
        
        public RowSpwaner() {}

        public RowSpwaner(global::System.String __Key, global::System.Int64 __DistanceMin, global::System.Int64 __DistanceMax, global::System.Int64 __RepeatDistance, global::System.Single __Rate, global::System.Int64 __MaxSpwan, global::System.String __Monster, global::System.Int64 __Score, global::System.Single __IncreaseAtkScale, global::System.Single __IncreaseHpScale, global::System.String __Lood, global::System.String __MoveKey, global::System.String __Prefabs)
        {
			_Key = __Key;
			_DistanceMin = __DistanceMin;
			_DistanceMax = __DistanceMax;
			_RepeatDistance = __RepeatDistance;
			_Rate = __Rate;
			_MaxSpwan = __MaxSpwan;
			_Monster = __Monster;
			_Score = __Score;
			_IncreaseAtkScale = __IncreaseAtkScale;
			_IncreaseHpScale = __IncreaseHpScale;
			_Lood = __Lood;
			_MoveKey = __MoveKey;
			_Prefabs = __Prefabs;

        }
    }

    [SerializeAbleClass]
    public partial class TableSpwaner : Table<RowSpwaner, global::System.String>
    {

    }
}