using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Feature.Attempt.Dtos;
using QuizApp.Api.Feature.Attempt.Services;

namespace QuizApp.Api.Feature.Attempt.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AttemptsController : ControllerBase
{
    private readonly IAttemptService _attemptService;

    public AttemptsController(IAttemptService attemptService)
    {
        _attemptService = attemptService;
    }

    
    [HttpPost("submit")]
    public async Task<IActionResult> Submit(SubmitQuizDto dto)
    {
        var userId = int.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var result = await _attemptService.SubmitQuizAsync(dto, userId);

        return Ok(result);
    }
}