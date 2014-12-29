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

            Question question2 = new Question("solve 4 * 7", categories, answers);
            Question result2 = api.AddQuestion(question);
            question2.ID = result2.ID;

            System.Diagnostics.Debug.WriteLine(question);
            System.Diagnostics.Debug.WriteLine(result2);

            List<String> categories3 = new List<String>();
            categories3.Add("basic");

            List<String> answers3 = new List<String>();
            answers3.Add("80");
            answers3.Add("35");
            answers3.Add("53");

            Question question4 = new Question("Solve 3 + 5 * 10", categories3, answers3);
            Question result3 = api.AddQuestion(question4);

            List<String> answers4 = new List<String>();
            answers4.Add("80");
            answers4.Add("53");

            Question question5 = new Question(question4.Title, question4.Categories, answers4);

            Question result4 = api.EditQuestion(result3.ID, question5);
        }
    }
}
