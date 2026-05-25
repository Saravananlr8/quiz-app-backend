namespace QuizApp.Api.Features.QuizModule.DTOs;

public class QuestionDto
{
    public string QuestionText { get; set; } = string.Empty;

    public int Marks { get; set; }

    public List<OptionDto> Options { get; set; } = new();
}