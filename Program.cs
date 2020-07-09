using System;
using System.Collections.Generic;

struct Human
{
    public string fio;
    public int age;
    public char gender;
}

class Mark
{

}

class StudyingStaff
{

}

class Student : StudyingStaff
{
    string group;
    char formOfTraining;
    Human studentData;
    Mark allMarks;

    public void ShowMarks(string _subject)
    {

    }
}

class Admin : StudyingStaff
{
    Human adminData;
    List<string> allNews = new List<string>();

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

namespace VUZ_System
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
