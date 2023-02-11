using System;
using System.Collections.Generic;
using System.Reflection;

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
            //string stroka_2_test = "5+10*(((((-4.0--5.0+4.001))+111)*10)+5)+10+15*((10+15)+10)"; // ответ должен быть ....;

            string stroka_2_test = "((a1+a1)+(b+10)+ab)+a1";
            Dictionary<string, double> parametri_2_test = new Dictionary<string, double>() { { "a1", 1.11 }, { "b", 22.2 }, {"ab", 333.333 } };
            Parser_1.Preobrazovanie_str_v_formulu(stroka_2_test, parametri_2_test);
            double otvet = ((1.11 + 1.11) + (22.2 + 10) + 333.333) + 1.11;
            Console.WriteLine($"Ответ: {otvet}");



        }
    }
}
