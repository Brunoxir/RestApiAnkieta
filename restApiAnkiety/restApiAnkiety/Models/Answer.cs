namespace restApiAnkiety.Models;

public class Answer
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public Form Form { get; set; }
    public int OptionId { get; set; }
    public Option Option { get; set; }

    public DateTime AnswerDate { get; set; }
}
