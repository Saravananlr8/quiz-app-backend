using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Features.QuizModule.DTOs;
using QuizApp.Api.Features.QuizModule.Services.Interfaces;

namespace QuizApp.Api.Features.QuizModule;
[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;
    public QuizController(IQuizService quizService)
    {
        _quizService =  quizService;
    }

    [Authorize]
    [HttpPost("create/quiz")]
    public async Task<IActionResult>CreateQuiz(QuizDto quizDto)
    {
        var response = await _quizService.CreateQuizAsync(quizDto);
        return Ok(response);
    }
}