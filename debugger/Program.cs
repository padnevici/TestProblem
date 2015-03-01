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
                tests.Test_01();


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
