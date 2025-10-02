using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public class Player : CharacterBase, IPlayableCharacter
    {
        public int Gold { get; set; }

        public Player(string name, string type, int level, int hp, int gold)
            : base(name, type, level, hp)
        {
            Gold = gold;
        }

        public override void UniqueBehavior()
        {
            int foundGold = Gold / 10 + 1;
            Console.WriteLine($"{Name} searches for treasure and finds {foundGold} gold coins!");
            Gold += foundGold;
            
            // Players gain experience (level) when using unique behavior
            Level += 1;
            Console.WriteLine($"{Name} gained experience! New level: {Level}");
        }
    }
}
