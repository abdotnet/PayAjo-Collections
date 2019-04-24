using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using PayAjo.Data.Repository;
using PayAjo.Domain.Core.Interfaces;
using PayAjo.Domain.Core.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayAjo.Controllers.Api
{
  /// <summary>
  /// Customer Controller ..
  /// </summary>
  [Produces("application/json")]
  [Route("api/v1/[controller]")]
  public class CustomerController : ApiController
  {
    private readonly IConfiguration _config;
    private readonly IHostingEnvironment _env;
    private readonly IUserRepository _repo;
    private readonly ICustomerService _customerService;
    private readonly INotificationService _notify;

    /// <summary>
    ///  Customer controller  ..
    /// </summary>
    /// <param name="signInManager"></param>
    /// <param name="userManager"></param>
    /// <param name="config"></param>
    /// <param name="repo"></param>
    /// <param name="mapper"></param>
    /// <param name="customerService"></param>
    /// <param name="env"></param>
    /// <param name="notify"></param>
    public CustomerController(IConfiguration config, IUserRepository repo,
        ICustomerService customerService, IHostingEnvironment env, INotificationService notify)
    {
      _config = config;
      _repo = repo;
      _customerService = customerService;
      _env = env;
      _notify = notify;
    }

    #region customer 

    /// <summary>
    /// Get Customer information paged
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet("{pageIndex}/{pageSize}")]
    public IActionResult GetCustomer(int pageIndex, int pageSize)
    {
      var op = _customerService.GetCustomers(null, UserId, Domain.Core.Models.StatusCode.Both, pageIndex, pageSize);

      return Ok(op);
    }

    /// <summary>
    /// get customer information ..
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("records")]
    public IActionResult GetCustomer([FromBody]SearchModel model)
    {
      var op = _customerService.GetCustomers(model, Domain.Core.Models.StatusCode.Both, UserId);

      return Ok(op);
    }

    /// <summary>
    /// Get active customers
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet("{pageIndex}/active/{pageSize}")]
    public IActionResult GetActiveCustomer(int pageIndex, int pageSize)
    {
      var op = _customerService.GetCustomers(null, UserId, Domain.Core.Models.StatusCode.Active, pageIndex, pageSize);

      return Ok(op);
    }
    /// <summary>
    /// Get in active customers
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet("{pageIndex}/in-active/{pageSize}")]
    public IActionResult GetInActiveCustomer(int pageIndex, int pageSize)
    {
      var op = _customerService.GetCustomers(null, UserId, Domain.Core.Models.StatusCode.InActive, pageIndex, pageSize);

      return Ok(op);
    }

    ///// <summary>
    ///// Create customers
    ///// </summary>
    ///// <param name="model"></param>
    ///// <returns></returns>
    //[HttpPost]
    private IActionResult CreateCustomer([FromBody]CustomerModel model)
    {
      Log.Information($"Currently on random  Create Customer");
      var op = _customerService.AddOrUpdateCustomer(model);
      return Ok(op);
    }

    /// <summary>
    /// register customers
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("registration")]
    [AllowAnonymous]
    public IActionResult CreateMobileCustomer([FromBody]CustomerLoginModel model)
    {
      if (model != null)
      {
        if (model.RegType == RegType.Agent) model.CreatedBy = UserId;
      }

      Log.Information($"Currently on Create  Customer");

      var op = _customerService.AddMobileCustomer(model);
      return Ok(op);
    }

    /// <summary>
    /// Create registration
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("registration-web")]
    public IActionResult CreateWebCustomer([FromBody]CustomerWebLoginModel model)
    {
      if (model != null)
      {
        if (model.RegType == RegType.Agent) model.CreatedBy = UserId;
      }

      Log.Information($"Currently on Create  Customer");

      var op = _customerService.AddMobileCustomer(new CustomerLoginModel()
      {
        Address = model.Address,
        Channel = Data.Entities.RegistrationChannel.IsWeb,
        City = model.City,
        CreatedBy = UserId,
        CreatedDate = model.CreatedDate,
        CustomerCode = model.CustomerCode,
        DateOfBirth = model.DateOfBirth,
        EmailAddress = model.EmailAddress,
        FirstName = model.FirstName,
        Gender = model.Gender,
        LastName = model.LastName,
        MerchantId = MerchantId,
        Mobile = model.Mobile,
        Password = "password1",
        RegType = RegType.Customer,
        MiddleName = model.MiddleName,
        UserName = model.UserName,
        IsActive = true
      });

      return Ok(op);
    }

    /// <summary>
    /// Reset customer balance 
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    [HttpGet("reset-customer/{customerId}/balance")]
    public IActionResult ResetCustomerBalance([Required]long customerId)
    {
      var op = _customerService.ResetCustomerBalance(customerId, UserId);

      return Ok(op);
    }

    /// <summary>
    /// Get all customers 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetCustomers()
    {
      Log.Information($"Currently at create token from  Get Customers");
      var op = _customerService.GetCustomers();

      return Ok(op);
    }

    /// <summary>
    /// Get customer by customer Id
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    [HttpGet("{customerId}")]
    public IActionResult GetCustomerById([Required]long customerId)
    {
      Log.Information($"Get customer Id");
      var op = _customerService.GetCustomer(customerId);

      return Ok(op);
    }

    /// <summary>
    ///  Get customer by customer Id
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    [HttpGet("{customerId}/item")]
    public IActionResult GetCustomerByCustId([Required]long customerId)
    {
      Log.Information($"Currently at create token from  Get CustomerById");
      var op = _customerService.GetCustomer(customerId);

      return Ok(op);
    }

    /// <summary>
    /// Update customer 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("update")]
    public IActionResult UpdateCustomer([FromBody]CustomerModel model)
    {
      if (model != null)
        model.CreatedBy = UserId;

      Log.Information($"Update customer api ");

      var op = _customerService.UpdateCustomer(model);

      return Ok(op);
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("image-upload/{id}"), DisableRequestSizeLimit]
    [AllowAnonymous]
    public IActionResult UploadPicture(long id)
    {
      var files = Request.Form.Files;
      var file = files.FirstOrDefault();

      if (file == null || file.Length == 0)
        return Content("file not selected");

      string webRootPath = _env.WebRootPath;


      string _path = Path.Combine(
                         webRootPath, "assets/images");

      string fileName = string.Empty;

      string path = string.Empty;
      string appurl = _config["Appurl"];
      string rootPath = string.Empty;

      foreach (var item in files)
      {
        fileName = DateTime.Now.Ticks.ToString().Substring(13) + item.FileName;

        path = Path.Combine(_path, fileName);

        if (!System.IO.Directory.Exists(_path))
        {
          System.IO.Directory.CreateDirectory(_path);
        }
        using (Stream stream = item.OpenReadStream())
        {
          using (var binaryReader = new BinaryReader(stream))
          {
            var fileContent = binaryReader.ReadBytes((int)item.Length);

            // Make sure the path to the file exists
            using (var _stream = new FileStream(path, FileMode.Create))
            {
              item.CopyTo(_stream);
            }
          }


          rootPath = appurl + "assets/images/" + fileName;
          if (item.Name.ToLower() == "picture")
          {
            var op = _customerService.UploadPixOrSignature(UploadType.Picture,
           new ImageUpload()
           {
             CustomerId = id,
             ContentLength = (int)item.Length,
             ContentType = item.ContentType,
             ImagePath = rootPath
           });
          }
          else if (item.Name.ToLower() == "signature")
          {
            var op = _customerService.UploadPixOrSignature(UploadType.Signature,
          new ImageUpload()
          {
            CustomerId = id,
            ContentLength = (int)item.Length,
            ContentType = item.ContentType,
            ImagePath = rootPath
          });
          }


        }
      }

      return Ok(new Operation()
      {
        Succeeded = true
      });
    }

    /// <summary>
    /// Upload file .
    /// </summary>
    /// <returns></returns>
    [HttpPost("file"), DisableRequestSizeLimit]
    [AllowAnonymous]
    public IActionResult UploadFile()
    {
      var files = Request.Form.Files;
      var file = files.FirstOrDefault();

      if (file == null || file.Length == 0)
        return Content("file not selected");

      string fileName = DateTime.Now.Ticks.ToString().Substring(13) + file.FileName;

      //string fileName = file.FileName;

      string webRootPath = _env.WebRootPath;


      string _path = Path.Combine(
                         webRootPath, "assets");

      string path = Path.Combine(_path, fileName);

      if (!System.IO.Directory.Exists(_path))
      {
        System.IO.Directory.CreateDirectory(_path);
      }

      using (Stream stream = file.OpenReadStream())
      {
        using (var binaryReader = new BinaryReader(stream))
        {
          var fileContent = binaryReader.ReadBytes((int)file.Length);
          // var result = _service.UploadFile(fileContent, file.FileName, file.ContentType);

          // Make sure the path to the file exists
          using (var _stream = new FileStream(path, FileMode.Create))
          {
            file.CopyTo(_stream);
          }

          var op = Import(path);

          var __ = new Operation();
          if (op.Succeeded)
          {
            var _op = _customerService.SaveUploadCustomer(op.Result);

            return Ok(_op);
          }

          return Ok(__);

        }
      }
    }

    //[HttpGet]
    //[Route("Import")]
    private Operation<CustomerInfo[]> Import(string path)
    {
      return Operation.Create(() =>
      {
        var customers = new List<CustomerInfo>();

        FileInfo file = new FileInfo(path);

        using (ExcelPackage package = new ExcelPackage(file))
        {
          StringBuilder sb = new StringBuilder();
          ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
          int rowCount = worksheet.Dimension.Rows;
          int ColCount = worksheet.Dimension.Columns;
          CustomerInfo customer = null;
          List<string> lstPhone = new List<string>();
          for (int row = 2; row <= rowCount; row++)
          {
            customer = new CustomerInfo();

            try
            {
              customer.MASTERNUMBER = worksheet.Cells[row, 1].Value.ToString();
            }
            catch (Exception ex)
            {
              Debug.Write($"Please check line {row}, it has an issue" + ex.Message);
            }

            try
            {
              // customer.FIRSTNAME = worksheet.Cells[row, 2].Value.ToString();
              customer.FIRSTNAME = worksheet.Cells[row, 2].Value.ToString().Split(' ')[0];
              //if (string.IsNullOrEmpty(customer.FIRSTNAME)) throw new Exception("Name not found");

            }
            catch (Exception ex)
            {
              Debug.Write($"Please check line {row}, it has an issue" + ex.Message);
            }
            try
            {
              //customer.MIDDLENAME = worksheet.Cells[row, 3].Value.ToString();
              //if (string.IsNullOrEmpty(customer.FIRSTNAME)) throw new Exception("Name not found");

            }
            catch (Exception ex)
            {
              Debug.Write($"Please check line {row}, it has an issue" + ex.Message);
            }
            try
            {
              // customer.LASTNAME = worksheet.Cells[row, 4].Value.ToString();
              customer.LASTNAME = worksheet.Cells[row, 2].Value.ToString().Split(' ')[1];
              //if (string.IsNullOrEmpty(customer.FIRSTNAME)) throw new Exception("Name not found");

            }
            catch (Exception ex)
            {
              Debug.Write($"Please check line {row}, it has an issue" + ex.Message);
            }

            try
            {
              customer.ADDRESS = worksheet.Cells[row, 3].Value.ToString();
            }
            catch (Exception ex)
            {
              Debug.Write($"Please check line {row}, it has an issue" + ex.Message);
            }

            try
            {
              customer.PHONENUMBER = worksheet.Cells[row, 4].Value.ToString();

              if (string.IsNullOrEmpty(customer.PHONENUMBER)) throw new Exception("Phoneno not found");

              foreach (var item in customers)
              {
                if (item.PHONENUMBER == customer.PHONENUMBER) lstPhone.Add($"Line {row} has {customer.PHONENUMBER} repeated");
              }

            }
            catch (Exception ex)
            {
              Debug.Write($"Please check line {row}, it has an issue" + ex.Message);
            }

            try
            {
              customer.BALANCE = "1";
            }
            catch (Exception ex)
            {
              Debug.Write($"Please check line {row}, it has an issue" + ex.Message);
            }

            try
            {
              customer.TRANSACTIONDATE = DateTime.UtcNow.ToShortDateString();
              string name = customer.LASTNAME ?? customer.FIRSTNAME;

              customer.UserName = (name.ToLower() + customer.PHONENUMBER.Substring(customer.PHONENUMBER.Length - 3) +
              DateTime.Now.Ticks.ToString().Substring(DateTime.Now.Ticks.ToString().Length - 4)).Trim();

            }
            catch (Exception ex)
            {
              Debug.Write($"Please check line {row}, it has an issue" + ex.Message);

            }
            customers.Add(customer);

          }

          var lsterrors = lstPhone;

          return customers.ToArray();
        };

      });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="phoneno"></param>
    /// <returns></returns>
    [HttpGet("send-sms/{phoneno}")]
    [AllowAnonymous]
    public IActionResult SendSms([Required]string phoneno)
    {

      var op = _notify.SendEBulkSms(null, "₦2,000 has been paid to PayAjo Inc. While testing the sms api", new string[] { phoneno }, flash: 0);
      return Ok(op);
    }

    /// <summary>
    /// Get all customer for a merchant 
    /// </summary>
    /// <param name="merchantId"></param>
    /// <returns></returns>
    [HttpGet("merchant/{merchantId}")]
    public IActionResult GetCustomerForMerchant([Required]long merchantId)
    {
      Log.Information($"Currently at get Customers by merchant");

      var op = _customerService.GetCustomerForMerchant(merchantId);
      return Ok(op);
    }

    /// <summary>
    ///Activate customers
    /// </summary>
    /// <returns></returns>
    [HttpPost("activate-customers")]
    public IActionResult ActivateCustomer([FromBody]CustomerUpdateModel model)
    {
      var op = _customerService.ActivateCustomer(model);
      return Ok(op);
    }

    /// <summary>
    ///  de inactive customers 
    /// </summary>
    /// <returns></returns>
    [HttpPost("deactivate-customers")]
    public IActionResult DeActivateCustomer([FromBody]CustomerUpdateModel model)
    {
      var op = _customerService.DeActivateCustomer(model.MerchantId, model.CustomerId);
      return Ok(op);
    }

    /// <summary>
    /// Get all inactive customers 
    /// </summary>
    /// <returns></returns>
    [HttpGet("merchant/{merchantId}/inactive-customers")]
    public IActionResult GetAllInActiveCustomers(long merchantId)
    {
      var op = _customerService.GetInActiveCustomers(merchantId);
      return Ok(op);
    }

    /// <summary>
    /// Get Customer code by customer name..
    /// </summary>
    /// <param name="customerCode"></param>
    /// <returns></returns>
    [HttpGet("{customerCode}")]
    public IActionResult GetCustomerNameByCode([Required]string customerCode)
    {
      var op = _customerService.GetCustomerName(customerCode, UserId);
      return Ok(op);
    }

    /// <summary>
    /// Send weekend messages 
    /// </summary>
    /// <param name="merchantid"></param>
    /// <returns></returns>
    [HttpGet("weekendsms/{merchantid}"), AllowAnonymous]
    public async Task<IActionResult> SendFridayMessages(long merchantid)
    {
      var response = await _notify.SendSmsNotificationAsync(merchantid);


      return Ok(new Responses()
      {
        ResponseCode = ResponseCode.SUCCESSFULL,
        Result = response,
      });
    }

    [HttpGet("send-single-sms/{customercode}"), AllowAnonymous]
    public async Task<IActionResult> SendFridayMessages(string  customercode)
    {

      var response = await _notify.SendSmsNotificationToCustomerCodeAsync(customercode);


      return Ok(new Responses()
      {
        ResponseCode = ResponseCode.SUCCESSFULL,
        Result = response,
      });
    }

    /// <summary>
    /// Send sms using customer code 
    /// </summary>
    /// <param name="customercode"></param>
    /// <returns></returns>
    [HttpGet("sms-customer/{customercode}"), AllowAnonymous]
    public IActionResult SendToSingleMasterCode(string customercode)
    {
     // var response = await _notify.SendSmsNotificationToCustomerCodeAsync(customercode);

      return Ok(new Responses()
      {
        ResponseCode = ResponseCode.SUCCESSFULL,
        Result = null,
      });
    }

   
  }
}
