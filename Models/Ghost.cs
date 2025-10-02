using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public class Ghost : CharacterBase, IFlyable, ILootable
    {
        public string Treasure { get; set; }

        public Ghost(string name, string type, int level, int hp, string treasure)
            : base(name, type, level, hp)
        {
            Treasure = treasure;
        }

        public void Fly()
        {
            Console.WriteLine($"{Name} flies rapidly through the air.");
        }
        
        public override void UniqueBehavior()
        {
            Console.WriteLine($"{Name} passes through a wall, revealing a hidden {Treasure}!");
            Fly(); // Ghosts use their flying ability as part of their unique behavior
            
            // Ghosts gain more HP than other characters
            HP += 3;
            Console.WriteLine($"{Name} absorbs ethereal energy. Current HP: {HP}");
        }
    }
}
