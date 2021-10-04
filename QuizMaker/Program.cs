using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace QuizMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new();
            string filePath = ConfigurationManager.AppSettings.Get("path");
            List<QnA> qnaQuestions = Data.LoadQuestionList(filePath);

            if (qnaQuestions == null)
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

                var reorderedQuestions = qnaQuestions.OrderBy(x => rnd.Next());

                foreach (var reorderedQuestion in reorderedQuestions)
                {
                    answerTry = 0;
                    do
                    {
                        answer = UI.PrintQuestionAndGetAnswer(reorderedQuestion);
                        answerTry++;
                    } while (answer == -1 && answerTry < 3);

                    if (answerTry < 3)
                    {
                        if (Data.IsItCorrectAnswer(reorderedQuestion, answer))
                        {
                            correctCount++;
                        }
                        else
                        {
                            wrongCount++;
                        }
                    }

                    if ((correctCount + wrongCount) < qnaQuestions.Count)
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
