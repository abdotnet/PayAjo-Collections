using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PayAjo.Data.Repository;
using PayAjo.Domain.Core.Interfaces;
using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using Serilog;

namespace PayAjo.Controllers.Api
{
  /// <summary>
  /// Transaction controller  ..
  /// </summary>
  [Produces("application/json")]
  [Route("api/v1/[controller]")]
  public class TransactionController : ApiController
  {
    private readonly IConfiguration _config;
    private readonly IUserRepository _repo;
    private IMapper _mapper;

    private readonly ITransactionService _transactionService;

    /// <summary>
    /// Transaction controller 
    /// </summary>
    /// <param name="config"></param>
    /// <param name="repo"></param>
    /// <param name="mapper"></param>
    /// <param name="transactionService"></param>
    public TransactionController(IConfiguration config, IUserRepository repo, IMapper mapper, ITransactionService transactionService)
    {

      _config = config;
      _repo = repo;
      _mapper = mapper;
      _transactionService = transactionService;
    }

    #region transaction api
    /// <summary>
    /// Get credit transactions
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet("{pageIndex}/credit/{pageSize}")]
    public IActionResult GetCreditTransaction(int pageIndex, int pageSize)
    {
      var op = _transactionService.GetMerchantTransactions(null, UserId, TransType.None, pageIndex, pageSize);

      return Ok(op);
    }

    /// <summary>
    /// Get all debit transactions
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet("{pageIndex}/debit/{pageSize}")]
    public IActionResult GetDebitTransaction(int pageIndex, int pageSize)
    {
      var op = _transactionService.GetMerchantTransactions(null, UserId, TransType.Debit, pageIndex, pageSize);

      return Ok(op);
    }
    /// <summary>
    /// Get all paged transactions
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet("{pageIndex}/{pageSize}")]
    public IActionResult GetTransaction(int pageIndex, int pageSize)
    {
      var op = _transactionService.GetMerchantTransactions(null, UserId, TransType.Credit, pageIndex, pageSize);

      return Ok(op);
    }

    /// <summary>
    /// Get transaction search 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("records")]
    public IActionResult GetTransaction([FromBody]SearchModel model)
    {
      var op = _transactionService.GetMerchantTransactions(model, TransType.Credit, UserId);

      return Ok(op);
    }

    /// <summary>
    /// post transaction
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult PostTransaction([FromBody]TransactionModel model)
    {
      Log.Information($"Posting Transactions  ");
      if (model != null)
        model.CreatedBy = UserId;

      var op = _transactionService.PostTransaction(model);

      return Ok(op);
    }

    /// <summary>
    /// get transaction log
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet("{pageIndex}/logs/{pageSize}")]
    public IActionResult GetTransactionLog(int pageIndex, int pageSize)
    {
      var op = _transactionService.GetMerchantTransactionLog(null, UserId, TransType.Credit, pageIndex, pageSize);

      return Ok(op);
    }

    /// <summary>
    /// post transaction log
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost, Route("log")]
    public IActionResult PostTransactionLog([FromBody]TransactionLogger model)
    {
      Log.Information($"Posting Transactions Log ");

      if (model != null)
      {
        model.CreatedBy = UserId;
      }

      var op = _transactionService.PostTransactionLog(model);

      return Ok(op);
    }

    /// <summary>
    /// APprove transaction..
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [HttpGet, Route("approval/{id}")]
    public IActionResult TransactionApproval(long id)
    {
      Log.Information($"Approval Transactions Log ");

      var op = _transactionService.PostTransactionApproval(id, UserId);

      return Ok(op);
    }


    /// <summary>
    ///  Transaction decline
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet, Route("decline/{id}")]
    public IActionResult TransactionDeline(long id)
    {
      Log.Information($"Deline Transactions Log ");

      var op = _transactionService.PostTransactionDecline(id, UserId);

      return Ok(op);
    }

    /// <summary>
    /// get transacions
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetTransactions()
    {
      var op = _transactionService.GetAllTransactions();
      return Ok(op);
    }

    /// <summary>
    /// get customer transaction by customer id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("customer/{id}")]
    public IActionResult GetCustomerTransactions(long id)
    {
      var op = _transactionService.GetCustomerTransactions(id);
      return Ok(op);
    }
    /// <summary>
    /// get Customer balance 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("customer/{id}/balance")]
    public IActionResult GetCustomerBalance(long id)
    {
      var op = _transactionService.GetCustomerCurrentBalance(id);
      return Ok(op);
    }

    /// <summary>
    /// Get transaction by Agent user Id
    /// </summary>
    /// <param name="userid"></param>
    /// <returns></returns>
    [HttpGet("agent/{userid}")]
    public IActionResult GetTransactionByAgentUserId(long userid)
    {
      var op = _transactionService.GetTransactionByAgentUserId(userid);
      return Ok(op);
    }

    /// <summary>
    /// Get all transaction by merchantId
    /// </summary>
    /// <param name="merchantId"></param>
    /// <returns></returns>
    [HttpGet("merchant/{merchantId}")]
    public IActionResult GetTransactionsByMerchantId(long merchantId)
    {
      var op = _transactionService.GetTransactionByMerchantId(merchantId);
      return Ok(op);
    }

    /// <summary>
    /// Update transaction
    /// </summary>
    /// <returns></returns>
    [HttpGet("update-trans")]
    [AllowAnonymous]
    // [NonAction]
    public IActionResult UpdateTransaction()
    {
      var op = _transactionService.UpdateTransactionNo();

      return Ok(op);
    }

    /// <summary>
    /// Get customer total credit
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    [HttpGet("customer/{customerId}/totalcredit")]
    public IActionResult GetCustomerTotalCreditDaily(long customerId)
    {
      var op = _transactionService.GetCustomerTotalCredit(customerId);
      return Ok(op);
    }

    /// <summary>
    /// Post offline transaction 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("offline-data")]
    public IActionResult PostOfflineTransaction([FromBody]OfflineModel model)
    {
      var op = _transactionService.PostOfflineTransaction(model);
      return Ok(op);
    }
    #endregion
  }
}
