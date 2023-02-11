using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser_formul
{
    public class Parser
    {

        // Глобальные переменные, вопрос о рациональности... 
        List<string> list_chisel = new List<string>(); // Лист хранения чисел
        List<string> list_operacii = new List<string>(); // Лист очереди операций
        List<string> list_operacii_nad_skobkami = new List<string>(); // Лист операций над скобками
        List<string> list_preoriteta_operazii = new List<string>() { "log", "sqrt", "cos", "sin", "^", "/", "*", "+", "-" };
        List<string> list_vozmognih_chisel = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };


        public Parser()
        {
          
            
        }


        // Функция по преобразованию строки в форумул
        // Функция получает на входе строку stroka;
        // Функция получает на входе параметры.
        public double Preobrazovanie_str_v_formulu(string stroka, Dictionary<string, double> parametri)
        {

            double rez = 0.0;
            Console.WriteLine($"stroka: {stroka}");
            stroka = Podstanovka_parametrov_v_stroku(stroka, parametri);
            rez = double.Parse(Razbienie_stroki(stroka));
            Console.WriteLine($"stroka 2: {stroka}");
            Console.WriteLine($"rez_finall: {rez}");

            return rez;


        }

        private string Razbienie_stroki(string stroka)
        {

            stroka = Poisk_skobok_v_glubinu(stroka);
            stroka = Razbienie_prosoi_stroki(stroka);

            return stroka;
        }
        
        //Передаётся строка, ограниченная с двух сторон скобками

        private string Poisk_skobok_v_glubinu(string stroka, int ots = 0)
        {
            int otsechka_prohoda = ots; // Проход по строке
            int nachalo_prohoda = otsechka_prohoda;
            int konec_prohoda;
            string srez_stroki_so_skobkami; // Переменная среза со скобками
            string srez_stroki_bez_skobok; // Вопрос может срез может быть и без скобок... 
            string operazia_nad_skobkami = "";
            string rez_operazii_v_skobkah;
            bool flag_skobok = false;

            // +1 ставится тут, потому что отсечка начинается с -1.
            // -1 у отсечки потому-что мы хотим обозревать с 0, а не с 1.

            for (int i = nachalo_prohoda; i < stroka.Length; i += 1)
            {
                otsechka_prohoda += 1;
                string simvol = stroka[i].ToString();


                // Разбиение по скобкам
                if (simvol == "(")
                {
                    list_operacii_nad_skobkami.Add(operazia_nad_skobkami);
                    stroka = Poisk_skobok_v_glubinu(stroka, otsechka_prohoda);
                    flag_skobok = false;
                    operazia_nad_skobkami = "";                 
                    continue;
                }

                else if (simvol == ")")
                {
                    konec_prohoda = i;

                    //Задача- вычислить то что мы нашли в скобках в глубине
                    //Заменить ответом выражение в скобках ответом, который мы получили.
                    // Мы получаем простую строку, которую надо вычислить
                    srez_stroki_so_skobkami = stroka.Substring(nachalo_prohoda - 1, konec_prohoda - nachalo_prohoda + 2);
                    srez_stroki_bez_skobok = stroka.Substring(nachalo_prohoda, konec_prohoda - nachalo_prohoda);
                    rez_operazii_v_skobkah = Razbienie_prosoi_stroki(srez_stroki_bez_skobok);

                    if (list_operacii_nad_skobkami.Last() != "")
                    {
                        rez_operazii_v_skobkah = Operacii_nad_skobkami(rez_operazii_v_skobkah, list_operacii_nad_skobkami.Last());
                        list_chisel.Clear();
                    }

                    stroka = stroka.Replace(srez_stroki_so_skobkami, rez_operazii_v_skobkah);
                    list_operacii_nad_skobkami.Remove(list_operacii_nad_skobkami.Last());


                    break;
                }

                else if (flag_skobok == false & 
                    Poisk_simvola_v_spiske(list_vozmognih_chisel, simvol) == false &
                    Poisk_simvola_v_spiske(list_preoriteta_operazii, simvol) == false &
                    simvol != ",") 
                {

                    operazia_nad_skobkami += simvol;
                    // Из-за того что после удаления операции над скобками в строке отсечка прохода не перемещается,
                    // её необходимо перемещать самому. Вопрос это можно ли сделать как-то более красиво ... 
                    stroka = stroka.Remove(i, 1);
                    otsechka_prohoda -= 1;
                    i = i - 1;
                }

            }
            return stroka;
        }

        //Данная функция на выходе получает простой ряд без скобок, в результате должный вернуть строку с ответом
        //, который был в данных скобках
        private string Razbienie_prosoi_stroki(string chast_stroki)
        {
            string rez_vichislenia = chast_stroki;
            string chislo = "";
            string operacia = "";

            // К примеру, поступило 2+2.1+4/5
            // Разобьём строку по числам и знакам по приоритету
            // На выходе должен получится ответ данного выражения
            // А если отрицательное число ... 
            // [2, 2.1, 4, 5]
            // [+, +, /]


            for(int i = 0; i < chast_stroki.Length; i += 1)
            {

                string simvol = chast_stroki[i].ToString();

                if (Poisk_simvola_v_spiske(list_vozmognih_chisel, simvol)) // числа
                {
                    chislo = chislo + simvol;

                    if(operacia != "")
                    {
                        list_operacii.Add(operacia);
                        operacia = "";
                    }
                }
                else if (Poisk_simvola_v_spiske(list_preoriteta_operazii, simvol)) // операции
                {
                    // Условие только для знака минус
                    if (simvol == "-")
                    {
                        //Проверка на начало строрки, если знак минус стоит в начале (-4....
                        if (i == 0)
                        {
                            chislo = chislo + simvol;
                        }


                        // Проверка на то, что если перед знаком минус стоит число, то это операция ...4-...
                        else if (Poisk_simvola_v_spiske(list_vozmognih_chisel, chast_stroki[i-1].ToString()))
                        {
                            list_chisel.Add(chislo);
                            chislo = "";
                                            
                            operacia = operacia + simvol;
                            list_operacii.Add(operacia);
                            operacia = "";

                        }
                        else if ((simvol == "(" ) || ( simvol == ")")) 
                        {
                            Console.WriteLine("Скобка не должна тут быть");
                        }
                        else
                        {
                            chislo = chislo + simvol;
                        }
                    }
                    else // если знак не равен минусу, то дабавляем его в список символов и добавляем число в список чисел
                    {
                        list_chisel.Add(chislo);
                        chislo = "";

                        // Тут надо доработать момент, если операция состоит из нескольких символов
                        operacia += simvol;
                        list_operacii.Add(operacia);
                        operacia = "";
                    }
                }
                else if (simvol == ",")
                {
                    chislo = chislo + simvol;
                }
                else
                {
                    Console.WriteLine($"Ошибка: {simvol}");
                }
            }

            if (chislo != "")
            {
                list_chisel.Add(chislo);
            }


            if (list_operacii.Count != 0)
            {
                rez_vichislenia = Obrabotka_Prostogo_viragenia(list_chisel, list_operacii);
            }
            
            return rez_vichislenia;

        }

        // Функция, которая должна считать простые математические действия
        // На вход передаётся часть строки, которая заключена в скобки
        private string Obrabotka_Prostogo_viragenia(List<string> list_chisel, List<string> list_operacii)
        {
            string rez = "1";


            //[0, 1, 2 ,3, 4]
            //[-, -, -, -]
            foreach( string operacia_pr in list_preoriteta_operazii)
            {
                for(int i=0; i < list_operacii.Count; i+=1)
                {
                    if (operacia_pr == list_operacii[i])
                    {
                        rez = Prostoi_raschet(list_chisel[i], list_chisel[i + 1], operacia_pr);
                        list_chisel.RemoveAt(i + 1);
                        list_chisel.RemoveAt(i);
                        list_operacii.RemoveAt(i);
                        list_chisel.Insert(i, rez);
                        i = -1;
                    }
                }
            }

            list_chisel.Clear();

            return rez;
        }

        private string Prostoi_raschet(string a, string b, string operacia)
        {
            string rez = "";

            
            double a_d = double.Parse(a);
            double b_d = double.Parse(b);

            if (operacia == "+")
            {
                rez = (a_d + b_d).ToString();
            }
            else if (operacia == "-")
            {
                rez = (a_d - b_d).ToString();
            }
            else if (operacia == "*")
            {
                rez = (a_d * b_d).ToString();
            }
            else if (operacia == "/")
            {
                rez = (a_d / b_d).ToString();
            }
            else if (operacia == "^")
            {
                rez = (Math.Pow(a_d, b_d)).ToString();
            }



            return rez;
        }

        private string Operacii_nad_skobkami(string a, string operacia)
        {
            string rez = "";
            

            double a_d = double.Parse(a);

            if (operacia == "sqrt")
            {
                rez = (Math.Sqrt(a_d)).ToString();
            }

            if (operacia == "ln")
            {
                rez = (Math.Log10(a_d)).ToString();
            }

            if (operacia == "log")
            {
                rez = (Math.Log(a_d)).ToString();
            }

            if (operacia == "sin")
            {
                rez = (Math.Sin(a_d)).ToString();
            }

            if (operacia == "cos")
            {
                //rez = Math.Round((Math.Cos(a_d*Math.PI/180))).ToString();
                rez = (Math.Cos(a_d * Math.PI / 180)).ToString();

            }
            Console.WriteLine($"rez:{rez}");
            return rez;
        }

        private bool Poisk_simvola_v_spiske(List<string> List_poiska, string simvol)
        {
            bool rez = false;
            foreach(string element_spiska in List_poiska)
            {
                if (element_spiska == simvol)
                {
                    rez = true;
                    break;
                }
            }

            return rez;
        }

        private string Podstanovka_parametrov_v_stroku(string stroka, Dictionary<string, double> parametri)
        {

            foreach(var parametr in parametri)
            {
                string key = parametr.Key;
                string znachenie_parametra = (parametr.Value).ToString();
                string parametr_v_stroke = "";
                bool flag_ostanova = false;
                string test_substring = "";
                

                for (int i = 0; i < stroka.Length; i++)
                {
                    string simvol = stroka[i].ToString();
                    

                    if (flag_ostanova == false &
                        Poisk_simvola_v_spiske(list_preoriteta_operazii, simvol) == false &
                        simvol != "," & simvol != ")" & simvol != "(")
                    {
                        parametr_v_stroke += simvol;      
                    }
                    else // если стоит знак то делаем флаг останова
                    {
                        flag_ostanova = true;
                    }

                    // Проверка на последний символ в строке. Если символ последний, то мы заканчиваем проход
                    // и подставляем ему нужное значение.
                    if (flag_ostanova == false &
                            Poisk_simvola_v_spiske(list_preoriteta_operazii, simvol) == false &
                            simvol != "," & simvol != ")" & simvol != "(" &
                            i == stroka.Length-1)
                    {
                        i = i + 1;
                        flag_ostanova = true;

                    }

                    if (parametr_v_stroke == key & flag_ostanova == true)
                    {
                        test_substring = stroka.Substring(i - parametr_v_stroke.Length, parametr_v_stroke.Length);
                        stroka = stroka.Remove(i - parametr_v_stroke.Length, parametr_v_stroke.Length);
                        stroka = stroka.Insert(i - parametr_v_stroke.Length, znachenie_parametra);
                        flag_ostanova = false;
                        parametr_v_stroke = "";
 
                    }
                    else if (flag_ostanova == true)
                    {
                        parametr_v_stroke = "";
                        flag_ostanova = false;
                    }


                }

            }

            return stroka;
        }

    }
}
