using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizGameAPI
{
    public class CategoryHolder
    {
        private String category;

        public CategoryHolder()
        {

        }

        public CategoryHolder(String category)
        {
            this.category = category;
        }

        public String Category
        {
            get { return category; }
            set { category = value; }
        }

        public override string ToString()
        {
            return "category=" + category;
        }

    }
}
