using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Rawdata
    {
        public long RawDataId { get; set; }
        public long? SamplesId { get; set; }
        public decimal? Hygro { get; set; }
        public decimal? FatCru { get; set; }
        public decimal? FatSm { get; set; }
        public decimal? FatCrusm { get; set; }
        public decimal? CalculatedFat { get; set; }
        public decimal? LigCruash { get; set; }
        public decimal? LigSm { get; set; }
        public decimal? LigCrusm { get; set; }
        public decimal? CalculatedLignin { get; set; }
        public decimal? AdfBag { get; set; }
        public decimal? AdfBagtr { get; set; }
        public decimal? AdfBagsm { get; set; }
        public decimal? CalculatedAdf { get; set; }
        public decimal? NdfBag { get; set; }
        public decimal? NdfBagtr { get; set; }
        public decimal? NdfBagsm { get; set; }
        public decimal? CalculatedNdf { get; set; }
        public decimal? AdfPc { get; set; }
        public decimal? CalculatedAdin { get; set; }
        public decimal? NdfPc { get; set; }
        public decimal? CalculatedNdin { get; set; }
        public decimal? Pro1Sm { get; set; }
        public decimal? Pro1Pc { get; set; }
        public decimal? CalculatedCp { get; set; }
        public decimal? Ps1 { get; set; }
        public decimal? Ps2 { get; set; }
        public decimal? Ps3 { get; set; }
        public decimal? Ps4 { get; set; }
        public decimal? SproBagsm { get; set; }
        public decimal? SproPc { get; set; }
        public decimal? SproBag { get; set; }
        public decimal? SproSm { get; set; }
        public decimal? StrchPc { get; set; }
        public decimal? StrchBl { get; set; }
        public decimal? StrchWt { get; set; }
        public decimal? CalculatedStarch { get; set; }
        public decimal? AshSm { get; set; }
        public decimal? AshCru { get; set; }
        public decimal? AshCrusm { get; set; }
        public decimal? CalculatedAsh { get; set; }

        public Rawdata RawData { get; set; }
        public Rawdata InverseRawData { get; set; }
    }
}
