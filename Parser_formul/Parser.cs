using System;
using System.Collections.Generic;
using System.Text;

namespace Parser_formul
{
    class Parser
    {

        // Глобальные переменные, вопрос о рациональности... 
        List<double> list_chisel = new List<double>(); // Лист хранения чисел
        List<string> list_razbienia_po_skobkam = new List<string>(); // Лист хранения разбиения скобок
        List<string> list_operacii = new List<string>(); // Лист очереди операций
        List<string> preoritet_operazii = new List<string>() { "log", "sqrt", "^", "/", "*", "+", "-" };
        string otvet; // Результат
        int otsechka_prohoda = 0; // Проход по строке


        public Parser()
        {
           
        }


        // Функция по преобразованию строки в форумул
        // Функция получает на входе строку stroka;
        // Функция получает на входе параметры.
        public void Preobrazovanie_str_v_formulu(string stroka, Dictionary<string, double> parametri)
        {

            Console.WriteLine($"stroka: {stroka}");
            foreach (var parametr in parametri)
            {
                Console.WriteLine($"parametr:{parametr}");
            }

            Razbienie_stroki(stroka);


        }

        private void Razbienie_stroki(string stroka)
        {

            //otsechka_prohoda
            for (int i = 0; i < stroka.Length; i += 1)
            {
                string simvol = stroka[i].ToString();

                // Разбиение по скобкам
                if (simvol == "(")
                {
                    Poisk_skobok_v_glubinu(stroka);
                }

                otsechka_prohoda += 1; // тут не единичка ???

            }


        }

        private void Poisk_skobok_v_glubinu(string stroka)
        {
            int nachalo_prohoda = otsechka_prohoda;
            int konec_prohoda;

            for (int i = nachalo_prohoda; i < stroka.Length; i += 1)
            {
                Console.WriteLine($"i:{i}");

                string simvol = stroka[i].ToString();

                // Разбиение по скобкам
                if (simvol == "(")
                {
                    otsechka_prohoda += 1;
                    Poisk_skobok_v_glubinu(stroka);
                }

                if (simvol == ")")
                {
                    konec_prohoda = i;
                    Console.WriteLine($"nachalo_prohoda:{nachalo_prohoda}, konec_prohoda:{konec_prohoda}");
                    Console.WriteLine($"Срез строки поиска скобок в глубину:{stroka.Substring(nachalo_prohoda, stroka.Length-konec_prohoda)}");
                }

                

            }


        }


        private void Razbienie_prosoi_stroki(string chast_stroki)
        {

        }

        // Функция, которая должна считать простые математические действия
        // На вход передаётся часть строки, которая заключена в скобки
        private void Prostoi_raschet()
        {



        }





    }
}
