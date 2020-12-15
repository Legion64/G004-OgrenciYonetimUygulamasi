using System;
using System.Collections.Generic;
using System.Text;

namespace G004_OgrenciYonetimUygulamasi.component
{
    class Student
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public string ClassName { get; set; }


        public List<Lesson> Lessons { get; set; }

        public Address Address { get; set; }

        public List<string> Reviews { get; set; }

        public List<string> Books { get; set; }

        public Student()
        {
            Lessons = new List<Lesson>();
            Reviews = new List<string>();
            Books = new List<string>();
        }

        public Student(int id, string name, string surname, DateTime birthDate, Gender gender, string className)
        {
            ID = id;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Gender = gender;
            ClassName = className;

            Lessons = new List<Lesson>();
            Reviews = new List<string>();
            Books = new List<string>();
        }


    }

    public enum Gender
    {
        E,
        K
    }

}
