namespace QuizApp.Api.Models;

public class QuizAttempt
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int QuizId { get; set; }

    public int Score { get; set; }

    public DateTime StartedAt { get; set; }

    public DateTime SubmittedAt { get; set; }

    public List<Answer> Answers { get; set; } = new();
}