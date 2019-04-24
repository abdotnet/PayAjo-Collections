using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PayAjo.Data.Repository;
using PayAjo.Domain.Core.Enum;
using PayAjo.Domain.Core.Interfaces;
using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using Serilog;
using System.ComponentModel.DataAnnotations;

namespace PayAjo.Controllers.Api
{
  /// <summary>
  /// Withdrawal controller 
  /// </summary>
  [Produces("application/json")]
  [Route("api/v1/[controller]")]
  public class WithdrawalController : ApiController
  {
    private readonly IConfiguration _config;
    private readonly IUserRepository _repo;
    private IMapper _mapper;
    private readonly IWithdrawalService _withdrawService;

    /// <summary>
    /// Withdrawal controller 
    /// </summary>
    /// <param name="config"></param>
    /// <param name="repo"></param>
    /// <param name="mapper"></param>
    /// <param name="withdrawService"></param>
    public WithdrawalController( IConfiguration config, IUserRepository repo, IMapper mapper, IWithdrawalService withdrawService)
    {

      _config = config;
      _repo = repo;
      _mapper = mapper;
      _withdrawService = withdrawService;
    }

    #region Withdrawal api
    /// <summary>
    /// Get withdrawals 
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet("{pageIndex}/{pageSize}")]
    public IActionResult GetWithdrawals(int pageIndex, int pageSize)
    {
      var op = _withdrawService.GetWithdrawalsByMerchant(null, UserId, WithdrawalType.Pending, pageIndex, pageSize);

      return Ok(op);
    }

    /// <summary>
    /// Get approved withdrawal
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet("{pageIndex}/approved/{pageSize}")]
    public IActionResult GetApprovedWithdrawals(int pageIndex, int pageSize)
    {
      var op = _withdrawService.GetWithdrawalsByMerchant(null, UserId, WithdrawalType.Approved, pageIndex, pageSize);

      return Ok(op);
    }

    /// <summary>
    /// Get paid withdrawal
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet("{pageIndex}/paid/{pageSize}")]
    public IActionResult GetPaidWithdrawals(int pageIndex, int pageSize)
    {
      var op = _withdrawService.GetWithdrawalsByMerchant(null, UserId, WithdrawalType.Paid, pageIndex, pageSize);

      return Ok(op);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("records")]
    public IActionResult GetWithdrawalRecord([FromBody]SearchModel model)
    {
      var op = _withdrawService.GetWithdrawalsByMerchant(model,  UserId,WithdrawalType.All);

      return Ok(op);
    }

    /// <summary>
    /// post withdrawal 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult PostWithdrawal([FromBody]WithdrawalModel model)
    {
      Log.Information($"Currently @ Post Withdrawal  ");

      if (model != null)
        model.CreatedBy = UserId;

      var op = _withdrawService.PostWithdrawal(model);

      return Ok(op);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost,Route("web")]
    public IActionResult PostWithdrawalWeb([FromBody]WithdrawalLogModel model)
    {
      Log.Information($"Currently @ Post Withdrawal  ");

      if (model != null)
        model.CreatedBy = UserId;

      var op = _withdrawService.PostWithdrawalLogger(model);

      return Ok(op);
    }

    /// <summary>
    /// get all withdrawal 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetAllWithdrawal()
    {
      var op = _withdrawService.GetAllWithdrawal();
      return Ok(op);
    }

    /// <summary>
    /// get withdrawal by merchant Id
    /// </summary>
    /// <param name="merchantId"></param>
    /// <returns></returns>
    [HttpGet("merchant/{merchantId}")]
    public IActionResult GetWithdrawal(long merchantId)
    {
      var op = _withdrawService.GetWithdrawalByMerchantId(merchantId);
      return Ok(op);
    }
    /// <summary>
    /// get withdrawal by merchant agent id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("merchant/agent/{userId}")]
    public IActionResult WithdrawalByMerchantAgent(long userId)
    {
      var op = _withdrawService.GetWithdrawalByMerchantAgentId(userId);

      return Ok(op);
    }

    /// <summary>
    /// Get transaction agent userId
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    [HttpGet("customer/{customerId}")]
    public IActionResult GetTransactionByAgentUserId(long customerId)
    {
      var op = _withdrawService.GetWithdrawalByCustomerId(customerId);
      return Ok(op);
    }

    /// <summary>
    /// Approve withdrawal amount..
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("approval/agent")]
    public IActionResult ApproveWidthdrawAmount([FromBody]WithdrawApprovalModel model)
    {
      if (model != null)
        model.CreatedBy = UserId;
      var op = _withdrawService.ApprovedWithdrawal(model, WithdrawalStatus.Approved);
      return Ok(op);
    }

    /// <summary>
    /// Paid withdrawal Amount
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("approval/admin")]
    public IActionResult PaidWidthdrawAmount([FromBody]WithdrawApprovalModel model)
    {
      if (model != null)
        model.CreatedBy = UserId;
      var op = _withdrawService.ApprovedWithdrawal(model, WithdrawalStatus.Paid);
      return Ok(op);
    }

    /// <summary>
    /// Withdrawal amount decline 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("decline/{id}")]
    public IActionResult WidthdrawAmountDeline([Required]long id)
    {
      var op = _withdrawService.DeclineWithdrawal(id);
      return Ok(op);
    }
    #endregion
  }
}
