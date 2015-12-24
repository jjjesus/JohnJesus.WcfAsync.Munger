using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

using JohnJesus.WcfAsync.Munger;
using System.ServiceModel.Description;

namespace JohnJesus.WcfAsync.Munger.Server
{
    public class MungerServiceHost
    {
        private System.Threading.AutoResetEvent stopFlag = new System.Threading.AutoResetEvent(false);
        private static MungerServiceHost _instance;

        private ServiceHost _svcHost;

        public static MungerServiceHost Instance()
        {
            if (_instance == null)
            {
                _instance = new MungerServiceHost();
                _instance._svcHost = new ServiceHost(typeof(MungerService));
            }
            return _instance;
        }

        public void Run()
        {
            this._svcHost.AddServiceEndpoint(
                typeof(JohnJesus.WcfAsync.Munger.IMungerContract),
                new NetTcpBinding(),
                "net.tcp://localhost:9999");

            // Add a metadata exchange (MEX) endpoint
            //
            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            this._svcHost.Description.Behaviors.Add(behavior);
            this._svcHost.AddServiceEndpoint(
                typeof(IMetadataExchange),
                MetadataExchangeBindings.CreateMexTcpBinding(),
                "net.tcp://localhost:9999/service/mex");

            this._svcHost.Open();

            Console.WriteLine("SERVER - Running ...");

            // Block until someone calls Stop()
            this.stopFlag.WaitOne();

            Console.WriteLine("SERVER - Shutting Down ...");
            this._svcHost.Close();
            Console.WriteLine("SERVER - Shut Down!");
        }
        public void Stop()
        {
            this.stopFlag.Set();
        }
    }

}
