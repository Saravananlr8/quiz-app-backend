namespace QuizApp.Api.Features.QuizModule.DTOs;

public class QuizDto
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int DurationInMinutes { get; set; }

    public List<QuestionDto> Questions { get; set; } = new();
}