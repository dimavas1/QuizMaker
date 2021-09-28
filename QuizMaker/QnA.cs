using System.Collections.Generic;

namespace QuizMaker
{
    public class QnA
    {
        public  string Question { get; set; } = null;
        public  List<string> Answers { get; set; } = new();
        public  List<string> CorrectAnswers { get; set; } = new();

    }
}
