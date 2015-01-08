using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.API.Test
{
    public class QuestionUtility
    {
        /// <summary>
        /// Generate a generic question to be used in the tests
        /// </summary>
        /// <returns>A generic question</returns>
        public static Question GetGenericQuestion()
        {
            Question question = new Question("test");
            question.AddCategories("test");
            question.AddAnswers("test");
            question.Correct = "test";
            return question;
        }
    }
}
