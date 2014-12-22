using System;
using System.Collections.Generic;
using System.IO;
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
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url + "/category");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            HttpStatusCode statusCode = response.StatusCode;

            if (statusCode.Equals(HttpStatusCode.OK))
            {
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                String json = sr.ReadToEnd();
                return serializer.Deserialize<List<CategoryHolder>>(json);
            }
            else
            {
                return null;
            }
        }

        // ----- QUESTIONS ----- //

        public Question GetQuestion(int id)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url + "/question/" + id);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            HttpStatusCode statusCode = response.StatusCode;

            if (statusCode.Equals(HttpStatusCode.OK))
            {
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                String json = sr.ReadToEnd();
                return serializer.Deserialize<Question>(json);
            }
            else
            {
                return null;
            }
        }

        public List<Question> GetQuestions()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url + "/question");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            HttpStatusCode statusCode = response.StatusCode;

            if (statusCode.Equals(HttpStatusCode.OK))
            {
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                String json = sr.ReadToEnd();
                return serializer.Deserialize<List<Question>>(json);
            }
            else
            {
                return null;
            }
        }

        public List<Question> GetQuestionsByCategory(String category)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url + "/question/category/" + category);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            HttpStatusCode statusCode = response.StatusCode;

            if (statusCode.Equals(HttpStatusCode.OK))
            {
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                String json = sr.ReadToEnd();
                return serializer.Deserialize<List<Question>>(json);
            }
            else
            {
                return null;
            }
        }

        public Boolean DeleteQuestion(int id)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url + "/question/" + id);
            request.Method = "DELETE";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            HttpStatusCode statusCode = response.StatusCode;

            if (statusCode.Equals(HttpStatusCode.OK))
            {
                return true;
            }
            else
            {
                return false;
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
