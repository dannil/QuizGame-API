using System;
using System.Collections.Generic;

namespace QuizGame.API.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740a");

            Question question = new Question("Solve a, where a + 4 = 11");
            question.AddCategories("basic", "algebra");
            question.AddAnswers("Undefined", "0", "-7", "7");
            question.Correct = "7";

            Question result = api.AddQuestion(question);
            Console.WriteLine(result);

            Console.WriteLine();

            Console.WriteLine(api.GetCategories());

            Console.WriteLine();

            Console.WriteLine(api.GetQuestions());

            Console.WriteLine();

            List<Question> list1 = api.GetQuestions();
            Console.WriteLine(api.GetQuestion(list1[list1.Count - 1].ID));

            Console.WriteLine();

            Console.WriteLine(api.GetQuestionsByCategory("algebra"));

            Console.WriteLine();

            List<Question> list2 = api.GetQuestions();
            Console.WriteLine(api.GetAnswersByQuestionID(list2[list2.Count - 1].ID));

            Console.WriteLine();

            List<Question> list3 = api.GetQuestions();
            Console.WriteLine(api.EditQuestion(list3[list3.Count - 2].ID, api.GetQuestion(list3[list3.Count - 1].ID)));

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine();

            Boolean success = api.DeleteQuestion(result.ID);
            Console.WriteLine(success);

            Console.ReadLine();
        }
    }
}
