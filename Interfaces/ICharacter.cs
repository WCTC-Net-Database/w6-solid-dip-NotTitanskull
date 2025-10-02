namespace W6_assignment_template.Interfaces
{
    public interface ICharacter
    {
        void Attack(ICharacter target);
        void Move();
        void UniqueBehavior();
        string Name { get; set; }
        string Type { get; set; }
        int Level { get; set; }
        int HP { get; set; }
    }

}
