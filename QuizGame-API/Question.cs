using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGameAPI
{
    public class Question
    {
        private int id;
        private String title;

        private List<CategoryHolder> categories;
        private List<AnswerHolder> answers;

        public int ID
        {
            get { return id; }
            private set { }
        }

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        public List<CategoryHolder> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public List<AnswerHolder> Answers
        {
            get { return answers; }
            set { answers = value; }
        }
    }
}
