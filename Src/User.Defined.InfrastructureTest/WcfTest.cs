using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using User.Defined.Infrastructure.Wcf;
using User.Defined.SimpleService;

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
            WcfInvokeFactory.Invoke<IIHelloService>(url, helloService =>
            {
                result = helloService.DoWork();
            });
            return proxy.DoWork();

        }

        public static void Invoke<TClient>(Action<TClient> act)
          where TClient : System.ServiceModel.ICommunicationObject, new()
        {
            TClient client = new TClient();
            try
            {
                act(client);
                client.Close();
            }
            catch (System.ServiceModel.CommunicationException)
            {
                client.Abort();
            }
            catch (TimeoutException)
            {
                client.Abort();
            }
            catch (Exception)
            {
                client.Abort();
                throw;
            }
        }
    }
}
