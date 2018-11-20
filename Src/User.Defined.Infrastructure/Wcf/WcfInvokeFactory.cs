using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using User.Defined.Infrastructure.Nlog;

namespace User.Defined.Infrastructure.Wcf
{
    public class WcfInvokeFactory
    {
        #region  CreateService
        public static T CreateServiceByUrl<T>(string url)
        {
            return CreateServiceByUrl<T>(url, "basicHttpBinding");
        }
        private static T CreateServiceByUrl<T>(string url, string bing)
        {
            try
            {
                if (string.IsNullOrEmpty(url)) throw new NotSupportedException("This url is not Null or Empty!");
                EndpointAddress address = new EndpointAddress(url);
                Binding binding = CreateBinding(bing);
                ChannelFactory<T> factory = new ChannelFactory<T>(binding, address);
                return factory.CreateChannel();
            }
            catch (Exception ex)
            {
                throw new Exception("创建服务工厂出现异常.");
            }
        }
        #endregion

        #region Invoke
        public static void Invoke<T>(string url, Action<T> method)
        {
            ChannelFactory<T> client = WcfInvokeFactory.CreateChannelByUrl<T>(url);
            try
            {
                method(client.CreateChannel());
                client.Close();
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                client.Abort();
                LoggerWrapper.Error(ex.Message);
            }
            catch (TimeoutException ex)
            {
                client.Abort();
                LoggerWrapper.Error(ex.Message);
            }
            catch (Exception ex)
            {
                client.Abort();
                LoggerWrapper.Error(ex.Message);
            }
        }
        #endregion

        #region CreateChannel
        private static ChannelFactory<T> CreateChannelByUrl<T>(string url)
        {
            return GetChannelFactory<T>(url, "basicHttpBinding");
        }
        private static ChannelFactory<T> GetChannelFactory<T>(string url, string bing)
        {
            try
            {
                if (string.IsNullOrEmpty(url)) throw new NotSupportedException("This url is not Null or Empty!");
                EndpointAddress address = new EndpointAddress(url);
                Binding binding = CreateBinding(bing);
                return new ChannelFactory<T>(binding, address);
            }
            catch (Exception ex)
            {
                throw new Exception("创建服务工厂出现异常.");
            }
        }
        #endregion

        #region 创建传输协议
        /// <summary>
        /// 创建传输协议
        /// </summary>
        /// <param name="binding">传输协议名称</param>
        /// <returns></returns>
        private static Binding CreateBinding(string binding)
        {
            Binding bindinginstance = null;
            if (binding.ToLower() == "basichttpbinding")
            {
                BasicHttpBinding ws = new BasicHttpBinding();
                ws.MaxBufferSize = 2147483647;
                ws.MaxBufferPoolSize = 2147483647;
                ws.MaxReceivedMessageSize = 2147483647;
                ws.ReaderQuotas.MaxStringContentLength = 2147483647;
                ws.CloseTimeout = new TimeSpan(0, 30, 0);
                ws.OpenTimeout = new TimeSpan(0, 30, 0);
                ws.ReceiveTimeout = new TimeSpan(0, 30, 0);
                ws.SendTimeout = new TimeSpan(0, 30, 0);

                bindinginstance = ws;
            }
            else if (binding.ToLower() == "nettcpbinding")
            {
                NetTcpBinding ws = new NetTcpBinding();
                ws.MaxReceivedMessageSize = 65535000;
                ws.Security.Mode = SecurityMode.None;
                bindinginstance = ws;
            }
            else if (binding.ToLower() == "wshttpbinding")
            {
                WSHttpBinding ws = new WSHttpBinding(SecurityMode.None);
                ws.MaxReceivedMessageSize = 65535000;
                ws.Security.Message.ClientCredentialType = System.ServiceModel.MessageCredentialType.Windows;
                ws.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Windows;
                bindinginstance = ws;
            }
            return bindinginstance;

        }
        #endregion
    }
}
