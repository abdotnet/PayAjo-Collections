using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Interfaces
{
  public interface ICustomerService
  {
    Operation<Pagination<CustomerModel>> GetCustomers(string search, long userId, StatusCode status, int pageIndex, int pageSize = 100);
    Operation<CustomerModel[]> GetCustomers();
    Operation<CustomerModel> GetCustomer(long id);
    Operation<CustomerModel> AddOrUpdateCustomer(CustomerModel model);
    Operation<CustomerModel> DeleteCustomer(long id);
    Operation UpdateImages(string fileName, int id);
    Operation<CustomerLoginModel> AddMobileCustomer(CustomerLoginModel model);
    Operation<int> SaveUploadCustomer(CustomerInfo[] models);
    Operation<CustomerModel[]> GetCustomerForMerchant([Required]long merchantId);

    Operation ActivateCustomer(CustomerUpdateModel model);
    Operation DeActivateCustomer(long merchantId, long customerId);
    Operation GetInActiveCustomers([Required]long merchantId);

    Operation<string> GetCustomerName([Required]string customerCode, long userId);
    Operation ResetCustomerBalance([Required]long customerId, long userId);
    Operation<CustomerModel> UpdateCustomer(CustomerModel model);
    Operation<Pagination<CustomerModel>> GetCustomers(SearchModel model, StatusCode status, long userId);
    Operation UploadPixOrSignature(UploadType type, ImageUpload model);

    //Operation SendFridaySms(long merchantId);
  }
}
