using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunWcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SunWcfClient.ServiceReference1.ISunCalculateClient tc = new ServiceReference1.ISunCalculateClient();
            var ddd = tc.DoWork("调用wcf服务成功了!");
        }
    }
}
