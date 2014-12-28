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
            List<String> categories = api.GetCategories();
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

            List<String> categories = new List<String>();
            categories.Add("basic");

            List<String> answers = new List<String>();
            answers.Add("24");
            answers.Add("26");
            answers.Add("28");
            answers.Add("30");
            answers.Add("32");

            Question question = new Question("Solve 4 * 7", categories, answers);
            Question result = api.AddQuestion(question);

            // This row is needed as the supplied question shouldn't have an ID explicitly specified
            // and therefore we assign it the ID of the result question
            question.ID = result.ID;

            Assert.AreNotEqual(result, null);
        }

        [TestCase]
        public void EditQuestion()
        {
            API api = new API("");
            Question question = new Question("test", null, null);
            Question result = api.EditQuestion(1, question);
            Assert.AreEqual(result.Title, "test");
        }

        [TestCase]
        public void DeleteQuestion()
        {
            API api = new API("");
            Boolean success = api.DeleteQuestion(2);
            Assert.AreEqual(success, true);
        }
    }
}
