using DayOut.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace DayOut.Models
{
    public static class SMS
    {
        public static void SendNextStopMessage(Customer customer, Place choice)
        {
            const string accountSid = APIKey.TwilioAccountSID;
            const string authToken = APIKey.TwilioAuthToken;
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Your next stop is in 30 minutes. You will be heading to " + choice.Name + ". At " + choice.Address + " https://www.google.com/maps/place/?q=place_id:" + choice.PlaceId,
                from: new Twilio.Types.PhoneNumber(APIKey.TwilioPhoneNumber),
                to: new Twilio.Types.PhoneNumber("+1" + customer.PhoneNumber)
            );
            Console.WriteLine(message.Sid);

        }
        public static void SendWelcomeMessage(Customer customer)
        {
            const string accountSid = APIKey.TwilioAccountSID;
            const string authToken = APIKey.TwilioAuthToken;
            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(
                body: "Welcome to DayOut! We're always happy to have a new d'Outer looking for something fun to do. We hope you enjoy your DayOut!",
                from: new Twilio.Types.PhoneNumber(APIKey.TwilioPhoneNumber),
                to: new Twilio.Types.PhoneNumber("+1" + customer.PhoneNumber)
            );
            Console.WriteLine(message.Sid);
        }
        public static void SendStartDayOutMessage(Customer customer, Place choice)
        {
            const string accountSid = APIKey.TwilioAccountSID;
            const string authToken = APIKey.TwilioAuthToken;
            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(
                body: "Looks like a great DayOut! Enjoy your first stop at " + choice.Name,
                from: new Twilio.Types.PhoneNumber(APIKey.TwilioPhoneNumber),
                to: new Twilio.Types.PhoneNumber("+1" + customer.PhoneNumber)
            );
            Console.WriteLine(message.Sid);
        }
    }
}
