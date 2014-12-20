using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace QuizGameAPI
{
    public class API
    {
        // Instance variables
        private String url;
        private String apiKey;

        private JavaScriptSerializer serializer;

        private API()
        {
            this.url = "http://localhost:8080/quizgame-backend";
            this.serializer = new JavaScriptSerializer();
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="apiKey">The API key to use</param>
        public API(String apiKey) : this()
        {
            this.apiKey = apiKey;
        }

        // ----- CATEGORIES ----- //

        public List<String> GetCategories()
        {
            return null;
        }

        // ----- QUESTIONS ----- //

        public List<Question> GetQuestions()
        {
            try
            {
                WebClient n = new WebClient();
                String json = n.DownloadString(url + "/question");
                return serializer.Deserialize<List<Question>>(json);
            }
            catch (WebException e)
            {
                return null;
            }
        }

        public Question GetQuestionByID(int id)
        {
            try
            {
                WebClient n = new WebClient();
                String json = n.DownloadString(url + "/question/" + id);
                return serializer.Deserialize<Question>(json);
            }
            catch (WebException e)
            {
                return null;
            }
        }

        // ----- ANSWERS ----- //

        public List<Answer> GetAnswers()
        {
            return null;
        }

        public List<Answer> GetAnswersByCategory(String category)
        {
            return null;
        }

        public List<Answer> GetAnswersByQuestionID(int id)
        {
            return null;
        }

        public List<Answer> GetAnswersByQuestion(Question question)
        {
            return this.GetAnswersByQuestionID(question.ID);
        }
    }
}
