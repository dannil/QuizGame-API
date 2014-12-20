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
            Question question = api.GetQuestionByID(1);
            List<Question> questions = api.GetQuestions();
        }
    }
}
