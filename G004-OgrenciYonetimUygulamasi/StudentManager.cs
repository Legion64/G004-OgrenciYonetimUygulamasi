using G004_OgrenciYonetimUygulamasi.component;
using System;
using System.Collections.Generic;
using System.Linq;

namespace G004_OgrenciYonetimUygulamasi
{
    class StudentManager
    {
        public List<Student> Students { get; set; }

        private Random Rand = new Random();

        public StudentManager()
        {
            Students = new List<Student>();
            FakeData();
        }

        public void FakeData()
        {
            Random rnd = new Random();

            Student ogr1 = new Student(1, "Melih", "Budak", RandomDay(), Gender.E, "A");
            Lesson lesson1 = new Lesson(LessonName.Matematik, rnd.Next(0, 100));
            Lesson lesson2 = new Lesson(LessonName.Fizik, rnd.Next(0, 100));
            Lesson lesson3 = new Lesson(LessonName.Biyoloji, rnd.Next(0, 100));
            Lesson lesson4 = new Lesson(LessonName.Kimya, rnd.Next(0, 100));
            ogr1.Lessons.Add(lesson1);
            ogr1.Lessons.Add(lesson2);
            ogr1.Lessons.Add(lesson3);
            ogr1.Lessons.Add(lesson4);
            Students.Add(ogr1);

            Student ogr2 = new Student(2, "Akın Can", "Cesaretli", RandomDay(), Gender.E, "A");
            Lesson lesson5 = new Lesson(LessonName.Matematik, rnd.Next(0, 100));
            Lesson lesson6 = new Lesson(LessonName.Fizik, rnd.Next(0, 100));
            Lesson lesson7 = new Lesson(LessonName.Biyoloji, rnd.Next(0, 100));
            Lesson lesson8 = new Lesson(LessonName.Kimya, rnd.Next(0, 100));
            ogr2.Lessons.Add(lesson5);
            ogr2.Lessons.Add(lesson6);
            ogr2.Lessons.Add(lesson7);
            ogr2.Lessons.Add(lesson8);
            Students.Add(ogr2);

            Student ogr3 = new Student(3, "Ozan", "Akyüz", RandomDay(), Gender.E, "B");
            Lesson lesson9 = new Lesson(LessonName.Matematik, rnd.Next(0, 100));
            Lesson lesson10 = new Lesson(LessonName.Fizik, rnd.Next(0, 100));
            Lesson lesson11 = new Lesson(LessonName.Biyoloji, rnd.Next(0, 100));
            Lesson lesson12 = new Lesson(LessonName.Kimya, rnd.Next(0, 100));
            ogr3.Lessons.Add(lesson9);
            ogr3.Lessons.Add(lesson10);
            ogr3.Lessons.Add(lesson11);
            ogr3.Lessons.Add(lesson12);
            Students.Add(ogr3);

            Student ogr4 = new Student(4, "Muhammed Taha", "Özdoğan", RandomDay(), Gender.E, "B");
            Lesson lesson13 = new Lesson(LessonName.Matematik, rnd.Next(0, 100));
            Lesson lesson14 = new Lesson(LessonName.Fizik, rnd.Next(0, 100));
            Lesson lesson15 = new Lesson(LessonName.Biyoloji, rnd.Next(0, 100));
            Lesson lesson16 = new Lesson(LessonName.Kimya, rnd.Next(0, 100));
            ogr4.Lessons.Add(lesson13);
            ogr4.Lessons.Add(lesson14);
            ogr4.Lessons.Add(lesson15);
            ogr4.Lessons.Add(lesson16);
            Students.Add(ogr4);
        }

        DateTime RandomDay()
        {
            DateTime start = new DateTime(1980, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(Rand.Next(range));
        }

        public void AddNote(int id, LessonName lessonName, int[] notes)
        {
            Student student = GetStudent(id);

            if (student != null)
            {
                foreach (var item in notes)
                {
                    Lesson lesson = new Lesson(lessonName, item);

                    student.Lessons.Add(lesson);
                }
            }
        }

        public void AddAddress(int id, Address address)
        {
            Student student = GetStudent(id);

            if (student != null)
            {
                student.Address = address;
            }
        }


        public Student GetStudent(int id)
        {
            return Students.Where(x => x.ID == id).FirstOrDefault();
        }

        public List<string> GetEvalaution(int id)
        {
            Student student = GetStudent(id);
            return student.Reviews;
        }

        public void AddEvalaution(int id, string text)
        {
            Student student = GetStudent(id);
            student.Reviews.Add(text);
        }

        public void AddBooks(int id, string book)
        {
            Student student = GetStudent(id);
            student.Books.Add(book);

        }

        public List<Lesson> GetStudentNote(int id)
        {
            return GetStudent(id).Lessons.OrderBy(x => x._Lesson).ToList();
        }

        public float? GetGAInClass(string className)
        {
            IEnumerable<Student> notes = Students.Where(x => x.ClassName == className.ToUpper());
            if (notes.Count() > 0)
            {
                return notes.Average(x => x.GA);
            }

            return null;
        }

        public List<Student> GetMostSuccessful()
        {
            return Students.OrderByDescending(x => x.GA).Take(5).ToList();
        }

        public List<Student> GetMostFailure()
        {
            return Students.OrderBy(x => x.GA).Take(3).ToList();
        }

        public List<Student> GetMostSuccessfulInClass(string className)
        {
            return Students.Where(x => x.ClassName == className.ToUpper()).OrderByDescending(x => x.GA).Take(5).ToList();
        }

        public List<Student> GetMostFailureInClass(string className)
        {
            return Students.Where(x => x.ClassName == className.ToUpper()).OrderBy(x => x.GA).Take(3).ToList();
        }
        
        public List<Student> StudentsByClass(string className)
        {
            return Students.Where(x => x.ClassName == className.ToUpper()).ToList();
        }
        
        public List<Student> StudentsByGender(Gender gender)
        {
            return Students.Where(x => x.Gender == gender).OrderBy(x => x.Gender).ToList();
        }
        
        public List<Student> BirthDateListing(DateTime date)
        {
            return Students.Where(x => x.BirthDate > date).OrderBy(x => x.BirthDate).ToList();
        } 


        public List<Student> GetNeighborhood()
        {
            return Students.OrderBy(x => x.Address.Neighborhood).ToList();
        }

        public string GetLastBook(int id)
        {
            Student student = GetStudent(id);
            return student.Books.Last();
        }
        public bool HasStudent(int id)
        {
            Student student = Students.Where(x => x.ID == id).FirstOrDefault();

            if (student != null)
                return true;
            return false;
        }



        public Student AddStudent(string name, string surname, DateTime birthDate, Gender gender, int Id, string className)
        {
            Student student = new Student();

            student.Name = name;
            student.Surname = surname;
            student.BirthDate = birthDate;
            student.Gender = gender;
            student.ID = Id;
            student.ClassName = className;

            Students.Add(student);

            return (student);
        }


        public Student UpdateStudent(Student x,string name, string surname, DateTime birthDate, Gender gender, string className)
        {

            if (name != "")
            {
                x.Name = name;
            }
            if (surname != "")
            {
                x.Surname = surname;
            }
            if (birthDate != null)
            {
                x.BirthDate = birthDate;
            }
            if (gender != Gender.Undefined)
            {
                x.Gender = gender;
            }
            if (className != "")
            {
                x.ClassName = className;

            }



            return x;
        }
       
    }
}
