using W6_assignment_template.Data;
using W6_assignment_template.Interfaces;
using W6_assignment_template.Models;

namespace W6_assignment_template.Services
{
    public class GameEngine
    {
        private readonly IContext _context;
        private readonly IPlayableCharacter? _playableCharacter;
        private readonly ILootable? _enemyCharacter;

        public GameEngine(IContext context)
        {
            _context = context;
            
            // Find characters by interface type instead of concrete type
            _playableCharacter = _context.Characters.OfType<IPlayableCharacter>().FirstOrDefault();
            _enemyCharacter = _context.Characters.OfType<ILootable>().FirstOrDefault(c => c is not IPlayableCharacter);
        }

        public void Run()
        {
            if (_playableCharacter == null || _enemyCharacter == null)
            {
                Console.WriteLine("Failed to initialize game characters.");
                return;
            }

            // Display player status using the interface
            Console.WriteLine($"Player Gold: {_playableCharacter.Gold}");

            // Basic turn actions using interfaces
            _enemyCharacter.Move();
            _enemyCharacter.Attack(_playableCharacter);

            _playableCharacter.Move();
            _playableCharacter.Attack(_enemyCharacter);

            // Check special abilities
            if (_enemyCharacter is IFlyable flyingEnemy)
            {
                Console.WriteLine($"{_enemyCharacter.Name} demonstrates flying ability:");
                flyingEnemy.Fly();
            }

            // Display updated player status
            Console.WriteLine($"Player Gold: {_playableCharacter.Gold}");
            
            // Display treasure status
            if (!string.IsNullOrEmpty(_enemyCharacter.Treasure))
            {
                Console.WriteLine($"{_enemyCharacter.Name} has {_enemyCharacter.Treasure}");
            }
            else
            {
                Console.WriteLine($"{_enemyCharacter.Name} has no treasure left");
            }
        }
    }
}
