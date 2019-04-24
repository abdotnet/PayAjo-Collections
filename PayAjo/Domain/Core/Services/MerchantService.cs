using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PayAjo.Data;
using PayAjo.Data.Entities;
using PayAjo.Data.Repository;
using PayAjo.Domain.Core.Interfaces;
using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Services
{
  public class MerchantService : Service, IMerchantService
  {
    private readonly ILogger<MerchantService> _logger;
    private readonly PayAjoContext _repo;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepo;

    /// <summary>
    /// Merchant service  ..
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="repo"></param>
    /// <param name="config"></param>
    /// <param name="mapper"></param>
    /// <param name="userRepo"></param>
    public MerchantService(ILogger<MerchantService> logger, PayAjoContext repo, IConfiguration config, IMapper mapper, IUserRepository userRepo) : base(repo)
    {
      _logger = logger;
      _repo = repo;
      _config = config;
      _mapper = mapper;
      _userRepo = userRepo;
    }

    #region Merchat Service 


    public Operation<Pagination<MerchantModel>> GetMerchants(string search, int pageIndex, int pageSize = 100)
    {
      return Operation.Create(() =>
      {
        _logger.LogInformation("I am currently @ the get merchant ");

        var query = _repo.Merchant.Where(s => !s.IsCancelled).ToList();

        if (!string.IsNullOrEmpty(search))
          query = query.Where(c => c.Name.Contains(search)).ToList();

        long totalCount = query.LongCount();
        if (pageIndex > 0) query = query.Skip(pageSize).Take(pageIndex * pageSize).ToList();

        var merchants = _mapper.Map<IEnumerable<Merchant>, IEnumerable<MerchantModel>>(query).ToArray();

        return new Pagination<MerchantModel>(merchants, totalCount, pageSize, pageIndex);

      });
    }

    public Operation<MerchantModel[]> GetMerchant()
    {
      return Operation.Create(() =>
      {
        _logger.LogInformation("I am currently @ the get merchant ");
        int system_merchant = 1;

        var query = _repo.Merchant.Where(c => !c.IsCancelled).Where(c => c.MerchantId != system_merchant).ToList();

        var lstMerchants = new List<MerchantModel>();

        foreach (var item in query)
        {
          lstMerchants.Add(new MerchantModel()
          {
            Id = item.MerchantId,
            Address = item.Address,
            Name = item.Name,
            State = item.State,
            BusinessMobile = item.BusinessMobile,
            BVN = item.BVN,
            City = item.City,
            Country = item.Country,
            GovtRegNo = item.GovtRegNo,
            MerchantNo = item.MerchantNo,
            IsCancelled = item.IsCancelled,
          });
        }


        return lstMerchants.ToArray();
      });
    }
    public Operation<MerchantModel> GetMerchant(long id)
    {
      return Operation.Create(() =>
      {
        _logger.LogInformation($"I am currently @ the get merchant by Id {id}");

        var query = _repo.Merchant.SingleOrDefault(c => c.MerchantId == id);

        var _query = _mapper.Map<Merchant, MerchantModel>(query);

        return _query;
      });
    }

    public Operation<MerchantModel> AddOrUpdateMerchant(MerchantModel model)
    {
      return Operation.Create(() =>
      {
        if (model == null)
        {
          _logger.LogError("Merchant cannot be empty");
          throw new Exception("Merchant cannot be empty");
        }

        model.Validate().Catch(c => throw new Exception("Error: " + c.Message));

        var query = _repo.Merchant.FirstOrDefault(c => c.MerchantId == model.Id && !c.IsCancelled);

        if (query == null)
        {
          query = new Merchant()
          {
            Address = model.Address,
            BusinessMobile = model.BusinessMobile,
            BVN = model.BVN,
            City = model.City,
            Country = model.Country,
            GovtRegNo = model.GovtRegNo,
            MerchantNo = model.MerchantNo,
            Name = model.Name,
            State = model.State,
            CreatedBy = model.CreatedBy.HasValue ? model.CreatedBy.Value : 0,
            CreatedDate = DateTime.Now
          };

          // = _mapper.Map<MerchantModel, Merchant>(model);
          _repo.Add<Merchant>(query);
          _repo.SaveChanges();
        }
        else
        {
          query.Name = model.Name;
          query.IsCancelled = model.IsCancelled;
          //query.MerchantNo = model.MerchantNo;
          query.State = model.State;
          query.Address = model.Address;
          query.BVN = model.BVN;
          query.City = model.City;
          query.BusinessMobile = model.BusinessMobile;
          query.GovtRegNo = model.GovtRegNo;


          query.ModifiedBy = model.ModifiedBy.HasValue ? model.ModifiedBy.Value : 0;
          query.ModifiedDate = DateTime.Now;

          _repo.Update<Merchant>(query);
          _repo.SaveChanges();
        }

        return new MerchantModel()
        {
          Address = query.Address,
          BusinessMobile = query.BusinessMobile,
          BVN = query.BVN,
          City = query.City,
          Country = query.Country,
          GovtRegNo = query.GovtRegNo,
          MerchantNo = query.MerchantNo,
          Name = query.Name,
          State = query.State,
          Id = query.MerchantId
        };
      });
    }

    public Operation<MerchantModel> DeleteMerchant(long id)
    {
      return Operation.Create(() =>
      {
        var query = _repo.Merchant.SingleOrDefault(c => c.MerchantId == id);
        query.IsCancelled = true;

        _repo.Update<Merchant>(query);
        _repo.SaveChanges();
        _logger.LogInformation($"Merchant has been deleted with Id= {id} ");
        return _mapper.Map<Merchant, MerchantModel>(query);
      });
    }

    public Operation UpdateImages(string fileName, int id)
    {
      return Operation.Create(() =>
      {
        if (!string.IsNullOrEmpty(fileName) || id == 0)
          throw new Exception("filename cannot be empty or merchant not found");

        var merchant = _repo.Merchant.FirstOrDefault(c => c.MerchantId == id);

        if (merchant != null)
        {
          merchant.ImagePath = fileName;
          _repo.Update<Merchant>(merchant);
          _repo.SaveChanges();
        }
      });
    }

    public Operation AddMobileMerchant(MerchantLoginModel model)
    {
      return Operation.Create(() =>
      {
        if (model == null)
          throw new Exception("Merchant information cannot be empty");

        model.Validate().Throw();

        // 1. Create merchant 2. register merchant

        if (string.IsNullOrEmpty(model.BusinessName)) throw new Exception("Business name cannot be empty");

        var merchant = _repo.Merchant.FirstOrDefault(m => m.Name.ToLower().Trim() == model.BusinessName.ToLower().Trim());
        //|| m.EmailAddress == model.EmailAddress
        if (merchant != null) throw new Exception("Merchant already exist");


        var _user = _repo.Users.FirstOrDefault(c => c.UserName.Trim().ToLower() == model.UserName.ToLower().Trim());

        if (_user != null) throw new Exception("User already exist");


        merchant = new Merchant()
        {
          Address = model.Address,
          EmailAddress = model.EmailAddress,
          BusinessMobile = model.Mobile,
          BVN = model.BVN,
          City = model.City,
          Country = model.Country,
          GovtRegNo = model.GovtRegNo,
          MerchantNo = GetMerchantno().Result,
          State = model.State,
          Name = model.BusinessName,
          CreatedBy = model.CreatedBy.HasValue ? model.CreatedBy.Value : 0,
          CreatedDate = model.CreatedDate,
        };

        _repo.Add<Merchant>(merchant);

        var user = _repo.Users.FirstOrDefault(c => c.UserName == model.UserName);

        if (user != null) throw new Exception("User already registered");

        // Save merchant ..
        _repo.SaveChanges();

        _userRepo.AddOrUpdateUserAccount(new UserModel()
        {
          Address = model.Address,
          City = model.City,
          Country = model.Country,
          EmailAddress = model.EmailAddress,
          FirstName = model.FirstName,
          LastName = model.LastName,
          MerchantId = merchant.MerchantId,
          Mobile = model.Mobile,
          Password = model.Password,
          RoleId = Constants.Roles.MerchantAdmin,
          LastLoginDate = DateTime.Now,
          Channel = RegistrationChannel.IsMobile,
          CreatedDate = DateTime.Now,
          CreatedBy = model.CreatedBy,
          UserName = model.UserName,
          IsActive = true
        }).Throw();






      });
    }

    public Operation AddMobileMerchantAgent(AgentModel model)
    {
      return Operation.Create(() =>
      {
        if (model == null)
          throw new Exception("Merchant agent information cannot be empty");

        model.Validate().Throw();

        var merchant = _repo.Merchant.FirstOrDefault(m => m.MerchantId == model.MerchantId);

        if (merchant == null) throw new Exception("Merchant does not exist");

        var user = _repo.Users.FirstOrDefault(c => c.UserName.Trim().ToLower() == model.UserName.Trim().ToLower());

        if (user != null) throw new Exception("User already registered");

        _userRepo.AddOrUpdateUserAccount(new UserModel()
        {
          Address = model.Address,
          EmailAddress = model.EmailAddress,
          FirstName = model.FirstName,
          LastName = model.LastName,
          MerchantId = merchant.MerchantId,
          Mobile = model.PhoneNumber,
          Password = model.Password,
          RoleId = Constants.Roles.MerchantAgent,
          LastLoginDate = DateTime.Now,
          Channel = RegistrationChannel.IsMobile,
          CreatedBy = model.CreatedBy,
          CreatedDate = DateTime.Now,
          UserName = model.UserName
        }).Throw();
      });
    }


    private Operation<string> GetMerchantno() => Operation.Create(() =>
   {
     uint RandomInt(RandomNumberGenerator rng)
     {
       var intByte = new byte[4];
       rng.GetBytes(intByte);
       return BitConverter.ToUInt32(intByte, 0);
     }
     using (var rng = new RNGCryptoServiceProvider())
     {
       var i1 = Math.Abs(RandomInt(rng));
       return $"Mer-{DateTime.Now.ToString("yyddMM")}-{i1.ToString("X")}";
     }
   });

    /// <summary>
    /// Get agent dashboard information .. 
    /// </summary>
    /// <param name="agentUserId"></param>
    /// <returns></returns>
    public Operation<AgentDashboard> GetAgentDashboard(long agentUserId)
    {
      return Operation.Create(() =>
      {
        if (agentUserId <= 0) throw new Exception("Agent user information is not found");

        // 
        var query = _repo.Transaction.Where(c => c.CreatedBy == agentUserId);

        if (query.Count() <= 0) throw new Exception("Agent transaction information is not found");

        // get agent current balance  
        //  var agent_Current_Balance = _repo.MerchantAgentBalance.FirstOrDefault(c => c.AgentId == agentUserId);

        // if (agent_Current_Balance == null) throw new Exception("Agent balance has not been created");

        var startDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 23, 59, 59);
        var endDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0);

        var model = new AgentDashboard();

        #region Debit weekly
        var _endDate = endDate.AddDays(-7);
        model.AgentTotalDebitWeek = query.Where(c => c.CreatedDate >= _endDate && c.CreatedDate <= startDate && c.TransactionType == TransactionType.Debit).Sum(c => c.Amount);

        #endregion

        #region Weekly Credit
        //endDate = DateTime.UtcNow.AddDays(-7);
        model.AgentTotalCreditWeek = query.Where(c => c.CreatedDate >= _endDate && c.CreatedDate <= startDate && c.TransactionType == TransactionType.Credit).Sum(c => c.Amount);
        #endregion

        #region Monthly Credit
        _endDate = endDate.AddDays(-30);
        model.AgentTotalCreditMonth = query.Where(c => c.CreatedDate >= _endDate && c.CreatedDate <= startDate && c.TransactionType == TransactionType.Credit).Sum(c => c.Amount);
        #endregion


        return model;

      });
    }

    /// <summary>
    /// Get agent dashboard information .. 
    /// </summary>
    /// <param name="agentUserId"></param>
    /// <returns></returns>
    public Operation<MerchantDashboard> GetAdminDashboard(long merchantId)
    {
      return Operation.Create(() =>
      {
        if (merchantId <= 0) throw new Exception("Agent user information is not found");

        // 
        var query = _repo.Transaction.Where(c => c.MerchantId == merchantId);

        if (query.Count() <= 0) return new MerchantDashboard();

        // get agent current balance
        var merchant_CurrentBal = _repo.MerchantBalance.FirstOrDefault(c => c.MerchantId == merchantId);

        // if (agent_Current_Balance == null) throw new Exception("Agent balance has not been created");

        var startDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 23, 59, 59);
        var endDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0);

        var model = new MerchantDashboard();

        #region Debit weekly
        var _endDate = endDate.AddDays(-7);
        model.TotalDebitWeek = query.Where(c => c.CreatedDate >= _endDate && c.CreatedDate <= startDate && c.TransactionType == TransactionType.Debit).Sum(c => c.Amount);

        #endregion

        #region Weekly Credit
        //endDate = DateTime.UtcNow.AddDays(-7);
        model.TotalCreditWeek = query.Where(c => c.CreatedDate >= _endDate && c.CreatedDate <= startDate && c.TransactionType == TransactionType.Credit).Sum(c => c.Amount);
        #endregion

        #region Monthly Credit
        _endDate = endDate.AddDays(-30);
        model.TotalCreditMonth = query.Where(c => c.CreatedDate >= _endDate && c.CreatedDate <= startDate && c.TransactionType == TransactionType.Credit).Sum(c => c.Amount);
        #endregion

        // Merchant total balance  ..
        model.TotalBalance = merchant_CurrentBal == null ? 0 : merchant_CurrentBal.Amount;

        return model;

      });
    }
    #endregion

  }
}
