using PayAjo.Data.Entities;
using PayAjo.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PayAjo.Data
{
  public class PayAjoSeeder
  {
    private static PayAjoContext _context;


    public static void Seed(PayAjoContext context)
    {
      _context = context;

   bool flag = _context.Database.EnsureCreated();

      // check flag to know if to continue or not  ..

      string password = "@Password1";

      string salt = Guid.NewGuid().ToString();

      var merchant1 = new Merchant()
      {
        Address = "Admin system merchant address",
        BusinessMobile = "08130230146",
        BVN = "36789057983",
        City = "Lagos",
        Country = "nigeria",
        GovtRegNo = "312345642",
        MerchantNo = "453678372",
        Name = "Admin System  Merchant",
        State = "Lagos state",
      };
      _context.Merchant.Add(merchant1);

      var merchant2 = new Merchant()
      {
        Address = "Demo merchant address",
        BusinessMobile = "01789685678",
        BVN = "8909803083",
        City = "demo lagos",
        Country = "Nigeria",
        GovtRegNo = "112322211",
        MerchantNo = "36378723222",
        Name = "Demo Merchant",
        State = "Lagos state",
      };
      _context.Merchant.Add(merchant2);



      var merchant3 = new Merchant()
      {
        Address = "alert merchant address",
        BusinessMobile = "0176387293678",
        BVN = "8378293083",
        City = "demo lagos",
        Country = "Nigeria",
        GovtRegNo = "11367290321",
        MerchantNo = "337820369222",
        Name = "DOOR  TO DOOR SAVING (WEMA AGENT BANKING)",
        State = "Lagos state",
      };
      _context.Merchant.Add(merchant3);

      _context.SaveChanges();

      var user = new User()
      {
        FirstName = "System",
        LastName = "Admin",
        EmailAddress = "system-account@gmail.com",
        Password = EncryptPassword(password, salt),
        Salt = salt,
        Address = "System 123",
        Channel = RegistrationChannel.IsWeb,
        CreatedBy = 1,
        Gender = "Male",
        CreatedDate = DateTime.Now,
        LastLoginDate = DateTime.Now,
        MiddleName = "G",
        Mobile = "081302301111",
        MerchantId = merchant1.MerchantId,
        IsActive = true
      };

      user.UserName = "system.admin123";
      _context.Users.Add(user);

      user = new User()
      {
        FirstName = "Omolaja",
        LastName = "Abubakar",
        EmailAddress = "abudotnet@gmail.com",
        Password = EncryptPassword(password, salt),
        Salt = salt,
        Address = "Demo 123",
        Channel = RegistrationChannel.IsWeb,
        CreatedBy = 1,
        Gender = "Male",
        CreatedDate = DateTime.Now,
        LastLoginDate = DateTime.Now,
        MiddleName = "G",
        Mobile = "08130230146",
        MerchantId = merchant1.MerchantId,
        IsActive = true
      };
      user.UserName = $"{user.FirstName}.{user.LastName}{GenerateUniqueName().Result}";
      _context.Users.Add(user);

      user = new User()
      {
        FirstName = "Mishael",
        LastName = "Harry",
        EmailAddress = "mishael.harry@gmail.com",
        Password = EncryptPassword(password, salt),
        Salt = salt,
        Address = "Surulere Lagos 123",
        Channel = RegistrationChannel.IsWeb,
        CreatedBy = 1,
        Gender = "Male",
        CreatedDate = DateTime.Now,
        LastLoginDate = DateTime.Now,
        MiddleName = "E",
        Mobile = "09039639237",
        MerchantId = merchant1.MerchantId,
        IsActive = true
      };
      user.UserName = $"{user.FirstName}.{user.LastName}{GenerateUniqueName().Result}";
      _context.Users.Add(user);

      password = $"password1";
      user = new User()
      {
        FirstName = "Demo",
        LastName = "App",
        EmailAddress = "demo@gmail.com",
        Password = EncryptPassword(password, salt),
        Salt = salt,
        Address = "Demo street 123",
        Channel = RegistrationChannel.IsWeb,
        CreatedBy = 1,
        Gender = "Male",
        CreatedDate = DateTime.Now,
        LastLoginDate = DateTime.Now,
        MiddleName = "E",
        Mobile = "080863378292",
        MerchantId = merchant2.MerchantId,
        IsActive = true
      };
      user.UserName = $"{user.FirstName}.{user.LastName}{GenerateUniqueName().Result}";
      _context.Users.Add(user);

      user = new User()
      {
        FirstName = "MARYJANE",
        LastName = "NDUKWE",
        EmailAddress = "alert@gmail.com",
        Password = EncryptPassword(password, salt),
        Salt = salt,
        Address = "87 Market  Road by Kent",
        Channel = RegistrationChannel.IsWeb,
        CreatedBy = 1,
        Gender = "Male",
        CreatedDate = DateTime.Now,
        LastLoginDate = DateTime.Now,
        MiddleName = "R",
        Mobile = "070988273232",
        MerchantId = merchant3.MerchantId,
        IsActive = true,
        UserName = "doortodoor2018",
        City = "Aba",
        State = "Abia"
      };
      // user.UserName = $"{user.FirstName}.{user.LastName}{GenerateUniqueName().Result}";
      _context.Users.Add(user);

      _context.SaveChanges();

      // Create Role

      _context.Role.Add(new Role()
      {
        Name = "Central Administrator",
        CreatedDate = DateTime.Now,
        CreatedBy = 1
      });
      _context.Role.Add(new Role()
      {
        Name = "Merchant Admin",
        CreatedDate = DateTime.Now,
        CreatedBy = 1
      });
      _context.Role.Add(new Role()
      {
        Name = "Merchant Agent",
        CreatedDate = DateTime.Now,
        CreatedBy = 1
      });
      _context.Role.Add(new Role()
      {
        Name = "Customers",
        CreatedDate = DateTime.Now,
        CreatedBy = 1
      });
      _context.SaveChanges();

      // Systems and admin user user role setup ..
      _context.UserRole.Add(new UserRole()
      {
        RoleId = 1,
        UserId = 1,
        CreatedDate = DateTime.Now,
        CreatedBy = 1
      });
      _context.UserRole.Add(new UserRole()
      {
        RoleId = 1,
        UserId = 2,
        CreatedDate = DateTime.Now,
        CreatedBy = 1
      });
      _context.UserRole.Add(new UserRole()
      {
        RoleId = 1,
        UserId = 3,
        CreatedDate = DateTime.Now,
        CreatedBy = 1
      });
      _context.UserRole.Add(new UserRole()
      {
        RoleId = 2,
        UserId = 4,
        CreatedDate = DateTime.Now,
        CreatedBy = 1
      });
      _context.UserRole.Add(new UserRole()
      {
        RoleId = 2,
        UserId = 5,
        CreatedDate = DateTime.Now,
        CreatedBy = 1
      });

      _context.SaveChanges();

    }

    public static string EncryptPassword(string password, string salt = "")
    {
      string text = salt + password;
      var UE = new UTF8Encoding();
      byte[] hashValue;
      byte[] message = UE.GetBytes(text);

      SHA512Managed hashString = new SHA512Managed();
      string hex = "";

      hashValue = hashString.ComputeHash(message);
      foreach (byte x in hashValue)
      {
        hex += String.Format("{0:x2}", x);
      }
      return hex;
    }
    private static Operation<string> GenerateUniqueCode() => Operation.Create(() =>
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
        return $"pass-{DateTime.Now.ToString("yyddMM")}-{i1.ToString("X")}";
      }
    });

    private static Operation<string> GenerateUniqueName() => Operation.Create(() =>
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
        return $"{DateTime.Now.ToString("yyddMM")}";
      }
    });
  }
}
