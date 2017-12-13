using Foragelab.Core.DataModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Foragelab.Core.Entities
{
    public class UserModel
    {       
        public Guid UserId { get; set; }
        public string Password { get; set; }       
        public string Email { get; set; }        
        public bool IsApproved { get; set; }
        public bool IsLockedOut { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastLoginDate { get; set; }

        /// <summary>
        /// Converts the user to an array of security claims.
        /// </summary>
        /// <returns>An array of security claims.</returns>
        public Claim[] ToClaims()
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim("UserId", this.UserId.ToString(), ClaimValueTypes.Integer));
            //claims.Add(new Claim("refreshToken", string.IsNullOrEmpty(this.RefreshToken) ? "" : this.RefreshToken, ClaimValueTypes.String));
            //claims.Add(new Claim("userTypeId", this.ty.ToString(), ClaimValueTypes.Integer));
            //if (ClientId.HasValue)
            //{
            //    claims.Add(new Claim("clientId", this.ClientId.Value.ToString(), ClaimValueTypes.Integer));
            //}

            Claim[] results = new Claim[claims.Count];

            for (int i = 0; i < claims.Count; i++)
            {
                results[i] = claims[i];
            }

            return results;
        }
    }

    public static partial class Extensions
    {
       
        public static UserModel ToViewModel(this AspnetMembership user)
        {
            return new UserModel()
            {
                UserId = user.UserId,
                Password = user.Password,
                Email = user.Email,
                IsApproved = user.IsApproved,
                IsLockedOut = user.IsLockedOut,
                CreateDate = user.CreateDate,
                LastLoginDate = user.LastLoginDate
            };
        }
    }
}
