using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class SampleprepSamples
    {
        public int SampleId { get; set; }
        public int LabId { get; set; }
        public int DmVesselid { get; set; }
        public int Dm2Vesselid { get; set; }
        public int NirclassId { get; set; }
        public int NirequationId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsToxic { get; set; }
        public string LogonName { get; set; }
        public bool? Linvitro { get; set; }
        public bool? Lstarch7 { get; set; }
        public bool? Lcsps { get; set; }
        public bool? LpeNdf { get; set; }
        public bool? Lprussic { get; set; }
        public bool? Lsalmonella { get; set; }
        public bool? Lmoldyeast { get; set; }
        public bool? Retained { get; set; }
        public bool? Lmycotoxinbag { get; set; }
        public bool? Lboron { get; set; }
        public bool? Lmoly { get; set; }
        public bool? Lnpn { get; set; }
        public bool? Lvitamins { get; set; }
        public bool? Lfap { get; set; }
        public bool? Lahf { get; set; }
        public bool? Lferm { get; set; }
        public bool? Wet { get; set; }
        public bool? Lsavebag { get; set; }
        public bool? Lstarch2 { get; set; }
        public bool? Lstarch24 { get; set; }
        public bool? Lmoldid { get; set; }
        public bool? Lparticlesize { get; set; }
        public bool? Lmicronsize { get; set; }
        public bool? Lfermplus { get; set; }

        public SampleprepStandardvesselWgt Dm2Vessel { get; set; }
        public SampleprepStandardvesselWgt DmVessel { get; set; }
        public Nirequations Nirequation { get; set; }
    }
}
