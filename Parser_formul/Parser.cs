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
        int glubina = 1; // Глубина погружения для тестов
        static bool stop_metka_dli_testov = false; // Для тестов
       
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
                    //Заглушка
                    Console.WriteLine($"ii:{i}");
                    Console.WriteLine($"stroka posle obrabotki: {stroka}");
                    break;
                }

                otsechka_prohoda += 1; // тут не единичка ???

            }


        }


        //Передаётся строка, ограниченная с двух сторон скобками
        //Передаётся глубина погружения, чтобы для тестов можно было выплывать....
        private void Poisk_skobok_v_glubinu(string stroka)
        {
            int nachalo_prohoda = otsechka_prohoda;
            int konec_prohoda;
            string srez_stroki_so_skobkami; // Переменная среза со скобками
            string srez_stroki_bez_skobok; // Вопрос может срез может быть и без скобок... 

            

            Console.WriteLine($"otsechka_prohoda:{otsechka_prohoda}");

            // Ставим +1 потому что надо смотреть от скобки, которая была найдена за шаг до предыдущей
            // Вопрос корректно ли это... 
            for (int i = nachalo_prohoda + 1; i < stroka.Length; i += 1)
            {

                // Заглушка
                if (stop_metka_dli_testov == true)
                {
                    Console.WriteLine($"Есть заход");
                    return;
                }


                string simvol = stroka[i].ToString();

                // Разбиение по скобкам
                if (simvol == "(")
                {
                    otsechka_prohoda += 1;
                    glubina += 1;
                    Poisk_skobok_v_glubinu(stroka);
                }

                if (simvol == ")")
                {
                    Console.WriteLine(stop_metka_dli_testov);
                    stop_metka_dli_testov = true;
                    konec_prohoda = i;
                    Console.WriteLine($"nachalo_prohoda:{nachalo_prohoda}, konec_prohoda:{konec_prohoda}");
                    //Вопрос верная ли формула Длина_Строки-Конец_прохода-1
                    //Нет не верная, необходимо добавить вычитание начала отсчёта, потому что скобка может быть не в начале...
                    Console.WriteLine($"Срез строки поиска скобок в глубину:{stroka.Substring(nachalo_prohoda, konec_prohoda - nachalo_prohoda + 1)}");

                    //Задача- вычислить то что мы нашли в скобках в глубине
                    //Заменить ответом выражение в скобках ответом, который мы получили.
                    // Мы получаем простую строку, которую надо вычислить
                    srez_stroki_so_skobkami = stroka.Substring(nachalo_prohoda, konec_prohoda - nachalo_prohoda + 1);
                    srez_stroki_bez_skobok = stroka.Substring(nachalo_prohoda + 1, konec_prohoda - nachalo_prohoda );
                    // Тут надо тестировать что передавать со скобками или без
                    Razbienie_prosoi_stroki(srez_stroki_bez_skobok);
                    
                    
                    // Поставим тут заглушку.
                    break;
                }

                
            }
        }


        //Данная функция на выходе получает простой ряд без скобок, в результате должный вернуть строку с ответом
        //, который был в данных скобках
        private string Razbienie_prosoi_stroki(string chast_stroki)
        {
            string rez_vichislenia = "";
            string chislo = "";
            string operacia = "";

            // К примеру, поступило 2+2.1+4/5
            // Разобьём строку по числам и знакам по приоритету
            // На выходе должен получится ответ данного выражения
            // А если отрицательное число ... 
            // [2, 2.1, 4, 5]
            // [+, +, /]
            Console.WriteLine($"chast_stroki: {chast_stroki}");

            for(int i =0; i < chast_stroki.Length; i += 1)
            {


                //list_chisel.Add();
                //list_operacii.Add();
            }

            return rez_vichislenia;

        }

        // Функция, которая должна считать простые математические действия
        // На вход передаётся часть строки, которая заключена в скобки
        private void Prostoi_raschet()
        {



        }





    }
}
