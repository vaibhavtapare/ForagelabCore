using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class AspnetUsers
    {
        public AspnetUsers()
        {
            AspnetPersonalizationPerUser = new HashSet<AspnetPersonalizationPerUser>();
            AspnetUsersInRoles = new HashSet<AspnetUsersInRoles>();
            Linkedaccounts = new HashSet<Linkedaccounts>();
            MobSamplebags = new HashSet<MobSamplebags>();
            MobSamplenotifications = new HashSet<MobSamplenotifications>();
            NewsCreatedByNavigation = new HashSet<News>();
            NewsModifedByNavigation = new HashSet<News>();
            RationUseraccess = new HashSet<RationUseraccess>();
            Useraccountpref = new HashSet<Useraccountpref>();
            Userdetails = new HashSet<Userdetails>();
        }

        public Guid ApplicationId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string LoweredUserName { get; set; }
        public string MobileAlias { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime LastActivityDate { get; set; }

        public AspnetApplications Application { get; set; }
        public AspnetMembership AspnetMembership { get; set; }
        public AspnetProfile AspnetProfile { get; set; }
        public ICollection<AspnetPersonalizationPerUser> AspnetPersonalizationPerUser { get; set; }
        public ICollection<AspnetUsersInRoles> AspnetUsersInRoles { get; set; }
        public ICollection<Linkedaccounts> Linkedaccounts { get; set; }
        public ICollection<MobSamplebags> MobSamplebags { get; set; }
        public ICollection<MobSamplenotifications> MobSamplenotifications { get; set; }
        public ICollection<News> NewsCreatedByNavigation { get; set; }
        public ICollection<News> NewsModifedByNavigation { get; set; }
        public ICollection<RationUseraccess> RationUseraccess { get; set; }
        public ICollection<Useraccountpref> Useraccountpref { get; set; }
        public ICollection<Userdetails> Userdetails { get; set; }
    }
}
