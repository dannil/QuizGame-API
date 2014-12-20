using NUnit.Framework;
using QuizGameAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGame_API_Test
{
    public class Test
    {
        [TestCase]
        public void GetQuestionByID()
        {
            API api = new API("");
            api.GetQuestionByID(1);
        }
    }
}
