using System;

namespace kampioenenQuiz {
    class Program {
        static void Main(string[] args) {
            Score score = new Score();
            Question[] questions = new Question[5];
            int[] askedQuestionsIndexlist = new int[questions.Length];
            for (int i = 0; i < askedQuestionsIndexlist.Length; i++) {
                askedQuestionsIndexlist[i] = -1;
            }

            GenerateQuestions(questions);

            Console.WriteLine("Welkom in de Kampioenenquiz, op elke vraag is 1 antwoord. Bij een juist antwoord krijg je een punt bij een fout niet. Na afloop krijg je je punten te zien en welke vragen je fout had.");
            Console.WriteLine();

            int amountQuestions = 5;

            for (int i = 0; i < amountQuestions; i++) {
                AskQuestion(questions, score, i, askedQuestionsIndexlist);
            }

            Console.WriteLine($"You scored {score.value}/{amountQuestions}.");
        }

        static void GenerateQuestions(Question[] questions) {
            Question question1 = new Question("In de allereerste aflevering \"nieuwe truitjes\" kon de match niet doorgaan tegen de Spuiters, waarom niet?", "Krater in het veld door een gasexplosie", "Xavier was te zat", "Pico heeft de match afgebeld");
            Question question2 = new Question("Hoe heet het PLAN-INTERNATIONAL kind van Pol?", "Marie-José", "Marie-Jo", "Marie-Jeanne");
            Question question3 = new Question("Hoeveel echte trainers voor meer dan 1 dag heeft de ploeg al gehad?", "7", "5", "6");
            Question question4 = new Question("Wat is het beroep van Doortje haar aanbidder Nicolas?", "Vastgoedmakelaar", "Verzekeringsagent", "Kunstschatter");
            Question question5 = new Question("Boma en Pico doen mee aan de gemeenteraadsverkiezingen, voor welke partij komt Boma op?", "Gemeentebelangen", "PVDA", "Stadspartij");

            questions[0] = question1;
            questions[1] = question2;
            questions[2] = question3;
            questions[3] = question4;
            questions[4] = question5;
        }

        static void AskQuestion(Question[] questions, Score score, int questionCount, int[] askedQuestionsIndexlist) {
            Random r = new Random();

            int questionPosition;

            do {
                questionPosition = r.Next(questions.Length);
            } while (Array.IndexOf(askedQuestionsIndexlist, questionPosition) != -1);

            askedQuestionsIndexlist[questionCount] = questionPosition;

            Console.WriteLine(questions[questionPosition].text);
            Console.WriteLine();
            Console.WriteLine("Possible answers (choose with the number in front)");

            int order = r.Next(3);

            string[] questionOrder = new string[3];

            switch (order) {
                case 0:
                    Console.WriteLine("1: " + questions[questionPosition].answer);
                    Console.WriteLine("2: " + questions[questionPosition].option1);
                    Console.WriteLine("3: " + questions[questionPosition].option2);

                    questionOrder[0] = questions[questionPosition].answer;
                    questionOrder[1] = questions[questionPosition].option1;
                    questionOrder[2] = questions[questionPosition].option2;
                    break;
                case 1:
                    Console.WriteLine("1: " + questions[questionPosition].option2);
                    Console.WriteLine("2: " + questions[questionPosition].answer);
                    Console.WriteLine("3: " + questions[questionPosition].option1);

                    questionOrder[0] = questions[questionPosition].option2;
                    questionOrder[1] = questions[questionPosition].answer;
                    questionOrder[2] = questions[questionPosition].option1;
                    break;
                case 2:
                    Console.WriteLine("1: " + questions[questionPosition].option1);
                    Console.WriteLine("2: " + questions[questionPosition].option2);
                    Console.WriteLine("3: " + questions[questionPosition].answer);

                    questionOrder[0] = questions[questionPosition].option1;
                    questionOrder[1] = questions[questionPosition].option2;
                    questionOrder[2] = questions[questionPosition].answer;
                    break;
            }
            Console.WriteLine();
            AskInput(questionOrder, questions[questionPosition], score);

            Console.WriteLine();
            Console.WriteLine();
        }

        static void AskInput(string[] questionsOrder, Question question, Score score) {
            int index;
            bool AnswerIsCorrect = false;

            do {
                Console.Write("Answer: ");
                AnswerIsCorrect = int.TryParse(Console.ReadLine(), out index);

                if(index > 3) {
                    AnswerIsCorrect = false;
                }
            } while (!AnswerIsCorrect);

            string guess = questionsOrder[index - 1];

            checkAnswer(guess, question, score);
        }

        static void checkAnswer(string guess, Question question, Score score) {
            bool correct = question.IsCorrectAnswer(guess);

            if (correct) {
                Console.WriteLine("Correct!");

                score.value++;
            } else {
                Console.WriteLine($"Sorry, the correct answer was: {question.answer}");
            }
        }
    }
}
