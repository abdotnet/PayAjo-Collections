using Newtonsoft.Json;
using PayAjo.Domain.Infrastucture.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PayAjo.Domain.Infrastucture.Notification
{
    public class SmsNotification : ISmsNotify
    {
        private string _username;
        private string _password;
        private string _smsinfobipcredential;
        private string _smslivecredentials;
        private string _sendername;

        #region SMS Sender ..
        public SmsNotification()
        {
            _smsinfobipcredential = "";
            _smslivecredentials = "";
            _sendername = "";
        }

        public Operation<bool> SendSMS(string phoneNumber, string _message)
        {
            return Operation.Create(() =>
            {
                string _host = "";
                string _owneremail = "";
                string _subacct = "";
                string _subacctpwd = "";

                foreach (string data in _smslivecredentials.Split('|'))
                {
                    if (data.Split('*')[0].ToLower() == "host") _host = data.Split('*')[1];
                    if (data.Split('*')[0].ToLower() == "uname") _subacct = HttpUtility.UrlEncode(data.Split('*')[1]);
                    if (data.Split('*')[0].ToLower() == "pwd") _subacctpwd = HttpUtility.UrlEncode(data.Split('*')[1]);
                    if (data.Split('*')[0].ToLower() == "owneremail") _owneremail = HttpUtility.UrlEncode(data.Split('*')[1]);
                }

                string message = HttpUtility.UrlEncode(_message);
                string sendto = HttpUtility.UrlEncode(phoneNumber);

                string URI =
                    string.Format("{0}&owneremail={1}&subacct={2}&subacctpwd={3}&message={4}&sendto={5}&sender={6}",
                                _host, _owneremail, _subacct, _subacctpwd, message, HttpUtility.UrlEncode(phoneNumber), _sendername);

                using (System.Net.WebClient client = new System.Net.WebClient())
                {

                    string answer = client.UploadString(new Uri(URI), "GET");
                    if (answer.ToLower().Contains("ok"))
                    {
                        return true;
                    }
                    return false;
                }

            });
        }

        public Operation<bool> SendSMS_InfoBip(string[] phoneNumber, string message, string from = "PayAjo.com")
        {
            return Operation.Create(() =>
            {
                string _host = "";
                string _single = "";
                foreach (string data in _smsinfobipcredential.Split('|'))
                {
                    if (data.Split('*')[0].ToLower() == "host") _host = data.Split('*')[1];
                    if (data.Split('*')[0].ToLower() == "uname") _username = data.Split('*')[1];
                    if (data.Split('*')[0].ToLower() == "pwd") _password = data.Split('*')[1];
                    if (data.Split('*')[0].ToLower() == "single") _single = data.Split('*')[1];
                }

                return SingleSMS(new EmailMessagePayload { From = from, To = phoneNumber, Message = message }, _host + _single);
            });
        }

        public Operation<bool> SendMulitpleSMS_InfoBip(string[][] phoneNumber, string[] message)
        {
            return Operation.Create(() =>
            {
                string _host = "";
                string _multi = "";
                foreach (string data in _smsinfobipcredential.Split('|'))
                {
                    if (data.Split('*')[0].ToLower() == "host") _host = data.Split('*')[1];
                    if (data.Split('*')[0].ToLower() == "uname") _username = data.Split('*')[1];
                    if (data.Split('*')[0].ToLower() == "pwd") _password = data.Split('*')[1];
                    if (data.Split('*')[0].ToLower() == "multi") _multi = data.Split('*')[1];
                }

                var payload = new List<EmailMessagePayload>();
                for (int i = 0; i < phoneNumber.Length; i++)
                {
                    payload.Add(new EmailMessagePayload { To = phoneNumber[i], From = _sendername, Message = message[i] });
                }
                return MultipleSMS(payload, _host + _multi);
            });
        }

        private bool SingleSMS(EmailMessagePayload requests, string url)
        {
            using (var client = new WebClient())
            {
                DisableSSLTrust();

                //set headers
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers[HttpRequestHeader.Accept] = "application/json, text/javascript, */*; q=0.01";

                client.Headers[HttpRequestHeader.Authorization] = $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes(_username + ":" + _password))}";

                var data = JsonConvert.SerializeObject(requests);
                var result = JsonConvert.DeserializeObject<ResultListPayload>(client.UploadString(url, "POST", data));

                return true;
            }
        }

        private bool MultipleSMS(List<EmailMessagePayload> requests, string url)
        {
            using (var client = new WebClient())
            {
                DisableSSLTrust();

                //set headers
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers[HttpRequestHeader.Accept] = "application/json, text/javascript, */*; q=0.01";
                client.Headers[HttpRequestHeader.Authorization] = $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes(_username + ":" + _password))}";

                var data = JsonConvert.SerializeObject(requests);
                var result = JsonConvert.DeserializeObject<ResultListPayload>(client.UploadString(url, "POST", data));

                return true;
            }
        }

        private void DisableSSLTrust()
        {
            try
            {
                //Change SSL checks so that all checks pass
                ServicePointManager.ServerCertificateValidationCallback = (s, cert, chain, errors) => true;
            }
            catch { }
        }


        #endregion
    }
}
