using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Infrastucture.Notification
{
    public class EmailPayload
    {
        public string  Email { get; set; }
        public string  Subject { get; set; }
        public string  Message { get; set; }
        public string  ccEmail { get; set; }
        public string  FilePath { get; set; }
    }

    public class SmsPayload
    {

    }

    public class EmailMessagePayload
    {
        public string From { get; set; }
        public string Message { get; set; }
        public string[] To { get; set; }
    }
    public class ResultListPayload
    {
        public SMSResultPayload[] messages { get; set; }
    }

    public class SMSResultPayload
    {
        public string to { get; set; }
        public int smsCount { get; set; }
        public string messageId { get; set; }
        public string audioFileUrl { get; set; }
        public string language { get; set; }
        public string submitTime { get; set; }
        public StatusPayload status { get; set; }
        public StatusPayload error { get; set; }
    }

    public class StatusPayload
    {
        public string groupId { get; set; }
        public string groupName { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool? permanent { get; set; }
        public string action { get; set; }
    }
}
