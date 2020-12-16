using G004_OgrenciYonetimUygulamasi.component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            Students.Add(new Student(1, "Melih", "Budak", RandomDay(), Gender.E, "A"));
            Students.Add(new Student(2, "Akın Can", "Cesaretli", RandomDay(), Gender.E, "A"));
            Students.Add(new Student(3, "Ozan", "Akyüz", RandomDay(), Gender.E, "A"));
            Students.Add(new Student(4, "Muhammed Taha", "Özdoğan", RandomDay(), Gender.E, "A"));
        }

        DateTime RandomDay()
        {
            DateTime start = new DateTime(1980, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(Rand.Next(range));
        }

        // Bu sınıf verinin işleneceği sınıf

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
            int index = Students.FindIndex(x => x.ID == id);

            return Students[index];
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
        public bool HasStudent(int id)
        {
            Student student = Students.Where(x => x.ID == id).FirstOrDefault();

            if (student != null)
                return true;
            return false;
        }



    }
}
