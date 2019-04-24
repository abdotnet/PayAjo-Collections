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
using Serilog;

namespace PayAjo.Controllers.Api
{

  /// <summary>
  /// Setting controller 
  /// </summary>
  [Produces("application/json")]
  [Route("api/v1/[controller]")]
  public class SettingController : ApiController
  {
  
    private readonly IConfiguration _config;
    private readonly IUserRepository _repo;
    private IMapper _mapper;
    private readonly ISettingService _settingService;

    /// <summary>
    /// Setttings controller 
    /// </summary>
    /// <param name="config"></param>
    /// <param name="repo"></param>
    /// <param name="mapper"></param>
    /// <param name="settingService"></param>
    public SettingController(
    IConfiguration config, IUserRepository repo, IMapper mapper, ISettingService settingService) 
    {
      _config = config;
      _repo = repo;
      _mapper = mapper;
      _settingService = settingService;
    }

    #region Setting api
    /// <summary>
    /// Post settings
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult PostSettings([FromBody]SettingModel model)
    {
      Log.Information($"Currently at setting ");
      model.CreatedBy = UserId;

      var op = _settingService.AddOrUpdateSetting(model);

      return Ok(op);
    }

    /// <summary>
    /// Get settings
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetSettings()
    {
      Log.Information($"Currently at get settings  ");
      var op = _settingService.GetSettings();
      return Ok(op);
    }

    /// <summary>
    /// Get settings by id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult GetSetting(long id)
    {
      Log.Information($"Currently at get settings by setting id {id} ");

      var op = _settingService.GetSetting(id);

      return Ok(op);
    }

    /// <summary>
    /// Delete settings by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public IActionResult DeleteSettings(long id) => Ok(_settingService.DeleteSetting(id));



    #endregion
  }
}
