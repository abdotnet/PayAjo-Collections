using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Entities
{
  public class User : BaseEntity
  {
    public User()
    {
      UserRoles = new HashSet<UserRole>();
    }

    [Key]
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Mobile { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    [MaxLength(450)]
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public bool IsPhoneConfirmed { get; set; }
    public bool IsLocked { get; set; }
    public bool IsCancelled { get; set; }
    public string UserName { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public DateTime LastLoginDate { get; set; } = DateTime.Now;
    public RegistrationChannel Channel { get; set; }
    public long MerchantId { get; set; }
    [ForeignKey("MerchantId")]
    public Merchant Merchant { get; set; }
    //public long? CustomerId { get; set; }
    //[ForeignKey("CustomerId")]
    //public Customer Customer { get; set; }
    public UserStatus UserStatus { get; set; }
    public List<SocialLogin> SocialLogins { get; set; } = new List<SocialLogin>();
    public List<Claim> Claims { get; set; } = new List<Claim>();
    public string State { get; set; }
    public string City { get; set; }
    public string Country { get; set; } = "Nigeria";
    public UserType UserType { get; set; }
    public bool IsActive { get; set; }
    public string PasswordCode { get; set; }
    public DateTime ResetCodeMinute { get; set; } = DateTime.UtcNow;
  }

  public enum UserType
  {
    Customer = 0,
    Agent = 1,
    Both = 2
  }
  public enum RegistrationChannel
  {
    IsMobile = 1,
    IsWeb = 2
  }
  public enum UserStatus { Pending, Verified, Blocked }

  public class SocialLogin
  {
    [Key]
    public int SocialLoginId { get; set; }
    public string Provider { get; set; }
    public string Key { get; set; }
    public string Name { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
  }


  public class UserRole : BaseEntity
  {
    [Key]
    public long UserRoleId { get; set; }
    public long RoleId { get; set; }
    public long UserId { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }
    [ForeignKey("RoleId")]
    public virtual Role Role { get; set; }

  }

  public class Role : BaseEntity
  {
    [Key]
    public long RoleId { get; set; }
    public string Name { get; set; }
  }

  public class Permission : BaseEntity
  {
    public long Id { get; set; }
    public string Name { get; set; }
  }
  public class RolePermission : BaseEntity
  {
    public long Id { get; set; }
    public long PermissionId { get; set; }
    [ForeignKey("PermissionId")]
    public Permission Permission { get; set; }
    public long RoleId { get; set; }
    [ForeignKey("RoleId")]
    public Role Role { get; set; }
  }

  public class Claim
  {
    [Key]
    public int ClaimId { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
  }



  public class RefreshToken
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public DateTime IssuedUtc { get; set; }
    public DateTime ExpiresUtc { get; set; }
    public string Token { get; set; }

    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
  }
}
