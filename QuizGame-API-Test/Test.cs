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
            Question question = api.GetQuestion(1);
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

        [TestCase]
        public void AddQuestion()
        {
            API api = new API("");
            Question question = new Question();
            question.Title = "testing post";
            api.AddQuestion(question);
        }

        [TestCase]
        public void DeleteQuestion()
        {
            API api = new API("");
            Boolean success = api.DeleteQuestion(0);
            Assert.AreEqual(success, true);
        }
    }
}
