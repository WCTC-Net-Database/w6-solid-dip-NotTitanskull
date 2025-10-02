using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public class Goblin : CharacterBase, ILootable
    {
        public string Treasure { get; set; }

        public Goblin(string name, string type, int level, int hp, string treasure)
            : base(name, type, level, hp)
        {
            Treasure = treasure;
        }
        
        public override void UniqueBehavior()
        {
            if (string.IsNullOrEmpty(Treasure))
            {
                Console.WriteLine($"{Name} scavenges around and finds a small trinket.");
                Treasure = "Small Trinket";
            }
            else
            {
                Console.WriteLine($"{Name} jealously guards its {Treasure}.");
            }
            // Goblins gain a small HP boost
            HP += 1;
        }
    }
}
