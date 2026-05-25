namespace QuizApp.Api.Models;

public class Question
{
    public int Id { get; set; }

    public int QuizId { get; set; }

    public string QuestionText { get; set; } = string.Empty;

    public int Marks { get; set; }

    public Quiz Quiz { get; set; } = null!;

    public List<Option> Options { get; set; } = new();
}