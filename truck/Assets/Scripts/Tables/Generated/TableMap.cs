//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowMap : IRow<global::System.String>
    {
		/// <summary>
		/// 월드맵 인덱스, 호출시 필요
		/// </summary>
		public global::System.String Key => _Key;

		/// <summary>
		/// 상단 표기 이름
		/// </summary>
		public global::System.String Name => _Name;

		/// <summary>
		/// 맵 프리팹 위치
		/// </summary>
		public global::System.String PrefabPath => _PrefabPath;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.String _Name;
		[SerializeAbleField(2)] private global::System.String _PrefabPath;


        public int Index { get; set; }
        
        public RowMap() {}

        public RowMap(global::System.String __Key, global::System.String __Name, global::System.String __PrefabPath)
        {
			_Key = __Key;
			_Name = __Name;
			_PrefabPath = __PrefabPath;

        }
    }

    [SerializeAbleClass]
    public partial class TableMap : Table<RowMap, global::System.String>
    {

    }
}