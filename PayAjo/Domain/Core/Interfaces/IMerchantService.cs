using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Interfaces
{
  public interface IMerchantService
  {
    Operation<Pagination<MerchantModel>> GetMerchants(string search, int pageIndex, int pageSize = 100);
    Operation<MerchantModel[]> GetMerchant();
    Operation<MerchantModel> GetMerchant(long id);
    Operation<MerchantModel> AddOrUpdateMerchant(MerchantModel model);
    Operation<MerchantModel> DeleteMerchant(long id);
    Operation UpdateImages(string fileName, int id);
    Operation AddMobileMerchant(MerchantLoginModel model);
    Operation AddMobileMerchantAgent(AgentModel model);
    Operation<AgentDashboard> GetAgentDashboard(long agentUserId);
    Operation<MerchantDashboard> GetAdminDashboard(long merchantId);
  }
}
