//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowCharacter : IRow<global::System.String>
    {
		public global::System.String Key => _Key;

		public global::System.String Name => _Name;

		/// <summary>
		/// 어떤 몬스터인지
		/// Mob = 일반
		/// Obs = 장애물
		/// Boss = 보스(y값 영향 안받음)
		/// </summary>
		public global::System.String Monster => _Monster;

		public global::System.Int64 HP => _HP;

		public global::System.Int64 ATK => _ATK;

		public global::System.Int64 DEF => _DEF;

		/// <summary>
		/// 플레이어
		/// </summary>
		public global::System.Int64 SPEED => _SPEED;

		/// <summary>
		/// 인게임 캐릭터 프리팹
		/// </summary>
		public global::System.String Prefabs => _Prefabs;

		/// <summary>
		/// 인게임 캐릭터 아이콘
		/// (도감 등에 사용)
		/// </summary>
		public global::System.String Icon => _Icon;

		/// <summary>
		/// 스페셜 몬스터를 쓸것인지
		/// </summary>
		public global::System.Boolean IsSpecial => _IsSpecial;

		/// <summary>
		/// 스페셜몬스터 태그
		/// </summary>
		public global::System.String SpecialMonsterTag => _SpecialMonsterTag;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.String _Name;
		[SerializeAbleField(2)] private global::System.String _Monster;
		[SerializeAbleField(3)] private global::System.Int64 _HP;
		[SerializeAbleField(4)] private global::System.Int64 _ATK;
		[SerializeAbleField(5)] private global::System.Int64 _DEF;
		[SerializeAbleField(6)] private global::System.Int64 _SPEED;
		[SerializeAbleField(7)] private global::System.String _Prefabs;
		[SerializeAbleField(8)] private global::System.String _Icon;
		[SerializeAbleField(9)] private global::System.Boolean _IsSpecial;
		[SerializeAbleField(10)] private global::System.String _SpecialMonsterTag;


        public int Index { get; set; }
        
        public RowCharacter() {}

        public RowCharacter(global::System.String __Key, global::System.String __Name, global::System.String __Monster, global::System.Int64 __HP, global::System.Int64 __ATK, global::System.Int64 __DEF, global::System.Int64 __SPEED, global::System.String __Prefabs, global::System.String __Icon, global::System.Boolean __IsSpecial, global::System.String __SpecialMonsterTag)
        {
			_Key = __Key;
			_Name = __Name;
			_Monster = __Monster;
			_HP = __HP;
			_ATK = __ATK;
			_DEF = __DEF;
			_SPEED = __SPEED;
			_Prefabs = __Prefabs;
			_Icon = __Icon;
			_IsSpecial = __IsSpecial;
			_SpecialMonsterTag = __SpecialMonsterTag;

        }
    }

    [SerializeAbleClass]
    public partial class TableCharacter : Table<RowCharacter, global::System.String>
    {

    }
}