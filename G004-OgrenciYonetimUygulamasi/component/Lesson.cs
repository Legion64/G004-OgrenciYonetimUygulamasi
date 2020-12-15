using System;
using System.Collections.Generic;
using System.Text;

namespace G004_OgrenciYonetimUygulamasi.component
{
    class Lesson
    {

        public string LessonName { get; set; }

        public float Note { get; set; }

        public Lesson(string lessonName, float note)
        {
            LessonName = lessonName;
            Note = note;
        }
    }
}
