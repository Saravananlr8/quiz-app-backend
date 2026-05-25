using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Features.Auth.DTOs;
using QuizApp.Api.Features.Auth.Services;
using QuizApp.Api.Features.Auth.Services.Interfaces;

namespace QuizApp.Api.Features.Auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDto request)
    {
        var response = await _authService.RegisterAsync(request);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto requestDto)
    {
        var response = await _authService.LoginAsync(requestDto);
        return Ok(response);
    }
}