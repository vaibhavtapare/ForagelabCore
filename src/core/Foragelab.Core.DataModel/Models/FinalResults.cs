﻿using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class FinalResults
    {
        public int FinalResultId { get; set; }
        public long? SamplesId { get; set; }
        public decimal? DryMatter { get; set; }
        public decimal? Moisture { get; set; }
        public decimal? CrudeProteinDm { get; set; }
        public decimal? AdjustedProteinDm { get; set; }
        public decimal? AdjustedProteinCp { get; set; }
        public decimal? SolubleProteinDm { get; set; }
        public decimal? SolubleProteinCp { get; set; }
        public decimal? AmmoniaDm { get; set; }
        public decimal? AmmoniaSp { get; set; }
        public decimal? AmmoniaCp { get; set; }
        public decimal? AdfproteinAdicpDm { get; set; }
        public decimal? AdfproteinAdicpCp { get; set; }
        public decimal? NdfproteinNdicpDm { get; set; }
        public decimal? NdfproteinNdicpCp { get; set; }
        public decimal? NdrcpDm { get; set; }
        public decimal? NdrcpCp { get; set; }
        public decimal? RumenDegrProteinDm { get; set; }
        public decimal? RumenDegrProteinCp { get; set; }
        public decimal? RumenUndegrProteinDm { get; set; }
        public decimal? RumenUndegrProteinCp { get; set; }
        public decimal? RumenDegCpstrepGDm { get; set; }
        public decimal? RumenDegCpstrepGCp { get; set; }
        public decimal? AcidDetergentFiberDm { get; set; }
        public decimal? AcidDetergentFiberNdf { get; set; }
        public decimal? NeutralDetergentFiberDm { get; set; }
        public decimal? ANdfom { get; set; }
        public decimal? NdrDm { get; set; }
        public decimal? NdrNdf { get; set; }
        public decimal? PeNdfDm { get; set; }
        public decimal? PeNdfNdf { get; set; }
        public decimal? CrudeFiberDm { get; set; }
        public decimal? CrudeFiberNdf { get; set; }
        public decimal? LigninDm { get; set; }
        public decimal? LigninNdf { get; set; }
        public decimal? Ndf12hrdigestibilityDm { get; set; }
        public decimal? Ndf12hrdigestibilityNdf { get; set; }
        public decimal? Ndf24hrdigestibilityDm { get; set; }
        public decimal? Ndf24hrdigestibilityNdf { get; set; }
        public decimal? Ndf30hrdigestibilityDm { get; set; }
        public decimal? Ndf30hrdigestibilityNdf { get; set; }
        public decimal? Ndf48hrdigestibilityDm { get; set; }
        public decimal? Ndf48hrdigestibilityNdf { get; set; }
        public decimal? Ndfd120Ndf { get; set; }
        public decimal? Ndfd120Dm { get; set; }
        public decimal? UNdfd120Ndf { get; set; }
        public decimal? UNdfd120Dm { get; set; }
        public decimal? Ndf240hrdigestibilityNdf { get; set; }
        public decimal? Ndf240hrdigestibilityDm { get; set; }
        public decimal? AampsscdegradabilityDm { get; set; }
        public decimal? AampsscdegradabilityNdf { get; set; }
        public decimal? IndigestibleNdfinvitro120Ndf { get; set; }
        public decimal? IndigestibleNdfinvitro120Dm { get; set; }
        public decimal? CncpscpmligninFactor { get; set; }
        public decimal? B2b3kdHrDm { get; set; }
        public decimal? B2b3kdHrNdf { get; set; }
        public decimal? NdfdigRateVanAmburghDm { get; set; }
        public decimal? NdfdigRateVanAmburghNdf { get; set; }
        public decimal? NdfdigRateVanAmburghLignin { get; set; }
        public decimal? NdfdigRateVanAmburghINdf { get; set; }
        public decimal? NdfdigRateMertensDm { get; set; }
        public decimal? NdfdigRateMertensNdf { get; set; }
        public decimal? SilageAcidsDm { get; set; }
        public decimal? SilageAcidsNfc { get; set; }
        public decimal? EthanolSolubleChosugarDm { get; set; }
        public decimal? EthanolSolubleChosugarNfc { get; set; }
        public decimal? WaterSolubleChosugarDm { get; set; }
        public decimal? WaterSolubleChosugarNfc { get; set; }
        public decimal? StarchDm { get; set; }
        public decimal? StarchNfc { get; set; }
        public decimal? SolubleFiberDm { get; set; }
        public decimal? SolubleFiberNfc { get; set; }
        public decimal? DigestibleDryMatterFastDm { get; set; }
        public decimal? StarchDigestibility7HrDm { get; set; }
        public decimal? StarchDigestibility7HrNfc { get; set; }
        public decimal? FattyAcidsTotalDm { get; set; }
        public decimal? CrudeFatDm { get; set; }
        public decimal? FattyAcidsCrudeFat { get; set; }
        public decimal? AcidHydrolysisFatDm { get; set; }
        public decimal? StarchMertensDm { get; set; }
        public decimal? StarchMertensNfc { get; set; }
        public decimal? Tdn { get; set; }
        public decimal? NetEnergyLactation { get; set; }
        public decimal? NetEnergyMaintenance { get; set; }
        public decimal? NetEnergyGain { get; set; }
        public decimal? RelativeFeedValue { get; set; }
        public decimal? RelativeFeedQuality { get; set; }
        public decimal? MilkPerTon { get; set; }
        public decimal? Me { get; set; }
        public decimal? DigOrganicMatterIndex { get; set; }
        public decimal? NonFiberCarbohydrates { get; set; }
        public decimal? NonStructuralCarbohydrates { get; set; }
        public decimal? Ash { get; set; }
        public decimal? Calcium { get; set; }
        public decimal? Phosphorus { get; set; }
        public decimal? Magnesium { get; set; }
        public decimal? Potassium { get; set; }
        public decimal? Sulfur { get; set; }
        public decimal? Sodium { get; set; }
        public decimal? Chloride { get; set; }
        public decimal? Iron { get; set; }
        public decimal? Manganese { get; set; }
        public decimal? Zinc { get; set; }
        public decimal? Copper { get; set; }
        public decimal? Selenium { get; set; }
        public decimal? Molybdenum { get; set; }
        public decimal? Dcad { get; set; }
        public decimal? Lurease { get; set; }
        public decimal? HorseTdn { get; set; }
        public decimal? HorseDe { get; set; }
        public decimal? EstimatedBushellTon { get; set; }
        public decimal? PH { get; set; }
        public decimal? TotalVfa { get; set; }
        public decimal? LacticAcid { get; set; }
        public decimal? LacticTotalVfa { get; set; }
        public decimal? AceticAcid { get; set; }
        public decimal? PropionicAcid { get; set; }
        public decimal? ButyricAcid { get; set; }
        public decimal? TitratableAcidity { get; set; }
        public decimal? Propendiol12 { get; set; }
        public decimal? Propanol1 { get; set; }
        public decimal? Methanol { get; set; }
        public decimal? Ethanol { get; set; }
        public decimal? Butanol2 { get; set; }
        public decimal? MethylAcetate { get; set; }
        public decimal? PropylAcetate { get; set; }
        public decimal? EthylLactate { get; set; }
        public decimal? PropylLactate { get; set; }
        public decimal? MoldCount { get; set; }
        public decimal? YeastCount { get; set; }
        public decimal? SoilContaminationProbability { get; set; }
        public decimal? NitrateProbability { get; set; }
        public decimal? VomitoxinProbability { get; set; }
        public decimal? NirstatisticalConfidence { get; set; }
        public decimal? NitrateIon { get; set; }
        public decimal? CornSilageProcessingScore { get; set; }
        public decimal? ParticlesGt075 { get; set; }
        public decimal? ParticlesF031075 { get; set; }
        public decimal? ParticlesLt031 { get; set; }
        public decimal? Ps1 { get; set; }
        public decimal? Ps2 { get; set; }
        public decimal? Ps3 { get; set; }
        public decimal? Ps4 { get; set; }
        public decimal? Pscumulative1 { get; set; }
        public decimal? Pscumulative2 { get; set; }
        public decimal? Pscumulative3 { get; set; }
        public decimal? Psaverage { get; set; }
        public decimal? PsstdDev { get; set; }
        public decimal? Ifvalue { get; set; }
        public decimal? Pdvalue { get; set; }
        public decimal? Atox { get; set; }
        public decimal? AtoxB1 { get; set; }
        public decimal? AtoxB2 { get; set; }
        public decimal? AtoxG1 { get; set; }
        public decimal? AtoxG2 { get; set; }
        public decimal? Vomitoxin { get; set; }
        public decimal? Don15Ac { get; set; }
        public decimal? Don3Ac { get; set; }
        public decimal? FtoxB1 { get; set; }
        public decimal? FtoxB2 { get; set; }
        public decimal? FtoxB3 { get; set; }
        public decimal? T2tox { get; set; }
        public decimal? Ztox { get; set; }
        public decimal? SummativeIndex { get; set; }
        public decimal? Aflat { get; set; }
        public decimal? AdjustedNel { get; set; }
        public decimal? SchwabShaverNelprocessed { get; set; }
        public decimal? SchwabShaverNelunprocessed { get; set; }
        public decimal? Nelndfdadjustment { get; set; }
        public decimal? Ochratoxin { get; set; }
        public decimal? Ht2 { get; set; }
        public decimal? AtoxB1nonDetect { get; set; }
        public decimal? AtoxB2nonDetect { get; set; }
        public decimal? AtoxG1nonDetect { get; set; }
        public decimal? AtoxG2nonDetect { get; set; }
        public decimal? ZtoxNonDetect { get; set; }
        public decimal? VomitoxinNonDetect { get; set; }
        public decimal? Don15AcNonDetect { get; set; }
        public decimal? Don3AcNonDetect { get; set; }
        public decimal? T2toxNonDetect { get; set; }
        public decimal? FtoxB1nonDetect { get; set; }
        public decimal? FtoxB2nonDetect { get; set; }
        public decimal? FtoxB3nonDetect { get; set; }
        public decimal? Ht2NonDetect { get; set; }
        public decimal? OchratoxinNonDetect { get; set; }
        public decimal? DonMethod { get; set; }
        public decimal? FatEe { get; set; }
        public decimal? FatAh { get; set; }
        public decimal? IndigestibleNdfinvitro30Ndf { get; set; }
        public decimal? IndigestibleNdfinvitro30Dm { get; set; }
        public decimal? SaturatedFattyAcids { get; set; }
        public decimal? UnsaturatedFattyAcids { get; set; }
        public decimal? OwensTdn { get; set; }
        public decimal? OwensNem { get; set; }
        public decimal? OwensNeg { get; set; }
        public decimal? OwnesNel { get; set; }
        public decimal? UreaseActivity { get; set; }
        public decimal? ProteinDispersibilityIndex { get; set; }
        public string PackageName { get; set; }
        public decimal? NutrecoStatus { get; set; }
        public bool? ImoldId { get; set; }
        public int? VersionNumber { get; set; }
    }
}
