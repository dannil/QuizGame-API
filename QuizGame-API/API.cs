using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace QuizGame.API
{
    /// <summary>
    /// API which communicates with the specified quiz game back-end.
    /// </summary>
    public class API
    {
        // Instance variables
        private String url;

        private String username;
        private String token;

        private JsonSerializer serializer;
        private RestClient client;

        /// <summary>
        /// Default constructor
        /// </summary>
        private API()
        {
            this.url = "http://localhost:8080/quizgame-backend";

            this.serializer = new JsonSerializer();
            this.client = new RestClient(this.url);
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="username">The username to use</param>
        /// <param name="token">The token key to use</param>
        public API(String username, String token) : this()
        {
            this.username = username;
            this.token = token;

            this.client.Authenticator = new SimpleAuthenticator("username", this.username, "token", this.token);
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="username">The username to use</param>
        /// <param name="token">The token key to use</param>
        /// <param name="url">The URL to use</param>
        public API(String url, String username, String token) : this(username, token)
        {
            this.url = url;
        }

        // ----- CATEGORIES ----- //

        /// <summary>
        /// Get a list of all categories.
        /// </summary>
        /// <returns>A list of categories</returns>
        public List<String> GetCategories()
        {
            RestRequest request = new RestRequest("category", Method.GET);

            // execute the request
            RestResponse<List<String>> response = (RestResponse<List<String>>)this.client.Execute<List<String>>(request);
            return response.Data;
        }

        // ----- QUESTIONS ----- //

        /// <summary>
        /// Get a question with the specified id.
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <returns>A question with the specified id</returns>
        public Question GetQuestion(int id)
        {
            RestRequest request = new RestRequest("question/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());

            // execute the request
            RestResponse<Question> response = (RestResponse<Question>)this.client.Execute<Question>(request);
            return response.Data;
        }

        /// <summary>
        /// Get a list of all questions.
        /// </summary>
        /// <returns>A list of questions</returns>
        public List<Question> GetQuestions()
        {
            RestRequest request = new RestRequest("question", Method.GET);

            // execute the request
            RestResponse<List<Question>> response = (RestResponse<List<Question>>)this.client.Execute<List<Question>>(request);
            return response.Data;
        }

        /// <summary>
        /// Get a list of all questions which contains the specified category.
        /// </summary>
        /// <param name="category">The category of the questions</param>
        /// <returns>A list of questions</returns>
        public List<Question> GetQuestionsByCategory(String category)
        {
            RestRequest request = new RestRequest("question/category/{category}", Method.GET);
            request.AddUrlSegment("category", category);

            // execute the request
            RestResponse<List<Question>> response = (RestResponse<List<Question>>)this.client.Execute<List<Question>>(request);
            return response.Data;
        }

        /// <summary>
        /// Add the specified question.
        /// </summary>
        /// <param name="question">The question to add</param>
        /// <returns>A question with new values set by the back-end system</returns>
        public Question AddQuestion(Question question)
        {
            // This should really be PUT instead of POST considering our pattern, but getting 
            // it to work with PUT both on the API and the backend side is a real hassle
            RestRequest request = new RestRequest("question", Method.POST);
            request.AddParameter("json", serializer.Serialize(question));

            // execute the request
            RestResponse<Question> response = (RestResponse<Question>)this.client.Execute<Question>(request);
            return response.Data;
        }

        /// <summary>
        /// Edit the question with the specified id.
        /// </summary>
        /// <param name="id">The id of the question to edit</param>
        /// <param name="question">The question values to replace the saved question</param>
        /// <returns>A question with the new values if the operation succeeded, otherwise null</returns>
        public Question EditQuestion(int id, Question question)
        {
            RestRequest request = new RestRequest("question/{id}", Method.POST);
            request.AddUrlSegment("id", id.ToString());
            request.AddParameter("json", serializer.Serialize(question));

            // execute the request
            RestResponse<Question> response = (RestResponse<Question>)this.client.Execute<Question>(request);
            return response.Data;
        }

        /// <summary>
        /// Delete a question with the specified id.
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <returns>True if a question with that id exists and is successfully deleted, otherwise false</returns>
        public Boolean DeleteQuestion(int id)
        {
            RestRequest request = new RestRequest("question/{id}", Method.DELETE);
            request.AddUrlSegment("id", id.ToString());

            // execute the request
            RestResponse response = (RestResponse)this.client.Execute(request);
            return (response.StatusCode.Equals(HttpStatusCode.OK) ? true : false);
        }

        // ----- ANSWERS ----- //

        //public List<String> GetAnswers()
        //{
        //    return null;
        //}

        //public List<String> GetAnswersByCategory(String category)
        //{
        //    return null;
        //}

        /// <summary>
        /// Get all the answers for the specified question id.
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <returns>A list of all the question's answers, with the correct answer as the last entry</returns>
        public List<String> GetAnswersByQuestionID(int id)
        {
            RestRequest request = new RestRequest("question/{id}/answer", Method.GET);
            request.AddUrlSegment("id", id.ToString());

            // execute the request
            RestResponse<List<String>> response = (RestResponse<List<String>>)this.client.Execute<List<String>>(request);
            return response.Data;
        }

        //public List<String> GetAnswersByQuestion(Question question)
        //{
        //    return this.GetAnswersByQuestionID(question.ID);
        //}
    }
}
