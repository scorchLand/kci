//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowHero : IRow<global::System.String>
    {
		public global::System.String Key => _Key;

		/// <summary>
		/// 영웅 이름
		/// </summary>
		public global::System.String Name => _Name;

		/// <summary>
		/// 영웅 설명
		/// 간단한 소개 등.
		/// Ex) 평범한 이세계
		/// 고등학생이다
		/// </summary>
		public global::System.String Desc => _Desc;

		/// <summary>
		/// 로비 영웅 탭에서 보일
		/// 썸네일 이미지 주소
		/// </summary>
		public global::System.String PortraitAddr => _PortraitAddr;

		/// <summary>
		/// 로비 영웅 정보창에서
		/// 보일 썸네일 이미지 주소
		/// </summary>
		public global::System.String FullImageAddr => _FullImageAddr;

		/// <summary>
		/// *아삭 논의&검토 필요*
		/// TIER_1 = 일반
		/// TIER_2 = 고급
		/// TIER_3 = 영웅
		/// TIER_4 = 전설
		/// TIER_5 = 신화
		/// </summary>
		public global::System.String Tier => _Tier;

		/// <summary>
		/// 최대 랭크
		/// </summary>
		public global::System.Int64 MaxRank => _MaxRank;

		/// <summary>
		/// 특정 랭크를 달성하면
		/// 우측의 추가 효과가 적용됨
		/// </summary>
		public global::System.Int64[] RankEffectNum => _RankEffectNum;

		/// <summary>
		/// 영웅의 로비 랭크 정보 Tag
		/// 태그 형식으로 랭크 조회
		/// (Key 형식으로 해도 무관)
		/// </summary>
		public global::System.String[] TableHeroRankEffect => _TableHeroRankEffect;

		/// <summary>
		/// ★영웅의 인게임 타워 Tag
		/// </summary>
		public global::System.String TableHeroTower => _TableHeroTower;

		/// <summary>
		/// ★추후 작업
		/// 인게임 로그라이크성
		/// 레벨업 효과 목록 Tag
		/// </summary>
		public global::System.String TableHeroAbility => _TableHeroAbility;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.String _Name;
		[SerializeAbleField(2)] private global::System.String _Desc;
		[SerializeAbleField(3)] private global::System.String _PortraitAddr;
		[SerializeAbleField(4)] private global::System.String _FullImageAddr;
		[SerializeAbleField(5)] private global::System.String _Tier;
		[SerializeAbleField(6)] private global::System.Int64 _MaxRank;
		[SerializeAbleField(7)] private global::System.Int64[] _RankEffectNum;
		[SerializeAbleField(8)] private global::System.String[] _TableHeroRankEffect;
		[SerializeAbleField(9)] private global::System.String _TableHeroTower;
		[SerializeAbleField(10)] private global::System.String _TableHeroAbility;


        public int Index { get; set; }
        
        public RowHero() {}

        public RowHero(global::System.String __Key, global::System.String __Name, global::System.String __Desc, global::System.String __PortraitAddr, global::System.String __FullImageAddr, global::System.String __Tier, global::System.Int64 __MaxRank, global::System.Int64[] __RankEffectNum, global::System.String[] __TableHeroRankEffect, global::System.String __TableHeroTower, global::System.String __TableHeroAbility)
        {
			_Key = __Key;
			_Name = __Name;
			_Desc = __Desc;
			_PortraitAddr = __PortraitAddr;
			_FullImageAddr = __FullImageAddr;
			_Tier = __Tier;
			_MaxRank = __MaxRank;
			_RankEffectNum = __RankEffectNum;
			_TableHeroRankEffect = __TableHeroRankEffect;
			_TableHeroTower = __TableHeroTower;
			_TableHeroAbility = __TableHeroAbility;

        }
    }

    [SerializeAbleClass]
    public partial class TableHero : Table<RowHero, global::System.String>
    {

    }
}