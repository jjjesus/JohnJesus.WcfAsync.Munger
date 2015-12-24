using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JohnJesus.WcfAsync.Munger.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = MungerServiceHost.Instance();
            host.Run();
        }
    }
}
