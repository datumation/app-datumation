using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Datumation.Extensions
{
    //     public interface IJwtFactory
    //     {

    //     }
    //     public class JwtFactory : IJwtFactory
    //     {
    //         public async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
    //         {
    //             if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
    //                 return await Task.FromResult<ClaimsIdentity>(null);

    //             var userToVerify = await _userManager.FindByNameAsync(userName);

    //             if (userToVerify == null)
    //             {
    //                 userToVerify = await _userManager.FindByEmailAsync(userName);
    //                 if (userToVerify == null)
    //                 {
    //                     return await Task.FromResult<ClaimsIdentity>(null);
    //                 }
    //             }
    //             // check the credentials
    //             if (await _userManager.CheckPasswordAsync(userToVerify, password))
    //             {
    //                 _claims = await _userManager.GetClaimsAsync(userToVerify);

    //                 return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userToVerify.UserName, userToVerify.Id, _claims));
    //             }
    //             // Credentials are invalid, or account doesn't exist
    //             return await Task.FromResult<ClaimsIdentity>(null);
    //         }
    //     }

    //     public ClaimsIdentity GenerateClaimsIdentity(string id, IList<Claim> claims)
    //     {
    //         claims.Add(new Claim(Helpers.Constants.Strings.JwtClaimIdentifiers.Id, id));

    //         // If your security is role based you can get then with the RoleManager and add then here as claims

    //         // Ask here for all claims your app need to validate later 

    //         return new ClaimsIdentity(new GenericIdentity(userName, "Token"), claims);
    //     }
    // public async Task<AccessToken>GenerateEncodedToken(string id, string userName)
    // {
    //   var identity = GenerateClaimsIdentity(id, userName);

    //   var claims = new[]
    //   {
    //     new Claim(JwtRegisteredClaimNames.Sub, userName),
    //     new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
    //     new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
    //     identity.FindFirst(Helpers.Constants.Strings.JwtClaimIdentifiers.Rol),
    //     identity.FindFirst(Helpers.Constants.Strings.JwtClaimIdentifiers.Id)
    //   };

    //   // Create the JWT security token and encode it.
    //   var jwt = new JwtSecurityToken(
    //   _jwtOptions.Issuer,
    //   _jwtOptions.Audience,
    //   claims,
    //   _jwtOptions.NotBefore,
    //   _jwtOptions.Expiration,
    //   _jwtOptions.SigningCredentials);
    //   return new AccessToken(_jwtTokenHandler.WriteToken(jwt), (int)_jwtOptions.ValidFor.TotalSeconds);
    // }
}