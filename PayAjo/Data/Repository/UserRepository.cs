using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PayAjo.Data.Entities;
using PayAjo.Domain.Core.Interfaces;
using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using PayAjo.Domain.Infrastucture.Helpers;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static PayAjo.Domain.Infrastucture.Constants;

namespace PayAjo.Data.Repository
{
  public class UserRepository : IUserRepository
  {
    private PayAjoContext _db;
    private readonly IMapper _mapper;
    private readonly ILogger<UserRepository> _logger;
    //private readonly INotificationService _notify;
    private readonly Object locker = new object();
    private readonly IConfiguration _config;

    public UserRepository(PayAjoContext db, AutoMapper.IMapper mapper, ILogger<UserRepository> logger, INotificationService notify, IConfiguration config)
    {
      _db = db;
      _mapper = mapper;
      _logger = logger;
     // _notify = notify;
      _config = config;

    }

    public async Task AddClaims(string userId, ClaimModel[] models)
    {
      long u = long.Parse(userId);
      var claimQuery = from userClaim in _db.Set<Claim>()
                       where userClaim.UserId == u
                       select userClaim;

      var userClaims = await claimQuery.ToListAsync();

      //Get Existing Claims
      var existingQueries = from claim in userClaims
                            join model in models
                            on claim.Type equals model.Type
                            select new { claim, model };

      //Update Existing Claims
      foreach (var record in existingQueries)
      {
        record.claim.Value = record.model.Value;
      }

      //Add new Claims
      var newClaims = models.Except(existingQueries.Select(r => r.model));
      foreach (var newClaim in newClaims)
      {
        _db.Add(new Claim
        {
          UserId = long.Parse(userId),
          Type = newClaim.Type,
          Value = newClaim.Value
        });
      }

      _db.SaveChanges();
    }

    public async Task AddSocialLogin(string userId, SocialLoginModel model)
    {
      var socialLogin = Mappers.MapSocialLogin(model);
      _db.Set<SocialLogin>().Add(socialLogin);
      await _db.SaveChangesAsync();
      model.SocialLoginId = socialLogin.SocialLoginId;
    }

    public async Task ChangeStatus(string userId, UserStatus status)
    {
      var user = await _db.FindAsync<User>(userId);
      user.UserStatus = status;
      await _db.SaveChangesAsync();
    }

    public async Task<UserModel> CreateUser(UserModel model)
    {
      var entity = Mappers.MapUser(model);
      _db.Set<User>().Add(entity);
      await _db.SaveChangesAsync();
      model.UserId = entity.UserId;
      return model;
    }

    public async Task DeleteUser(UserModel model)
    {
      var user = _db.Set<User>().Find(model.UserId);
      if (user != null)
      {
        _db.Set<User>().Remove(user);
      }
      await _db.SaveChangesAsync();
    }

    public async Task<UserModel> FindUserBySocialLogin(string loginProvider, string providerKey)
    {
      var query = from socialLogins in _db.Set<SocialLogin>().Include(s => s.User)
                  where socialLogins.Provider == loginProvider
                  where socialLogins.Key == providerKey
                  select socialLogins.User;

      var user = await query.FirstOrDefaultAsync();
      if (user == null) return null;
      return Mappers.MapUser(user);
    }

    public async Task<UserModel[]> FindUsersFromClaim(string type, string value)
    {
      var query = from claims in _db.Set<Claim>()
                  where claims.Type == type
                  where claims.Value == value
                  select claims.User;
      var users = await query.ToListAsync();
      return users.Select(Mappers.MapUser).ToArray();
    }

    public async Task<string> GetPasswordHash(string userId)
    {
      var _u = long.Parse(userId);
      var query = from users in _db.Set<User>()
                  where users.UserId == _u
                  select users.Salt;

      return await query.FirstOrDefaultAsync();
    }

    public async Task<SocialLoginModel> GetSocialLogin(string userId, string loginProvider)
    {
      var query = from socialLogins in _db.Set<SocialLogin>()
                  where socialLogins.UserId == userId
                  where socialLogins.Provider == loginProvider
                  select socialLogins;

      var login = await query.FirstOrDefaultAsync();
      return Mappers.MapSocialLogin(login);
    }

    public async Task<SocialLoginModel[]> GetSocialLogins(string userId)
    {
      var query = from socialLogins in _db.Set<SocialLogin>()
                  where socialLogins.UserId == userId
                  select socialLogins;

      var logins = await query.ToListAsync();
      return logins.Select(Mappers.MapSocialLogin).ToArray();
    }

    public async Task<UserModel> GetUserByEmail(string id)
    {
      var query = from _user in _db.Set<User>()
                  where _user.EmailAddress == id || _user.Mobile == id
                  select _user;

      var user = await query.FirstOrDefaultAsync();

      if (user == null) return null;
      return Mappers.MapUser(user);
    }

    public async Task<UserModel> GetUserById(string userId)
    {
      long _u = long.Parse(userId);

      var query = from users in _db.Set<User>()
                  join roleUser in _db.Set<UserRole>() on users.UserId equals roleUser.UserId
                  join role in _db.Set<Role>() on roleUser.RoleId equals role.RoleId
                  where users.UserId == _u
                  select new { users, role };

      var user = await query.Select(c => c.users).FirstOrDefaultAsync();
      var _role = await query.Select(c => c.role).FirstOrDefaultAsync();

      if (user == null) return null;

      var _customer = _db.Set<Customer>().FirstOrDefault(c => c.UserId == user.UserId);

      return Mappers.MapUser(user, _role, _customer);
    }

    public async Task RemoveClaims(string userId, string[] claimTypes)
    {
      long u = long.Parse(userId);

      var query = from claim in _db.Set<Claim>()
                  where claim.UserId == u
                  where claimTypes.Contains(claim.Type)
                  select claim;
      var claims = await query.ToListAsync();
      _db.RemoveRange(claims);
      await _db.SaveChangesAsync();
    }

    public async Task RemoveSocialLogin(string userId, string loginProvider, string providerKey)
    {
      var query = from socialLogins in _db.Set<SocialLogin>()
                  where socialLogins.UserId.ToString() == userId
                  where socialLogins.Provider == loginProvider
                  where socialLogins.Key == providerKey
                  select socialLogins;

      var socialLogin = await query.FirstOrDefaultAsync();
      if (socialLogin == null) throw new Exception("Social Login not Found");
      _db.Set<SocialLogin>().Remove(socialLogin);
      await _db.SaveChangesAsync();
    }

    public async Task SetClaimValue(string userId, string claimType, string claimValue)
    {
      var query = from users in _db.Set<User>()
                  where users.UserId.ToString() == userId
                  from claims in users.Claims
                  where claims.Type == claimType
                  select claims;

      var claim = await query.FirstOrDefaultAsync();

      claim.Value = claimValue;

      await _db.SaveChangesAsync();
    }

    public async Task<string> SetPasswordHash(string userId, string passwordHash)
    {
      var user = await _db.Set<User>().FindAsync(userId);
      if (user == null) throw new Exception("User Not Found");
      user.Salt = passwordHash;
      await _db.SaveChangesAsync();
      return passwordHash;
    }

    public async Task<UserModel> UpdateUser(UserModel model)
    {
      var user = await _db.Set<User>().FindAsync(model.UserId);
      if (user == null) throw new Exception("User Not Found");
      user.FirstName = model.FirstName;
      user.LastName = model.LastName;
      user.Mobile = model.Mobile;
      user.Gender = model.Gender;
      await _db.SaveChangesAsync();
      return Mappers.MapUser(user);
    }

    public async Task<long> GetUserId(string userName)
    {
      var query = from user in _db.Set<User>()
                  where user.UserName == userName
                  where user.EmailAddress == userName
                  select user;

      var _user = await query.FirstOrDefaultAsync();

      return _user.UserId;

    }

    /// <summary>
    ///  Validate User ...
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public Operation<UserModel> ValidateUser(string username, string password)
    => Operation.Create(() =>
    {
      var query = from user in _db.Set<User>()
                  join userRole in _db.Set<UserRole>() on user.UserId equals userRole.UserId
                  join role in _db.Set<Role>() on userRole.RoleId equals role.RoleId
                  join merc in _db.Set<Merchant>() on user.MerchantId equals merc.MerchantId
                  where user.UserName == username //|| user.Mobile == username || user.EmailAddress == username 
                  select new { user, role, merc };

      var _user = query.Select(c => c.user).FirstOrDefault();
      var _role = query.Select(c => c.role).FirstOrDefault();
      var _merc = query.Select(m => m.merc).FirstOrDefault();


      if (_user == null)
        throw new Exception("Invalid Credentials");

      if (_role == null || _merc == null) throw new Exception("Either role or merchant is missing for this user");

      var _customer = _db.Set<Customer>().FirstOrDefault(c => c.UserId == _user.UserId);

      var encryptedPwd = EncryptPassword(password, _user.Salt);

      UserModel userModel = null;

      if (encryptedPwd == _user.Password)
      {
        userModel = Mappers.MapUser(_user, _role, _merc, _customer); //_mapper.Map<User, UserModel>(user);//  new UserModel(user);
        _user.LastLoginDate = DateTime.Now;
        _db.Update<User>(_user);
        _db.SaveChanges();
        return userModel;
      }
      else throw new Exception("Invalid Credentials");
    });

    public static string EncryptPassword(string password, string salt = "")
    {
      string text = salt + password;
      var UE = new UTF8Encoding();
      byte[] hashValue;
      byte[] message = UE.GetBytes(text);

      SHA512Managed hashString = new SHA512Managed();
      string hex = "";

      hashValue = hashString.ComputeHash(message);
      foreach (byte x in hashValue)
      {
        hex += String.Format("{0:x2}", x);
      }
      return hex;
    }
    private static Operation<string> GenerateUniquePassword() => Operation.Create(() =>
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
        return $"TMP-{DateTime.Now.ToString("yyddMM")}-{i1.ToString("X")}";
      }
    });
    private static Operation<string> GenerateUniqueName() => Operation.Create(() =>
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
        return $"{DateTime.Now.ToString("yyddMM")}";
      }
    });


    public Operation<long> AddOrUpdateUserAccount(UserModel model)
    {

      return Operation.Create(() =>
      {

        if (model == null)
          throw new Exception("User information cannot be empty");

        if (string.IsNullOrEmpty(model.Password))
          throw new Exception("Password cannot be empty");

        if (model.RoleId <= 0)
          throw new Exception("Role  cannot be empty");

        model.Validate().Throw();

        if (string.IsNullOrEmpty(model.UserName)) throw new Exception("Username cannot be empty");

        var user = _db.Set<User>().FirstOrDefault(c => c.UserName.ToLower().Trim() == model.UserName.ToLower().Trim());

        if (user != null)
          throw new Exception("Username already exist");

        var role = _db.Set<Role>().FirstOrDefault(c => c.RoleId == model.RoleId);

        if (role == null)
          throw new Exception("Role not found ");

        user = _db.Set<User>().FirstOrDefault(c => c.UserId == model.UserId);

        string salt = Guid.NewGuid().ToString();


        if (user == null)
        {
          user = new User()
          {
            EmailAddress = model.EmailAddress,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Mobile = model.Mobile,
            Gender = model.Gender,
            Password = EncryptPassword(model.Password, salt),
            CreatedDate = DateTime.Now,
            LastLoginDate = DateTime.Now,
            Salt = salt,
            //UserName = $"{model.FirstName}.{model.LastName}{GenerateUniqueName().Result}",
            IsPhoneConfirmed = true,
            Address = model.Address,
            City = model.City,
            Country = model.Country,
            MerchantId = model.MerchantId,
            State = model.State,
            // MasterCode = model.CustomerCode,
            CreatedBy = model.CreatedBy.HasValue ? model.CreatedBy.Value : 0,
            IsActive = model.IsActive,
            UserName = model.UserName

          };

          _db.Add<User>(user);
          _db.SaveChanges();

          var customer = _db.Set<Customer>().FirstOrDefault(c => c.CustomerId == model.CustomerId);

          if (customer != null)
          {
            customer.UserId = user.UserId;
            _db.Customer.Update(customer);
          }
          _db.Add<UserRole>(new UserRole()
          {
            RoleId = role.RoleId,
            UserId = user.UserId
          });
          _db.SaveChanges();

        }
        else
        {
          user.EmailAddress = model.EmailAddress;
          user.FirstName = model.FirstName;
          user.LastLoginDate = model.LastLoginDate;
          user.LastName = model.LastName;
          user.Gender = model.Gender;
          user.Mobile = model.Mobile;

          _db.Update<User>(user);
          _db.SaveChanges();
        }

        return user.UserId;
      });

    }

    public Operation AddOrUpdateRegister(UserWebModel model)
    {
      return Operation.Create(() =>
      {
        if (model == null) throw new Exception("User information cannot be empty");

        var user = _db.Users.FirstOrDefault(c => c.UserName == model.UserName);

        if (user != null) throw new Exception("User information cannot empty");

        var merch_nt = _db.Users.FirstOrDefault(c => c.UserId == model.CreatedBy);

        if (merch_nt == null) throw new Exception("Merchant cannot be empty");

        if (string.IsNullOrEmpty(model.Role)) throw new Exception("Role must be selected");

        var role = _db.Role.FirstOrDefault(c => c.Name.Trim().ToLower() == model.Role.Trim().ToLower());

        if (role == null) throw new Exception("Role not found");

        AddOrUpdateUserAccount(new UserModel()
        {
          Address = model.Address,
          Channel = RegistrationChannel.IsWeb,
          FirstName = model.FirstName,
          LastName = model.LastName,
          EmailAddress = model.EmailAddress,
          MerchantId = merch_nt.MerchantId,
          Mobile = model.Mobile,
          Password = "password1",
          UserName = model.UserName,
          UserStatus = UserStatus.Verified,
          RoleId = role.RoleId,
          CreatedDate = DateTime.UtcNow,
          CreatedBy = model.CreatedBy,
          LastLoginDate = DateTime.Now,
          Role = model.Role,
          IsActive = model.IsActive,
          Gender = model.Gender,
        }).Throw();

      });
    }
    public Task<Operation> UpdateProfile(UserModel model)
    {

      return Operation.Run(() =>
      {

        if (model == null)
          throw new Exception("User information cannot be empty");

        if (model.UserId <= 0)
          throw new Exception("User information cannot be empty");

        model.Validate();

        var user = _db.Set<User>().FirstOrDefault(c => c.UserId == model.UserId);


        string salt = Guid.NewGuid().ToString();

        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.MiddleName = model.MiddleName;
        user.Gender = model.Gender;
        user.Address = model.Address;
        user.City = model.City;
        user.IsActive = model.IsActive;

        _db.Update<User>(user);

        _db.SaveChanges();

        return Task.CompletedTask;
      });

    }

    public Task<Operation> UpdateUserWebProfile(UserWebModel model)
    {

      return Operation.Run(() =>
      {

        if (model == null)
          throw new Exception("User information cannot be empty");

        if (model.UserId <= 0)
          throw new Exception("User information cannot be empty");

        model.Validate();

        var user = _db.Set<User>().FirstOrDefault(c => c.UserId == model.UserId);


        string salt = Guid.NewGuid().ToString();

        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.MiddleName = model.MiddleName;
        user.Address = model.Address;
        user.Mobile = model.Mobile;
        user.EmailAddress = model.EmailAddress;

        _db.Update<User>(user);
        _db.SaveChanges();

        return Task.CompletedTask;
      });

    }

    public Task<Operation> ChangePassword(PasswordChangeModel model)
    {
      return Operation.Run(() =>
      {
        if (model == null)
          throw new Exception("Password change cannot be null");

        if (model.NewPassword != model.ConfirmPassword)
          throw new Exception("New password and confirm password must be the same");

        model.Validate();

        var user = _db.Set<User>().SingleOrDefault(c => c.UserId == model.UserId);

        if (user == null)
          throw new Exception("User not found ");

        bool flag = false;

        flag = EncryptPassword(model.Password, user.Salt) == user.Password;

        if (flag)
        {
          user.Password = EncryptPassword(model.NewPassword, user.Salt);

          _db.Update<User>(user);
          _db.SaveChanges();
          return Task.CompletedTask;

        }
        else
          throw new Exception("Please enter your old password correctly");
      });
    }
    public Operation<UserModel[]> GetUsers()
    {
      return Operation.Create(() =>
      {

        var query = (from u in _db.Users
                     join ur in _db.UserRole on u.UserId equals ur.UserId
                     join r in _db.Role on ur.RoleId equals r.RoleId
                     join c in _db.Customer on u.UserId equals c.UserId
                     where !u.IsCancelled
                     select new { u, role = r.Name, c }).ToList();

        var _queryUsers = new List<UserModel>();

        query.ForEach(lst =>
              {
                var c = lst.u;
                _queryUsers.Add(new UserModel()
                {
                  Address = c.Address,
                  FirstName = c.FirstName,
                  LastName = c.LastName,
                  Channel = c.Channel,
                  EmailAddress = c.EmailAddress,
                  Gender = c.Gender,
                  Mobile = c.Mobile,
                  MiddleName = c.MiddleName,
                  UserId = c.UserId,
                  UserName = c.UserName,
                  LastLoginDate = c.LastLoginDate,
                  Role = lst.role,
                  UserStatus = c.UserStatus,
                  MerchantId = c.MerchantId,
                  City = c.City,
                  IsActive = c.IsActive,
                  CustomerId = lst.c.CustomerId
                });
              });
        return _queryUsers.ToArray();
      });
    }

    public Operation<UserModel> GetUserByUserId(long userId)
    {
      return Operation.Create(() =>
      {

        var query = (from c in _db.Users
                     where c.UserId == userId
                     select new UserModel
                     {
                       Address = c.Address,
                       FirstName = c.FirstName,
                       LastName = c.LastName,
                       Channel = c.Channel,
                       EmailAddress = c.EmailAddress,
                       Gender = c.Gender,
                       Mobile = c.Mobile,
                       MiddleName = c.MiddleName,
                       UserId = c.UserId,
                       UserName = c.UserName,
                       LastLoginDate = c.LastLoginDate,
                       MerchantId = c.MerchantId,
                       City = c.City,
                       IsActive = c.IsActive,
                     });

        return query.FirstOrDefault();

      });
    }

    public Operation<Pagination<UserModel>> GetUsers(string search, long userId, UserType type, int pageIndex, int pageSize = 100)
    {
      return Operation.Create(() =>
      {
        Log.Information("I am currently @ the get user method ");

        var user = _db.Users.FirstOrDefault(c => c.UserId == userId);

        if (user == null) throw new Exception("User information not found");

        var query = _db.Users.Where(s => !s.IsCancelled && s.MerchantId == user.MerchantId && s.UserType == type)
                    .OrderByDescending(c => c.UserId).ToList();

        if (!string.IsNullOrEmpty(search))
          query = query.Where(c => c.UserName.Contains(search)).ToList();

        long totalCount = query.LongCount();

        if (pageIndex > 0) query = query.Skip(pageSize).Take(pageIndex * pageSize).ToList();

        var _query = new List<UserModel>();
        query.ForEach(c =>
        {
          _query.Add(new UserModel()
          {
            Address = c.Address,
            Channel = c.Channel,
            EmailAddress = c.EmailAddress,
            FirstName = c.FirstName,
            Gender = c.Gender,
            LastName = c.LastName,
            MiddleName = c.MiddleName,
            UserName = c.UserName,
            IsCancelled = c.IsCancelled,
            UserStatus = c.UserStatus,
            UserId = c.UserId,
            Mobile = c.Mobile,
            IsActive = c.IsActive,
            CreatedDate = c.CreatedDate
          });
        });

        return new Pagination<UserModel>(_query.ToArray(), totalCount, pageSize, pageIndex);

      });
    }
    public Operation<Pagination<UserModel>> GetUsers(string search, int pageIndex, int pageSize = 100)
    {
      return Operation.Create(() =>
      {
        Log.Information("I am currently @ the get user method ");

        var query = _db.Users.Where(s => !s.IsCancelled).ToList();

        if (!string.IsNullOrEmpty(search))
          query = query.Where(c => c.UserName.Contains(search)).ToList();

        long totalCount = query.LongCount();

        if (pageIndex > 0) query = query.Skip(pageSize).Take(pageIndex * pageSize).ToList();

        var _query = new List<UserModel>();
        query.ForEach(c =>
              {
                _query.Add(new UserModel()
                {
                  Address = c.Address,
                  Channel = c.Channel,
                  EmailAddress = c.EmailAddress,
                  FirstName = c.FirstName,
                  Gender = c.Gender,
                  LastName = c.LastName,
                  MiddleName = c.MiddleName,
                  UserName = c.UserName,
                  IsCancelled = c.IsCancelled,
                  UserStatus = c.UserStatus,
                  UserId = c.UserId,
                  Mobile = c.Mobile,
                  IsActive = c.IsActive
                });
              });
        // var _query = _mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(query).ToArray();

        return new Pagination<UserModel>(_query.ToArray(), totalCount, pageSize, pageIndex);

      });
    }

    public Operation CreateAgent(AgentModel model)
    {
      return Operation.Create(() =>
      {
        if (model == null) throw new Exception("Operation failed , Agent details cannot be empty");

        if (model.Password != model.ConfirmPassword)
          throw new Exception("Operation failed, Password must be equal confirm password");

        model.Validate().Throw();

        var role = _db.Role.FirstOrDefault(c => c.Name.Trim().ToLower() == "Merchant Agent".Trim().ToLower());

        if (role == null) throw new Exception("User role cannot be found");

        AddOrUpdateUserAccount(new UserModel()
        {
          Address = model.Address,
          Channel = RegistrationChannel.IsMobile,
          CreatedBy = model.CreatedBy,
          DateOfBirth = DateTime.Now,
          EmailAddress = model.EmailAddress,
          FirstName = model.FirstName,
          LastLoginDate = DateTime.UtcNow,
          LastName = model.LastName,
          MiddleName = model.MiddleName,
          Mobile = model.PhoneNumber,
          RoleId = role.RoleId,
          Password = model.Password,
          MerchantId = model.MerchantId,
          IsActive = true,
          UserName = model.UserName
        }).Throw();

      });
    }

    public Operation<string> ValidatePhone(string phoneNo)
    {
      return Operation.Create(() =>
      {

        if (string.IsNullOrEmpty(phoneNo)) throw new Exception("Phoneno cannot be empty");

        // Check if the mobile exist on customer entity .. 
        var customer = _db.Customer.FirstOrDefault(c => c.Mobile == phoneNo);

        if (customer != null)
          return $"Customer {customer.LastName} {customer.FirstName}";

        // Check the phone in user
        var user = _db.Users.FirstOrDefault(c => c.Mobile == phoneNo);

        if (user != null)
          return $"User {user.LastName} {user.FirstName}";

        // check if the mobile exist on merchant 
        var merchant = _db.Merchant.FirstOrDefault(c => c.BusinessMobile == phoneNo);

        if (merchant != null)
          return $"Merchant {merchant.Name}";

        return string.Empty;
      });
    }

    /// <summary>
    /// Get Merchant Agent Users
    /// </summary>
    /// <param name="merchantId"></param>
    /// <returns></returns>
    public Operation<AgenUserUserModel[]> GetMerchantAgentUsers([Required]long merchantId)
    {
      return Operation.Create(() =>
      {
        if (merchantId <= 0) throw new Exception("Merchant information not found");

        var merchant = _db.Merchant.FirstOrDefault(c => c.MerchantId == merchantId);
        if (merchant == null) throw new Exception("Merchant details is not found");

        var query = from _user in _db.Users
                    join _merchant in _db.Merchant on _user.MerchantId equals _merchant.MerchantId
                    join _userRole in _db.UserRole on _user.UserId equals _userRole.UserId
                    join _role in _db.Role on _userRole.RoleId equals _role.RoleId
                    where _role.RoleId == Roles.MerchantAgent
                    select new AgenUserUserModel
                    {
                      AgentName = _user.LastName + " " + _user.FirstName,
                      AgentUserId = _user.UserId,
                      Address = _user.Address,
                      EmailAddress = _user.EmailAddress,
                      Mobile = _user.Mobile,
                      Gender = _user.Gender,
                      CreatedDate = _user.CreatedDate.ToShortDateString(),
                      UserName = _user.UserName
                    };

        return query.ToArray();
      });
    }

    /// <summary>
    /// Get list of active customer ..
    /// </summary>
    /// <param name="merchantId"></param>
    /// <returns></returns>
    public Operation<List<UserModel>> GetListOfInActiveCustomers([Required]long merchantId)
    {
      return Operation.Create(() =>
      {
        var query = (from u in _db.Users
                     join c in _db.Customer on u.UserId equals c.UserId
                     where !u.IsActive && !c.IsActive && !u.IsCancelled
                     where c.MerchantId == merchantId
                     select new { u, c }
                     ).ToList();

        var _query = new List<UserModel>();

        query.ForEach(lst =>
        {
          var c = lst.c;

          _query.Add(new UserModel()
          {
            Address = c.Address,
            Channel = c.Channel,
            EmailAddress = c.EmailAddress,
            FirstName = c.FirstName,
            Gender = c.Gender,
            LastName = c.LastName,
            MiddleName = c.MiddleName,
            UserName = lst.u.UserName,
            IsCancelled = c.IsCancelled,
            UserStatus = lst.u.UserStatus,
            UserId = c.UserId,
            Mobile = c.Mobile,
            MerchantId = c.MerchantId,
            CustomerId = c.CustomerId
          });
        });

        return _query;
      });
    }
    public Operation ActivateUserAccount(NokUpdateModel model)
    {
      return Operation.Create(() =>
      {
        if (model == null) throw new Exception("User data update cannot be empty");

        var user = _db.Users.FirstOrDefault(c => c.UserId == model.UserId);

        if (user == null) throw new Exception("User information cannot be empty");

        user.IsActive = true;
        user.ModifiedBy = model.CreatedBy;
        user.ModifiedDate = DateTime.UtcNow;
        _db.Users.Update(user);
        _db.SaveChanges();
      });
    }
    public Operation DeActivateUserAccount(DeAcivateUserModel model)
    {
      return Operation.Create(() =>
      {
        if (model == null) throw new Exception("User data update cannot be empty");

        var user = _db.Users.FirstOrDefault(c => c.UserId == model.UserId);

        if (user == null) throw new Exception("User information cannot be empty");

        user.IsActive = false;
        user.ModifiedBy = model.CreatedBy;
        user.ModifiedDate = DateTime.UtcNow;

        _db.Users.Update(user);

        _db.SaveChanges();
      });
    }

    public Operation GetPassordCode(string identity)
    {
      return Operation.Create(() =>
      {
        // validate identity
        if (string.IsNullOrEmpty(identity)) throw new Exception("Either phoneno or username cannot be empty");

        var user = _db.Users.FirstOrDefault(c => c.Mobile.Trim() == identity.Trim() || c.UserName.Trim() == identity.Trim());

        if (user == null) throw new Exception("User not found");

        // Log the code and minute in the user table  ..
        string pass_code = string.Empty;
        string message = string.Empty;
        DateTime expire;
        double code_in_minute = 0;
        lock (locker)
        {
          pass_code = DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 7);

          user.PasswordCode = pass_code;
          code_in_minute = double.Parse(_config["System:passwordResetCodeMinute"]);

          expire = DateTime.Now.AddMinutes(code_in_minute);
          user.ResetCodeMinute = expire;
          _db.Users.Update(user);

          message = $@"*DO NOT DISCLOSE* A reset code has been sent to you by PayAjo.Use {pass_code} as your one time code,Expires {expire}";

          // Log for sms
          _db.Notification.Add(new Notification()
          {
            Message = message,
            CreatedBy = user.UserId,
            CreatedDate = DateTime.Now,
            NotificationSystem = NotificationSystem.UserAccount,
            NotificationType = NotificationType.Sms,
            SendToUserId = user.UserId,
            Sender = "ResetCode",
            Recipient = user.Mobile
          });
          _db.SaveChanges();
        }


      });
    }
    public Operation PasswordResetUpdate(RecoverPassword model)
    {
      return Operation.Create(() =>
      {

        if (model == null) throw new Exception("Password recover cannot be empty");

        model.Validate().Throw();

        var user = _db.Users.FirstOrDefault(c => c.PasswordCode == model.Code);

        if (user == null) throw new Exception("User code does not exist");
        double code_in_minute = double.Parse(_config["System:passwordResetCodeMinute"]);

        if (user.ResetCodeMinute.Subtract(DateTime.Now).Minutes > code_in_minute) throw new Exception("Password reset code has expires, please request for a new reset code");

        if (model.Password != model.ConfirmPassword) throw new Exception("Password must be equal confirm password");

        user.Password = EncryptPassword(model.Password, user.Salt);
        user.ModifiedDate = DateTime.UtcNow;
        _db.Users.Update(user);

        _db.SaveChanges();
      });
    }

    public Operation<UserModel[]> GetUserDataDetails(long userId)
    {
      return Operation.Create(() =>
      {
        var user = _db.Users.FirstOrDefault(c => c.UserId == userId);

        if (user == null) throw new Exception("User not found");

        var query = (from c in _db.Users
                     join ur in _db.UserRole on c.UserId equals ur.UserId
                     join r in _db.Role on ur.RoleId equals r.RoleId
                     where c.MerchantId == user.MerchantId
                     where r.RoleId == 2 || r.RoleId == 3
                     select new UserModel
                     {
                       Address = c.Address,
                       FirstName = c.FirstName,
                       LastName = c.LastName,
                       Channel = c.Channel,
                       EmailAddress = c.EmailAddress,
                       Gender = c.Gender,
                       Mobile = c.Mobile,
                       MiddleName = c.MiddleName,
                       UserId = c.UserId,
                       UserName = c.UserName,
                       LastLoginDate = c.LastLoginDate,
                       MerchantId = c.MerchantId,
                       City = c.City,
                       IsActive = c.IsActive,
                       Role = r.Name
                     });

        return query.OrderByDescending(c => c.UserId).ToArray();
      });
    }

    public Operation<Pagination<UserModel>> GetUserDataDetails(SearchModel model, long userId, SystemUserStatus status)
    {
      return Operation.Create(() =>
      {
        var user = _db.Users.FirstOrDefault(c => c.UserId == userId);

        if (user == null) throw new Exception("User not found");

        var query = (from c in _db.Users
                     join ur in _db.UserRole on c.UserId equals ur.UserId
                     join r in _db.Role on ur.RoleId equals r.RoleId
                     where c.MerchantId == user.MerchantId
                     // agent or merchant admin role id 
                     select new UserModel
                     {
                       Address = c.Address,
                       FirstName = c.FirstName,
                       LastName = c.LastName,
                       Channel = c.Channel,
                       EmailAddress = c.EmailAddress,
                       Gender = c.Gender,
                       Mobile = c.Mobile,
                       MiddleName = c.MiddleName,
                       UserId = c.UserId,
                       UserName = c.UserName,
                       LastLoginDate = c.LastLoginDate,
                       MerchantId = c.MerchantId,
                       City = c.City,
                       IsActive = c.IsActive,
                       Role = r.Name,
                       RoleId = r.RoleId
                     });

        if (status == SystemUserStatus.AdminOrAgent)
        {
          query = query.Where(c => c.RoleId == 2 || c.RoleId == 3);
        }
        else if (status == SystemUserStatus.Customer)
        {
          query = query.Where(c => c.RoleId == 4);
        }

        if (!string.IsNullOrEmpty(model.Search))
        {
          query = query.Where(c => c.LastName.Contains(model.Search) || c.FirstName.Contains(model.Search)
          || c.UserName.Contains(model.Search) || c.EmailAddress.Contains(model.Search) || c.Mobile.Contains(model.Search));
        }

        if (!model.StartDate.ToString().Contains("1/1/0001") && !model.EndDate.ToString().Contains("1/1/0001"))
        {

          if (model.StartDate > model.EndDate) throw new Exception("Start date cannot be greater than end date");

          query = query.Where(c => c.CreatedDate >= model.StartDate && c.CreatedDate <= model.EndDate);

        }

        long totalCount = query.LongCount();

        query = query.OrderByDescending(c => c.UserId).Skip(model.pageIndex * model.pageSize).Take(model.pageSize);

        return new Pagination<UserModel>(query.ToArray(), totalCount, model.pageSize, model.pageIndex);
      });
    }

    public Operation<Pagination<UserModel>> GetUserDataDetails(string search, long userId, int pageIndex, int pageSize)
    {
      return Operation.Create(() =>
      {
        var user = _db.Users.FirstOrDefault(c => c.UserId == userId);

        if (user == null) throw new Exception("User not found");

        var query = (from c in _db.Users
                     join ur in _db.UserRole on c.UserId equals ur.UserId
                     join r in _db.Role on ur.RoleId equals r.RoleId
                     where c.MerchantId == user.MerchantId
                     where r.RoleId == 2 || r.RoleId == 3 // agent or merchant admin role id 
                     select new UserModel
                     {
                       Address = c.Address,
                       FirstName = c.FirstName,
                       LastName = c.LastName,
                       Channel = c.Channel,
                       EmailAddress = c.EmailAddress,
                       Gender = c.Gender,
                       Mobile = c.Mobile,
                       MiddleName = c.MiddleName,
                       UserId = c.UserId,
                       UserName = c.UserName,
                       LastLoginDate = c.LastLoginDate,
                       MerchantId = c.MerchantId,
                       City = c.City,
                       IsActive = c.IsActive,
                       Role = r.Name
                     });

        if (!string.IsNullOrEmpty(search))
          query = query.Where(c => c.LastName.Contains(search));

        long totalCount = query.LongCount();

         query = query.Skip(pageIndex * pageSize).Take(pageSize);

        return new Pagination<UserModel>(query.OrderByDescending(c => c.UserId).ToArray(), totalCount, pageSize, pageIndex);
      });
    }

    public Operation<AgentUserModel[]> GetAllAdminAgents(long userId)
    {
      return Operation.Create(() =>
      {
        var user = _db.Users.FirstOrDefault(c => c.UserId == userId);

        if (user == null) throw new Exception("User information cannot be empty");

        var query = (from u in _db.Users
                     join ur in _db.UserRole on u.UserId equals ur.UserId
                     join r in _db.Role on ur.RoleId equals r.RoleId
                     // where !u.IsActive && !u.IsCancelled
                     where u.MerchantId == user.MerchantId && (r.RoleId == 2 || r.RoleId == 3)
                     select new AgentUserModel
                     {
                       Name = u.LastName + " " + u.FirstName + " Username: " + u.UserName,
                       AgentUserId = u.UserId
                     }
                     ).OrderByDescending(u => u.AgentUserId).ToArray();

        return query;
      });
    }

    public Operation<Pagination<UserModel>> GetUserDatas(string search, long userId, UserType type, int pageIndex, int pageSize = 100)
    {
      return Operation.Create(() =>
      {
        var user = _db.Users.FirstOrDefault(c => c.UserId == userId);
        if (user == null) throw new Exception("User not found");

        var query = (from c in _db.Users
                     join ur in _db.UserRole on c.UserId equals ur.UserId
                     join r in _db.Role on ur.RoleId equals r.RoleId
                     where c.MerchantId == user.MerchantId
                     select new UserModel
                     {
                       Address = c.Address,
                       FirstName = c.FirstName,
                       LastName = c.LastName,
                       Channel = c.Channel,
                       EmailAddress = c.EmailAddress,
                       Gender = c.Gender,
                       Mobile = c.Mobile,
                       MiddleName = c.MiddleName,
                       UserId = c.UserId,
                       UserName = c.UserName,
                       LastLoginDate = c.LastLoginDate,
                       MerchantId = c.MerchantId,
                       City = c.City,
                       IsActive = c.IsActive,
                       Role = r.Name,
                       RoleId = r.RoleId
                     });

        if (!string.IsNullOrEmpty(search))
          query = query.Where(c => c.LastName.Contains(search) || c.FirstName.Contains(search));

        if (type == UserType.Agent)
        {
          query = query.Where(c => c.RoleId == 2 || c.RoleId == 3);
        }
        else if (type == UserType.Customer)
        {
          query = query.Where(c => c.RoleId == 4);
        }


        long totalCount = query.LongCount();
         query = query.Skip(pageIndex * pageSize).Take(pageSize);

        return new Pagination<UserModel>(query.OrderByDescending(c => c.UserId).ToArray(), totalCount, pageSize, pageIndex);
      });
    }

  }
}
