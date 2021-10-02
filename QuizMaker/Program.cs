using System.Collections.Generic;

namespace QuizMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] questions = Data.GetQuestionsFromTextFile(@"..\..\..\..\Input File\QuizList.txt");

            if (questions != null)
            {
                int answer;
                int answerTry;
                int correctCount = 0;
                int wrongCount = 0;
                List<QnA> qnaQuestions = Data.GetQuestionsFromArray(questions);
                HashSet<int> listofIndexes = Data.GetRundomQuestionsNumbering(qnaQuestions);

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

                    if (( correctCount + wrongCount) < listofIndexes.Count)
                    {
                        if (!UI.PrintContinuePlay(correctCount, wrongCount))
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
