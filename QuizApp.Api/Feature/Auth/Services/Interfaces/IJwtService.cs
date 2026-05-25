using QuizApp.Api.Models;

namespace QuizApp.Api.Features.Auth.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}