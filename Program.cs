using System;
using System.Collections.Generic;

struct Human
{
    public string fio;
    public int age;
    public char gender;
}

class Student
{

}

class Professor
{
    string subject;
    Human professorData;

    public void AddBook(string _title, string _author)
    {

    }

    public void AddMark(Student _student, int [] marks)
    {

    }
}

class Admin
{
    Human H;
    List<string> allNews = new List<string>();
    List<Student> allStudents;

    public Admin(string _fio, int _age, char _gender)
    {
        H.fio = _fio;
        H.age = _age;
        H.gender = _gender;
    }

    public void AddNews(string newNews)
    {
        allNews.Add(newNews);
    }

    public void ShowStudentList(Student students)
    {

    }

    public void AddStudent(string _fio, int _age, char _gender)
    {

    }

    public void GetNews()
    {
        foreach (string news in allNews)
        {
            Console.WriteLine(news);
        }
    }
}

namespace VUZ_System_copy
{
    class Program
    {
        static void Main()
        {
            Admin A = new Admin("Alexandr", 18, 'm');
            A.AddNews("myNews");
            A.AddNews("newNews");
            A.AddNews("hello");
            A.GetNews();
        }
    }
}
