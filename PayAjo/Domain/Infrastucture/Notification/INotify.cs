using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Infrastucture.Email
{
    public interface IEmailNotify
    {
        Operation SendEmail(string email, string subject, string message, string ccEmail = null, string filePath = null);
        Operation SendEmail(string[] email, string subject, string message, string ccEmail = null, string filePath = null);
    }


    public interface ISmsNotify
    {
        Operation<bool> SendSMS(string phoneNumber, string message);
        Operation<bool> SendSMS_InfoBip(string[] phoneNumber, string message, string from = "PayAjo.com");
        Operation<bool> SendMulitpleSMS_InfoBip(string[][] phoneNumber, string[] message);
    }
}
