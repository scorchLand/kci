//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowAvatar : IRow<global::System.Int32>
    {
		/// <summary>
		/// 키 값
		/// </summary>
		public global::System.Int32 Key => _Key;

		/// <summary>
		/// 아바타 이름
		/// </summary>
		public global::System.String Name => _Name;

		/// <summary>
		/// 등급
		/// </summary>
		public global::System.Int32 Grade => _Grade;

		/// <summary>
		/// 이미지 이름
		/// </summary>
		public global::System.String ImageName => _ImageName;

		/// <summary>
		/// 프리팹 이름
		/// </summary>
		public global::System.String PrefabName => _PrefabName;

		/// <summary>
		/// 최고 레벨
		/// </summary>
		public global::System.Int32 MaxLevel => _MaxLevel;

		/// <summary>
		/// 최초 시작 최대 레벨
		/// </summary>
		public global::System.Int32 MaxStart => _MaxStart;

		/// <summary>
		/// 돌파마다 상승하는 최대 레벨
		/// </summary>
		public global::System.Int32 MaxIncrease => _MaxIncrease;

		/// <summary>
		/// 레벨업 소모 아이템 키
		/// </summary>
		public global::System.Int32 LevelupItemKey => _LevelupItemKey;

		/// <summary>
		/// 레벨업 소모량
		/// </summary>
		public global::System.Int32 LevelupCostBase => _LevelupCostBase;

		/// <summary>
		/// 레벨업 소모량 증가값
		/// </summary>
		public global::System.Int32 LevelupCostIncrease => _LevelupCostIncrease;

		/// <summary>
		/// 돌파 소모 아이템 키
		/// </summary>
		public global::System.Int32 MaxItemKey => _MaxItemKey;

		/// <summary>
		/// 돌파 소모 아이템 개수
		/// </summary>
		public global::System.Int32 MaxCostBase => _MaxCostBase;

		/// <summary>
		/// 돌파 아이템 개수 증가량 
		/// </summary>
		public global::System.Int32 MaxCostIncrease => _MaxCostIncrease;


		[SerializeAbleField(0)] private global::System.Int32 _Key;
		[SerializeAbleField(1)] private global::System.String _Name;
		[SerializeAbleField(2)] private global::System.Int32 _Grade;
		[SerializeAbleField(3)] private global::System.String _ImageName;
		[SerializeAbleField(4)] private global::System.String _PrefabName;
		[SerializeAbleField(5)] private global::System.Int32 _MaxLevel;
		[SerializeAbleField(6)] private global::System.Int32 _MaxStart;
		[SerializeAbleField(7)] private global::System.Int32 _MaxIncrease;
		[SerializeAbleField(8)] private global::System.Int32 _LevelupItemKey;
		[SerializeAbleField(9)] private global::System.Int32 _LevelupCostBase;
		[SerializeAbleField(10)] private global::System.Int32 _LevelupCostIncrease;
		[SerializeAbleField(11)] private global::System.Int32 _MaxItemKey;
		[SerializeAbleField(12)] private global::System.Int32 _MaxCostBase;
		[SerializeAbleField(13)] private global::System.Int32 _MaxCostIncrease;


        public int Index { get; set; }
        
        public RowAvatar() {}

        public RowAvatar(global::System.Int32 __Key, global::System.String __Name, global::System.Int32 __Grade, global::System.String __ImageName, global::System.String __PrefabName, global::System.Int32 __MaxLevel, global::System.Int32 __MaxStart, global::System.Int32 __MaxIncrease, global::System.Int32 __LevelupItemKey, global::System.Int32 __LevelupCostBase, global::System.Int32 __LevelupCostIncrease, global::System.Int32 __MaxItemKey, global::System.Int32 __MaxCostBase, global::System.Int32 __MaxCostIncrease)
        {
			_Key = __Key;
			_Name = __Name;
			_Grade = __Grade;
			_ImageName = __ImageName;
			_PrefabName = __PrefabName;
			_MaxLevel = __MaxLevel;
			_MaxStart = __MaxStart;
			_MaxIncrease = __MaxIncrease;
			_LevelupItemKey = __LevelupItemKey;
			_LevelupCostBase = __LevelupCostBase;
			_LevelupCostIncrease = __LevelupCostIncrease;
			_MaxItemKey = __MaxItemKey;
			_MaxCostBase = __MaxCostBase;
			_MaxCostIncrease = __MaxCostIncrease;

        }
    }

    [SerializeAbleClass]
    public partial class TableAvatar : Table<RowAvatar, global::System.Int32>
    {

    }
}