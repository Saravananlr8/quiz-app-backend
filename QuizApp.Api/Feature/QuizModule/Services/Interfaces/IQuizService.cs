using QuizApp.Api.Features.QuizModule.DTOs;

namespace QuizApp.Api.Features.QuizModule.Services.Interfaces;

public interface IQuizService
{
    Task<string> CreateQuizAsync(CreateQuizDto request);
    Task<List<GetAllQuizDto>> GetAllQuizzesAsync();
    Task<QuizDetailsDto?> GetQuizByIdAsync(int id);
}