namespace QuizApp.Api.Models;

public class Answer
{
    public int Id { get; set; }

    public int QuizAttemptId { get; set; }

    public int QuestionId { get; set; }

    public int SelectedOptionId { get; set; }

    public QuizAttempt QuizAttempt { get; set; } = null!;
}