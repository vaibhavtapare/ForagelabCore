using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Invitrodigestibility
    {
        public int InvitroId { get; set; }
        public string InvitroCode { get; set; }
        public string InvitroValue { get; set; }
        public string InvitroDescription { get; set; }
        public decimal? DomesticPrice { get; set; }
        public decimal? InternationalPrice { get; set; }
        public int? OrderValue { get; set; }
        public bool? IsOption { get; set; }
        public bool? IsComponent { get; set; }
        public int? DomesticSpecialItemId { get; set; }
        public int? IntSpecialItemId { get; set; }

        public Specialitems DomesticSpecialItem { get; set; }
        public Specialitems IntSpecialItem { get; set; }
    }
}
