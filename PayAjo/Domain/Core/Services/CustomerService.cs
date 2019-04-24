using AutoMapper;
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
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Services
{
  /// <summary>
  /// Customer Services
  /// </summary>
  public class CustomerService : Service, ICustomerService
  {
    private readonly ILogger<CustomerService> _logger;
    private readonly PayAjoContext _repo;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepo;
    private readonly ITransactionService _service;
    private readonly INotificationService _notify;


    /// <summary>
    ///  Customer Service controller  ..
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="repo"></param>
    /// <param name="config"></param>
    /// <param name="mapper"></param>
    /// <param name="userRepo"></param>
    /// <param name="service"></param>
    /// <param name="notify"></param>
    public CustomerService(ILogger<CustomerService> logger, PayAjoContext repo, IConfiguration config,
        IMapper mapper, IUserRepository userRepo, ITransactionService service, INotificationService notify)
        : base(repo)
    {
      _logger = logger;
      _repo = repo;
      _config = config;
      _mapper = mapper;
      _userRepo = userRepo;
      _service = service;
      _notify = notify;
    }

    #region Customer api

    public Operation<Pagination<CustomerModel>> GetCustomers(SearchModel model, StatusCode status, long userId)
    {
      return Operation.Create(() =>
      {

        _logger.LogInformation("I am currently @ the get customer registration ");

        var user = _repo.Users.FirstOrDefault(c => c.UserId == userId);

        if (user == null) throw new Exception("User merchant not found");

        var query = (from c in _repo.Customer
                     join u in _repo.Users on c.UserId equals u.UserId
                     join cb in _repo.CustomerBalance on c.CustomerId equals cb.CustomerId
                     where u.MerchantId == user.MerchantId
                     select new CustomerModel()
                     {
                       Address = c.Address,
                       Channel = c.Channel,
                       City = c.City,
                       Country = c.Country,
                       CreatedBy = c.CreatedBy,
                       CreatedDate = c.CreatedDate,
                       CustomerCode = c.CustomerCode,
                       CustomerId = c.CustomerId,
                       DateOfBirth = c.DateOfBirth,
                       EmailAddress = c.EmailAddress,
                       FirstName = c.FirstName.ToUpper(),
                       Gender = c.Gender,
                       IsCancelled = c.IsCancelled,
                       IsLocked = c.IsLocked,
                       LastName = c.LastName.ToUpper(),
                       MerchantId = c.MerchantId,
                       MiddleName = c.MiddleName,
                       Mobile = c.Mobile,
                       NokEmail = c.NokEmail,
                       NokMobile = c.NokMobile,
                       NokName = c.NokName,
                       NokRelationship = c.NokRelationship,
                       State = c.State,
                       Status = c.IsActive,
                       UserName = u.UserName,
                       UserId = u.UserId,
                       CustomerBalance = cb.CurrentBalance,
                       SignatureContentType = c.SignatureContentType,
                       SignatureContentLength = c.SignatureContentLength,
                       SignaturePath = c.SignaturePath,
                       PictureContentLength = c.PictureContentLength,
                       PictureContentType = c.PictureContentType,
                       PicturePath = c.PicturePath
                     });





        if (!string.IsNullOrEmpty(model.Search))
          query = query.Where(c => c.LastName.Contains(model.Search) || c.FirstName.Contains(model.Search)
          || c.CustomerCode.Contains(model.Search) || c.Mobile.Contains(model.Search) || c.UserName.Contains(model.Search));

        if (!model.StartDate.ToString().Contains("1/1/0001") && !model.EndDate.ToString().Contains("1/1/0001"))
        {

          if (model.StartDate > model.EndDate) throw new Exception("Start date cannot be greater than end date");

          query = query.Where(c => c.CreatedDate >= model.StartDate && c.CreatedDate <= model.EndDate);

        }

        if (status == StatusCode.Active)
        {
          query = query.Where(c => c.Status);
        }
        else if (status == StatusCode.InActive)
        {
          query = query.Where(c => !c.Status);
        }

        long totalCount = query.LongCount();

        query = query.OrderByDescending(c => c.CustomerId).Skip(model.pageIndex * model.pageSize).Take(model.pageSize);

        return new Pagination<CustomerModel>(query.ToArray(), totalCount, model.pageSize, model.pageIndex);
      });
    }

    /// <summary>
    /// Get customer information..
    /// </summary>
    /// <param name="search"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public Operation<Pagination<CustomerModel>> GetCustomers(string search, long userId, StatusCode status, int pageIndex, int pageSize = 100)
    {
      return Operation.Create(() =>
      {
        _logger.LogInformation("I am currently @ the get customer registration ");

        var user = _repo.Users.FirstOrDefault(c => c.UserId == userId);

        if (user == null) throw new Exception("User merchant not found");

        var query = (from c in _repo.Customer
                     join u in _repo.Users on c.UserId equals u.UserId
                     join cb in _repo.CustomerBalance on c.CustomerId equals cb.CustomerId
                     where u.MerchantId == user.MerchantId
                     select new CustomerModel()
                     {
                       Address = c.Address,
                       Channel = c.Channel,
                       City = c.City,
                       Country = c.Country,
                       CreatedBy = c.CreatedBy,
                       CreatedDate = c.CreatedDate,
                       CustomerCode = c.CustomerCode,
                       CustomerId = c.CustomerId,
                       DateOfBirth = c.DateOfBirth,
                       EmailAddress = c.EmailAddress,
                       FirstName = c.FirstName.ToUpper(),
                       Gender = c.Gender,
                       IsCancelled = c.IsCancelled,
                       IsLocked = c.IsLocked,
                       LastName = c.LastName.ToUpper(),
                       MerchantId = c.MerchantId,
                       MiddleName = c.MiddleName,
                       Mobile = c.Mobile,
                       NokEmail = c.NokEmail,
                       NokMobile = c.NokMobile,
                       NokName = c.NokName,
                       NokRelationship = c.NokRelationship,
                       State = c.State,
                       Status = c.IsActive,
                       UserName = u.UserName,
                       UserId = u.UserId,
                       CustomerBalance = cb.CurrentBalance,
                       SignatureContentType = c.SignatureContentType,
                       SignatureContentLength = c.SignatureContentLength,
                       SignaturePath = c.SignaturePath,
                       PictureContentLength = c.PictureContentLength,
                       PictureContentType = c.PictureContentType,
                       PicturePath = c.PicturePath
                     });


        long totalCount = query.LongCount();


        if (!string.IsNullOrEmpty(search))
          query = query.Where(c => c.LastName.Contains(search) || c.FirstName.Contains(search));

        if (status == StatusCode.Active)
        {
          query = query.Where(c => c.Status);
        }
        else if (status == StatusCode.InActive)
        {
          query = query.Where(c => !c.Status);
        }

        query = query.OrderByDescending(c => c.CustomerId).Skip(pageIndex * pageSize).Take(pageSize);

        return new Pagination<CustomerModel>(query.ToArray(), totalCount, pageSize, pageIndex);
      });
    }

    public Operation<CustomerModel[]> GetCustomers()
    {
      return Operation.Create(() =>
      {
        _logger.LogInformation("I am currently @ the get customers ");

        var query = _repo.Customer.Where(c => !c.IsCancelled).ToList();

        var lstCustomers = new List<CustomerModel>();

        foreach (var item in query)
        {
          lstCustomers.Add(new CustomerModel()
          {
            CustomerId = item.CustomerId,
            Address = item.Address,
            FirstName = item.FirstName,
            State = item.State,
            LastName = item.LastName,
            DateOfBirth = item.DateOfBirth,
            City = item.City,
            Country = item.Country,
            Gender = item.Gender,
            MerchantId = item.MerchantId,
            MiddleName = item.MiddleName,
            Mobile = item.Mobile,
            EmailAddress = item.EmailAddress,
            NokEmail = item.NokEmail,
            NokMobile = item.NokMobile,
            NokName = item.NokName,
            Title = item.Title,
            NokRelationship = item.NokRelationship,
            IsCancelled = item.IsCancelled,
            Channel = item.Channel,
            CustomerCode = item.CustomerCode,
            SignatureContentType = item.SignatureContentType,
            SignatureContentLength = item.SignatureContentLength,
            SignaturePath = item.SignaturePath,
            PictureContentLength = item.PictureContentLength,
            PictureContentType = item.PictureContentType,
            PicturePath = item.PicturePath
          });
        }

        return lstCustomers.ToArray();
      });
    }
    public Operation<CustomerModel> GetCustomer(long id)
    {
      return Operation.Create(() =>
      {
        _logger.LogInformation($"I am currently @ the get customer by Id {id}");

        var query = (from c in _repo.Customer
                     join cb in _repo.CustomerBalance on c.CustomerId equals cb.CustomerId
                     join u in _repo.Users on c.UserId equals u.UserId
                     select new CustomerModel()
                     {
                       Address = c.Address,
                       Channel = c.Channel,
                       City = c.City,
                       Country = c.Country,
                       CreatedBy = c.CreatedBy,
                       CustomerId = c.CustomerId,
                       EmailAddress = c.EmailAddress,
                       DateOfBirth = c.DateOfBirth,
                       FirstName = c.FirstName,
                       Gender = c.Gender,
                       LastName = c.LastName,
                       MerchantId = c.MerchantId,
                       MiddleName = c.MiddleName,
                       Mobile = c.Mobile,
                       NokMobile = c.NokMobile,
                       NokEmail = c.NokEmail,
                       NokName = c.NokName,
                       State = c.State,
                       Title = c.Title,
                       NokRelationship = c.NokRelationship,
                       IsCancelled = c.IsCancelled,
                       CreatedDate = c.CreatedDate,
                       CustomerBalance = cb.CurrentBalance,
                       UserName = u.UserName,
                       UserId = u.UserId,
                       TotalCustomerBalance = cb.CurrentBalance,
                       CustomerCode = c.CustomerCode,
                       SignatureContentType = c.SignatureContentType,
                       SignatureContentLength = c.SignatureContentLength,
                       SignaturePath = c.SignaturePath,
                       PictureContentLength = c.PictureContentLength,
                       PictureContentType = c.PictureContentType,
                       PicturePath = c.PicturePath
                     }).FirstOrDefault(c => c.CustomerId == id);

        return query;
      });
    }
    public Operation<CustomerModel> AddOrUpdateCustomer(CustomerModel model)
    {
      return Operation.Create(() =>
      {
        throw new Exception("This method has been deprecated,please use /api/v1/customer/registration ");


        if (model == null)
        {
          _logger.LogError("Customer cannot be empty");
          throw new Exception("Customer cannot be empty");
        }

        model.Validate().Throw();

        var query = _repo.Customer.FirstOrDefault(c => c.CustomerId == model.CustomerId && !c.IsCancelled);

        if (query == null)
        {
          query = new Customer()
          {
            Address = model.Address,
            FirstName = model.FirstName,
            State = model.State,
            LastName = model.LastName,
            DateOfBirth = model.DateOfBirth,
            City = model.City,
            Country = model.Country,
            Gender = model.Gender,
            MerchantId = model.MerchantId,
            MiddleName = model.MiddleName,
            Mobile = model.Mobile,
            EmailAddress = model.EmailAddress,
            NokEmail = model.NokEmail,
            NokMobile = model.NokMobile,
            NokName = model.NokName,
            Title = model.Title,
            NokRelationship = model.NokRelationship,
            IsCancelled = model.IsCancelled,
            Channel = model.Channel,
          };

          _repo.Add<Customer>(query);
          _repo.SaveChanges();
        }
        else
        {
          query.Address = model.Address;
          query.FirstName = model.FirstName;
          query.State = model.State;
          query.LastName = model.LastName;
          query.DateOfBirth = model.DateOfBirth;
          query.City = model.City;
          query.Country = model.Country;
          query.Gender = model.Gender;
          query.MiddleName = model.MiddleName;
          query.Mobile = model.Mobile;
          query.EmailAddress = model.EmailAddress;
          query.NokEmail = model.NokEmail;
          query.NokMobile = model.NokMobile;
          query.NokName = model.NokName;
          query.Title = model.Title;
          query.NokRelationship = model.NokRelationship;
          query.IsCancelled = model.IsCancelled;
          query.Channel = model.Channel;
          query.CustomerCode = model.CustomerCode;


          query.ModifiedBy = model.ModifiedBy.HasValue ? model.ModifiedBy.Value : 0;
          query.ModifiedDate = DateTime.Now;

          _repo.Update<Customer>(query);
          _repo.SaveChanges();
        }

        return new CustomerModel()
        {
          Address = query.Address,
          FirstName = query.FirstName,
          State = query.State,
          LastName = query.LastName,
          DateOfBirth = query.DateOfBirth,
          City = query.City,
          Country = query.Country,
          Gender = query.Gender,
          MiddleName = query.MiddleName,
          Mobile = query.Mobile,
          EmailAddress = query.EmailAddress,
          NokEmail = query.NokEmail,
          NokMobile = query.NokMobile,
          NokName = query.NokName,
          Title = query.Title,
          NokRelationship = query.NokRelationship,
          IsCancelled = query.IsCancelled,
          Channel = query.Channel,
          CustomerId = query.CustomerId
        };
      });
    }

    public Operation<CustomerModel> UpdateCustomer(CustomerModel model)
    {
      return Operation.Create(() =>
      {
        if (model == null)
        {
          _logger.LogError("Customer model cannot be empty");
          throw new Exception("Customer cannot be empty");
        }

        model.Validate().Throw();

        var query = _repo.Customer.FirstOrDefault(c => c.CustomerId == model.CustomerId && !c.IsCancelled);

        if (query == null) throw new Exception("Customer information not found");

        query.Address = model.Address;
        query.FirstName = model.FirstName;
        query.State = model.State;
        query.LastName = model.LastName;
        query.DateOfBirth = model.DateOfBirth;
        query.City = model.City;
        query.Country = model.Country;
        query.Gender = model.Gender;
        query.MiddleName = model.MiddleName;
        query.Mobile = model.Mobile;
        query.EmailAddress = model.EmailAddress;
        query.NokEmail = model.NokEmail;
        query.NokMobile = model.NokMobile;
        query.NokName = model.NokName;
        query.Title = model.Title;
        query.NokRelationship = model.NokRelationship;
        query.IsCancelled = model.IsCancelled;
        query.Channel = model.Channel;
        query.CustomerCode = model.CustomerCode;


        query.ModifiedBy = model.ModifiedBy.HasValue ? model.ModifiedBy.Value : 0;
        query.ModifiedDate = DateTime.Now;

        _repo.Update<Customer>(query);
        _repo.SaveChanges();

        return new CustomerModel()
        {
          Address = query.Address,
          FirstName = query.FirstName,
          State = query.State,
          LastName = query.LastName,
          DateOfBirth = query.DateOfBirth,
          City = query.City,
          Country = query.Country,
          Gender = query.Gender,
          MiddleName = query.MiddleName,
          Mobile = query.Mobile,
          EmailAddress = query.EmailAddress,
          NokEmail = query.NokEmail,
          NokMobile = query.NokMobile,
          NokName = query.NokName,
          Title = query.Title,
          NokRelationship = query.NokRelationship,
          IsCancelled = query.IsCancelled,
          Channel = query.Channel,
          CustomerId = query.CustomerId
        };
      });
    }
    public Operation ResetCustomerBalance([Required]long customerId, long userId)
    {
      return Operation.Create(() =>
      {
        if (customerId <= 0) throw new Exception("Customer Id not found");

        var query = _repo.CustomerBalance.FirstOrDefault(c => c.CustomerId == customerId);

        if (query == null) throw new Exception("Customer balance information not found");

        query.CurrentBalance = 0;
        query.ModifiedBy = userId;
        query.ModifiedDate = DateTime.UtcNow;

        _repo.CustomerBalance.Update(query);
        _repo.SaveChanges();

      });
    }
    public Operation<CustomerLoginModel> AddMobileCustomer(CustomerLoginModel model)
    {
      return Operation.Create(() =>
      {
        if (model == null)
        {
          _logger.LogError("Customer cannot be empty");
          throw new Exception("Customer cannot be empty");
        }

        model.Validate().Throw();

        if (model.MerchantId == 0)
        {
          var user = _repo.Users.FirstOrDefault(c => c.UserId == model.CreatedBy);
          if (user != null)
            model.MerchantId = user.MerchantId;
        }

        if (string.IsNullOrEmpty(model.UserName)) throw new Exception("Customer username cannot be empty");

        model.CustomerCode = string.IsNullOrEmpty(model.CustomerCode) ? CustomerCode : model.CustomerCode;

        var customer = _repo.Customer.FirstOrDefault(c => c.CustomerCode == model.CustomerCode && c.MerchantId == model.MerchantId);

        if (customer != null) throw new Exception($"Customer information already exist with {model.CustomerCode}");

        var _user = _repo.Users.FirstOrDefault(c => c.UserName.Trim().ToLower() == model.UserName.ToLower().Trim());

        if (_user != null) throw new Exception("User information already exist");

        customer = new Customer()
        {
          Address = model.Address,
          FirstName = model.FirstName,
          State = model.State,
          LastName = model.LastName,
          DateOfBirth = model.DateOfBirth,
          City = model.City,
          Country = model.Country,
          Gender = model.Gender,
          MerchantId = model.MerchantId,
          MiddleName = model.MiddleName,
          Mobile = model.Mobile,
          EmailAddress = model.EmailAddress,
          Title = model.Title,
          IsCancelled = model.IsCancelled,
          Channel = model.Channel,
          CreatedBy = model.CreatedBy.HasValue ? model.CreatedBy.Value : 0,
          CreatedDate = DateTime.Now,
          CustomerCode = model.CustomerCode,
          IsActive = model.IsActive,
          NokEmail = model.NokEmail,
          NokMobile = model.NokMobile,
          NokName = model.NokName
        };
        _repo.Add<Customer>(customer);
        _repo.SaveChanges();

        var _cust_bal = new CustomerBalance()
        {
          CurrentBalance = 0,
          CustomerId = customer.CustomerId,
          MerchantId = model.MerchantId,
          CreatedDate = DateTime.UtcNow,
          CreatedBy = 1,
          TechFeeEndDate = DateTime.UtcNow,
          TechFeeStartDate = DateTime.UtcNow,
        };
        _repo.Add<CustomerBalance>(_cust_bal);
        _repo.SaveChanges();


        var userId = _userRepo.AddOrUpdateUserAccount(new UserModel()
        {
          LastLoginDate = DateTime.Now,
          Address = model.Address,
          CustomerId = customer.CustomerId,
          FirstName = model.FirstName,
          EmailAddress = model.EmailAddress,
          Gender = model.Gender,
          LastName = model.LastName,
          MerchantId = model.MerchantId,
          MiddleName = model.MiddleName,
          Mobile = model.Mobile,
          Password = model.Password,
          RoleId = Constants.Roles.Customer,
          Channel = RegistrationChannel.IsMobile,
          CreatedBy = model.CreatedBy.HasValue ? model.CreatedBy.Value : 0,
          CreatedDate = DateTime.Now,
          // CustomerCode = model.CustomerCode,
          IsActive = true,
          UserName = model.UserName.Trim()
        }).Throw();

        return new CustomerLoginModel()
        {
          Address = customer.Address,
          CustomerId = customer.CustomerId,
          MerchantId = customer.MerchantId,
          UserName = model.UserName,
          CustomerCode = model.CustomerCode,
          UserId = userId
        };

      });
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Operation<CustomerModel> DeleteCustomer(long id)
    {
      return Operation.Create(() =>
      {
        var query = _repo.Customer.FirstOrDefault(c => c.CustomerId == id);
        query.IsCancelled = true;

        _repo.Update<Customer>(query);
        _repo.SaveChanges();
        _logger.LogInformation($"Customer has been deleted with Id= {id} ");
        return _mapper.Map<Customer, CustomerModel>(query);
      });
    }

    public Operation UpdateImages(string fileName, int id)
    {
      return Operation.Create(() =>
      {
        if (!string.IsNullOrEmpty(fileName) || id == 0)
          throw new Exception("filename cannot be empty or merchant not found");

        var merchant = _repo.Customer.FirstOrDefault(c => c.CustomerId == id);

        if (merchant != null)
        {
          //merchant.ImagePath = fileName;
          //_repo.Update<Merchant>(merchant);
          //_repo.SaveChanges();
        }
      });
    }

    public Operation<int> SaveUploadCustomer(CustomerInfo[] models)
    {
      return Operation.Create(() =>
     {
       if (models.Count() <= 0) throw new Exception("customer information  not found");

       long merchantId = 2; // DOOR to DOOR alert
       int count = 0;

       foreach (var item in models)
       {

         count++;

         if (count > 100) continue;

         var data = AddMobileCustomer(new CustomerLoginModel()
         {
           Address = item.ADDRESS,
           MerchantId = merchantId,
           DateOfBirth = DateTime.Now,
           EmailAddress = string.IsNullOrEmpty(item.LASTNAME) ? item.FIRSTNAME : item.LASTNAME + $"{count}@payajo.com",
           LastName = string.IsNullOrEmpty(item.LASTNAME) ? item.FIRSTNAME : item.LASTNAME,
           FirstName = string.IsNullOrEmpty(item.FIRSTNAME) ? item.LASTNAME : item.FIRSTNAME,
           MiddleName = item.MIDDLENAME,
           IsSmsNotify = true,
           CreatedBy = 1,
           Mobile = item.PHONENUMBER,
           Password = "password1",
           TransEndDate = DateTime.Now,
           TransStartDate = DateTime.Now,
           RegType = RegType.Customer,
           CreatedDate = DateTime.Now,
           CustomerCode = string.IsNullOrEmpty(item.MASTERNUMBER) ? GenerateUnique().Result.Trim() : item.MASTERNUMBER.Trim(),
           Gender = "Male",
           City = "Lagos",
           State = "Lagos",
           Country = "Nigeria",
           UserName = item.UserName,

         }).Throw();

         _service.PostTransaction(new TransactionModel()
         {
           Amount = decimal.Parse(item.BALANCE),
           CreatedBy = 4,
           CreatedDate = DateTime.Now,
           CustomerId = data.CustomerId,
           MerchantId = data.MerchantId,
           TransactionType = TransactionType.Credit,
           TransactionMessage = "Just joining the payajo",
           TechFeeEndDate = DateTime.Now,
           TechFeeStartDate = DateTime.Now,

         }).Throw();
       }
       return count;

     });
    }

    public Operation UploadPixOrSignature(UploadType type, ImageUpload model)
    {
      return Operation.Create(() =>
      {
        if (model == null) throw new Exception("Upload image not found");

        var customer = _repo.Customer.FirstOrDefault(c => c.CustomerId == model.CustomerId);

        if (customer == null) throw new Exception("Customer not found");

        if (type == UploadType.Picture)
        {
          customer.PicturePath = model.ImagePath;
          customer.PictureContentLength = model.ContentLength;
          customer.PictureContentType = model.ContentType;
          _repo.Customer.Update(customer);
          _repo.SaveChanges();
        }
        else if (type == UploadType.Signature)
        {
          customer.SignaturePath = model.ImagePath;
          customer.SignatureContentLength = model.ContentLength;
          customer.SignatureContentType = model.ContentType;
          _repo.Customer.Update(customer);
          _repo.SaveChanges();
        }

      });
    }
    /// <summary>
    /// merchantId
    /// </summary>
    /// <param name="merchantId"></param>
    /// <returns></returns>
    public Operation<CustomerModel[]> GetCustomerForMerchant([Required]long merchantId)
    {
      return Operation.Create(() =>
      {
        _logger.LogInformation($"Get Customer For Merchant {merchantId} ");

        var query = from c in _repo.Customer
                    join u in _repo.Users on c.UserId equals u.UserId
                    where !c.IsCancelled && c.IsActive
                    where c.MerchantId == merchantId
                    select new { c, u };

        var lstCustomers = new List<CustomerModel>();
        var customer_merchant = _repo.CustomerBalance.Where(c => c.MerchantId == merchantId);
        decimal cus_bal = 0;

        foreach (var itemq in query)
        {
          var item = itemq.c;
          cus_bal = 0;
          if (customer_merchant.Count() > 0)
          {
            var cust_bal = customer_merchant.FirstOrDefault(c => c.CustomerId == item.CustomerId);
            if (cust_bal != null) cus_bal = cust_bal.CurrentBalance;
          }
          lstCustomers.Add(new CustomerModel()
          {
            CustomerId = item.CustomerId,
            Address = item.Address,
            FirstName = item.FirstName,
            State = item.State,
            LastName = item.LastName,
            DateOfBirth = item.DateOfBirth,
            City = item.City,
            Country = item.Country,
            Gender = item.Gender,
            MerchantId = item.MerchantId,
            MiddleName = item.MiddleName,
            Mobile = item.Mobile,
            EmailAddress = item.EmailAddress,
            NokEmail = item.NokEmail,
            NokMobile = item.NokMobile,
            NokName = item.NokName,
            Title = item.Title,
            NokRelationship = item.NokRelationship,
            IsCancelled = item.IsCancelled,
            Channel = item.Channel,
            CustomerCode = item.CustomerCode,
            TotalCustomerBalance = cus_bal,
            UserId = itemq.u.UserId,
            UserName = itemq.u.UserName
          });
        }
        return lstCustomers.ToArray();
      });
    }

    /// <summary>
    /// Get all inactive customers ..
    /// </summary>
    /// <param name="merchantId"></param>
    /// <returns></returns>
    public Operation GetInActiveCustomers([Required]long merchantId)
    {
      return Operation.Create(() =>
      {

        var query = from c in _repo.Customer
                    join u in _repo.Users on c.UserId equals u.UserId
                    where !c.IsCancelled && !c.IsActive
                    where c.MerchantId == merchantId
                    select new { c, u };

        var lstCustomers = new List<CustomerModel>();
        var customer_merchant = _repo.CustomerBalance.Where(c => c.MerchantId == merchantId);
        decimal cus_bal = 0;

        foreach (var itemq in query)
        {
          var item = itemq.c;
          cus_bal = 0;
          if (customer_merchant.Count() > 0)
          {
            var cust_bal = customer_merchant.FirstOrDefault(c => c.CustomerId == item.CustomerId);
            if (cust_bal != null) cus_bal = cust_bal.CurrentBalance;
          }
          lstCustomers.Add(new CustomerModel()
          {
            CustomerId = item.CustomerId,
            Address = item.Address,
            FirstName = item.FirstName,
            State = item.State,
            LastName = item.LastName,
            DateOfBirth = item.DateOfBirth,
            City = item.City,
            Country = item.Country,
            Gender = item.Gender,
            MerchantId = item.MerchantId,
            MiddleName = item.MiddleName,
            Mobile = item.Mobile,
            EmailAddress = item.EmailAddress,
            NokEmail = item.NokEmail,
            NokMobile = item.NokMobile,
            NokName = item.NokName,
            Title = item.Title,
            NokRelationship = item.NokRelationship,
            IsCancelled = item.IsCancelled,
            Channel = item.Channel,
            CustomerCode = item.CustomerCode,
            TotalCustomerBalance = cus_bal,
            UserId = itemq.u.UserId,
            UserName = itemq.u.UserName,
          });
        }
        return lstCustomers.ToArray();

      });
    }

    /// <summary>
    ///  Active Customers 
    /// </summary>
    /// <param name="merchantId"></param>
    /// <param name="customerId"></param>
    /// <returns></returns>
    public Operation ActivateCustomer(CustomerUpdateModel model)
    {
      return Operation.Create(() =>
      {
        var customer = _repo.Customer.FirstOrDefault(c => c.MerchantId == model.MerchantId
        && c.CustomerId == model.CustomerId);

        if (customer == null) throw new Exception("Customer not found");

        customer.IsActive = true;

        customer.NokAddress = model.NokAddress;
        customer.NokEmail = model.NoKEmail;
        customer.NokMobile = model.NokPhone;
        customer.NokName = model.NokName;
        customer.NokRelationship = model.NokRelationship;

        _repo.Customer.Update(customer);
        _repo.SaveChanges();
      });
    }
    public Operation DeActivateCustomer(long merchantId, long customerId)
    {
      return Operation.Create(() =>
      {
        var customer = _repo.Customer.FirstOrDefault(c => c.MerchantId == merchantId
        && c.CustomerId == customerId);

        if (customer == null) throw new Exception("Customer not found");

        customer.IsActive = false;

        _repo.Customer.Update(customer);
        _repo.SaveChanges();
      });
    }

    /// <summary>
    /// get Customer name by customer code ...
    /// </summary>
    /// <param name="customerCode"></param>
    /// <returns></returns>
    public Operation<string> GetCustomerName([Required]string customerCode, long userId)
    {
      return Operation.Create(() =>
      {

        decimal amount = 0;
        var user = _repo.Users.FirstOrDefault(c => c.UserId == userId);

        if (user == null) throw new Exception("User information not found");

        if (string.IsNullOrEmpty(customerCode)) throw new Exception("Customer code cannot be empty");

        var customer = _repo.Customer.FirstOrDefault(c => c.CustomerCode == customerCode.Trim() && c.MerchantId == user.MerchantId);

        if (customer == null) throw new Exception("customer information not found");

        var cust_bal = _repo.CustomerBalance.FirstOrDefault(c => c.CustomerId == customer.CustomerId);

        if (cust_bal != null) amount = cust_bal.CurrentBalance;

        return customer?.LastName + " " + customer?.FirstName + " Bal: " + amount;

      });
    }

    /// <summary>
    /// Send Friday sms 
    /// </summary>
    /// <param name="merchantId"></param>
    /// <returns></returns>

    private Operation UpdateCustomerInfo()
    {
      return Operation.Create(() =>
      {
        var customers = _repo.Customer.ToList();
        foreach (var item in customers)
        {
          if (long.TryParse(item.CustomerCode, out long result))
          {
            //item.CustomerCode = DateTime.UtcNow.Ticks.
          }
        }
      });
    }

    #endregion

  }
}
