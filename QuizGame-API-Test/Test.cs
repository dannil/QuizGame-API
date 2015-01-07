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
        public void TestURLConstructor()
        {
            API api = new API("http://localhost:8080/quizgame-backend", "api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            List<String> categories = api.GetCategories();

            Assert.AreNotEqual(categories, null);
        }

        // ----- CATEGORIES ----- //

        /// <summary>
        /// Test-ID 1
        /// </summary>
        [TestCase]
        public void GetCategories()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");
            
            List<String> categories = api.GetCategories();
            
            Assert.AreNotEqual(categories, null);
        }

        // ----- QUESTIONS ----- //

        /// <summary>
        /// Test-ID 2
        /// </summary>
        [TestCase]
        public void GetQuestionByID()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = QuestionUtility.GetGenericQuestion();

            Question result = api.AddQuestion(question);

            Question fetched = api.GetQuestion(result.ID);
            
            Assert.AreNotEqual(question, null);
        }

        [TestCase]
        public void GetQuestionWithNonExistingIDLowerBoundary()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            api.AddQuestion(QuestionUtility.GetGenericQuestion());

            List<Question> questions = api.GetQuestions();

            Question result = api.GetQuestion(-1);

            Assert.AreEqual(result, null);
        }

        [TestCase]
        public void GetQuestionWithExistingIDLowerBoundary()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            api.AddQuestion(QuestionUtility.GetGenericQuestion());

            List<Question> questions = api.GetQuestions();

            Question result = questions[0];

            Assert.AreNotEqual(result, null);
        }

        [TestCase]
        public void GetQuestionWithExistingIDUpperBoundary()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            api.AddQuestion(QuestionUtility.GetGenericQuestion());

            List<Question> questions = api.GetQuestions();

            Question result = questions[questions.Count - 1];

            Assert.AreNotEqual(result, null);
        }

        /// <summary>
        /// Test-ID 15
        /// </summary>
        [TestCase]
        public void GetQuestionWithNonExistingIDUpperBoundary()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");
            api.AddQuestion(QuestionUtility.GetGenericQuestion());

            List<Question> questions = api.GetQuestions();

            Question result = api.GetQuestion(questions[questions.Count - 1].ID + 1);

            Assert.AreEqual(result, null);
        }

        /// <summary>
        /// Test-ID 3
        /// </summary>
        [TestCase]
        public void GetQuestions()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");
            
            List<Question> questions = api.GetQuestions();
            
            Assert.AreNotEqual(questions, null);
        }

        /// <summary>
        /// Test-ID 4
        /// </summary>
        [TestCase]
        public void GetQuestionsByCategory()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = new Question("Solve a, where a + 4 = 11");
            question.AddCategories("basic", "algebra");
            question.AddAnswers("Undefined", "0", "-7", "7");
            question.Correct = "7";

            Question result = api.AddQuestion(question);

            List<Question> questions = api.GetQuestionsByCategory("algebra");
            
            Assert.AreNotEqual(questions, null);
        }

        /// <summary>
        /// Test-ID 5
        /// </summary>
        [TestCase]
        public void AddQuestion()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = new Question("Solve 4 * 7");
            question.AddCategories("basic");
            question.AddAnswers("24", "26", "28", "30", "32");
            question.Correct = "28";

            Question result = api.AddQuestion(question);

            Assert.AreNotEqual(result, null);
        }

        /// <summary>
        /// Test-ID 14
        /// </summary>
        [TestCase]
        public void AddQuestionWithNullValues()
        {
            // Tests that if given null, null is returned
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = new Question(null, null, null, null);

            Question result = api.AddQuestion(question);

            Assert.AreEqual(result, null);
        }

        /// <summary>
        /// Test-ID 6
        /// </summary>
        [TestCase]
        public void EditQuestionTitle()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = QuestionUtility.GetGenericQuestion();

            Question result = api.AddQuestion(question);

            question.Title = "changed";

            Question result2 = api.EditQuestion(result.ID, question);

            Assert.AreNotEqual(result.Title, result2.Title);
        }

        /// <summary>
        /// Test-ID 8
        /// </summary>
        [TestCase]
        public void EditQuestionCategoriesAdd()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = QuestionUtility.GetGenericQuestion();

            Question result = api.AddQuestion(question);

            question.AddCategories("generic", "undefined");

            Question result2 = api.EditQuestion(result.ID, question);

            Assert.AreNotEqual(result.Categories, result2.Categories);
        }

        [TestCase]
        public void EditQuestionCategoriesRemove()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = QuestionUtility.GetGenericQuestion();
            question.AddCategories("undefined");

            Question result = api.AddQuestion(question);

            question.RemoveCategories("undefined");

            Question result2 = api.EditQuestion(result.ID, question);

            Assert.AreNotEqual(result.Categories, result2.Categories);
        }

        [TestCase]
        public void EditQuestionAnswersAdd()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = new Question("Solve 3 + 5 * 10");
            question.AddCategories("basic");
            question.AddAnswers("80", "53", "35");
            question.Correct = "53";

            Question result = api.AddQuestion(question);

            question.AddAnswers("200");

            Question result2 = api.EditQuestion(result.ID, question);

            Assert.AreNotEqual(result.Answers, result2.Answers);
        }

        [TestCase]
        public void EditQuestionAnswersRemove()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = new Question("Solve 3 + 5 * 10");
            question.AddCategories("basic");
            question.AddAnswers("80", "53", "35");
            question.Correct = "53";

            Question result = api.AddQuestion(question);

            question.RemoveAnswers("80");

            Question result2 = api.EditQuestion(result.ID, question);

            Assert.AreNotEqual(result.Answers, result2.Answers);
        }

        [TestCase]
        public void EditQuestionCorrect()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = QuestionUtility.GetGenericQuestion();

            Question result = api.AddQuestion(question);

            question.Correct = "changed";

            Question result2 = api.EditQuestion(result.ID, question);

            Assert.AreNotEqual(result.Correct, result2.Correct);
        }

        /// <summary>
        /// Test-ID 7
        /// </summary>
        [TestCase]
        public void DeleteQuestion()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = QuestionUtility.GetGenericQuestion();

            Question result = api.AddQuestion(question);

            Boolean success = api.DeleteQuestion(result.ID);

            Assert.AreEqual(success, true);
        }

        /// <summary>
        /// Test-ID 9
        /// </summary>
        [TestCase]
        public void DeleteQuestionWithNonExistingIDLowerBoundary()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");
            api.AddQuestion(QuestionUtility.GetGenericQuestion());

            Boolean result = api.DeleteQuestion(-1);

            Assert.AreEqual(result, false);
        }

        /// <summary>
        /// Test-ID 19
        /// </summary>
        [TestCase]
        public void DeleteQuestionWithExistingIDLowerBoundary()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");
            api.AddQuestion(QuestionUtility.GetGenericQuestion());

            List<Question> questions = api.GetQuestions();

            Boolean result = api.DeleteQuestion(questions[0].ID);

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// Test-ID 20
        /// </summary>
        [TestCase]
        public void DeleteQuestionWithExistingIDUpperBoundary()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");
            api.AddQuestion(QuestionUtility.GetGenericQuestion());

            List<Question> questions = api.GetQuestions();

            Boolean result = api.DeleteQuestion(questions[questions.Count - 1].ID);

            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// Test-ID 21
        /// </summary>
        [TestCase]
        public void DeleteQuestionWithNonExistingIDUpperBoundary()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");
            api.AddQuestion(QuestionUtility.GetGenericQuestion());

            List<Question> questions = api.GetQuestions();

            Boolean result = api.DeleteQuestion(questions[questions.Count - 1].ID + 1);

            Assert.AreEqual(result, false);
        }

        /// <summary>
        /// Test-ID 11
        /// </summary>
        [TestCase]
        public void GetAnswersByQuestionID()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = QuestionUtility.GetGenericQuestion();

            Question result = api.AddQuestion(question);

            List<String> answers = api.GetAnswersByQuestionID(result.ID);

            Assert.AreNotEqual(answers, null);
        }

        /// <summary>
        /// Test-ID 10
        /// </summary>
        [TestCase]
        public void QuestionToString()
        {
            Question question = QuestionUtility.GetGenericQuestion();

            Assert.AreNotEqual(question.ToString(), null);
        }

        [TestCase]
        public void QuestionToStringCompare()
        {
            Question question = QuestionUtility.GetGenericQuestion();
            Question question2 = QuestionUtility.GetGenericQuestion();
            question2.AddCategories("basic");

            Assert.AreNotEqual(question.ToString(), question2.ToString());
        }
    }
}
