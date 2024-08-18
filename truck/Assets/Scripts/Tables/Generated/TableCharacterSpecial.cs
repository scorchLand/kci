//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowCharacterSpecial : IRow<global::System.String>
    {
		public global::System.String Key => _Key;

		public global::System.String Tag => _Tag;

		public global::System.Int64 Rate => _Rate;

		/// <summary>
		/// 배율(곱연산)
		/// </summary>
		public global::System.Int64 RewardValue => _RewardValue;

		/// <summary>
		/// 인게임
		/// 획득시 보여주는 캐릭터 프리팹
		/// </summary>
		public global::System.String Prefabs => _Prefabs;

		/// <summary>
		/// 로비
		/// 도감 등에서 사용할 아이콘
		/// </summary>
		public global::System.String Icon => _Icon;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.String _Tag;
		[SerializeAbleField(2)] private global::System.Int64 _Rate;
		[SerializeAbleField(3)] private global::System.Int64 _RewardValue;
		[SerializeAbleField(4)] private global::System.String _Prefabs;
		[SerializeAbleField(5)] private global::System.String _Icon;


        public int Index { get; set; }
        
        public RowCharacterSpecial() {}

        public RowCharacterSpecial(global::System.String __Key, global::System.String __Tag, global::System.Int64 __Rate, global::System.Int64 __RewardValue, global::System.String __Prefabs, global::System.String __Icon)
        {
			_Key = __Key;
			_Tag = __Tag;
			_Rate = __Rate;
			_RewardValue = __RewardValue;
			_Prefabs = __Prefabs;
			_Icon = __Icon;

        }
    }

    [SerializeAbleClass]
    public partial class TableCharacterSpecial : Table<RowCharacterSpecial, global::System.String>
    {

    }
}