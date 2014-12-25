using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGameAPI
{
    public class AnswerHolder
    {
        private String answer;

        public AnswerHolder()
        {

        }

        public AnswerHolder(String answer)
        {
            this.answer = answer;
        }

        public String Answer
        {
            get { return answer; }
            set { answer = value; }
        }
    }
}
