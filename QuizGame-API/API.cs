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

        public List<CategoryHolder> GetCategories()
        {
            try
            {
                WebClient n = new WebClient();
                String json = n.DownloadString(url + "/category");
                return serializer.Deserialize<List<CategoryHolder>>(json);
            }
            catch (WebException e)
            {
                return null;
            }
        }

        // ----- QUESTIONS ----- //

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

        public List<Question> GetQuestionsByCategory(String category)
        {
            try
            {
                WebClient n = new WebClient();
                String json = n.DownloadString(url + "/question/category/" + category);
                return serializer.Deserialize<List<Question>>(json);
            }
            catch (WebException e)
            {
                return null;
            }
        }

        // ----- ANSWERS ----- //

        public List<AnswerHolder> GetAnswers()
        {
            return null;
        }

        public List<AnswerHolder> GetAnswersByCategory(String category)
        {
            return null;
        }

        public List<AnswerHolder> GetAnswersByQuestionID(int id)
        {
            return null;
        }

        public List<AnswerHolder> GetAnswersByQuestion(Question question)
        {
            return this.GetAnswersByQuestionID(question.ID);
        }
    }
}
