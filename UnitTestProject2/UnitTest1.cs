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
            string stroka_test = "(-4+5,001)";
            double otvet = -4 + 5.001;

            Test = Vspomogatelnii_method(stroka_test, parametri_test);

            Assert.AreEqual(Test, otvet, "������");

        }


        [TestMethod]
        public void TestMethod3()
        {
            double Test;

            Dictionary<string, double> parametri_test = new Dictionary<string, double>() { { "a", 12.2 }, { "b", 12.4 } };
            string stroka_test = "((-4+-5,001*-3)-10)-15";
            double otvet = ((-4 + -5.001 * -3) - 10) - 15;

            Test = Vspomogatelnii_method(stroka_test, parametri_test);

            Assert.AreEqual(Test, otvet, "������");

        }


        [TestMethod]
        public void TestMethod4()
        {
            double Test;

            Dictionary<string, double> parametri_test = new Dictionary<string, double>() { { "a", 12.2 }, { "b", 12.4 } };
            string stroka_test = "2^4";
            double otvet = Math.Pow(2, 4);

            Test = Vspomogatelnii_method(stroka_test, parametri_test);

            Assert.AreEqual(Test, otvet, "������");

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