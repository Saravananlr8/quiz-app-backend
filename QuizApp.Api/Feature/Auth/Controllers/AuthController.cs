using Microsoft.AspNetCore.Mvc;

namespace QuizApp.Api.Features.Auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Auth API working!");
    }
}