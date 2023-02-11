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
            
            Dictionary<string, double> parametri_test = new Dictionary<string, double>() { { "a", -4 }, { "b", 2 } };
            string stroka_test = "(a+5,001)^b";
            double otvet = (-4 + 5.001)*(-4 + 5.001);

            Test = Vspomogatelnii_method(stroka_test, parametri_test);

            Assert.AreEqual(Test, otvet, "Ошибка");

        }


        [TestMethod]
        public void TestMethod3()
        {
            double Test;

            Dictionary<string, double> parametri_test = new Dictionary<string, double>() { { "a11", 4 }, { "a2", 10 } };
            string stroka_test = "a11+a2*((-a11+-5,001*-3)-a2)-15";
            double otvet = 4 + 10 * ((-4 + -5.001 * -3) - 10) - 15;

            Test = Vspomogatelnii_method(stroka_test, parametri_test);

            Assert.AreEqual(Test, otvet, "Ошибка");

        }


        [TestMethod]
        public void TestMethod4()
        {
            double Test;

            Dictionary<string, double> parametri_test = new Dictionary<string, double>() { { "a", 2 }, { "b", 5 } };
            string stroka_test = "a^(4+3)-10*b-b--b/a";
            double otvet = Math.Pow(2, 7)-10*5-5-(-5.0/2.0);

            Test = Vspomogatelnii_method(stroka_test, parametri_test);

            Assert.AreEqual(Test, otvet, "Ошибка");

        }

        [TestMethod]
        public void TestMethod5()
        {
            double Test;

            Dictionary<string, double> parametri_test = new Dictionary<string, double>() { { "a", 3.559}, { "b", 4.3912 } };
            string stroka_test = "1+2+3+4+a+b";
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

            Dictionary<string, double> parametri_test = new Dictionary<string, double>() { { "a1", 10 }, { "b1", 4 } };
            string stroka_test = "(((b1-1)-a1--15)*(3,13*5*-2)/(2+10)-(5*a1))/(12*3)+b1";
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
            string stroka_test = "cos(cos(cos(90)))+cos(0)";
            double otvet = 1.9998531180882773;

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
