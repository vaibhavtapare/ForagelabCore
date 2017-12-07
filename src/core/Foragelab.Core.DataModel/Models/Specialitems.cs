using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Specialitems
    {
        public Specialitems()
        {
            AminoacidanalysisDomesticSpecialItem = new HashSet<Aminoacidanalysis>();
            AminoacidanalysisIntSpecialItem = new HashSet<Aminoacidanalysis>();
            AnalysisoptionsDomesticSpecialItem = new HashSet<Analysisoptions>();
            AnalysisoptionsIntSpecialItem = new HashSet<Analysisoptions>();
            Billitems = new HashSet<Billitems>();
            ComponentsDomesticSpecialItem = new HashSet<Components>();
            ComponentsIntSpecialItem = new HashSet<Components>();
            InsituDomesticSpecialItem = new HashSet<Insitu>();
            InsituIntSpecialItem = new HashSet<Insitu>();
            InvitrodigestibilityDomesticSpecialItem = new HashSet<Invitrodigestibility>();
            InvitrodigestibilityIntSpecialItem = new HashSet<Invitrodigestibility>();
            ManureanalysisDomesticSpecialItem = new HashSet<Manureanalysis>();
            ManureanalysisIntSpecialItem = new HashSet<Manureanalysis>();
            MycotoxinsDomesticSpecialItem = new HashSet<Mycotoxins>();
            MycotoxinsIntSpecialItem = new HashSet<Mycotoxins>();
            PlanttissueanalysisDomesticSpecialItem = new HashSet<Planttissueanalysis>();
            PlanttissueanalysisIntSpecialItem = new HashSet<Planttissueanalysis>();
            ProximateDomesticSpecialItem = new HashSet<Proximate>();
            ProximateIntSpecialItem = new HashSet<Proximate>();
            StarchdigestibilityDomesticSpecialItem = new HashSet<Starchdigestibility>();
            StarchdigestibilityIntSpecialItem = new HashSet<Starchdigestibility>();
            WateranalysisDomesticSpecialItem = new HashSet<Wateranalysis>();
            WateranalysisIntSpecialItem = new HashSet<Wateranalysis>();
        }

        public int SpecialItemId { get; set; }
        public string SpecialItem { get; set; }
        public decimal? Amount { get; set; }

        public ICollection<Aminoacidanalysis> AminoacidanalysisDomesticSpecialItem { get; set; }
        public ICollection<Aminoacidanalysis> AminoacidanalysisIntSpecialItem { get; set; }
        public ICollection<Analysisoptions> AnalysisoptionsDomesticSpecialItem { get; set; }
        public ICollection<Analysisoptions> AnalysisoptionsIntSpecialItem { get; set; }
        public ICollection<Billitems> Billitems { get; set; }
        public ICollection<Components> ComponentsDomesticSpecialItem { get; set; }
        public ICollection<Components> ComponentsIntSpecialItem { get; set; }
        public ICollection<Insitu> InsituDomesticSpecialItem { get; set; }
        public ICollection<Insitu> InsituIntSpecialItem { get; set; }
        public ICollection<Invitrodigestibility> InvitrodigestibilityDomesticSpecialItem { get; set; }
        public ICollection<Invitrodigestibility> InvitrodigestibilityIntSpecialItem { get; set; }
        public ICollection<Manureanalysis> ManureanalysisDomesticSpecialItem { get; set; }
        public ICollection<Manureanalysis> ManureanalysisIntSpecialItem { get; set; }
        public ICollection<Mycotoxins> MycotoxinsDomesticSpecialItem { get; set; }
        public ICollection<Mycotoxins> MycotoxinsIntSpecialItem { get; set; }
        public ICollection<Planttissueanalysis> PlanttissueanalysisDomesticSpecialItem { get; set; }
        public ICollection<Planttissueanalysis> PlanttissueanalysisIntSpecialItem { get; set; }
        public ICollection<Proximate> ProximateDomesticSpecialItem { get; set; }
        public ICollection<Proximate> ProximateIntSpecialItem { get; set; }
        public ICollection<Starchdigestibility> StarchdigestibilityDomesticSpecialItem { get; set; }
        public ICollection<Starchdigestibility> StarchdigestibilityIntSpecialItem { get; set; }
        public ICollection<Wateranalysis> WateranalysisDomesticSpecialItem { get; set; }
        public ICollection<Wateranalysis> WateranalysisIntSpecialItem { get; set; }
    }
}
