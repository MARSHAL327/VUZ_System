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

    struct Book
    {
        public string title;
        public string author;
        public string subject;
    }

    class BaseBook
    {
        List<Book> allBooks = new List<Book>();
        Book specificBook;

        public void AddBook(string title, string author, string subject)
        {
            specificBook.title = title;
            specificBook.author = author;
            specificBook.subject = subject;
            allBooks.Add(specificBook);
        }

        public void ShowBook(string _subject)
        {
            foreach( Book B in allBooks)
            {
                if( B.subject == _subject)
                {
                    Console.WriteLine(
                        specificBook.title + "   " +
                        specificBook.author + "   " +
                        specificBook.subject
                    );
                }
            }
        }
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
                if ( am.subject == _subject)
                {
                    int i = 0;
                    Console.Write(am.subject + ": ");
                    foreach (int marks in am.Marks)
                    {
                        Console.Write(marks + (am.Marks.Count == ++i ? " " : ", "));
                    }
                    Console.WriteLine();
                }
            }
        }
    }

    class StudyingStaff
    {
        static protected BaseBook StudyingBook = new BaseBook();
        static protected List<Student> debtor = new List<Student>();
        Admin A = new Admin();

        public void ShowNews(Admin adminNews)
        {
            adminNews.GetNews();
        }

        public void ShowMarks(Student _student, string _subject)
        {
            _student.GetAllMarks().ShowMarks(_student, _subject);
        }

        public void ShowBook(string _subject)
        {
            StudyingBook.ShowBook(_subject);
        }

        public void ShowDebtors()
        {
            A.ShowStudentList(debtor);
        }
    }

    class Professor : StudyingStaff
    {
        List<string> professorSubjects = new List<string>();
        Human professorData;
        Mark professorMarks;

        public Professor(string _fio, int _age, char _gender, string _subject)
        {
            professorData.fio = _fio;
            professorData.age = _age;
            professorData.gender = _gender;
            professorSubjects.Add(_subject);
            professorMarks = new Mark();
        }

        public void AddBook(string _title, string _author, string _subject)
        {
            StudyingBook.AddBook(_title, _author, _subject);
        }

        public void AddMark(Student _student, string _subject, int[] _marks)
        {
            for (int i = 0; i < _marks.Length; i++)
            {
                if( _marks[i] < 3)
                {
                    debtor.Add(_student);
                }
            }
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

        public new void ShowDebtors()
        {
            foreach( Student studentDebtor in debtor)
            {
                if( this.studentData.fio == studentDebtor.studentData.fio)
                {
                    foreach( AllMarks AM in allSubjects)
                    {
                        string debtorSubject = "";
                        foreach ( int mark in AM.Marks)
                        {
                            if (mark < 3)
                            {
                                debtorSubject = AM.subject;
                            }
                        }

                        if (debtorSubject != "") {
                            int i = 0;
                            Console.WriteLine(debtorSubject + ": ");
                            foreach (int mark in AM.Marks)
                            {
                                Console.Write(mark + (AM.Marks.Count == ++i ? " " : ", "));
                            }
                        } else Console.WriteLine("Долгов нет");
                        
                    }
                }
            }
        }

        public void ShowMarks(string _subject)
        {
            allMarks.ShowMarks(this, _subject);
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
            allStudents.Add(new Student(_fio, _age, _gender, _group, _formOfTraining));
        }

        public void ShowStudentList(List<Student> studentList)
        {
            Console.WriteLine("Имя студента   |  Возраст   |  Пол   |  Группа   |  Ф/О");

            foreach (Student student in studentList)
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
            Professor P = new Professor("Забаштанский", 33, 'м', "ООП");
            Admin A = new Admin("Alexandr", 18, 'm');
            List<Student> AllStudents = A.GetAllStudents();

            A.AddSubject("математика");
            A.AddSubject("ООП");
            A.AddStudent("Denis", 19, 'м', "ПИ/б-18-1-о", 'о');
            A.AddStudent("Александр", 19, 'м', "ПИ/б-18-1-о", 'о');
            P.AddBook("Первая книга", "Я", "ООП");
            P.ShowBook("ООП");
            P.ShowNews(A);


            while (true)
            {
                A.ShowStudentList(AllStudents);
                
                string specificStudent = Console.ReadLine();
                foreach (Student student in AllStudents)
                {
                    if (specificStudent == student.GetStudentData().fio)
                    {
                        P.AddMark(student, "математика", new int[] { 2, 3 });
                        P.AddMark(student, "ООП", new int[] { 4, 5, 3 });
                        P.AddMark(student, "математика", new int[] { 4 });
                    }
                }
                P.ShowDebtors();
                string specificStudent2 = Console.ReadLine();
                foreach (Student student in AllStudents)
                {
                    if (specificStudent2 == student.GetStudentData().fio)
                    {
                        P.ShowMarks(student, "ООП");
                    }
                }
            }
        }
    }
}
