namespace restApiAnkiety.Models;


public class Form
{
    public int Id { get; set; }
    public string Question { get; set; }
    public DateTime ReleaseDate { get; set; } = DateTime.UtcNow;
    public List<Option> Options { get; set; } = new();
    public List<Answer> Answers { get; set; } = new();
}
