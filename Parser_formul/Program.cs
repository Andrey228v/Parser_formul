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

            string stroka_2_test = "(((15*2)/12)-(5*10))+10";
            Dictionary<string, double> parametri_2_test = new Dictionary<string, double>() { { "a", 12.2 }, { "b", 12.4 } };
            Parser_1.Preobrazovanie_str_v_formulu(stroka_2_test, parametri_2_test);
            double otvet = (15 * 2.0 / 12.0 - (5 * 10))+10;
            Console.WriteLine($"Ответ: {otvet}");



        }
    }
}
