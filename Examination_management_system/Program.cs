namespace Examination_management_system
{
    internal class Program
    {

        //  CLASS Question 
        class Question
        {
            public string Text { get; set; }
            public string Type { get; set; }
            public string Level { get; set; }
            public double Mark { get; set; }
            public string CorrectAnswer { get; set; }
            public string[] Options { get; set; }

            public void DisplayQuestion()
            {
                Console.WriteLine("Question: " + Text);
                if (Type == "TrueFalse")
                {
                    Console.WriteLine("Answer with True or False");
                }
                else if (Type == "ChooseOne" || Type == "Multiple")
                {
                    for (int i = 0; i < Options.Length; i++)
                    {
                        Console.WriteLine((i + 1) + ") " + Options[i]);
                    }
                }
            }
        }

        //  CLASS Exam 
        class Exam
        {
            public string ExamType { get; set; }
            public Question[] Questions { get; set; }
            public double TotalMarks { get; set; }
            public double StudentMarks { get; set; }

            public void TakeExam()
            {
                Console.WriteLine("\n=== Starting " + ExamType + " Exam ===");

                for (int i = 0; i < Questions.Length; i++)
                {
                    Console.WriteLine("\n----------------------");
                    Console.WriteLine("Q" + (i + 1) + ": ");
                    Questions[i].DisplayQuestion();

                    Console.Write("Your answer: ");
                    string answer = Console.ReadLine();

                    if (answer.ToLower() == Questions[i].CorrectAnswer.ToLower())
                    {
                        Console.WriteLine(" Correct ");
                        StudentMarks += Questions[i].Mark;
                    }
                    else
                    {
                        Console.WriteLine(" Wrong! Correct answer is: " + Questions[i].CorrectAnswer);
                    }

                    TotalMarks += Questions[i].Mark;
                }

                Console.WriteLine("\n=== Exam Finished ===");
                Console.WriteLine("Your grade: " + StudentMarks + " / " + TotalMarks);
            }
        }

        //  CLASS Doctor 
        class Doctor
        {
            public string Name { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }

            public bool Login()
            {
                Console.Write("Enter Doctor Username: ");
                string user = Console.ReadLine();

                Console.Write("Enter Password: ");
                string pass = Console.ReadLine();

                if (user == Username && pass == Password)
                {
                    Console.WriteLine(" Doctor Login Successful!");
                    return true;
                }
                else
                {
                    Console.WriteLine(" Invalid Doctor Login.");
                    return false;
                }
            }

            public Question[] CreateQuestions()
            {
                Console.Write("Enter number of questions: ");
                int n = int.Parse(Console.ReadLine());
                Question[] qArr = new Question[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("\n--- Enter data for Question " + (i + 1) + " ---");
                    qArr[i] = new Question();

                    Console.Write("Enter question type (TrueFalse / ChooseOne / Multiple): ");
                    qArr[i].Type = Console.ReadLine();

                    Console.Write("Enter difficulty (Easy / Hard): ");
                    qArr[i].Level = Console.ReadLine();

                    Console.Write("Enter question text: ");
                    qArr[i].Text = Console.ReadLine();

                    Console.Write("Enter mark for this question: ");
                    qArr[i].Mark = double.Parse(Console.ReadLine());

                    if (qArr[i].Type == "TrueFalse")
                    {
                        Console.Write("Enter correct answer (True / False): ");
                        qArr[i].CorrectAnswer = Console.ReadLine();
                    }
                    else if (qArr[i].Type == "ChooseOne" || qArr[i].Type == "Multiple")
                    {
                        Console.Write("How many options? ");
                        int optCount = int.Parse(Console.ReadLine());
                        string[] opts = new string[optCount];
                        for (int j = 0; j < optCount; j++)
                        {
                            Console.Write("Enter option " + (j + 1) + ": ");
                            opts[j] = Console.ReadLine();
                        }
                        qArr[i].Options = opts;

                        Console.Write("Enter correct answer (write exact text): ");
                        qArr[i].CorrectAnswer = Console.ReadLine();
                    }
                }

                Console.WriteLine("\n All questions saved successfully!");
                return qArr;
            }
        }

        //  CLASS Student 
        class Student
        {
            public string Name { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }

            public bool Login()
            {
                Console.Write("Enter Student Username: ");
                string user = Console.ReadLine();

                Console.Write("Enter Password: ");
                string pass = Console.ReadLine();

                if (user == Username && pass == Password)
                {
                    Console.WriteLine(" Student Login Successful!");
                    return true;
                }
                else
                {
                    Console.WriteLine(" Invalid Student Login.");
                    return false;
                }
            }

            public void StartExam(Question[] questions)
            {
                
               

                Exam ex = new Exam();
               
                ex.Questions = questions;
                ex.TakeExam();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=== Examination Management System (Doctor & Student) ===");

            Question[] questionBank = null;

            while (true)
            {
                Console.Write("\nAre you (1) Doctor or (2) Student? ");
                string mode = Console.ReadLine();

                if (mode == "1")
                {
                    Doctor d = new Doctor();
                    d.Username = "doctor1";
                    d.Password = "12345";
                    d.Name = "Dr. Ahmed";

                    if (d.Login())
                    {
                        questionBank = d.CreateQuestions();
                    }
                }
                else if (mode == "2")
                {
                    if (questionBank == null)
                    {
                        Console.WriteLine(" No questions available. Please let a doctor add questions first.");
                    }
                    else
                    {
                        Student s = new Student();
                        s.Username = "student1";
                        s.Password = "123";
                        s.Name = "Ali";

                        if (s.Login())
                        {
                            s.StartExam(questionBank);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again.");
                }

                Console.WriteLine("\n-----------------------------------");

            }
        }
    }
}
