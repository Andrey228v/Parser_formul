using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser_formul;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            Parser Parser_1 = new Parser();
            string stroka_2_test = "5+10*(((((-4--5+4.001))+111)*10)+5)+10+15*((10+15)+10)"; // ответ должен быть ....;
            Dictionary<string, double> parametri_2_test = new Dictionary<string, double>() { { "a", 12.2 }, { "b", 12.4 } };
            Parser_1.Preobrazovanie_str_v_formulu(stroka_2_test, parametri_2_test);
            Assert.AreEqual(12, 13, "tOKFAWK");
        }
    }
}
