namespace QuizApp.Api.Features.QuizModule.DTOs;

public class CreateQuizDto
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int DurationInMinutes { get; set; }

    public List<CreateQuestionDto> Questions { get; set; } = new();
}