//This code was automatically generated.
//Don't edit this code.

using DevDev.Table;
using OPS.Serialization.Attributes;

namespace Grooz
{
    [SerializeAbleClass]
    public partial class RowSkill : IRow<global::System.String>
    {
		public global::System.String Key => _Key;

		/// <summary>
		/// 스킬 쿨타임
		/// </summary>
		public global::System.Int64 CoolTime => _CoolTime;

		/// <summary>
		/// 스킬 내부 쿨타임
		/// (동시에 쿨 돌때 난사 방지)
		/// </summary>
		public global::System.Int64 CoolTimeDuration => _CoolTimeDuration;

		/// <summary>
		/// 스킬 프리팹 주소
		/// </summary>
		public global::System.String Prefab => _Prefab;

		/// <summary>
		/// 스킬 대미지
		/// </summary>
		public global::System.Int64 Dmg => _Dmg;

		/// <summary>
		/// 스킬 적중 시
		/// 이펙트 주소
		/// </summary>
		public global::System.String EffectPrefab => _EffectPrefab;

		/// <summary>
		/// PLAYER = 플레이어
		/// MON = 몬스터
		/// </summary>
		public global::System.String SkillType => _SkillType;

		/// <summary>
		/// 타게팅 타입
		/// </summary>
		public global::System.String TargetingType => _TargetingType;

		/// <summary>
		/// 스킬의 유형
		/// SPAWN_MONSTER
		/// (enum화 필요할듯)
		/// </summary>
		public global::System.String SkillCategory => _SkillCategory;

		public global::System.String SkillKey => _SkillKey;

		public global::System.String SkillValue => _SkillValue;

		public global::System.String UpgradeCurerency => _UpgradeCurerency;

		public global::System.Int64 UpgradeCost => _UpgradeCost;

		public global::System.String NextLevel => _NextLevel;


		[SerializeAbleField(0)] private global::System.String _Key;
		[SerializeAbleField(1)] private global::System.Int64 _CoolTime;
		[SerializeAbleField(2)] private global::System.Int64 _CoolTimeDuration;
		[SerializeAbleField(3)] private global::System.String _Prefab;
		[SerializeAbleField(4)] private global::System.Int64 _Dmg;
		[SerializeAbleField(5)] private global::System.String _EffectPrefab;
		[SerializeAbleField(6)] private global::System.String _SkillType;
		[SerializeAbleField(7)] private global::System.String _TargetingType;
		[SerializeAbleField(8)] private global::System.String _SkillCategory;
		[SerializeAbleField(9)] private global::System.String _SkillKey;
		[SerializeAbleField(10)] private global::System.String _SkillValue;
		[SerializeAbleField(11)] private global::System.String _UpgradeCurerency;
		[SerializeAbleField(12)] private global::System.Int64 _UpgradeCost;
		[SerializeAbleField(13)] private global::System.String _NextLevel;


        public int Index { get; set; }
        
        public RowSkill() {}

        public RowSkill(global::System.String __Key, global::System.Int64 __CoolTime, global::System.Int64 __CoolTimeDuration, global::System.String __Prefab, global::System.Int64 __Dmg, global::System.String __EffectPrefab, global::System.String __SkillType, global::System.String __TargetingType, global::System.String __SkillCategory, global::System.String __SkillKey, global::System.String __SkillValue, global::System.String __UpgradeCurerency, global::System.Int64 __UpgradeCost, global::System.String __NextLevel)
        {
			_Key = __Key;
			_CoolTime = __CoolTime;
			_CoolTimeDuration = __CoolTimeDuration;
			_Prefab = __Prefab;
			_Dmg = __Dmg;
			_EffectPrefab = __EffectPrefab;
			_SkillType = __SkillType;
			_TargetingType = __TargetingType;
			_SkillCategory = __SkillCategory;
			_SkillKey = __SkillKey;
			_SkillValue = __SkillValue;
			_UpgradeCurerency = __UpgradeCurerency;
			_UpgradeCost = __UpgradeCost;
			_NextLevel = __NextLevel;

        }
    }

    [SerializeAbleClass]
    public partial class TableSkill : Table<RowSkill, global::System.String>
    {

    }
}