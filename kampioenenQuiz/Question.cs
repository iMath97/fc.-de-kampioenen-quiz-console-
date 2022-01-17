using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kampioenenQuiz {
    class Question {
        public string Text { get; set; }
        public string Answer { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }

        public Question(string text, string answer, string option1, string option2) {
            Text = text;
            Answer = answer;
            Option1 = option1;
            Option2 = option2;
        }

        public bool IsCorrectAnswer(string guess) {
            if(Answer == guess) {
                return true;
            }
            
            return false;
        }
    }
}
