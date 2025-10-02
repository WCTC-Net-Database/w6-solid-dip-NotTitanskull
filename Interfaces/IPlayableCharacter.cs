namespace W6_assignment_template.Interfaces
{
    /// <summary>
    /// Interface for characters that can collect gold
    /// </summary>
    public interface IPlayableCharacter : ICharacter
    {
        int Gold { get; set; }
    }
}

