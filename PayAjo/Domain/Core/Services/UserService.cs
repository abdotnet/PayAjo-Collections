using Microsoft.AspNetCore.Identity;
using PayAjo.Data.Entities;
using PayAjo.Data.Repository;
using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Services
{
    public class UserStore : IUserStore<UserModel>, IUserPasswordStore<UserModel>, IUserLoginStore<UserModel>, IUserClaimStore<UserModel>, IUserEmailStore<UserModel>
    {
        #region IUserStore
        private IUserRepository _repo;

        public UserStore(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task AddLoginAsync(UserModel user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            var sociallogin = await _repo.GetSocialLogin(user.UserId.ToString(), login.LoginProvider);
            if (sociallogin == null)
            {
                sociallogin = ToSocialLogin(login);
                await _repo.AddSocialLogin(user.UserId.ToString(), sociallogin);
            }
        }

        public Task<IdentityResult> CreateAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Operation.Run(async () => await _repo.CreateUser(user)).ToIdentityResult();
        }

        public Task<IdentityResult> DeleteAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Operation.Run(async () => await _repo.CreateUser(user)).ToIdentityResult();
        }

        public void Dispose()
        {

        }

        public Task<UserModel> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return _repo.GetUserById(userId);
        }

        public async Task<UserModel> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            return await _repo.FindUserBySocialLogin(loginProvider, providerKey);
        }

        public Task<UserModel> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var op = _repo.GetUserByEmail(normalizedUserName);
            return op;
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(UserModel user, CancellationToken cancellationToken)
        {
            var socialLogins = await _repo.GetSocialLogins(user.UserId.ToString());
            return socialLogins.Select(ToLoginInfo).ToList();
        }

        public Task<string> GetNormalizedUserNameAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(string.Format("{0}{1}",user.LastName,user.FirstName));
        }

        public async Task<string> GetPasswordHashAsync(UserModel user, CancellationToken cancellationToken)
        {
            return await _repo.GetPasswordHash(user.UserId.ToString());
        }

        public Task<string> GetUserIdAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserId.ToString());
        }

        public Task<string> GetUserNameAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.EmailAddress);
        }

        public Task<bool> HasPasswordAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public async Task RemoveLoginAsync(UserModel user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            await _repo.RemoveSocialLogin(user.UserId.ToString(), loginProvider, providerKey);
        }

        public Task SetNormalizedUserNameAsync(UserModel user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public async Task SetPasswordHashAsync(UserModel user, string passwordHash, CancellationToken cancellationToken)
        {
            await _repo.SetPasswordHash(user.UserId.ToString(), passwordHash);
        }

        public Task SetUserNameAsync(UserModel user, string userName, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.EmailAddress);
        }

        public Task<IdentityResult> UpdateAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Operation.Run(async () => await _repo.UpdateUser(user)).ToIdentityResult();
        }

        //
        // Summary:
        //     Returns the User ID claim value if present otherwise returns null.
        //
        // Parameters:
        //   principal:
        //     The System.Security.Claims.ClaimsPrincipal instance.
        //
        // Returns:
        //     The User ID claim value, or null if the claim is not present.
        //
        // Remarks:
        //     The User ID claim is identified by System.Security.Claims.ClaimTypes.NameIdentifier.
        public string GetUserId(ClaimsPrincipal principal)
        {

            string userName = principal.Identity.Name;

            return _repo.GetUserId(userName).ToString();
        }
        #endregion

        public SocialLoginModel ToSocialLogin(UserLoginInfo loginInfo)
        {
            if (loginInfo == null) return null;
            return new SocialLoginModel
            {
                Name = loginInfo.ProviderDisplayName,
                Key = loginInfo.ProviderKey,
                Provider = loginInfo.LoginProvider,
            };
        }

        public UserLoginInfo ToLoginInfo(SocialLoginModel socialLogin)
        {
            if (socialLogin == null) return null;
            return new UserLoginInfo(socialLogin.Provider, socialLogin.Key, socialLogin.Name);
        }

        #region IUserClaimStore
        public async Task<IList<System.Security.Claims.Claim>> GetClaimsAsync(UserModel model, CancellationToken cancellationToken)
        {
            var user = await _repo.GetUserByEmail(model.EmailAddress);
            return user.GetClaims();
        }

        public async Task AddClaimsAsync(UserModel user, IEnumerable<System.Security.Claims.Claim> claims, CancellationToken cancellationToken)
        {
            ClaimModel toModel(System.Security.Claims.Claim c) => new ClaimModel { UserId = long.Parse(user.UserId.ToString()), Type = c.Type, Value = c.Value };
            await _repo.AddClaims(user.UserId.ToString(), claims.Select(c => toModel(c)).ToArray());
        }

        public async Task ReplaceClaimAsync(UserModel user, System.Security.Claims.Claim claim, System.Security.Claims.Claim newClaim, CancellationToken cancellationToken)
        {
            if (claim.Type != newClaim.Type) throw new Exception("Claim and New Claim don't match");
            await _repo.SetClaimValue(user.UserId.ToString(), claim.Type, newClaim.Value);
        }

        public async Task RemoveClaimsAsync(UserModel user, IEnumerable<System.Security.Claims.Claim> claims, CancellationToken cancellationToken)
        {
            await _repo.RemoveClaims(user.UserId.ToString(), claims.Select(c => c.Type).ToArray());
        }

        public async Task<IList<UserModel>> GetUsersForClaimAsync(System.Security.Claims.Claim claim, CancellationToken cancellationToken)
        {
            var users = await _repo.FindUsersFromClaim(claim.Type, claim.Value);
            return users.ToList();
        }
        #endregion

        #region IUserEmailStore
        public Task SetEmailAsync(UserModel user, string email, CancellationToken cancellationToken)
        {
            user.EmailAddress = email;
            return Task.FromResult(email);
        }

        public Task<string> GetEmailAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.EmailAddress);
        }

        public Task<bool> GetEmailConfirmedAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserStatus == UserStatus.Verified);
        }

        public async Task SetEmailConfirmedAsync(UserModel user, bool confirmed, CancellationToken cancellationToken)
        {
            if (user.UserStatus == UserStatus.Blocked) throw new Exception("Account has been Blocked");
            await _repo.ChangeStatus(user.UserId.ToString(), UserStatus.Verified);
            user.UserStatus = UserStatus.Verified;
        }

        public Task<UserModel> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return _repo.GetUserByEmail(normalizedEmail);
        }

        public Task<string> GetNormalizedEmailAsync(UserModel user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.EmailAddress?.ToLower());
        }

        public Task SetNormalizedEmailAsync(UserModel user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.EmailAddress = user.EmailAddress?.ToLower();
            return Task.FromResult(user.EmailAddress);
        }
        #endregion
    }

    public class RoleStore : IRoleStore<string>
    {
        public Task<IdentityResult> CreateAsync(string role, CancellationToken cancellationToken)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(string role, CancellationToken cancellationToken)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public void Dispose()
        {
            //Do Nothing
        }

        public Task<string> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            return Task.FromResult(roleId);
        }

        public Task<string> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return Task.FromResult(normalizedRoleName);
        }

        public Task<string> GetNormalizedRoleNameAsync(string role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role);
        }

        public Task<string> GetRoleIdAsync(string role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role);
        }

        public Task<string> GetRoleNameAsync(string role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role);
        }

        public Task SetNormalizedRoleNameAsync(string role, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task SetRoleNameAsync(string role, string roleName, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task<IdentityResult> UpdateAsync(string role, CancellationToken cancellationToken)
        {
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
