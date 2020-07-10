using System;
using System.Collections.Generic;



namespace VUZ_System
{
    struct Human
    {
        public string fio;
        public int age;
        public char gender;
    }

    struct AllMarks
    {
        public string subject;
        public List<int> Marks;
    }

    class Mark
    {
        AllMarks AM;
        Admin A = new Admin();

        public Mark(){
            AM.Marks = new List<int>();
        }

        public Mark(Student _student)
        {
            foreach (string subject in A.GetAllSubjects())
            {
                AM.subject = subject;
                AM.Marks = new List<int>();
                _student.GetAllSubjects().Add(AM);
            }
        }

        public void AddMarks(Student _student, string _subject, int[] _marks)
        {
            foreach (AllMarks addMark in _student.GetAllSubjects())
            {
                if (addMark.subject == _subject)
                {
                    addMark.Marks.AddRange(_marks);
                }
                
            }
        }

        public void ShowMarks(Student _student, string _subject)
        {
            foreach(AllMarks am in _student.GetAllSubjects())
            {
                int i = 0;
                Console.Write(am.subject + ": ");
                foreach( int marks in am.Marks)
                {
                    Console.Write(marks + (am.Marks.Count == ++i ? " " : ", "));
                }
                Console.WriteLine();
            }
        }

        /*public List<AllMarks> GetAllSubjects(Student _student)
        {
            Console.WriteLine("GetAllSubjects()");
            foreach (AllMarks am in _student.GetAllMarks().allSubjects)
            {
                Console.WriteLine(am.subject);
                foreach (int marks in am.Marks)
                {
                    Console.WriteLine(marks);
                }
            }
            return _student.GetAllMarks().allSubjects;
        }*/
    }

    class StudyingStaff
    {
        public void ShowMarks(Student _student, string _subject)
        {
            _student.GetAllMarks().ShowMarks(_student, _subject);
        }
    }

    class Professor : StudyingStaff
    {
        string subject;
        Human professorData;
        Mark professorMarks;
        Admin A = new Admin();

        public Professor()
        {
            professorMarks = new Mark();
        }

        public void AddBook(string _title, string _author)
        {
            
        }

        public void AddMark(Student _student, string _subject, int[] _marks)
        {
            professorMarks.AddMarks(_student, _subject, _marks);
        }
    }

    class Student : StudyingStaff
    {
        string group;
        char formOfTraining;
        Human studentData;
        Mark allMarks;
        List<AllMarks> allSubjects;

        public Student()
        {
            allSubjects = new List<AllMarks>();
            allMarks = new Mark(this);
        }

        public Student(string _fio, int _age, char _gender, string _group, char _formOfTraining)
        {
            studentData.fio = _fio;
            studentData.age = _age;
            studentData.gender = _gender;
            group = _group;
            formOfTraining = _formOfTraining;
            allSubjects = new List<AllMarks>();
            allMarks = new Mark(this);
        }

        public void ShowMarks(string _subject)
        {

        }

        public Human GetStudentData()
        {
            return studentData;
        }

        public string GetGroup()
        {
            return group;
        }

        public char GetFormOfTraining()
        {
            return formOfTraining;
        }

        public Mark GetAllMarks()
        {
            return allMarks;
        }

        public List<AllMarks> GetAllSubjects()
        {
            return allSubjects;
        }

        /*public void SetAllMarks(AllMarks _AM, Student _student)
        {
            _student.allMarks.GetAllSubjects(_student).Add(_AM);
        }*/
    }

    class Admin
    {
        Human adminData;
        static List<string> allSubjects = new List<string>();
        static List<string> allNews = new List<string>();
        static List<Student> allStudents = new List<Student>();

        public Admin() { }

        public Admin(string _fio, int _age, char _gender)
        {
            adminData.fio = _fio;
            adminData.age = _age;
            adminData.gender = _gender;
        }

        public void AddNews(string newNews)
        {
            allNews.Add(newNews);
        }

        public void GetNews()
        {
            foreach (string news in allNews)
            {
                Console.WriteLine(news);
            }
        }

        public void AddStudent(string _fio, int _age, char _gender, string _group, char _formOfTraining)
        {
            /*Student newStudent = new Student(_fio, _age, _gender, _group, _formOfTraining);
            newStudent.GetAllMarks();*/
            allStudents.Add(new Student(_fio, _age, _gender, _group, _formOfTraining));
        }

        public void ShowStudentList()
        {
            Console.WriteLine("Имя студента   |  Возраст   |  Пол   |  Группа   |  Ф/О");

            foreach (Student student in allStudents)
            {
                Console.WriteLine(
                    student.GetStudentData().fio + "     " +
                    student.GetStudentData().age + "     " +
                    student.GetStudentData().gender + "     " +
                    student.GetGroup() + "     " +
                    student.GetFormOfTraining()
                    );
            }
        }

        public void AddSubject(string _subjectName)
        {
            allSubjects.Add(_subjectName);
        }

        public List<string> GetAllSubjects()
        {
            return allSubjects;
        }

        public List<Student> GetAllStudents()
        {
            return allStudents;
        }
    }

    class Program
    {
        static void Main()
        {
            Professor P = new Professor();
            Admin A = new Admin("Alexandr", 18, 'm');
            A.AddSubject("математика");
            A.AddSubject("ООП");
            A.AddStudent("Denis", 19, 'м', "ПИ/б-18-1-о", 'о');
            A.AddStudent("Александр", 19, 'м', "ПИ/б-18-1-о", 'о');
            

            while (true)
            {
                A.ShowStudentList();

                string specificStudent = Console.ReadLine();
                foreach (Student student in A.GetAllStudents())
                {
                    student.GetAllMarks();
                    if (specificStudent == student.GetStudentData().fio)
                    {
                        //student.GetAllMarks();
                        P.AddMark(student, "математика", new int[] { 2, 3 });
                        P.AddMark(student, "ООП", new int[] { 4, 5, 3 });
                        P.AddMark(student, "математика", new int[] { 4 });
                    }
                }

                string specificStudent2 = Console.ReadLine();
                foreach (Student student in A.GetAllStudents())
                {
                    if (specificStudent2 == student.GetStudentData().fio)
                    {
                        P.ShowMarks(student, "математика");
                    }
                }
            }
        }
    }
}
