using System;
using System.Collections.Generic;
using System.Text;

namespace G004_OgrenciYonetimUygulamasi.component
{
    class Lesson
    {

        public LessonName _Lesson { get; set; }

        public float Note { get; set; }

        public Lesson(LessonName lessonName, float note)
        {
            _Lesson = lessonName;
            Note = note;
        }

    }

    public enum LessonName
    {
        Undefined,
        Biyoloji,
        Coğrafya,
        Felsefe,
        Fizik,
        Kimya,
        Matematik,
        Tarih,
        Türkçe
    }
}
