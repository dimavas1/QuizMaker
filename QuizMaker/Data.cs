using QuizMaker;
using System;
using System.Collections.Generic;
using System.IO;

public class Data
{

    /// <summary>
    /// Reading the Question and adding questions and answers into List of QnA objects
    /// </summary>
    /// <param name="filepath">Path and name of text file with questions</param>
    /// <returns>List of QnA objects
    /// Question stored Question
    /// Answers - wrong answers
    /// CorrectAnswers - correct answers
    /// </returns>
    public static List<QnA> GetQuestionsFromTextFile(string filepath)
    {
        List<QnA> questions = new();

        string[] textlines = File.ReadAllLines(filepath);
        int count = 0;

        foreach (var line in textlines)
        {
            count++;

            QnA question = new();
            var lineArray = line.Split("?");
            question.Question = lineArray[0].Trim() + "?";
            string temp = "";

            foreach (string answer in lineArray[1].Split("|"))
            {
                if (answer.Trim() != string.Empty)
                {

                    if (answer.Contains("*"))
                    {
                        question.CorrectAnswers.Add(answer.Trim().Replace("*", ""));
                    }

                    question.Answers.Add(answer.Trim().Replace("*", ""));

                }
            }

            questions.Add(question);
        }

        return questions;
    }

    /// <summary>
    /// Generating list with uniq numbers 
    /// </summary>
    /// <param name="questions">List of Questions objects</param>
    /// <returns></returns>
    public static HashSet<int> GetRundomQuestionsNumbering(List<QnA> questions)
    {
        int questionsCount = questions.Count;
        Random rnd = new();
        HashSet<int> numbers = new();

        while (numbers.Count < questionsCount)
        {
            numbers.Add(rnd.Next(0, questionsCount));
        }

        return numbers;
    }



}
