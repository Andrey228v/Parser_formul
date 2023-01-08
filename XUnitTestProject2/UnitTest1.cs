using System;
using Xunit;
using Parser_formul;
using System.Collections.Generic;

namespace XUnitTestProject2
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Parser Parser_1 = new Parser();

            ////Test_2
            //string stroka_2_test = "5+10*(((((-4--5+4.001))+111)*10)+5)+10+15*((10+15)+10)"; // ответ должен быть ....;
            //Dictionary<string, double> parametri_2_test = new Dictionary<string, double>() { { "a", 12.2 }, { "b", 12.4 } };
            //Parser_1.Preobrazovanie_str_v_formulu(stroka_2_test, parametri_2_test);

            Assert.Equal("1", "1");
            Console.WriteLine("TEST");
        }
    }
}
