using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_python
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            try
            {
                string pythonLibPath = AppDomain.CurrentDomain.BaseDirectory + "PythonLib";
                string pythohFilePath = AppDomain.CurrentDomain.BaseDirectory + "stats_calibration.py";

                ScriptEngine engine = IronPython.Hosting.Python.CreateEngine();
                engine.SetSearchPaths(new List<string> { pythonLibPath });
                //ScriptSource script = engine.CreateScriptSourceFromFile(@"stats_calibration.py", Encoding.UTF8);
                //ScriptScope scope = engine.CreateScope();
                //script.Execute(scope);
                //var result = scope.GetVariable<Func<object>>("get_stats_by_http");
                dynamic pythonFile = engine.Runtime.UseFile(pythohFilePath);

                while (count++ < 5)
                {
                    try
                    {
                        IronPython.Runtime.PythonDictionary dictionary = (IronPython.Runtime.PythonDictionary)pythonFile.get_stats_by_http();
                        var monthTotalMib = (dictionary["MonthTotal"] as IronPython.Runtime.List)[0];
                        var monthUsedMib = (dictionary["MonthUsed"] as IronPython.Runtime.List)[0];
                        var monthUploadMib = (dictionary["MonthUpload"] as IronPython.Runtime.List)[0];
                        var monthDownloadMib = (dictionary["MonthDownload"] as IronPython.Runtime.List)[0];
                        Console.WriteLine(monthTotalMib);
                        Console.WriteLine(monthUsedMib);
                        Console.WriteLine(monthUploadMib);
                        Console.WriteLine(monthDownloadMib);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("CalibrateTrafficDataStats error: " + ex.Message);
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                //数据校正失败
                Console.WriteLine("数据校正失败：" + ex.Message);
            }
            //string result = script.Execute();
            Console.ReadLine();
        }
    }
}
