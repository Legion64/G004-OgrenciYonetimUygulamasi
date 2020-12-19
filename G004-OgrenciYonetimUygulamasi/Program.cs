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
                            AddStudent();
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
                            GetStudentNotes();
                            break;
                        case 8:
                            GetGAInClass();
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
                            DeleteStudent();
                            break;
                        case 22:
                            UpdateStudent();
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
            Console.WriteLine(" 1 - Öğrenci Gir");
            Console.WriteLine(" 2 - Not Gir");
            Console.WriteLine(" 3 - Öğrencinin ortalamasını gör");
            Console.WriteLine(" 4 - Öğrencinin adresini gir");
            Console.WriteLine(" 5 - Bütün Öğrencileri Listele");
            Console.WriteLine(" 6 - Şubeye Göre Öğrencileri Listele");
            Console.WriteLine(" 7 - Öğrencinin notlarını görüntüle");
            Console.WriteLine(" 8 - Sınıfın not ortalamasını gör");
            Console.WriteLine(" 9 - Cinsiyetine göre öğrenci listele");
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
            Console.WriteLine("22 - Öğrenci güncelle\n");
            Console.WriteLine("Çıkış yapmak için \"çıkış\" yazıp \"enter\"a basın.");

        }

        static void AddStudentNote()
        {
            int id;
            Console.WriteLine("Not Girişi");
            while (true)
            {
                Console.Write("\nÖğrenci numarası: ");
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Sayı tipinde bir değer girmelisiniz!");
                }
                else
                {
                    if (!SM.HasStudent(id))
                    {
                        Console.WriteLine("Girdiğiniz numaraya ait öğrenci bulunamadı!");
                    }
                    else
                        break;
                }
            }

            LessonName lesson;
            while (true)
            {
                Console.Write("Eklemek istediğiniz ders adı: ");
                if (!(Enum.TryParse(Console.ReadLine(), true, out lesson) && Enum.IsDefined(typeof(LessonName), lesson)))
                {
                    Console.WriteLine("Bu ders sisteme kayıtlı değil!");
                }
                else
                    break;
            }

            int counter;
            while (true)
            {
                Console.Write("Eklemek istediğiniz not adedi: ");
                if (!int.TryParse(Console.ReadLine(), out counter))
                {
                    Console.WriteLine("Sayı tipinde bir değer girmelisiniz!");
                }
                else
                    break;
            }

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
        }

        static void GetStudentGA()
        {
            while (true)
            {
                Console.Write("Öğrenci numarası: ");
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
                Console.Write("Öğrenci numarası: ");
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
                Console.Write("Öğrenci Numarası: ");
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
                Console.Write("Öğrenci Numarası : ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (SM.HasStudent(id))
                    {
                        int i = 0;
                        
                        if(!(SM.GetStudent(id).Reviews.Count > 0))
                            Console.WriteLine("Bu öğrenciye ait değerlendirme bulunamadı!");
                        else
                        {
                            foreach (var item in SM.GetStudent(id).Reviews)
                            {
                                i++;
                                Console.WriteLine("\n {0} - {1}", i, item);
                            }
                        }
                        Console.WriteLine();
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
                Console.Write("Öğrenci Numarası: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (SM.HasStudent(id))
                    {
                        Console.Write("Kitap ismi girin: ");
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
                Console.Write("Öğrenci Numarası : ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (SM.HasStudent(id))
                    {
                        int i = 0;
                        if (!(SM.GetStudent(id).Books.Count > 0))
                            Console.WriteLine("Bu öğrenciye ait okunmuş kitap bulunamadı!");
                        else
                        {
                            foreach (var item in SM.GetStudent(id).Books)
                            {
                                i++;
                                Console.WriteLine("\n{0} - {1}", i, item);
                            }
                        }
                        Console.WriteLine();
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
                Console.Write("Öğrenci Numarası : ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (SM.HasStudent(id))
                    {
                        if(SM.GetStudent(id).Books.Count > 0)
                            Console.WriteLine("Öğrencinin okuduğu son kitap: {0} ", SM.GetLastBook(id));
                        else
                            Console.WriteLine("Bu öğrenci için okunmuş kitap bulunamadı!\n");
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

        static void GetStudentNotes()
        {
            while (true)
            {
                Console.Write("Öğrenci Numarası: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (SM.HasStudent(id))
                    {
                        Console.WriteLine($"\n{"Dersin Adı",10}{"Notu",15}");
                        Console.WriteLine("-------------------------");
                        foreach (var item in SM.GetStudentNote(id))
                        {
                            Console.WriteLine($"{item._Lesson,10}{item.Note,15}");
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

        private static void GetGAInClass()
        {
            Console.Write("Bir sınıf girin: ");
            string className = Console.ReadLine();
            float? _GA = SM.GetGAInClass(className);
            if (_GA != null)
            {
                Console.WriteLine("Sınıfın not ortalaması: {0}", _GA);
            }
            else
            {
                Console.WriteLine("Bu sınıfta öğrenci bulunamadı!");
            }
        }

        static void AllStudents()
        {
            Utils.ListHeader();
            foreach (var student in SM.Students)
            {
                Utils.DataWriter(student.ClassName, student.ID, student.Name, student.Surname, student.GA, student.Books.Count);
            }
        }

        static void StudentsByClass()
        {
            Console.Write("Görmek istediğiniz şubeyi girin: ");
            string className = Console.ReadLine();
            Utils.ListHeader();
            foreach (var student in SM.StudentsByClass(className))
            {
                Utils.DataWriter(student.ClassName, student.ID, student.Name, student.Surname, student.GA, student.Books.Count);
            }
        }

        static void StudentsByNeighborhood()
        {
            Utils.ListHeader();
            foreach (var student in SM.GetNeighborhood())
            {
                Utils.DataWriter(student.ClassName, student.ID, student.Name, student.Surname, student.GA, student.Books.Count);
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

            Utils.ListHeader();
            foreach (var student in SM.BirthDateListing(birthDate))
            {
                Utils.DataWriter(student.ClassName, student.ID, student.Name, student.Surname, student.GA, student.Books.Count);
            }

            return null;
        }

        static void MostSuccessfulInSchool()
        {
            Utils.ListHeader();
            foreach (var student in SM.GetMostSuccessful())
            {
                Utils.DataWriter(student.ClassName, student.ID, student.Name, student.Surname, student.GA, student.Books.Count);
            }
        }
        
        static void MostFailureInSchool()
        {
            Utils.ListHeader();
            foreach (var student in SM.GetMostFailure())
            {
                Utils.DataWriter(student.ClassName, student.ID, student.Name, student.Surname, student.GA, student.Books.Count);
            }
        }
        static void MostSuccessfulInClass()
        {
            Console.Write("Görmek istediğiniz şubeyi girin: ");
            string className = Console.ReadLine();
            Utils.ListHeader();
            foreach (var student in SM.GetMostSuccessfulInClass(className))
            {
                Utils.DataWriter(student.ClassName, student.ID, student.Name, student.Surname, student.GA, student.Books.Count);
            }
        }

        static void MostFailureInClass()
        {
            Console.Write("Görmek istediğiniz şubeyi girin: ");
            string className = Console.ReadLine();
            Utils.ListHeader();
            foreach (var student in SM.GetMostFailureInClass(className))
            {
                Utils.DataWriter(student.ClassName, student.ID, student.Name, student.Surname, student.GA, student.Books.Count);
            }
        }

        static void StudentsByGender()
        {
            while (true)
            {
                Console.Write("Hangi öğrencileri listelemek istersiniz? (E/K): ");
                bool isValid = Enum.TryParse(Console.ReadLine(), true, out Gender gender) && Enum.IsDefined(typeof(Gender), gender);
                if (isValid)
                {
                    Utils.ListHeader();
                    foreach (var student in SM.StudentsByGender(gender))
                    {
                        Utils.DataWriter(student.ClassName, student.ID, student.Name, student.Surname, student.GA, student.Books.Count);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Yanlış bir cinsiyet seçimi yaptınız!");
                }
            }
        }

        static void AddStudent()
        {

            int number;
            int tempNumber;
            while (true)
            {
                Console.Write("Öğrencinin numarası: ");
                bool isValidNumber = int.TryParse(Console.ReadLine(), out number);

                if (!isValidNumber)
                {
                    Console.WriteLine("Lütfen sayı tipinde bir veri girin!");
                }
                else
                {
                    tempNumber = number;
                    while (true)
                    {
                        if (SM.HasStudent(tempNumber))
                        {
                            tempNumber++;
                        }
                        else
                            break;
                    }
                    break;
                }
            }

            Console.Write("Öğrencinin adı: ");
            string name = Console.ReadLine();

            Console.Write("Öğrencinin soyadı: ");
            string surname = Console.ReadLine();

            DateTime birthDate;
            while (true)
            {
                Console.Write("Öğrencinin doğum tarihi: ");
                bool isValidDate = DateTime.TryParse(Console.ReadLine(), out birthDate);

                if (!isValidDate)
                {
                    Console.WriteLine("Lütfen geçerli bir tarih girin!");
                }
                else
                    break;
            }

            Gender gender;
            while (true)
            {
                Console.Write("Öğrencinin cinsiyeti K/E: ");
                string cinsiyet = Console.ReadLine();

                try
                {
                    gender = (Gender)Enum.Parse(typeof(Gender), cinsiyet.ToUpper());
                    break;
                }
                catch (Exception)
                {
                    Console.Write("Geçerli bir değer giriniz");
                }
            }

            Console.Write("Öğrencinin şubesi:  ");
            string className = Console.ReadLine();

            if (tempNumber != number)
                Console.WriteLine("Sistemde {0} numaralı öğrenci olduğu için verdiğiniz öğrenci no {1} olarak değiştirildi.", number, tempNumber);
            else
                Console.WriteLine("{0} numaralı öğrenci sisteme başarılı bir şekilde eklenmiştir.", tempNumber);

            SM.AddStudent(name, surname, birthDate, gender, tempNumber, className);
            Console.WriteLine("Öğrendi eklendi");
        }

        static void DeleteStudent()
        {
            Console.Write("Silmek istediğiniz öğrencinin numarasını girin: ");

            int id;
            while (true)
            {
                Console.Write("\nÖğrenci numarası: ");
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Sayı tipinde bir değer girmelisiniz!");
                }
                else
                {
                    if (!SM.HasStudent(id))
                    {
                        Console.WriteLine("Girdiğiniz numaraya ait öğrenci bulunamadı!");
                    }
                    else
                        break;
                }
            }

            SM.Students.Remove(SM.GetStudent(id));
            Console.WriteLine("{0} numaralı öğrenci başarılı bir şekilde silindi.", id);
        }

        static void UpdateStudent()
        {
            Student student = null;

            int id;
            while (true)
            {
                Console.Write("\nÖğrenci numarası: ");
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Sayı tipinde bir değer girmelisiniz!");
                }
                else
                {
                    if (!SM.HasStudent(id))
                    {
                        Console.WriteLine("Girdiğiniz numaraya ait öğrenci bulunamadı!");
                    }
                    else
                    {
                        student = SM.GetStudent(id);
                        break;
                    }
                }
            }

            Console.Write("Öğrencinin adı: ");
            string name = Console.ReadLine();

            Console.Write("Öğrencinin soyadı: ");
            string surname = Console.ReadLine();

            DateTime birthDate;
            while (true)
            {
                Console.Write("Öğrencinin doğum tarihi: ");
                bool isValidDate = DateTime.TryParse(Console.ReadLine(), out birthDate);
                if (!isValidDate)
                {
                    Console.WriteLine("Geçersiz bir tarih girdiniz. Lütfen tekrar deneyin!");
                }
                else
                    break;
            }

            Console.Write("Öğrencinin cinsiyeti K/E: ");
            string _gender = Console.ReadLine();
            Gender gender = Gender.Undefined;
            do
            {
                if (_gender != "")
                {
                    try
                    {
                        gender = (Gender)Enum.Parse(typeof(Gender), _gender.ToUpper());
                        break;
                    }
                    catch (Exception)
                    {
                        Console.Write("Geçerli bir değer giriniz: ");
                        _gender = Console.ReadLine();
                    }
                }
                else
                {
                    break;
                }

            } while (true);

            Console.Write("Öğrencinin şubesi: ");
            string className = Console.ReadLine();


            SM.UpdateStudent(student, name, surname, birthDate, gender, className);
            Console.WriteLine("Öğrenci güncellendi!");
        }





        static void ExitApp()
        {
            Environment.Exit(0);
        }
    }
}
