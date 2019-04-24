using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PayAjo.Data.Entities;
using PayAjo.Data.Repository;
using PayAjo.Domain.Core.Models;
using Serilog;

namespace PayAjo.Controllers.Api
{
  /// <summary>
  /// Account controller 
  /// </summary>
  [Produces("application/json")]
  [Route("api/v1/[controller]")]
  public class AccountController : ApiController
  {

    private readonly SignInManager<UserModel> _signInManager;
    private readonly UserManager<UserModel> _userManager;

    private readonly IConfiguration _config;
    private readonly IUserRepository _repo;

    private IMapper _mapper;

    //private TokenConfig _tokenConfig;

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="signInManager"></param>
    /// <param name="userManager"></param>
    /// <param name="config"></param>
    /// <param name="repo"></param>
    /// <param name="mapper"></param>
    public AccountController(SignInManager<UserModel> signInManager,
            UserManager<UserModel> userManager, IConfiguration config, IUserRepository repo, IMapper mapper)
    {
      _signInManager = signInManager;
      _userManager = userManager;
      _config = config;
      _repo = repo;
      _mapper = mapper;

    }


    #region token

    /// <summary>
    /// Create token
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("login")]
    [AllowAnonymous]
    public IActionResult CreateToken([FromBody]LoginModel model)
    {
      var op = UserLogin(model);

      return Ok(op);
    }

    private Operation<Token> UserLogin(LoginModel model)
    {
      return Operation.Create(() =>
      {
        var user = _repo.ValidateUser(model.UserName, model.Password);

        if (user.Succeeded && user.Result.IsActive)
        {
          var claims = new[]
          {
                            new System.Security.Claims.Claim(JwtRegisteredClaimNames.Sub,user.Result.EmailAddress),
                            new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                            new System.Security.Claims.Claim(JwtRegisteredClaimNames.UniqueName,user.Result.EmailAddress),
                            new System.Security.Claims.Claim("UserId",user.Result.UserId.ToString()),
                            new System.Security.Claims.Claim("FirstName",user.Result.FirstName),
                            new System.Security.Claims.Claim("LastName",user.Result.LastName),
                             new System.Security.Claims.Claim("Role",user.Result.Role),
                             new System.Security.Claims.Claim("RoleId",user.Result.RoleId.ToString()),
                            new System.Security.Claims.Claim("UserStatus",user.Result.UserStatus.ToString()),
                            new System.Security.Claims.Claim("MerchantId",user.Result.MerchantId.ToString()),
                             new System.Security.Claims.Claim("MerchantName",user.Result.MerchantName),
                             new System.Security.Claims.Claim("LastLoginDate",user.Result.LastLoginDate.ToString()),
                        };

          var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
          // new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:key"]));
          var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

          var token = new JwtSecurityToken(
              _config["Tokens:Issuer"],
              _config["Tokens:Audience"],
              claims,
              expires: DateTime.UtcNow.AddMinutes(1000000),
              signingCredentials: creds
              );

          var _token = new Token()
          {
            token = new JwtSecurityTokenHandler().WriteToken(token),
            expiration = token.ValidTo,
            user = user.Result
          };

          return _token;
        }
        else
        {
          Log.Information($"Error, user information cannot be found or user is not active");
          throw new Exception("Invalid credentials,either username or password is incorrect or user is not active");

        }
      });
    }
    #endregion

    #region User information

    /// <summary>
    ///  Get paged users
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet("{pageIndex}/{pageSize}")]
    public IActionResult GetUsers(int pageIndex, int pageSize)
    {
      var op = _repo.GetUserDatas(null, UserId, UserType.Customer, pageIndex, pageSize);

      return Ok(op);
    }

    [HttpGet("{pageIndex}/agent/{pageSize}")]
    public IActionResult GetAgentUsers(int pageIndex, int pageSize)
    {
      var op = _repo.GetUserDatas(null, UserId, UserType.Agent, pageIndex, pageSize);

      return Ok(op);
    }

    /// <summary>
    /// Get all users
    /// </summary>
    /// <returns></returns>
    [HttpGet("user")]
    public IActionResult GetAllUsers()
    {
      Log.Information($"Currently at create token from Get All Users");
      var op = _repo.GetUsers();

      return Ok(op);
    }

    /// <summary>
    /// Get User by Id
    /// </summary>
    /// <param name="userid"></param>
    /// <returns></returns>
    [HttpGet("user/{userid}")]
    public IActionResult GetUserById(long userid)
    {
      Log.Information($"Currently at create token from  Get User ById");
      var op = _repo.GetUserByUserId(userid);
      return Ok(op);
    }

    [HttpGet("current-user")]
    public IActionResult GetCurrentUserById()
    {
      Log.Information($"Get currently loggedin user");

      var op = _repo.GetUserByUserId(UserId);

      return Ok(op);
    }

    /// <summary>
    /// Update user profile
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("update-profile")]
    public IActionResult UpdateUserProfile([FromBody]UserModel model)
    {
      if (model != null)
      {
        model.ModifiedBy = UserId;
        model.ModifiedDate = DateTime.UtcNow;
      }

      Log.Information($"Currently at create token from Update User Profile");
      var op = _repo.UpdateProfile(model);
      return Ok(op);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("update-userprofile")]
    public IActionResult UpdateUserWebProfile([FromBody]UserWebModel model)
    {
      if (model != null)
      {
        model.CreatedBy = UserId;
        model.UserId = UserId;
        model.ModifiedBy = UserId;
        model.ModifiedDate = DateTime.UtcNow;
      }

      Log.Information($"Currently at User Profile");
      var op = Operation.Create(() => _repo.UpdateUserWebProfile(model));

      return Ok(op);
    }

    /// <summary>
    /// Register User
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost, Route("register-user")]
    public IActionResult RegisterWebUser([FromBody]UserWebModel model)
    {
      Log.Information($"Currently at create token from Register User");
      if (model != null)
        model.CreatedBy = UserId;

      var op = _repo.AddOrUpdateRegister(model);
      return Ok(op);
    }

    [HttpGet("admin-users-data")]
    public IActionResult GetAllAdminUser()
    {
      var op = _repo.GetUserDataDetails(UserId);
      return Ok(op);
    }

    [HttpGet("admin-users-data/{pageIndex}/{pageSize}")]
    public IActionResult GetAllAdminUserPaged(int pageIndex , int pageSize)
    {
      // var op = _repo.GetUserDataDetails(null,UserId,pageIndex,pageSize);
      var op = _repo.GetUserDatas(null, UserId, UserType.Agent, pageIndex, pageSize);
      return Ok(op);
    }

    
    /// <summary>
    /// Admin records 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("admin-records")]
    public IActionResult GetAllAdminUserSearch([FromBody]SearchModel model)
    {
      var op = _repo.GetUserDataDetails(model, UserId, SystemUserStatus.AdminOrAgent);

      return Ok(op);
    }

    /// <summary>
    ///  Get all customer users
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("customer-users")]
    public IActionResult GetCustomerUser([FromBody]SearchModel model)
    {
      var op = _repo.GetUserDataDetails(model, UserId, SystemUserStatus.Customer);

      return Ok(op);
    }

    // 
    [HttpGet("agent-names")]
    public IActionResult GetAgentNames()
    {
      var op = _repo.GetAllAdminAgents(UserId);

      return Ok(op);
    }
  
    /// <summary>
    ///  Change Password
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("change-password")]
    public IActionResult ChangePassword([FromBody]PasswordChangeModel model)
    {

      if (model != null)
      {
        model.UserId = model.UserId > 0 ? model.UserId : UserId;
        model.ModifiedBy = UserId;
        model.ModifiedDate = DateTime.UtcNow;
      }


      Log.Information($"Currently at create token from Change Password");

      var op = Operation.Create(() => { _repo.ChangePassword(model); });
      return Ok(op);
    }

    /// <summary>
    /// Create Agent
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("agent")]
    public IActionResult CreateAgent([FromBody]AgentModel model)
    {
      var op = _repo.CreateAgent(model);
      return Ok(op);
    }

    /// <summary>
    ///  Validate phone No
    /// </summary>
    /// <param name="phoneno"></param>
    /// <returns></returns>
    [HttpGet("validate-mobile/{phoneno}")]
    public IActionResult ValidatePhoneNo([FromRoute]string phoneno)
    {
      var op = _repo.ValidatePhone(phoneno);

      return Ok(op);
    }

    /// <summary>
    /// Get all merchant agent users 
    /// </summary>
    /// <param name="merchantId"></param>
    /// <returns></returns>
    [HttpGet("merchant/{merchantId}/agent")]
    public IActionResult GetAgentForMerchant(long merchantId)
    {
      var op = _repo.GetMerchantAgentUsers(merchantId);
      return Ok(op);
    }

    /// <summary>
    /// Get list of in active users
    /// </summary>
    /// <param name="merchantId"></param>
    /// <returns></returns>
    [HttpGet("merchant/{merchantId}/inactive")]
    public IActionResult GetListOfInActiveUsers([Required]long merchantId)
    {
      var op = _repo.GetListOfInActiveCustomers(merchantId);
      return Ok(op);
    }

    /// <summary>
    /// Active account of in active user
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    ///

    [HttpPost("activate")]
    public IActionResult ActivateUserAccount([FromBody]NokUpdateModel model)
    {
      if (model != null)
        model.CreatedBy = UserId;

      var op = _repo.ActivateUserAccount(model);

      return Ok(op);
    }

    /// <summary>
    /// Deactivate user and customer 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("de-activate")]
    public IActionResult DeActivateUserAccount([FromBody]DeAcivateUserModel model)
    {
      if (model != null)
        model.CreatedBy = UserId;

      var op = _repo.DeActivateUserAccount(model);
      return Ok(op);
    }
    /// <summary>
    /// Either phone no or username ..to get the password reset code  ..
    /// </summary>
    /// <param name="identity"></param>
    /// <returns></returns>
    [HttpGet("password-resetcode/{identity}")]
    [AllowAnonymous]
    public IActionResult PasswordResetCode([Required]string identity)
    {
      var op = _repo.GetPassordCode(identity);
      return Ok(op);
    }

    /// <summary>
    /// Update password using this api
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>

    [HttpPost("password-resetcode-update")]
    [AllowAnonymous]
    public IActionResult PasswordResetCode([FromBody]RecoverPassword model)
    {
      var op = _repo.PasswordResetUpdate(model);
      return Ok(op);
    }

    #endregion
  }
}
