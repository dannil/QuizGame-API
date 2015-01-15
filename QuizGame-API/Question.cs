using System;
using System.Collections.Generic;

namespace QuizGame.API
{
    /// <summary>
    /// Class which holds values dedicated to a question in the quiz game. This class can be
    /// utilized two ways:
    /// 
    ///     1. Use the constructor Question(Title, Categories, Answers, Correct) by adding all the
    ///        values at the moment of initialization.
    /// 
    ///     2. Use the constructor Question(Title) and add categories, answers and the correct 
    ///        answer either by using the respective properties (however, that is the equivalence of
    ///        Question(Title, Categories, Answers, Correct), only assigning the categories, answers and 
    ///        the correct answer later on) or by using the methods AddCategories(), AddAnswers() and
    ///        the property for the correct answer.
    ///        
    /// This class doesn't allow null values and will throw exception on trying to assign a variable the
    /// value null. If you don't know what values these should be at the moment of initialization, see
    /// point 2 above.
    /// </summary>
    public class Question
    {
        private int id;
        private String title;

        private List<String> categories;
        private List<String> answers;

        private String correct;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Question()
        {
            this.categories = new List<String>();
            this.answers = new List<String>();
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="title">The title</param>
        public Question(String title) : this()
        {
            this.Title = title;
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="categories">The categories</param>
        /// <param name="answers">The answers</param>
        /// <param name="correct">The correct answer</param>
        public Question(String title, List<String> categories, List<String> answers, String correct) : this(title)
        {
            this.Categories = categories;
            this.Answers = answers;
            this.Correct = correct;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="question">The question object to deep copy</param>
        public Question(Question question)
        {
            this.id = question.ID;
            this.title = question.Title;
            this.categories = new List<String>(question.Categories);
            this.answers = new List<String>(question.Answers);
            this.correct = question.Correct;
        }

        /// <summary>
        /// Property for id. Performs a null check on the 
        /// value and throws an exception if it's null
        /// </summary>
        public int ID
        {
            get { return this.id; }
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

        /// <summary>
        /// Property for title. Performs a null check on the 
        /// value and throws an exception if it's null
        /// </summary>
        public String Title
        {
            get { return this.title; }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null is not a valid value for Title");
                }
                this.title = value;
            }
        }

        /// <summary>
        /// Property for categories. Performs a null check on the 
        /// value and throws an exception if it's null
        /// </summary>
        public List<String> Categories
        {
            get { return this.categories; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null is not valid values for categories");
                }
                this.categories = new List<String>();
                String[] temp = value.ToArray();
                this.AddCategories(temp);
            }
        }

        /// <summary>
        /// Property for answers. Performs a null check on the 
        /// value and throws an exception if it's null
        /// </summary>
        public List<String> Answers
        {
            get { return this.answers; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null is not valid values for answers");
                }
                this.answers = new List<String>();
                String[] temp = value.ToArray();
                this.AddAnswers(temp);
            }
        }

        /// <summary>
        /// Property for correct. Performs a null check on the 
        /// value and throws an exception if it's null
        /// </summary>
        public String Correct
        {
            get { return this.correct; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null is not a valid value for Correct");
                }
                this.correct = value;
            }
        }

        /// <summary>
        /// Add categories to the question
        /// </summary>
        /// <param name="categories">The categories to add</param>
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

        /// <summary>
        /// Remove categories from the question
        /// </summary>
        /// <param name="categories">The categories to remove</param>
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

        /// <summary>
        /// Add answers to the question
        /// </summary>
        /// <param name="categories">The answers to add</param>
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

        /// <summary>
        /// Remove answers from the question
        /// </summary>
        /// <param name="categories">The answers to remove</param>
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

        /// <summary>
        /// Overridden ToString() to show a string presentation of this object
        /// </summary>
        public override string ToString()
        {
            return "Question={ id={" + id + "}, title={" + title + "}, categories={" + 
                String.Join(",", categories) + "}, answers={" + String.Join(",", answers) + "}, correct={" + correct + "} }";
        }

    }
}
