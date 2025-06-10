using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Grooz
{
    public partial class RowStat
    {
        string Key;
        string Name;
    }
    public partial class RowStatus
    {
        string Key;
    }
    public partial class RowWave
    {
        public string Key;
        public string Name;
        public string Path;
        public float Duration;
        public string StatusKey;
    }
    public partial class RowHero
    {
        public string Key;
        public string Name;
        public string Desc;
        public string PortraitAddr;
        public string FullImageAddr;
        public string Tier;
        public long MaxRank;
        public long[] RankEffectNum;
        public string[] TableHeroRankEffect;
        public string TableHeroTower;
    }
    public partial class RowHeroTower
    {
        public string Key;
        public string Tag;
        public long Rate;
        public string Name;
        public int GridX;
        public int GridY;
        public string PrefabAddr;
        public string ThumbnailAddr;
        public string Skill;
    }

    public class TestConfig
    {

    }
}
