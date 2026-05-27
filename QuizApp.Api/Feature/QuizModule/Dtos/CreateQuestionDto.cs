namespace QuizApp.Api.Features.QuizModule.DTOs;

public class CreateQuestionDto
{
    public string QuestionText { get; set; } = string.Empty;

    public int Marks { get; set; }

    public List<CreateOptionDto> Options { get; set; } = new();
}