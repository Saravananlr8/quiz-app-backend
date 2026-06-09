using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Api.Feature.Attempt.Dtos
{
    public class ResultDto
    {
        public int Score { get; set; }

        public int TotalQuestions { get; set; }

        public double Percentage { get; set; }
    }
}