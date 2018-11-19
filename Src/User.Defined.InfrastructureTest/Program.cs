using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Defined.Infrastructure.Nlog;

namespace User.Defined.InfrastructureTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            LoggerWrapper.Debug("dddddddddd");
            LoggerWrapper.Error("dddddddddd");
        }
    }
}
