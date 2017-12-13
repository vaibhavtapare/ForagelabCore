using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Foragelab.Core.Results;
using Foragelab.Core.Services;
using Foragelab.Core.Entities;
using System.Security.Claims;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;
using Foragelab.Core.DataModel;

namespace Foragelab.API.Controllers
{
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly SecurityManager securityManager;
        private SymmetricSecurityKey JWTSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWTSecretKey")));
        
        /// <summary>
        /// Base constructor for the authController
        /// </summary>
        public AuthController(IHttpContextAccessor context, IMemoryCache memoryCache)
        {
            CVASContext _contex; ; 
             securityManager = new SecurityManager();
        }

        [HttpPost("token")]
        public async Task<IActionResult> Token(string username, string password)
        {
            // Obviously the username and password parameters have to be provided or 
            // there is nothing to validate.
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {               

                OpResult<AspnetMembership> authenticatedUserResult = await securityManager.AuthenticateUserAsync(username, password);
                if (authenticatedUserResult.Code == OperationResultCode.Success)
                {
                    AspnetMembership authenticatedUser = authenticatedUserResult.Result; 

                    ClaimsIdentity userClaimsIdentity = new ClaimsIdentity(new GenericIdentity(authenticatedUser.UserId.ToString(), "Token"));
                    UserModel userModel = authenticatedUser.ToViewModel();
                    userClaimsIdentity.AddClaims(userModel.ToClaims());
                    //LoadClientIdForClients(userModel, authenticatedUser);
                    return GenerateToken(userClaimsIdentity);
                }
            }

            // Credentials are invalid, or account doesn't exist
            return BadRequest("Refresh token must be provided & valid.");
        }


        private IActionResult GenerateToken(ClaimsIdentity identity, bool isRefresh = false)
        {
            string newRefreshToken = "";

            var now = DateTime.UtcNow;

            // Create claims array that will hold all the identity claims plus these 3 standard claims
            var claims = new Claim[identity.Claims.Count() + 3];

            // Add these standard claims
            claims[0] = new Claim(JwtRegisteredClaimNames.Sub, identity.Name);
            claims[1] = new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());
            claims[2] = new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(now).ToString(), ClaimValueTypes.Integer64);

            if (identity.Claims.FirstOrDefault(f => f.Type.Equals("refreshToken")) != null)
            {
                newRefreshToken = identity.Claims.FirstOrDefault(f => f.Type.Equals("refreshToken")).Value;
            }

            // Add the identity claims
            identity.Claims.Where(f => !f.Type.Equals("refreshToken")).ToArray<Claim>().CopyTo(claims, 3);

            var token = new JwtSecurityToken(
                                        "PPG",
                                        "PPGAud",
                                        claims,
                                        expires: now.AddHours(1),
                                        signingCredentials: new SigningCredentials(JWTSigningKey, SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

            if (!isRefresh)
            {
                var response = new
                {
                    access_token = encodedJwt,
                    expires_in = 3600,
                    refresh_token = newRefreshToken
                };

                // Serialize and return the response
                return Json(response);
            }
            else
            {
                var response = new
                {
                    access_token = encodedJwt,
                    expires_in = 3600
                };

                // Serialize and return the response
                return Json(response);
            }
        }


        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

    }
}