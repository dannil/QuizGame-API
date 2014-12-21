using NUnit.Framework;
using QuizGameAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGame_API_Test
{
    public class Test
    {

        // ----- CATEGORIES ----- //
        [TestCase]
        public void GetCategories()
        {
            API api = new API("");
            List<CategoryHolder> categories = api.GetCategories();
            Assert.AreNotEqual(categories, null);
        }

        // ----- QUESTIONS ----- //

        [TestCase]
        public void GetQuestionByID()
        {
            API api = new API("");
            Question question = api.GetQuestionByID(1);
            Assert.AreNotEqual(question, null);
        }

        [TestCase]
        public void GetQuestions()
        {
            API api = new API("");
            List<Question> questions = api.GetQuestions();
            Assert.AreNotEqual(questions, null);
        }

        [TestCase]
        public void GetQuestionsByCategory()
        {
            API api = new API("");
            List<Question> questions = api.GetQuestionsByCategory("basic");
            Assert.AreNotEqual(questions, null);
        }
    }
}
