using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace QuizApp.Api.Features.Auth.DTOs;

public class AuthResponseDto
{
    public string Message { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}