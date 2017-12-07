using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Waterlevels
    {
        public long WaterLevelsId { get; set; }
        public string ColumnName { get; set; }
        public string ColumnDescription { get; set; }
        public string FarmSurveyAvg { get; set; }
        public string DrinkingWater { get; set; }
        public string CattleLevels { get; set; }
        public bool? IsNote { get; set; }
        public bool? IsActive { get; set; }
    }
}
