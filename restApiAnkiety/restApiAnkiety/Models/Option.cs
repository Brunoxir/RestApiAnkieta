namespace restApiAnkiety.Models;

public class Option
{
    public int Id { get; set; }
    public int FormId { get; set; }

    public string Description { get; set; }
    public int Votes { get; set; } = 0;
    public Form Form { get; set; }
    public List<Answer> Answers { get; set; } = new();
}
