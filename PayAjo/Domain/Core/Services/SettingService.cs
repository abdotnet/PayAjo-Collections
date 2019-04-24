using PayAjo.Data;
using PayAjo.Domain.Core.Interfaces;
using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Microsoft.EntityFrameworkCore;
using PayAjo.Data.Entities;

namespace PayAjo.Domain.Core.Services
{
  public class SettingService : Service, ISettingService
  {
    private readonly PayAjoContext _repo;
    public SettingService(PayAjoContext repo) : base(repo)
    {
      _repo = repo;
    }

    #region Setting Services

    public Operation<Pagination<SettingModel>> GetSettings(string search, int pageIndex, int pageSize = 100)
    {
      return Operation.Create(() =>
      {
        Log.Information("Currently @ the get setting service ");

        var query = _repo.Setting.Where(s => !s.IsActive).ToList();

        long totalCount = query.LongCount();

        if (pageIndex > 0) query = query.Skip(pageSize).Take(pageIndex * pageSize).ToList();

        var lstSetting = new List<SettingModel>();

        query.ForEach(c =>
           lstSetting.Add(new SettingModel()
           {
             IsActive = c.IsActive,
             MerchantId = c.MerchantId,
             SmsUnit = c.SmsUnit,
             TechAmount = c.TechAmount,
             SmsAmount = c.SmsAmount,
           })
         );
        return new Pagination<SettingModel>(lstSetting.ToArray(), totalCount, pageSize, pageIndex);

      });
    }

    public Operation<SettingModel[]> GetSettings()
    {
      return Operation.Create(() =>
      {
        Log.Information("I am currently @ the get setting function");

        var query = _repo.Setting.Include(mer => mer.Merchant)
        .Where(c => !c.IsActive).ToList();

        var lstSettings = new List<SettingModel>();

        foreach (var item in query)
        {
          lstSettings.Add(new SettingModel()
          {
            TechAmount = item.TechAmount,
            SmsAmount = item.SmsAmount,
            SmsUnit = item.SmsUnit,
            IsActive = item.IsActive,
            MerchantId = item.MerchantId,
            Merchant = new MerchantModel()
            {
              Address = item.Merchant.Address,
              BusinessMobile = item.Merchant.BusinessMobile,
              MerchantNo = item.Merchant.MerchantNo,
              Name = item.Merchant.Name
            },
            Id = item.Id
          });
        }


        return lstSettings.ToArray();
      });
    }
    public Operation<SettingModel> GetSetting(long id)
    {
      return Operation.Create(() =>
      {
        Log.Information($"I am currently @ the get setting by Id {id}");

        var query = _repo.Setting.Include(m => m.Merchant).
        Select(item => new SettingModel()
        {
          TechAmount = item.TechAmount,
          SmsAmount = item.SmsAmount,
          Merchant = new MerchantModel()
          {
            Address = item.Merchant.Address,
            BusinessMobile = item.Merchant.BusinessMobile,
            MerchantNo = item.Merchant.MerchantNo,
            Name = item.Merchant.Name
          },
          IsCancelled = item.IsCancelled,
          CreatedDate = item.CreatedDate,
          Id = item.Id

        }).FirstOrDefault(c => c.Id == id);

        return query;
      });
    }

    public Operation<SettingModel[]> GetSettings(long settingId)
    {
      return Operation.Create(() =>
      {
        Log.Information($"I am currently @ the get setting Id {settingId}");

        var query = _repo.Setting.Include(m => m.Merchant).Select(item => new SettingModel()
        {
          SmsAmount = item.SmsAmount,
          TechAmount = item.TechAmount,
          Merchant = new MerchantModel()
          {
            Address = item.Merchant.Address,
            BusinessMobile = item.Merchant.BusinessMobile,
            MerchantNo = item.Merchant.MerchantNo,
            Name = item.Merchant.Name,
            Id = item.Merchant.MerchantId
          },
          IsCancelled = item.IsCancelled,
          CreatedDate = item.CreatedDate,
          Id = item.Id

        }).Where(c => c.Id == settingId).ToArray();

        return query;
      });
    }

    public Operation<SettingModel> AddOrUpdateSetting(SettingModel model)
    {
      return Operation.Create(() =>
      {
        if (model == null)
        {
          Log.Error("Setting cannot be empty");
          throw new Exception("Setting cannot be empty");
        }

        model.Validate().Catch(c => throw new Exception("Error " + c.Message));

        var query = _repo.Setting.FirstOrDefault(c => c.Id == model.Id && !c.IsCancelled);

        if (query == null)
        {
          var merchant = _repo.Merchant.FirstOrDefault(c => c.MerchantId == model.MerchantId);

          if (merchant == null) throw new Exception("Merchant does not  exist");

          query = new Setting()
          {
            CreatedDate = model.CreatedDate,
            MerchantId = model.MerchantId,
            MinimumBalance = model.MinimumBalance,
            SmsAmount = model.SmsAmount,
            TechAmount = model.TechAmount,
            SmsUnit = model.SmsUnit,
            IsCancelled = model.IsCancelled,
            IsActive = model.IsActive,
            CreatedBy = model.CreatedBy.HasValue ? model.CreatedBy.Value : 0
          };

          _repo.Add<Setting>(query);
          _repo.SaveChanges();
        }
        else
        {
          query.MinimumBalance = model.MinimumBalance;
          query.SmsAmount = model.SmsAmount;
          query.TechAmount = model.TechAmount;
          query.SmsUnit = model.SmsUnit;

          query.ModifiedBy = model.ModifiedBy.HasValue ? model.ModifiedBy.Value : 0;
          query.ModifiedDate = DateTime.Now;

          _repo.Update<Setting>(query);
          _repo.SaveChanges();
        }

        return new SettingModel()
        {
          Id = query.Id,
          MinimumBalance = query.MinimumBalance,
          MerchantId = query.MerchantId,
          SmsAmount = query.SmsAmount,
          SmsUnit = query.SmsUnit,
          TechAmount = query.TechAmount,
        };
      });
    }
    public Operation DeleteSetting(long id)
    {
      return Operation.Create(() =>
      {
        var query = _repo.Setting.SingleOrDefault(c => c.Id == id);
        query.IsCancelled = true;

        _repo.Update<Setting>(query);
        _repo.SaveChanges();
        Log.Information($"Setting has been deleted with Id= {id} ");
      });
    }

    #endregion
  }
}
