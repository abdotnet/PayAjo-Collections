using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Interfaces
{
  public interface ITransactionService
  {
    Operation PostTransaction(TransactionModel model);
    Operation<decimal> GetCustomerCurrentBalance([Required]long customerId);
    Operation<TransactionReponseModel[]> GetCustomerTransactions([Required] long customerId);
    Operation<TransactionReponseModel[]> GetAllTransactions();
    Operation<TransactionModel[]> GetTransactionByAgentUserId([Required]long userId);
    Operation<MerchanTransactionModel[]> GetTransactionByMerchantId([Required]long merchantId);

    Operation<CreditModel> GetCustomerTotalCredit(long customerId);
    Operation PostOfflineTransaction(OfflineModel model);
    Operation PostTransactionForJobs(TransactionJobModel model);

    Operation UpdateTransactionNo();

    Operation<Pagination<TransactionReponseModel>>  GetMerchantTransactions(string search, long UserId, TransType type, int pageIndex, int pageSize = 100);

    Operation<Pagination<TransactionReponseModel>> GetMerchantTransactionLog(string search, long UserId, TransType type, int pageIndex, int pageSize = 100);
    
    Operation PostTransactionLog(TransactionLogger model);
    Operation PostTransactionApproval(long transactionLogId, long userId);
    Operation PostTransactionDecline(long transactionLogId, long userId);

    Operation<Pagination<TransactionReponseModel>> GetMerchantTransactions(SearchModel model, TransType type, long userId);
  }
}
