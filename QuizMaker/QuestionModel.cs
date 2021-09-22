using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    public class QuestionModel
    {
        public string Question { get; set; }
        public List<string> Answers { get; set; }
        public List<string> CorrectAnswers { get; set; }
    }
}
