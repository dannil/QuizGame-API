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
            return "id={" + id + "};title={" + title + "};categories={" + String.Join(",", categories) + "};answers={" + String.Join(",", answers) + "};";
        }

        public override bool Equals(object obj)
        {
            Question compare = (Question)obj;
            if (!ID.Equals(compare.ID))
            {
                return false;
            }
            else if (!Title.Equals(compare.Title))
            {
                return false;
            }
            else
            {
                if (this.categories.Count != compare.categories.Count)
                {
                    return false;
                }
                for (int i = 0; i < this.categories.Count; i++)
			    {
                    if (!this.categories[i].Category.Equals(compare.categories[i].Category))
                    {
                        return false;
                    }
                }

                if (this.answers.Count != compare.answers.Count)
                {
                    return false;
                }
                for (int i = 0; i < this.answers.Count; i++)
                {
                    if (!this.answers[i].Answer.Equals(compare.answers[i].Answer))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
