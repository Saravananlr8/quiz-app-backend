namespace QuizApp.Api.Features.QuizModule.DTOs;

public class CreateOptionDto
{
    public string OptionText { get; set; } = string.Empty;

    public bool IsCorrect { get; set; }
}