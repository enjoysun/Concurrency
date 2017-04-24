using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace asyncdemo
{
    public class ProgressPartialResult
    {
        public double Current { get; set; }
        public int Total { get; set; }
    }
    public class worksort
    {
        public async Task<int> DelayAndReturnAsync(int val)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(val));
            return val;
        }
        public async Task MyMethodAsync(IProgress<double> progress)
        {
            double precentComplete = 0;
            bool done = false;
            while (!done)
            {
                await Task.Delay(100);
                if (progress != null)
                {
                    progress.Report(precentComplete);
                }
                precentComplete++;
                if (precentComplete == 100)
                {
                    done = true;
                }
            }
        }

        public async Task<string> Getasyncstringwithurl(string url, IProgress<ProgressPartialResult> process = null)
        {
            int totle = 100;
            double precentComplete = 0;
            bool done = false;

            using (var client = new HttpClient())
            {
                while (!done)
                {
                    string str=await client.GetStringAsync(url);
                    if (process != null)
                    {
                        process.Report(new ProgressPartialResult() { Current = precentComplete++, Total = totle });
                    }
                    precentComplete++;
                    if (precentComplete == 100)
                    {
                        done = true;
                        return str;
                    }
                }
                return "log";
            }
        }
    }
}
