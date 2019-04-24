using PayAjo.Data.Entities;
using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Data.Repository
{
  public interface IUserRepository
  {
    Operation<UserModel[]> GetUserDataDetails(long userId);
    Task<UserModel> GetUserById(string userId);
    Task<UserModel> GetUserByEmail(string email);
    Task<UserModel> UpdateUser(UserModel user);
 
    Task<string> GetPasswordHash(string userId);
    Task<string> SetPasswordHash(string userId, string passwordHash);
    Task DeleteUser(UserModel user);
    Task<UserModel> CreateUser(UserModel model);
    Task AddSocialLogin(string userId, SocialLoginModel socialLogin);
    Task<UserModel> FindUserBySocialLogin(string loginProvider, string providerKey);
    Task<SocialLoginModel> GetSocialLogin(string userId, string loginProvider);
    Task<SocialLoginModel[]> GetSocialLogins(string userId);
    Task RemoveSocialLogin(string userId, string loginProvider, string providerKey);
    Task AddClaims(string userId, ClaimModel[] claims);
    Task SetClaimValue(string userId, string claimType, string claimValue);
    Task RemoveClaims(string userId, string[] claimTypes);
    Task<UserModel[]> FindUsersFromClaim(string type, string value);
    Task ChangeStatus(string userId, UserStatus status);
    Operation<UserModel> ValidateUser(string username, string password);
    Task<long> GetUserId(string userName);

    Operation<long> AddOrUpdateUserAccount(UserModel model);
    Task<Operation> ChangePassword(PasswordChangeModel model);
    Task<Operation> UpdateProfile(UserModel model);
    Operation<UserModel[]> GetUsers();
    Operation<Pagination<UserModel>> GetUsers(string search, int pageIndex, int pageSize = 100);
    Operation<UserModel> GetUserByUserId(long userId);
    Operation CreateAgent(AgentModel model);
    Operation<string> ValidatePhone(string phoneNo);
    Operation<AgenUserUserModel[]> GetMerchantAgentUsers([Required]long merchantId);

    Operation<List<UserModel>> GetListOfInActiveCustomers([Required]long merchantId);
    Operation ActivateUserAccount(NokUpdateModel model);

    Operation DeActivateUserAccount(DeAcivateUserModel model);
    Operation GetPassordCode(string identity);
    Operation PasswordResetUpdate(RecoverPassword model);
    Operation<Pagination<UserModel>> GetUserDatas(string search, long userId, UserType type, int pageIndex, int pageSize = 100);
    Task<Operation> UpdateUserWebProfile(UserWebModel model);

    Operation AddOrUpdateRegister(UserWebModel model);
    Operation<AgentUserModel[]> GetAllAdminAgents(long userId);
    Operation<Pagination<UserModel>> GetUserDataDetails(string search, long userId, int pageIndex, int pageSize);

    Operation<Pagination<UserModel>> GetUserDataDetails(SearchModel model, long userId, SystemUserStatus  status);

  }
}
