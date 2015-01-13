using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGame.API.Test
{
    /// <summary>
    /// Class for running NUnit tests on our questions and the corresponding API.
    /// </summary>
    public class Test
    {
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

        /// <summary>
        /// Test-ID 2
        /// </summary>
        [TestCase]
        public void GetQuestionByID()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = new Question(QuestionUtility.GetGenericQuestion());

            Question result = api.AddQuestion(question);

            Question fetched = api.GetQuestion(result.ID);
            
            Assert.AreNotEqual(question, null);
        }

        /// <summary>
        /// Test-ID 16
        /// </summary>
        [TestCase]
        public void GetQuestionWithNonExistingIDLowerBoundary()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            api.AddQuestion(new Question(QuestionUtility.GetGenericQuestion()));

            List<Question> questions = api.GetQuestions();

            Question result = api.GetQuestion(-1);

            Assert.AreEqual(result, null);
        }

        /// <summary>
        /// Test-ID 18
        /// </summary>
        [TestCase]
        public void GetQuestionWithExistingIDLowerBoundary()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            api.AddQuestion(new Question(QuestionUtility.GetGenericQuestion()));

            List<Question> questions = api.GetQuestions();

            Question result = questions[0];

            Assert.AreNotEqual(result, null);
        }

        /// <summary>
        /// Test-ID 17
        /// </summary>
        [TestCase]
        public void GetQuestionWithExistingIDUpperBoundary()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            api.AddQuestion(new Question(QuestionUtility.GetGenericQuestion()));

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
            api.AddQuestion(new Question(QuestionUtility.GetGenericQuestion()));

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

            List<String> categories = new List<String> { "basic", "basic" };
            List<String> answers = new List<String> { "24", "26", "28", "30", "32" };

            Question question = new Question("Solve 4 * 7", categories, answers, "28");

            Question result = api.AddQuestion(question);

            Assert.AreNotEqual(result, null);
        }

        /// <summary>
        /// Test-ID 14
        /// </summary>
        [TestCase]
        public void AddQuestionWithNullValues()
        {
            Assert.Throws<ArgumentNullException>(delegate
            {
                Question question = new Question(null, null, null, null);
            });
        }

        /// <summary>
        /// Test-ID 6
        /// </summary>
        [TestCase]
        public void EditQuestionTitleDatabase()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = new Question(QuestionUtility.GetGenericQuestion());

            Question result = api.AddQuestion(question);

            question.Title = "changed";

            Question result2 = api.EditQuestion(result.ID, question);

            Assert.AreNotEqual(result.Title, result2.Title);
        }

        /// <summary>
        /// Test-ID 8
        /// </summary>
        [TestCase]
        public void EditQuestionCategoriesAddDatabase()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = new Question(QuestionUtility.GetGenericQuestion());

            Question result = api.AddQuestion(question);

            question.AddCategories("generic", "undefined");

            Question result2 = api.EditQuestion(result.ID, question);

            Assert.AreNotEqual(result.Categories, result2.Categories);
        }

        /// <summary>
        /// Test-ID 12
        /// </summary>
        [TestCase]
        public void EditQuestionAnswersAddDatabase()
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

        /// <summary>
        /// Test-ID 13
        /// </summary>
        [TestCase]
        public void EditQuestionAnswersRemoveDatabase()
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

        /// <summary>
        /// Test-ID 7
        /// </summary>
        [TestCase]
        public void DeleteQuestion()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = new Question(QuestionUtility.GetGenericQuestion());

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
            api.AddQuestion(new Question(QuestionUtility.GetGenericQuestion()));

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
            api.AddQuestion(new Question(QuestionUtility.GetGenericQuestion()));

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
            api.AddQuestion(new Question(QuestionUtility.GetGenericQuestion()));

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
            api.AddQuestion(new Question(QuestionUtility.GetGenericQuestion()));

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

            Question question = new Question(QuestionUtility.GetGenericQuestion());

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
            Question question = new Question(QuestionUtility.GetGenericQuestion());

            Assert.AreNotEqual(question.ToString(), null);
        }

        /// <summary>
        /// Test-ID 22
        /// </summary>
        [TestCase]
        public void QuestionToStringCompare()
        {
            Question question = new Question(QuestionUtility.GetGenericQuestion());
            Question question2 = new Question(QuestionUtility.GetGenericQuestion());
            question2.AddCategories("generic");

            Assert.AreNotEqual(question.ToString(), question2.ToString());
        }

        /// <summary>
        /// Test-ID 23
        /// </summary>
        [TestCase]
        public void TestURLConstructor()
        {
            API api = new API("http://localhost:8080/quizgame-backend", "api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = new Question("Solve 4 + 4 * 4");
            question.AddCategories("basic");
            question.AddAnswers("16", "20", "24");
            api.AddQuestion(question);

            List<String> categories = api.GetCategories();

            Assert.AreNotEqual(categories, null);
        }

        /// <summary>
        /// Test-ID 24
        /// </summary>
        [TestCase]
        public void EditQuestionCategoriesRemoveDatabase()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = new Question(QuestionUtility.GetGenericQuestion());
            question.AddCategories("undefined");

            Question result = api.AddQuestion(question);

            question.RemoveCategories("undefined");

            Question result2 = api.EditQuestion(result.ID, question);

            Assert.AreNotEqual(result.Categories, result2.Categories);
        }

        /// <summary>
        /// Test-ID 25
        /// </summary>
        [TestCase]
        public void EditQuestionCorrectDatabase()
        {
            API api = new API("api-test", "2fb5e13419fc89246865e7a324f476ec624e8740");

            Question question = new Question(QuestionUtility.GetGenericQuestion());

            Question result = api.AddQuestion(question);

            question.Correct = "changed";

            Question result2 = api.EditQuestion(result.ID, question);

            Assert.AreNotEqual(result.Correct, result2.Correct);
        }

        /// <summary>
        /// Test-ID 26
        /// </summary>
        [TestCase]
        public void EditQuestionID()
        {
            Question question = new Question(QuestionUtility.GetGenericQuestion());
            question.ID = 0;

            Question question2 = new Question(QuestionUtility.GetGenericQuestion());
            question2.ID = 1;

            Assert.AreNotEqual(question.ID, question2.ID);
        }

        /// <summary>
        /// Test-ID 27
        /// </summary>
        [TestCase]
        public void EditQuestionTitle()
        {
            Question question = new Question(QuestionUtility.GetGenericQuestion());
            question.Title = "title";

            Question question2 = new Question(QuestionUtility.GetGenericQuestion());
            question2.Title = "another title";

            Assert.AreNotEqual(question.Title, question2.Title);
        }

        /// <summary>
        /// Test-ID 28
        /// </summary>
        [Test]
        public void EditQuestionCategoriesAdd()
        {
            Question question = new Question(QuestionUtility.GetGenericQuestion());
            question.AddCategories("generic");

            Question question2 = new Question(QuestionUtility.GetGenericQuestion());
            question2.AddCategories("generic", "undefined");

            Assert.AreNotEqual(question.Categories, question2.Categories);
        }

        /// <summary>
        /// Test-ID 29
        /// </summary>
        [TestCase]
        public void EditQuestionCategoriesRemove()
        {
            Question question = new Question(QuestionUtility.GetGenericQuestion());
            question.AddCategories("undefined");

            Question question2 = new Question(QuestionUtility.GetGenericQuestion());
            question2.AddCategories("undefined");
            question2.RemoveCategories("undefined");

            Assert.AreNotEqual(question.Categories, question2.Categories);
        }

        /// <summary>
        /// Test-ID 30
        /// </summary>
        [TestCase]
        public void EditQuestionAnswersAdd()
        {
            Question question = new Question("Solve 3 + 5 * 10");
            question.AddCategories("basic");
            question.AddAnswers("80", "53", "35");
            question.Correct = "53";

            Question question2 = new Question("Solve 3 + 5 * 10");
            question2.AddCategories("basic");
            question2.AddAnswers("80", "53", "35", "200");
            question2.Correct = "53";

            Assert.AreNotEqual(question.Answers, question2.Answers);
        }

        /// <summary>
        /// Test-ID 31
        /// </summary>
        [TestCase]
        public void EditQuestionAnswersRemove()
        {
            Question question = new Question("Solve 3 + 5 * 10");
            question.AddCategories("basic");
            question.AddAnswers("80", "53", "35");
            question.Correct = "53";

            Question question2 = new Question("Solve 3 + 5 * 10");
            question2.AddCategories("basic");
            question2.AddAnswers("80", "53", "35");
            question2.Correct = "53";

            question2.RemoveAnswers("80");

            Assert.AreNotEqual(question.Answers, question2.Answers);
        }

        /// <summary>
        /// Test-ID 32
        /// </summary>
        [TestCase]
        public void EditQuestionCorrect()
        {
            Question question = new Question(QuestionUtility.GetGenericQuestion());
            question.Correct = "changed";

            Question question2 = new Question(QuestionUtility.GetGenericQuestion());
            question2.Correct = "another correct";

            Assert.AreNotEqual(question.Correct, question2.Correct);
        }

        /// <summary>
        /// Test-ID 33
        /// </summary>
        [TestCase]
        public void EditQuestionIDLowerBoundary()
        {
            Question question = new Question(QuestionUtility.GetGenericQuestion());
            question.ID = -1;

            // ID defaults to 0 if it's value isn't valid
            Assert.AreEqual(question.ID, 0);
        }

        /// <summary>
        /// Test-ID 34
        /// </summary>
        [TestCase]
        public void EditQuestionTitleNull()
        {
            Question question = new Question(QuestionUtility.GetGenericQuestion());

            Assert.Throws<ArgumentNullException>(delegate
            {
                question.Title = null;
            });
        }

        /// <summary>
        /// Test-ID 35
        /// </summary>
        [TestCase]
        public void EditQuestionCategoryAddNull()
        {
            Question question = new Question(QuestionUtility.GetGenericQuestion());

            Assert.Throws<ArgumentNullException>(delegate
            {
                question.AddCategories(null);
            });
        }

        /// <summary>
        /// Test-ID 36
        /// </summary>
        [TestCase]
        public void EditQuestionAnswersAddNull()
        {
            Question question = new Question(QuestionUtility.GetGenericQuestion());

            Assert.Throws<ArgumentNullException>(delegate
            {
                question.AddAnswers(null);
            });
        }

        /// <summary>
        /// Test-ID 37
        /// </summary>
        [TestCase]
        public void EditQuestionCorrectNull()
        {
            Question question = new Question(QuestionUtility.GetGenericQuestion());

            Assert.Throws<ArgumentNullException>(delegate
            {
                question.Correct = null;
            });
        }

        /// <summary>
        /// Test-ID 38
        /// </summary>
        [TestCase]
        public void EditQuestionCategoryValidFirstNullLast()
        {
            Question question = new Question(QuestionUtility.GetGenericQuestion());

            Assert.Throws<ArgumentNullException>(delegate
            {
                question.AddCategories("basic", null);
            });
        }

        /// <summary>
        /// Test-ID 39
        /// </summary>
        [TestCase]
        public void EditQuestionAnswerValidFirstNullLast()
        {
            Question question = new Question(QuestionUtility.GetGenericQuestion());

            Assert.Throws<ArgumentNullException>(delegate
            {
                question.AddAnswers("20", null);
            });
        }

        /// <summary>
        /// Test-ID 40
        /// </summary>
        [TestCase]
        public void EditQuestionCategoryListIsNull()
        {
            Question question = new Question(QuestionUtility.GetGenericQuestion());

            Assert.Throws<ArgumentNullException>(delegate
            {
                question.Categories = null;
            });
        }

        /// <summary>
        /// Test-ID 41
        /// </summary>
        [TestCase]
        public void EditQuestionAnswerListIsNull()
        {
            Question question = new Question(QuestionUtility.GetGenericQuestion());

            Assert.Throws<ArgumentNullException>(delegate
            {
                question.Answers = null;
            });
        }

    }
}
