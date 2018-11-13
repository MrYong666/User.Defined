using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SimpleService;
using Newtonsoft.Json;

namespace SunService
{
    public partial class MyService : ServiceBase
    {
        ServiceHost host = new ServiceHost(typeof(HelloService));
        public MyService()
        {
            InitializeComponent();
        }
        string filePath = @"D:\MyServiceLog.txt";

        protected override void OnStart(string[] args)
        {
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Append))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine($"{DateTime.Now},服务启动前！");
                }
                host.Open();
                using (FileStream stream = new FileStream(filePath, FileMode.Append))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine($"{DateTime.Now},服务启动后！");
                }
            }
            catch (Exception ex)
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Append))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine($"{DateTime.Now};ErrorMsg:{JsonConvert.SerializeObject(ex)},服务启动异常！");
                }
            }
        }

        protected override void OnStop()
        {
            try
            {
                host.Close();
            }
            catch (Exception ex)
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Append))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine($"{DateTime.Now};ErrorMsg:{JsonConvert.SerializeObject(ex)},服务停止异常！");
                }
            }
        }
    }
}
