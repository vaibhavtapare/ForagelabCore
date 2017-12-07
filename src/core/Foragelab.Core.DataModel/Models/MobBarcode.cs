using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobBarcode
    {
        public long BarCodeId { get; set; }
        public string Affiliate { get; set; }
        public int Year { get; set; }
        public string FarmerCity { get; set; }
        public string State { get; set; }
        public string Territory { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string BookName { get; set; }
        public int Entry { get; set; }
        public string PlantedBusinessEnterprise { get; set; }
        public string CommercialName { get; set; }
        public string RowId { get; set; }
        public string BarCodeNo { get; set; }
        public string BagId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
