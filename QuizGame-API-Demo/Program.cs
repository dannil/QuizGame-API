using System;

namespace QuizGame.API.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            // Add a question
            Console.WriteLine("Press enter to run add question-demo: ");
            Console.ReadLine();

            Question question = new Question("Solve a, where a + 4 = 11");
            question.AddCategories("basic", "algebra");
            question.AddAnswers("Undefined", "0", "-7", "7");
            question.Correct = "7";

            Question result = api.AddQuestion(question);
            Console.WriteLine(result);

            Console.WriteLine();

            // Delete a question
            Console.WriteLine("Press enter to run delete question-demo: ");
            Console.ReadLine();

            Boolean success = api.DeleteQuestion(result.ID);
            Console.WriteLine(success);

            Console.ReadLine();
        }
    }
}
