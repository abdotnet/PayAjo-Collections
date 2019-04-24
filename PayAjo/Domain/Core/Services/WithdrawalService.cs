using PayAjo.Data;
using PayAjo.Data.Entities;
using PayAjo.Domain.Core.Interfaces;
using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using PayAjo.Domain.Core.Enum;
using System.Text;
using System.Security.Cryptography;

namespace PayAjo.Domain.Core.Services
{
  /// <summary>
  /// Withdrawal Service
  /// </summary>
  public class WithdrawalService : Service, IWithdrawalService
  {
    private readonly PayAjoContext _repo;
    private readonly ITransactionService _tranService;
    private readonly INotificationService _notify;
    /// <summary>
    /// Withdrawal Service
    /// </summary>
    /// <param name="repo"></param>
    /// <param name="tranService"></param>
    /// <param name="notify"></param>
    public WithdrawalService(PayAjoContext repo, ITransactionService tranService, INotificationService notify) : base(repo)
    {
      _repo = repo;
      _tranService = tranService;
      _notify = notify;
    }

    #region Withdrawal Service

    public Operation<Pagination<WithdrawalResponseModel>> GetWithdrawalsByMerchant(SearchModel model, long UserId, WithdrawalType type)
    {
      return Operation.Create(() =>
      {
        var user = _repo.Users.FirstOrDefault(c => c.UserId == UserId);

        if (user == null) throw new Exception("User merchant not found");

        var query = (from w in _repo.Withdrawal
                     join c in _repo.Customer on w.CustomerId equals c.CustomerId
                     join u in _repo.Users on c.UserId equals u.UserId
                     where !w.IsCancelled
                     where w.MerchantId == user.MerchantId
                     select new WithdrawalResponseModel()
                     {
                       Message = w.Message,
                       WithdrawalStatus = w.WithdrawalStatus,
                       MerchantId = c.MerchantId,
                       Merchant = new MerchantModel()
                       {
                         Id = c.MerchantId,
                       },
                       CustomerId = c.CustomerId,
                       Amount = w.Amount,
                       CreatedBy = c.CreatedBy,
                       CreatedDate = w.CreatedDate,
                       Customer = new CustomerModel()
                       {
                         Address = c.Address,
                         LastName = c.LastName,
                         City = c.City,
                         Country = c.Country,
                         CustomerId = c.CustomerId,
                         EmailAddress = c.EmailAddress,
                         FirstName = c.FirstName,
                         Mobile = c.Mobile,
                         UserName = u.UserName,
                         CustomerCode = c.CustomerCode
                       },
                       Id = w.Id
                     });

        var withdrawalResponse = new List<WithdrawalResponseModel>().ToArray();

        if (!string.IsNullOrEmpty(model.Search))
        {
          query = query.Where(c => c.Customer.LastName.Contains(model.Search.Trim()) || c.Customer.FirstName.Contains(model.Search.Trim())
          || c.Customer.CustomerCode.Contains(model.Search.Trim()));
        }

        if (type == WithdrawalType.Approved)
        {
          withdrawalResponse = query.Where(c => c.WithdrawalStatus == WithdrawalStatus.Approved).ToArray();
        }
        else if (type == WithdrawalType.Paid)
        {
          withdrawalResponse = query.Where(c => c.WithdrawalStatus == WithdrawalStatus.Paid).ToArray();
        }
        else
        {
          withdrawalResponse = query.ToArray();
        }

        long totalCount = withdrawalResponse.LongCount();

        //if (pageIndex > 0)
        withdrawalResponse = withdrawalResponse.OrderByDescending(c => c.Id).Skip(model.pageIndex * model.pageSize).Take(model.pageSize).ToArray();

        return new Pagination<WithdrawalResponseModel>(withdrawalResponse,
          totalCount, model.pageSize, model.pageIndex);

      });
    }

    /// <summary>
    /// Get withdrawals by merchant ...
    /// </summary>
    /// <param name="search"></param>
    /// <param name="UserId"></param>
    /// <param name="type"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public Operation<Pagination<WithdrawalResponseModel>> GetWithdrawalsByMerchant(string search, long UserId, WithdrawalType type, int pageIndex, int pageSize = 100)
    {
      return Operation.Create(() =>
      {
        var user = _repo.Users.FirstOrDefault(c => c.UserId == UserId);

        if (user == null) throw new Exception("User merchant not found");

        var query = (from w in _repo.Withdrawal
                     join c in _repo.Customer on w.CustomerId equals c.CustomerId
                     join u in _repo.Users on c.UserId equals u.UserId
                     where !w.IsCancelled
                     where w.MerchantId == user.MerchantId
                     select new WithdrawalResponseModel()
                     {
                       Message = w.Message,
                       WithdrawalStatus = w.WithdrawalStatus,
                       MerchantId = c.MerchantId,
                       Merchant = new MerchantModel()
                       {
                         Id = c.MerchantId,
                       },
                       CustomerId = c.CustomerId,
                       Amount = w.Amount,
                       CreatedBy = c.CreatedBy,
                       CreatedDate = w.CreatedDate,
                       Customer = new CustomerModel()
                       {
                         Address = c.Address,
                         LastName = c.LastName,
                         City = c.City,
                         Country = c.Country,
                         CustomerId = c.CustomerId,
                         EmailAddress = c.EmailAddress,
                         FirstName = c.FirstName,
                         Mobile = c.Mobile,
                         UserName = u.UserName,
                         CustomerCode = c.CustomerCode
                       },
                       Id = w.Id
                     });

        var withdrawalResponse = new List<WithdrawalResponseModel>().ToArray();


        if (type == WithdrawalType.Approved)
        {
          withdrawalResponse = query.Where(c => c.WithdrawalStatus == WithdrawalStatus.Approved).ToArray();
        }
        else if (type == WithdrawalType.Paid)
        {
          withdrawalResponse = query.Where(c => c.WithdrawalStatus == WithdrawalStatus.Paid).ToArray();
        }
        else
        {
          withdrawalResponse = query.ToArray();
        }

        long totalCount = withdrawalResponse.LongCount();

        //if (pageIndex > 0)
        withdrawalResponse = withdrawalResponse.OrderByDescending(c => c.Id).Skip(pageIndex * pageSize).Take(pageSize).ToArray();

        return new Pagination<WithdrawalResponseModel>(withdrawalResponse,
          totalCount, pageSize, pageIndex);
      });
    }


    /// <summary>
    /// Post withdrawal
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public Operation<WithdrawalModel> PostWithdrawal(WithdrawalModel model)
    {
      return Operation.Create(() =>
      {
        if (model == null) throw new Exception("Withdrawal model not found");

        model.Validate().Catch(c => throw new Exception("Error: " + c.Message));

        var merchant = _repo.Merchant.FirstOrDefault(m => m.MerchantId == model.MerchantId);

        if (merchant == null) throw new Exception("Merchant not found");

        var customer = _repo.Customer.FirstOrDefault(c => c.CustomerId == model.CustomerId && c.MerchantId == model.MerchantId);

        if (customer == null)
          throw new Exception("Customer information not found");

        var currentBal = _repo.CustomerBalance.
                          FirstOrDefault(c => c.MerchantId == model.MerchantId && c.CustomerId == model.CustomerId);

        if (currentBal == null)
          throw new Exception("Invalid request, has  not transaction history on this system");

        if (currentBal.CurrentBalance < model.Amount)
          throw new Exception("Transaction failed, the amount cannot be greater than the current balance ");

        // for user & password confirmation ..
        var user = _repo.Users.FirstOrDefault(c => c.UserId == model.CreatedBy);

        if (user == null) throw new Exception("User does not exist");

        // validate password
        if (user.Password != EncryptPassword(model.Password, user.Salt))
          throw new Exception("Password incorrect");

        // One widthdrawal @ a time

        var widthdrawal = _repo.Withdrawal.FirstOrDefault(c => c.MerchantId == model.MerchantId && c.CustomerId == model.CustomerId && c.WithdrawalStatus != WithdrawalStatus.Paid);

        if (widthdrawal != null)
          throw new Exception("Invalid request, your pending or approved request should be cleared  before a new request ");


        var request = new Withdrawal()
        {
          Amount = model.Amount,
          CustomerId = model.CustomerId,
          CreatedBy = model.CreatedBy.HasValue ? model.CreatedBy.Value : 0,
          CreatedDate = DateTime.Now,
          MerchantId = model.MerchantId,
          Message = model.Message + " pending state",
          WithdrawalStatus = WithdrawalStatus.Pending,
        };
        _repo.Withdrawal.Add(request);
        _repo.SaveChanges();

        //var _customer = _repo.Customer.FirstOrDefault(c => c.CustomerId == model.CustomerId);

        //if (_customer != null)
        //  _notify.SendSmsKudi(new string[] { customer.Mobile }, $"You have requested for withdrawal of {model.Amount} from your account. ");

        return new WithdrawalModel()
        {
          Amount = request.Amount,
          Message = request.Message,
          CustomerId = request.CustomerId,
          MerchantId = request.MerchantId,
          Id = request.Id
        };
      });
    }

    public Operation<WithdrawalModel> PostWithdrawalLogger(WithdrawalLogModel model)
    {
      return Operation.Create(() =>
      {
        if (model == null) throw new Exception("Withdrawal model not found");

        model.Validate().Catch(c => throw new Exception("Error: " + c.Message));

        var user = _repo.Users.FirstOrDefault(m => m.UserId == model.CreatedBy);

        if (user == null) throw new Exception("User not found");

        var customer = _repo.Customer.FirstOrDefault(c => c.CustomerCode == model.CustomerCode && c.MerchantId == user.MerchantId);

        if (customer == null)
          throw new Exception("Customer information not found");

        var currentBal = _repo.CustomerBalance.
                          FirstOrDefault(c => c.MerchantId == customer.MerchantId && c.CustomerId == customer.CustomerId);

        if (currentBal == null)
          throw new Exception("Invalid request, has  not transaction history on this system");

        if (currentBal.CurrentBalance < model.Amount)
          throw new Exception("Transaction failed, the amount cannot be greater than the current balance ");


        // One widthdrawal @ a time

        var widthdrawal = _repo.Withdrawal.FirstOrDefault(c => c.MerchantId == customer.MerchantId && c.CustomerId == customer.CustomerId && c.WithdrawalStatus != WithdrawalStatus.Paid && !c.IsCancelled);

        if (widthdrawal != null)
          throw new Exception("Invalid request, your pending or approved request should be cleared  before a new request ");


        var request = new Withdrawal()
        {
          Amount = model.Amount,
          CustomerId = customer.CustomerId,
          CreatedBy = model.CreatedBy.HasValue ? model.CreatedBy.Value : 0,
          CreatedDate = DateTime.Now,
          MerchantId = customer.MerchantId,
          Message = " pending state",
          WithdrawalStatus = WithdrawalStatus.Pending
        };
        _repo.Withdrawal.Add(request);
        _repo.SaveChanges();

        //var _customer = _repo.Customer.FirstOrDefault(c => c.CustomerId == model.CustomerId);

        //if (_customer != null)
        //  _notify.SendSmsKudi(new string[] { customer.Mobile }, $"You have requested for withdrawal of {model.Amount} from your account. ");

        return new WithdrawalModel()
        {
          Amount = request.Amount,
          Message = request.Message,
          CustomerId = request.CustomerId,
          MerchantId = request.MerchantId,
          Id = request.Id
        };
      });
    }

    public Operation ApprovedWithdrawal(WithdrawApprovalModel model, WithdrawalStatus status)
    {
      return Operation.Create(() =>
      {
        if (model == null) throw new Exception("Withdrawal approval  not found");

        model.Validate().Throw();

        if (status == WithdrawalStatus.Approved)
        {
          var withdrawal = _repo.Withdrawal
                      .FirstOrDefault(c => c.Id == model.WithdrawalId
                        && c.WithdrawalStatus == WithdrawalStatus.Pending);

          if (withdrawal == null) throw new Exception("Invalid request,withdrawal is not in pending state");

          var query = _repo.CustomerBalance.FirstOrDefault(c => c.MerchantId == withdrawal.MerchantId && c.CustomerId == withdrawal.CustomerId);

          if (query == null) throw new Exception("Invalid Request, customer balance does not exist");

          if (query.CurrentBalance < withdrawal.Amount) throw new Exception("Invalid request,Customer balance cannot be less than the amount request");

          if (model.AgentUserId > 0)
          {
            var user_exist = _repo.Users.FirstOrDefault(c => c.UserId == model.AgentUserId);
            if (user_exist == null) throw new Exception("user not found");

            withdrawal.WithdrawalStatus = WithdrawalStatus.Approved;
            withdrawal.Message += withdrawal.Message + " --- Approved state";
            withdrawal.CreatedBy = model.AgentUserId;
            _repo.Withdrawal.Update(withdrawal);
            _repo.SaveChanges();
          }
          else
          {
            withdrawal.WithdrawalStatus = WithdrawalStatus.Approved;
            _repo.Withdrawal.Update(withdrawal);
            _repo.SaveChanges();
          }

        }
        else if (status == WithdrawalStatus.Paid)
        {
          var withdrawal = _repo.Withdrawal
                      .FirstOrDefault(c => c.Id == model.WithdrawalId
                         && c.WithdrawalStatus == WithdrawalStatus.Pending); // instead of approved.

          if (withdrawal == null) throw new Exception("Invalid request,withdrawal is not in pending state");


          var _model = new TransactionModel()
          {
            Amount = withdrawal.Amount,
            CreatedBy = withdrawal.CreatedBy,
            CreatedDate = withdrawal.CreatedDate,
            CustomerId = withdrawal.CustomerId,
            MerchantId = withdrawal.MerchantId,
            TransactionMessage = withdrawal.Message,
            TransactionType = TransactionType.Debit,
            TransactionChannel = TChannel.Withdrawal
          };
          _tranService.PostTransaction(_model).Throw();

          withdrawal.WithdrawalStatus = WithdrawalStatus.Paid;
          withdrawal.Message += withdrawal.Message + "--- Paid customer";
          _repo.Withdrawal.Update(withdrawal);
          _repo.SaveChanges();

        }

      });
    }

    public Operation DeclineWithdrawal(long id)
    {
      return Operation.Create(() =>
      {
        var withdrawal = _repo.Withdrawal
                     .FirstOrDefault(c => c.Id == id);

        if (withdrawal == null) throw new Exception("Withdrawal not found");

        withdrawal.IsCancelled = true;

        _repo.Withdrawal.Update(withdrawal);
        _repo.SaveChanges();

      });
    }
    /// <summary>
    /// Get all widthdrawal
    /// </summary>
    /// <returns></returns>
    public Operation<WithdrawalResponseModel[]> GetAllWithdrawal()
    {
      return Operation.Create(() =>
      {

        var query = from o in _repo.Withdrawal
                    join c in _repo.Customer on o.CustomerId equals c.CustomerId
                    join cb in _repo.CustomerBalance on c.CustomerId equals cb.CustomerId
                    join u in _repo.Users on c.UserId equals u.UserId
                    where !c.IsCancelled & c.IsActive
                    select new { o, c, cb, u };


        var lstresponse = new List<WithdrawalResponseModel>();

        foreach (var item in query)
        {

          lstresponse.Add(new WithdrawalResponseModel()
          {
            Message = item.o.Message,
            WithdrawalStatus = item.o.WithdrawalStatus,
            MerchantId = item.o.MerchantId,
            CustomerId = item.o.CustomerId,
            Amount = item.o.Amount,
            CreatedBy = item.o.CreatedBy,
            Customer = new CustomerModel()
            {
              Address = item.c.Address,
              LastName = item.c.LastName,
              City = item.c.City,
              Country = item.c.Country,
              CustomerId = item.c.CustomerId,
              EmailAddress = item.c.EmailAddress,
              FirstName = item.c.FirstName,
              Mobile = item.c.Mobile,
              TotalCustomerBalance = item.cb.CurrentBalance,
              CustomerCode = item.c.CustomerCode,
              MerchantId = item.c.MerchantId,
              UserId = item.u.UserId,
              DateOfBirth = item.c.DateOfBirth,
              CreatedDate = item.o.CreatedDate
            },
            Id = item.o.Id
          });
        }


        return lstresponse.OrderByDescending(c => c.Id).ToArray();
      });
    }

    public Operation<WithdrawalResponseModel[]> GetWithdrawalByMerchantId([Required]long merchantId)
    {
      return Operation.Create(() =>
      {
        var query = (from w in _repo.Withdrawal
                     join c in _repo.Customer on w.CustomerId equals c.CustomerId
                     join u in _repo.Users on c.UserId equals u.UserId
                     where !c.IsCancelled
                     select new WithdrawalResponseModel()
                     {
                       Message = w.Message,
                       WithdrawalStatus = w.WithdrawalStatus,
                       MerchantId = c.MerchantId,
                       Merchant = new MerchantModel()
                       {
                         Id = c.MerchantId,
                       },
                       CustomerId = c.CustomerId,
                       Amount = w.Amount,
                       CreatedBy = c.CreatedBy,
                       CreatedDate = w.CreatedDate,
                       Customer = new CustomerModel()
                       {
                         Address = c.Address,
                         LastName = c.LastName,
                         City = c.City,
                         Country = c.Country,
                         CustomerId = c.CustomerId,
                         EmailAddress = c.EmailAddress,
                         FirstName = c.FirstName,
                         Mobile = c.Mobile,
                         UserName = u.UserName,
                         CustomerCode = c.CustomerCode
                       },
                       Id = w.Id
                     });

        return query.OrderByDescending(c => c.Id).Where(c => c.MerchantId == merchantId).ToArray();
      });
    }

    public Operation<WithdrawalResponseModel[]> GetWithdrawalByMerchantAgentId([Required]long userId)
    {
      return Operation.Create(() =>
      {

        var user = _repo.Users.FirstOrDefault(c => c.UserId == userId);

        if (user == null)
          throw new Exception("User not found");

        var query = (from w in _repo.Withdrawal
                     join c in _repo.Customer on w.CustomerId equals c.CustomerId
                     join u in _repo.Users on c.UserId equals u.UserId
                     where !w.IsCancelled
                     where w.MerchantId == user.MerchantId
                     select new WithdrawalResponseModel()
                     {
                       Message = w.Message,
                       WithdrawalStatus = w.WithdrawalStatus,
                       MerchantId = c.MerchantId,
                       Merchant = new MerchantModel()
                       {
                         Id = c.MerchantId,
                       },
                       CustomerId = c.CustomerId,
                       Amount = w.Amount,
                       CreatedBy = c.CreatedBy,
                       CreatedDate = w.CreatedDate,
                       Customer = new CustomerModel()
                       {
                         Address = c.Address,
                         LastName = c.LastName,
                         City = c.City,
                         Country = c.Country,
                         CustomerId = c.CustomerId,
                         EmailAddress = c.EmailAddress,
                         FirstName = c.FirstName,
                         Mobile = c.Mobile,
                         UserName = u.UserName,
                         CustomerCode = c.CustomerCode
                       },

                       Id = w.Id
                     });
        // .Where(c => c.CreatedBy == userId)
        return query.OrderByDescending(c => c.Id).ToArray();
      });
    }

    public Operation<WithdrawalResponseModel[]> GetWithdrawalByCustomerId([Required]long customerId)
    {
      return Operation.Create(() =>
      {
        var query = (from w in _repo.Withdrawal
                     join c in _repo.Customer on w.CustomerId equals c.CustomerId
                     join u in _repo.Users on c.UserId equals u.UserId
                     where !c.IsCancelled
                     select new WithdrawalResponseModel()
                     {
                       Message = w.Message,
                       WithdrawalStatus = w.WithdrawalStatus,
                       MerchantId = c.MerchantId,
                       Merchant = new MerchantModel()
                       {
                         Id = c.MerchantId,
                       },
                       CustomerId = c.CustomerId,
                       Amount = w.Amount,
                       CreatedBy = c.CreatedBy,
                       CreatedDate = w.CreatedDate,
                       Customer = new CustomerModel()
                       {
                         Address = c.Address,
                         LastName = c.LastName,
                         City = c.City,
                         Country = c.Country,
                         CustomerId = c.CustomerId,
                         EmailAddress = c.EmailAddress,
                         FirstName = c.FirstName,
                         Mobile = c.Mobile,
                         UserName = u.UserName,
                         CustomerCode = c.CustomerCode
                       },
                       Id = w.Id
                     });

        return query.OrderByDescending(c => c.Id).Where(c => c.CustomerId == customerId).ToArray();
      });
    }

    #endregion

  }
}

