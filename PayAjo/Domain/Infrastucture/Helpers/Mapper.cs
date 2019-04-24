using PayAjo.Data.Entities;
using PayAjo.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayAjo.Domain.Infrastucture.Extension;

namespace PayAjo.Domain.Infrastucture.Helpers
{
  public static class Mappers
  {
    public static UserModel MapUser(User user)
    {
      var model = new UserModel();
      model.Assign(user);
      model.IsCancelled = user.IsCancelled;
      model.MiddleName = user.MiddleName;

      model.Password = string.Empty;
      return model;
    }
    public static UserModel MapUser(User user, Role role, Customer customer)
    {
      var model = new UserModel();

      model.Assign(user);

      model.FirstName = user.FirstName.ToUpper();
      model.LastName = user.LastName.ToUpper();
      model.MiddleName = user.MiddleName;

      model.IsCancelled = user.IsCancelled;
      model.Role = role.Name;
      model.Password = string.Empty;
      model.RoleId = role.RoleId;
      model.CustomerId = (customer != null) ? customer.CustomerId : 0;
      model.IsActive = user.IsActive;
      return model;
    }
    public static UserModel MapUser(User user, Role role, Merchant merch, Customer customer)
    {
      var model = new UserModel();

      model.Assign(user);

      model.FirstName = user.FirstName.ToUpper();
      model.LastName = user.LastName.ToUpper();
      model.MiddleName = user.MiddleName;

      model.IsCancelled = user.IsCancelled;
      model.Role = role.Name;
      model.Password = string.Empty;
      model.RoleId = role.RoleId;
      model.CustomerId = (customer != null) ? customer.CustomerId : 0;
      model.IsActive = user.IsActive;
      model.MerchantName = merch.Name;

      return model;
    }

    public static User MapUser(UserModel model)
    {
      var user = new User();
      user.Assign(model);
      user.IsCancelled = model.IsCancelled;
      model.Password = string.Empty;
      return user;
    }

    public static SocialLogin MapSocialLogin(SocialLoginModel model)
    {
      var socialLogin = new SocialLogin();
      socialLogin.Assign(model);
      return socialLogin;
    }

    public static SocialLoginModel MapSocialLogin(SocialLogin socialLogin)
    {
      var model = new SocialLoginModel();
      model.Assign(socialLogin);
      return model;
    }
  }
}
