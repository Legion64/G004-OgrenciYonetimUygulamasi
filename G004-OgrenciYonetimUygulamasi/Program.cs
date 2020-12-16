using G004_OgrenciYonetimUygulamasi.component;
using System;

namespace G004_OgrenciYonetimUygulamasi
{
    class Program
    {
        static StudentManager SM = new StudentManager();

        static void Main(string[] args)
        {
            RunAll();
        }

        static void RunAll()
        {
            Console.Clear();
            Menu();
            MenuSelector();
        }

        static void MenuSelector()
        {
            while (true)
            {
                Console.Write("Yapmak istediğiniz işlemi seçiniz: ");
                string input = Console.ReadLine();
                bool checkInt = int.TryParse(input, out int result);
                if (checkInt)
                {
                    switch (result)
                    {
                        case 1:

                            break;
                        case 2:
                            AddStudentNote();
                            break;
                        case 3:
                            GetStudentGA();
                            break;
                        case 4:
                            AddStudentAddress();
                            break;
                        case 5:
                            AllStudents();
                            break;
                        case 6:
                            StudentsByClass();
                            break;
                        case 7:

                            break;
                        case 8:

                            break;
                        case 9:
                            StudentsByGender();
                            break;
                        case 10:
                            StudentsByBirthDate();
                            break;
                        case 11:
                            StudentsByNeighborhood();
                            break;
                        case 12:
                            MostSuccessfulInSchool();
                            break;
                        case 13:
                            MostFailureInSchool();
                            break;
                        case 14:
                            MostSuccessfulInClass();
                            break;
                        case 15:
                            MostFailureInClass();
                            break;
                        case 16:
                            AddStudentEvaluation();
                            break;
                        case 17:
                            GetStudentEvaluation();
                            break;
                        case 18:
                            AddBooks();
                            break;
                        case 19:
                            GetBooks();
                            break;
                        case 20:
                            GetLastBook();
                            break;
                        case 21:

                            break;
                        case 22:

                            break;
                        default:
                            Console.WriteLine("Herhangi bir seçim yapmadınız!");
                            break;
                    }

                    StopOrContinue();
                }
                else
                {
                    if (input.ToLower() == "çıkış")
                    {
                        ExitApp();
                    }
                    else
                    {
                        Console.WriteLine("Yanlış seçim yaptınız. Lütfen tekrar deneyin!");
                    }
                }
            }
        }

        static void StopOrContinue()
        {
            while (true)
            {
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                Console.Write("Yapmak istediğiniz işlemi seçin: ");
                string _input = Console.ReadLine();
                if (_input == "liste")
                {
                    RunAll();
                }
                else if (_input == "çıkış")
                {
                    ExitApp();
                }
                else
                {
                    Console.WriteLine("Yanlış bir değer girdiniz. Lütfen tekrar deneyin.");
                }
            }
        }

        static void Menu()
        {
            Console.WriteLine("\t\t\tÖğrenci Yönetim Paneli\n");
            Console.WriteLine("1  - Öğrenci Gir");
            Console.WriteLine("2  - Not Gir");
            Console.WriteLine("3  - Öğrencinin ortalamasını gör");
            Console.WriteLine("4  - Öğrencinin adresini gir");
            Console.WriteLine("5  - Bütün Öğrencileri Listele");
            Console.WriteLine("6  - Şubeye Göre Öğrencileri Listele");
            Console.WriteLine("7  - Öğrencinin notlarını görüntüle");
            Console.WriteLine("8  - Sınıfın not ortalamasını gör");
            Console.WriteLine("9  - Cinsiyetine göre öğrenci listele");
            Console.WriteLine("10 - Şu tarihten sonra doğan öğrencileri listele");
            Console.WriteLine("11 - Tüm öğrencileri semtlerine göre sıralayarak listele");
            Console.WriteLine("12 - Okuldaki En başarılı 5 öğrenciyi listele");
            Console.WriteLine("13 - Okuldaki En başarısız 3 öğrenciyi listele");
            Console.WriteLine("14 - Sınıftaki En başarılı 5 öğrenciyi listele");
            Console.WriteLine("15 - Sınıftaki En başarısız 3 öğrenciyi listele");
            Console.WriteLine("16 - Öğrenci için değerlendirme gir");
            Console.WriteLine("17 - Öğrencinin değerlendirmesini gör");
            Console.WriteLine("18 - Öğrencinin okuduğu kitabı gir");
            Console.WriteLine("19 - Öğrencinin okuduğu kitapları listele");
            Console.WriteLine("20 - Öğrencinin okuduğu son kitabı görüntüle");
            Console.WriteLine("21 - Öğrenci sil");
            Console.WriteLine("22 - Öğrenci güncelle");
        }

        static void AddStudentNote()
        {
            Console.WriteLine("\nNot Girişi");
            while (true)
            {
                Console.Write("\nÖğrenci numarası: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (SM.HasStudent(id))
                    {
                        Console.Write("Eklemek istediğiniz ders adı: ");
                        if (Enum.TryParse(Console.ReadLine(), true, out LessonName lesson) && Enum.IsDefined(typeof(LessonName), lesson))
                        {
                            Console.Write("Eklemek istediğiniz not adedi: ");
                            if (int.TryParse(Console.ReadLine(), out int counter))
                            {
                                int[] notes = new int[counter];
                                for (int i = 0; i < counter; i++)
                                {
                                    while (true)
                                    {
                                        Console.Write("{0}. Notu girin: ", i + 1);
                                        if (int.TryParse(Console.ReadLine(), out int note))
                                        {
                                            if (note >= 0 && note <= 100)
                                            {
                                                notes[i] = note;
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Girdiğiniz değer 0 ve 100 arasında olmalıdır.");
                                            }
                                        }
                                        else
                                            Console.WriteLine("Sayı tipinde bir değer girmelisiniz!");
                                    }
                                }

                                SM.AddNote(id, lesson, notes);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Sayı tipinde bir değer girmelisiniz!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bu ders sisteme kayıtlı değil!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Girdiğiniz numaraya ait öğrenci bulunamadı!");
                    }
                }
                else
                {
                    Console.WriteLine("Sayı tipinde bir değer girmelisiniz!");
                }
            }
        }

        static void GetStudentGA()
        {
            while (true)
            {
                Console.Write("\nÖğrenci numarası: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (SM.HasStudent(id))
                    {
                        Console.WriteLine("Öğrencinin not ortalaması: {0}", SM.GetStudent(id).GA);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Girdiğiniz numaraya ait öğrenci bulunamadı!");
                    }
                }
                else
                {
                    Console.WriteLine("Sayı tipinde bir değer girmelisiniz!");
                }
            }
        }

        static void AddStudentAddress()
        {
            while (true)
            {
                Console.Write("\nÖğrenci numarası: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (SM.HasStudent(id))
                    {
                        Console.Write("İl: ");
                        string province = Console.ReadLine();

                        Console.Write("İlçe: ");
                        string district = Console.ReadLine();

                        Console.Write("Mahalle: ");
                        string neighborhood = Console.ReadLine();


                        Address address = new Address(province, district, neighborhood);

                        SM.AddAddress(id, address);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Girdiğiniz numaraya ait öğrenci bulunamadı!");
                    }
                }
                else
                {
                    Console.WriteLine("Sayı tipinde bir değer girmelisiniz!");
                }
            }
        }

        static void AddStudentEvaluation()
        {

            while (true)
            {
                Console.Write("Ogrenci Numarası: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (SM.HasStudent(id))
                    {
                        Console.WriteLine("Öğrenci hakkında değerlendirme giriniz.");
                        string evaluation = Console.ReadLine();
                        SM.AddEvalaution(id, evaluation);

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Girdiğiniz numaraya ait öğrenci bulunamadı");
                    }
                }
                else
                {
                    Console.WriteLine("Sayı tipinde bir değişken girmelisiniz");
                }
            }
        }

        static void GetStudentEvaluation()
        {
            while (true)
            {
                Console.Write("Ogrenci Numarası : ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (SM.HasStudent(id))
                    {
                        int i = 0;
                        foreach (var item in SM.GetStudent(id).Reviews)
                        {
                            i++;
                            Console.WriteLine("\n {0} - {1}\n", i, item);
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Girdiğiniz numaraya ait öğrenci bulunamadı");
                    }
                }
                else
                {
                    Console.WriteLine("Sayı tipinde bir değişken girmelisiniz");
                }
            }
        }

        static void AddBooks()
        {
            while (true)
            {
                Console.Write("Ogrenci Numarası: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (SM.HasStudent(id))
                    {
                        Console.WriteLine("Kitap giriniz.");
                        string book = Console.ReadLine();
                        SM.AddBooks(id, book);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Girdiğiniz numaraya ait öğrenci bulunamadı");
                    }
                }
                else
                {
                    Console.WriteLine("Sayı tipinde bir değişken girmelisiniz");
                }
            }
        }

        static void GetBooks()
        {
            while (true)
            {
                Console.Write("Ogrenci Numarası : ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (SM.HasStudent(id))
                    {
                        int i = 0;
                        foreach (var item in SM.GetStudent(id).Books)
                        {
                            i++;
                            Console.WriteLine("\n{0} - {1}\n", i, item);
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Girdiğiniz numaraya ait öğrenci bulunamadı");
                    }
                }
                else
                {
                    Console.WriteLine("Sayı tipinde bir değişken girmelisiniz");
                }
            }
        }

        static void GetLastBook()
        {
            while (true)
            {
                Console.Write("Ogrenci Numarası : ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (SM.HasStudent(id))
                    {
                        Console.WriteLine("Öğrencinin okuduğu son kitap: {0} ", SM.GetLastBook(id));
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Girdiğiniz numaraya ait öğrenci bulunamadı");
                    }
                }
                else
                {
                    Console.WriteLine("Sayı tipinde bir değişken girmelisiniz");
                }
            }
        }


        static void ExitApp()
        {
            Environment.Exit(0);
        }




        static void AddStudent()
        {
            Console.Write("Öğrencinin numarası: ");
            bool dorumunumara = int.TryParse(Console.ReadLine(), out int numara);
            Console.Write("Öğrencinin adı:  ");
            string ad = Console.ReadLine();
            Console.Write("Öğrencinin soyadı:  ");
            string soyad = Console.ReadLine();
            Console.Write("Öğrencinin doğum tarihi:  ");
            bool dorumutarih = DateTime.TryParse(Console.ReadLine(), out DateTime dogumTarihi);
            Console.Write("Öğrencinin cinsiyeti:  ");
            string cinsiyet = Console.ReadLine();
            Gender gender = (Gender)Enum.Parse(typeof(Gender), cinsiyet);
            Console.Write("Öğrencinin şubesi:  ");
            string sınıf = Console.ReadLine();

            SM.AddStudent(ad, soyad, dogumTarihi, gender, numara, sınıf);

        }

        static void AllStudents()
        {
            ListHeader();
            foreach (var student in SM.Students)
            {
                DataWriter(student.ClassName, student.Name, student.Surname, student.GA, student.Books.Count);
            }
        }

        static void StudentsByClass()
        {
            Console.Write("Görmek istediğiniz şubeyi girin: ");
            string className = Console.ReadLine();
            ListHeader();
            foreach (var student in SM.StudentsByClass(className))
            {
                DataWriter(student.ClassName, student.Name, student.Surname, student.GA, student.Books.Count);
            }
        }

        static void StudentsByNeighborhood()
        {
            ListHeader();
            foreach (var student in SM.GetNeighborhood())
            {
                DataWriter(student.ClassName, student.Name, student.Surname, student.GA, student.Books.Count);
            }

        }

        static object StudentsByBirthDate()
        {
            Console.Write("Tarih sınırını girin: ");
            bool dateChecker = DateTime.TryParse(Console.ReadLine(), out DateTime birthDate);

            if (!dateChecker)
            {
                Console.WriteLine("Girilen tarih geçersiz! Lütfen bir daha deneyin.");
                return StudentsByBirthDate();
            }

            ListHeader();
            foreach (var student in SM.BirthDateListing(birthDate))
            {
                DataWriter(student.ClassName, student.Name, student.Surname, student.GA, student.Books.Count);
            }

            return null;
        }

        static void MostSuccessfulInSchool()
        {
            ListHeader();
            foreach (var student in SM.GetMostSuccessful())
            {
                DataWriter(student.ClassName, student.Name, student.Surname, student.GA, student.Books.Count);
            }
        }

        static void MostFailureInSchool()
        {
            ListHeader();
            foreach (var student in SM.GetMostFailure())
            {
                DataWriter(student.ClassName, student.Name, student.Surname, student.GA, student.Books.Count);
            }
        }
        static void MostSuccessfulInClass()
        {
            Console.Write("Görmek istediğiniz şubeyi girin: ");
            string className = Console.ReadLine();
            ListHeader();
            foreach (var student in SM.GetMostSuccessfulInClass(className))
            {
                DataWriter(student.ClassName, student.Name, student.Surname, student.GA, student.Books.Count);
            }
        }

        static void MostFailureInClass()
        {
            Console.Write("Görmek istediğiniz şubeyi girin: ");
            string className = Console.ReadLine();
            ListHeader();
            foreach (var student in SM.GetMostFailureInClass(className))
            {
                DataWriter(student.ClassName, student.Name, student.Surname, student.GA, student.Books.Count);
            }
        }

        static void StudentsByGender()
        {
            ListHeader();
            foreach (var student in SM.StudentsByGender())
            {
                Console.WriteLine($"{student.ClassName,10}{student.Name + " " + student.Surname,25} {student.GA,15} {student.Books.Count,20}");
            }
        }

        static void DataWriter(string className, string name, string surname, float ga, int bookCount)
        {
            Console.WriteLine($"{className,10}{name + " " + surname,25}{ga,15}{bookCount,5}");
        }

        static void ListHeader()
        {
            Console.WriteLine("{0}{1}{2}{3}", "Şube No".PadLeft(10), "Adı Soyadı".PadLeft(25), "Not Ort.".PadLeft(15), "Okuduğu Kitap Say.".PadLeft(20));
            Console.WriteLine("----------------------------------------------------------------------");
        }
    }
}
