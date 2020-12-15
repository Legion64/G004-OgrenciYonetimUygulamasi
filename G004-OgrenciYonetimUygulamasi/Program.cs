using G004_OgrenciYonetimUygulamasi.component;
using System;
using System.Linq.Expressions;

namespace G004_OgrenciYonetimUygulamasi
{
    class Program
    {
        static StudentManager SM = new StudentManager();

        // Bu sınıf verilerin işlemleri tamamlanınca dönen sonuca göre kontrol mekanizmasını çalıştırdığımız alan
        // Örnek: Öğrenci ekleme işlemi başarılıysa 'true' döner. -> Kontrolü yaparken 'true' ise işlem başarılı yazdırsın

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

                            break;
                        case 6:

                            break;
                        case 7:

                            break;
                        case 8:

                            break;
                        case 9:

                            break;
                        case 10:

                            break;
                        case 11:

                            break;
                        case 12:

                            break;
                        case 13:

                            break;
                        case 14:

                            break;
                        case 15:

                            break;
                        case 16:

                            break;
                        case 17:

                            break;
                        case 18:

                            break;
                        case 19:

                            break;
                        case 20:

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

        static void ExitApp()
        {
            Environment.Exit(0);
        }
    }
}
