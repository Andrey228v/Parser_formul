using System;
using System.Collections.Generic;

namespace Parser_formul
{
    class Program
    {
       

        // Проблемы :
        // Могут быть отрицательные числа
        // Возведение в степень может быть ^, а может быть ** надо выбрать что-то одно.

        static void Main(string[] args)
        {
            Parser Parser_1 = new Parser();

            ////Test_2
            string stroka_2_test = "5+10*(((((-4+5+4.001))+111)*10)+5)+10"; // ответ должен быть ....;
            Dictionary<string, double> parametri_2_test = new Dictionary<string, double>() { { "a", 12.2 }, { "b", 12.4 } };
            Parser_1.Preobrazovanie_str_v_formulu(stroka_2_test, parametri_2_test);


            //Test_1
            //string stroka_1_test = "2+5"; // ответ должен быть 7;
            //Dictionary<string, double> parametri_1_test = new Dictionary<string, double>() { {"a", 12.2 }, {"b", 12.4 } };
            //Parser_1.Preobrazovanie_str_v_formulu(stroka_1_test, parametri_1_test);




        }
    }
}
