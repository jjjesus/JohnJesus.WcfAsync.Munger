using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;


namespace JohnJesus.WcfAsync.Munger.Client
{
    public class MungerClient
    {
        private MungerContractClient client;

        public MungerClient()
        {
            this.client = new MungerContractClient(
					new NetTcpBinding (),
                    new EndpointAddress("net.tcp://localhost:9999"));
        }

        public void Run()
        {
            uint numerator = 248;
            uint denominator = 12;

            client.DivideCompleted += new EventHandler<DivideCompletedEventArgs>(DivideCallback);
            client.DivideAsync(numerator, denominator);
            Console.WriteLine("Divide {0} by {1}", numerator, denominator);

            Console.WriteLine("Hit ENTER to exit this program");
            Console.ReadLine();
            client.Close();
        }

        static void DivideCallback(object sender, DivideCompletedEventArgs e)
        {
            Console.WriteLine("Divide Result: {0}", e.Result);
        }
    }
}
