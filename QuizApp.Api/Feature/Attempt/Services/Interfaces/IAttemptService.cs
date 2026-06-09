using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizApp.Api.Feature.Attempt.Dtos;

namespace QuizApp.Api.Feature.Attempt.Services
{
    public interface IAttemptService
    {
        Task<ResultDto> SubmitQuizAsync(SubmitQuizDto dto,
            int userId);
    }
}