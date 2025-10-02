namespace W6_assignment_template.Interfaces
{
    /// <summary>
    /// Interface for characters that can be looted
    /// </summary>
    public interface ILootable : ICharacter
    {
        string? Treasure { get; set; }
    }
}

