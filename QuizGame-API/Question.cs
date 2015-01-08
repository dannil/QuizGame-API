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
            this.Title = title;
        }

        public Question(String title, List<String> categories, List<String> answers, String correct) : this(title)
        {
            this.Categories = categories;
            this.Answers = answers;
            this.Correct = correct;
        }

        public int ID
        {
            get { return id; }
            set 
            {
                if (value >= 0)
                {
                    id = value;
                }
                else
                {
                    id = 0;
                }
            }
        }

        public String Title
        {
            get { return title; }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null is not a valid value for Title");
                }
                title = value;
            }
        }

        public List<String> Categories
        {
            get { return categories; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null is not valid values for categories");
                }
                categories = value;
            }
        }

        public List<String> Answers
        {
            get { return answers; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null is not valid values for answers");
                }
                answers = value;
            }
        }

        public String Correct
        {
            get { return correct; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null is not a valid value for Correct");
                }
                correct = value;
            }
        }

        public void AddCategories(params String[] categories)
        {
            if (categories == null)
            {
                throw new ArgumentNullException("Null is not valid values for categories");
            }
            foreach (String category in categories)
            {
                if (category == null)
                {
                    throw new ArgumentNullException("Null is not a valid value for a category");
                }
                if (!this.categories.Contains(category))
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
            if (answers == null)
            {
                throw new ArgumentNullException("Null is not valid values for answers");
            }
            foreach (String answer in answers)
            {
                if (answer == null)
                {
                    throw new ArgumentNullException("Null is not a valid value for an answer");
                }
                if (!this.answers.Contains(answer))
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
