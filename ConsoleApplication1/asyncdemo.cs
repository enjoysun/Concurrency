using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class asyncdemo
    {
        public async void MyMethodAsync(IProgress<ProcessResult> process = null)
        {
            int total = 100;
            for (int i = 0; i < total; i++)
            {
                //var task = new waitdelay().Downloadwithtimeout("https://www.baidu.com");
                await Task.Delay(20);
                if (process != null)
                {
                    process.Report(new ProcessResult() { Current = i + 1, Total = total });
                }

            }
            process.Report(new ProcessResult() { Current = 0, Total = total });

        }
    }
    public class ProcessResult
    {
        public int Current { get; set; }
        public int Total { get; set; }
    }
}
