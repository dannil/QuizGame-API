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

        public Question()
        {

        }

        public Question(String title, List<CategoryHolder> categories, List<AnswerHolder> answers)
        {
            this.title = title;
            this.categories = categories;
            this.answers = answers;
        }

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

        public override string ToString()
        {
            return "Question={id={" + id + "};title={" + title + "};categories={" + 
                String.Join(",", categories) + "};answers={" + String.Join(",", answers) + "};};";
        }

    }
}
