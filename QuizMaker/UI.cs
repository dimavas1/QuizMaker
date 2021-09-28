using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    public class UI
    {
        /// <summary>
        /// Receiving Questions List and question index on the list.
        /// Printing all answers and asking for input from user.
        /// </summary>
        /// <param name="questions">List of wuestions</param>
        /// <param name="questionIndex">Index of the question</param>
        /// <returns>Key selected by user</returns>
        public static ConsoleKeyInfo PrintQuestion(List<QnA> questions, int questionIndex)
        {
            Console.WriteLine(questions[questionIndex]);
            Console.WriteLine("Select your unswer:");

            for (int i = 0; i < questions[questionIndex].Answers.Count; i++)
            {
                Console.WriteLine($"{i+1}.  {questions[questionIndex].Answers[i]}");
            }

            return Console.ReadKey();
        }
    }
}
