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

        private String correct;

        public Question()
        {
            this.categories = new List<String>();
            this.answers = new List<String>();
        }

        public Question(String title) : this()
        {
            this.title = title;
        }

        public Question(String title, List<String> categories, List<String> answers, String correct) : this(title)
        {
            this.categories = categories;
            this.answers = answers;
            this.correct = correct;
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

        public String Correct
        {
            get { return correct; }
            set { correct = value; }
        }

        public void AddCategories(params String[] categories)
        {
            foreach (String category in categories)
            {
                if (category != null)
                {
                    this.categories.Add(category);
                }
            }
        }

        public void RemoveCategories(params String[] categories)
        {
            foreach (String category in categories)
            {
                if (category != null)
                {
                    this.categories.Remove(category);
                }
            }
        }

        public void AddAnswers(params String[] answers)
        {
            foreach (String answer in answers)
            {
                if (answer != null)
                {
                    this.answers.Add(answer);
                }
            }
        }

        public void RemoveAnswers(params String[] answers)
        {
            foreach (String answer in answers)
            {
                if (answer != null)
                {
                    this.answers.Remove(answer);
                }
            }
        }

        public override string ToString()
        {
            return "Question={ id={" + id + "}, title={" + title + "}, categories={" + 
                String.Join(",", categories) + "}, answers={" + String.Join(",", answers) + "} }";
        }

    }
}
