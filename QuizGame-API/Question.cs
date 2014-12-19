using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGameAPI
{
    public class Question
    {
        private int id;
        private String title;

        private String category;
        private List<Answer> answers;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
