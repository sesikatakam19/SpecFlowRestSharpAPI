using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SpecFlowRestSharpAPI.Hooks
{
    [Binding]
    public  class MyHooks
    {
        static string filepath = null;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        [BeforeFeature]
        public static void HooskFeatures()
        {
            var folderpath = Path.GetFullPath(@"..\..\..\") + @"Results\" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (!(Directory.Exists(folderpath)) && filepath == null)
            {
                Directory.CreateDirectory(folderpath);
                filepath = folderpath;
               
                
            }
            var filename = folderpath + @"\ExecutionResults.txt";
            if (!(File.Exists(filename)))
            {
                var fs = File.Create(filename);
                fs.Close();
            }
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            UpdateFile("");
            UpdateFile($"Running Test scenario - {TestContext.CurrentContext.Test.Name}");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Passed)
            {
                UpdateFile($"TEST RESULT - PASS");
            }
            else if (status == TestStatus.Failed)
            {
                UpdateFile($"TEST RESULT - FAIL");
                
            }
        }
        
        public static void UpdateFile(string message)
        {
            var filename = filepath + @"\ExecutionResults.txt";

            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine(message);
                sw.Close();
            }
        }
    }


}
