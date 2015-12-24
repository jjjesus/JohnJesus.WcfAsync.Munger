using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

using JohnJesus.WcfAsync.Munger;
using System.Threading.Tasks;

namespace JohnJesus.WcfAsync.Munger.Server
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class MungerService : IMungerContract
    {
        public uint Numerator { get; set; }
        public uint Denominator { get; set; }

        public IAsyncResult BeginDivide(uint numerator, uint denominator, AsyncCallback callback, object state)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
            try
            {
                var myTask = Task<uint>.Factory.StartNew(this.doDivide, state);
                return myTask.ContinueWith(taskResult => callback(myTask));
            }
            catch (DivideByZeroException)
            {
                throw new FaultException<MungerFault>(new MungerFault { Message = "Undefined result" });
            }
        }

        public uint EndDivide(IAsyncResult asyncResult)
        {
            // if an exception occurred in the worker, it shows up here
            return ((Task<uint>)asyncResult).Result;
        }

        private uint doDivide(object state)
        {
            return Numerator / Denominator;
        }
    }
}
