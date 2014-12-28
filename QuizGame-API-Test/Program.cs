using QuizGameAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizGame_API_Test
{
    class Program
    {
        public static void Main(String[] args)
        {
            API api = new API("");
            Question question = api.GetQuestion(1);
            List<Question> questions1 = api.GetQuestions();
            List<Question> questions2 = api.GetQuestionsByCategory("basic");
            List<String> categories1 = api.GetCategories();
            Boolean success = api.DeleteQuestion(2);

            List<String> categories = new List<String>();
            categories.Add("basic");

            List<String> answers = new List<String>();
            answers.Add("24");
            answers.Add("26");
            answers.Add("28");
            answers.Add("30");
            answers.Add("32");

            Question question3 = new Question("solve 4 * 7", categories, answers);
            Question result = api.AddQuestion(question3);
            question3.ID = result.ID;

            System.Diagnostics.Debug.WriteLine(question3);
            System.Diagnostics.Debug.WriteLine(result);
        }
    }
}
