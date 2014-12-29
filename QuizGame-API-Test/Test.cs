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

            Assert.AreNotEqual(result, null);
        }

        [TestCase]
        public void EditQuestion()
        {
            API api = new API("");

            List<String> categories = new List<String>();
            categories.Add("basic");

            List<String> answers = new List<String>();
            answers.Add("80");
            answers.Add("35");
            answers.Add("53");

            Question question = new Question("Solve 3 + 5 * 10", categories, answers);
            Question result = api.AddQuestion(question);

            List<String> answers2 = new List<String>();
            answers2.Add("80");
            answers2.Add("53");

            Question question2 = new Question(question.Title, question.Categories, answers2);

            Question result2 = api.EditQuestion(result.ID, question2);

            Assert.AreNotEqual(result.Answers, result2.Answers);
        }

        [TestCase]
        public void DeleteQuestion()
        {
            API api = new API("");

            Question question = new Question("test", null, null);
            Question result = api.AddQuestion(question);

            Boolean success = api.DeleteQuestion(result.ID);

            Assert.AreEqual(success, true);
        }
    }
}
