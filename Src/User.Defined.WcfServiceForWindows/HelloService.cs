using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using User.Defined.Interface;

namespace User.Defined.SimpleService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“IHelloService”。
    public class HelloService : IIHelloService
    {
        public string DoWork()
        {
            return "HelloWorld";
        }
        public string GetName()
        {
            return "ZhangSan";
        }
        public string GetSex()
        {
            return "Male";
        }
    }
}
