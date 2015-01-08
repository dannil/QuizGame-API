using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.API.Test
{
    /// <summary>
    /// Utility class for generating semi-randomized questions which can be used in our tests.
    /// </summary>
    public class QuestionUtility
    {
        private static List<Question> questions;

        static QuestionUtility()
        {
            questions = new List<Question>();
            questions.Add(new Question("Solve 4 * 5", new List<String>() { "basic" }, new List<String>() { "18", "20", "22" }, "20"));
            questions.Add(new Question("Solve 4 * 3 + 5 * 5", new List<String>() { "basic" }, new List<String>() { "37", "64", "101" }, "37"));
            questions.Add(new Question("Solve a, where a^3 = 64", new List<String>() { "algebra" }, new List<String>() { "3", "4", "5", "6" }, "4"));
        }

        /// <summary>
        /// Get a semi-randomized question from our list of questions.
        /// </summary>
        /// <returns>A question</returns>
        public static Question GetGenericQuestion()
        {
            Random random = new Random();
            return questions[random.Next(questions.Count)];
        }
    }
}
