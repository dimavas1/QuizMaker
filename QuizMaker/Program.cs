using System;

namespace QuizMaker
{
    class Program
    {
        static void Main(string[] args)
        {            
            var questions =  Data.GetQuestionsFromTextFile(@"C:\Tranning\QuizMaker\Input File\QuizList.txt");
            var lisofIndexes = Data.GetRundomQuestionsNumbering(questions);
        }
    }
}
