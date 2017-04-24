using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //并发体现之并行处理
            //PocessPush(2, 2);
            //Console.ReadKey();
            var delay = new waitdelay();
            var assync = new asyncdemo();
            //Task<string> str = delay.Downloadwithrestri("http://news.sohu.com/20170424/n490448796.shtml");
            //Task<string> str = delay.Downloadwithtimeout("https://baidu.com");
            //Console.WriteLine(str.Result);
            var process = new Progress<ProcessResult>();

            process.ProgressChanged += new EventHandler<ProcessResult>(Process_ProgressChanged);
            assync.MyMethodAsync(process);
            Console.ReadKey();
        }

        private static void Process_ProgressChanged(object sender, ProcessResult e)
        {
            double partool = e.Current / e.Total;
            Console.WriteLine(partool);
        }

        public static void PocessPush(int x, int y)
        {
            Parallel.Invoke(
                () => GetPush(x, y),
                () => GetPush(x / 2, y / 2));
        }
        public static void GetPush(int x, int y)
        {
            Console.WriteLine(x + y);
        }
    }
}
