using NUnit.Framework;
using QuizGameAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGame_API_Test
{
    public class Test
    {
        [TestCase]
        public void GetQuestionByID()
        {
            API api = new API("");
            Question question = api.GetQuestionByID(1);
        }

        [TestCase]
        public void GetQuestions()
        {
            API api = new API("");
            List<Question> questions = api.GetQuestions();
        }
    }
}
