using System;
using System.Collections.Generic;

struct Human
{
    public string fio;
    public int age;
    public char gender;
}

struct AllMarks
{
    string subject;
    List<int> Marks;
}

class Mark
{
    List<AllMarks> allSubjects = new List<AllMarks>();

    public void AddMarks(Student _student, int [] _marks)
    {

    }

    public void ShowMarks(Student _student, string _subject)
    {

    }
}

class StudyingStaff
{

}

class Professor : StudyingStaff
{
    string subject;
    Human professorData;

    public void AddBook(string _title, string _author)
    {

    }

    public void AddMark(Student _student, int [] _marks)
    {

    }
}

class Student : StudyingStaff
{
    string group;
    char formOfTraining;
    Human studentData;
    Mark allMarks;

    public Student(string _fio, int _age, char _gender)
    {
        studentData.fio = _fio;
        studentData.age = _age;
        studentData.gender = _gender;
    }

    public void ShowMarks(string _subject)
    {

    }

    public Human GetStudentData()
    {
        return studentData;
    }
}

class Admin : StudyingStaff
{
    Human adminData;
    List<string> allNews = new List<string>();
    List<Student> allStudents = new List<Student>();

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

    public void ShowStudentList()
    {
        Console.WriteLine("Имя студента   |  возраст   |  пол");

        foreach (Student student in allStudents)
        {
            Console.WriteLine(
                student.GetStudentData().fio + "     " + 
                student.GetStudentData().age + "     " +
                student.GetStudentData().gender
                );
        }
    }

    public void AddStudent(string _fio, int _age, char _gender)
    {
        Student newStudent = new Student(_fio, _age, _gender);
        allStudents.Add(newStudent);
    }

    public void GetNews()
    {
        foreach (string news in allNews)
        {
            Console.WriteLine(news);
        }
    }
}

namespace VUZ_System
{
    class Program
    {
        static void Main()
        {
            
            Admin A = new Admin("Alexandr", 18, 'm');
            A.AddStudent("Denis", 19, 'm');
            A.ShowStudentList();
        }
    }
}
