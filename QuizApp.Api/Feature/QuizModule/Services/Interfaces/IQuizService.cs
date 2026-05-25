using QuizApp.Api.Features.QuizModule.DTOs;

namespace QuizApp.Api.Features.QuizModule.Services.Interfaces;

public interface IQuizService
{
    Task<string> CreateQuizAsync(QuizDto request);
}