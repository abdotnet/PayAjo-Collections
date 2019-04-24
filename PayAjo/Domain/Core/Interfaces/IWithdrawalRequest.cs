using PayAjo.Domain.Core.Enum;
using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Interfaces
{
  public interface IWithdrawalService
  {
    Operation<WithdrawalModel> PostWithdrawal(WithdrawalModel model);
    Operation ApprovedWithdrawal(WithdrawApprovalModel model, WithdrawalStatus status);
    Operation<WithdrawalResponseModel[]> GetAllWithdrawal();
    Operation<WithdrawalResponseModel[]> GetWithdrawalByMerchantId([Required]long merchantId);
    Operation<WithdrawalResponseModel[]> GetWithdrawalByMerchantAgentId([Required]long userId);
    Operation<WithdrawalResponseModel[]> GetWithdrawalByCustomerId([Required]long customerId);
    Operation<Pagination<WithdrawalResponseModel>> GetWithdrawalsByMerchant(string search, long UserId, WithdrawalType type, int pageIndex, int pageSize = 100);
    Operation<WithdrawalModel> PostWithdrawalLogger(WithdrawalLogModel model);
    Operation DeclineWithdrawal(long id);
    Operation<Pagination<WithdrawalResponseModel>> GetWithdrawalsByMerchant(SearchModel model, long UserId, WithdrawalType type);

  }
}
