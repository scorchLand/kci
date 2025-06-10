//This code was automatically generated.
//Don't edit this code.


using System.Collections.Generic;
using System.IO;
using OPS.Serialization.IO;
using UnityEngine;

namespace Grooz
{
    public static class Tables
    {
		public static TableHero Hero { get; } = new TableHero();
		public static TableHeroTower HeroTower { get; } = new TableHeroTower();
		public static TableStatus Status { get; } = new TableStatus();
		public static TableStat Stat { get; } = new TableStat();
		public static TableWave Wave { get; } = new TableWave();

        
        public static void LoadFromPath(string path)
        {
			Hero.LoadFromPath($"{path}/TableHero.bytes");
			HeroTower.LoadFromPath($"{path}/TableHeroTower.bytes");
			Status.LoadFromPath($"{path}/TableStatus.bytes");
			Stat.LoadFromPath($"{path}/TableStat.bytes");
			Wave.LoadFromPath($"{path}/TableWave.bytes");

        }
        
        public static void LoadFromResources()
        {
			Hero.LoadFromResources($"Table/TableHero");
			HeroTower.LoadFromResources($"Table/TableHeroTower");
			Status.LoadFromResources($"Table/TableStatus");
			Stat.LoadFromResources($"Table/TableStat");
			Wave.LoadFromResources($"Table/TableWave");

        }
    }
}
