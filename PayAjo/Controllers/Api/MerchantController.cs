using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PayAjo.Data.Repository;
using PayAjo.Domain.Core.Interfaces;
using PayAjo.Domain.Core.Models;
using Serilog;
using System.ComponentModel.DataAnnotations;

namespace PayAjo.Controllers.Api
{
  /// <summary>
  /// Merchant portal 
  /// </summary>
  [Produces("application/json")]
  [Route("api/v1/[controller]")]
  public class MerchantController : ApiController
  {
    private readonly IConfiguration _config;
    private readonly IUserRepository _repo;
    private readonly IMerchantService _merchantService;

    /// <summary>
    /// Merchant controller 
    /// </summary>
    /// <param name="config"></param>
    /// <param name="repo"></param>
    /// <param name="merchantService"></param>
    public MerchantController(IConfiguration config, IUserRepository repo, IMerchantService merchantService)
    {
      _config = config;
      _repo = repo;
      _merchantService = merchantService;
    }


    #region Merchant api

    //[HttpPost]
    private IActionResult CreateMerchant([FromBody]MerchantModel model)
    {
      Log.Information("I am currently in the Create Merchant method");
      var op = _merchantService.AddOrUpdateMerchant(model);

      return Ok(op);
    }
    /// <summary>
    ///  Get Merchant 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetMerchants()
    {
      Log.Information("I am currently in the GetMerchants method");
      var op = _merchantService.GetMerchant();
      return Ok(op);
    }

    /// <summary>
    /// Create mobile merchant
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("registration")]
    [AllowAnonymous]
    public IActionResult CreateMobileMerchant([FromBody]MerchantLoginModel model)
    {
      Log.Information("I am currently in the Create Mobile Merchant method");
      var op = _merchantService.AddMobileMerchant(model);
      return Ok(op);
    }
    /// <summary>
    /// Create Mobile agent  ..
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>

    [HttpPost("agent")]
    [AllowAnonymous]
    public IActionResult CreateMobileAgent([FromBody]AgentModel model)
    {
      // model.CreatedBy = UserId;
      Log.Information("I am currently in the Create Mobile Agent method");
      var op = _merchantService.AddMobileMerchantAgent(model);

      return Ok(op);
    }

    /// <summary>
    ///  Merchant agent transaction information..
    /// </summary>
    /// <returns></returns>
    [HttpGet("agent/{userId}/dashboard")]
    public IActionResult MerchantAgentDashboardInfo(long userId)
    {

      var op = _merchantService.GetAgentDashboard(userId);

      return Ok(op);
    }

    /// <summary>
    /// Get merchant admin dashboard ..
    /// </summary>
    /// <param name="merchantId"></param>
    /// <returns></returns>
    [HttpGet("{merchantId}/admin/dashboard")]
    public IActionResult GetMerchantAdminDashboard([Required]long merchantId)
    {

      var op = _merchantService.GetAdminDashboard(merchantId);

      return Ok(op);
    }
    #endregion
  }
}
