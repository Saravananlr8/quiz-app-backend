using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizApp.Api.Data;
using QuizApp.Api.Features.Auth.DTOs;
using QuizApp.Api.Features.Auth.Services.Interfaces;
using QuizApp.Api.Models;

namespace QuizApp.Api.Features.Auth.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IJwtService _jwtService;

    public AuthService(ApplicationDbContext context, IPasswordHasher<User> passwordHasher, IJwtService jwtService)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
    {
        User? existingUser = await _context.Users
            .FirstOrDefaultAsync(x => x.Email == request.Email);

        if (existingUser is not null)
        {
            return new AuthResponseDto
            {
                Message = "Email already exists"
            };
        }

        User user = new User
        {
            Name = request.Name,
            Email = request.Email
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return new AuthResponseDto
        {
            Message = "User registered successfully"
        };
    }

    public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

        if (user is null)
        {
            return new AuthResponseDto
            {
                Message = "Invalid email or password"
            };
        }

        var result = _passwordHasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            request.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            return new AuthResponseDto
            {
                Message = "Invalid email or password"
            };
        }


        return new AuthResponseDto
        {
            Message = "Login successful",
            Token = _jwtService.GenerateToken(user)
        };
    }
}