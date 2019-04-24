using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
  public abstract class Model : IValidatableObject
  {
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public long? CreatedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public long? ModifiedBy { get; set; }

    public bool IsCancelled { get; set; }
    public bool Status { get; set; }

    public void Assign(object source)
    {
      if (source != null)
      {
        var destProperties = GetType().GetProperties();
        foreach (var sourceProperty in source.GetType().GetProperties())
        {
          foreach (var desProperty in destProperties)
          {
            if (desProperty.Name == sourceProperty.Name && desProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
            {
              desProperty.SetValue(this, sourceProperty.GetValue(source, new object[] { }), new object[] { });
              break;
            }
          }
        }
      }
    }

    public Operation<ValidationResult[]> Validate()
    {
      var results = new List<ValidationResult>();
      Validator.TryValidateObject(this, new ValidationContext(this, serviceProvider: null, items: null), results, true);

      return new Operation<ValidationResult[]>
      {
        Result = results.ToArray(),
        Succeeded = results.Any() == false,
        Message = results.Any() ? results.Select(e => e.ErrorMessage).Aggregate((ag, e) => ag + ", " + e) : ""
      };
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();

    public Operation<string> GenerateUniqueNo() => Operation.Create(() =>
    {
      uint RandomInt(RandomNumberGenerator rng)
      {
        var intByte = new byte[4];
        rng.GetBytes(intByte);
        return BitConverter.ToUInt32(intByte, 0);
      }
      using (var rng = new RNGCryptoServiceProvider())
      {
        var i1 = Math.Abs(RandomInt(rng));
        var i2 = Math.Abs(RandomInt(rng));
        return $"PAJO-{DateTime.Now.ToString("yyddMM")}-{i1.ToString("X")}";
      }
    });
    /// <summary>
    /// Generate transaction no
    /// </summary>
    /// <returns></returns>
    public Operation<string> GenerateTransactionNo() => Operation.Create(() =>
    {
      return $"T{DateTime.Now.Ticks.ToString().Substring(11)}";
    });

    /// <summary>
    /// Generate collection code  ...
    /// </summary>
    /// <returns></returns>
    public Operation<string> GetCollectionCode()
        => Operation.Create(() =>
        {
          uint RandomInt(RandomNumberGenerator rng)
          {
            var intByte = new byte[4];
            rng.GetBytes(intByte);
            return BitConverter.ToUInt32(intByte, 0);
          }
          using (var rng = new RNGCryptoServiceProvider())
          {
            var i1 = Math.Abs(RandomInt(rng));
            var i2 = Math.Abs(RandomInt(rng));
            return $"Coll-{DateTime.Now.ToString("yyddMM")}-{i1.ToString("X")}";
          }
        });

    /// <summary>
    /// Get Customer code  ..
    /// </summary>
    /// <returns></returns>
    public Operation<string> GetCustomerCode()
            => Operation.Create(() =>
            {
              uint RandomInt(RandomNumberGenerator rng)
              {
                var intByte = new byte[4];
                rng.GetBytes(intByte);
                return BitConverter.ToUInt32(intByte, 0);
              }
              using (var rng = new RNGCryptoServiceProvider())
              {
                var i1 = Math.Abs(RandomInt(rng));
                var i2 = Math.Abs(RandomInt(rng));
                return $"C{DateTime.Now.ToString("yyddMM")}";
              }
            });

  }

  public class ValidateModel : IValidatableObject
  {

    public Operation<ValidationResult[]> Validate()
    {
      var results = new List<ValidationResult>();
      Validator.TryValidateObject(this, new ValidationContext(this, serviceProvider: null, items: null), results, true);

      return new Operation<ValidationResult[]>
      {
        Result = results.ToArray(),
        Succeeded = results.Any() == false,
        Message = results.Any() ? results.Select(e => e.ErrorMessage).Aggregate((ag, e) => ag + ", " + e) : ""
      };
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }

  public class SearchModel
  {
    public string Search { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int pageIndex { get; set; }
    public int pageSize { get; set; } = 100;

  }
  public enum SystemUserStatus
  {
    All,
    AdminOrAgent,
    Customer
  }
}
