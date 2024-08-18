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
		public static TableCharacter Character { get; } = new TableCharacter();
		public static TableCharacterSpecial CharacterSpecial { get; } = new TableCharacterSpecial();
		public static TableMove Move { get; } = new TableMove();
		public static TableSkill Skill { get; } = new TableSkill();
		public static TableSpwaner Spwaner { get; } = new TableSpwaner();

        
        public static void LoadFromPath(string path)
        {
			Character.LoadFromPath($"{path}/TableCharacter.bytes");
			CharacterSpecial.LoadFromPath($"{path}/TableCharacterSpecial.bytes");
			Move.LoadFromPath($"{path}/TableMove.bytes");
			Skill.LoadFromPath($"{path}/TableSkill.bytes");
			Spwaner.LoadFromPath($"{path}/TableSpwaner.bytes");

        }
        
        public static void LoadFromResources()
        {
			Character.LoadFromResources($"Table/TableCharacter");
			CharacterSpecial.LoadFromResources($"Table/TableCharacterSpecial");
			Move.LoadFromResources($"Table/TableMove");
			Skill.LoadFromResources($"Table/TableSkill");
			Spwaner.LoadFromResources($"Table/TableSpwaner");

        }
    }
}
