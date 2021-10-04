using System.Collections.Generic;
using System.Configuration;

namespace QuizMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = ConfigurationManager.AppSettings.Get("path");
            List<QnA> qnaQuestions = Data.LoadQuestionList(filePath);

            if(qnaQuestions == null)
            {
                UI.PrintErrorToReadTheFile();
                return;
            }

            if (qnaQuestions != null)
            {
                int answer;
                int answerTry;
                int correctCount = 0;
                int wrongCount = 0;
                HashSet<int> listofIndexes = Data.GenerateRandomNonRepeatingList(qnaQuestions.Count);

                foreach (var index in listofIndexes)
                {
                    answerTry = 0;
                    do
                    {
                        answer = UI.PrintQuestionAndGetAnswer(qnaQuestions[index]);
                        answerTry++;
                    } while (answer == -1 && answerTry < 3);

                    if (answerTry < 3)
                    {
                        if (Data.IsItCorrectAnswer(qnaQuestions[index], answer))
                        {
                            correctCount++;
                        }
                        else
                        {
                            wrongCount++;
                        }
                    }

                    if ((correctCount + wrongCount) < listofIndexes.Count)
                    {
                        if (!UI.AskUserToContinue(correctCount, wrongCount))
                        {
                            break;
                        }
                    }

                }
            }
            else
            {
                UI.PrintErrorToReadTheFile();
            }



        }
    }
}
