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
        /// <param name="question">Selected question object</param>
        /// <returns>Key selected by user</returns>
        public static int PrintQuestionAndGetAnswer(QnA question)
        {
            Console.WriteLine(question.Question);
            Console.WriteLine("Select your unswer:");

            for (int i = 0; i < question.Answers.Count; i++)
            {
                Console.WriteLine($"{i+1}.  {question.Answers[i]}");
            }

            return ConsoleKeyInfoToQuestionIndex(Console.ReadKey());
        }

        /// <summary>
        /// Convert user key input to Question index
        /// </summary>
        /// <param name="key">User key inpur</param>
        /// <returns>
        /// -1 if wrong key
        /// 0 for first answer 
        /// 1 for second answer 
        /// 2 for third answer 
        /// 3 for fourth answer 
        /// </returns>
        public static int ConsoleKeyInfoToQuestionIndex(ConsoleKeyInfo key)
        {
            int questionIndex = -1;

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    questionIndex = 0;
                    break;

                case ConsoleKey.D2:
                    questionIndex = 1;
                    break;
                
                case ConsoleKey.D3:
                    questionIndex = 2;
                    break;
                
                case ConsoleKey.D4:
                    questionIndex = 3;
                    break;

            }

            return questionIndex;
        }

        public static void PrintErrorToReadTheFile()
        {
            Console.WriteLine("Cant Read the questions file!");
        }
        
    }
}
