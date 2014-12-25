using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
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

        /// <summary>
        /// Get a list of all categories.
        /// </summary>
        /// <returns>A list of categories</returns>
        public List<CategoryHolder> GetCategories()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/category");
            request.Method = "GET";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode.Equals(HttpStatusCode.OK))
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    String json = sr.ReadToEnd();
                    return serializer.Deserialize<List<CategoryHolder>>(json);
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // ----- QUESTIONS ----- //

        /// <summary>
        /// Get a question with the specified id.
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <returns>A question with the specified id</returns>
        public Question GetQuestion(int id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/question/" + id);
            request.Method = "GET";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode.Equals(HttpStatusCode.OK))
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    String json = sr.ReadToEnd();
                    return serializer.Deserialize<Question>(json);
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get a list of all questions.
        /// </summary>
        /// <returns>A list of questions</returns>
        public List<Question> GetQuestions()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/question");
            request.Method = "GET";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode.Equals(HttpStatusCode.OK))
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    String json = sr.ReadToEnd();
                    return serializer.Deserialize<List<Question>>(json);
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get a list of all questions which contains the specified category.
        /// </summary>
        /// <param name="category">The category of the questions</param>
        /// <returns>A list of questions</returns>
        public List<Question> GetQuestionsByCategory(String category)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/question/category/" + category);
            request.Method = "GET";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode.Equals(HttpStatusCode.OK))
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    String json = sr.ReadToEnd();
                    return serializer.Deserialize<List<Question>>(json);
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Add the specified question.
        /// </summary>
        /// <param name="question">The question to add</param>
        /// <returns>A question with new values set by the back-end system</returns>
        public Question AddQuestion(Question question)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/question");
            request.Method = "POST";
            try
            {
                String formContent = "json=" + serializer.Serialize(question);

                byte[] byteArray = Encoding.UTF8.GetBytes(formContent);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                Stream stream = request.GetRequestStream();
                stream.Write(byteArray, 0, byteArray.Length);
                stream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode.Equals(HttpStatusCode.OK))
                {
                    stream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream);
                    String json = sr.ReadToEnd();
                    return serializer.Deserialize<Question>(json);
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Delete a question with the specified id
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <returns>True if a question with that id exists and is successfully deleted, otherwise false</returns>
        public Boolean DeleteQuestion(int id)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url + "/question/" + id);
            request.Method = "DELETE";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode.Equals(HttpStatusCode.OK))
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
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
