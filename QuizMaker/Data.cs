using QuizMaker;
using System;
using System.Collections.Generic;
using System.IO;

public class Data
{

    /// <summary>
    /// Trying to Read the text file.
    /// </summary>
    /// <param name="filepath">selected file path</param>
    /// <returns>
    /// if succeded returnig an array if not returning null
    /// </returns>
    public static string[] GetQuestionsFromTextFile(string filepath)
    {
        string[] textlines = null;

        try
        {
            textlines = File.ReadAllLines(filepath);
        }
        catch (Exception)
        {
           
        }

        return textlines;
    }

    /// <summary>
    /// Reading the Question from array and adding questions and answers into List of QnA objects
    /// </summary>
    /// <param name="textlines">selected array</param>
    /// <returns>List of QnA objects
    /// Question stored Question
    /// Answers - wrong answers
    /// CorrectAnswers - correct answers
    /// </returns>
    public static List<QnA> GetQuestionsFromArray(string[] textlines)
    {
        List<QnA> questions = new();
        int count = 0;

        foreach (var line in textlines)
        {
            count++;

            QnA question = new();
            var lineArray = line.Split("?");
            question.Question = lineArray[0].Trim() + "?";

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

    /// <summary>
    /// Verify if user answer is correct
    /// </summary>
    /// <param name="question">selected question object</param>
    /// <param name="answerIndex">answer index(0 to 3)</param>
    /// <returns></returns>
    public static bool IsItCorrectAnswer(QnA question, int answerIndex)
    {
        bool correctAnswer = false;

        foreach (string answer in question.CorrectAnswers)
        {
            if (answer == question.Answers[answerIndex])
            {
                correctAnswer = true;
            }
        }
        return correctAnswer;
    }

}
