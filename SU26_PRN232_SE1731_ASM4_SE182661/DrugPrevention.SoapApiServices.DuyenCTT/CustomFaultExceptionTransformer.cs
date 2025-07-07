using SoapCore.Extensibility;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Xml;

namespace DrugPrevention.SoapApiServices.DuyenCTT
{
    public class CustomFaultExceptionTransformer : IFaultExceptionTransformer
    {
        public Message ProvideFault(Exception exception, MessageVersion messageVersion, Message requestMessage, XmlNamespaceManager xmlNamespaceManager)
        {
            var faultException = Transform(exception, messageVersion);
            MessageFault fault = faultException.CreateMessageFault();

            return Message.CreateMessage(messageVersion, faultException.Action);
        }

        public FaultException Transform(Exception exception, MessageVersion messageVersion)
        {
            // Customize the message or wrap based on the exception
            return new FaultException("An internal server error occurred.");
        }
    }
}
