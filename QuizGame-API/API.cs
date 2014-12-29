using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace QuizGameAPI
{
    public class API
    {
        // Instance variables
        private String url;
        private String apiKey;

        private JsonSerializer serializer;

        private API()
        {
            this.url = "http://localhost:8080/quizgame-backend";
            this.serializer = new JsonSerializer();
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
        public List<String> GetCategories()
        {
            RestClient client = new RestClient(this.url);

            RestRequest request = new RestRequest("category", Method.GET);

            // execute the request
            RestResponse<List<String>> response = (RestResponse<List<String>>)client.Execute<List<String>>(request);
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
            RestClient client = new RestClient(this.url);

            RestRequest request = new RestRequest("question/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());

            // execute the request
            RestResponse<Question> response = (RestResponse<Question>)client.Execute<Question>(request);
            return response.Data;
        }

        /// <summary>
        /// Get a list of all questions.
        /// </summary>
        /// <returns>A list of questions</returns>
        public List<Question> GetQuestions()
        {
            RestClient client = new RestClient(this.url);

            RestRequest request = new RestRequest("question", Method.GET);

            // execute the request
            RestResponse<List<Question>> response = (RestResponse<List<Question>>)client.Execute<List<Question>>(request);
            return response.Data;
        }

        /// <summary>
        /// Get a list of all questions which contains the specified category.
        /// </summary>
        /// <param name="category">The category of the questions</param>
        /// <returns>A list of questions</returns>
        public List<Question> GetQuestionsByCategory(String category)
        {
            RestClient client = new RestClient(this.url);

            RestRequest request = new RestRequest("question/category/{category}", Method.GET);
            request.AddUrlSegment("category", category);

            // execute the request
            RestResponse<List<Question>> response = (RestResponse<List<Question>>)client.Execute<List<Question>>(request);
            return response.Data;
        }

        /// <summary>
        /// Add the specified question.
        /// </summary>
        /// <param name="question">The question to add</param>
        /// <returns>A question with new values set by the back-end system</returns>
        public Question AddQuestion(Question question)
        {
            RestClient client = new RestClient(this.url);

            // This should really be PUT instead of POST considering our pattern, but getting 
            // it to work with PUT both on the API and the backend side is a real hassle
            RestRequest request = new RestRequest("question", Method.POST);
            request.AddParameter("json", serializer.Serialize(question));
            String json = serializer.Serialize(question);

            // execute the request
            RestResponse<Question> response = (RestResponse<Question>)client.Execute<Question>(request);
            return response.Data;
        }

        public Question EditQuestion(int id, Question question)
        {
            RestClient client = new RestClient(this.url);

            RestRequest request = new RestRequest("question/" + id, Method.POST);
            request.AddParameter("json", serializer.Serialize(question));

            // execute the request
            RestResponse<Question> response = (RestResponse<Question>)client.Execute<Question>(request);
            return response.Data;
        }

        /// <summary>
        /// Delete a question with the specified id
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <returns>True if a question with that id exists and is successfully deleted, otherwise false</returns>
        public Boolean DeleteQuestion(int id)
        {
            RestClient client = new RestClient(this.url);

            RestRequest request = new RestRequest("question/{id}", Method.DELETE);
            request.AddUrlSegment("id", id.ToString());

            // execute the request
            RestResponse<Question> response = (RestResponse<Question>)client.Execute<Question>(request);
            return (response.StatusCode.Equals(HttpStatusCode.OK) ? true : false);
        }

        // ----- ANSWERS ----- //

        public List<String> GetAnswers()
        {
            return null;
        }

        public List<String> GetAnswersByCategory(String category)
        {
            return null;
        }

        public List<String> GetAnswersByQuestionID(int id)
        {
            return null;
        }

        public List<String> GetAnswersByQuestion(Question question)
        {
            return this.GetAnswersByQuestionID(question.ID);
        }
    }
}
