namespace Odev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tablo = new string[]
            {
                "Numara",
                "İsim",
                "Soyad",
                "Vize",
                "Final",
                "Ortalama",
                "Harf"
            };

            int ogrencisayi = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Öğrenci sayısı?");
                    ogrencisayi = Convert.ToInt32(Console.ReadLine());

                    if (ogrencisayi <= 0)
                    {
                        Console.WriteLine("Öğrenci sayısı pozitif bir sayı olmalı.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                }
            }

            double[] ortalamaT = new double[ogrencisayi];
            string[,] liste = new string[ogrencisayi + 1, tablo.Length];

            double min = 0;
            double max = 0;
            double vizeNot = 0;
            double finalNot = 0;
            double ortalama = 0;
            double genel = 0;

            for (int i = 0; i < tablo.Length; i++)
            {
                liste[0, i] = tablo[i];
            }

            for (int i = 0; i < ogrencisayi; i++)
            {
                Console.Write($"{i + 1}. Öğrencinin Numarasını Giriniz: ");
                int numara =int.Parse(Console.ReadLine().Trim());
                    
                while (true)
                {
                    try
                    {
                        liste[i + 1, 0] = numara.ToString();
                        if (numara <= 0)
                        {
                            Console.WriteLine("Öğrenci numarası sıfır veya negatif girilemez.\nNumara giriniz");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Lütfen geçerli bir tam sayı giriniz.");
                    }
                }

                Console.Write($"{i + 1}. Öğrencinin Adını Giriniz: ");
                liste[i + 1, 1] = Console.ReadLine().Trim().ToUpper();

                Console.Write($"{i + 1}. Öğrencinin Soyadını Giriniz: ");
                liste[i + 1, 2] = Console.ReadLine().Trim().ToUpper();

                while (true)
                {
                    try
                    {
                        Console.Write($"{i + 1}. Öğrencinin Vize Notunu Giriniz: ");
                        vizeNot = Convert.ToDouble(Console.ReadLine());
                        if (vizeNot < 0 || vizeNot > 100)
                        {
                            Console.WriteLine("Lütfen 0-100 arasında geçerli bir vize notu giriniz.");
                        }
                        else
                        {
                            liste[i + 1, 3] = vizeNot.ToString();
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Lütfen geçerli bir sayısal değer giriniz.");
                    }
                }

                while (true)
                {
                    try
                    {
                        Console.Write($"{i + 1}. Öğrencinin Final Notunu Giriniz: ");
                        finalNot = Convert.ToDouble(Console.ReadLine());
                        if (finalNot < 0 || finalNot > 100)
                        {
                            Console.WriteLine("Lütfen 0-100 arasında geçerli bir değer giriniz.");
                        }
                        else
                        {
                            liste[i + 1, 4] = finalNot.ToString();
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Lütfen geçerli bir sayısal değer giriniz.");
                    }
                }

                ortalama = vizeNot * 0.40 + finalNot * 0.60;
                ortalamaT[i] = ortalama;

                if (ortalama >= 85) { liste[i + 1, 6] = "AA"; }
                else if (ortalama >= 75) { liste[i + 1, 6] = "BA"; }
                else if (ortalama >= 60) { liste[i + 1, 6] = "BB"; }
                else if (ortalama >= 50) { liste[i + 1, 6] = "CB"; }
                else if (ortalama >= 40) { liste[i + 1, 6] = "CC"; }
                else if (ortalama >= 30) { liste[i + 1, 6] = "DC"; }
                else if (ortalama >= 20) { liste[i + 1, 6] = "DD"; }
                else if (ortalama >= 10) { liste[i + 1, 6] = "FD"; }
                else { liste[i + 1, 6] = "FF"; }

                liste[i + 1, 5] = ortalama.ToString("F2");

                Console.WriteLine(" ");
            }

            min = ortalamaT.Min();
            max = ortalamaT.Max();
            genel = ortalamaT.Average();

            string format = "{0,-11}{1,-9}{2,-10}{3,-14}{4,-15}{5,-13}{6,-9}";

            Console.WriteLine(string.Format(format, "Numara", "İsim", "Soyad", "Vize Notu", "Final Notu", "Ortalama", "Harf"));

            for (int i = 0; i < ogrencisayi; i++)
            {
                Console.WriteLine(string.Format(format,
                    liste[i + 1, 0],
                    liste[i + 1, 1],
                    liste[i + 1, 2],
                    liste[i + 1, 3],
                    liste[i + 1, 4],
                    liste[i + 1, 5],
                    liste[i + 1, 6]
                ));
            }

            Console.WriteLine($"\nSınıf Ortalaması: {genel:F2}\nEn Düşük Not: {min:F2}\nEn Yüksek Not: {max:F2}");
        }
    }
}
