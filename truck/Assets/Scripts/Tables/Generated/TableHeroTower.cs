//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowHeroTower : IRow<global::System.String>
    {
		public global::System.String Key => _Key;

		/// <summary>
		/// #Hero시트의
		/// TableHeroTower
		/// 확인
		/// </summary>
		public global::System.String Tag => _Tag;

		/// <summary>
		/// 빌드업 웨이브에서 뽑을 때
		/// 이 등급이 등장할 확률
		/// 해당 태그의 Rate를 합산하고
		/// 그 중 하나 소환
		/// </summary>
		public global::System.Int64 Rate => _Rate;

		public global::System.String Name => _Name;

		/// <summary>
		/// 가로칸
		/// </summary>
		public global::System.Int32 GridX => _GridX;

		/// <summary>
		/// 세로칸
		/// </summary>
		public global::System.Int32 GridY => _GridY;

		/// <summary>
		/// 전투할 타워 주소
		/// (게임옵젝의
		/// Tower폴더)
		/// </summary>
		public global::System.String PrefabAddr => _PrefabAddr;

		/// <summary>
		/// 타워 인벤토리에서
		/// 보여줄 프리팹 주소
		/// (게임옵젝의
		/// Data/Prefabs/Ui/
		/// UiComponent/Portraits
		/// </summary>
		public global::System.String ThumbnailAddr => _ThumbnailAddr;

		/// <summary>
		/// Skill테이블에서
		/// 해당 키 참고
		/// </summary>
		public global::System.String Skill => _Skill;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.String _Tag;
		[SerializeAbleField(2)] private global::System.Int64 _Rate;
		[SerializeAbleField(3)] private global::System.String _Name;
		[SerializeAbleField(4)] private global::System.Int32 _GridX;
		[SerializeAbleField(5)] private global::System.Int32 _GridY;
		[SerializeAbleField(6)] private global::System.String _PrefabAddr;
		[SerializeAbleField(7)] private global::System.String _ThumbnailAddr;
		[SerializeAbleField(8)] private global::System.String _Skill;


        public int Index { get; set; }
        
        public RowHeroTower() {}

        public RowHeroTower(global::System.String __Key, global::System.String __Tag, global::System.Int64 __Rate, global::System.String __Name, global::System.Int32 __GridX, global::System.Int32 __GridY, global::System.String __PrefabAddr, global::System.String __ThumbnailAddr, global::System.String __Skill)
        {
			_Key = __Key;
			_Tag = __Tag;
			_Rate = __Rate;
			_Name = __Name;
			_GridX = __GridX;
			_GridY = __GridY;
			_PrefabAddr = __PrefabAddr;
			_ThumbnailAddr = __ThumbnailAddr;
			_Skill = __Skill;

        }
    }

    [SerializeAbleClass]
    public partial class TableHeroTower : Table<RowHeroTower, global::System.String>
    {

    }
}