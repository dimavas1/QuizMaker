using System;
using System.Collections.Generic;

namespace QuizMaker
{
    class Program
    {
        static void Main(string[] args)
        {            
            string[] questions =  Data.GetQuestionsFromTextFile(@"..\..\..\..\Input File\QuizList.txt");

            if (questions!=null)
            {
                int correctCount = 0;
                int wrongCount = 0;
                List<QnA> qnaQuestions = Data.GetQuestionsFromArray(questions);
                HashSet<int> listofIndexes = Data.GetRundomQuestionsNumbering(qnaQuestions);
            }
            else
            {
                UI.PrintErrorToReadTheFile();
            }


            
        }

       
    }
}
