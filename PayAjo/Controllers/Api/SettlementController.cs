using System;
using System.Collections.Generic;
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
using PayAjo.Domain.Infrastucture.HangFire;
using Serilog;

namespace PayAjo.Controllers.Api
{
  /// <summary>
  /// Settlement Engine  ..
  /// </summary>
  [Produces("application/json")]
  [Route("api/v1/[controller]")]
  public class SettlementController : ApiController
  {

    private readonly IConfiguration _config;
    private readonly IUserRepository _repo;
    private IMapper _mapper;

    private readonly IHangFireService _iHangFireService;
    private readonly ISettlementService _settlement;

    /// <summary>
    /// Settlement controller  
    /// </summary>
    /// <param name="config"></param>
    /// <param name="repo"></param>
    /// <param name="mapper"></param>
    /// <param name="iHangFireService"></param>
    public SettlementController(IConfiguration config, IUserRepository repo, IMapper mapper, IHangFireService iHangFireService, ISettlementService settlement)
    {

      _config = config;
      _repo = repo;
      _mapper = mapper;
      _iHangFireService = iHangFireService;
      _settlement = settlement;

    }

    #region Settlement api

    ///// <summary>
    ///// Tech jobs
    ///// </summary>
    ///// <returns></returns>
    //[HttpGet("tech")]
    //[AllowAnonymous]
    private IActionResult TechjobsDateReset()
    {
      Log.Information($"Currently @ Tech date and debit balance jobs  ");
      var op = _iHangFireService.ResetTechDateJob();

      return Ok(op);
    }

    /// <summary>
    /// Tech job debit customer balance 
    /// </summary>
    /// <returns></returns>
    [NonAction]
    private IActionResult TechJobDebiCustomerBalance()
    {
      var op1 = _iHangFireService.DebitTechCustomerBalanceOnIsChargeableJob();

      return Ok(op1);
    }
    /// <summary>
    /// Sms Jobs
    /// </summary>
    /// <returns></returns>
    [NonAction]
    private IActionResult SmsJobs()
    {
      Log.Information($"Currently @ Sms date and debit balance jobs  ");
      var op = _iHangFireService.WeeklySmsDateResetJob();
      return Ok(op);
    }

    [NonAction]
    private IActionResult SmsJobDebiCustomerBalance()
    {
      var op1 = _iHangFireService.SendWeeklySmsJob();

      return Ok(op1);
    }


    /// <summary>
    /// Sms notification
    /// </summary>
    /// <returns></returns>
    [HttpGet("sms-notify")]
    public async Task<IActionResult> SmsNotification()
    {
      var response = await _settlement.GetSmsNotification(MerchantId);
      var op = new Operation()
      {
        Result = response,
        Succeeded = true
      };
      return Ok(op);
    }

    #endregion
  }
}
