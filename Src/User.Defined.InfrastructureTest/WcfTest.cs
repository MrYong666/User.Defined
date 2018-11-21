using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using User.Defined.Infrastructure.Wcf;
using User.Defined.Interface;

namespace User.Defined.InfrastructureTest
{
    public class WcfTest
    {
        public static string GetWcfMethod()
        {
            string result = string.Empty;
            string url = "http://127.0.0.1:8888/HelloService/";
            //第一种方式
            IIHelloService proxy = WcfInvokeFactory.CreateServiceByUrl<IIHelloService>(url);
            //第二种方式
            // ChannelFactory<IIHelloService> ddd = WcfInvokeFactory.GetChannelFactory11<IIHelloService>(url);
            //第三种方式
            WcfInvokeFactory.Invoke<IIHelloService>(url, wcfService =>
            {
                result = wcfService.DoWork();
                var name = wcfService.GetName();
                var sex = wcfService.GetSex();
            });
            return proxy.DoWork();

        }
    }
}
