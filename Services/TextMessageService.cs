using SweetTextV2.Models;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SweetTextV2.Services
{
    public class TextMessageService : ITextMessageService
    {
        public void SendTextMessage(IMessage message)
        {
            var toPhoneNumber = message.GetType() == typeof(EmptyMessage) ? ConfigurationManager.AppSettings["TwilioToPhoneNumberEmpty"] :
                ConfigurationManager.AppSettings["TwilioToPhoneNumber"];

            TwilioClient.Init(ConfigurationManager.AppSettings["TwilioAccountSID"], ConfigurationManager.AppSettings["TwilioAuthToken"]);
            MessageResource.Create(
             new PhoneNumber(toPhoneNumber),
             from: new PhoneNumber(ConfigurationManager.AppSettings["TwilioFromPhoneNumber"]),
             body: message.Message
            );
        }
    }
}