namespace QuizApp.Api.Features.QuizModule.DTOs;

public class QuizDetailsDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int DurationInMinutes { get; set; }

    public List<QuestionResponseDto> Questions { get; set; } = new();
}