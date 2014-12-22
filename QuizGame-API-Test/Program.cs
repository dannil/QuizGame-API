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
            Question question = api.GetQuestion(0);
            List<Question> questions1 = api.GetQuestions();
            List<Question> questions2 = api.GetQuestionsByCategory("algebra");
            List<CategoryHolder> categories1 = api.GetCategories();
            Boolean success = api.DeleteQuestion(0);

            Question question3 = new Question();
            question3.Title = "Testing post";
            api.AddQuestion(question3);
        }
    }
}
