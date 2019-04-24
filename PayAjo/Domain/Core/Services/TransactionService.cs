using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PayAjo.Data;
using PayAjo.Data.Entities;
using PayAjo.Data.Repository;
using PayAjo.Domain.Core.Interfaces;
using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Services
{
  /// <summary>
  /// Transaction
  /// </summary>
  public class TransactionService : Service, ITransactionService
  {
    private readonly PayAjoContext _repo;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;

    // private readonly INotificationService _notify;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="repo"></param>
    /// <param name="config"></param>
    /// <param name="mapper"></param>
    public TransactionService(PayAjoContext repo, IConfiguration config,
    IMapper mapper) : base(repo)
    {
      _repo = repo;
      _config = config;
      _mapper = mapper;

    }

    #region Transaction service
    /// <summary>
    /// Check if there is data on the customer balance table is not insert and post to transaction table 
    /// if data is already on customer balance table update then post to transaction table .
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public Operation PostTransaction(TransactionModel model)
    {
      return Operation.Create(() =>
      {
        if (model == null)
          throw new Exception("Transaction paramters cannot empty");

        if (model.TransactionType != TransactionType.Credit && model.TransactionType != TransactionType.Debit)
          throw new Exception("Transaction type is invalid");

        if (model.TransactionChannel != TChannel.Payment && model.TransactionChannel != TChannel.SMS && model.TransactionChannel != TChannel.TechFee && model.TransactionChannel != TChannel.Withdrawal)
          throw new Exception("Transaction Channel is invalid, Either SMS|TECHFEE|WITHDRAWAL|PAYMENT");


        var merchant = _repo.Merchant.FirstOrDefault(c => c.MerchantId == model.MerchantId);

        if (merchant == null) throw new Exception("Merchant not found");

        var customer = _repo.Customer.FirstOrDefault(c => c.MerchantId == model.MerchantId && c.CustomerId == model.CustomerId);

        if (customer == null) throw new Exception("Customer information not found");

        if (model.TransactionType == TransactionType.Credit)
        {
          CreditTransaction(model).Throw();
        }
        else if (model.TransactionType == TransactionType.Debit)
        {
          DebitTransaction(model).Throw();
        }
      });
    }
    public Operation PostTransactionLog(TransactionLogger model)
    {
      return Operation.Create(() =>
      {
        if (model == null)
          throw new Exception("Transaction paramters cannot empty");


        var user = _repo.Users.FirstOrDefault(c => c.UserId == model.CreatedBy);

        if (user == null) throw new Exception("User not found");

        var customer = _repo.Customer.FirstOrDefault(c => c.MerchantId == user.MerchantId && c.CustomerCode == model.CustomerCode);

        if (customer == null) throw new Exception("Customer information not found");

        //TransactionLog
        CreditTransactionLog(new TransactionLogModel()
        {
          Amount = model.Amount,
          CreatedBy = model.CreatedBy,
          CreatedDate = DateTime.Now,
          CustomerCode = model.CustomerCode,
          CustomerId = customer.CustomerId,
          MerchantId = customer.MerchantId,
          TransactionType = TransactionType.Credit,
          IsNotified = true,
          TransactionChannel = TChannel.Payment
        }).Throw();

      });
    }
    public Operation PostTransactionApproval(long transactionLogId, long userId)
    {
      return Operation.Create(() =>
      {
        var user = _repo.Users.FirstOrDefault(c => c.UserId == userId);

        if (user == null) throw new Exception("User not found");

        var transLog = _repo.TransactionLog.FirstOrDefault(c => c.Id == transactionLogId);

        if (transLog == null || transLog.IsApproved) throw new Exception("Either transaction log is empty or has already been approved");

        // Move from trans log to transaction

        PostTransaction(new TransactionModel()
        {
          Amount = transLog.Amount,
          CreatedBy = transLog.CreatedBy,
          CustomerId = transLog.CustomerId.HasValue ? transLog.CustomerId.Value : 0,
          MerchantId = transLog.MerchantId,
          ModifiedBy = userId,
          TransactionType = transLog.TransactionType,
          CreatedDate = DateTime.Now,
          TransactionNo = transLog.TransactionNo,
          TransactionChannel = transLog.TransactionChannel
        }).Throw();

        transLog.IsApproved = true;
        transLog.IsNotified = true;

        _repo.TransactionLog.Update(transLog);
        _repo.SaveChanges();
      });
    }
    public Operation PostTransactionDecline(long transactionLogId, long userId)
    {
      return Operation.Create(() =>
      {
        var user = _repo.Users.FirstOrDefault(c => c.UserId == userId);

        if (user == null) throw new Exception("User not found");

        var transLog = _repo.TransactionLog.FirstOrDefault(c => c.Id == transactionLogId);

        if (transLog == null || transLog.IsApproved) throw new Exception("Either transaction log is empty or has already been approved");

        transLog.IsApproved = false;
        transLog.IsNotified = false;

        _repo.TransactionLog.Update(transLog);
        _repo.SaveChanges();
      });
    }
    public Operation UpdateTransactionNo()
    {
      return Operation.Create(() =>
      {
        //var trans = _repo.Transaction.ToList();

        //foreach (var item in trans)
        //{
        //  item.TransactionNo = $"T{DateTime.Now.Ticks.ToString().Substring(11)}";
        //   _repo.Update(item);
        //}
        //_repo.SaveChanges();
      });
    }

    public Operation PostTransactionForJobs(TransactionJobModel model)
    {
      return Operation.Create(() =>
      {
        if (model == null)
          throw new Exception("Transaction paramters cannot empty");
        if (model.TransactionType != TransactionType.Credit && model.TransactionType != TransactionType.Debit)
          throw new Exception("Transaction type is invalid");

        model.Validate().Catch(c => throw new Exception("Error: " + c.Message));

        var _merchant = _repo.Merchant.FirstOrDefault(c => c.MerchantId == model.CustemerMerchantId);
        var merchant = _repo.Merchant.FirstOrDefault(c => c.MerchantId == model.SystemMerchantId);

        if (merchant == null || _merchant == null) throw new Exception("Merchant not found");

        if (model.TransactionType == TransactionType.Debit)
        {
          ExecuteTransactionJob(model).Throw();
        }
      });
    }
    private Operation CreditTransaction(TransactionModel model)
    {
      return Operation.Create(() =>
      {
        var customerBal = _repo.CustomerBalance.FirstOrDefault(c => c.CustomerId == model.CustomerId);

        if (customerBal == null) // check if balance is not null insert but otherwise update  .. 
        {
          customerBal = new Data.Entities.CustomerBalance()
          {
            CreatedBy = model.CreatedBy.HasValue ? model.CreatedBy.Value : 0,
            CustomerId = model.CustomerId,
            MerchantId = model.MerchantId,
            CurrentBalance = model.Amount,
            TechFeeStartDate = model.TechFeeStartDate,
            TechFeeEndDate = model.TechFeeEndDate.AddDays(30),
            CreatedDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow
          };
          _repo.CustomerBalance.Add(customerBal);
          _repo.SaveChanges();

          var transaction = new Transaction()
          {
            Amount = model.Amount,
            CreatedBy = model.CreatedBy.HasValue ? model.CreatedBy.Value : 0,
            CreatedDate = DateTime.UtcNow,
            CustomerId = model.CustomerId,
            MerchantId = model.MerchantId,
            TransactionCode = model.TransactionCode,
            TransactionNo = model.TransactionNo,
            TransactionType = model.TransactionType,
            TransactionMapCode = model.TransactionMapCode,
            Message = model.TransactionMessage,
            TransactionChannel = model.TransactionChannel
          };

          _repo.Transaction.Add(transaction);

          // will be calculating per day from the transaction table ..
          // log current balance on merchant table  ..
          //PostMerchantAgentBalance(model.MerchantId, model.CreatedBy, model.Amount).Throw();

          // log merchant current balance  
          PostMerchantBalance(model.MerchantId, model.CreatedBy, model.Amount).Throw();

          _repo.SaveChanges();

          //var customer = _repo.Customer.FirstOrDefault(c => c.CustomerId == model.CustomerId);
          //if (customer != null)
          //  _notify.SendSmsKudi(new string[] { customer.Mobile }, $"Your account has been credited with {model.Amount}, your current balance is {customerBal.CurrentBalance}");

        }
        else
        {
          customerBal.CurrentBalance += model.Amount;
          customerBal.ModifiedDate = DateTime.UtcNow;
          _repo.CustomerBalance.Update(customerBal);
          _repo.SaveChanges();
          var transaction = new Data.Entities.Transaction()
          {
            Amount = model.Amount,

            CreatedBy = model.CreatedBy.HasValue ? model.CreatedBy.Value : 0,
            CreatedDate = DateTime.UtcNow,
            CustomerId = model.CustomerId,
            MerchantId = model.MerchantId,
            TransactionCode = model.TransactionCode,
            TransactionNo = model.TransactionNo,
            TransactionType = model.TransactionType,
            TransactionMapCode = model.TransactionMapCode,
            Message = model.TransactionMessage,
            TransactionChannel = model.TransactionChannel
          };

          if (model.CollectionTypeId.HasValue) transaction.CollectionTypeId = model.CollectionTypeId.Value;

          _repo.Transaction.Add(transaction);

          // will be calculating per day for the agent
          // log current balance on merchant table  ..
          // PostMerchantAgentBalance(model.MerchantId, model.CreatedBy, model.Amount).Throw();

          // log merchant current balance  
          PostMerchantBalance(model.MerchantId, model.CreatedBy, model.Amount).Throw();
          _repo.SaveChanges();

          //var customer = _repo.Customer.FirstOrDefault(c => c.CustomerId == model.CustomerId);
          //if (customer != null)
          //  _notify.SendSmsKudi(new string[] { customer.Mobile }, $"Your account has been credited with {model.Amount}, your current balance is {customerBal.CurrentBalance}");
        }

        //_notify.PushSms((model.CustomerId, model.TransactionNo, model.CreatedBy.HasValue ? model.CreatedBy.Value : 0), model.Amount, "CR");
      });
    }
    private Operation CreditTransactionLog(TransactionLogModel model)
    {
      return Operation.Create(() =>
      {

        var transaction = new TransactionLog()
        {
          Amount = model.Amount,
          CreatedBy = model.CreatedBy.HasValue ? model.CreatedBy.Value : 0,
          CreatedDate = DateTime.UtcNow,
          CustomerId = model.CustomerId,
          MerchantId = model.MerchantId,
          TransactionCode = model.TransactionCode,
          TransactionNo = model.TransactionNo,
          TransactionType = TransactionType.Credit,
          TransactionMapCode = model.TransactionMapCode,
          Message = model.TransactionMessage,
          IsNotified = true,
          TransactionChannel = model.TransactionChannel
        };
        _repo.TransactionLog.Add(transaction);
        _repo.SaveChanges();

      });
    }
    private Operation DebitTransaction(TransactionModel model)
    {
      return Operation.Create(() =>
      {
        var customerBal = _repo.CustomerBalance.FirstOrDefault(c => c.CustomerId == model.CustomerId);

        if (customerBal == null) throw new Exception("There is not cash to debit in customers account ");

        if (customerBal.CurrentBalance < model.Amount) throw new Exception("Invalid transaction , amount to debit cannot be more than the current balace");

        decimal amount = model.Amount;
        model.Amount = -amount;

        customerBal.CurrentBalance += model.Amount;
        customerBal.ModifiedDate = DateTime.UtcNow;
        _repo.CustomerBalance.Update(customerBal);

        var transaction = new Data.Entities.Transaction()
        {
          Amount = -amount,
          CreatedBy = model.CreatedBy.HasValue ? model.CreatedBy.Value : 0,
          CreatedDate = DateTime.UtcNow,
          CustomerId = model.CustomerId,
          MerchantId = model.MerchantId,
          TransactionCode = model.TransactionCode,
          TransactionNo = model.TransactionNo,
          TransactionType = model.TransactionType,
          TransactionMapCode = model.TransactionMapCode,
          Message = model.TransactionMessage,
          TransactionChannel = model.TransactionChannel
        };
        if (model.CollectionTypeId.HasValue) transaction.CollectionTypeId = model.CollectionTypeId.Value;

        _repo.Transaction.Add(transaction);

        // log agent current balance 
        //PostMerchantAgentBalance(model.MerchantId, model.CreatedBy, model.Amount).Throw();
        _repo.SaveChanges();
        // log merchant current balance  
        PostMerchantBalance(model.MerchantId, model.CreatedBy, model.Amount).Throw();



        // _notify.PushSms((model.CustomerId, model.TransactionNo, model.CreatedBy.HasValue ? model.CreatedBy.Value : 0), model.Amount, "DR");
      });
    }

    private Operation ExecuteTransactionJob(TransactionJobModel model)
    {
      return Operation.Create(() =>
      {
        var customerBal = _repo.CustomerBalance.FirstOrDefault(c => c.CustomerId == model.CustomerId);

        if (customerBal == null) throw new Exception("There is not cash to debit in customers account ");

        if (customerBal.CurrentBalance < model.Amount)
          throw new Exception("Invalid transaction , amount to debit cannot be more than the current balace");

        //model.Amount = -model.Amount;

        customerBal.CurrentBalance += -model.Amount; // debit customer balance

        _repo.CustomerBalance.Update(customerBal);

        var transaction = new Transaction()
        {
          Amount = -model.Amount,
          CreatedBy = model.CreatedBy.HasValue ? model.CreatedBy.Value : 0,
          CreatedDate = DateTime.UtcNow,
          CustomerId = model.CustomerId,
          MerchantId = model.CustemerMerchantId,
          TransactionCode = model.TransactionCode,
          TransactionNo = model.TransactionNo,
          TransactionType = model.TransactionType,
          TransactionMapCode = model.TransactionMapCode,
          Message = model.TransactionMessage
        };
        _repo.Transaction.Add(transaction);

        // To get the current balance for an agent we will calculate from the transaction table  ..  the once they posted  ..
        // posting system id makes it diff to reconcile the merhant agent creator using background job ..
        // debit agent balance and credit system balance
        // PostMerchantAgentJobBalance((model.CustemerMerchantId, model.SystemMerchantId), model.CreatedBy.Value, model.Amount).Throw();

        // log merchant current balance  
        PostMerchantJobBalance((model.CustemerMerchantId, model.SystemMerchantId), model.CreatedBy.Value, model.Amount).Throw();

        _repo.SaveChanges();
      });
    }
    /// <summary>
    /// There is a challenge using the background service, it uses the system created by to tag customer merchant which is wrong
    /// So it would give inaccurate result  .... there by suspended for now.. 
    /// </summary>
    /// <param name="_merchant"></param>
    /// <param name="createdBy"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    internal Operation PostMerchantAgentJobBalance((long customerMerchantId, long systemMerchantId) _merchant, long createdBy, decimal amount)
    {
      return Operation.Create(() =>
      {

        if (_merchant.customerMerchantId <= 0 || _merchant.systemMerchantId <= 0)
          throw new Exception("Agent balance information not found");

        if (createdBy <= 0) throw new Exception("Agent id not found");

        if (amount <= 0) throw new Exception("Amount cannot be less than or equal to zero");

        var merchant_user = _repo.Users.FirstOrDefault(c => c.MerchantId == _merchant.customerMerchantId && c.UserId == _merchant.systemMerchantId);

        if (merchant_user == null) throw new Exception("Agent or customer details not found");

        var query = _repo.MerchantAgentBalance.FirstOrDefault(c => c.AgentId == createdBy);
        // there is a challenge here!  .. the system user is debiting customer merchant agent  --
        // to reconcile will be diff , for a particular agent ..
        if (query == null)
        {
          // system debit the customer  ..
          query = new MerchantAgentBalance()
          {
            AgentId = createdBy,
            CreatedBy = createdBy,
            CreatedDate = DateTime.Now,
            CurrentBalance = amount,
            MerchantId = _merchant.customerMerchantId,
          };
          _repo.MerchantAgentBalance.Add(query);
          //_repo.SaveChanges();
        }
        else
        {
          query.CurrentBalance += amount;
          _repo.MerchantAgentBalance.Update(query);
          //_repo.SaveChanges();
        }


      });
    }
    /// <summary>
    /// Debit customer merchant and credit system merchant table.. 
    /// </summary>
    /// <param name="merchant"></param>
    /// <param name="createdBy"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    internal Operation PostMerchantJobBalance((long customerMerchantId, long systemMerchantId) _merchant, long createdBy, decimal amount)
    {
      return Operation.Create(() =>
      {
        // validation
        if (_merchant.customerMerchantId <= 0 || _merchant.systemMerchantId <= 0) //&& !agentUserId.HasValue && amount <= 0)
          throw new Exception("Merchant  information not found");

        if (amount <= 0) throw new Exception("Amount cannot be less than zero");

        if (createdBy <= 0) throw new Exception("System user does not exist");

        var merchant_user = _repo.Users.FirstOrDefault(c => c.MerchantId == _merchant.customerMerchantId);

        var _merchant_user = _repo.Users.FirstOrDefault(c => c.MerchantId == _merchant.systemMerchantId);

        if (merchant_user == null || _merchant_user == null) throw new Exception("Merchant user details not found");


        // credit system current merchant 
        var system_merchant = _repo.MerchantBalance.FirstOrDefault(c => c.MerchantId == _merchant.systemMerchantId);

        if (system_merchant == null)
        {
          system_merchant = new MerchantBalance()
          {
            CreatedBy = createdBy,
            CreatedDate = DateTime.UtcNow,
            Amount = amount, // credit system
            MerchantId = _merchant.systemMerchantId,
          };
          _repo.MerchantBalance.Add(system_merchant);
        }
        else
        {
          system_merchant.Amount += amount; // credit system 
          _repo.MerchantBalance.Update(system_merchant);
        }

        // In further calculations --  the system agent on background debit customer merchant ...
        // debit customer current merchant ...
        var cus_merchant = _repo.MerchantBalance.FirstOrDefault(c => c.MerchantId == _merchant.customerMerchantId);

        if (cus_merchant == null)
        {
          cus_merchant = new MerchantBalance()
          {
            CreatedBy = createdBy,
            CreatedDate = DateTime.Now,
            MerchantId = _merchant.customerMerchantId,
            Amount = -amount,
          };
          _repo.MerchantBalance.Add(cus_merchant);
          //_repo.SaveChanges();
        }
        else
        {
          cus_merchant.Amount += -amount; // debit 
          _repo.MerchantBalance.Update(cus_merchant);
          //_repo.SaveChanges();
        }
      });
    }

    /// <summary>
    /// Post merchant agent balance  
    /// </summary>
    /// <param name="merchantId"></param>
    /// <param name="agentUserId"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    protected internal Operation PostMerchantAgentBalance(long merchantId, long? agentUserId, decimal amount)
    {
      return Operation.Create(() =>
      {
        if (merchantId <= 0 && !agentUserId.HasValue && amount <= 0)
          throw new Exception("Agent balance information not found");

        var merchant = _repo.Users.FirstOrDefault(c => c.MerchantId == merchantId && c.UserId == agentUserId);

        if (merchant == null) throw new Exception("Agent details not found");

        var query = _repo.MerchantAgentBalance.FirstOrDefault(c => c.AgentId == agentUserId);

        if (query == null)
        {
          query = new MerchantAgentBalance()
          {
            AgentId = agentUserId.Value,
            CreatedBy = agentUserId.Value,
            CreatedDate = DateTime.Now,
            CurrentBalance = amount,
            MerchantId = merchantId,
          };
          _repo.MerchantAgentBalance.Add(query);
          //_repo.SaveChanges();
        }
        else
        {
          query.CurrentBalance += amount;
          _repo.MerchantAgentBalance.Update(query);
          //_repo.SaveChanges();
        }

      });
    }
    /// <summary>
    /// Post merchant balance 
    /// </summary>
    /// <param name="merchantId"></param>
    /// <param name="agentUserId"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    protected internal Operation PostMerchantBalance([Required]long merchantId, long? agentUserId, decimal amount)
    {
      return Operation.Create(() =>
      {
        if (merchantId <= 0)
          throw new Exception("Merchant information not found");

        if (!agentUserId.HasValue)
          throw new Exception("Agent user id not found");


        var merchant = _repo.Users.FirstOrDefault(c => c.MerchantId == merchantId);

        if (merchant == null) throw new Exception("Merchant details not found");

        var query = _repo.MerchantBalance.FirstOrDefault(c => c.MerchantId == merchantId);

        if (query == null)
        {
          query = new MerchantBalance()
          {
            CreatedBy = agentUserId.Value,
            CreatedDate = DateTime.Now,
            MerchantId = merchantId,
            Amount = amount,
          };
          _repo.MerchantBalance.Add(query);
          //_repo.SaveChanges();
        }
        else
        {
          query.Amount += amount;
          _repo.MerchantBalance.Update(query);
          //_repo.SaveChanges();
        }

      });
    }

    /// <summary>
    ///  Get all transactions
    /// </summary>
    /// <returns></returns>
    public Operation<TransactionReponseModel[]> GetAllTransactions()
    {
      return Operation.Create(() =>
      {


        var transaction = _repo.Transaction.Include(m => m.Merchant)
                            .Include(c => c.Customer).Select(c =>
                           new TransactionReponseModel
                           {
                             Amount = c.Amount,
                             MerchantId = c.Merchant.MerchantId,
                             Merchant = new MerchantModel()
                             {
                               Id = c.Merchant.MerchantId,
                               Name = c.Merchant.Name
                             },
                             TransactionCode = c.TransactionCode,
                             TransactionNo = c.TransactionNo,
                             TransactionType = c.TransactionType,
                             Customer = new CustomerModel()
                             {
                               CustomerId = c.Customer.CustomerId,
                               FirstName = c.Customer.FirstName,
                               LastName = c.Customer.LastName,
                               Mobile = c.Customer.Mobile,
                               Address = c.Customer.Address,
                               EmailAddress = c.Customer.EmailAddress,
                             },
                             CustomerId = c.Customer.CustomerId,
                             TransactionMapCode = c.TransactionMapCode,
                             Id = c.Id,
                             CreatedDate = c.CreatedDate
                           }).ToArray();

        return transaction;

      });
    }
    /// <summary>
    /// Get Customer transaction ..
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    public Operation<TransactionReponseModel[]> GetCustomerTransactions([Required] long customerId)
    {
      return Operation.Create(() =>
      {
        var query = from t in _repo.Transaction
                    join m in _repo.Merchant on t.MerchantId equals m.MerchantId
                    join c in _repo.Customer on t.CustomerId equals c.CustomerId
                    join u in _repo.Users on t.CreatedBy equals u.UserId
                    select new TransactionReponseModel()
                    {
                      Amount = t.Amount,
                      MerchantId = t.MerchantId,
                      Merchant = new MerchantModel()
                      {
                        Id = m.MerchantId,
                        Name = m.Name
                      },
                      TransactionCode = t.TransactionCode,
                      TransactionNo = t.TransactionNo,
                      TransactionType = t.TransactionType,
                      Customer = new CustomerModel()
                      {
                        CustomerId = c.CustomerId,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Mobile = c.Mobile,
                        Address = c.Address,
                        EmailAddress = c.EmailAddress,
                        CustomerCode = c.CustomerCode
                      },
                      CustomerId = c.CustomerId,
                      TransactionMapCode = t.TransactionMapCode,
                      TransactionMessage = t.Message,
                      Id = t.Id,
                      Agent = new AgentModel()
                      {
                        Address = u.Address,
                        AgentId = u.UserId,
                        EmailAddress = u.EmailAddress,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        PhoneNumber = u.Mobile
                      },
                      UserName = u.UserName,
                      CreatedDate = t.CreatedDate
                    };



        return query.OrderByDescending(c => c.Id).Where(c => c.CustomerId == customerId).ToArray();
      });
    }
    /// <summary>
    ///  Get customer Current balance
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    public Operation<decimal> GetCustomerCurrentBalance([Required]long customerId)
    {
      return Operation.Create(() =>
      {
        var customerBal = _repo.CustomerBalance.Include(c => c.Customer).FirstOrDefault(c => c.CustomerId == customerId);

        if (customerBal == null) throw new Exception("Invalid customer balance");

        return customerBal.CurrentBalance;
      });
    }
    /// <summary>
    /// Transaction agent user id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public Operation<TransactionModel[]> GetTransactionByAgentUserId([Required]long userId)
    {
      return Operation.Create(() =>
      {
        var cus_trans = (from t in _repo.Transaction
                         join c in _repo.Customer on t.CustomerId equals c.CustomerId
                         join m in _repo.Merchant on t.MerchantId equals m.MerchantId
                         join u in _repo.Users on c.UserId equals u.UserId
                         where t.CreatedBy == userId
                         select new TransactionModel()
                         {
                           Amount = t.Amount,
                           CreatedBy = c.CreatedBy,
                           MerchantId = c.MerchantId,
                           TransactionCode = t.TransactionCode,
                           TransactionMapCode = t.TransactionMapCode,
                           TransactionType = t.TransactionType,
                           TransactionNo = t.TransactionNo,
                           CustomerId = c.CustomerId,
                           TransactionMessage = t.Message,
                           Id = t.Id,
                           UserName = u.UserName,
                           CustomerCode = c.CustomerCode,
                           CreatedDate = t.CreatedDate
                         }).OrderByDescending(c => c.Id).ToArray();

        return cus_trans;
      });
    }
    /// <summary>
    /// Transaction merchant
    /// </summary>
    /// <param name="merchantId"></param>
    /// <returns></returns>
    public Operation<MerchanTransactionModel[]> GetTransactionByMerchantId([Required]long merchantId)
    {
      return Operation.Create(() =>
      {
        var cus_trans = (from t in _repo.Transaction
                         join c in _repo.Customer on t.CustomerId equals c.CustomerId
                         join m in _repo.Merchant on t.MerchantId equals m.MerchantId
                         join u in _repo.Users on c.UserId equals u.UserId
                         where m.MerchantId == merchantId
                         select new MerchanTransactionModel()
                         {
                           Amount = t.Amount,
                           CreatedBy = t.CreatedBy,
                           MerchantId = c.MerchantId,
                           TransactionCode = t.TransactionCode,
                           TransactionMapCode = t.TransactionMapCode,
                           TransactionType = t.TransactionType,
                           TransactionNo = t.TransactionNo,
                           CustomerId = c.CustomerId,
                           Id = t.Id,
                           TransactionMessage = t.Message,
                           Customer = new CustomerModel()
                           {
                             CustomerId = c.CustomerId,
                             LastName = c.LastName,
                             FirstName = c.FirstName,
                             CustomerCode = c.CustomerCode,
                             Mobile = c.Mobile,
                             UserName = u.UserName,
                             UserId = u.UserId
                           },
                           CreatedDate = t.CreatedDate
                         }).OrderByDescending(c => c.Id).ToArray();

        return cus_trans;
      });
    }

    /// <summary>
    ///  Get customer total credit
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    public Operation<CreditModel> GetCustomerTotalCredit(long customerId)
    {
      return Operation.Create(() =>
      {

        var model = new CreditModel();


        var query = _repo.Transaction.Include(c => c.Customer).Where(c => c.CustomerId == customerId);

        //DateTime startDate = DateTime.UtcNow;
        //DateTime endDate = DateTime.UtcNow;

        var startDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 23, 59, 59);
        var endDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0);


        #region Debit weekly
        var _endDate = endDate.AddDays(-7);
        model.TotalDebitWeekly = query.Where(c => c.CreatedDate >= _endDate && c.CreatedDate <= startDate && c.TransactionType == TransactionType.Debit).Sum(c => c.Amount);

        #endregion

        #region Weekly Credit
        model.TotalCreditWeekly = query.Where(c => c.CreatedDate >= _endDate && c.CreatedDate <= startDate && c.TransactionType == TransactionType.Credit).Sum(c => c.Amount);
        #endregion

        #region Monthly Credit
        endDate = endDate.AddDays(-30);
        model.TotalCreditMonthly = query.Where(c => c.CreatedDate >= _endDate && c.CreatedDate <= startDate && c.TransactionType == TransactionType.Credit).Sum(c => c.Amount);
        #endregion


        return model;
      });
    }
    /// <summary>
    /// Post offline information of but the customer , merchant and agent
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public Operation PostOfflineTransaction(OfflineModel model)
    {
      return Operation.Create(() =>
      {
        if (model == null) throw new Exception("Offline data cannot be empty");

        model.Validate().Throw();

        Customer customer = null;

        // Check if customer exist on the system ..
        customer = _repo.Customer.FirstOrDefault(c => c.CustomerCode == model.CustomerCode || c.MerchantId == model.MerchantId);

        if (customer == null)
          throw new Exception("Customer information not found");

        // Check if user exist agent on the system  || latter we check if  user exist as merchant  ..
        User user = null;
        // Merchant merchant = null;

        user = _repo.Users.FirstOrDefault(c => c.UserName == model.AgentUserName || c.MerchantId == model.MerchantId);

        //Validate if merchant is the same .. 
        if (user.MerchantId != customer.MerchantId)
          throw new Exception("Merchant for both agent and customer must be the same  ");

        if (user == null) throw new Exception("Agent information cannot be empty");

        // post transactions ... 
        PostTransaction(new TransactionModel()
        {
          Amount = model.Amount,
          CreatedDate = DateTime.Now,
          CustomerId = customer.CustomerId,
          MerchantId = customer.MerchantId,
          TransactionType = model.TransactionType,
          TransactionMessage = $"Offline {model.TransactionType} of {customer.FirstName} " +
                 $"{customer.LastName} by {user.LastName} {user.FirstName}",
          CreatedBy = user.UserId,
        }).Throw();
      });
    }

    public Operation<Pagination<TransactionReponseModel>> GetMerchantTransactions(SearchModel model, TransType type, long userId)
    {
      return Operation.Create(() =>
      {

        Log.Information("I am currently @ the get customer registration ");

        var user = _repo.Users.FirstOrDefault(c => c.UserId == userId);

        if (user == null) throw new Exception("User merchant not found");

        var query = from t in _repo.Transaction
                    join m in _repo.Merchant on t.MerchantId equals m.MerchantId
                    join c in _repo.Customer on t.CustomerId equals c.CustomerId
                    join u in _repo.Users on t.CreatedBy equals u.UserId
                    where u.MerchantId == user.MerchantId
                    select new TransactionReponseModel()
                    {
                      Amount = t.Amount,
                      MerchantId = t.MerchantId,
                      Merchant = new MerchantModel()
                      {
                        Id = m.MerchantId,
                        Name = m.Name
                      },
                      TransactionCode = t.TransactionCode,
                      TransactionNo = t.TransactionNo,
                      TransactionType = t.TransactionType,
                      Customer = new CustomerModel()
                      {
                        CustomerId = c.CustomerId,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Mobile = c.Mobile,
                        Address = c.Address,
                        EmailAddress = c.EmailAddress,
                        CustomerCode = c.CustomerCode
                      },
                      CustomerId = c.CustomerId,
                      TransactionMapCode = t.TransactionMapCode,
                      TransactionMessage = t.Message,
                      Id = t.Id,
                      Agent = new AgentModel()
                      {
                        Address = u.Address,
                        AgentId = u.UserId,
                        EmailAddress = u.EmailAddress,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        PhoneNumber = u.Mobile
                      },
                      UserName = u.UserName,
                      CreatedDate = t.CreatedDate,
                      AgentName = u.LastName + " " + u.FirstName,
                      MerchantName = m.Name
                    };

        var transactions = new List<TransactionReponseModel>().ToArray();


        if (!string.IsNullOrEmpty(model.Search))
        {
          query = query.Where(c => c.TransactionCode.Contains(model.Search) || c.TransactionNo.Contains(model.Search)
          || c.TransactionType.Contains(model.Search) || c.AgentName.Contains(model.Search) || c.UserName.Contains(model.Search) || c.Customer.CustomerCode.Contains(model.Search) || c.Customer.FirstName.Contains(model.Search) || c.Customer.LastName.Contains(model.Search));
        }

        if (!model.StartDate.ToString().Contains("1/1/0001") && !model.EndDate.ToString().Contains("1/1/0001"))
        {

          if (model.StartDate > model.EndDate) throw new Exception("Start date cannot be greater than end date");

          query = query.Where(c => c.CreatedDate >= model.StartDate && c.CreatedDate <= model.EndDate);

        }

        //if (type ==  TransType.Credit)
        //{
        //  query = query.Where(c => c.Status);
        //}
        //else if (type == TransType.Debit)
        //{
        //  query = query.Where(c => !c.Status);
        //}

        long totalCount = query.LongCount();

        query = query.OrderByDescending(c => c.CustomerId).Skip(model.pageIndex * model.pageSize).Take(model.pageSize);

        return new Pagination<TransactionReponseModel>(query.ToArray(), totalCount, model.pageSize, model.pageIndex);
      });
    }

    /// <summary>
    /// Get transaction for merchants ..
    /// </summary>
    /// <param name="search"></param>
    /// <param name="UserId"></param>
    /// <param name="type"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public Operation<Pagination<TransactionReponseModel>> GetMerchantTransactions(string search, long UserId, TransType type, int pageIndex, int pageSize = 100)
    {
      return Operation.Create(() =>
      {
        var user = _repo.Users.FirstOrDefault(c => c.UserId == UserId);

        if (user == null) throw new Exception("User merchant not found");

        var query = from t in _repo.Transaction
                    join m in _repo.Merchant on t.MerchantId equals m.MerchantId
                    join c in _repo.Customer on t.CustomerId equals c.CustomerId
                    join u in _repo.Users on t.CreatedBy equals u.UserId
                    where u.MerchantId == user.MerchantId
                    select new TransactionReponseModel()
                    {
                      Amount = t.Amount,
                      MerchantId = t.MerchantId,
                      Merchant = new MerchantModel()
                      {
                        Id = m.MerchantId,
                        Name = m.Name
                      },
                      TransactionCode = t.TransactionCode,
                      TransactionNo = t.TransactionNo,
                      TransactionType = t.TransactionType,
                      Customer = new CustomerModel()
                      {
                        CustomerId = c.CustomerId,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Mobile = c.Mobile,
                        Address = c.Address,
                        EmailAddress = c.EmailAddress,
                        CustomerCode = c.CustomerCode
                      },
                      CustomerId = c.CustomerId,
                      TransactionMapCode = t.TransactionMapCode,
                      TransactionMessage = t.Message,
                      Id = t.Id,
                      Agent = new AgentModel()
                      {
                        Address = u.Address,
                        AgentId = u.UserId,
                        EmailAddress = u.EmailAddress,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        PhoneNumber = u.Mobile
                      },
                      UserName = u.UserName,
                      CreatedDate = t.CreatedDate,
                      AgentName = u.LastName + " " + u.FirstName,
                      MerchantName = m.Name
                    };

        var transactions = new List<TransactionReponseModel>().ToArray();


        if (!string.IsNullOrEmpty(search))
          query = query.Where(c => c.TransactionNo.Contains(search));

        if (type == TransType.Debit)
        {
          transactions = query.Where(c => c.TransactionType == TransactionType.Debit).ToArray();
        }
        else if (type == TransType.Credit)
        {
          transactions = query.Where(c => c.TransactionType == TransactionType.Credit).ToArray();
        }
        else
        {
          transactions = query.ToArray();
        }

        long totalCount = transactions.LongCount();

        // if (pageIndex > 0)
        transactions = transactions.OrderByDescending(c => c.Id).Skip(pageIndex * pageSize).Take(pageSize).ToArray();

        return new Pagination<TransactionReponseModel>(transactions, totalCount, pageSize, pageIndex);

      });
    }
    public Operation<Pagination<TransactionReponseModel>> GetMerchantTransactionLog(string search, long UserId, TransType type, int pageIndex, int pageSize = 100)
    {
      return Operation.Create(() =>
      {
        var user = _repo.Users.FirstOrDefault(c => c.UserId == UserId);

        if (user == null) throw new Exception("User merchant not found");

        var query = from t in _repo.TransactionLog
                    join m in _repo.Merchant on t.MerchantId equals m.MerchantId
                    join c in _repo.Customer on t.CustomerId equals c.CustomerId
                    join u in _repo.Users on t.CreatedBy equals u.UserId
                    where u.MerchantId == user.MerchantId
                    where t.IsNotified
                    where !t.IsApproved
                    select new TransactionReponseModel()
                    {
                      Amount = t.Amount,
                      MerchantId = t.MerchantId,
                      Merchant = new MerchantModel()
                      {
                        Id = m.MerchantId,
                        Name = m.Name
                      },
                      TransactionCode = t.TransactionCode,
                      TransactionNo = t.TransactionNo,
                      TransactionType = t.TransactionType,
                      Customer = new CustomerModel()
                      {
                        CustomerId = c.CustomerId,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Mobile = c.Mobile,
                        Address = c.Address,
                        EmailAddress = c.EmailAddress,
                        CustomerCode = c.CustomerCode
                      },
                      CustomerId = c.CustomerId,
                      TransactionMapCode = t.TransactionMapCode,
                      TransactionMessage = t.Message,
                      Id = t.Id,
                      Agent = new AgentModel()
                      {
                        Address = u.Address,
                        AgentId = u.UserId,
                        EmailAddress = u.EmailAddress,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        PhoneNumber = u.Mobile
                      },
                      UserName = u.UserName,
                      CreatedDate = t.CreatedDate,
                      AgentName = u.FirstName + " " + u.LastName,
                      MerchantName = m.Name
                    };



        if (!string.IsNullOrEmpty(search))
          query = query.Where(c => c.TransactionNo.Contains(search));

        long totalCount = query.LongCount();
        if (pageIndex > 0) query = query.OrderByDescending(c => c.Id).Skip(pageIndex * pageSize).Take(pageSize);

        return new Pagination<TransactionReponseModel>(query.ToArray(), totalCount, pageSize, pageIndex);

      });
    }
    #endregion

  }
}
