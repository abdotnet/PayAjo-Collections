using PayAjo.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Models
{
  public class UserModel : Model
  {

    public long UserId { get; set; }
    public string Title { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    [Required]
    public string Mobile { get; set; }
    public string Gender { get; set; }
    //[Required]
    public string Address { get; set; }
    [MaxLength(450)]
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public bool IsPhoneConfirmed { get; set; }
    public bool IsLocked { get; set; }
    [Required]
    public string UserName { get; set; }
    // public virtual ICollection<UserRoleModel> UserRoles { get; set; }
    public DateTime LastLoginDate { get; set; } = DateTime.Now;
    public RegistrationChannel Channel { get; set; }
    [Required]
    public long MerchantId { get; set; }
    public string ApplicationCode { get; set; }
    public DateTime DateOfBirth { get; internal set; } = DateTime.Now;
    public UserStatus UserStatus { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Country { get; set; } = "Nigeria";
    public long RoleId { get; set; }
    public string Role { get; set; }
    public long CustomerId { get; set; }
    public bool IsActive { get; set; }
    // public string CustomerCode { get; set; }
    public string MerchantName { get; set; }
  }

  public class AgentUserModel
  {
    public string  Name { get; set; }
    public long AgentUserId { get; set; }
  }

  public class UserWebModel : Model
  {

    public long UserId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    [Required]
    public string Mobile { get; set; }
    [Required]
    public string Address { get; set; }
    [MaxLength(450)]
    public string EmailAddress { get; set; }
    public string Role { get; set; }

    public string UserName { get; set; }

    public string  Gender { get; set; }
    public bool IsActive { get; set; }

  }

  public class UserResponseModel : Model
  {
    public UserResponseModel()
    {
      UserRoles = new HashSet<UserRoleModel>();
    }

    public long UserId { get; set; }
    public string Title { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    [Required]
    public string Mobile { get; set; }
    public string Gender { get; set; }
    //[Required]
    public string Address { get; set; }
    [MaxLength(450)]
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public bool IsPhoneConfirmed { get; set; }
    public bool IsLocked { get; set; }
    public string UserName { get; set; }
    public virtual ICollection<UserRoleModel> UserRoles { get; set; }
    public DateTime LastLoginDate { get; set; } = DateTime.Now;
    public RegistrationChannel Channel { get; set; }
    [Required]
    public long MerchantId { get; set; }
    public string ApplicationCode { get; set; }
    public DateTime DateOfBirth { get; internal set; } = DateTime.Now;
    public UserStatus UserStatus { get; set; }
    public List<SocialLogin> SocialLogins { get; set; } = new List<SocialLogin>();
    public List<Claim> Claims { get; set; } = new List<Claim>();
    //public string NokName { get; set; }
    //public string NokEmail { get; set; }
    //public string NokMobile { get; set; }
    //public string NokRelationship { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Country { get; set; } = "Nigeria";
    public long RoleId { get; set; }
    public string Role { get; set; }
    public long CustomerId { get; set; }
    public bool IsActive { get; set; }
    public string CustomerCode { get; set; }

  }

  public class SocialLoginModel : Model
  {
    public int SocialLoginId { get; set; }
    public string Provider { get; set; }
    public string Key { get; set; }
    public string Name { get; set; }
    public string UserId { get; set; }
    public UserModel User { get; set; }
  }


  public class UserRoleModel : Model
  {
    public long UserRoleId { get; set; }
    public long RoleId { get; set; }
    public long UserId { get; set; }

    public virtual UserModel User { get; set; }
    public virtual RoleModel Role { get; set; }

  }

  public class RoleModel : Model
  {
    public long RoleId { get; set; }
    public string Name { get; set; }
  }

  public class PermissionModel : Model
  {
    public long Id { get; set; }
    public string Name { get; set; }
  }
  public class RolePermissionModel : Model
  {
    public long Id { get; set; }
    public long PermissionId { get; set; }
    public PermissionModel Permission { get; set; }
    public long RoleId { get; set; }
    public RoleModel Role { get; set; }
  }

  public class ClaimModel
  {
    public int ClaimId { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
    public long UserId { get; set; }
    public UserModel User { get; set; }
  }

  public class PasswordChangeModel : Model
  {
    [Required]
    public long UserId { get; set; }

    [Required]
    public string Password { get; set; }
    [Required]
    public string NewPassword { get; set; }

    [Required]
    public string ConfirmPassword { get; set; }
  }
  public class AuditTrailModel : Model
  {
    public long Id { get; set; }
    public string IPAddress { get; set; }
    public string Action { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
  }

  public class LoginModel
  {
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
  }

  public class AgenUserUserModel
  {
    public long AgentUserId { get; set; }
    public string AgentName { get; set; }
    public string EmailAddress { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
    public string Gender { get; internal set; }
    public string CreatedDate { get; internal set; }
    public string UserName { get; set; }
  }

  public class NokUpdateModel
  {

    [Required]
    public long UserId { get; set; }
    public string NokName { get; set; }
    public string NokPhone { get; set; }
    public string NoKEmail { get; set; }
    public string NokAddress { get; set; }

    public string NokRelationship { get; set; }

    public long CreatedBy { get; set; }
  }
  public class DeAcivateUserModel
  {
    [Required]
    public long UserId { get; set; }
    public long CreatedBy { get; set; }
  }
  public class RecoverPassword : ValidateModel
  {
    [Required]
    public string Code { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string ConfirmPassword { get; set; }
  }
}
