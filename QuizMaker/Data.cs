﻿using QuizMaker;
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

            if (lineArray.Length > 0)
            {
                question.Question = lineArray[0].Trim() + "?";
                var answers = lineArray[1].Split("|");

                for (int i = 0; i < answers.Length; i++)
                {
                    if (answers[i].Trim() != string.Empty)
                    {
                        if (answers[i].Contains("*"))
                        {
                            question.CorrectAnswer = i-1;
                        }

                        question.Answers.Add(answers[i].Trim().Replace("*", ""));

                    }
                }

                if (question.CorrectAnswer != null)
                {
                    questions.Add(question);
                }

            }


        }

        return questions;
    }

    /// <summary>
    /// Generating list with uniq numbers 
    /// </summary>
    /// <param name="numberOfquestios">number of questios</param>
    /// <returns>None repeatable list with random numbers</returns>
    public static HashSet<int> GenerateRandomNonRepeatingList(int numberOfquestios)
    {
        Random rnd = new();
        HashSet<int> numbers = new();

        while (numbers.Count < numberOfquestios)
        {
            numbers.Add(rnd.Next(0, numberOfquestios));
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

        if (answerIndex == question.CorrectAnswer)
        {
            correctAnswer = true;
        }

        return correctAnswer;
    }

    /// <summary>
    /// Getting questions from file and loading to QnA list object
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns>
    /// Loaded QnA list object if succeded to read from file, if not return null
    /// </returns>
    public static List<QnA> LoadQuestionList(string filePath)
    {
        List<QnA> list = null;

        string[] textlines = GetQuestionsFromTextFile(filePath);

        if (textlines != null)
        {
            list = GetQuestionsFromArray(textlines);
        }

        return list;
    }

}
