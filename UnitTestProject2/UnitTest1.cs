using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser_formul;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {

       

        [TestMethod]
        public void TestMethod2()
        {
            double Test;
            
            Dictionary<string, double> parametri_test = new Dictionary<string, double>() { { "a", 12.2 }, { "b", 12.4 } };
            string stroka_test = "(-4+5,001)^2";
            double otvet = (-4 + 5.001)*(-4 + 5.001);

            Test = Vspomogatelnii_method(stroka_test, parametri_test);

            Assert.AreEqual(Test, otvet, "Ошибка");

        }


        [TestMethod]
        public void TestMethod3()
        {
            double Test;

            Dictionary<string, double> parametri_test = new Dictionary<string, double>() { { "a", 12.2 }, { "b", 12.4 } };
            string stroka_test = "4+10*((-4+-5,001*-3)-10)-15";
            double otvet = 4 + 10 * ((-4 + -5.001 * -3) - 10) - 15;

            Test = Vspomogatelnii_method(stroka_test, parametri_test);

            Assert.AreEqual(Test, otvet, "Ошибка");

        }


        [TestMethod]
        public void TestMethod4()
        {
            double Test;

            Dictionary<string, double> parametri_test = new Dictionary<string, double>() { { "a", 12.2 }, { "b", 12.4 } };
            string stroka_test = "2^(4+3)-10*5-5--5/2";
            double otvet = Math.Pow(2, 7)-10*5-5-(-5.0/2.0);

            Test = Vspomogatelnii_method(stroka_test, parametri_test);

            Assert.AreEqual(Test, otvet, "Ошибка");

        }

        [TestMethod]
        public void TestMethod5()
        {
            double Test;

            Dictionary<string, double> parametri_test = new Dictionary<string, double>() { { "a", 12.2 }, { "b", 12.4 } };
            string stroka_test = "1+2+3+4+3,559+4,3912";
            double otvet = 1 + 2 + 3 + 4 + 3.559 + 4.3912;

            Test = Vspomogatelnii_method(stroka_test, parametri_test);

            Assert.AreEqual(Test, otvet, "Ошибка");

        }


        [TestMethod]
        public void TestMethod6()
        {
            double Test;

            Dictionary<string, double> parametri_test = new Dictionary<string, double>() { { "a", 12.2 }, { "b", 12.4 } };
            string stroka_test = "1*2*3*4+4+5-1-4/2*(4+(4+(4*(5+5))))";
            double otvet = 1 * 2 * 3 * 4 + 4 + 5 - 1 - 4 / 2 * (4 + (4 + (4 * (5 + 5))));

            Test = Vspomogatelnii_method(stroka_test, parametri_test);

            Assert.AreEqual(Test, otvet, "Ошибка");

        }

        [TestMethod]
        public void TestMethod7()
        {
            double Test;

            Dictionary<string, double> parametri_test = new Dictionary<string, double>() { { "a", 12.2 }, { "b", 12.4 } };
            string stroka_test = "(((4-1)-10--15)*(3,13*5*-2)/(2+10)-(5*10))/(12*3)+4";
            double otvet = (((4 - 1) - 10- -15)*(3.13 * 5 * -2) / (2 + 10) - (5 * 10))/(12*3)+4;

            Test = Vspomogatelnii_method(stroka_test, parametri_test);

            Assert.AreEqual(Test, otvet, "Ошибка");

        }


        [TestMethod]
        public void TestMethod8()
        {
            double Test;

            Dictionary<string, double> parametri_test = new Dictionary<string, double>() { { "a", 12.2 }, { "b", 12.4 } };
            string stroka_test = "sqrt(16+sqrt(5*5)+sqrt(4*4))";
            double otvet = 5;

            Test = Vspomogatelnii_method(stroka_test, parametri_test);

            Assert.AreEqual(Test, otvet, "Ошибка");

        }

        [TestMethod]
        public void TestMethod9()
        {
            double Test;

            Dictionary<string, double> parametri_test = new Dictionary<string, double>() { { "a", 12.2 }, { "b", 12.4 } };
            string stroka_test = "cos(90)+cos(0)";
            double otvet = 1;

            Test = Vspomogatelnii_method(stroka_test, parametri_test);

            Assert.AreEqual(Test, otvet, "Ошибка");

        }

        


        public double Vspomogatelnii_method(string stroka_test, Dictionary<string, double> parametri_test)
        {
            double rez;

            Parser Parser_1 = new Parser();
            Type type_class = typeof(Parser);

            //foreach (FieldInfo field in type_class.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            //{
            //    Console.WriteLine($"field:{field}");
            //}

            Object[] args = new Object[0];
            Object obj = type_class.InvokeMember(null,
            BindingFlags.DeclaredOnly |
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.CreateInstance, null, null, args);


            Object Preobrazovanie = type_class.InvokeMember("Preobrazovanie_str_v_formulu", BindingFlags.DeclaredOnly |
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.InvokeMethod, null, obj, new Object[] { stroka_test, parametri_test });


            rez = (double)Preobrazovanie;

            return rez;


        }


    }
}
