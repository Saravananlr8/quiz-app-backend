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
    public async Task<IActionResult>CreateQuiz(CreateQuizDto quizDto)
    {
        var response = await _quizService.CreateQuizAsync(quizDto);
        return Ok(response);
    }

    [Authorize]
    [HttpGet("quizzes")]
    public async Task<IActionResult>GetAllQuizzes()
    {
        var response = await _quizService.GetAllQuizzesAsync();
        return Ok(response);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuizById(int id)
    {
        var response = await _quizService.GetQuizByIdAsync(id);

        if(response is null)
        {
            return NotFound("Quiz not found");
        }

        return Ok(response);
    }
}