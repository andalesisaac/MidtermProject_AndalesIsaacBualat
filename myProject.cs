using System;
class Program
{
    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== STUDENT SYSTEM =====");
            Console.WriteLine("1. Register Student");
            Console.WriteLine("2. Enroll Student Subjects");
            Console.WriteLine("3. Enter Grades");
            Console.WriteLine("4. Show Grades");
            Console.WriteLine("5. Exit");

            Console.Write("Enter choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RegisterStudent();
                    break;

                case 2:
                    EnrollSubjects();
                    break;

                case 3:
                    EnterGrades();
                    break;

                case 4:
                    ShowGrades();
                    break;
            }

        } while (choice != 5);
    }

        static void RegisterStudent()
    {
        Console.Write("First Name: ");
        string fname = Console.ReadLine();

        Console.Write("Middle Initial: ");
        string mi = Console.ReadLine();

        Console.Write("Last Name: ");
        string lname = Console.ReadLine();

        Console.Write("Birthdate: ");
        string birth = Console.ReadLine();

        Console.Write("Age: ");
        string age = Console.ReadLine();

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("Contact Number: ");
        string contact = Console.ReadLine();

        Console.Write("Course: ");
        string course = Console.ReadLine();

        Console.Write("Year: ");
        string year = Console.ReadLine();

        // string student = $"{lname},{fname},{mi},{birth},{age},{address},{contact},{course},{year}";
       
        string student = "{\n" +
                 "  \"Student\": [\n" +
                 "    {\n" +
                 $"      \"lname\": \"{lname}\",\n" +
                 $"      \"fname\": \"{fname}\",\n" +
                 $"      \"mi\": \"{mi}\",\n" +
                 $"      \"birthdate\": \"{birth}\",\n" +
                 $"      \"age\": {age},\n" +
                 $"      \"address\": \"{address}\",\n" +
                 $"      \"number\": \"{contact}\",\n" +
                 $"      \"subject\": \"{course}\",\n" +
                 $"      \"year\": {year}\n" +
                 "    }\n" +
                 "  ]\n" +
                 "}";

        File.AppendAllText("data.txt", student + Environment.NewLine);

        Console.WriteLine("Student Registered Successfully!");
    }

        static void EnrollSubjects()
    {
        Console.Write("Enter Student Last Name: ");
        string lname = Console.ReadLine();

        if (!File.ReadAllText("students.txt").Contains(lname))
        {
            Console.WriteLine("Student not registered!");
            return;
        }

        Console.Write("Subject Name: ");
        string subName = Console.ReadLine();

        Console.Write("Subject ID: ");
        string subID = Console.ReadLine();

        // string subject = $"{lname},{subName},{subID}";
       
        string subject = "{\n" +
         "  \"Subjects\": [\n" +
         "    {\n" +
         $"      \"lname\": \"{lname}\",\n" +
         $"      \"subject\": \"{subName}\",\n" +
         $"      \"subjectName\": \"{subID}\"\n" +
         "    }\n" +
         "  ]\n" +
         "}";

        File.AppendAllText("data.txt", subject + Environment.NewLine);

        Console.WriteLine("Subject Enrolled!");
    }

        static void EnterGrades()
    {
        Console.Write("Student Last Name: ");
        string lname = Console.ReadLine();

        Console.Write("Subject Name: ");
        string subject = Console.ReadLine();

        Console.Write("Grade: ");
        string grade = Console.ReadLine();

        // string record = $"{lname},{subject},{grade}";
        string record = "{\n" +
         "  \"Grades\": [\n" +
         "    {\n" +
         $"      \"lname\": \"{lname}\",\n" +
         $"      \"subject\": \"{subject}\",\n" +
         $"      \"grade\": \"{grade}\"\n" +
         "    }\n" +
         "  ]\n" +
         "}";

        File.AppendAllText("data.txt", record + Environment.NewLine);

        Console.WriteLine("Grade Saved!");
    }

    static void ShowGrades()
    {
        Console.Write("Enter Student Last Name: ");
        string lname = Console.ReadLine();

        string[] students = File.ReadAllLines("students.txt");

        foreach (string student in students)
        {
            string[] data = student.Split(',');

            if (data[0] == lname)
            {
                Console.WriteLine("\n" + data[0] + ", " + data[1]); // Lastname, Firstname
                Console.WriteLine(data[7] + " - " + data[8]); // Course - Year
                Console.WriteLine();
            }
        }

        string[] grades = File.ReadAllLines("grades.txt");

        foreach (string grade in grades)
        {
            string[] g = grade.Split(',');

            if (g[0] == lname)
            {
                Console.WriteLine(g[1] + " ----- " + g[2]);
            }
        }
    }
}
