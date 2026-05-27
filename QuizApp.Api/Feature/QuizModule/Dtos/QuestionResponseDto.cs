namespace QuizApp.Api.Features.QuizModule.DTOs;

public class QuestionResponseDto
{
    public int Id { get; set; }

    public string QuestionText { get; set; } = string.Empty;

    public int Marks { get; set; }

    public List<OptionResponseDto> Options { get; set; } = new();
}