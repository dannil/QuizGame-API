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
        private List<AnswerHolder> answers;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        public String Category
        {
            get { return category; }
            set { category = value; }
        }

        public List<AnswerHolder> Answers
        {
            get { return answers; }
            set { answers = value; }
        }
    }
}
