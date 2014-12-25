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
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
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
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
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
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
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
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public Boolean AddQuestion(Question question)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/question");
            request.Method = "POST";

            String formContent = "json=" + serializer.Serialize(question);

            byte[] byteArray = Encoding.UTF8.GetBytes(formContent);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            reader.Close();
            dataStream.Close();
            response.Close();

            if (response.StatusCode.Equals(HttpStatusCode.OK)) {
                return true;
            }
            return false;

            //UTF8Encoding encoding = new UTF8Encoding();
            //String postData = "json=" + serializer.Serialize(question);
            //byte[] data = encoding.GetBytes(postData);

            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url + "/question");
            //request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";

            //request.ContentLength = data.Length;
            //Stream newStream = request.GetRequestStream();

            //// Send the data
            //newStream.Write(data, 0, data.Length);
            //newStream.Close();

            //using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            //{
            //    String json = serializer.Serialize(question);
            //    streamWriter.Write(json);
            //    streamWriter.Flush();
            //    streamWriter.Close();

            //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //    using (var streamReader = new StreamReader(response.GetResponseStream()))
            //    {
            //        String result = streamReader.ReadToEnd();
            //    }
            //}
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
                else
                {
                    return false;
                }
            }
            catch
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
