using QuizApp.Api.Data;
using QuizApp.Api.Features.QuizModule.DTOs;
using QuizApp.Api.Models;
using QuizApp.Api.Features.QuizModule.Services.Interfaces;

namespace QuizApp.Api.Features.QuizService.Services;

public class QuizService : IQuizService
{
    private readonly ApplicationDbContext _context;

    public QuizService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> CreateQuizAsync(QuizDto request)
    {
        Quiz quiz = new Quiz
        {
            Title = request.Title,
            Description = request.Description,
            DurationInMinutes = request.DurationInMinutes
        };

        foreach (QuestionDto questionDto in request.Questions)
        {
            Question question = new Question
            {
                QuestionText = questionDto.QuestionText,
                Marks = questionDto.Marks
            };

            foreach (OptionDto optionDto in questionDto.Options)
            {
                Option option = new Option
                {
                    OptionText = optionDto.OptionText,
                    IsCorrect = optionDto.IsCorrect
                };

                question.Options.Add(option);
            }

            quiz.Questions.Add(question);
        }

        _context.Quizzes.Add(quiz);

        await _context.SaveChangesAsync();

        return "Quiz created successfully";
    }
}