using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PayAjo.Data.Repository;
using PayAjo.Domain.Core.Interfaces;
using PayAjo.Domain.Core.Models;
using Serilog;

namespace PayAjo.Controllers.Api
{
  /// <summary>
  /// Reporting Api
  /// </summary>
  [Produces("application/json")]
  [Route("api/v1/[controller]")]
  public class ReportController : ApiController
  {
    private readonly IConfiguration _config;
    private readonly IUserRepository _repo;
    private IMapper _mapper;
    private readonly IReportingService _reportService;
    private readonly IMerchantService _merchantService;

    /// <summary>
    /// Report controller  
    /// </summary>
    /// <param name="config"></param>
    /// <param name="repo"></param>
    /// <param name="mapper"></param>
    /// <param name="merchantService"></param>
    /// <param name="reportService"></param>
    public ReportController(IConfiguration config, IUserRepository repo,
    IMapper mapper, IMerchantService merchantService, IReportingService reportService)
    {
      _config = config;
      _repo = repo;
      _mapper = mapper;
      _merchantService = merchantService;
      _reportService = reportService;
    }


    #region Report api
    /// <summary>
    /// Get dashboard 
    /// </summary>
    /// <returns></returns>
    [HttpGet("dashboard")]
    public IActionResult GetDashboard()
    {

      var op = _reportService.GetDashboard(UserId);
      return Ok(op);
    }
    /// <summary>
    /// Create Merchant
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [NonAction]
    public IActionResult CreateMerchant([FromBody]MerchantModel model)
    {
      Log.Information("I am currently in the Create Merchant method");
      //model.CreatedBy = UserId;
      var op = _merchantService.AddOrUpdateMerchant(model);

      return Ok(op);
    }

    /// <summary>
    /// Get merchants
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
    /// Create mobile agent
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
    /// Get merchant admin dashboard
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
