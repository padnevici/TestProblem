using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTal_TestCases;
using TopTal_Framework;

namespace debugger
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Log log = Logger.Log.Instance;
            TestBase.Initialize();
            TestCases tests = new TestCases();
            try
            {
                //tests.TTC_01();
                //tests.TTC_02();
                //tests.TTC_03();
                //tests.TTC_04();
                //tests.TTC_05();
                //tests.TTC_06();
                //tests.TTC_07();
                //tests.TTC_08();
                //tests.TTC_09();
                //tests.TTC_10();
                //tests.TTC_11();
                //tests.TTC_12();
                tests.TTC_13();
                tests.TTC_14();

            }
            catch (Exception e)
            {
                log.Error(e.Message);
                log.Error(e.StackTrace);
            }
            finally
            {
                Console.WriteLine("DONE !!!!!!!!!!!");
                Console.ReadKey();
                Browser.Quit();
            }
        }
    }
}
