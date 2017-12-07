using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Samples
    {
        public Samples()
        {
            Billitems = new HashSet<Billitems>();
            INdfdinvitro = new HashSet<INdfdinvitro>();
            ITmrfecalFecalSamples = new HashSet<ITmrfecal>();
            ITmrfecalTmrSamples = new HashSet<ITmrfecal>();
            Invitro = new HashSet<Invitro>();
            SampleUserNotes = new HashSet<SampleUserNotes>();
            Samplenotes = new HashSet<Samplenotes>();
        }

        public long SamplesId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public decimal? OldSampleId { get; set; }
        public decimal? NirClassId { get; set; }
        public decimal? ChemClassId { get; set; }
        public int? RegionStateId { get; set; }
        public int? FeedCodeId { get; set; }
        public int? WinlabSampleId { get; set; }
        public string AccountCode { get; set; }
        public string FarmName { get; set; }
        public bool? CopyTo { get; set; }
        public string SampleDesc { get; set; }
        public int? EqtypeId { get; set; }
        public string FeedType { get; set; }
        public bool? Wet { get; set; }
        public int? Cutting { get; set; }
        public decimal? AmountDue { get; set; }
        public int? HarvestYear { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? SampledDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? ProcessDate { get; set; }
        public decimal? Wewt { get; set; }
        public bool? AllDone { get; set; }
        public bool? Release { get; set; }
        public bool? Lnir { get; set; }
        public bool? Lbq { get; set; }
        public bool? Lndf30 { get; set; }
        public bool? Linvndf { get; set; }
        public bool? Lmold { get; set; }
        public int? Agclass { get; set; }
        public bool? Lmoisture { get; set; }
        public bool? Lprotein { get; set; }
        public bool? Ladin { get; set; }
        public bool? Lndf { get; set; }
        public bool? Lndfs { get; set; }
        public bool? Llignin { get; set; }
        public bool? Lfat { get; set; }
        public bool? Lno3 { get; set; }
        public bool? Lnpn { get; set; }
        public bool? Lsolpro { get; set; }
        public bool? Luip { get; set; }
        public bool? Lpepsin { get; set; }
        public bool? Lsulfur { get; set; }
        public bool? Lchloride { get; set; }
        public bool? Ltrace { get; set; }
        public bool? Lsalt { get; set; }
        public bool? Lash { get; set; }
        public bool? Ltoxin { get; set; }
        public bool? Lammonia { get; set; }
        public bool? Lfa { get; set; }
        public bool? Lsize { get; set; }
        public bool? Losu { get; set; }
        public bool? Lurease { get; set; }
        public bool? Ltitrate { get; set; }
        public bool? Llact { get; set; }
        public bool? Lstarch { get; set; }
        public bool? Lsugar { get; set; }
        public bool? Lndin { get; set; }
        public bool? Lrbean { get; set; }
        public bool? Laflat { get; set; }
        public decimal? Aflat { get; set; }
        public bool? Lzeral { get; set; }
        public bool? Ldon { get; set; }
        public bool? Lt2 { get; set; }
        public bool? Lcap { get; set; }
        public bool? Lmacro { get; set; }
        public bool? Ladf { get; set; }
        public bool? Lcfiber { get; set; }
        public bool? Lht2 { get; set; }
        public bool? Ldas { get; set; }
        public bool? Lneo { get; set; }
        public bool? Ldrycow { get; set; }
        public bool? Lcornell { get; set; }
        public bool? Lbyprod { get; set; }
        public bool? LAsh { get; set; }
        public bool? LFat { get; set; }
        public bool? LSta { get; set; }
        public bool? LLig { get; set; }
        public bool? LHyg { get; set; }
        public bool? LK { get; set; }
        public bool? LMg { get; set; }
        public bool? LP { get; set; }
        public bool? LCa { get; set; }
        public bool? LIsP { get; set; }
        public bool? LHdP { get; set; }
        public bool? LNdf { get; set; }
        public bool? LAdf { get; set; }
        public bool? LCp { get; set; }
        public bool? LNStarch { get; set; }
        public bool? Lcho { get; set; }
        public bool? Lselenium { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<Billitems> Billitems { get; set; }
        public ICollection<INdfdinvitro> INdfdinvitro { get; set; }
        public ICollection<ITmrfecal> ITmrfecalFecalSamples { get; set; }
        public ICollection<ITmrfecal> ITmrfecalTmrSamples { get; set; }
        public ICollection<Invitro> Invitro { get; set; }
        public ICollection<SampleUserNotes> SampleUserNotes { get; set; }
        public ICollection<Samplenotes> Samplenotes { get; set; }
    }
}
