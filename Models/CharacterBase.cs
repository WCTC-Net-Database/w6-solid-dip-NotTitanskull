using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public abstract class CharacterBase : ICharacter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }

        protected CharacterBase(string name, string type, int level, int hp)
        {
            Name = name;
            Type = type;
            Level = level;
            HP = hp;
        }

        public void Attack(ICharacter target)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Name} attacks {target.Name}");
            Console.ResetColor();

            // Now using interfaces instead of concrete classes
            if (this is IPlayableCharacter playableCharacter && target is ILootable targetWithTreasure && !string.IsNullOrEmpty(targetWithTreasure.Treasure))
            {
                Console.WriteLine($"{Name} takes {targetWithTreasure.Treasure} from {target.Name}");
                playableCharacter.Gold += 10; // Assuming each treasure is worth 10 gold
                targetWithTreasure.Treasure = null; // Treasure is taken
            }
            else if (this is IPlayableCharacter attacker && target is IPlayableCharacter defender && defender.Gold > 0)
            {
                Console.WriteLine($"{Name} takes gold from {target.Name}");
                attacker.Gold += defender.Gold;
                defender.Gold = 0; // Gold is taken
            }
        }

        public void Move()
        {
            Console.WriteLine($"{Name} moves.");
        }
        
        // Added back the abstract UniqueBehavior method
        public abstract void UniqueBehavior();
    }
}
