using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace QuizGameAPI
{
    public class API
    {
        private String apiKey;

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="apiKey">The API key to use</param>
        public API(String apiKey)
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
            return null;
        }

        public Question GetQuestionByID(int id)
        {
            JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            using (WebClient webClient = new System.Net.WebClient())
            {
                WebClient n = new WebClient();
                String json = n.DownloadString("http://localhost:8080/quizgame-backend/question/" + id);
                return oSerializer.Deserialize<Question>(json);
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
