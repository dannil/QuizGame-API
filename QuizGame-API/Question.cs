using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGameAPI
{
    public class Question
    {
        private int id;
        private String title;

        private List<String> categories;
        private List<String> answers;

        public Question()
        {
            this.categories = new List<String>();
            this.answers = new List<String>();
        }

        public Question(String title) : this()
        {
            this.title = title;
        }

        public Question(String title, List<String> categories, List<String> answers) : this(title)
        {
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

        public List<String> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public List<String> Answers
        {
            get { return answers; }
            set { answers = value; }
        }

        public void AddCategory(String category)
        {
            if (!category.Equals(String.Empty) && this.categories != null)
            {
                this.categories.Add(category);
            }
        }

        public void RemoveCategory(String category)
        {
            if (!category.Equals(String.Empty) && this.categories != null && this.categories.Contains(category))
            {
                this.categories.Remove(category);
            }
        }

        public void AddAnswer(String answer)
        {
            if (!answer.Equals(String.Empty) && this.answers != null)
            {
                this.answers.Add(answer);
            }
        }

        public void RemoveAnswer(String answer)
        {
            if (!answer.Equals(String.Empty) && this.answers != null && this.answers.Contains(answer))
            {
                this.answers.Remove(answer);
            }
        }

        public override string ToString()
        {
            return "Question={id={" + id + "};title={" + title + "};categories={" + 
                String.Join(",", categories) + "};answers={" + String.Join(",", answers) + "};};";
        }

    }
}
