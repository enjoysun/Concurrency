using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class waitdelay
    {
        //使用task的delay实现指数退避
        public async Task<string> Downloadwithrestri(string url)
        {
            using (var client = new HttpClient())
            {
                //第一次重试等一秒，第二次两秒，第三次四秒
                var nextdelay = TimeSpan.FromSeconds(1);
                for (int i = 0; i != 3; i++)
                {
                    try
                    {
                        return await client.GetStringAsync(url);
                    }
                    catch
                    {
                    }
                    await Task.Delay(nextdelay);
                    nextdelay += nextdelay;
                }
                //重试一遍调用者知道信息
                return await client.GetStringAsync(url);
            }
        }
        public async Task<string> Downloadwithtimeout(string url)
        {
            //如果在10秒内无响应就返回null
            using (var client=new HttpClient())
            {
                var task = client.GetStringAsync(url);
                var timeout = Task.Delay(10000);
                var downtask=await Task.WhenAny(task, timeout);
                if (downtask == timeout)
                    return null;
                return await task;
            }
        }
    }
}
