using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Interfaces
{
  public interface ISettingService
  {
    Operation<Pagination<SettingModel>> GetSettings(string search, int pageIndex, int pageSize = 100);
    Operation<SettingModel[]> GetSettings();
    Operation<SettingModel> GetSetting(long id);
    Operation<SettingModel[]> GetSettings(long settingId);
    Operation<SettingModel> AddOrUpdateSetting(SettingModel model);
    Operation DeleteSetting(long id);
  }
}
