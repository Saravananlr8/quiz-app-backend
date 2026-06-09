using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Api.Feature.Attempt.Dtos
{
    public class SubmitQuizDto
    {
        public int QuizId { get; set; }

        public List<SelectedAnswerDto> SelectedAnswers { get; set; } = new();
    }
}