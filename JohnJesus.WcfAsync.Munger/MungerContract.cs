using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JohnJesus.WcfAsync.Munger
{
    [DataContract]
    public class MungerFault
    {
        [DataMember]
        public string Message { get; set; }
    }

    [ServiceContract]
    public interface IMungerContract
    {
        // Synchronous equivalent:
        //  [OperationContract]
        //  [FaultContract(typeof(CalculatorFault))]
        //  uint Divide(uint numerator, uint denominator);
        [OperationContract(AsyncPattern = true)]
        [FaultContract(typeof(MungerFault))]
        IAsyncResult BeginDivide(uint numerator, uint denominator, AsyncCallback callback, object state);

        // Note: There is no OperationContractAttribute for the End method
        uint EndDivide(IAsyncResult asyncResult);


    }
}
