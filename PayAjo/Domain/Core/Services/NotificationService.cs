using Microsoft.Extensions.Configuration;
using PayAjo.Data;
using PayAjo.Data.Entities;
using PayAjo.Domain.Core.Interfaces;
using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using static PayAjo.Domain.Infrastucture.Constants;

namespace PayAjo.Domain.Core.Services
{
  /// <summary>
  /// Notification service  ..
  /// </summary>
  public class NotificationService : INotificationService
  {
    private IConfiguration _config;
    private readonly PayAjoContext _repo;
    private readonly ITransactionService _service;
    private TransactionModel transModel;


    /// <summary>
    /// Notification service
    /// </summary>
    /// <param name="config"></param>
    /// <param name="repo"></param>
    /// <param name="service"></param>
    public NotificationService(IConfiguration config, PayAjoContext repo, ITransactionService service)
    {
      _config = config;
      _repo = repo;
      _service = service;
    }
    /// <summary>
    ///
    /// </summary>
    public NotificationService()
    {
    }

    #region Sms Notification

    /// <summary>
    ///  Send sms notification .
    /// </summary>
    /// <param name="phoneNos"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public Operation SendSms(string[] phoneNos, string message)
    {
      return Operation.Create(() =>
      {
        string apiKey = _config["Notify:api"];
        string sender = _config["Notify:sender"];
        string msgtype = "text";
        string delivery = "yes";
        string username = "abudotnet@gmail.com";
        string password = "@Omolaja1";
        string msg = HttpUtility.UrlEncode(message);
        // 2501|2348154336442|45625|DELIVERED,2501|2348030000001|45625|NOT_DELIVERED,250
        // 1 | 2348050000001 | 45625 | MESSAGE_SENT,2501 | 2348090000001 | 45625 | MESSAGE_SENT
        var url = string.Format("{0}apikey={1}&sender={2}&recipient={3}&message={4}&msgtype={5}&delivery={6}", "http://api.ibulky.com/sendsms/?", apiKey, sender, string.Join(',', phoneNos), msg, msgtype, delivery);

        var url2 = string.Format("{0}username={1}&password={2}&sender={3}&recipient={4}&message={5}&msgtype={6}&delivery={7}", "http://api.ibulky.com/sendsms/?", username, password, sender, string.Join(',', phoneNos), "This %20 is20a % 20Demo % 20Message!!!", msgtype, delivery);
        //apikey

        var url3 = string.Format("{0}username={1}&password={2}&apikey={3}&sender={4}&recipient={5}&message={6}&msgtype={7}&delivery={8}", "http://api.ibulky.com/sendsms/?", username, password, apiKey, sender, string.Join(',', phoneNos), "This %20 is20a % 20Demo % 20Message!!!", msgtype, delivery);
        //apikey

        //var url4 = string.Format($@"https://lamydas.com.ng/ls_bulksms/index.php?option=com_spc&comm=spc_api&username=abudotnet&password=@Omolaja1&sender=@@{sender}@@&recipient =@@{string.Join(',', phoneNos)}@@&message =@@{message}@@&");

        var url4 = string.Format($@"https://lamydas.com.ng/ls_bulksms/index.php?option=com_spc&comm=spc_api&username=abudotnet&password=@Omolaja1&sender={sender}&recipient={string.Join(',', phoneNos)}&message={message}");

        //HttpUtility.UrlEncode

        string userName = HttpUtility.UrlEncode("abudotnet"); //Your reg username
        string subUser = HttpUtility.UrlEncode("abudotnetsub"); //Sub account user
        string subPass = HttpUtility.UrlEncode("abudotnetsub"); //Sub account password
        string proxy = "";  //If connecting via a proxy, enter it here




        string url_getSession = string.Format("http://www.lamydas.com.ng/smsClients/index.php?ls=checkLogin&main_uname={0}&subacct_uname={1}&subacct_upass={2}", userName, subUser, subPass);

        //.($login->userName)."&subacct_uname=".urlencode($login->subUser). "&subacct_upass=".urlencode($login->subPass);

        string sessionID = string.Empty;
        using (System.Net.WebClient client = new System.Net.WebClient())
        {

          string response = client.UploadString(new Uri(url_getSession), "GET");

          if (response.Substring(0, 4) == "1000")
          {
            sessionID = response.Split('|')[1];
          }
        }

        if (!string.IsNullOrEmpty(sessionID))
          sessionID = sessionID.Trim();

        string url_send = string.Format("http://www.lamydas.com.ng/smsClients/index.php?ls=sendOut&sessionid={0}&message={1}&senderid={2}&numbers={3}&msgtype={4}", HttpUtility.UrlEncode(sessionID), HttpUtility.UrlEncode(message), HttpUtility.UrlEncode(sender), HttpUtility.UrlEncode(string.Join(',', phoneNos)), HttpUtility.UrlEncode("0"));

        //. $this->sessionID. "&message=".urlencode($smsMessage). "&senderid=".urlencode($smsSender). "&numbers=".urlencode($smsReceiver). "&msgtype=0");

        string msg_response = string.Empty;

        using (System.Net.WebClient client = new System.Net.WebClient())
        {

          string response = client.UploadString(new Uri(url_send), "GET");

          string result = response.Split(' ')[0];

          if (!string.IsNullOrEmpty(result) && result.ToLower().Contains("ok"))
            msg_response = GetErrorDescription("OK");
          else
          {
            msg_response = GetErrorDescription(result);
          }
          //if (!string.IsNullOrEmpty(answer) && answer.ToUpper().Contains("MESSAGE_SENT"))
          //{
          //  return true;
          //}
          return msg_response;
        }

      });
    }

    /// <summary>
    ///  Get error description ...
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public string GetErrorDescription(string error)
    {
      string error_msg = string.Empty;

      if (error == "OK")
        error_msg = "Message Submitted Successfully";
      else if (error == "100")
        error_msg = "SMS Sending Failed: " + error;
      else if (error == "401")
        error_msg = "Invalid sessionID: " + error;
      else if (error == "402")
        error_msg = "Invalid Sub-Account or Password: " + error;
      else if (error == "403")
        error_msg = "Invalid Recharge Voucher code: " + error;
      else if (error == "404")
        error_msg = "Insufficient Credit: " + error;
      else if (error == "407")
        error_msg = "Forbidden/Access Denied: " + error;
      else if (error == "408")
        error_msg = "Data supplied is not in expected format: " + error;
      else if (error == "409")
        error_msg = "Gateway Error: " + error;
      else if (error == "410")
        error_msg = "Account is disabled: " + error;
      else
        error_msg = "Not Connected to the internet";

      return error_msg;
    }

    ////Query Balance
    //function queryBalance()
    //{
    //    //die("entered");
    //    //$login = new smsLogin();
    //    $smsSender = new smsSender();
    //  if ($smsSender) {
    //        $url = "http://www.lamydas.com.ng/smsClients/index.php?ls=queryBalance&sessionid=". $this->sessionID;
    //        //die("$url");
    //        $response = $this->sendRequest($url);
    //    if (substr($response, 0, 4) == "1701")
    //    {
    //            $response = explode("|", $response);
    //            $response = trim(end($response));
    //      if (empty($response))
    //                $response = "0";
    //            $this->error = "";
    //      return $response;
    //    }
    //    else
    //    {
    //            $response = explode("|", $response);
    //            $response = end($response);
    //            $response = !empty($response) ? $response: "0";
    //            $this->error = $response;
    //      return $response;
    //    }//else return $response = "0"; // end if
    //  } // end function
    //}

    //public Operation SendSmsKudi(string[] phoneNos, string message, string sender = "PayAjo")
    //{
    //  return Operation.Create(() =>
    //  {

    //    Task.Run(() =>
    //    {
    //      string user = "abudotnet@gmail.com";
    //      string password = "@Omolaja1";
    //      // string sender = _config["Notify:sender"];

    //      string url = string.Format("https://account.kudisms.net/api/?username={0}&password={1}&message={2}&sender={3}&mobiles={4}", HttpUtility.UrlEncode(user), HttpUtility.UrlEncode(password), HttpUtility.UrlEncode(message), HttpUtility.UrlEncode(sender), HttpUtility.UrlEncode(string.Join(',', phoneNos)));
    //      string msg_response = string.Empty;

    //      using (System.Net.WebClient client = new System.Net.WebClient())
    //      {

    //        string response = client.UploadString(new Uri(url), "GET");

    //        if (!string.IsNullOrEmpty(response) && response.ToLower().Contains("ok"))
    //          msg_response = GetErrorDescription("OK");
    //        else
    //        {
    //          msg_response = GetErrorDescription(response);
    //        }

    //        return msg_response;
    //      }

    //    });

    //  });
    //}
    /// <summary>
    /// Expectation is to run background job to fire every item on notification table
    /// </summary>
    /// <returns></returns>
    public Operation SendSmsKudiJob()
    {
      return Operation.Create(() =>
      {

        string user = "abudotnet@gmail.com";
        string password = "@Omolaja1";
        // string sender = _config["Notify:sender"];

        var notify = _repo.Notification.Where(c => !c.IsNotify).ToList();
        string url = string.Empty;
        string msg_response = string.Empty;
        string response = string.Empty;
        int count = 0;

        //user = HttpUtility.UrlEncode(user);
        //password = HttpUtility.UrlEncode(password);
        //HttpUtility.UrlEncode(item.Message);
        //HttpUtility.UrlEncode(item.Sender),
        //HttpUtility.UrlEncode(string.Join(',', item.Recipient))
        foreach (var item in notify)
        {
          response = string.Empty;

          url = string.Format("https://account.kudisms.net/api/?username={0}&password={1}&message={2}&sender={3}&mobiles={4}", user, password, HttpUtility.UrlEncode(item.Message), item.Sender, string.Join(',', item.Recipient));
          using (System.Net.WebClient client = new System.Net.WebClient())
          {
            try
            {
              response = client.UploadString(new Uri(url), "GET");
            }
            catch (Exception ex)
            {
              Debug.Write(ex.Message);
              Log.Information(ex.Message);
            }


            if (!string.IsNullOrEmpty(response) && response.ToLower().Contains("ok"))
            {
              msg_response = GetErrorDescription("OK");
              count++;
            }
            else
            {
              msg_response = GetErrorDescription(response);
            }

            if (!string.IsNullOrEmpty(response) && response.ToLower().Contains("ok"))
            {
              item.IsNotify = true;
              _repo.Notification.Update(item);
            }
          }

        }
        // update all sent notifications..
        if (count > 0) _repo.SaveChanges();


      });
    }

    public Operation PushSms((long CustomerId, string TransactionNo, long CreatedBy) model, decimal amount, string transactionType)
    {
      return Operation.Create(() =>
      {
        var customer = (from c in _repo.Customer
                        join m in _repo.Merchant on c.MerchantId equals m.MerchantId
                        join cb in _repo.CustomerBalance on c.CustomerId equals cb.CustomerId
                        where c.CustomerId == model.CustomerId
                        select new { c, cb, m }).FirstOrDefault();


        if (customer != null)
        {
          string content = $@"Acct: { customer.c.CustomerCode},  DT: { DateTime.Now.ToUniversalTime()},  { transactionType} Amt: { amount}Bal:{customer.cb.CurrentBalance},REF: { model.TransactionNo}";

          //var op = _notify.SendSmsKudi(new string[] { customer.c.Mobile }, $"Code: {customer.c.CustomerCode},DT:{DateTime.Now.ToUniversalTime()},S:{customer.m.Name} {transactionType}: {amount} Bal:{customer.cb.CurrentBalance},REF:{model.TransactionNo}", customer.m.Name);

          var notify = new Notification()
          {
            Message = content,
            Sender = customer.m.MerchantCode,
            CreatedBy = model.CreatedBy,
            CreatedDate = DateTime.UtcNow,
            NotificationSystem = NotificationSystem.Transacition,
            NotificationType = NotificationType.Sms,
            Recipient = customer.c.Mobile,
            SendToUserId = model.CreatedBy,
          };
          _repo.Notification.Add(notify);
          _repo.SaveChanges();

          // SendEBulkSms(notify.Sender.Substring(0, 10), notify.Message, new string[] { notify.Recipient }, flash: 0);

        }
      });
    }

    /// <summary>
    /// Save Sms
    /// </summary>
    /// <param name="message"></param>
    /// <param name="sender"></param>
    /// <param name="createdBy"></param>
    /// <param name="recipient"></param>
    /// <param name="customerId"></param>
    /// <param name="merchantId"></param>
    /// <param name="cost"></param>
    /// <param name="status"></param>
    /// <param name="totalSent"></param>
    /// <returns></returns>
    public async Task SaveSms(string message, string sender, long createdBy, string recipient, long customerId,
      long merchantId, string cost, string status, string totalSent)
    {


      var notify = new Notification()
      {
        Message = message,
        Sender = sender,
        CreatedBy = createdBy,
        CreatedDate = DateTime.UtcNow.AddDays(-1),
        NotificationSystem = NotificationSystem.Transacition,
        NotificationType = NotificationType.Sms,
        Recipient = recipient,
        SendToUserId = createdBy,
        CustomerId = customerId,
        MerchantId = merchantId,
        Cost = string.IsNullOrEmpty(cost) ? 0 : int.Parse(cost),
        IsNotify = status == "SUCCESS" ? true : false,
        TotalMessageSent = (string.IsNullOrEmpty(totalSent)) ? 0 : int.Parse(totalSent)
      };
      _repo.Notification.Add(notify);

      await _repo.SaveChangesAsync();

    }

    /// <summary>
    /// Send Sms Kudi
    /// </summary>
    /// <param name="phoneNo"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public Operation SendSmsKudi(string[] phoneNo, string message)
    {
      return Operation.Create(() =>
      {

        string user = "abudotnet@gmail.com";
        string password = "@Omolaja1";
        string msg_response;
        int count = 0;
        string sender = "PayAjo";

        message = HttpUtility.UrlEncode(message);
        // password = HttpUtility.UrlEncode(password);
        // user = HttpUtility.UrlEncode(user);
        // sender = HttpUtility.UrlEncode(sender);
        string mobile = string.Join(',', phoneNo);
        // mobile = HttpUtility.UrlEncode(mobile);
        string url = string.Format("https://account.kudisms.net/api/?username={0}&password={1}&message={2}&sender={3}&mobiles={4}", user, password, message, sender, mobile);

        using (System.Net.WebClient client = new System.Net.WebClient())
        {

          var response = client.UploadString(new Uri(url), "GET");

          if (!string.IsNullOrEmpty(response) && response.ToLower().Contains("ok"))
          {
            msg_response = GetErrorDescription("OK");
            count++;
          }
          else
          {
            msg_response = GetErrorDescription(response);
          }

        }

        return msg_response;
      });
    }

    #endregion

    /// <summary>
    /// Send EBulk Sms
    /// </summary>
    /// <param name="senderName"></param>
    /// <param name="message"></param>
    /// <param name="recipients"></param>
    /// <param name="flash"></param>
    /// <returns></returns>
    public async Task<string> SendEBulkSms(string senderName, string message, string[] recipients, int flash = 0)
    {
      string apiresponse = string.Empty;
      string responseStr = string.Empty;

      try
      {
        string userName = "abudotnet@gmail.com";
        string apiKey = "25f7363b76588379989e3a3bbba1ac1412f572a9";
        senderName = senderName ?? "PayAjo";

        string sms_gateway = $"http://api.ebulksms.com:8080/sendsms?username={userName}&apikey={apiKey}&sender={senderName}&messagetext={message}&flash={flash}&recipients={string.Join(",", recipients)}";

        using (HttpClient client = new HttpClient())
        {
          HttpResponseMessage response = await client.GetAsync(sms_gateway);

          if (response.IsSuccessStatusCode)
          {
            responseStr = await response.Content.ReadAsStringAsync();
          }
          return responseStr;


        }

      }
      catch (Exception e)
      {
        Log.Error(e.Message);
        //Console.WriteLine(e.Message);
      }

      return apiresponse;
    }

    /// <summary>
    /// Send sms notification ...
    /// </summary>
    /// <param name="merchantId"></param>
    /// <returns></returns>
    public Operation SendSmsNotification1([Required]long merchantId)
    {
      return Operation.Create(() =>
      {
        // https://www.ebulksms.com
        // username: abudotnet@gmail.com  || pwd: password1

        // Send Sms for today  ..
        string message = string.Empty;
        string sender = string.Empty;
        string recipient = string.Empty;
        DateTime endDate = DateTime.Now;

        if (merchantId <= 1) throw new Exception("Merchant Id is not correct");

        var merchant = _repo.Merchant.FirstOrDefault(c => c.MerchantId == merchantId);


        if (merchant == null) throw new Exception("merchant not found");

        var transactions = _service.GetTransactionByMerchantId(merchantId);


        var query = _repo.Customer.Where(c => c.MerchantId == merchantId);

        if (query.Count() <= 0) throw new Exception("Customer information not found");

        sender = merchant?.MerchantCode;
        // if (DateTime.Now != merchant.SmsDate) return;

        decimal sum = 0; int counter = 0;
        string transactionNo = string.Empty;
        var lstmsg = new List<string>();
        string transType = string.Empty;

        // get no of dayz in a week MON - FRI
        string smsConfig = _config["System:SmsDays"].ToString();

        // Friday of the week..
        endDate = DateTime.Now.AddDays(-3); //merchant.SmsDate;

        DateTime startDate = endDate.AddDays(-int.Parse(smsConfig));

        if (transactions.Succeeded)
        {
          //var tranList = transactions.Result.Where(c => c.CreatedDate >= startDate &&
          //c.CreatedDate <= endDate && c.Amount > 500 && !c.IsNotified).ToArray();

          var tranList = transactions.Result.Where(c => c.Amount > 500 && !c.IsNotified).ToArray();

          if (tranList.Count() > 0)
          {
            foreach (var item in tranList)
            {

              var _recipient = query.Where(c => c.CustomerId == item.CustomerId)
                .Select(c => new { c.Mobile, c.CustomerCode }).FirstOrDefault();

              // message : DT:9/21/2018 9:48:36 AM, MON:N2,000CR,TUE:N1000DR,WED:N7822,THUR:N2883,FRI:N2782

              message = $"{sender.ToUpper()},ACCT:{_recipient.CustomerCode},DT:{startDate.ToShortDateString()}-{endDate.ToShortDateString()},";

              var cus_tranList = tranList.Where(c => c.CustomerId == item.CustomerId).ToArray();

              counter = 0;
              transactionNo = string.Empty;
              sum = 0;
              // todaySum = 0;
              foreach (var item2 in cus_tranList.OrderBy(c => c.CreatedDate))
              {
                message += $"{item2.CreatedDate.DayOfWeek.ToString().ToUpper().Substring(0, 3)}:N{ item.Amount.ToString("#,##0")}{item.TransactionType} ";
                transactionNo = item2.TransactionNo;
                sum += item.Amount;
                counter++;
              }

              // fix balance
              if (!string.IsNullOrEmpty(transactionNo))
              {
                transType = (sum > 0) ? TransactionType.Credit : TransactionType.Debit;
                message += $" BAL:N{sum.ToString("#,##0")}" + transType;
                message += $" REF:{transactionNo}";
              }

              lstmsg.Add(message);

              //if (counter > 0)
              //{
              //  var response = SendEBulkSms(sender, message, new string[] { _recipient.Mobile }, flash: 0).Result;

              //  if (!string.IsNullOrEmpty(response))
              //  {
              //    if (response.Contains("SUCCESS"))
              //    {
              //      var smsResponse = response.Split('|');
              //      // SUCCESS | totalsent:1 | cost:2
              //      if (string.IsNullOrEmpty(response) || (smsResponse.Length < 1 && smsResponse[0] != "SUCCESS")) continue;

              //      SaveSms(message, sender, 1, _recipient.Mobile, item.CustomerId, item.MerchantId,
              //      smsResponse[2].Split(':')[1], smsResponse[0], smsResponse[1].Split(':')[1]);
              //      //totalsent:1

              //      isSmsSent = true;
              //    }
              //    else
              //    {
              //      if (isSmsSent) _repo.SaveChanges(); // incase there is a failure save notification and update transactions
              //    }
              //  }
              //  else
              //  {
              //    if (isSmsSent) _repo.SaveChanges(); // incase there is a failure save notification and update transactions
              //  }
              //}
            }

            //if (counter > 0 && isSmsSent)
            //{
            //  // reset sms date to next friday ... 
            //  merchant.SmsDate = endDate;
            //  _repo.Merchant.Update(merchant);

            //  _repo.SaveChanges();
            //}
          }
          else
            throw new Exception("There are no transaction for this merchant");
        }
        else
          throw new Exception("Transaction not found for merchant");

      });
    }

    /// <summary>
    /// Send notification Async
    /// </summary>
    /// <param name="merchantId"></param>
    /// <returns></returns>
    public async Task<int> SendSmsNotificationAsync([Required]long merchantId = 2)
    {

      // https://www.ebulksms.com
      // username: abudotnet@gmail.com  || pwd: password1

      // Send Sms for today  ..
      string message = string.Empty;
      string sender = string.Empty;

      decimal sum = 0; int counter = 0;
      string transactionNo = string.Empty;
      //  var lstmsg = new List<string>();
      string transType = string.Empty;
      bool isSmsSent = false;
      long customerId = 0;
      string phoneNo = string.Empty;
      long transactionId = 0;

      // get no of dayz in a week MON - FRI
      var smsConfig = int.Parse(_config["System:SmsDays"].ToString());

      // saturday of the week
      //DateTime startDate = DateTime.Now.AddDays(-int.Parse(smsConfig));
      var merchant = _repo.Merchant.FirstOrDefault(c => c.MerchantId == merchantId);

      if (merchant == null) throw new Exception("Merchant not found");

      DateTime startDate = DateTime.Now.AddDays(-5); // merchant.SmsDate.AddDays(-1 * smsConfig);
      // Friday of the week..
      DateTime endDate = DateTime.Now; //merchant.SmsDate; //DateTime.Now.AddDays(-4);

      //DateTime startDate = DateTime.Now.AddDays(-6);

      //// Friday of the week..
      //DateTime endDate = DateTime.Now; //DateTime.Now.AddDays(-4);



      var query = from cus in _repo.Customer
                  join tran in _repo.Transaction on new { mer = cus.MerchantId, cus = cus.CustomerId }
                equals new { mer = tran.MerchantId, cus = tran.CustomerId.Value }
                  join custBal in _repo.CustomerBalance on cus.CustomerId equals custBal.CustomerId
                  join merBal in _repo.MerchantBalance on cus.MerchantId equals merBal.MerchantId
                  where tran.MerchantId == merchantId && !tran.IsNotified
                  where tran.CreatedDate >= startDate && tran.CreatedDate <= endDate
                  where custBal.CurrentBalance > 500 // merch.MinimumBalance // should be greater than 500 naira
                  where cus.Mobile.Length == 11
                  orderby tran.CreatedDate descending
                  select new NotificationPayload
                  {
                    CustomerCode = cus.CustomerCode,
                    TransactionNo = tran.TransactionNo,
                    TransactionType = tran.TransactionType,
                    EntryDate = tran.CreatedDate,
                    PhoneNo = cus.Mobile,
                    Amount = tran.Amount,
                    CustomerId = cus.CustomerId,
                    TransactionId = tran.Id,
                  };


      bool flag = query.Any();

      //long _counter = 0;
      //if (flag) _counter = query.LongCount();

      //var _query = query.Where(c => c.EntryDate >= startDate && c.EntryDate <= endDate);

      //flag = false;
      //flag = _query.Any();

      if (flag)
      {
        sender = merchant.MerchantCode;
        // looop over the whole list
        var groupTransactions = query.GroupBy(c => c.CustomerCode).ToList();

        foreach (var grouptrans in groupTransactions)
        {
          message = $"{sender.ToUpper()} ,ACCT:{grouptrans.Key} ,DT:{startDate.ToShortDateString()}-{endDate.ToShortDateString()}, ";
          sum = 0;
          foreach (var item in grouptrans)
          {
            // message += $"{item.EntryDate.DayOfWeek.ToString().ToUpper().Substring(0, 3)}:N{ item.Amount.ToString("#,##0")}{item.TransactionType} ";
            message += $"{item.EntryDate.DayOfWeek.ToString().ToUpper().Substring(0, 3)}:" + string.Format("{0}", item.Amount > 0 ? $"N{item.Amount.ToString("#,##0")}" : $"-N{(-1 * item.Amount).ToString("#,##0")}") + $"{item.TransactionType} ";

            transactionNo = item.TransactionNo;
            sum += item.Amount;
            counter++;
            customerId = item.CustomerId;
            phoneNo = item.PhoneNo;
            transactionId = item.TransactionId;
          }

          // if its not in the string add it up  ..
          transType = string.Empty;
          // fix balance
          if (!string.IsNullOrEmpty(transactionNo))
          {
            transType = (sum > 0) ? TransactionType.Credit : TransactionType.Debit;
            message += $" BAL:N{sum.ToString("#,##0")}";
            message += $" REF:{transactionNo}";
          }


          if (counter > 0)
          {
            var response = await SendEBulkSms(sender, message, new string[] { phoneNo }, flash: 0);

            if (!string.IsNullOrEmpty(response))
            {
              if (response.Contains("SUCCESS"))
              {
                var smsResponse = response.Split('|');
                // SUCCESS | totalsent:1 | cost:2
                if (string.IsNullOrEmpty(response) || (smsResponse.Length < 1 && smsResponse[0] != "SUCCESS")) continue;

                //totalsent:1

                var transaction = _repo.Transaction.FirstOrDefault(c => c.Id == transactionId);

                transaction.IsNotified = true;
                transaction.ModifiedDate = DateTime.UtcNow;
                transaction.ModifiedBy = 1;
                transaction.Message = "Sms debit";

                _repo.Transaction.Update(transaction);


                //_repo.Transaction.Add(new Transaction()
                //{
                //  CustomerId = customerId,
                //  MerchantId = merchantId,
                //  TransactionType = TransactionType.Debit,
                //  Amount = -1 * merchant.SmsCost,
                //  CreatedBy = 1,
                //  CreatedDate = DateTime.UtcNow,
                //  ModifiedDate = DateTime.Now,
                //  ModifiedBy = 1,
                //  Message = "Tech Fee Debit",
                //  IsNotified = true,
                //  TransactionNo = new TransactionModel().TransactionNo,
                //});

                await SaveSms(message, sender, 1, phoneNo, customerId, merchantId,
                  smsResponse[2].Split(':')[1], smsResponse[0], smsResponse[1].Split(':')[1]);
                isSmsSent = true;
              }
            }
          }
        }



        if (counter > 0 && isSmsSent)
        {
          // reset sms date to next friday ...
          //var merchant = _repo.Merchant.FirstOrDefault(c => c.MerchantId == merchantId);

          merchant.SmsDate = endDate;
          _repo.Merchant.Update(merchant);

          await _repo.SaveChangesAsync();
        }
      }

      return counter;
    }

    /// <summary>
    /// Send Sms Notification to customers code 
    /// </summary>
    /// <param name="customerCode"></param>
    /// <returns></returns>
    public async Task<int> SendSmsNotificationToCustomerCodeAsync(string customerCode)
    {
      // https://www.ebulksms.com
      // username: abudotnet@gmail.com  || pwd: password1

      if (string.IsNullOrEmpty(customerCode)) throw new Exception("Customer code not found");

      // Send Sms for today  ..
      string message = string.Empty;
      string sender = string.Empty;

      decimal sum = 0; int counter = 0;
      string transactionNo = string.Empty;
      string transType = string.Empty;
      bool isSmsSent = false;
      long customerId = 0;
      string phoneNo = string.Empty;
      long transactionId = 0;
      long merchantId = 0;

      // get no of dayz in a week MON - FRI
      var smsConfig = int.Parse(_config["System:SmsDays"].ToString());

      // saturday of the week
      //DateTime startDate = DateTime.Now.AddDays(-int.Parse(smsConfig));

      var merch_customer = (from merch in _repo.Merchant
                            join cust in _repo.Customer
                            on merch.MerchantId equals cust.MerchantId
                            where cust.CustomerCode == customerCode
                            select new
                            {
                              merch.SmsDate,
                              merch.MerchantId,
                              merch.SmsCost,
                              merch.MinimumBalance,
                              cust.CustomerId,
                              merch.MerchantCode
                            }).FirstOrDefault();

      if (merch_customer == null) throw new Exception("Merchant not found");

      DateTime startDate = merch_customer.SmsDate.AddDays(-1 * smsConfig);

      // Friday of the week..
      DateTime endDate = merch_customer.SmsDate; //DateTime.Now.AddDays(-4);


      var query = from cus in _repo.Customer
                  join tran in _repo.Transaction on new { mer = cus.MerchantId, cus = cus.CustomerId }
                  equals new { mer = tran.MerchantId, cus = tran.CustomerId.Value }
                  join custBal in _repo.CustomerBalance on cus.CustomerId equals custBal.CustomerId
                  join merBal in _repo.MerchantBalance on cus.MerchantId equals merBal.MerchantId
                  where tran.CustomerId == merch_customer.CustomerId && !tran.IsNotified
                  where tran.CreatedDate >= startDate && tran.CreatedDate <= endDate
                  where custBal.CurrentBalance > merch_customer.MinimumBalance
                  where cus.Mobile.Length == 11
                  orderby tran.CreatedDate descending
                  select new NotificationPayload
                  {
                    CustomerCode = cus.CustomerCode,
                    TransactionNo = tran.TransactionNo,
                    TransactionType = tran.TransactionType,
                    EntryDate = tran.CreatedDate,
                    PhoneNo = cus.Mobile,
                    Amount = tran.Amount,
                    CustomerId = cus.CustomerId,
                    TransactionId = tran.Id,
                  };



      bool flag = query.Any();

      if (flag)
      {
        sender = merch_customer.MerchantCode;

        // check this 
        // looop over the whole list
        var groupTransactions = query.GroupBy(c => c.CustomerCode).ToList();

        foreach (var grouptrans in groupTransactions)
        {
          message = $"{sender.ToUpper()}, ACCT:{grouptrans.Key}, DT:{startDate.ToShortDateString()}-{endDate.ToShortDateString()}, ";
          sum = 0;
          foreach (var item in grouptrans)
          {
            // message += $"{item.EntryDate.DayOfWeek.ToString().ToUpper().Substring(0, 3)}:N{ item.Amount.ToString("#,##0")}{item.TransactionType} ";
            message += $"{item.EntryDate.DayOfWeek.ToString().ToUpper().Substring(0, 3)}:" + string.Format("{0}", item.Amount > 0 ? $"N{item.Amount.ToString("#,##0")}" : $"-N{(-1 * item.Amount).ToString("#,##0")}") + $"{item.TransactionType} ";

            transactionNo = item.TransactionNo;
            sum += item.Amount;
            counter++;
            customerId = item.CustomerId;
            phoneNo = item.PhoneNo;
            transactionId = item.TransactionId;
            merchantId = merch_customer.MerchantId;

          }
          // if its not in the string add it up  ..
          transType = string.Empty;

          // fix balance
          if (!string.IsNullOrEmpty(transactionNo))
          {
            transType = (sum > 0) ? TransactionType.Credit : TransactionType.Debit;
            message += $" BAL:N{sum.ToString("#,##0")}";
            message += $" REF:{transactionNo}";
          }


          if (counter > 0)
          {
            var response = await SendEBulkSms(sender, message, new string[] { phoneNo }, flash: 0);

            if (!string.IsNullOrEmpty(response))
            {
              if (response.Contains("SUCCESS"))
              {
                var smsResponse = response.Split('|');
                // SUCCESS | totalsent:1 | cost:2
                if (string.IsNullOrEmpty(response) || (smsResponse.Length < 1 && smsResponse[0] != "SUCCESS")) continue;

                //totalsent:1

                var transaction = _repo.Transaction.FirstOrDefault(c => c.Id == transactionId);

                transaction.IsNotified = true;
                transaction.ModifiedDate = DateTime.UtcNow;
                transaction.ModifiedBy = 1;

                _repo.Transaction.Update(transaction);

                var op = _service.PostTransaction(new TransactionModel()
                {
                  Amount = -1 * merch_customer.SmsCost,
                  CreatedBy = 1,
                  CreatedDate = DateTime.Now,
                  CustomerId = customerId,
                  IsNotified = true,
                  MerchantId = merchantId,
                  TransactionType = TransactionType.Debit,
                  TransactionMessage = "Sms cost",
                });
                if (op.Succeeded)
                {
                  await SaveSms(message, sender, 1, phoneNo, customerId, merchantId,
                    smsResponse[2].Split(':')[1], smsResponse[0], smsResponse[1].Split(':')[1]);
                  isSmsSent = true;
                }
              }
            }
          }
        }


        if (counter > 0 && isSmsSent)
        {
          //// reset sms date to next friday ...
          var merchant = _repo.Merchant.FirstOrDefault(c => c.MerchantId == merch_customer.MerchantId);

          merchant.SmsDate = endDate;
          _repo.Merchant.Update(merchant);

          await _repo.SaveChangesAsync();

        }
      }

      return counter;
    }

    /// <summary>
    /// Apply Tech fee charges to notification
    /// </summary>
    /// <returns></returns>
    public async Task ApplyTechFeeChargesNotificationAsync()
    {
      // Send Sms for today  ..
      string message = string.Empty;
      string sender = string.Empty;
      string transactionNo = string.Empty;
      var lstmsg = new List<string>();
      string transType = string.Empty;
      string phoneNo = string.Empty;
      long merchantId = 0;

      // get no of dayz in a week MON - FRI
      var smsConfig = int.Parse(_config["System:TechDays"].ToString());

      // saturday of the week
      //DateTime startDate = DateTime.Now.AddDays(-int.Parse(smsConfig));

      var merchant = _repo.Merchant.FirstOrDefault(c => c.MerchantId == merchantId);

      if (merchant == null) throw new Exception("Merchant not found");

      DateTime startDate = merchant.TechDate.AddDays(-smsConfig);

      // Friday of the week..
      DateTime endDate = merchant.TechDate;

      //DateTime.Now.AddDays(-4);

      //DateTime startDate = DateTime.Now.AddDays(-8);
      //// Friday of the week..
      //DateTime endDate = DateTime.Now.AddDays(-4);

      merchantId = 2;

      var query = from cus in _repo.Customer
                  join merch in _repo.Merchant on cus.MerchantId equals merch.MerchantId
                  join tran in _repo.Transaction on new { c = cus.CustomerId, m = cus.MerchantId }
                  equals new { c = tran.CustomerId.Value, m = tran.MerchantId }
                  join custBal in _repo.CustomerBalance on cus.CustomerId equals custBal.CustomerId
                  where cus.MerchantId >= merchantId && !tran.IsNotified
                  where tran.CreatedDate >= startDate && tran.CreatedDate <= endDate
                  where custBal.CurrentBalance > merch.MinimumBalance // should be greater than 500 naira
                  orderby tran.CreatedDate
                  select new NotificationPayload
                  {
                    CustomerCode = cus.CustomerCode,
                    TransactionNo = tran.TransactionNo,
                    TransactionType = tran.TransactionType,
                    EntryDate = tran.CreatedDate,
                    // MerchantName = merch.MerchantCode,
                    PhoneNo = cus.Mobile,
                    Amount = tran.Amount,
                    CustomerId = cus.CustomerId,
                    TransactionId = tran.Id,
                  };



      await _repo.SaveChangesAsync();
    }
  }
}
