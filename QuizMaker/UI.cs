using System;

namespace QuizMaker
{
    public class UI
    {
        /// <summary>
        /// Receiving Questions List and question index on the list.
        /// Printing all answers and asking for input from user.
        /// </summary>
        /// <param name="question">Selected question object</param>
        /// <returns>Key selected by user, -1 if invaild</returns>
        public static int PrintQuestionAndGetAnswer(QnA question)
        {
            
            Console.Clear();
            Console.WriteLine(question.Question);
            Console.WriteLine("Select your unswer:");

            for (int i = 0; i < question.Answers.Count; i++)
            {
                Console.WriteLine($"{i+1}.  {question.Answers[i]}");
            }

            return ConsoleKeyInfoToQuestionIndex(Console.ReadKey(), question.Answers.Count);
        }

        /// <summary>
        /// Convert user key input to Question index
        /// </summary>
        /// <param name="key">User key inpur</param>
        /// <param name="total">total answers</param>
        /// <returns>
        /// -1 if wrong key
        /// 0 for first answer 
        /// 1 for second answer 
        /// 2 for third answer 
        /// 3 for fourth answer 
        /// </returns>
        public static int ConsoleKeyInfoToQuestionIndex(ConsoleKeyInfo key, int total)
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
                    if (total == 3)
                    {
                        questionIndex = 2;
                    }                    
                    break;
                
                case ConsoleKey.D4:
                    if (total == 4)
                    {
                        questionIndex = 3;
                    }
                    break;

            }

            return questionIndex;
        }

        /// <summary>
        /// Print read file error message
        /// </summary>
        public static void PrintErrorToReadTheFile()
        {
            Console.WriteLine("Cant Read the questions file!");
        }

        /// <summary>
        /// Printig game summary and asking user if he want to continue.
        /// </summary>
        /// <param name="correct">number of correct answers</param>
        /// <param name="wrong">number of wrong answers</param>
        /// <returns>
        /// True if user selected Y to continue play
        /// False if user selected any other key
        /// </returns>
        public static bool AskUserToContinue(int correct,int wrong)
        {
            bool play = false;
            Console.Clear();
            Console.WriteLine($"You have answered {correct + wrong} questions.");
            Console.WriteLine($"Correct answers - {correct}");
            Console.WriteLine($"Wrong answers - {wrong}");
            Console.WriteLine("Do you want to continue playing Type Y if yes or any key for not");

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                play = true;
            }

            return play;
        }
        
    }
}
