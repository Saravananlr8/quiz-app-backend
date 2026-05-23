using QuizApp.Api.Features.Auth.DTOs;

namespace QuizApp.Api.Features.Auth.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request);
}