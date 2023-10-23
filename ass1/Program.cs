using System;
using System.Collections.Generic;

namespace School_Management
{
    // The IPerson interface represents a common structure for both students and lecturers.
    public interface IPerson
    {
        void DisplayInfo();
    }

    internal class Person : IPerson
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Person(string id, string name, string dateOfBirth, string email, string address)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Email = email;
            Address = address;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{Id} | {Name} | {DateOfBirth} | {Email} | {Address}");
        }
    }

    internal class Student : Person
    {
        public string stdClass { get; set; }

        public Student(string id, string name, string dateOfBirth, string email, string address, string studentClass)
            : base(id, name, dateOfBirth, email, address)
        {
            stdClass = studentClass;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{Id} | {Name} | {DateOfBirth} | {Email} | {Address} | {stdClass}");
        }
    }

    internal class Lecturer : Person
    {
        public string Department { get; set; }

        public Lecturer(string id, string name, string dateOfBirth, string email, string address, string department)
            : base(id, name, dateOfBirth, email, address)
        {
            Department = department;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{Id} | {Name} | {DateOfBirth} | {Email} | {Address} | {Department}");
        }
    }

    internal class StudentManager
    {
        private List<IPerson> students;

        public StudentManager(List<IPerson> students)
        {
            this.students = students;
        }

        public void ManageStudents()
        {
            while (true)
            {
                Console.WriteLine("===========================================================");
                Console.WriteLine("Student Management Menu:");
                Console.WriteLine("1. Add new student");
                Console.WriteLine("2. View all students");
                Console.WriteLine("3. Search students");
                Console.WriteLine("4. Delete student");
                Console.WriteLine("5. Update student");
                Console.WriteLine("6. Back to main menu");
                Console.WriteLine("===========================================================");
                Console.WriteLine("Please choose:");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddStudent();
                            break;
                        case 2:
                            DisplayStudents();
                            break;
                        // Implement other student management methods
                        case 6:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        public void AddStudent()
        {
            try
            {
                Console.WriteLine("Enter student ID: ");
                string Id = Console.ReadLine();
                Console.WriteLine("Enter student name: ");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter student date of birth: ");
                string DateOfBirth = Console.ReadLine();
                Console.WriteLine("Enter student email: ");
                string Email = Console.ReadLine();
                Console.WriteLine("Enter student address: ");
                string Address = Console.ReadLine();
                Console.WriteLine("Enter student class: ");
                string stdClass = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(Id) || string.IsNullOrWhiteSpace(Name))
                {
                    Console.WriteLine("Invalid input. Student not added.");
                    return;
                }

                Student student = new Student(Id, Name, DateOfBirth, Email, Address, stdClass);
                students.Add(student);
                Console.WriteLine("Student added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void DisplayStudents()
        {
            Console.WriteLine("List of Students:");
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
            }
            else
            {
                foreach (var student in students)
                {
                    student.DisplayInfo();
                }
            }
        }
    }

    internal class Program
    {
        static List<IPerson> students = new List<IPerson>();
        static List<IPerson> lecturers = new List<IPerson>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("===========================================================");
                Console.WriteLine("1. Manage Students");
                Console.WriteLine("2. Manage Lecturers");
                Console.WriteLine("3. Exit");
                Console.WriteLine("===========================================================");
                Console.WriteLine("Please choose:");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            StudentManager studentManager = new StudentManager(students);
                            studentManager.ManageStudents();
                            break;
                        case 2:
                            // Implement LecturerManager and manage lecturers here
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        // Implement the LecturerManager class and methods for managing lecturers

        // Additional comments and explanations here.
    }
}
