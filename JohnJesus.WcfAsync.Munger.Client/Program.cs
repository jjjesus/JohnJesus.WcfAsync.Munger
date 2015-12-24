using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JohnJesus.WcfAsync.Munger.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MungerClient();
            client.Run();
        }
    }
}
