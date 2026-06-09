using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizApp.Api.Data;
using QuizApp.Api.Feature.Attempt.Dtos;
using QuizApp.Api.Models;

namespace QuizApp.Api.Feature.Attempt.Services
{
    public class AttemptService : IAttemptService
    {
        private readonly ApplicationDbContext _context;
        public AttemptService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<ResultDto> SubmitQuizAsync(SubmitQuizDto dto,int userId)
        {
            Quiz? quiz = await _context.Quizzes.Include(q => q.Questions).ThenInclude(q=>q.Options).FirstOrDefaultAsync(q=> q.Id==dto.QuizId);

            if(quiz==null)
            {
                throw new Exception("Quiz not found");
            }
            int score = 0;
            List<Answer> attemptAnswers = new List<Answer>();
            foreach (var answer in dto.SelectedAnswers)
            {
                var question = quiz.Questions
                    .First(q => q.Id == answer.QuestionId);

                var correctOption = question.Options
                    .First(o => o.IsCorrect);

                bool isCorrect =
                    correctOption.Id == answer.OptionId;

                if (isCorrect)
                    score++;

                attemptAnswers.Add(new Answer
                {
                    QuestionId = answer.QuestionId,
                    SelectedOptionId = answer.OptionId
                });
            }
            var quizAttempt = new QuizAttempt
            {
                UserId = userId,
                QuizId = dto.QuizId,
                Score = score,
                StartedAt = DateTime.UtcNow,
                SubmittedAt = DateTime.UtcNow
            };
            _context.QuizAttempts.Add(quizAttempt);

            await _context.SaveChangesAsync();
            foreach (var answer in attemptAnswers)
            {
                answer.QuizAttemptId = quizAttempt.Id;
            }

            _context.Answers.AddRange(attemptAnswers);

            await _context.SaveChangesAsync();
            return new ResultDto
            {
                Score = score,
                TotalQuestions = quiz.Questions.Count,
                Percentage =
                    (double)score /
                    quiz.Questions.Count * 100
            };
        }
    }
}