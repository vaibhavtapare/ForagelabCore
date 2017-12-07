using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ReportingLingualFields
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public int? FieldId { get; set; }
        public int? LanguageId { get; set; }

        public ReportingFields Field { get; set; }
    }
}
