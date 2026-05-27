using QuizApp.Api.Data;
using QuizApp.Api.Features.QuizModule.DTOs;
using QuizApp.Api.Models;
using QuizApp.Api.Features.QuizModule.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QuizApp.Api.Features.QuizService.Services;

public class QuizService : IQuizService
{
    private readonly ApplicationDbContext _context;

    public QuizService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> CreateQuizAsync(CreateQuizDto request)
    {
        Quiz quiz = new Quiz
        {
            Title = request.Title,
            Description = request.Description,
            DurationInMinutes = request.DurationInMinutes
        };

        foreach (CreateQuestionDto questionDto in request.Questions)
        {
            Question question = new Question
            {
                QuestionText = questionDto.QuestionText,
                Marks = questionDto.Marks
            };

            foreach (CreateOptionDto optionDto in questionDto.Options)
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

    public async Task<List<GetAllQuizDto>> GetAllQuizzesAsync()
    {
        List<GetAllQuizDto> quizzes = await _context.Quizzes
            .Select(x => new GetAllQuizDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                DurationInMinutes = x.DurationInMinutes
            })
            .ToListAsync();

        return quizzes;
    }

    public async Task<QuizDetailsDto?> GetQuizByIdAsync(int id)
    {
        Quiz? quiz = await _context.Quizzes
            .Include(x => x.Questions)
            .ThenInclude(x => x.Options)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (quiz is null)
        {
            return null;
        }

        QuizDetailsDto response = new QuizDetailsDto
        {
            Id = quiz.Id,
            Title = quiz.Title,
            Description = quiz.Description,
            DurationInMinutes = quiz.DurationInMinutes,

            Questions = quiz.Questions.Select(q => new QuestionResponseDto
            {
                Id = q.Id,
                QuestionText = q.QuestionText,
                Marks = q.Marks,

                Options = q.Options.Select(o => new OptionResponseDto
                {
                    Id = o.Id,
                    OptionText = o.OptionText
                }).ToList()

            }).ToList()
        };

        return response;
    }
}