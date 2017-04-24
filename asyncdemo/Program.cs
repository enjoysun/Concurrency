using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asyncdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var work = new worksort();
            Task<int> taskA = work.DelayAndReturnAsync(1);
            Task<int> taskB = work.DelayAndReturnAsync(2);
            Task<int> taskC = work.DelayAndReturnAsync(3);
            int[] arr = { taskA.Result, taskB.Result, taskC.Result };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine("starting...");

            var progress = new Progress<ProgressPartialResult>();
            progress.ProgressChanged += (sender, e) =>
            {
                Console.WriteLine(e.Current / e.Total * 100 + "%");
            };
            //work.MyMethodAsync(progress).Wait();
            Task<string> str = work.Getasyncstringwithurl("https://baidu.com", progress);
            Console.WriteLine(str.Result);
            Console.WriteLine("finished");
            Console.ReadKey();
        }
        //static Task AwaitAndProcessAsync(Task<int> task)
        //{

        //}
    }
}
