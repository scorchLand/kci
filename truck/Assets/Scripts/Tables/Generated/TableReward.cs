//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowReward : IRow<global::System.String>
    {
		/// <summary>
		/// 보상 키
		/// </summary>
		public global::System.String Key => _Key;

		/// <summary>
		/// 대표 아이콘 Path
		/// </summary>
		public global::System.String IconicIconPath => _IconicIconPath;

		/// <summary>
		/// 보상 아이템
		/// </summary>
		public global::System.String[] RewardItems => _RewardItems;

		/// <summary>
		/// 보상 아이템 개수
		/// </summary>
		public global::System.Int64[] RewardValues => _RewardValues;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.String _IconicIconPath;
		[SerializeAbleField(2)] private global::System.String[] _RewardItems;
		[SerializeAbleField(3)] private global::System.Int64[] _RewardValues;


        public int Index { get; set; }
        
        public RowReward() {}

        public RowReward(global::System.String __Key, global::System.String __IconicIconPath, global::System.String[] __RewardItems, global::System.Int64[] __RewardValues)
        {
			_Key = __Key;
			_IconicIconPath = __IconicIconPath;
			_RewardItems = __RewardItems;
			_RewardValues = __RewardValues;

        }
    }

    [SerializeAbleClass]
    public partial class TableReward : Table<RowReward, global::System.String>
    {

    }
}