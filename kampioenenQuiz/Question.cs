using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kampioenenQuiz {
    class Question {
        public string text { get; set; }
        public string answer { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }

        public Question(string text, string answer, string option1, string option2) {
            this.text = text;
            this.answer = answer;
            this.option1 = option1;
            this.option2 = option2;
        }

        public bool IsCorrectAnswer(string guess) {
            if(this.answer == guess) {
                return true;
            }
            
            return false;
        }
    }
}
