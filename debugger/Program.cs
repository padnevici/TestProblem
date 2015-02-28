using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsVerifyFramework;
using LetsVerifyTests;

namespace debugger
{
    class Program
    {
        static void Main(string[] args)
        {
            AdministraotrTestCases();
        }

        public static void AdministraotrTestCases()
        {
            Logger.Logger log = Logger.Logger.Instance;

            //SmokeTests s = new SmokeTests();
            AdministratorTestCases a = new AdministratorTestCases();
            TestBase.Initialize();
            a.Init();

            try
            {
                //a.LVA_1001();
                //a.LVA_1002();
                //a.LVA_1003();
                //a.LVA_1004();
                //a.LVA_1005();
                //a.LVA_1006();
                //a.LVA_1007();
                //a.LVA_1008();
                //a.LVA_1009();
                //a.LVA_1010();
                //a.LVA_1011();
                //a.LVA_1012();
                //a.LVA_1013();
                //a.LVA_1014();
                //a.LVA_1015();
                //a.LVA_1016();
                //a.LVA_1017();
                //a.LVA_1018();
                //a.LVA_1019();
                //a.LVA_1020();
                //a.LVA_1021();
                //a.LVA_1022();
                //a.LVA_1023();
                //a.LVA_1024();
                //a.LVA_1025();
                //a.LVA_1026();
                //a.LVA_1027();
                //a.LVA_1028();
                //a.LVA_1029();
                //a.LVA_1030();
                //a.LVA_1031();
                //a.LVA_1032();
                a.LVA_1033();
                a.LVA_1034();
                a.LVA_1035();
                a.LVA_1036();
                //a.LVA_test();

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

        public static void MasteAdminTestCases()
        {
            Logger.Logger log = Logger.Logger.Instance;

            //SmokeTests s = new SmokeTests();
            MasterAdminTestCases m = new MasterAdminTestCases();
            TestBase.Initialize();
            //try
            //{
            //s.CanLogIn();
            //m.LVMA_1();
            //m.LVMA_2();
            //m.LVMA_3();
            //m.LVMA_4();
            //m.LVMA_5();
            //m.LVMA_6();
            //m.LVMA_7();
            //m.LVMA_108();
            //m.LVMA_109();
            //m.LVMA_10();
            //m.LVMA_11();
            //m.LVMA_12();
            //m.LVMA_13();
            //m.LVMA_14();
            //m.LVMA_15();
            //m.LVMA_16();
            //m.LVMA_17();
            //m.LVMA_18();
            //m.LVMA_119();
            //m.LVMA_120();
            //m.LVMA_21();
            //m.LVMA_22();
            //m.LVMA_23();
            //m.LVMA_24();
            //m.LVMA_25();
            //m.LVMA_26();
            //m.LVMA_27();
            //m.LVMA_135();
            //m.LVMA_136();
            //m.LVMA_137();
            //m.LVMA_138();
            //m.LVMA_139();
            //m.LVMA_140();

            //}
            //catch (Exception e)
            //{
            //    log.Error(e.Message);
            //    log.Error(e.StackTrace);
            //}
            //finally
            //{
            //    Console.WriteLine("DONE !!!!!!!!!!!");
            //    Console.ReadKey();
            //    Browser.Quit();
            //}

        }
    }
}
