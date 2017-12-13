using Foragelab.Core.DataModel;
using Foragelab.Core.DataModel.Repository;
using Foragelab.Core.Entities;
using Foragelab.Core.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Foragelab.Core.Services
{
  

    public class SecurityManager
    {
        private readonly IRepository<DataModel.AspnetMembership> _membershipRepository;
        private readonly CVASContext _dbContext;
        private readonly DbSet<AspnetMembership> _userDbSet;

        ///// <summary>
        ///// Base Constructor of the manager
        ///// </summary>
        ///// <param name="ppgContext">data context</param>
        //public SecurityManager(CVASContext dbContext)
        //{

        //}

        public SecurityManager()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CVASContext>();
            optionsBuilder.UseSqlServer("Server = PEEYUSH_AGRAWAL; UID = sa; password = clarion; Initial Catalog = CVASLive; MultipleActiveResultSets = true;");
            _dbContext = new CVASContext(optionsBuilder.Options);
            _userDbSet = _dbContext.Set<AspnetMembership>(); 


        }


        public virtual async Task<OpResult<AspnetMembership>> AuthenticateUserAsync(string userName, string password)
        {
            OpResult<AspnetMembership> result = new OpResult<AspnetMembership>() { Code = OperationResultCode.Error }; 

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
               AspnetMembership user = await _userDbSet.FirstOrDefaultAsync(x => x.Email == userName);

                if (user != null)
                {
                    result.Code = OperationResultCode.Success;
                    result.Result = user;

                    return result; 
                }

                result.Message = "Oops!  We were unable to find an active account with " +
                              "that email & password combination.";
            }
            return result; 
        }
    }
}
