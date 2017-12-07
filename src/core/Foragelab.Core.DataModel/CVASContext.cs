using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Foragelab.Core.DataModel
{
    public partial class CVASContext : DbContext
    {



        public CVASContext(DbContextOptions<CVASContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNT");

                entity.HasIndex(e => new { e.FirstName, e.LastName, e.AccountCode })
                    .HasName("IXACCOUNTCODE");

                entity.HasIndex(e => new { e.FirstName, e.LastName, e.BusinessName, e.AccountCode, e.AccountId })
                    .HasName("_dta_index_ACCOUNT_8_1509580416__K2_K1_4_5_6")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccountCode).HasMaxLength(50);

                entity.Property(e => e.AddressTypeId).HasColumnName("AddressTypeID");

                entity.Property(e => e.AutoCopyTo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessName).HasMaxLength(50);

                entity.Property(e => e.CopyTo).HasMaxLength(200);

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fax)
                    .HasColumnName("FAX")
                    .HasMaxLength(50);

                entity.Property(e => e.FaxAnyTime)
                    .HasColumnName("Fax_AnyTime")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IsMergeReports).HasDefaultValueSql("((1))");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.ModifiedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReportForm)
                    .HasColumnName("Report_Form")
                    .HasMaxLength(150);

                entity.Property(e => e.ReportPreference)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UnitSystemId)
                    .HasColumnName("UnitSystemID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.WinLabName).HasMaxLength(50);

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.AddressTypeId)
                    .HasConstraintName("FK_ACCOUNT_ADDRESSTYPE");
            });

            modelBuilder.Entity<Accountaddress>(entity =>
            {
                entity.ToTable("ACCOUNTADDRESS");

                entity.Property(e => e.AccountAddressId).HasColumnName("AccountAddressID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Accountaddress)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTADDRESS_ACCOUNT");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Accountaddress)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTADDRESS_ADDRESS");
            });

            modelBuilder.Entity<Accountcopytos>(entity =>
            {
                entity.HasKey(e => e.AccountCopyToId);

                entity.ToTable("ACCOUNTCOPYTOS");

                entity.Property(e => e.AccountCopyToId).HasColumnName("AccountCopyToID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CopyToId).HasColumnName("CopyToID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Accountcopytos)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTCOYPTOS_ACCOUNT");

                entity.HasOne(d => d.CopyTo)
                    .WithMany(p => p.Accountcopytos)
                    .HasForeignKey(d => d.CopyToId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTCOYPTOS_COPYTO");
            });

            modelBuilder.Entity<Accountpref>(entity =>
            {
                entity.ToTable("ACCOUNTPREF");

                entity.Property(e => e.AccountPrefId).HasColumnName("AccountPrefID");

                entity.Property(e => e.AccountPrefDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AccountPrefName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AccountPrefSwitch)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("ADDRESS");

                entity.Property(e => e.Address1)
                    .HasColumnName("Address_1")
                    .HasMaxLength(150);

                entity.Property(e => e.Address2)
                    .HasColumnName("Address_2")
                    .HasMaxLength(150);

                entity.Property(e => e.Address3)
                    .HasColumnName("Address_3")
                    .HasMaxLength(150);

                entity.Property(e => e.AttnName).HasMaxLength(150);

                entity.Property(e => e.CellPhone).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CountryCode).HasMaxLength(50);

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.ModifiedDt).HasColumnType("datetime");

                entity.Property(e => e.Municipality).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasMaxLength(50);
            });

            modelBuilder.Entity<Addresstype>(entity =>
            {
                entity.ToTable("ADDRESSTYPE");

                entity.Property(e => e.AddressTypeId).HasColumnName("AddressTypeID");

                entity.Property(e => e.AddressTypeDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressTypeValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Affiliatelabs>(entity =>
            {
                entity.HasKey(e => e.AffiliateId);

                entity.ToTable("AFFILIATELABS");

                entity.Property(e => e.AffiliateId).HasColumnName("AffiliateID");

                entity.Property(e => e.AffiliateCode).HasMaxLength(3);
            });

            modelBuilder.Entity<Aminoacidanalysis>(entity =>
            {
                entity.HasKey(e => e.AminoAcidId);

                entity.ToTable("AMINOACIDANALYSIS");

                entity.Property(e => e.AminoAcidId).HasColumnName("AminoAcidID");

                entity.Property(e => e.AminoAcidCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.AminoAcidDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AminoAcidValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DomesticPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DomesticSpecialItemId).HasColumnName("DomesticSpecialItemID");

                entity.Property(e => e.IntSpecialItemId).HasColumnName("IntSpecialItemID");

                entity.Property(e => e.InternationalPrice).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.DomesticSpecialItem)
                    .WithMany(p => p.AminoacidanalysisDomesticSpecialItem)
                    .HasForeignKey(d => d.DomesticSpecialItemId)
                    .HasConstraintName("FK_AMINOACIDANALYSIS_SPECIALITEMS");

                entity.HasOne(d => d.IntSpecialItem)
                    .WithMany(p => p.AminoacidanalysisIntSpecialItem)
                    .HasForeignKey(d => d.IntSpecialItemId)
                    .HasConstraintName("FK_AMINOACIDANALYSIS_SPECIALITEMS1");
            });

            modelBuilder.Entity<Analysisoptions>(entity =>
            {
                entity.HasKey(e => e.AnalysisId);

                entity.ToTable("ANALYSISOPTIONS");

                entity.Property(e => e.AnalysisId).HasColumnName("AnalysisID");

                entity.Property(e => e.AnalysisCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.AnalysisDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AnalysisValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DomesticPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DomesticSpecialItemId).HasColumnName("DomesticSpecialItemID");

                entity.Property(e => e.IntSpecialItemId).HasColumnName("IntSpecialItemID");

                entity.Property(e => e.InternationalPrice).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.DomesticSpecialItem)
                    .WithMany(p => p.AnalysisoptionsDomesticSpecialItem)
                    .HasForeignKey(d => d.DomesticSpecialItemId)
                    .HasConstraintName("FK_ANALYSISOPTIONS_SPECIALITEMS");

                entity.HasOne(d => d.IntSpecialItem)
                    .WithMany(p => p.AnalysisoptionsIntSpecialItem)
                    .HasForeignKey(d => d.IntSpecialItemId)
                    .HasConstraintName("FK_ANALYSISOPTIONS_SPECIALITEMS1");
            });

            modelBuilder.Entity<Appearance>(entity =>
            {
                entity.ToTable("APPEARANCE");

                entity.Property(e => e.AppearanceId).HasColumnName("AppearanceID");

                entity.Property(e => e.Cname)
                    .HasColumnName("CName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cvalue)
                    .HasColumnName("CValue")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ash>(entity =>
            {
                entity.ToTable("ASH");

                entity.HasIndex(e => new { e.Ash1, e.ResultsId })
                    .HasName("IX_RESULTID")
                    .IsUnique();

                entity.Property(e => e.Ashid).HasColumnName("ASHID");

                entity.Property(e => e.Ash1)
                    .HasColumnName("ASH")
                    .HasColumnType("numeric(6, 3)");

                entity.Property(e => e.AshAll)
                    .HasColumnName("ASH_All")
                    .HasColumnType("numeric(6, 3)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");
            });

            modelBuilder.Entity<AspnetApplications>(entity =>
            {
                entity.HasKey(e => e.ApplicationId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("aspnet_Applications");

                entity.HasIndex(e => e.ApplicationName)
                    .HasName("UQ__aspnet_A__309103317B5B524B")
                    .IsUnique();

                entity.HasIndex(e => e.LoweredApplicationName)
                    .HasName("aspnet_Applications_Index")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ApplicationName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredApplicationName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspnetMembership>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("aspnet_Membership");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredEmail })
                    .HasName("aspnet_Membership_index")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasColumnType("ntext(3000)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");

                entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredEmail).HasMaxLength(256);

                entity.Property(e => e.MobilePin)
                    .HasColumnName("MobilePIN")
                    .HasMaxLength(16);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PasswordAnswer).HasMaxLength(128);

                entity.Property(e => e.PasswordFormat).HasDefaultValueSql("((0))");

                entity.Property(e => e.PasswordQuestion).HasMaxLength(256);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetMembership)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Me__Appli__160F4887");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AspnetMembership)
                    .HasForeignKey<AspnetMembership>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Me__UserI__17036CC0");
            });

            modelBuilder.Entity<AspnetPaths>(entity =>
            {
                entity.HasKey(e => e.PathId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("aspnet_Paths");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredPath })
                    .HasName("aspnet_Paths_index")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.PathId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LoweredPath)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetPaths)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Pa__Appli__4F47C5E3");
            });

            modelBuilder.Entity<AspnetPersonalizationAllUsers>(entity =>
            {
                entity.HasKey(e => e.PathId);

                entity.ToTable("aspnet_PersonalizationAllUsers");

                entity.Property(e => e.PathId).ValueGeneratedNever();

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.PageSettings)
                    .IsRequired()
                    .HasColumnType("image(6000)");

                entity.HasOne(d => d.Path)
                    .WithOne(p => p.AspnetPersonalizationAllUsers)
                    .HasForeignKey<AspnetPersonalizationAllUsers>(d => d.PathId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Pe__PathI__56E8E7AB");
            });

            modelBuilder.Entity<AspnetPersonalizationPerUser>(entity =>
            {
                entity.ToTable("aspnet_PersonalizationPerUser");

                entity.HasIndex(e => new { e.PathId, e.UserId })
                    .HasName("aspnet_PersonalizationPerUser_index1")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => new { e.UserId, e.PathId })
                    .HasName("aspnet_PersonalizationPerUser_ncindex2")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.PageSettings)
                    .IsRequired()
                    .HasColumnType("image(6000)");

                entity.HasOne(d => d.Path)
                    .WithMany(p => p.AspnetPersonalizationPerUser)
                    .HasForeignKey(d => d.PathId)
                    .HasConstraintName("FK__aspnet_Pe__PathI__5CA1C101");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspnetPersonalizationPerUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__aspnet_Pe__UserI__5D95E53A");
            });

            modelBuilder.Entity<AspnetProfile>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("aspnet_Profile");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.PropertyNames)
                    .IsRequired()
                    .HasColumnType("ntext(6000)");

                entity.Property(e => e.PropertyValuesBinary)
                    .IsRequired()
                    .HasColumnType("image(6000)");

                entity.Property(e => e.PropertyValuesString)
                    .IsRequired()
                    .HasColumnType("ntext(6000)");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AspnetProfile)
                    .HasForeignKey<AspnetProfile>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Pr__UserI__2CF2ADDF");
            });

            modelBuilder.Entity<AspnetRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("aspnet_Roles");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredRoleName })
                    .HasName("aspnet_Roles_index1")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredRoleName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetRoles)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Ro__Appli__3864608B");
            });

            modelBuilder.Entity<AspnetSchemaVersions>(entity =>
            {
                entity.HasKey(e => new { e.Feature, e.CompatibleSchemaVersion });

                entity.ToTable("aspnet_SchemaVersions");

                entity.Property(e => e.Feature).HasMaxLength(128);

                entity.Property(e => e.CompatibleSchemaVersion).HasMaxLength(128);
            });

            modelBuilder.Entity<AspnetUsers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("aspnet_Users");

                entity.HasIndex(e => new { e.ApplicationId, e.LastActivityDate })
                    .HasName("aspnet_Users_Index2");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredUserName })
                    .HasName("aspnet_Users_Index")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredUserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.MobileAlias).HasMaxLength(16);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetUsers)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Us__Appli__02084FDA");
            });

            modelBuilder.Entity<AspnetUsersInRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.ToTable("aspnet_UsersInRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("aspnet_UsersInRoles_index");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspnetUsersInRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Us__RoleI__3F115E1A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspnetUsersInRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Us__UserI__3E1D39E1");
            });

            modelBuilder.Entity<AspnetWebEventEvents>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("aspnet_WebEvent_Events");

                entity.Property(e => e.EventId)
                    .HasColumnType("char(32)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApplicationPath).HasMaxLength(256);

                entity.Property(e => e.ApplicationVirtualPath).HasMaxLength(256);

                entity.Property(e => e.Details).HasColumnType("ntext");

                entity.Property(e => e.EventOccurrence).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.EventSequence).HasColumnType("decimal(19, 0)");

                entity.Property(e => e.EventTime).HasColumnType("datetime");

                entity.Property(e => e.EventTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.EventType)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ExceptionType).HasMaxLength(256);

                entity.Property(e => e.MachineName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Message).HasMaxLength(1024);

                entity.Property(e => e.RequestUrl).HasMaxLength(1024);
            });

            modelBuilder.Entity<Billitems>(entity =>
            {
                entity.HasKey(e => e.BillItemId);

                entity.ToTable("BILLITEMS");

                entity.HasIndex(e => new { e.SpecialItemId, e.SamplesId })
                    .HasName("IX_SPECITEM_SAMPLEID");

                entity.Property(e => e.BillItemId).HasColumnName("BillItemID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.SamplesId).HasColumnName("SamplesID");

                entity.Property(e => e.SpecialItemId).HasColumnName("SpecialItemID");

                entity.HasOne(d => d.Samples)
                    .WithMany(p => p.Billitems)
                    .HasForeignKey(d => d.SamplesId)
                    .HasConstraintName("FK_BILLITEMS_SAMPLES");

                entity.HasOne(d => d.SpecialItem)
                    .WithMany(p => p.Billitems)
                    .HasForeignKey(d => d.SpecialItemId)
                    .HasConstraintName("FK_BILLITEMS_SPECIALITEMS");
            });

            modelBuilder.Entity<Billtoaccounts>(entity =>
            {
                entity.HasKey(e => e.BillToAccountId);

                entity.ToTable("BILLTOACCOUNTS");

                entity.Property(e => e.BillToAccountId).HasColumnName("BillToAccountID");

                entity.Property(e => e.BillToAccountAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Blurb>(entity =>
            {
                entity.ToTable("BLURB");

                entity.Property(e => e.BlurbId).HasColumnName("BlurbID");

                entity.Property(e => e.BlurbText).HasMaxLength(1000);

                entity.Property(e => e.BlurbTitle).HasMaxLength(100);

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.ModifiedDt).HasColumnType("datetime");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<Calculation>(entity =>
            {
                entity.ToTable("CALCULATION");

                entity.HasIndex(e => new { e.Nelmcallb, e.Nemmcallb, e.Negmcallb, e.Memcallb, e.Tdn, e.Rfv, e.Rfq, e.Nfc, e.Ndfkd, e.Starchkd, e.LigNdf, e.CpAdj, e.CpAv, e.RdpCp, e.IndfLig, e.TdnHorse, e.No3, e.No3ppm, e.No3n, e.Dcad, e.Nsc, e.ResultsId })
                    .HasName("IX_RESULTID")
                    .IsUnique();

                entity.Property(e => e.CalculationId).HasColumnName("CalculationID");

                entity.Property(e => e.Acetid).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CpAdj)
                    .HasColumnName("CP_ADJ")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.CpAv)
                    .HasColumnName("CP_AV")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Dcad)
                    .HasColumnName("DCAD")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.DeHorse)
                    .HasColumnName("DE_Horse")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Demcalkg)
                    .HasColumnName("DEMcalkg")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.Demcallb)
                    .HasColumnName("DEMcallb")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.Demjkg)
                    .HasColumnName("DEMJkg")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Domi)
                    .HasColumnName("DOMI")
                    .HasColumnType("decimal(4, 0)");

                entity.Property(e => e.IndfLig)
                    .HasColumnName("INDF_lig")
                    .HasColumnType("decimal(3, 1)");

                entity.Property(e => e.LigNdf)
                    .HasColumnName("Lig_NDF")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Memcalkg)
                    .HasColumnName("MEMcalkg")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.Memcallb)
                    .HasColumnName("MEMcallb")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.Memjkg)
                    .HasColumnName("MEMJkg")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.MilktonCsn)
                    .HasColumnName("MilktonCSn")
                    .HasColumnType("decimal(4, 0)");

                entity.Property(e => e.MilktonCsp)
                    .HasColumnName("MilktonCSp")
                    .HasColumnType("decimal(4, 0)");

                entity.Property(e => e.MilktonH).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Ndfd120Ndf)
                    .HasColumnName("NDFD120_NDF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ndfd240Ndf)
                    .HasColumnName("NDFD240_NDF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Ndfkd)
                    .HasColumnName("NDFkd")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Negmcalkg)
                    .HasColumnName("NEGMcalkg")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.Negmcallb)
                    .HasColumnName("NEGMcallb")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Negmjkg)
                    .HasColumnName("NEGMJkg")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.NelAdj)
                    .HasColumnName("NEL_ADJ")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NelCsnMcalkg)
                    .HasColumnName("NEL_CSnMcalkg")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.NelCsnMcallb)
                    .HasColumnName("NEL_CSnMcallb")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.NelCsnMjkg)
                    .HasColumnName("NEL_CSnMJkg")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.NelCspMcalkg)
                    .HasColumnName("NEL_CSpMcalkg")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.NelCspMcallb)
                    .HasColumnName("NEL_CSpMcallb")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.NelCspMjkg)
                    .HasColumnName("NEL_CSpMJkg")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.Nelmcalkg)
                    .HasColumnName("NELMcalkg")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.Nelmcallb)
                    .HasColumnName("NELMcallb")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Nelmjkg)
                    .HasColumnName("NELMJkg")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.Nemmcalkg)
                    .HasColumnName("NEMMcalkg")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.Nemmcallb)
                    .HasColumnName("NEMMcallb")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Nemmjkg)
                    .HasColumnName("NEMMJkg")
                    .HasColumnType("decimal(4, 3)");

                entity.Property(e => e.Nfc)
                    .HasColumnName("NFC")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.No3)
                    .HasColumnName("NO3")
                    .HasColumnType("decimal(3, 1)");

                entity.Property(e => e.No3n)
                    .HasColumnName("NO3N")
                    .HasColumnType("decimal(3, 1)");

                entity.Property(e => e.No3ppm)
                    .HasColumnName("NO3ppm")
                    .HasColumnType("decimal(6, 1)");

                entity.Property(e => e.Nsc)
                    .HasColumnName("NSC")
                    .HasColumnType("decimal(8, 1)");

                entity.Property(e => e.RdpCp)
                    .HasColumnName("RDP_CP")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.Property(e => e.Rfq)
                    .HasColumnName("RFQ")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Rfv)
                    .HasColumnName("RFV")
                    .HasColumnType("decimal(3, 0)");

                entity.Property(e => e.SchwabShaverNelprocessed)
                    .HasColumnName("SchwabShaverNELProcessed")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.SchwabShaverNelunprocessed)
                    .HasColumnName("SchwabShaverNELUnprocessed")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Starchkd).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.SummativeIndex).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Tdn)
                    .HasColumnName("TDN")
                    .HasColumnType("decimal(7, 3)");

                entity.Property(e => e.TdnCalc)
                    .HasColumnName("TDN_CALC")
                    .HasColumnType("decimal(7, 3)");

                entity.Property(e => e.TdnHorse)
                    .HasColumnName("TDN_Horse")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.UNdf120Ndf)
                    .HasColumnName("uNDF120_NDF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.UNdf240Ndf)
                    .HasColumnName("uNDF240_NDF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.VanAmburghLignin).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.VanAmburghiNdf)
                    .HasColumnName("VanAmburghiNDF")
                    .HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Chemclass>(entity =>
            {
                entity.ToTable("CHEMCLASS");

                entity.Property(e => e.ChemClassId).HasColumnName("ChemClassID");

                entity.Property(e => e.ChemClassDescription).HasColumnType("nchar(10)");

                entity.Property(e => e.ChemClassName).HasColumnType("nchar(10)");

                entity.Property(e => e.ChemClassNumber).HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<Cho>(entity =>
            {
                entity.ToTable("CHO");

                entity.HasIndex(e => new { e.SugarEsc, e.Starch, e.ResultsId })
                    .HasName("IX_ResultID")
                    .IsUnique();

                entity.HasIndex(e => new { e.SugarEsc, e.Glucose, e.Sucrose, e.Fructose, e.Manitol, e.Arabinose, e.Xylose, e.Ribose, e.GlucAcid, e.Galactose, e.GalAcid, e.Starch, e.StarchGel, e.StarchGelperSt, e.StarchEa, e.Choid })
                    .HasName("IX_CHOID")
                    .IsUnique();

                entity.Property(e => e.Choid).HasColumnName("CHOID");

                entity.Property(e => e.Arabinose).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Fructose).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.GalAcid)
                    .HasColumnName("Gal_acid")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Galactose).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.GlucAcid)
                    .HasColumnName("Gluc_acid")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Glucose).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Manitol).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.Property(e => e.Ribose).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Starch).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.StarchEa)
                    .HasColumnName("Starch_EA")
                    .HasColumnType("numeric(6, 3)");

                entity.Property(e => e.StarchGel)
                    .HasColumnName("Starch_GEL")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.StarchGelperSt)
                    .HasColumnName("Starch_GELPerST")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Sucrose).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.SugarEsc)
                    .HasColumnName("Sugar_ESC")
                    .HasColumnType("numeric(5, 1)");

                entity.Property(e => e.Xylose).HasColumnType("numeric(4, 2)");
            });

            modelBuilder.Entity<Clientphotos>(entity =>
            {
                entity.HasKey(e => e.ClientPhotoId);

                entity.ToTable("CLIENTPHOTOS");

                entity.Property(e => e.ClientPhotoId).HasColumnName("ClientPhotoID");

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.PhotoDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampleEntryId).HasColumnName("SampleEntryID");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.ToTable("CLIENTS");

                entity.Property(e => e.ClientsId).HasColumnName("ClientsID");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cmsmedia>(entity =>
            {
                entity.ToTable("CMSMEDIA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BlurbId).HasColumnName("BlurbID");

                entity.Property(e => e.CmspageMlid).HasColumnName("CMSPageMLID");

                entity.Property(e => e.MediaId).HasColumnName("MediaID");

                entity.HasOne(d => d.CmspageMl)
                    .WithMany(p => p.Cmsmedia)
                    .HasForeignKey(d => d.CmspageMlid)
                    .HasConstraintName("FK_CMSMEDIA_CMSPAGEML");
            });

            modelBuilder.Entity<Cmspageml>(entity =>
            {
                entity.ToTable("CMSPAGEML");

                entity.Property(e => e.CmspageMlid).HasColumnName("CMSPageMLID");

                entity.Property(e => e.CmspageDescription)
                    .HasColumnName("CMSPageDescription")
                    .HasColumnType("ntext");

                entity.Property(e => e.CmspageTitle)
                    .HasColumnName("CMSPageTitle")
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.MenulinkId).HasColumnName("MenulinkID");

                entity.Property(e => e.ModifiedDt).HasColumnType("datetime");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.Menulink)
                    .WithMany(p => p.Cmspageml)
                    .HasForeignKey(d => d.MenulinkId)
                    .HasConstraintName("FK_CMSPAGEML_MENU");
            });

            modelBuilder.Entity<Cobrandaccounts>(entity =>
            {
                entity.ToTable("COBRANDACCOUNTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CoBrandId).HasColumnName("CoBrandID");
            });

            modelBuilder.Entity<CobrandReportExceptions>(entity =>
            {
                entity.ToTable("COBRAND_REPORT_EXCEPTIONS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Cobrandid).HasColumnName("COBRANDID");

                entity.Property(e => e.CreatedDt).HasColumnType("date");

                entity.Property(e => e.ExceptionName)
                    .IsRequired()
                    .HasColumnName("EXCEPTION_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InverseIdNavigation)
                    .HasForeignKey<CobrandReportExceptions>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_C_Table_1");
            });

            modelBuilder.Entity<Cobrands>(entity =>
            {
                entity.HasKey(e => e.CoBrandId);

                entity.ToTable("COBRANDS");

                entity.Property(e => e.CoBrandId).HasColumnName("CoBrandID");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FooterImageName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HeaderImageName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Completedsamples>(entity =>
            {
                entity.ToTable("COMPLETEDSAMPLES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgClassId).HasColumnName("AgClassID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.ChemClassId).HasColumnName("ChemClassID");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.LabId)
                    .HasColumnName("LabID")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NirClassId).HasColumnName("NirClassID");
            });

            modelBuilder.Entity<Components>(entity =>
            {
                entity.HasKey(e => e.ComponentId);

                entity.ToTable("COMPONENTS");

                entity.Property(e => e.ComponentId).HasColumnName("ComponentID");

                entity.Property(e => e.ComponentCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DomesticPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DomesticSpecialItemId).HasColumnName("DomesticSpecialItemID");

                entity.Property(e => e.IntSpecialItemId).HasColumnName("IntSpecialItemID");

                entity.Property(e => e.InternationalPrice).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.DomesticSpecialItem)
                    .WithMany(p => p.ComponentsDomesticSpecialItem)
                    .HasForeignKey(d => d.DomesticSpecialItemId)
                    .HasConstraintName("FK_COMPONENTS_SPECIALITEMS");

                entity.HasOne(d => d.IntSpecialItem)
                    .WithMany(p => p.ComponentsIntSpecialItem)
                    .HasForeignKey(d => d.IntSpecialItemId)
                    .HasConstraintName("FK_COMPONENTS_SPECIALITEMS1");
            });

            modelBuilder.Entity<Condition>(entity =>
            {
                entity.ToTable("CONDITION");

                entity.Property(e => e.ConditionId).HasColumnName("ConditionID");

                entity.Property(e => e.Cname)
                    .HasColumnName("CName")
                    .HasMaxLength(50);

                entity.Property(e => e.Cvalue)
                    .HasColumnName("CValue")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Contactus>(entity =>
            {
                entity.ToTable("CONTACTUS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(200);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ShowText).HasMaxLength(500);

                entity.Property(e => e.UpdatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserQuestion).HasMaxLength(500);
            });

            modelBuilder.Entity<Contentlabel>(entity =>
            {
                entity.ToTable("CONTENTLABEL");

                entity.Property(e => e.ContentLabelId).HasColumnName("ContentLabelID");

                entity.Property(e => e.ClpageName)
                    .HasColumnName("CLPageName")
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.FormatTypeId).HasColumnName("FormatTypeID");

                entity.Property(e => e.LableIdonPage)
                    .HasColumnName("LableIDOnPage")
                    .HasMaxLength(128);

                entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Contentlabelml>(entity =>
            {
                entity.ToTable("CONTENTLABELML");

                entity.Property(e => e.ContentLabelMlid).HasColumnName("ContentLabelMLID");

                entity.Property(e => e.ContentLabel).HasMaxLength(128);

                entity.Property(e => e.ContentLabelId).HasColumnName("ContentLabelID");

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Copyto>(entity =>
            {
                entity.ToTable("COPYTO");

                entity.HasIndex(e => new { e.CopyToId, e.CopyToName })
                    .HasName("NonClustered_CopyToName_IncludeCopyToID");

                entity.HasIndex(e => new { e.CopyToName, e.CopyToId })
                    .HasName("_dta_index_COPYTO_8_630293305__K1_18")
                    .IsUnique();

                entity.Property(e => e.CopyToId).HasColumnName("CopyToID");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.BuisnessName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CopyToName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasColumnName("FAX")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FaxAnytime)
                    .HasColumnName("Fax_Anytime")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsMergeReports).HasDefaultValueSql("((1))");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDt).HasColumnType("datetime");

                entity.Property(e => e.ReportForm)
                    .HasColumnName("Report_Form")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReportPreference)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WinLabName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Copyto)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_COPYTO_ADDRESS");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Code).HasMaxLength(3);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CvasConfig>(entity =>
            {
                entity.HasKey(e => e.ConfigId);

                entity.Property(e => e.AttributeKey)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AttributeValue)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dm>(entity =>
            {
                entity.ToTable("DM");

                entity.HasIndex(e => new { e.Dm1, e.ResultsId })
                    .HasName("IX_RESULTID")
                    .IsUnique();

                entity.HasIndex(e => new { e.ResultsId, e.Dm1 })
                    .HasName("IX_DM");

                entity.Property(e => e.Dmid).HasColumnName("DMID");

                entity.Property(e => e.Dm1)
                    .HasColumnName("DM")
                    .HasColumnType("numeric(7, 3)");

                entity.Property(e => e.DmRes)
                    .HasColumnName("DM_Res")
                    .HasColumnType("numeric(6, 4)");

                entity.Property(e => e.Kfm)
                    .HasColumnName("KFM")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Moisture).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.HasOne(d => d.Results)
                    .WithMany(p => p.Dm)
                    .HasForeignKey(d => d.ResultsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DM_RESULTS");
            });

            modelBuilder.Entity<ElmahError>(entity =>
            {
                entity.HasKey(e => e.ErrorId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ELMAH_Error");

                entity.HasIndex(e => new { e.Application, e.TimeUtc, e.Sequence })
                    .HasName("IX_ELMAH_Error_App_Time_Seq");

                entity.Property(e => e.ErrorId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AllXml)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Application)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Sequence).ValueGeneratedOnAdd();

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.TimeUtc).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Emailsamplesdetails>(entity =>
            {
                entity.HasKey(e => e.SampleEmailId);

                entity.ToTable("EMAILSAMPLESDETAILS");

                entity.Property(e => e.SampleEmailId).HasColumnName("SampleEmailID");

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SampleContent).HasMaxLength(4000);

                entity.Property(e => e.SampleFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampleSubject)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SampleTo)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Emailsamplesmapdetails>(entity =>
            {
                entity.HasKey(e => e.SampleEmailMapId);

                entity.ToTable("EMAILSAMPLESMAPDETAILS");

                entity.Property(e => e.SampleEmailMapId).HasColumnName("SampleEmailMapID");

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SamplesId).HasColumnName("SamplesID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Energytype>(entity =>
            {
                entity.HasKey(e => e.EqTypeId);

                entity.ToTable("ENERGYTYPE");

                entity.HasIndex(e => new { e.EqTypeId, e.EqTypeCode })
                    .HasName("IX_EQTYPE")
                    .IsUnique();

                entity.Property(e => e.EqTypeId).HasColumnName("EqTypeID");

                entity.Property(e => e.EqTypeCode).HasMaxLength(6);

                entity.Property(e => e.EqTypeDescription).HasMaxLength(60);
            });

            modelBuilder.Entity<Failedimport>(entity =>
            {
                entity.ToTable("FAILEDIMPORT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");
            });

            modelBuilder.Entity<Failedresults>(entity =>
            {
                entity.ToTable("FAILEDRESULTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");
            });

            modelBuilder.Entity<Failedsamples>(entity =>
            {
                entity.ToTable("FAILEDSAMPLES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");
            });

            modelBuilder.Entity<FarmFeedCodes>(entity =>
            {
                entity.HasKey(e => e.FarmFeedId);

                entity.Property(e => e.FarmFeedType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsFarm).HasColumnName("isFarm");
            });

            modelBuilder.Entity<Fat>(entity =>
            {
                entity.ToTable("FAT");

                entity.HasIndex(e => new { e.FatEe, e.FatAh, e.Ffa, e.Tfa, e.C120, e.C140, e.C160, e.C161, e.C180, e.C181, e.C182, e.C183, e.OtherFa, e.C120Tfa, e.C140Tfa, e.C160Tfa, e.C161Tfa, e.C180Tfa, e.C181Tfa, e.C182Tfa, e.C183Tfa, e.OtherFaTfa, e.ResultsId })
                    .HasName("IX_RESULTID")
                    .IsUnique();

                entity.Property(e => e.FatId).HasColumnName("FatID");

                entity.Property(e => e.C100FinalRelativeCalc)
                    .HasColumnName("C100_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C100FinalSampleCalc)
                    .HasColumnName("C100_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C120FinalRelativeCalc)
                    .HasColumnName("C120_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120FinalSampleCalc)
                    .HasColumnName("C120_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120Tfa)
                    .HasColumnName("C120_TFA")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C140).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C140FinalRelativeCalc)
                    .HasColumnName("C140_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C140FinalSampleCalc)
                    .HasColumnName("C140_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C140Tfa)
                    .HasColumnName("C140_TFA")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C141FinalRelativeCalc)
                    .HasColumnName("C141_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C141FinalSampleCalc)
                    .HasColumnName("C141_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C150FinalRelativeCalc)
                    .HasColumnName("C150_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C150FinalSampleCalc)
                    .HasColumnName("C150_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C160FinalRelativeCalc)
                    .HasColumnName("C160_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160FinalSampleCalc)
                    .HasColumnName("C160_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160Tfa)
                    .HasColumnName("C160_TFA")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C161).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C161FinalRelativeCalc)
                    .HasColumnName("C161_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C161FinalSampleCalc)
                    .HasColumnName("C161_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C161Tfa)
                    .HasColumnName("C161_TFA")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C162FinalRelativeCalc)
                    .HasColumnName("C162_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C162FinalSampleCalc)
                    .HasColumnName("C162_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C163FinalRelativeCalc)
                    .HasColumnName("C163_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C163FinalSampleCalc)
                    .HasColumnName("C163_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C164FinalRelativeCalc)
                    .HasColumnName("C164_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C164FinalSampleCalc)
                    .HasColumnName("C164_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C170FinalRelativeCalc)
                    .HasColumnName("C170_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C170FinalSampleCalc)
                    .HasColumnName("C170_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C171FinalRelativeCalc)
                    .HasColumnName("C171_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C171FinalSampleCalc)
                    .HasColumnName("C171_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C180FinalRelativeCalc)
                    .HasColumnName("C180_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180FinalSampleCalc)
                    .HasColumnName("C180_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180Tfa)
                    .HasColumnName("C180_TFA")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C181).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C181FinalRelativeCalc)
                    .HasColumnName("C181_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181FinalSampleCalc)
                    .HasColumnName("C181_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181Tfa)
                    .HasColumnName("C181_TFA")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C181w7FinalRelativeCalc)
                    .HasColumnName("C181w7_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w7FinalSampleCalc)
                    .HasColumnName("C181w7_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w9FinalRelativeCalc)
                    .HasColumnName("C181w9_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w9FinalSampleCalc)
                    .HasColumnName("C181w9_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C182FinalRelativeCalc)
                    .HasColumnName("C182_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182FinalSampleCalc)
                    .HasColumnName("C182_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182Tfa)
                    .HasColumnName("C182_TFA")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C182w4FinalRelativeCalc)
                    .HasColumnName("C182w4_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w4FinalSampleCalc)
                    .HasColumnName("C182w4_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w6FinalRelativeCalc)
                    .HasColumnName("C182w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w6FinalSampleCalc)
                    .HasColumnName("C182w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C183FinalRelativeCalc)
                    .HasColumnName("C183_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183FinalSampleCalc)
                    .HasColumnName("C183_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183Tfa)
                    .HasColumnName("C183_TFA")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.C183w3FinalRelativeCalc)
                    .HasColumnName("C183w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w3FinalSampleCalc)
                    .HasColumnName("C183w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w6FinalRelativeCalc)
                    .HasColumnName("C183w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w6FinalSampleCalc)
                    .HasColumnName("C183w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C184w3FinalRelativeCalc)
                    .HasColumnName("C184w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C184w3FinalSampleCalc)
                    .HasColumnName("C184w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C200FinalRelativeCalc)
                    .HasColumnName("C200_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C200FinalSampleCalc)
                    .HasColumnName("C200_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w7FinalRelativeCalc)
                    .HasColumnName("C201w7_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w7FinalSampleCalc)
                    .HasColumnName("C201w7_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w9FinalRelativeCalc)
                    .HasColumnName("C201w9_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w9FinalSampleCalc)
                    .HasColumnName("C201w9_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C2021114FinalRelativeCalc)
                    .HasColumnName("C2021114_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C2021114FinalSampleCalc)
                    .HasColumnName("C2021114_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C202w6FinalRelativeCalc)
                    .HasColumnName("C202w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C202w6FinalSampleCalc)
                    .HasColumnName("C202w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w3FinalRelativeCalc)
                    .HasColumnName("C203w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w3FinalSampleCalc)
                    .HasColumnName("C203w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w6FinalRelativeCalc)
                    .HasColumnName("C203w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w6FinalSampleCalc)
                    .HasColumnName("C203w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w3FinalRelativeCalc)
                    .HasColumnName("C204w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w3FinalSampleCalc)
                    .HasColumnName("C204w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w6FinalRelativeCalc)
                    .HasColumnName("C204w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w6FinalSampleCalc)
                    .HasColumnName("C204w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C205w3FinalRelativeCalc)
                    .HasColumnName("C205w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C205w3FinalSampleCalc)
                    .HasColumnName("C205w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C215w3FinalRelativeCalc)
                    .HasColumnName("C215w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C215w3FinalSampleCalc)
                    .HasColumnName("C215w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C220FinalRelativeCalc)
                    .HasColumnName("C220_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C220FinalSampleCalc)
                    .HasColumnName("C220_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C22111FinalRelativeCalc)
                    .HasColumnName("C22111_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C22111FinalSampleCalc)
                    .HasColumnName("C22111_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221FinalRelativeCalc)
                    .HasColumnName("C221_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221FinalSampleCalc)
                    .HasColumnName("C221_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221w9FinalRelativeCalc)
                    .HasColumnName("C221w9_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221w9FinalSampleCalc)
                    .HasColumnName("C221w9_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w3FinalRelativeCalc)
                    .HasColumnName("C225w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w3FinalSampleCalc)
                    .HasColumnName("C225w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w6FinalRelativeCalc)
                    .HasColumnName("C225w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w6FinalSampleCalc)
                    .HasColumnName("C225w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C226w3FinalRelativeCalc)
                    .HasColumnName("C226w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C226w3FinalSampleCalc)
                    .HasColumnName("C226w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C240FinalRelativeCalc)
                    .HasColumnName("C240_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C240FinalSampleCalc)
                    .HasColumnName("C240_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C241FinalRelativeCalc)
                    .HasColumnName("C241_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C241FinalSampleCalc)
                    .HasColumnName("C241_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C60FinalRelativeCalc)
                    .HasColumnName("C60_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C60FinalSampleCalc)
                    .HasColumnName("C60_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C80FinalRelativeCalc)
                    .HasColumnName("C80_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C80FinalSampleCalc)
                    .HasColumnName("C80_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.FatAh)
                    .HasColumnName("Fat_AH")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.FatEe)
                    .HasColumnName("Fat_EE")
                    .HasColumnType("numeric(6, 3)");

                entity.Property(e => e.Ffa)
                    .HasColumnName("FFA")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.OtherFa)
                    .HasColumnName("OtherFA")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.OtherFaTfa)
                    .HasColumnName("OtherFA_TFA")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.OtherFinalRelativeCalc)
                    .HasColumnName("Other_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.OtherFinalSampleCalc)
                    .HasColumnName("Other_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.Property(e => e.Tfa)
                    .HasColumnName("TFA")
                    .HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<Feedcodes>(entity =>
            {
                entity.HasKey(e => e.FeedCodeId);

                entity.ToTable("FEEDCODES");

                entity.HasIndex(e => new { e.FeedCode, e.FeedType, e.Designator })
                    .HasName("IX_DESIGNATOR");

                entity.Property(e => e.FeedCodeId).HasColumnName("FeedCodeID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Designator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeedCode).HasColumnName("Feed_Code");

                entity.Property(e => e.FeedType)
                    .HasColumnName("Feed_Type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralClass)
                    .HasColumnName("General_Class")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FeedTypeAvgStdDev>(entity =>
            {
                entity.HasKey(e => e.FeedTypeAvgId);

                entity.Property(e => e.FeedTypeAvgId).HasColumnName("FeedTypeAvgID");

                entity.Property(e => e.Avg30M120)
                    .HasColumnName("Avg_30_m120")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.AvgM120240)
                    .HasColumnName("Avg_m120_240")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.FeedType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StdDev30M120)
                    .HasColumnName("StdDev_30_m120")
                    .HasColumnType("decimal(10, 6)");

                entity.Property(e => e.StdDevM120240)
                    .HasColumnName("StdDev_m120_240")
                    .HasColumnType("decimal(10, 6)");
            });

            modelBuilder.Entity<Fermentation>(entity =>
            {
                entity.ToTable("FERMENTATION");

                entity.HasIndex(e => new { e.Acetic, e.Propionic, e.Butyric, e.Lactic, e.IsoButyric, e.TotVfa, e.TitAc, e.ResultsId })
                    .HasName("_dta_index_FERMENTATION_8_1472724299__K2_3_4_5_6_10_21_22")
                    .IsUnique();

                entity.HasIndex(e => new { e.Acetic, e.Propionic, e.Butyric, e.Lactic, e.IsoValeric, e.PropylLactate, e.TotVfa, e.TitAc, e.Ethanol, e.Butanol2, e.MethylAcetate, e.EthylAcetate, e.PropylAcetate, e.EthylLactate, e.Valeric, e.Caproic, e.IsoButyric, e.Propanediol12, e.Propanol1, e.Methanol, e.ResultsId })
                    .HasName("IX_RESULTID")
                    .IsUnique();

                entity.Property(e => e.FermentationId).HasColumnName("FermentationID");

                entity.Property(e => e.Acetic).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Butanol2)
                    .HasColumnName("Butanol_2")
                    .HasColumnType("numeric(5, 3)");

                entity.Property(e => e.Butyric).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Caproic).HasColumnType("numeric(5, 3)");

                entity.Property(e => e.Ethanol).HasColumnType("numeric(5, 3)");

                entity.Property(e => e.EthylAcetate)
                    .HasColumnName("Ethyl_acetate")
                    .HasColumnType("numeric(5, 3)");

                entity.Property(e => e.EthylLactate)
                    .HasColumnName("Ethyl_lactate")
                    .HasColumnType("numeric(5, 3)");

                entity.Property(e => e.IsoButyric)
                    .HasColumnName("Iso_butyric")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.IsoValeric)
                    .HasColumnName("Iso_valeric")
                    .HasColumnType("numeric(5, 3)");

                entity.Property(e => e.Lactic).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Methanol).HasColumnType("numeric(5, 3)");

                entity.Property(e => e.MethylAcetate)
                    .HasColumnName("Methyl_acetate")
                    .HasColumnType("numeric(5, 3)");

                entity.Property(e => e.Propanediol12)
                    .HasColumnName("Propanediol_12")
                    .HasColumnType("numeric(5, 3)");

                entity.Property(e => e.Propanol1)
                    .HasColumnName("Propanol_1")
                    .HasColumnType("numeric(5, 3)");

                entity.Property(e => e.Propionic).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.PropylAcetate)
                    .HasColumnName("Propyl_acetate")
                    .HasColumnType("numeric(5, 3)");

                entity.Property(e => e.PropylLactate)
                    .HasColumnName("Propyl_lactate")
                    .HasColumnType("numeric(5, 3)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.Property(e => e.TitAc)
                    .HasColumnName("Tit_AC")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.TotVfa)
                    .HasColumnName("TotVFA")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Valeric).HasColumnType("numeric(5, 3)");

                entity.HasOne(d => d.Results)
                    .WithMany(p => p.Fermentation)
                    .HasForeignKey(d => d.ResultsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FERMENTATION_RESULTS");
            });

            modelBuilder.Entity<Fertilization>(entity =>
            {
                entity.ToTable("FERTILIZATION");

                entity.Property(e => e.FertilizationId).HasColumnName("FertilizationID");

                entity.Property(e => e.Cname)
                    .HasColumnName("CName")
                    .HasMaxLength(50);

                entity.Property(e => e.Cvalue)
                    .HasColumnName("CValue")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Fibers>(entity =>
            {
                entity.ToTable("FIBERS");

                entity.HasIndex(e => new { e.SolFiber, e.Adf, e.Adfom, e.Ndf, e.ANdf, e.ANdfom, e.Ndr, e.ANdr, e.Ndrom, e.ANdrom, e.Cf, e.PeNdfNdf, e.Lignin, e.ResultsId })
                    .HasName("IX_RESULTID")
                    .IsUnique();

                entity.Property(e => e.FibersId).HasColumnName("FibersID");

                entity.Property(e => e.ANdf)
                    .HasColumnName("aNDF")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.ANdfom)
                    .HasColumnName("aNDFom")
                    .HasColumnType("numeric(6, 3)");

                entity.Property(e => e.ANdr)
                    .HasColumnName("aNDR")
                    .HasColumnType("numeric(6, 3)");

                entity.Property(e => e.ANdrom)
                    .HasColumnName("aNDRom")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Adf)
                    .HasColumnName("ADF")
                    .HasColumnType("numeric(6, 3)");

                entity.Property(e => e.Adfom)
                    .HasColumnName("ADFom")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Cf)
                    .HasColumnName("CF")
                    .HasColumnType("numeric(6, 3)");

                entity.Property(e => e.Lignin).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.Ndf)
                    .HasColumnName("NDF")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ndr)
                    .HasColumnName("NDR")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ndrom)
                    .HasColumnName("NDRom")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.PeNdfNdf)
                    .HasColumnName("peNDF_NDF")
                    .HasColumnType("numeric(6, 3)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.Property(e => e.SolFiber)
                    .HasColumnName("Sol_Fiber")
                    .HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<FinalResults>(entity =>
            {
                entity.HasKey(e => e.FinalResultId);

                entity.Property(e => e.ANdfom)
                    .HasColumnName("aNDFom")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AampsscdegradabilityDm)
                    .HasColumnName("AAMPSSCDegradability_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AampsscdegradabilityNdf)
                    .HasColumnName("AAMPSSCDegradability_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AceticAcid).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AcidDetergentFiberDm)
                    .HasColumnName("AcidDetergentFiber_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AcidDetergentFiberNdf)
                    .HasColumnName("AcidDetergentFiber_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AcidHydrolysisFatDm)
                    .HasColumnName("AcidHydrolysisFat_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AdfproteinAdicpCp)
                    .HasColumnName("ADFProteinADICP_CP")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AdfproteinAdicpDm)
                    .HasColumnName("ADFProteinADICP_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AdjustedNel)
                    .HasColumnName("AdjustedNEL")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AdjustedProteinCp)
                    .HasColumnName("AdjustedProtein_CP")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AdjustedProteinDm)
                    .HasColumnName("AdjustedProtein_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Aflat)
                    .HasColumnName("AFLAT")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AmmoniaCp)
                    .HasColumnName("Ammonia_CP")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AmmoniaDm)
                    .HasColumnName("Ammonia_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AmmoniaSp)
                    .HasColumnName("Ammonia_SP")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ash).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Atox).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AtoxB1).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AtoxB1nonDetect)
                    .HasColumnName("AtoxB1NonDetect")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AtoxB2).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AtoxB2nonDetect)
                    .HasColumnName("AtoxB2NonDetect")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AtoxG1).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AtoxG1nonDetect)
                    .HasColumnName("AtoxG1NonDetect")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AtoxG2).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.AtoxG2nonDetect)
                    .HasColumnName("AtoxG2NonDetect")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.B2b3kdHrDm)
                    .HasColumnName("B2B3KdHR_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.B2b3kdHrNdf)
                    .HasColumnName("B2B3KdHR_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Butanol2).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ButyricAcid).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Calcium).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Chloride).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.CncpscpmligninFactor)
                    .HasColumnName("CNCPSCPMLigninFactor")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Copper).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.CornSilageProcessingScore).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.CrudeFatDm)
                    .HasColumnName("CrudeFat_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.CrudeFiberDm)
                    .HasColumnName("CrudeFiber_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.CrudeFiberNdf)
                    .HasColumnName("CrudeFiber_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.CrudeProteinDm)
                    .HasColumnName("CrudeProtein_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Dcad)
                    .HasColumnName("DCAD")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DigOrganicMatterIndex).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DigestibleDryMatterFastDm)
                    .HasColumnName("DigestibleDryMatter_Fast_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Don15Ac).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Don15AcNonDetect).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Don3Ac).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Don3AcNonDetect).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DonMethod).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DryMatter).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.EstimatedBushellTon).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ethanol).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.EthanolSolubleChosugarDm)
                    .HasColumnName("EthanolSolubleCHOSugar_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.EthanolSolubleChosugarNfc)
                    .HasColumnName("EthanolSolubleCHOSugar_NFC")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.EthylLactate).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.FatAh)
                    .HasColumnName("Fat_AH")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.FatEe)
                    .HasColumnName("Fat_EE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.FattyAcidsCrudeFat)
                    .HasColumnName("FattyAcids_CrudeFat")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.FattyAcidsTotalDm)
                    .HasColumnName("FattyAcidsTotal_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.FtoxB1).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.FtoxB1nonDetect)
                    .HasColumnName("FtoxB1NonDetect")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.FtoxB2).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.FtoxB2nonDetect)
                    .HasColumnName("FtoxB2NonDetect")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.FtoxB3).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.FtoxB3nonDetect)
                    .HasColumnName("FtoxB3NonDetect")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.HorseDe)
                    .HasColumnName("HorseDE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.HorseTdn)
                    .HasColumnName("HorseTDN")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ht2).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ht2NonDetect).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ifvalue)
                    .HasColumnName("IFValue")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ImoldId).HasColumnName("IMoldId");

                entity.Property(e => e.IndigestibleNdfinvitro120Dm)
                    .HasColumnName("IndigestibleNDFInvitro120_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.IndigestibleNdfinvitro120Ndf)
                    .HasColumnName("IndigestibleNDFInvitro120_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.IndigestibleNdfinvitro30Dm)
                    .HasColumnName("IndigestibleNDFInvitro30_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.IndigestibleNdfinvitro30Ndf)
                    .HasColumnName("IndigestibleNDFInvitro30_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Iron).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.LacticAcid).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.LacticTotalVfa)
                    .HasColumnName("LacticTotalVFA")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.LigninDm)
                    .HasColumnName("Lignin_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.LigninNdf)
                    .HasColumnName("Lignin_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Lurease)
                    .HasColumnName("LUREASE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Magnesium).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Manganese).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Me)
                    .HasColumnName("ME")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Methanol).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.MethylAcetate).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.MilkPerTon).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Moisture).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.MoldCount).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Molybdenum).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ndf12hrdigestibilityDm)
                    .HasColumnName("NDF12HRDigestibility_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ndf12hrdigestibilityNdf)
                    .HasColumnName("NDF12HRDigestibility_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ndf240hrdigestibilityDm)
                    .HasColumnName("NDF240HRDigestibility_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ndf240hrdigestibilityNdf)
                    .HasColumnName("NDF240HRDigestibility_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ndf24hrdigestibilityDm)
                    .HasColumnName("NDF24HRDigestibility_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ndf24hrdigestibilityNdf)
                    .HasColumnName("NDF24HRDigestibility_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ndf30hrdigestibilityDm)
                    .HasColumnName("NDF30HRDigestibility_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ndf30hrdigestibilityNdf)
                    .HasColumnName("NDF30HRDigestibility_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ndf48hrdigestibilityDm)
                    .HasColumnName("NDF48HRDigestibility_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ndf48hrdigestibilityNdf)
                    .HasColumnName("NDF48HRDigestibility_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ndfd120Dm)
                    .HasColumnName("NDFD120_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ndfd120Ndf)
                    .HasColumnName("NDFD120_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NdfdigRateMertensDm)
                    .HasColumnName("NDFDigRateMertens_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NdfdigRateMertensNdf)
                    .HasColumnName("NDFDigRateMertens_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NdfdigRateVanAmburghDm)
                    .HasColumnName("NDFDigRateVanAmburgh_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NdfdigRateVanAmburghINdf)
                    .HasColumnName("NDFDigRateVanAmburgh_iNDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NdfdigRateVanAmburghLignin)
                    .HasColumnName("NDFDigRateVanAmburgh_Lignin")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NdfdigRateVanAmburghNdf)
                    .HasColumnName("NDFDigRateVanAmburgh_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NdfproteinNdicpCp)
                    .HasColumnName("NDFProteinNDICP_CP")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NdfproteinNdicpDm)
                    .HasColumnName("NDFProteinNDICP_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NdrDm)
                    .HasColumnName("NDR_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NdrNdf)
                    .HasColumnName("NDR_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NdrcpCp)
                    .HasColumnName("NDRCP_CP")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NdrcpDm)
                    .HasColumnName("NDRCP_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Nelndfdadjustment)
                    .HasColumnName("NELNDFDAdjustment")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NetEnergyGain).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NetEnergyLactation).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NetEnergyMaintenance).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NeutralDetergentFiberDm)
                    .HasColumnName("NeutralDetergentFiber_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NirstatisticalConfidence)
                    .HasColumnName("NIRStatisticalConfidence")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NitrateIon).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NitrateProbability).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NonFiberCarbohydrates).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NonStructuralCarbohydrates).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NutrecoStatus).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ochratoxin).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.OchratoxinNonDetect).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.OwensNeg)
                    .HasColumnName("OwensNEG")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.OwensNem)
                    .HasColumnName("OwensNEM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.OwensTdn)
                    .HasColumnName("OwensTDN")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.OwnesNel)
                    .HasColumnName("OwnesNEL")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PH)
                    .HasColumnName("pH")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PackageName).HasMaxLength(50);

                entity.Property(e => e.ParticlesF031075).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ParticlesGt075)
                    .HasColumnName("ParticlesGT075")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ParticlesLt031)
                    .HasColumnName("ParticlesLT031")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Pdvalue)
                    .HasColumnName("PDValue")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PeNdfDm)
                    .HasColumnName("peNDF_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PeNdfNdf)
                    .HasColumnName("peNDF_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Phosphorus).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Potassium).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Propanol1).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Propendiol12).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PropionicAcid).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PropylAcetate).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PropylLactate).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ProteinDispersibilityIndex).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ps1)
                    .HasColumnName("PS1")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ps2)
                    .HasColumnName("PS2")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ps3)
                    .HasColumnName("PS3")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ps4)
                    .HasColumnName("PS4")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Psaverage)
                    .HasColumnName("PSAverage")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Pscumulative1)
                    .HasColumnName("PSCumulative1")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Pscumulative2)
                    .HasColumnName("PSCumulative2")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Pscumulative3)
                    .HasColumnName("PSCumulative3")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PsstdDev)
                    .HasColumnName("PSStdDev")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.RelativeFeedQuality).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.RelativeFeedValue).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.RumenDegCpstrepGCp)
                    .HasColumnName("RumenDegCPStrepG_CP")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.RumenDegCpstrepGDm)
                    .HasColumnName("RumenDegCPStrepG_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.RumenDegrProteinCp)
                    .HasColumnName("RumenDegrProtein_CP")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.RumenDegrProteinDm)
                    .HasColumnName("RumenDegrProtein_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.RumenUndegrProteinCp)
                    .HasColumnName("RumenUndegrProtein_CP")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.RumenUndegrProteinDm)
                    .HasColumnName("RumenUndegrProtein_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.SaturatedFattyAcids).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.SchwabShaverNelprocessed)
                    .HasColumnName("SchwabShaverNELProcessed")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.SchwabShaverNelunprocessed)
                    .HasColumnName("SchwabShaverNELUnprocessed")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Selenium).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.SilageAcidsDm)
                    .HasColumnName("SilageAcids_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.SilageAcidsNfc)
                    .HasColumnName("SilageAcids_NFC")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Sodium).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.SoilContaminationProbability).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.SolubleFiberDm)
                    .HasColumnName("SolubleFiber_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.SolubleFiberNfc)
                    .HasColumnName("SolubleFiber_NFC")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.SolubleProteinCp)
                    .HasColumnName("SolubleProtein_CP")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.SolubleProteinDm)
                    .HasColumnName("SolubleProtein_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.StarchDigestibility7HrDm)
                    .HasColumnName("StarchDigestibility7HR_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.StarchDigestibility7HrNfc)
                    .HasColumnName("StarchDigestibility7HR_NFC")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.StarchDm)
                    .HasColumnName("Starch_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.StarchMertensDm)
                    .HasColumnName("StarchMertens_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.StarchMertensNfc)
                    .HasColumnName("StarchMertens_NFC")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.StarchNfc)
                    .HasColumnName("Starch_NFC")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Sulfur).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.SummativeIndex).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.T2tox)
                    .HasColumnName("T2Tox")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.T2toxNonDetect)
                    .HasColumnName("T2ToxNonDetect")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Tdn)
                    .HasColumnName("TDN")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.TitratableAcidity).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.TotalVfa)
                    .HasColumnName("TotalVFA")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.UNdfd120Dm)
                    .HasColumnName("uNDFD120_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.UNdfd120Ndf)
                    .HasColumnName("uNDFD120_NDF")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.UnsaturatedFattyAcids).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.UreaseActivity).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Vomitoxin).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.VomitoxinNonDetect).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.VomitoxinProbability).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.WaterSolubleChosugarDm)
                    .HasColumnName("WaterSolubleCHOSugar_DM")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.WaterSolubleChosugarNfc)
                    .HasColumnName("WaterSolubleCHOSugar_NFC")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.YeastCount).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Zinc).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ztox).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ZtoxNonDetect).HasColumnType("decimal(6, 2)");
            });

            modelBuilder.Entity<IAnDfom>(entity =>
            {
                entity.ToTable("I_anDFom");

                entity.Property(e => e.IanDfomId).HasColumnName("IanDFomID");

                entity.Property(e => e.ANdfom)
                    .HasColumnName("aNDFom")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IaNdf)
                    .HasColumnName("IaNDF")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ICsps>(entity =>
            {
                entity.HasKey(e => e.Cspsid);

                entity.ToTable("I_CSPS");

                entity.Property(e => e.Cspsid).HasColumnName("CSPSID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Coarse).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.CoarsePercentage).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Csps)
                    .HasColumnName("CSPS")
                    .HasColumnType("decimal(5, 3)");

                entity.Property(e => e.Fine).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.FinePercentage).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Medium).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.MediumPercentage).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NirstarchCoarse)
                    .HasColumnName("NIRStarchCoarse")
                    .HasColumnType("decimal(5, 1)");

                entity.Property(e => e.PanWeight).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.SampleStarch).HasColumnType("decimal(5, 1)");
            });

            modelBuilder.Entity<IFattyacid>(entity =>
            {
                entity.ToTable("I_FATTYACID");

                entity.Property(e => e.IfattyAcidId).HasColumnName("IfattyAcidID");

                entity.Property(e => e.AdjustByHygro).HasColumnName("Adjust_By_Hygro");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.C100FinalRelativeCalc)
                    .HasColumnName("C100_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C100FinalSampleCalc)
                    .HasColumnName("C100_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C100calcRaw1)
                    .HasColumnName("C10_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C100calcRaw2)
                    .HasColumnName("C10_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C100relativeRaw1)
                    .HasColumnName("C10_0RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C100relativeRaw2)
                    .HasColumnName("C10_0RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C100sampleRaw1)
                    .HasColumnName("C10_0SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C100sampleRaw2)
                    .HasColumnName("C10_0SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C100userOverride).HasColumnName("C10_0UserOverride");

                entity.Property(e => e.C120FinalRelativeCalc)
                    .HasColumnName("C120_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120FinalSampleCalc)
                    .HasColumnName("C120_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120calcRaw1)
                    .HasColumnName("C12_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120calcRaw2)
                    .HasColumnName("C12_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120relativeRaw1)
                    .HasColumnName("C12_0RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120relativeRaw2)
                    .HasColumnName("C12_0RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120sampleRaw1)
                    .HasColumnName("C12_0SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120sampleRaw2)
                    .HasColumnName("C12_0SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120userOverride).HasColumnName("C12_0UserOverride");

                entity.Property(e => e.C140FinalRelativeCalc)
                    .HasColumnName("C140_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C140FinalSampleCalc)
                    .HasColumnName("C140_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C140calcRaw1)
                    .HasColumnName("C14_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C140calcRaw2)
                    .HasColumnName("C14_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C140relativeRaw1)
                    .HasColumnName("C14_0RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C140relativeRaw2)
                    .HasColumnName("C14_0RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C140sampleRaw1)
                    .HasColumnName("C14_0SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C140sampleRaw2)
                    .HasColumnName("C14_0SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C140userOverride).HasColumnName("C14_0UserOverride");

                entity.Property(e => e.C141FinalRelativeCalc)
                    .HasColumnName("C141_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C141FinalSampleCalc)
                    .HasColumnName("C141_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C141calcRaw1)
                    .HasColumnName("C14_1CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C141calcRaw2)
                    .HasColumnName("C14_1CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C141relativeRaw1)
                    .HasColumnName("C14_1RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C141relativeRaw2)
                    .HasColumnName("C14_1RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C141sampleRaw1)
                    .HasColumnName("C14_1SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C141sampleRaw2)
                    .HasColumnName("C14_1SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C141userOverride).HasColumnName("C14_1UserOverride");

                entity.Property(e => e.C150FinalRelativeCalc)
                    .HasColumnName("C150_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C150FinalSampleCalc)
                    .HasColumnName("C150_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C150calcRaw1)
                    .HasColumnName("C15_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C150calcRaw2)
                    .HasColumnName("C15_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C150relativeRaw1)
                    .HasColumnName("C15_0RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C150relativeRaw2)
                    .HasColumnName("C15_0RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C150sampleRaw1)
                    .HasColumnName("C15_0SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C150sampleRaw2)
                    .HasColumnName("C15_0SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C150userOverride).HasColumnName("C15_0UserOverride");

                entity.Property(e => e.C160FinalRelativeCalc)
                    .HasColumnName("C160_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160FinalSampleCalc)
                    .HasColumnName("C160_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160calcRaw1)
                    .HasColumnName("C16_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160calcRaw2)
                    .HasColumnName("C16_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160relativeRaw1)
                    .HasColumnName("C16_0RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160relativeRaw2)
                    .HasColumnName("C16_0RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160sampleRaw1)
                    .HasColumnName("C16_0SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160sampleRaw2)
                    .HasColumnName("C16_0SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160userOverride).HasColumnName("C16_0UserOverride");

                entity.Property(e => e.C161FinalRelativeCalc)
                    .HasColumnName("C161_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C161FinalSampleCalc)
                    .HasColumnName("C161_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C161calcRaw1)
                    .HasColumnName("C16_1CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C161calcRaw2)
                    .HasColumnName("C16_1CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C161relativeRaw1)
                    .HasColumnName("C16_1RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C161relativeRaw2)
                    .HasColumnName("C16_1RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C161sampleRaw1)
                    .HasColumnName("C16_1SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C161sampleRaw2)
                    .HasColumnName("C16_1SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C161userOverride).HasColumnName("C16_1UserOverride");

                entity.Property(e => e.C162FinalRelativeCalc)
                    .HasColumnName("C162_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C162FinalSampleCalc)
                    .HasColumnName("C162_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C162calcRaw1)
                    .HasColumnName("C16_2CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C162calcRaw2)
                    .HasColumnName("C16_2CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C162relativeRaw1)
                    .HasColumnName("C16_2RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C162relativeRaw2)
                    .HasColumnName("C16_2RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C162sampleRaw1)
                    .HasColumnName("C16_2SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C162sampleRaw2)
                    .HasColumnName("C16_2SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C162userOverride).HasColumnName("C16_2UserOverride");

                entity.Property(e => e.C163FinalRelativeCalc)
                    .HasColumnName("C163_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C163FinalSampleCalc)
                    .HasColumnName("C163_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C163calcRaw1)
                    .HasColumnName("C16_3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C163calcRaw2)
                    .HasColumnName("C16_3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C163relativeRaw1)
                    .HasColumnName("C16_3RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C163relativeRaw2)
                    .HasColumnName("C16_3RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C163sampleRaw1)
                    .HasColumnName("C16_3SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C163sampleRaw2)
                    .HasColumnName("C16_3SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C163userOverride).HasColumnName("C16_3UserOverride");

                entity.Property(e => e.C164FinalRelativeCalc)
                    .HasColumnName("C164_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C164FinalSampleCalc)
                    .HasColumnName("C164_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C164calcRaw1)
                    .HasColumnName("C16_4CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C164calcRaw2)
                    .HasColumnName("C16_4CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C164relativeRaw1)
                    .HasColumnName("C16_4RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C164relativeRaw2)
                    .HasColumnName("C16_4RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C164sampleRaw1)
                    .HasColumnName("C16_4SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C164sampleRaw2)
                    .HasColumnName("C16_4SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C164userOverride).HasColumnName("C16_4UserOverride");

                entity.Property(e => e.C170FinalRelativeCalc)
                    .HasColumnName("C170_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C170FinalSampleCalc)
                    .HasColumnName("C170_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C170calcRaw1)
                    .HasColumnName("C17_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C170calcRaw2)
                    .HasColumnName("C17_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C170relativeRaw1)
                    .HasColumnName("C17_0RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C170relativeRaw2)
                    .HasColumnName("C17_0RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C170sampleRaw1)
                    .HasColumnName("C17_0SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C170sampleRaw2)
                    .HasColumnName("C17_0SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C170userOverride).HasColumnName("C17_0UserOverride");

                entity.Property(e => e.C171FinalRelativeCalc)
                    .HasColumnName("C171_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C171FinalSampleCalc)
                    .HasColumnName("C171_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C171calcRaw1)
                    .HasColumnName("C17_1CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C171calcRaw2)
                    .HasColumnName("C17_1CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C171relativeRaw1)
                    .HasColumnName("C17_1RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C171relativeRaw2)
                    .HasColumnName("C17_1RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C171sampleRaw1)
                    .HasColumnName("C17_1SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C171sampleRaw2)
                    .HasColumnName("C17_1SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C171userOverride).HasColumnName("C17_1UserOverride");

                entity.Property(e => e.C180FinalRelativeCalc)
                    .HasColumnName("C180_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180FinalSampleCalc)
                    .HasColumnName("C180_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180calcRaw1)
                    .HasColumnName("C18_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180calcRaw2)
                    .HasColumnName("C18_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180relativeRaw1)
                    .HasColumnName("C18_0RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180relativeRaw2)
                    .HasColumnName("C18_0RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180sampleRaw1)
                    .HasColumnName("C18_0SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180sampleRaw2)
                    .HasColumnName("C18_0SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180userOverride).HasColumnName("C18_0UserOverride");

                entity.Property(e => e.C181FinalRelativeCalc)
                    .HasColumnName("C181_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181FinalSampleCalc)
                    .HasColumnName("C181_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181calcRaw1)
                    .HasColumnName("C18_1CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181calcRaw2)
                    .HasColumnName("C18_1CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181relativeRaw1)
                    .HasColumnName("C18_1RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181relativeRaw2)
                    .HasColumnName("C18_1RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181sampleRaw1)
                    .HasColumnName("C18_1SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181sampleRaw2)
                    .HasColumnName("C18_1SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181userOverride).HasColumnName("C18_1UserOverride");

                entity.Property(e => e.C181w7CalcRaw1)
                    .HasColumnName("C18_1w7CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w7CalcRaw2)
                    .HasColumnName("C18_1w7CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w7FinalRelativeCalc)
                    .HasColumnName("C181w7_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w7FinalSampleCalc)
                    .HasColumnName("C181w7_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w7RelativeRaw1)
                    .HasColumnName("C18_1w7RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w7RelativeRaw2)
                    .HasColumnName("C18_1w7RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w7SampleRaw1)
                    .HasColumnName("C18_1w7SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w7SampleRaw2)
                    .HasColumnName("C18_1w7SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w7UserOverride).HasColumnName("C18_1w7UserOverride");

                entity.Property(e => e.C181w9CalcRaw1)
                    .HasColumnName("C18_1w9CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w9CalcRaw2)
                    .HasColumnName("C18_1w9CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w9FinalRelativeCalc)
                    .HasColumnName("C181w9_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w9FinalSampleCalc)
                    .HasColumnName("C181w9_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w9RelativeRaw1)
                    .HasColumnName("C18_1w9RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w9RelativeRaw2)
                    .HasColumnName("C18_1w9RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w9SampleRaw1)
                    .HasColumnName("C18_1w9SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w9SampleRaw2)
                    .HasColumnName("C18_1w9SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w9UserOverride).HasColumnName("C18_1w9UserOverride");

                entity.Property(e => e.C182FinalRelativeCalc)
                    .HasColumnName("C182_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182FinalSampleCalc)
                    .HasColumnName("C182_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182calcRaw1)
                    .HasColumnName("C18_2CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182calcRaw2)
                    .HasColumnName("C18_2CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182relativeRaw1)
                    .HasColumnName("C18_2RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182relativeRaw2)
                    .HasColumnName("C18_2RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182sampleRaw1)
                    .HasColumnName("C18_2SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182sampleRaw2)
                    .HasColumnName("C18_2SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182userOverride).HasColumnName("C18_2UserOverride");

                entity.Property(e => e.C182w4CalcRaw1)
                    .HasColumnName("C18_2w4CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w4CalcRaw2)
                    .HasColumnName("C18_2w4CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w4FinalRelativeCalc)
                    .HasColumnName("C182w4_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w4FinalSampleCalc)
                    .HasColumnName("C182w4_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w4RelativeRaw1)
                    .HasColumnName("C18_2w4RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w4RelativeRaw2)
                    .HasColumnName("C18_2w4RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w4SampleRaw1)
                    .HasColumnName("C18_2w4SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w4SampleRaw2)
                    .HasColumnName("C18_2w4SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w4UserOverride).HasColumnName("C18_2w4UserOverride");

                entity.Property(e => e.C182w6CalcRaw1)
                    .HasColumnName("C18_2w6CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w6CalcRaw2)
                    .HasColumnName("C18_2w6CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w6FinalRelativeCalc)
                    .HasColumnName("C182w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w6FinalSampleCalc)
                    .HasColumnName("C182w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w6RelativeRaw1)
                    .HasColumnName("C18_2w6RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w6RelativeRaw2)
                    .HasColumnName("C18_2w6RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w6SampleRaw1)
                    .HasColumnName("C18_2w6SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w6SampleRaw2)
                    .HasColumnName("C18_2w6SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w6UserOverride).HasColumnName("C18_2w6UserOverride");

                entity.Property(e => e.C183FinalRelativeCalc)
                    .HasColumnName("C183_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183FinalSampleCalc)
                    .HasColumnName("C183_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183calcRaw1)
                    .HasColumnName("C18_3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183calcRaw2)
                    .HasColumnName("C18_3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183relativeRaw1)
                    .HasColumnName("C18_3RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183relativeRaw2)
                    .HasColumnName("C18_3RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183sampleRaw1)
                    .HasColumnName("C18_3SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183sampleRaw2)
                    .HasColumnName("C18_3SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183userOverride).HasColumnName("C18_3UserOverride");

                entity.Property(e => e.C183w3CalcRaw1)
                    .HasColumnName("C18_3w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w3CalcRaw2)
                    .HasColumnName("C18_3w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w3FinalRelativeCalc)
                    .HasColumnName("C183w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w3FinalSampleCalc)
                    .HasColumnName("C183w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w3RelativeRaw1)
                    .HasColumnName("C18_3w3RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w3RelativeRaw2)
                    .HasColumnName("C18_3w3RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w3SampleRaw1)
                    .HasColumnName("C18_3w3SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w3SampleRaw2)
                    .HasColumnName("C18_3w3SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w3UserOverride).HasColumnName("C18_3w3UserOverride");

                entity.Property(e => e.C183w6CalcRaw1)
                    .HasColumnName("C18_3w6CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w6CalcRaw2)
                    .HasColumnName("C18_3w6CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w6FinalRelativeCalc)
                    .HasColumnName("C183w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w6FinalSampleCalc)
                    .HasColumnName("C183w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w6RelativeRaw1)
                    .HasColumnName("C18_3w6RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w6RelativeRaw2)
                    .HasColumnName("C18_3w6RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w6SampleRaw1)
                    .HasColumnName("C18_3w6SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w6SampleRaw2)
                    .HasColumnName("C18_3w6SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w6UserOverride).HasColumnName("C18_3w6UserOverride");

                entity.Property(e => e.C184w3CalcRaw1)
                    .HasColumnName("C18_4w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C184w3CalcRaw2)
                    .HasColumnName("C18_4w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C184w3FinalRelativeCalc)
                    .HasColumnName("C184w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C184w3FinalSampleCalc)
                    .HasColumnName("C184w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C184w3RelativeRaw1)
                    .HasColumnName("C18_4w3RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C184w3RelativeRaw2)
                    .HasColumnName("C18_4w3RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C184w3SampleRaw1)
                    .HasColumnName("C18_4w3SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C184w3SampleRaw2)
                    .HasColumnName("C18_4w3SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C184w3UserOverride).HasColumnName("C18_4w3UserOverride");

                entity.Property(e => e.C200FinalRelativeCalc)
                    .HasColumnName("C200_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C200FinalSampleCalc)
                    .HasColumnName("C200_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C200calcRaw1)
                    .HasColumnName("C20_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C200calcRaw2)
                    .HasColumnName("C20_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C200relativeRaw1)
                    .HasColumnName("C20_0RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C200relativeRaw2)
                    .HasColumnName("C20_0RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C200sampleRaw1)
                    .HasColumnName("C20_0SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C200sampleRaw2)
                    .HasColumnName("C20_0SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C200userOverride).HasColumnName("C20_0UserOverride");

                entity.Property(e => e.C20111calcRaw1)
                    .HasColumnName("C20_1_11CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C20111calcRaw2)
                    .HasColumnName("C20_1_11CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C20111relativeRaw1)
                    .HasColumnName("C20_1_11RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C20111relativeRaw2)
                    .HasColumnName("C20_1_11RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C20111sampleRaw1)
                    .HasColumnName("C20_1_11SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C20111sampleRaw2)
                    .HasColumnName("C20_1_11SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C20111userOverride).HasColumnName("C20_1_11UserOverride");

                entity.Property(e => e.C201w7CalcRaw1)
                    .HasColumnName("C20_1w7CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w7CalcRaw2)
                    .HasColumnName("C20_1w7CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w7FinalRelativeCalc)
                    .HasColumnName("C201w7_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w7FinalSampleCalc)
                    .HasColumnName("C201w7_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w7RelativeRaw1)
                    .HasColumnName("C20_1w7RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w7RelativeRaw2)
                    .HasColumnName("C20_1w7RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w7SampleRaw1)
                    .HasColumnName("C20_1w7SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w7SampleRaw2)
                    .HasColumnName("C20_1w7SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w7UserOverride).HasColumnName("C20_1w7UserOverride");

                entity.Property(e => e.C201w9CalcRaw1)
                    .HasColumnName("C20_1w9CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w9CalcRaw2)
                    .HasColumnName("C20_1w9CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w9FinalRelativeCalc)
                    .HasColumnName("C201w9_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w9FinalSampleCalc)
                    .HasColumnName("C201w9_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w9RelativeRaw1)
                    .HasColumnName("C20_1w9RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w9RelativeRaw2)
                    .HasColumnName("C20_1w9RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w9SampleRaw1)
                    .HasColumnName("C20_1w9SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w9SampleRaw2)
                    .HasColumnName("C20_1w9SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w9UserOverride).HasColumnName("C20_1w9UserOverride");

                entity.Property(e => e.C2021114FinalRelativeCalc)
                    .HasColumnName("C2021114_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C2021114FinalSampleCalc)
                    .HasColumnName("C2021114_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C2021114calcRaw1)
                    .HasColumnName("C20_2_11_14CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C2021114calcRaw2)
                    .HasColumnName("C20_2_11_14CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C2021114relativeRaw1)
                    .HasColumnName("C20_2_11_14RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C2021114relativeRaw2)
                    .HasColumnName("C20_2_11_14RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C2021114sampleRaw1)
                    .HasColumnName("C20_2_11_14SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C2021114sampleRaw2)
                    .HasColumnName("C20_2_11_14SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C2021114userOverride).HasColumnName("C20_2_11_14UserOverride");

                entity.Property(e => e.C202w6CalcRaw1)
                    .HasColumnName("C20_2w6CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C202w6CalcRaw2)
                    .HasColumnName("C20_2w6CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C202w6FinalRelativeCalc)
                    .HasColumnName("C202w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C202w6FinalSampleCalc)
                    .HasColumnName("C202w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C202w6RelativeRaw1)
                    .HasColumnName("C20_2w6RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C202w6RelativeRaw2)
                    .HasColumnName("C20_2w6RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C202w6SampleRaw1)
                    .HasColumnName("C20_2w6SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C202w6SampleRaw2)
                    .HasColumnName("C20_2w6SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C202w6UserOverride).HasColumnName("C20_2w6UserOverride");

                entity.Property(e => e.C203w3CalcRaw1)
                    .HasColumnName("C20_3w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w3CalcRaw2)
                    .HasColumnName("C20_3w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w3FinalRelativeCalc)
                    .HasColumnName("C203w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w3FinalSampleCalc)
                    .HasColumnName("C203w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w3RelativeRaw1)
                    .HasColumnName("C20_3w3RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w3RelativeRaw2)
                    .HasColumnName("C20_3w3RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w3SampleRaw1)
                    .HasColumnName("C20_3w3SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w3SampleRaw2)
                    .HasColumnName("C20_3w3SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w3UserOverride).HasColumnName("C20_3w3UserOverride");

                entity.Property(e => e.C203w6CalcRaw1)
                    .HasColumnName("C20_3w6CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w6CalcRaw2)
                    .HasColumnName("C20_3w6CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w6FinalRelativeCalc)
                    .HasColumnName("C203w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w6FinalSampleCalc)
                    .HasColumnName("C203w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w6RelativeRaw1)
                    .HasColumnName("C20_3w6RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w6RelativeRaw2)
                    .HasColumnName("C20_3w6RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w6SampleRaw1)
                    .HasColumnName("C20_3w6SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w6SampleRaw2)
                    .HasColumnName("C20_3w6SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w6UserOverride).HasColumnName("C20_3w6UserOverride");

                entity.Property(e => e.C204w3CalcRaw1)
                    .HasColumnName("C20_4w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w3CalcRaw2)
                    .HasColumnName("C20_4w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w3FinalRelativeCalc)
                    .HasColumnName("C204w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w3FinalSampleCalc)
                    .HasColumnName("C204w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w3RelativeRaw1)
                    .HasColumnName("C20_4w3RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w3RelativeRaw2)
                    .HasColumnName("C20_4w3RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w3SampleRaw1)
                    .HasColumnName("C20_4w3SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w3SampleRaw2)
                    .HasColumnName("C20_4w3SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w3UserOverride).HasColumnName("C20_4w3UserOverride");

                entity.Property(e => e.C204w6CalcRaw1)
                    .HasColumnName("C20_4w6CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w6CalcRaw2)
                    .HasColumnName("C20_4w6CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w6FinalRelativeCalc)
                    .HasColumnName("C204w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w6FinalSampleCalc)
                    .HasColumnName("C204w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w6RelativeRaw1)
                    .HasColumnName("C20_4w6RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w6RelativeRaw2)
                    .HasColumnName("C20_4w6RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w6SampleRaw1)
                    .HasColumnName("C20_4w6SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w6SampleRaw2)
                    .HasColumnName("C20_4w6SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w6UserOverride).HasColumnName("C20_4w6UserOverride");

                entity.Property(e => e.C205w3CalcRaw1)
                    .HasColumnName("C20_5w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C205w3CalcRaw2)
                    .HasColumnName("C20_5w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C205w3FinalRelativeCalc)
                    .HasColumnName("C205w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C205w3FinalSampleCalc)
                    .HasColumnName("C205w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C205w3RelativeRaw1)
                    .HasColumnName("C20_5w3RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C205w3RelativeRaw2)
                    .HasColumnName("C20_5w3RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C205w3SampleRaw1)
                    .HasColumnName("C20_5w3SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C205w3SampleRaw2)
                    .HasColumnName("C20_5w3SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C205w3UserOverride).HasColumnName("C20_5w3UserOverride");

                entity.Property(e => e.C215w3CalcRaw1)
                    .HasColumnName("C21_5w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C215w3CalcRaw2)
                    .HasColumnName("C21_5w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C215w3FinalRelativeCalc)
                    .HasColumnName("C215w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C215w3FinalSampleCalc)
                    .HasColumnName("C215w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C215w3RelativeRaw1)
                    .HasColumnName("C21_5w3RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C215w3RelativeRaw2)
                    .HasColumnName("C21_5w3RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C215w3SampleRaw1)
                    .HasColumnName("C21_5w3SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C215w3SampleRaw2)
                    .HasColumnName("C21_5w3SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C215w3UserOverride).HasColumnName("C21_5w3UserOverride");

                entity.Property(e => e.C220FinalRelativeCalc)
                    .HasColumnName("C220_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C220FinalSampleCalc)
                    .HasColumnName("C220_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C220calcRaw1)
                    .HasColumnName("C22_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C220calcRaw2)
                    .HasColumnName("C22_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C220relativeRaw1)
                    .HasColumnName("C22_0RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C220relativeRaw2)
                    .HasColumnName("C22_0RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C220sampleRaw1)
                    .HasColumnName("C22_0SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C220sampleRaw2)
                    .HasColumnName("C22_0SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C220userOverride).HasColumnName("C22_0UserOverride");

                entity.Property(e => e.C22111FinalRelativeCalc)
                    .HasColumnName("C22111_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C22111FinalSampleCalc)
                    .HasColumnName("C22111_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221FinalRelativeCalc)
                    .HasColumnName("C221_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221FinalSampleCalc)
                    .HasColumnName("C221_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221calcRaw1)
                    .HasColumnName("C22_1CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221calcRaw2)
                    .HasColumnName("C22_1CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221relativeRaw1)
                    .HasColumnName("C22_1RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221relativeRaw2)
                    .HasColumnName("C22_1RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221sampleRaw1)
                    .HasColumnName("C22_1SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221sampleRaw2)
                    .HasColumnName("C22_1SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221userOverride).HasColumnName("C22_1UserOverride");

                entity.Property(e => e.C221w9CalcRaw1)
                    .HasColumnName("C22_1w9CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221w9CalcRaw2)
                    .HasColumnName("C22_1w9CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221w9FinalRelativeCalc)
                    .HasColumnName("C221w9_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221w9FinalSampleCalc)
                    .HasColumnName("C221w9_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221w9RelativeRaw1)
                    .HasColumnName("C22_1w9RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221w9RelativeRaw2)
                    .HasColumnName("C22_1w9RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221w9SampleRaw1)
                    .HasColumnName("C22_1w9SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221w9SampleRaw2)
                    .HasColumnName("C22_1w9SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221w9UserOverride).HasColumnName("C22_1w9UserOverride");

                entity.Property(e => e.C225w3CalcRaw1)
                    .HasColumnName("C22_5w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w3CalcRaw2)
                    .HasColumnName("C22_5w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w3FinalRelativeCalc)
                    .HasColumnName("C225w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w3FinalSampleCalc)
                    .HasColumnName("C225w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w3RelativeRaw1)
                    .HasColumnName("C22_5w3RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w3RelativeRaw2)
                    .HasColumnName("C22_5w3RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w3SampleRaw1)
                    .HasColumnName("C22_5w3SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w3SampleRaw2)
                    .HasColumnName("C22_5w3SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w3UserOverride).HasColumnName("C22_5w3UserOverride");

                entity.Property(e => e.C225w6CalcRaw1)
                    .HasColumnName("C22_5w6CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w6CalcRaw2)
                    .HasColumnName("C22_5w6CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w6FinalRelativeCalc)
                    .HasColumnName("C225w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w6FinalSampleCalc)
                    .HasColumnName("C225w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w6RelativeRaw1)
                    .HasColumnName("C22_5w6RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w6RelativeRaw2)
                    .HasColumnName("C22_5w6RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w6SampleRaw1)
                    .HasColumnName("C22_5w6SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w6SampleRaw2)
                    .HasColumnName("C22_5w6SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w6UserOverride).HasColumnName("C22_5w6UserOverride");

                entity.Property(e => e.C226w3CalcRaw1)
                    .HasColumnName("C22_6w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C226w3CalcRaw2)
                    .HasColumnName("C22_6w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C226w3FinalRelativeCalc)
                    .HasColumnName("C226w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C226w3FinalSampleCalc)
                    .HasColumnName("C226w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C226w3RelativeRaw1)
                    .HasColumnName("C22_6w3RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C226w3RelativeRaw2)
                    .HasColumnName("C22_6w3RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C226w3SampleRaw1)
                    .HasColumnName("C22_6w3SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C226w3SampleRaw2)
                    .HasColumnName("C22_6w3SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C226w3UserOverride).HasColumnName("C22_6w3UserOverride");

                entity.Property(e => e.C240FinalRelativeCalc)
                    .HasColumnName("C240_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C240FinalSampleCalc)
                    .HasColumnName("C240_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C240calcRaw1)
                    .HasColumnName("C24_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C240calcRaw2)
                    .HasColumnName("C24_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C240relativeRaw1)
                    .HasColumnName("C24_0RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C240relativeRaw2)
                    .HasColumnName("C24_0RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C240sampleRaw1)
                    .HasColumnName("C24_0SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C240sampleRaw2)
                    .HasColumnName("C24_0SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C240userOverride).HasColumnName("C24_0UserOverride");

                entity.Property(e => e.C241FinalRelativeCalc)
                    .HasColumnName("C241_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C241FinalSampleCalc)
                    .HasColumnName("C241_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C241calcRaw1)
                    .HasColumnName("C24_1CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C241calcRaw2)
                    .HasColumnName("C24_1CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C241relativeRaw1)
                    .HasColumnName("C24_1RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C241relativeRaw2)
                    .HasColumnName("C24_1RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C241sampleRaw1)
                    .HasColumnName("C24_1SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C241sampleRaw2)
                    .HasColumnName("C24_1SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C241userOverride).HasColumnName("C24_1UserOverride");

                entity.Property(e => e.C60FinalRelativeCalc)
                    .HasColumnName("C60_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C60FinalSampleCalc)
                    .HasColumnName("C60_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C60calcRaw1)
                    .HasColumnName("C6_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C60calcRaw2)
                    .HasColumnName("C6_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C60relativeRaw1)
                    .HasColumnName("C6_0RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C60relativeRaw2)
                    .HasColumnName("C6_0RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C60sampleRaw1)
                    .HasColumnName("C6_0SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C60sampleRaw2)
                    .HasColumnName("C6_0SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C60userOverride).HasColumnName("C6_0UserOverride");

                entity.Property(e => e.C80FinalRelativeCalc)
                    .HasColumnName("C80_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C80FinalSampleCalc)
                    .HasColumnName("C80_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C80calcRaw1)
                    .HasColumnName("C8_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C80calcRaw2)
                    .HasColumnName("C8_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C80relativeRaw1)
                    .HasColumnName("C8_0RelativeRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C80relativeRaw2)
                    .HasColumnName("C8_0RelativeRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C80sampleRaw1)
                    .HasColumnName("C8_0SampleRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C80sampleRaw2)
                    .HasColumnName("C8_0SampleRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C80userOverride).HasColumnName("C8_0UserOverride");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NjfHygroAdjust).HasColumnName("NJF_Hygro_Adjust");

                entity.Property(e => e.OtherCalcRaw1).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.OtherCalcRaw2).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.OtherFinalRelativeCalc)
                    .HasColumnName("Other_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.OtherFinalSampleCalc)
                    .HasColumnName("Other_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.OtherRelativeRaw1).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.OtherRelativeRaw2).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.OtherSampleRaw1).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.OtherSampleRaw2).HasColumnType("decimal(6, 3)");
            });

            modelBuilder.Entity<IFattyacidOld>(entity =>
            {
                entity.HasKey(e => e.IfattyAcidIdOld);

                entity.ToTable("I_FATTYACID_OLD");

                entity.Property(e => e.IfattyAcidIdOld).HasColumnName("IfattyAcidID_Old");

                entity.Property(e => e.AdjustByHygro).HasColumnName("Adjust_By_Hygro");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.C100FinalRelativeCalc)
                    .HasColumnName("C100_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C100FinalSampleCalc)
                    .HasColumnName("C100_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C100calcRaw1)
                    .HasColumnName("C10_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C100calcRaw2)
                    .HasColumnName("C10_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C100finalCalc)
                    .HasColumnName("C10_0FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C100relativeRaw1)
                    .HasColumnName("C10_0RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C100relativeRaw2)
                    .HasColumnName("C10_0RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C100sampleRaw1)
                    .HasColumnName("C10_0SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C100sampleRaw2)
                    .HasColumnName("C10_0SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C100userOverride).HasColumnName("C10_0UserOverride");

                entity.Property(e => e.C120FinalRelativeCalc)
                    .HasColumnName("C120_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120FinalSampleCalc)
                    .HasColumnName("C120_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120calcRaw1)
                    .HasColumnName("C12_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120calcRaw2)
                    .HasColumnName("C12_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120finalCalc)
                    .HasColumnName("C12_0FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C120relativeRaw1)
                    .HasColumnName("C12_0RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C120relativeRaw2)
                    .HasColumnName("C12_0RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C120sampleRaw1)
                    .HasColumnName("C12_0SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C120sampleRaw2)
                    .HasColumnName("C12_0SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C120userOverride).HasColumnName("C12_0UserOverride");

                entity.Property(e => e.C140FinalRelativeCalc)
                    .HasColumnName("C140_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C140FinalSampleCalc)
                    .HasColumnName("C140_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C140calcRaw1)
                    .HasColumnName("C14_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C140calcRaw2)
                    .HasColumnName("C14_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C140finalCalc)
                    .HasColumnName("C14_0FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C140relativeRaw1)
                    .HasColumnName("C14_0RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C140relativeRaw2)
                    .HasColumnName("C14_0RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C140sampleRaw1)
                    .HasColumnName("C14_0SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C140sampleRaw2)
                    .HasColumnName("C14_0SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C140userOverride).HasColumnName("C14_0UserOverride");

                entity.Property(e => e.C141FinalRelativeCalc)
                    .HasColumnName("C141_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C141FinalSampleCalc)
                    .HasColumnName("C141_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C141calcRaw1)
                    .HasColumnName("C14_1CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C141calcRaw2)
                    .HasColumnName("C14_1CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C141finalCalc)
                    .HasColumnName("C14_1FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C141relativeRaw1)
                    .HasColumnName("C14_1RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C141relativeRaw2)
                    .HasColumnName("C14_1RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C141sampleRaw1)
                    .HasColumnName("C14_1SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C141sampleRaw2)
                    .HasColumnName("C14_1SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C141userOverride).HasColumnName("C14_1UserOverride");

                entity.Property(e => e.C150FinalRelativeCalc)
                    .HasColumnName("C150_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C150FinalSampleCalc)
                    .HasColumnName("C150_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C150calcRaw1)
                    .HasColumnName("C15_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C150calcRaw2)
                    .HasColumnName("C15_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C150finalCalc)
                    .HasColumnName("C15_0FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C150relativeRaw1)
                    .HasColumnName("C15_0RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C150relativeRaw2)
                    .HasColumnName("C15_0RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C150sampleRaw1)
                    .HasColumnName("C15_0SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C150sampleRaw2)
                    .HasColumnName("C15_0SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C150userOverride).HasColumnName("C15_0UserOverride");

                entity.Property(e => e.C160FinalRelativeCalc)
                    .HasColumnName("C160_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160FinalSampleCalc)
                    .HasColumnName("C160_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160calcRaw1)
                    .HasColumnName("C16_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160calcRaw2)
                    .HasColumnName("C16_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160finalCalc)
                    .HasColumnName("C16_0FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C160relativeRaw1)
                    .HasColumnName("C16_0RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C160relativeRaw2)
                    .HasColumnName("C16_0RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C160sampleRaw1)
                    .HasColumnName("C16_0SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C160sampleRaw2)
                    .HasColumnName("C16_0SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C160userOverride).HasColumnName("C16_0UserOverride");

                entity.Property(e => e.C161FinalRelativeCalc)
                    .HasColumnName("C161_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C161FinalSampleCalc)
                    .HasColumnName("C161_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C161calcRaw1)
                    .HasColumnName("C16_1CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C161calcRaw2)
                    .HasColumnName("C16_1CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C161finalCalc)
                    .HasColumnName("C16_1FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C161relativeRaw1)
                    .HasColumnName("C16_1RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C161relativeRaw2)
                    .HasColumnName("C16_1RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C161sampleRaw1)
                    .HasColumnName("C16_1SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C161sampleRaw2)
                    .HasColumnName("C16_1SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C161userOverride).HasColumnName("C16_1UserOverride");

                entity.Property(e => e.C162FinalRelativeCalc)
                    .HasColumnName("C162_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C162FinalSampleCalc)
                    .HasColumnName("C162_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C162calcRaw1)
                    .HasColumnName("C16_2CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C162calcRaw2)
                    .HasColumnName("C16_2CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C162finalCalc)
                    .HasColumnName("C16_2FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C162relativeRaw1)
                    .HasColumnName("C16_2RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C162relativeRaw2)
                    .HasColumnName("C16_2RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C162sampleRaw1)
                    .HasColumnName("C16_2SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C162sampleRaw2)
                    .HasColumnName("C16_2SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C162userOverride).HasColumnName("C16_2UserOverride");

                entity.Property(e => e.C163FinalRelativeCalc)
                    .HasColumnName("C163_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C163FinalSampleCalc)
                    .HasColumnName("C163_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C163calcRaw1)
                    .HasColumnName("C16_3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C163calcRaw2)
                    .HasColumnName("C16_3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C163finalCalc)
                    .HasColumnName("C16_3FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C163relativeRaw1)
                    .HasColumnName("C16_3RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C163relativeRaw2)
                    .HasColumnName("C16_3RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C163sampleRaw1)
                    .HasColumnName("C16_3SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C163sampleRaw2)
                    .HasColumnName("C16_3SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C163userOverride).HasColumnName("C16_3UserOverride");

                entity.Property(e => e.C164FinalRelativeCalc)
                    .HasColumnName("C164_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C164FinalSampleCalc)
                    .HasColumnName("C164_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C164calcRaw1)
                    .HasColumnName("C16_4CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C164calcRaw2)
                    .HasColumnName("C16_4CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C164finalCalc)
                    .HasColumnName("C16_4FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C164relativeRaw1)
                    .HasColumnName("C16_4RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C164relativeRaw2)
                    .HasColumnName("C16_4RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C164sampleRaw1)
                    .HasColumnName("C16_4SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C164sampleRaw2)
                    .HasColumnName("C16_4SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C164userOverride).HasColumnName("C16_4UserOverride");

                entity.Property(e => e.C170FinalRelativeCalc)
                    .HasColumnName("C170_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C170FinalSampleCalc)
                    .HasColumnName("C170_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C170calcRaw1)
                    .HasColumnName("C17_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C170calcRaw2)
                    .HasColumnName("C17_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C170finalCalc)
                    .HasColumnName("C17_0FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C170relativeRaw1)
                    .HasColumnName("C17_0RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C170relativeRaw2)
                    .HasColumnName("C17_0RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C170sampleRaw1)
                    .HasColumnName("C17_0SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C170sampleRaw2)
                    .HasColumnName("C17_0SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C170userOverride).HasColumnName("C17_0UserOverride");

                entity.Property(e => e.C171FinalRelativeCalc)
                    .HasColumnName("C171_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C171FinalSampleCalc)
                    .HasColumnName("C171_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C171calcRaw1)
                    .HasColumnName("C17_1CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C171calcRaw2)
                    .HasColumnName("C17_1CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C171finalCalc)
                    .HasColumnName("C17_1FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C171relativeRaw1)
                    .HasColumnName("C17_1RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C171relativeRaw2)
                    .HasColumnName("C17_1RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C171sampleRaw1)
                    .HasColumnName("C17_1SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C171sampleRaw2)
                    .HasColumnName("C17_1SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C171userOverride).HasColumnName("C17_1UserOverride");

                entity.Property(e => e.C180FinalRelativeCalc)
                    .HasColumnName("C180_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180FinalSampleCalc)
                    .HasColumnName("C180_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180calcRaw1)
                    .HasColumnName("C18_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180calcRaw2)
                    .HasColumnName("C18_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180finalCalc)
                    .HasColumnName("C18_0FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C180relativeRaw1)
                    .HasColumnName("C18_0RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C180relativeRaw2)
                    .HasColumnName("C18_0RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C180sampleRaw1)
                    .HasColumnName("C18_0SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C180sampleRaw2)
                    .HasColumnName("C18_0SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C180userOverride).HasColumnName("C18_0UserOverride");

                entity.Property(e => e.C181FinalRelativeCalc)
                    .HasColumnName("C181_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181FinalSampleCalc)
                    .HasColumnName("C181_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181calcRaw1)
                    .HasColumnName("C18_1CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181calcRaw2)
                    .HasColumnName("C18_1CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181finalCalc)
                    .HasColumnName("C18_1FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181relativeRaw1)
                    .HasColumnName("C18_1RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C181relativeRaw2)
                    .HasColumnName("C18_1RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C181sampleRaw1)
                    .HasColumnName("C18_1SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C181sampleRaw2)
                    .HasColumnName("C18_1SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C181userOverride).HasColumnName("C18_1UserOverride");

                entity.Property(e => e.C181w7CalcRaw1)
                    .HasColumnName("C18_1w7CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w7CalcRaw2)
                    .HasColumnName("C18_1w7CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w7FinalCalc)
                    .HasColumnName("C18_1w7FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w7FinalRelativeCalc)
                    .HasColumnName("C181w7_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w7FinalSampleCalc)
                    .HasColumnName("C181w7_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w7RelativeRaw1)
                    .HasColumnName("C18_1w7RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C181w7RelativeRaw2)
                    .HasColumnName("C18_1w7RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C181w7SampleRaw1)
                    .HasColumnName("C18_1w7SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C181w7SampleRaw2)
                    .HasColumnName("C18_1w7SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C181w7UserOverride).HasColumnName("C18_1w7UserOverride");

                entity.Property(e => e.C181w9CalcRaw1)
                    .HasColumnName("C18_1w9CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w9CalcRaw2)
                    .HasColumnName("C18_1w9CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w9FinalCalc)
                    .HasColumnName("C18_1w9FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w9FinalRelativeCalc)
                    .HasColumnName("C181w9_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w9FinalSampleCalc)
                    .HasColumnName("C181w9_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C181w9RelativeRaw1)
                    .HasColumnName("C18_1w9RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C181w9RelativeRaw2)
                    .HasColumnName("C18_1w9RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C181w9SampleRaw1)
                    .HasColumnName("C18_1w9SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C181w9SampleRaw2)
                    .HasColumnName("C18_1w9SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C181w9UserOverride).HasColumnName("C18_1w9UserOverride");

                entity.Property(e => e.C182FinalRelativeCalc)
                    .HasColumnName("C182_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182FinalSampleCalc)
                    .HasColumnName("C182_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182calcRaw1)
                    .HasColumnName("C18_2CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182calcRaw2)
                    .HasColumnName("C18_2CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182finalCalc)
                    .HasColumnName("C18_2FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182relativeRaw1)
                    .HasColumnName("C18_2RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C182relativeRaw2)
                    .HasColumnName("C18_2RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C182sampleRaw1)
                    .HasColumnName("C18_2SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C182sampleRaw2)
                    .HasColumnName("C18_2SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C182userOverride).HasColumnName("C18_2UserOverride");

                entity.Property(e => e.C182w4CalcRaw1)
                    .HasColumnName("C18_2w4CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w4CalcRaw2)
                    .HasColumnName("C18_2w4CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w4FinalCalc)
                    .HasColumnName("C18_2w4FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w4FinalRelativeCalc)
                    .HasColumnName("C182w4_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w4FinalSampleCalc)
                    .HasColumnName("C182w4_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w4RelativeRaw1)
                    .HasColumnName("C18_2w4RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C182w4RelativeRaw2)
                    .HasColumnName("C18_2w4RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C182w4SampleRaw1)
                    .HasColumnName("C18_2w4SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C182w4SampleRaw2)
                    .HasColumnName("C18_2w4SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C182w4UserOverride).HasColumnName("C18_2w4UserOverride");

                entity.Property(e => e.C182w6CalcRaw1)
                    .HasColumnName("C18_2w6CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w6CalcRaw2)
                    .HasColumnName("C18_2w6CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w6FinalCalc)
                    .HasColumnName("C18_2w6FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w6FinalRelativeCalc)
                    .HasColumnName("C182w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w6FinalSampleCalc)
                    .HasColumnName("C182w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C182w6RelativeRaw1)
                    .HasColumnName("C18_2w6RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C182w6RelativeRaw2)
                    .HasColumnName("C18_2w6RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C182w6SampleRaw1)
                    .HasColumnName("C18_2w6SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C182w6SampleRaw2)
                    .HasColumnName("C18_2w6SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C182w6UserOverride).HasColumnName("C18_2w6UserOverride");

                entity.Property(e => e.C183FinalRelativeCalc)
                    .HasColumnName("C183_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183FinalSampleCalc)
                    .HasColumnName("C183_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183calcRaw1)
                    .HasColumnName("C18_3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183calcRaw2)
                    .HasColumnName("C18_3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183finalCalc)
                    .HasColumnName("C18_3FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183relativeRaw1)
                    .HasColumnName("C18_3RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C183relativeRaw2)
                    .HasColumnName("C18_3RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C183sampleRaw1)
                    .HasColumnName("C18_3SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C183sampleRaw2)
                    .HasColumnName("C18_3SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C183userOverride).HasColumnName("C18_3UserOverride");

                entity.Property(e => e.C183w3CalcRaw1)
                    .HasColumnName("C18_3w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w3CalcRaw2)
                    .HasColumnName("C18_3w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w3FinalCalc)
                    .HasColumnName("C18_3w3FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w3FinalRelativeCalc)
                    .HasColumnName("C183w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w3FinalSampleCalc)
                    .HasColumnName("C183w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w3RelativeRaw1)
                    .HasColumnName("C18_3w3RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C183w3RelativeRaw2)
                    .HasColumnName("C18_3w3RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C183w3SampleRaw1)
                    .HasColumnName("C18_3w3SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C183w3SampleRaw2)
                    .HasColumnName("C18_3w3SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C183w3UserOverride).HasColumnName("C18_3w3UserOverride");

                entity.Property(e => e.C183w6CalcRaw1)
                    .HasColumnName("C18_3w6CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w6CalcRaw2)
                    .HasColumnName("C18_3w6CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w6FinalCalc)
                    .HasColumnName("C18_3w6FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w6FinalRelativeCalc)
                    .HasColumnName("C183w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w6FinalSampleCalc)
                    .HasColumnName("C183w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C183w6RelativeRaw1)
                    .HasColumnName("C18_3w6RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C183w6RelativeRaw2)
                    .HasColumnName("C18_3w6RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C183w6SampleRaw1)
                    .HasColumnName("C18_3w6SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C183w6SampleRaw2)
                    .HasColumnName("C18_3w6SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C183w6UserOverride).HasColumnName("C18_3w6UserOverride");

                entity.Property(e => e.C184w3CalcRaw1)
                    .HasColumnName("C18_4w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C184w3CalcRaw2)
                    .HasColumnName("C18_4w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C184w3FinalCalc)
                    .HasColumnName("C18_4w3FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C184w3FinalRelativeCalc)
                    .HasColumnName("C184w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C184w3FinalSampleCalc)
                    .HasColumnName("C184w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C184w3RelativeRaw1)
                    .HasColumnName("C18_4w3RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C184w3RelativeRaw2)
                    .HasColumnName("C18_4w3RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C184w3SampleRaw1)
                    .HasColumnName("C18_4w3SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C184w3SampleRaw2)
                    .HasColumnName("C18_4w3SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C184w3UserOverride).HasColumnName("C18_4w3UserOverride");

                entity.Property(e => e.C200FinalRelativeCalc)
                    .HasColumnName("C200_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C200FinalSampleCalc)
                    .HasColumnName("C200_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C200calcRaw1)
                    .HasColumnName("C20_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C200calcRaw2)
                    .HasColumnName("C20_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C200finalCalc)
                    .HasColumnName("C20_0FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C200relativeRaw1)
                    .HasColumnName("C20_0RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C200relativeRaw2)
                    .HasColumnName("C20_0RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C200sampleRaw1)
                    .HasColumnName("C20_0SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C200sampleRaw2)
                    .HasColumnName("C20_0SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C200userOverride).HasColumnName("C20_0UserOverride");

                entity.Property(e => e.C20111calcRaw1)
                    .HasColumnName("C20_1_11CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C20111calcRaw2)
                    .HasColumnName("C20_1_11CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C20111finalCalc)
                    .HasColumnName("C20_1_11FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C20111relativeRaw1)
                    .HasColumnName("C20_1_11RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C20111relativeRaw2)
                    .HasColumnName("C20_1_11RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C20111sampleRaw1)
                    .HasColumnName("C20_1_11SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C20111sampleRaw2)
                    .HasColumnName("C20_1_11SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C20111userOverride).HasColumnName("C20_1_11UserOverride");

                entity.Property(e => e.C201w7CalcRaw1)
                    .HasColumnName("C20_1w7CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w7CalcRaw2)
                    .HasColumnName("C20_1w7CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w7FinalCalc)
                    .HasColumnName("C20_1w7FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w7FinalRelativeCalc)
                    .HasColumnName("C201w7_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w7FinalSampleCalc)
                    .HasColumnName("C201w7_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w7RelativeRaw1)
                    .HasColumnName("C20_1w7RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C201w7RelativeRaw2)
                    .HasColumnName("C20_1w7RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C201w7SampleRaw1)
                    .HasColumnName("C20_1w7SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C201w7SampleRaw2)
                    .HasColumnName("C20_1w7SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C201w7UserOverride).HasColumnName("C20_1w7UserOverride");

                entity.Property(e => e.C201w9CalcRaw1)
                    .HasColumnName("C20_1w9CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w9CalcRaw2)
                    .HasColumnName("C20_1w9CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w9FinalCalc)
                    .HasColumnName("C20_1w9FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w9FinalRelativeCalc)
                    .HasColumnName("C201w9_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w9FinalSampleCalc)
                    .HasColumnName("C201w9_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C201w9RelativeRaw1)
                    .HasColumnName("C20_1w9RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C201w9RelativeRaw2)
                    .HasColumnName("C20_1w9RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C201w9SampleRaw1)
                    .HasColumnName("C20_1w9SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C201w9SampleRaw2)
                    .HasColumnName("C20_1w9SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C201w9UserOverride).HasColumnName("C20_1w9UserOverride");

                entity.Property(e => e.C2021114FinalRelativeCalc)
                    .HasColumnName("C2021114_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C2021114FinalSampleCalc)
                    .HasColumnName("C2021114_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C2021114calcRaw1)
                    .HasColumnName("C20_2_11_14CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C2021114calcRaw2)
                    .HasColumnName("C20_2_11_14CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C2021114finalCalc)
                    .HasColumnName("C20_2_11_14FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C2021114relativeRaw1)
                    .HasColumnName("C20_2_11_14RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C2021114relativeRaw2)
                    .HasColumnName("C20_2_11_14RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C2021114sampleRaw1)
                    .HasColumnName("C20_2_11_14SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C2021114sampleRaw2)
                    .HasColumnName("C20_2_11_14SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C2021114userOverride).HasColumnName("C20_2_11_14UserOverride");

                entity.Property(e => e.C202w6CalcRaw1)
                    .HasColumnName("C20_2w6CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C202w6CalcRaw2)
                    .HasColumnName("C20_2w6CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C202w6FinalCalc)
                    .HasColumnName("C20_2w6FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C202w6FinalRelativeCalc)
                    .HasColumnName("C202w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C202w6FinalSampleCalc)
                    .HasColumnName("C202w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C202w6RelativeRaw1)
                    .HasColumnName("C20_2w6RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C202w6RelativeRaw2)
                    .HasColumnName("C20_2w6RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C202w6SampleRaw1)
                    .HasColumnName("C20_2w6SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C202w6SampleRaw2)
                    .HasColumnName("C20_2w6SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C202w6UserOverride).HasColumnName("C20_2w6UserOverride");

                entity.Property(e => e.C203w3CalcRaw1)
                    .HasColumnName("C20_3w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w3CalcRaw2)
                    .HasColumnName("C20_3w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w3FinalCalc)
                    .HasColumnName("C20_3w3FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w3FinalRelativeCalc)
                    .HasColumnName("C203w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w3FinalSampleCalc)
                    .HasColumnName("C203w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w3RelativeRaw1)
                    .HasColumnName("C20_3w3RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C203w3RelativeRaw2)
                    .HasColumnName("C20_3w3RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C203w3SampleRaw1)
                    .HasColumnName("C20_3w3SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C203w3SampleRaw2)
                    .HasColumnName("C20_3w3SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C203w3UserOverride).HasColumnName("C20_3w3UserOverride");

                entity.Property(e => e.C203w6CalcRaw1)
                    .HasColumnName("C20_3w6CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w6CalcRaw2)
                    .HasColumnName("C20_3w6CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w6FinalCalc)
                    .HasColumnName("C20_3w6FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w6FinalRelativeCalc)
                    .HasColumnName("C203w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w6FinalSampleCalc)
                    .HasColumnName("C203w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C203w6RelativeRaw1)
                    .HasColumnName("C20_3w6RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C203w6RelativeRaw2)
                    .HasColumnName("C20_3w6RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C203w6SampleRaw1)
                    .HasColumnName("C20_3w6SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C203w6SampleRaw2)
                    .HasColumnName("C20_3w6SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C203w6UserOverride).HasColumnName("C20_3w6UserOverride");

                entity.Property(e => e.C204w3CalcRaw1)
                    .HasColumnName("C20_4w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w3CalcRaw2)
                    .HasColumnName("C20_4w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w3FinalCalc)
                    .HasColumnName("C20_4w3FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w3FinalRelativeCalc)
                    .HasColumnName("C204w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w3FinalSampleCalc)
                    .HasColumnName("C204w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w3RelativeRaw1)
                    .HasColumnName("C20_4w3RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C204w3RelativeRaw2)
                    .HasColumnName("C20_4w3RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C204w3SampleRaw1)
                    .HasColumnName("C20_4w3SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C204w3SampleRaw2)
                    .HasColumnName("C20_4w3SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C204w3UserOverride).HasColumnName("C20_4w3UserOverride");

                entity.Property(e => e.C204w6CalcRaw1)
                    .HasColumnName("C20_4w6CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w6CalcRaw2)
                    .HasColumnName("C20_4w6CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w6FinalCalc)
                    .HasColumnName("C20_4w6FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w6FinalRelativeCalc)
                    .HasColumnName("C204w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w6FinalSampleCalc)
                    .HasColumnName("C204w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C204w6RelativeRaw1)
                    .HasColumnName("C20_4w6RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C204w6RelativeRaw2)
                    .HasColumnName("C20_4w6RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C204w6SampleRaw1)
                    .HasColumnName("C20_4w6SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C204w6SampleRaw2)
                    .HasColumnName("C20_4w6SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C204w6UserOverride).HasColumnName("C20_4w6UserOverride");

                entity.Property(e => e.C205w3CalcRaw1)
                    .HasColumnName("C20_5w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C205w3CalcRaw2)
                    .HasColumnName("C20_5w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C205w3FinalCalc)
                    .HasColumnName("C20_5w3FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C205w3FinalRelativeCalc)
                    .HasColumnName("C205w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C205w3FinalSampleCalc)
                    .HasColumnName("C205w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C205w3RelativeRaw1)
                    .HasColumnName("C20_5w3RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C205w3RelativeRaw2)
                    .HasColumnName("C20_5w3RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C205w3SampleRaw1)
                    .HasColumnName("C20_5w3SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C205w3SampleRaw2)
                    .HasColumnName("C20_5w3SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C205w3UserOverride).HasColumnName("C20_5w3UserOverride");

                entity.Property(e => e.C215w3CalcRaw1)
                    .HasColumnName("C21_5w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C215w3CalcRaw2)
                    .HasColumnName("C21_5w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C215w3FinalCalc)
                    .HasColumnName("C21_5w3FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C215w3FinalRelativeCalc)
                    .HasColumnName("C215w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C215w3FinalSampleCalc)
                    .HasColumnName("C215w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C215w3RelativeRaw1)
                    .HasColumnName("C21_5w3RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C215w3RelativeRaw2)
                    .HasColumnName("C21_5w3RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C215w3SampleRaw1)
                    .HasColumnName("C21_5w3SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C215w3SampleRaw2)
                    .HasColumnName("C21_5w3SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C215w3UserOverride).HasColumnName("C21_5w3UserOverride");

                entity.Property(e => e.C220FinalRelativeCalc)
                    .HasColumnName("C220_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C220FinalSampleCalc)
                    .HasColumnName("C220_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C220calcRaw1)
                    .HasColumnName("C22_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C220calcRaw2)
                    .HasColumnName("C22_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C220finalCalc)
                    .HasColumnName("C22_0FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C220relativeRaw1)
                    .HasColumnName("C22_0RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C220relativeRaw2)
                    .HasColumnName("C22_0RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C220sampleRaw1)
                    .HasColumnName("C22_0SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C220sampleRaw2)
                    .HasColumnName("C22_0SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C220userOverride).HasColumnName("C22_0UserOverride");

                entity.Property(e => e.C22111FinalRelativeCalc)
                    .HasColumnName("C22111_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C22111FinalSampleCalc)
                    .HasColumnName("C22111_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221FinalRelativeCalc)
                    .HasColumnName("C221_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221FinalSampleCalc)
                    .HasColumnName("C221_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221calcRaw1)
                    .HasColumnName("C22_1CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221calcRaw2)
                    .HasColumnName("C22_1CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221finalCalc)
                    .HasColumnName("C22_1FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221relativeRaw1)
                    .HasColumnName("C22_1RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C221relativeRaw2)
                    .HasColumnName("C22_1RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C221sampleRaw1)
                    .HasColumnName("C22_1SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C221sampleRaw2)
                    .HasColumnName("C22_1SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C221userOverride).HasColumnName("C22_1UserOverride");

                entity.Property(e => e.C221w9CalcRaw1)
                    .HasColumnName("C22_1w9CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221w9CalcRaw2)
                    .HasColumnName("C22_1w9CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221w9FinalCalc)
                    .HasColumnName("C22_1w9FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221w9FinalRelativeCalc)
                    .HasColumnName("C221w9_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221w9FinalSampleCalc)
                    .HasColumnName("C221w9_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C221w9RelativeRaw1)
                    .HasColumnName("C22_1w9RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C221w9RelativeRaw2)
                    .HasColumnName("C22_1w9RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C221w9SampleRaw1)
                    .HasColumnName("C22_1w9SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C221w9SampleRaw2)
                    .HasColumnName("C22_1w9SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C221w9UserOverride).HasColumnName("C22_1w9UserOverride");

                entity.Property(e => e.C225w3CalcRaw1)
                    .HasColumnName("C22_5w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w3CalcRaw2)
                    .HasColumnName("C22_5w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w3FinalCalc)
                    .HasColumnName("C22_5w3FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w3FinalRelativeCalc)
                    .HasColumnName("C225w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w3FinalSampleCalc)
                    .HasColumnName("C225w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w3RelativeRaw1)
                    .HasColumnName("C22_5w3RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C225w3RelativeRaw2)
                    .HasColumnName("C22_5w3RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C225w3SampleRaw1)
                    .HasColumnName("C22_5w3SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C225w3SampleRaw2)
                    .HasColumnName("C22_5w3SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C225w3UserOverride).HasColumnName("C22_5w3UserOverride");

                entity.Property(e => e.C225w6CalcRaw1)
                    .HasColumnName("C22_5w6CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w6CalcRaw2)
                    .HasColumnName("C22_5w6CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w6FinalCalc)
                    .HasColumnName("C22_5w6FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w6FinalRelativeCalc)
                    .HasColumnName("C225w6_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w6FinalSampleCalc)
                    .HasColumnName("C225w6_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C225w6RelativeRaw1)
                    .HasColumnName("C22_5w6RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C225w6RelativeRaw2)
                    .HasColumnName("C22_5w6RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C225w6SampleRaw1)
                    .HasColumnName("C22_5w6SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C225w6SampleRaw2)
                    .HasColumnName("C22_5w6SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C225w6UserOverride).HasColumnName("C22_5w6UserOverride");

                entity.Property(e => e.C226w3CalcRaw1)
                    .HasColumnName("C22_6w3CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C226w3CalcRaw2)
                    .HasColumnName("C22_6w3CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C226w3FinalCalc)
                    .HasColumnName("C22_6w3FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C226w3FinalRelativeCalc)
                    .HasColumnName("C226w3_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C226w3FinalSampleCalc)
                    .HasColumnName("C226w3_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C226w3RelativeRaw1)
                    .HasColumnName("C22_6w3RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C226w3RelativeRaw2)
                    .HasColumnName("C22_6w3RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C226w3SampleRaw1)
                    .HasColumnName("C22_6w3SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C226w3SampleRaw2)
                    .HasColumnName("C22_6w3SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C226w3UserOverride).HasColumnName("C22_6w3UserOverride");

                entity.Property(e => e.C240FinalRelativeCalc)
                    .HasColumnName("C240_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C240FinalSampleCalc)
                    .HasColumnName("C240_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C240calcRaw1)
                    .HasColumnName("C24_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C240calcRaw2)
                    .HasColumnName("C24_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C240finalCalc)
                    .HasColumnName("C24_0FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C240relativeRaw1)
                    .HasColumnName("C24_0RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C240relativeRaw2)
                    .HasColumnName("C24_0RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C240sampleRaw1)
                    .HasColumnName("C24_0SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C240sampleRaw2)
                    .HasColumnName("C24_0SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C240userOverride).HasColumnName("C24_0UserOverride");

                entity.Property(e => e.C241FinalRelativeCalc)
                    .HasColumnName("C241_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C241FinalSampleCalc)
                    .HasColumnName("C241_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C241calcRaw1)
                    .HasColumnName("C24_1CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C241calcRaw2)
                    .HasColumnName("C24_1CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C241finalCalc)
                    .HasColumnName("C24_1FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C241relativeRaw1)
                    .HasColumnName("C24_1RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C241relativeRaw2)
                    .HasColumnName("C24_1RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C241sampleRaw1)
                    .HasColumnName("C24_1SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C241sampleRaw2)
                    .HasColumnName("C24_1SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C241userOverride).HasColumnName("C24_1UserOverride");

                entity.Property(e => e.C60FinalRelativeCalc)
                    .HasColumnName("C60_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C60FinalSampleCalc)
                    .HasColumnName("C60_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C60calcRaw1)
                    .HasColumnName("C6_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C60calcRaw2)
                    .HasColumnName("C6_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C60finalCalc)
                    .HasColumnName("C6_0FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C60relativeRaw1)
                    .HasColumnName("C6_0RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C60relativeRaw2)
                    .HasColumnName("C6_0RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C60sampleRaw1)
                    .HasColumnName("C6_0SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C60sampleRaw2)
                    .HasColumnName("C6_0SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C60userOverride).HasColumnName("C6_0UserOverride");

                entity.Property(e => e.C80FinalRelativeCalc)
                    .HasColumnName("C80_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C80FinalSampleCalc)
                    .HasColumnName("C80_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C80calcRaw1)
                    .HasColumnName("C8_0CalcRaw1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C80calcRaw2)
                    .HasColumnName("C8_0CalcRaw2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C80finalCalc)
                    .HasColumnName("C8_0FinalCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.C80relativeRaw1)
                    .HasColumnName("C8_0RelativeRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C80relativeRaw2)
                    .HasColumnName("C8_0RelativeRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C80sampleRaw1)
                    .HasColumnName("C8_0SampleRaw1")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C80sampleRaw2)
                    .HasColumnName("C8_0SampleRaw2")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.C80userOverride).HasColumnName("C8_0UserOverride");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.NjfHygroAdjust).HasColumnName("NJF_Hygro_Adjust");

                entity.Property(e => e.OtherCalcRaw1).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.OtherCalcRaw2).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.OtherFinalCalc).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.OtherFinalRelativeCalc)
                    .HasColumnName("Other_FinalRelativeCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.OtherFinalSampleCalc)
                    .HasColumnName("Other_FinalSampleCalc")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.OtherRelativeRaw1).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.OtherRelativeRaw2).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.OtherSampleRaw1).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.OtherSampleRaw2).HasColumnType("decimal(4, 2)");
            });

            modelBuilder.Entity<IFermAnyalysys>(entity =>
            {
                entity.HasKey(e => e.AnyalysysId);

                entity.ToTable("I_FERM_ANYALYSYS");

                entity.Property(e => e.Average).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DmMax)
                    .HasColumnName("DM_Max")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.DmMin)
                    .HasColumnName("DM_Min")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.DmRange)
                    .HasColumnName("DM_Range")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Range)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SampleDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SampleType)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IFermentation>(entity =>
            {
                entity.HasKey(e => e.FermentationId);

                entity.ToTable("I_FERMENTATION");

                entity.Property(e => e.FermentationId).HasColumnName("FermentationID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Butanol2calc)
                    .HasColumnName("Butanol_2Calc")
                    .HasColumnType("decimal(9, 3)");

                entity.Property(e => e.Butanol2raw)
                    .HasColumnName("Butanol_2Raw")
                    .HasColumnType("decimal(9, 3)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EthanolCalc).HasColumnType("decimal(9, 3)");

                entity.Property(e => e.EthanolRaw).HasColumnType("decimal(9, 3)");

                entity.Property(e => e.EthylAcetateCalc)
                    .HasColumnName("Ethyl_acetateCalc")
                    .HasColumnType("decimal(9, 3)");

                entity.Property(e => e.EthylAcetateRaw)
                    .HasColumnName("Ethyl_acetateRaw")
                    .HasColumnType("decimal(9, 3)");

                entity.Property(e => e.EthylLactateCalc)
                    .HasColumnName("Ethyl_lactateCalc")
                    .HasColumnType("decimal(9, 3)");

                entity.Property(e => e.EthylLactateRaw)
                    .HasColumnName("Ethyl_lactateRaw")
                    .HasColumnType("decimal(9, 3)");

                entity.Property(e => e.MethanolCalc).HasColumnType("decimal(9, 3)");

                entity.Property(e => e.MethanolRaw).HasColumnType("decimal(9, 3)");

                entity.Property(e => e.MethylAcetateCalc)
                    .HasColumnName("Methyl_acetateCalc")
                    .HasColumnType("decimal(9, 3)");

                entity.Property(e => e.MethylAcetateRaw)
                    .HasColumnName("Methyl_acetateRaw")
                    .HasColumnType("decimal(9, 3)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Propanol1calc)
                    .HasColumnName("Propanol_1Calc")
                    .HasColumnType("decimal(9, 3)");

                entity.Property(e => e.Propanol1raw)
                    .HasColumnName("Propanol_1Raw")
                    .HasColumnType("decimal(9, 3)");

                entity.Property(e => e.PropylAcetateCalc)
                    .HasColumnName("Propyl_acetateCalc")
                    .HasColumnType("decimal(9, 3)");

                entity.Property(e => e.PropylAcetateRaw)
                    .HasColumnName("Propyl_acetateRaw")
                    .HasColumnType("decimal(9, 3)");

                entity.Property(e => e.PropylLactateCalc)
                    .HasColumnName("Propyl_lactateCalc")
                    .HasColumnType("decimal(9, 3)");

                entity.Property(e => e.PropylLactateRaw)
                    .HasColumnName("Propyl_lactateRaw")
                    .HasColumnType("decimal(9, 3)");

                entity.Property(e => e.SampleWeight).HasColumnType("decimal(9, 3)");

                entity.Property(e => e.Water).HasColumnType("decimal(9, 3)");
            });

            modelBuilder.Entity<IIntranetsubmission>(entity =>
            {
                entity.ToTable("I_INTRANETSUBMISSION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.IsMoldId).HasColumnName("IsMoldID");
            });

            modelBuilder.Entity<ILogbook>(entity =>
            {
                entity.ToTable("I_logbook");

                entity.Property(e => e.IlogbookId).HasColumnName("IlogbookID");

                entity.Property(e => e.Analysis)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Batch)
                    .HasColumnName("BATCH")
                    .HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FeedType)
                    .HasColumnName("Feed_Type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Initials)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<IManure>(entity =>
            {
                entity.ToTable("I_Manure");

                entity.Property(e => e.ImanureId)
                    .HasColumnName("IManureID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Imanure)
                    .WithOne(p => p.InverseImanure)
                    .HasForeignKey<IManure>(d => d.ImanureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_Manure_I_Manure");
            });

            modelBuilder.Entity<IManureAmmonia>(entity =>
            {
                entity.HasKey(e => e.AmmoniaId);

                entity.ToTable("I_ManureAmmonia");

                entity.Property(e => e.AmmoniaId).HasColumnName("AmmoniaID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Calculation).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Weight).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureAmmonia)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureAmmonia_I_Manure");
            });

            modelBuilder.Entity<IManureCa>(entity =>
            {
                entity.HasKey(e => e.CaId);

                entity.ToTable("I_ManureCa");

                entity.Property(e => e.CaId).HasColumnName("CaID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Calculation).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueImport).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureCa)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureCa_I_Manure");
            });

            modelBuilder.Entity<IManureCl>(entity =>
            {
                entity.HasKey(e => e.ClId);

                entity.ToTable("I_ManureCl");

                entity.Property(e => e.ClId).HasColumnName("ClID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueImport).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureCl)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureCl_I_Manure");
            });

            modelBuilder.Entity<IManureCu>(entity =>
            {
                entity.HasKey(e => e.CuId);

                entity.ToTable("I_ManureCu");

                entity.Property(e => e.CuId).HasColumnName("CuID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Calculation).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Code).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueImport).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureCu)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureCu_I_Manure1");
            });

            modelBuilder.Entity<IManureDensity>(entity =>
            {
                entity.HasKey(e => e.DensityId);

                entity.ToTable("I_ManureDensity");

                entity.Property(e => e.DensityId).HasColumnName("DensityID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Calc).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Cylinder).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.CylplusWater).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.LorS).HasMaxLength(1);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SampleplusCylinder).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.SampplusCylplusWater).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureDensity)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureDensity_I_Manure");
            });

            modelBuilder.Entity<IManureFe>(entity =>
            {
                entity.HasKey(e => e.FeId);

                entity.ToTable("I_ManureFe");

                entity.Property(e => e.FeId).HasColumnName("FeID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Calculation).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Code).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueImport).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureFe)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureFe_I_Manure");
            });

            modelBuilder.Entity<IManureK>(entity =>
            {
                entity.HasKey(e => e.Kid);

                entity.ToTable("I_ManureK");

                entity.Property(e => e.Kid).HasColumnName("KID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Calculation).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Code).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueImport).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureK)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureK_I_Manure");
            });

            modelBuilder.Entity<IManureMg>(entity =>
            {
                entity.HasKey(e => e.MgId);

                entity.ToTable("I_ManureMg");

                entity.Property(e => e.MgId).HasColumnName("MgID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Calculation).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Code).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueImport).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureMg)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureMg_I_Manure");
            });

            modelBuilder.Entity<IManureMineralsIcp>(entity =>
            {
                entity.HasKey(e => e.MineralsIcpid);

                entity.ToTable("I_ManureMineralsICP");

                entity.Property(e => e.MineralsIcpid).HasColumnName("MineralsICPID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Crucible).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.CrucibleplusDiluent).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.CrucibleplusSample).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Factor).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureMineralsIcp)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureMineralsICP_I_Manure");
            });

            modelBuilder.Entity<IManureMn>(entity =>
            {
                entity.HasKey(e => e.MnId);

                entity.ToTable("I_ManureMn");

                entity.Property(e => e.MnId).HasColumnName("MnID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Calculation).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Code).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueImport).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureMn)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureMn_I_Manure");
            });

            modelBuilder.Entity<IManureNa>(entity =>
            {
                entity.HasKey(e => e.NaId);

                entity.ToTable("I_ManureNa");

                entity.Property(e => e.NaId).HasColumnName("NaID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Calculation).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Code).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueImport).HasColumnType("decimal(9, 3)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureNa)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureNa_I_Manure");
            });

            modelBuilder.Entity<IManureNitrogen>(entity =>
            {
                entity.HasKey(e => e.NitrogeId);

                entity.ToTable("I_ManureNitrogen");

                entity.Property(e => e.NitrogeId).HasColumnName("NitrogeID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureNitrogen)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureNitrogen_I_Manure");
            });

            modelBuilder.Entity<IManurep>(entity =>
            {
                entity.HasKey(e => e.PId);

                entity.ToTable("I_Manurep");

                entity.Property(e => e.PId).HasColumnName("pID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Calculation).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Code).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueImport).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManurep)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_Manurep_I_Manure");
            });

            modelBuilder.Entity<IManurepH>(entity =>
            {
                entity.HasKey(e => e.PHid);

                entity.ToTable("I_ManurepH");

                entity.Property(e => e.PHid).HasColumnName("pHID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManurepH)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManurepH_I_Manure");
            });

            modelBuilder.Entity<IManureS>(entity =>
            {
                entity.HasKey(e => e.Sid);

                entity.ToTable("I_ManureS");

                entity.Property(e => e.Sid).HasColumnName("SID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueImport).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureS)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureS_I_Manure");
            });

            modelBuilder.Entity<IManureTotalSolids>(entity =>
            {
                entity.HasKey(e => e.TotalSolidId);

                entity.ToTable("I_ManureTotalSolids");

                entity.Property(e => e.TotalSolidId).HasColumnName("TotalSolidID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Calculation).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Crucible).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.CruciblePlusSample).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Dry)
                    .HasColumnName("DRY")
                    .HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureTotalSolids)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureTotalSolids_I_Manure");
            });

            modelBuilder.Entity<IManureVolatilesSolids>(entity =>
            {
                entity.HasKey(e => e.VolatilesSolidsId);

                entity.ToTable("I_ManureVolatilesSolids");

                entity.Property(e => e.VolatilesSolidsId).HasColumnName("VolatilesSolidsID");

                entity.Property(e => e.AshedCrucible).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Calculation).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureVolatilesSolids)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureVolatilesSolids_I_Manure");
            });

            modelBuilder.Entity<IManureWep>(entity =>
            {
                entity.HasKey(e => e.Wepid);

                entity.ToTable("I_ManureWEP");

                entity.Property(e => e.Wepid).HasColumnName("WEPID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Calculation).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Code).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Crucible).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.CruplusLiquid).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.CruplusSample).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Phos).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Weight).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureWep)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureWEP_I_Manure");
            });

            modelBuilder.Entity<IManureZn>(entity =>
            {
                entity.HasKey(e => e.ZnId);

                entity.ToTable("I_ManureZn");

                entity.Property(e => e.ZnId).HasColumnName("ZnID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Calculation).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Code).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Imanure).HasColumnName("IManure");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ValueImport).HasColumnType("decimal(9, 4)");

                entity.HasOne(d => d.ImanureNavigation)
                    .WithMany(p => p.IManureZn)
                    .HasForeignKey(d => d.Imanure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ManureZn_I_Manure");
            });

            modelBuilder.Entity<IMoldIdentification>(entity =>
            {
                entity.HasKey(e => e.MoldIdentificationId);

                entity.ToTable("I_MoldIdentification");

                entity.Property(e => e.MoldIdentificationId).HasColumnName("MoldIdentificationID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<IMoldIdentificationDetails>(entity =>
            {
                entity.HasKey(e => e.MoldIdentificationDetailsId);

                entity.ToTable("I_MoldIdentificationDetails");

                entity.Property(e => e.MoldIdentificationDetailsId).HasColumnName("MoldIdentificationDetailsID");

                entity.Property(e => e.MoldId).HasColumnName("MoldID");

                entity.Property(e => e.MoldIdentificationId).HasColumnName("MoldIdentificationID");

                entity.HasOne(d => d.Mold)
                    .WithMany(p => p.IMoldIdentificationDetails)
                    .HasForeignKey(d => d.MoldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_MoldIdentificationDetails_I_MoldsMaster");

                entity.HasOne(d => d.MoldIdentification)
                    .WithMany(p => p.IMoldIdentificationDetails)
                    .HasForeignKey(d => d.MoldIdentificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_MoldIdentificationDetails_I_MoldIdentification");
            });

            modelBuilder.Entity<IMoldsMaster>(entity =>
            {
                entity.HasKey(e => e.MoldId);

                entity.ToTable("I_MoldsMaster");

                entity.Property(e => e.MoldId).HasColumnName("MoldID");

                entity.Property(e => e.Mold)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<INdfddata>(entity =>
            {
                entity.ToTable("I_NDFDDATA");

                entity.Property(e => e.IndfdDataId).HasColumnName("INdfdDataID");

                entity.Property(e => e.ANdf).HasColumnName("aNDF");

                entity.Property(e => e.ANdfom).HasColumnName("aNDFom");

                entity.Property(e => e.ANdr).HasColumnName("aNDR");

                entity.Property(e => e.ANdrom).HasColumnName("aNDRom");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FilterPlusAsh1).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.FilterPlusAsh2).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.FilterPlusAsh3).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Lag).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ndf2Bag).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Ndf2BagSm).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Ndf2BagTr).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Ndf3Bag).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Ndf3BagSm).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Ndf3BagTr).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.NdfBag).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.NdfBagSm).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.NdfBagTr).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.NdfdResult1).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.NdfdResult2).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.NdfdResult3).HasColumnType("decimal(10, 4)");
            });

            modelBuilder.Entity<INdfdinvitro>(entity =>
            {
                entity.ToTable("I_NDFDINVITRO");

                entity.Property(e => e.IndfdInvitroId).HasColumnName("IndfdInvitroID");

                entity.Property(e => e.Averaged).HasDefaultValueSql("((1))");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Blank).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CorrectionFactor).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DNdfdm)
                    .HasColumnName("dNDFDM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.DNdfndf)
                    .HasColumnName("dNDFNDF")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.DNdfomDm)
                    .HasColumnName("dNDFomDM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.DNdfomNdf)
                    .HasColumnName("dNDFomNDF")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.FilterAshWeight).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.FilterWeight).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.FinalWeight).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.INdfdm)
                    .HasColumnName("iNDFDM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.INdfndf)
                    .HasColumnName("iNDFNDF")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.INdfomDm)
                    .HasColumnName("iNDFomDM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.INdfomNdf)
                    .HasColumnName("iNDFomNDF")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SampleId).HasColumnName("SampleID");

                entity.Property(e => e.Sampleweight).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.TimePointId).HasColumnName("TimePointID");

                entity.HasOne(d => d.Sample)
                    .WithMany(p => p.INdfdinvitro)
                    .HasForeignKey(d => d.SampleId)
                    .HasConstraintName("FK_I_NDFDINVITRO_SAMPLES");

                entity.HasOne(d => d.TimePoint)
                    .WithMany(p => p.INdfdinvitro)
                    .HasForeignKey(d => d.TimePointId)
                    .HasConstraintName("FK_I_NDFDINVITRO_I_TimePoint");
            });

            modelBuilder.Entity<INirdata>(entity =>
            {
                entity.ToTable("I_NIRDATA");

                entity.Property(e => e.InirDataId).HasColumnName("INirDataID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Insitu>(entity =>
            {
                entity.ToTable("INSITU");

                entity.Property(e => e.InsituId).HasColumnName("InsituID");

                entity.Property(e => e.DomesticPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DomesticSpecialItemId).HasColumnName("DomesticSpecialItemID");

                entity.Property(e => e.InsituCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.InsituDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.InsituValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IntSpecialItemId).HasColumnName("IntSpecialItemID");

                entity.Property(e => e.InternationalPrice).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.DomesticSpecialItem)
                    .WithMany(p => p.InsituDomesticSpecialItem)
                    .HasForeignKey(d => d.DomesticSpecialItemId)
                    .HasConstraintName("FK_INSITU_SPECIALITEMS");

                entity.HasOne(d => d.IntSpecialItem)
                    .WithMany(p => p.InsituIntSpecialItem)
                    .HasForeignKey(d => d.IntSpecialItemId)
                    .HasConstraintName("FK_INSITU_SPECIALITEMS1");
            });

            modelBuilder.Entity<INutrecoData>(entity =>
            {
                entity.ToTable("I_NutrecoData");

                entity.Property(e => e.InutrecoDataId).HasColumnName("INutrecoDataID");

                entity.Property(e => e.AaAceticAcid)
                    .HasColumnName("AA_AceticAcid")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.AdAdf)
                    .HasColumnName("AD_Adf")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.AmAmmonia)
                    .HasColumnName("AM_Ammonia")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.AsAsh)
                    .HasColumnName("AS_Ash")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CaCalcium)
                    .HasColumnName("CA_Calcium")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ClChloride)
                    .HasColumnName("CL_Chloride")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CpCrudeProtein)
                    .HasColumnName("CP_CrudeProtein")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CtTotalFattyAcid)
                    .HasColumnName("CT_TotalFattyAcid")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.DmDryMatter)
                    .HasColumnName("DM_DryMatter")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.EqEquation)
                    .HasColumnName("Eq_Equation")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EsAvailableStarch)
                    .HasColumnName("ES_AvailableStarch")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.FaFat)
                    .HasColumnName("FA_Fat")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.FeIronppm)
                    .HasColumnName("FE_Ironppm")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.FeedCodeId).HasColumnName("FeedCodeID");

                entity.Property(e => e.FeedType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FfSolubleFiber)
                    .HasColumnName("FF_SolubleFiber")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.GhGlobalValue)
                    .HasColumnName("gh_GlobalValue")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.IaIsobutyricAcid)
                    .HasColumnName("IA_IsobutyricAcid")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.IfIf)
                    .HasColumnName("If_If")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.IpAdin)
                    .HasColumnName("IP_Adin")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.IsInsolubleProtein)
                    .HasColumnName("IS_InsolubleProtein")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.LaLacticAcid)
                    .HasColumnName("LA_LacticAcid")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.LfIndfDm)
                    .HasColumnName("LF_Indf_DM")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.LgLignin)
                    .HasColumnName("LG_Lignin")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.MachineNumber)
                    .HasColumnName("Machine_Number")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MgMagnesium)
                    .HasColumnName("MG_Magnesium")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.N1Ndf12)
                    .HasColumnName("N1_NDF12")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.N2Ndf24)
                    .HasColumnName("N2_NDF24")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.N3Ndf30)
                    .HasColumnName("N3_NDF30")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.N4Ndf48)
                    .HasColumnName("N4_NDF48")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NaSodium)
                    .HasColumnName("NA_Sodium")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NdNdr)
                    .HasColumnName("ND_Ndr")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Nelact)
                    .HasColumnName("NELACT")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NoNdfom)
                    .HasColumnName("NO_Ndfom")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NpNdin)
                    .HasColumnName("NP_Ndin")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NrNdfomRatio)
                    .HasColumnName("NR_NdfomRatio")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NsNdf)
                    .HasColumnName("NS_Ndf")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NzNdfd240)
                    .HasColumnName("NZ_NDFD240")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.O3NitrateIon)
                    .HasColumnName("O3_NitrateIon")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Pcon)
                    .HasColumnName("PCON")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PdPd)
                    .HasColumnName("Pd_Pd")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PhPh)
                    .HasColumnName("PH_Ph")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Pl12propanediol)
                    .HasColumnName("PL_12Propanediol")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PoPotassium)
                    .HasColumnName("PO_Potassium")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PrProprionicAcid)
                    .HasColumnName("PR_ProprionicAcid")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.PsPhosphorus)
                    .HasColumnName("PS_Phosphorus")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.S7InvitroStarch7Hr)
                    .HasColumnName("S7_InvitroStarch7HR")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.SaStarch)
                    .HasColumnName("SA_Starch")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.SampleType)
                    .HasColumnName("Sample_Type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SfSulfur)
                    .HasColumnName("SF_Sulfur")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.SgWaterSolubleCarbohyrate)
                    .HasColumnName("SG_WaterSolubleCarbohyrate")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.SuSugar)
                    .HasColumnName("SU_Sugar")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.TaTitratableAcidityMeqgm)
                    .HasColumnName("TA_TitratableAcidityMEQGM")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.TvTotalVfa)
                    .HasColumnName("TV_TotalVfa")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.XxAFrac)
                    .HasColumnName("xx_A_FRAC")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.XxAcetic)
                    .HasColumnName("xx_Acetic")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.XxAdl)
                    .HasColumnName("xx_Adl")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.XxBFrac)
                    .HasColumnName("xx_B_Frac")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.XxDFrac)
                    .HasColumnName("xx_D_Frac")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.XxEFrac)
                    .HasColumnName("xx_E_Frac")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.XxEwFrac)
                    .HasColumnName("xx_Ew_Frac")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.XxFFrac)
                    .HasColumnName("xx_F_Frac")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.XxK2)
                    .HasColumnName("xx_K2")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.XxK8)
                    .HasColumnName("xx_K8")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.XxK9)
                    .HasColumnName("xx_K9")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.XxLactic)
                    .HasColumnName("xx_Lactic")
                    .HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Invitro>(entity =>
            {
                entity.HasKey(e => e.NdfdIv240id);

                entity.ToTable("INVITRO");

                entity.Property(e => e.NdfdIv240id).HasColumnName("NDFD_IV_240ID");

                entity.Property(e => e.Sampleid).HasColumnName("SAMPLEID");

                entity.Property(e => e.Timepoint).HasColumnName("TIMEPOINT");

                entity.Property(e => e.Value)
                    .HasColumnName("VALUE")
                    .HasColumnType("decimal(7, 4)");

                entity.HasOne(d => d.Sample)
                    .WithMany(p => p.Invitro)
                    .HasForeignKey(d => d.Sampleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NDFD_IV_240_SAMPLES");
            });

            modelBuilder.Entity<Invitrodigestibility>(entity =>
            {
                entity.HasKey(e => e.InvitroId);

                entity.ToTable("INVITRODIGESTIBILITY");

                entity.Property(e => e.InvitroId).HasColumnName("InvitroID");

                entity.Property(e => e.DomesticPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DomesticSpecialItemId).HasColumnName("DomesticSpecialItemID");

                entity.Property(e => e.IntSpecialItemId).HasColumnName("IntSpecialItemID");

                entity.Property(e => e.InternationalPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.InvitroCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.InvitroDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.InvitroValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.DomesticSpecialItem)
                    .WithMany(p => p.InvitrodigestibilityDomesticSpecialItem)
                    .HasForeignKey(d => d.DomesticSpecialItemId)
                    .HasConstraintName("FK_INVITRODIGESTIBILITY_SPECIALITEMS");

                entity.HasOne(d => d.IntSpecialItem)
                    .WithMany(p => p.InvitrodigestibilityIntSpecialItem)
                    .HasForeignKey(d => d.IntSpecialItemId)
                    .HasConstraintName("FK_INVITRODIGESTIBILITY_SPECIALITEMS1");
            });

            modelBuilder.Entity<IParticlesizeanalysis>(entity =>
            {
                entity.HasKey(e => e.ParticleSizeId);

                entity.ToTable("I_PARTICLESIZEANALYSIS");

                entity.Property(e => e.ParticleSizeId)
                    .HasColumnName("ParticleSizeID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AverageParticleSize).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CumulativeBottomPan).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.CumulativeLower).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.CumulativeMiddle).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.CumulativeUpper).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RemainingBottomPan).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.RemainingLower).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.RemainingMiddle).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.RemainingUpper).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.SieveBottomPan).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.SieveLower).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.SieveMiddle).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.SieveUpper).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.StandardDeviation).HasColumnType("decimal(5, 3)");

                entity.HasOne(d => d.ParticleSize)
                    .WithOne(p => p.InverseParticleSize)
                    .HasForeignKey<IParticlesizeanalysis>(d => d.ParticleSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_ParticleSizeAnalysis_I_ParticleSizeAnalysis");
            });

            modelBuilder.Entity<IPdi>(entity =>
            {
                entity.HasKey(e => e.Pdiid);

                entity.ToTable("I_PDI");

                entity.Property(e => e.Pdiid).HasColumnName("PDIID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CrudeProteinAsIs)
                    .HasColumnName("CrudeProteinAsIS")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.CrudeProteinDry).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Dm)
                    .HasColumnName("DM")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Moisture).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.ProteinDispersibilityIndex).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.UreaseActivity).HasColumnType("decimal(4, 2)");
            });

            modelBuilder.Entity<Irrigation>(entity =>
            {
                entity.ToTable("IRRIGATION");

                entity.Property(e => e.IrrigationId).HasColumnName("IrrigationID");

                entity.Property(e => e.Cname)
                    .HasColumnName("CName")
                    .HasMaxLength(50);

                entity.Property(e => e.Cvalue)
                    .HasColumnName("CValue")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Irrigationtype>(entity =>
            {
                entity.ToTable("IRRIGATIONTYPE");

                entity.Property(e => e.IrrigationTypeId).HasColumnName("IrrigationTypeID");

                entity.Property(e => e.Cname)
                    .HasColumnName("CName")
                    .HasMaxLength(50);

                entity.Property(e => e.Cvalue)
                    .HasColumnName("CValue")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<IStEqLookup>(entity =>
            {
                entity.ToTable("I_ST_EQ_Lookup");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Eq)
                    .IsRequired()
                    .HasColumnName("EQ")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeedType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.St)
                    .IsRequired()
                    .HasColumnName("ST")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ITimePoint>(entity =>
            {
                entity.HasKey(e => e.TimePointId);

                entity.ToTable("I_TimePoint");

                entity.Property(e => e.TimePointId).HasColumnName("TimePointID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ITmrfecal>(entity =>
            {
                entity.HasKey(e => e.TmrFecalId);

                entity.ToTable("I_TMRFECAL");

                entity.Property(e => e.TmrFecalId).HasColumnName("TmrFecalID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FecalSamplesId).HasColumnName("FecalSamplesID");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TmrSamplesId).HasColumnName("TmrSamplesID");

                entity.HasOne(d => d.FecalSamples)
                    .WithMany(p => p.ITmrfecalFecalSamples)
                    .HasForeignKey(d => d.FecalSamplesId)
                    .HasConstraintName("FK_I_TMRFECAL_SAMPLES_FECAL");

                entity.HasOne(d => d.TmrSamples)
                    .WithMany(p => p.ITmrfecalTmrSamples)
                    .HasForeignKey(d => d.TmrSamplesId)
                    .HasConstraintName("FK_I_TMRFECAL_SAMPLES_TMR");
            });

            modelBuilder.Entity<IToxin>(entity =>
            {
                entity.ToTable("I_TOXIN");

                entity.Property(e => e.ItoxinId).HasColumnName("IToxinID");

                entity.Property(e => e.Atoxb1).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Atoxb2).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Atoxg1).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Atoxg2).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Don).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Don15ac)
                    .HasColumnName("DON_15Ac")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Don3ac)
                    .HasColumnName("DON_3Ac")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Ftoxb1).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.Ftoxb2).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Ftoxb3).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.Ht2).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ochratoxin).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.T2tox).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.ToxinLabId).HasColumnName("ToxinLabID");

                entity.Property(e => e.Ztox).HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.ToxinLab)
                    .WithMany(p => p.IToxin)
                    .HasForeignKey(d => d.ToxinLabId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_TOXIN_I_TOXINLABS");
            });

            modelBuilder.Entity<IToxinlabs>(entity =>
            {
                entity.ToTable("I_TOXINLABS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LabName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IToxinmethod>(entity =>
            {
                entity.ToTable("I_TOXINMETHOD");

                entity.Property(e => e.ItoxinMethodId).HasColumnName("IToxinMethodID");

                entity.Property(e => e.ItoxinId).HasColumnName("IToxinID");

                entity.HasOne(d => d.Itoxin)
                    .WithMany(p => p.IToxinmethod)
                    .HasForeignKey(d => d.ItoxinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_TOXINMETHOD_I_TOXIN");
            });

            modelBuilder.Entity<IToxinnondetect>(entity =>
            {
                entity.HasKey(e => e.ItoxinIdnonDetect);

                entity.ToTable("I_TOXINNONDETECT");

                entity.Property(e => e.ItoxinIdnonDetect).HasColumnName("IToxinIDNonDetect");

                entity.Property(e => e.Don15acNonDetect).HasColumnName("DON_15AcNonDetect");

                entity.Property(e => e.Don3acNonDetect).HasColumnName("DON_3AcNonDetect");

                entity.Property(e => e.ItoxinId).HasColumnName("IToxinID");

                entity.HasOne(d => d.Itoxin)
                    .WithMany(p => p.IToxinnondetect)
                    .HasForeignKey(d => d.ItoxinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_I_TOXINNONDETECT_I_TOXIN");
            });

            modelBuilder.Entity<Ivsd>(entity =>
            {
                entity.ToTable("IVSD");

                entity.HasIndex(e => new { e.Ivsd02, e.Ivsd04, e.Ivsd06, e.Ivsd0Ng, e.Ivsd22, e.Ivsd24, e.Ivsd26, e.Ivsd2Ng, e.Ivsd32, e.Ivsd34, e.Ivsd36, e.Ivsd3Ng, e.Ivsd42, e.Ivsd44, e.Ivsd46, e.Ivsd4Ng, e.Ivsd62, e.Ivsd64, e.Ivsd66, e.Ivsd6Ng, e.Ivsd72, e.Ivsd74, e.Ivsd76, e.Ivsd7Ng, e.Ivsd82, e.Ivsd84, e.Ivsd86, e.Ivsd8Ng, e.Ivsd122, e.Ivsd124, e.Ivsd126, e.Ivsd12Ng, e.Ivsd162, e.Ivsd164, e.Ivsd166, e.Ivsd16Ng, e.Ivsd202, e.Ivsd204, e.Ivsd206, e.Ivsd20Ng, e.Ivsd242, e.Ivsd244, e.Ivsd246, e.Ivsd24Ng, e.Ivsd362, e.Ivsd364, e.Ivsd366, e.Ivsd36Ng, e.IvsdLag, e.Issd72, e.Issd74, e.Issd76, e.Issd7Ng, e.Issd122, e.Issd124, e.Issd126, e.Issd12Ng, e.Issd242, e.Issd244, e.Issd246, e.Issd24Ng, e.ResultsId })
                    .HasName("IX_RESULTID")
                    .IsUnique();

                entity.Property(e => e.Ivsdid).HasColumnName("IVSDID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Issd122)
                    .HasColumnName("ISSD_12_2")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Issd124)
                    .HasColumnName("ISSD_12_4")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Issd126)
                    .HasColumnName("ISSD_12_6")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Issd12Ng)
                    .HasColumnName("ISSD_12_NG")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Issd242)
                    .HasColumnName("ISSD_24_2")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Issd244)
                    .HasColumnName("ISSD_24_4")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Issd246)
                    .HasColumnName("ISSD_24_6")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Issd24Ng)
                    .HasColumnName("ISSD_24_NG")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Issd72)
                    .HasColumnName("ISSD_7_2")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Issd74)
                    .HasColumnName("ISSD_7_4")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Issd76)
                    .HasColumnName("ISSD_7_6")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Issd7Ng)
                    .HasColumnName("ISSD_7_NG")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd02)
                    .HasColumnName("IVSD_0_2")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd04)
                    .HasColumnName("IVSD_0_4")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd06)
                    .HasColumnName("IVSD_0_6")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd0Ng)
                    .HasColumnName("IVSD_0_NG")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd122)
                    .HasColumnName("IVSD_12_2")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd124)
                    .HasColumnName("IVSD_12_4")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd126)
                    .HasColumnName("IVSD_12_6")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd12Ng)
                    .HasColumnName("IVSD_12_NG")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd162)
                    .HasColumnName("IVSD_16_2")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd164)
                    .HasColumnName("IVSD_16_4")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd166)
                    .HasColumnName("IVSD_16_6")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd16Ng)
                    .HasColumnName("IVSD_16_NG")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd202)
                    .HasColumnName("IVSD_20_2")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd204)
                    .HasColumnName("IVSD_20_4")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd206)
                    .HasColumnName("IVSD_20_6")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd20Ng)
                    .HasColumnName("IVSD_20_NG")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd22)
                    .HasColumnName("IVSD_2_2")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd24)
                    .HasColumnName("IVSD_2_4")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd242)
                    .HasColumnName("IVSD_24_2")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd244)
                    .HasColumnName("IVSD_24_4")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd246)
                    .HasColumnName("IVSD_24_6")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd24Ng)
                    .HasColumnName("IVSD_24_NG")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd26)
                    .HasColumnName("IVSD_2_6")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd2Ng)
                    .HasColumnName("IVSD_2_NG")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd32)
                    .HasColumnName("IVSD_3_2")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd34)
                    .HasColumnName("IVSD_3_4")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd36)
                    .HasColumnName("IVSD_3_6")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd362)
                    .HasColumnName("IVSD_36_2")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd364)
                    .HasColumnName("IVSD_36_4")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd366)
                    .HasColumnName("IVSD_36_6")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd36Ng)
                    .HasColumnName("IVSD_36_NG")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd3Ng)
                    .HasColumnName("IVSD_3_NG")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd42)
                    .HasColumnName("IVSD_4_2")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd44)
                    .HasColumnName("IVSD_4_4")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd46)
                    .HasColumnName("IVSD_4_6")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd4Ng)
                    .HasColumnName("IVSD_4_NG")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd62)
                    .HasColumnName("IVSD_6_2")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd64)
                    .HasColumnName("IVSD_6_4")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd66)
                    .HasColumnName("IVSD_6_6")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd6Ng)
                    .HasColumnName("IVSD_6_NG")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd72)
                    .HasColumnName("IVSD_7_2")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Ivsd74)
                    .HasColumnName("IVSD_7_4")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Ivsd76)
                    .HasColumnName("IVSD_7_6")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd7Ng)
                    .HasColumnName("IVSD_7_NG")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd82)
                    .HasColumnName("IVSD_8_2")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd84)
                    .HasColumnName("IVSD_8_4")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd86)
                    .HasColumnName("IVSD_8_6")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Ivsd8Ng)
                    .HasColumnName("IVSD_8_NG")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.IvsdLag)
                    .HasColumnName("IVSD_lag")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");
            });

            modelBuilder.Entity<Lablocations>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("LABLOCATIONS");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.HasKey(e => e.LanguageId);

                entity.ToTable("LANGUAGES");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.LanguageDesc).HasMaxLength(128);

                entity.Property(e => e.LanguageName).HasMaxLength(64);

                entity.Property(e => e.LanguageUrl).HasMaxLength(50);

                entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            });

            modelBuilder.Entity<LcodeNamesInfo>(entity =>
            {
                entity.HasKey(e => e.IdColumn);

                entity.Property(e => e.IdColumn).HasColumnName("ID_column");

                entity.Property(e => e.LcodeDevName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LcodeRealName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Linkedaccounts>(entity =>
            {
                entity.HasKey(e => e.LinkedAccountId);

                entity.ToTable("LINKEDACCOUNTS");

                entity.Property(e => e.LinkedAccountId).HasColumnName("LinkedAccountID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Linkedaccounts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_LINKEDACCOUNTS_ACCOUNT");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Linkedaccounts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_LINKEDACCOUNTS_aspnet_Users");
            });

            modelBuilder.Entity<LogFaxes>(entity =>
            {
                entity.HasKey(e => e.FaxLogId);

                entity.ToTable("LOG_FAXES");

                entity.Property(e => e.FaxLogId).HasColumnName("FaxLogID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FaxId).HasColumnName("FaxID");

                entity.Property(e => e.FaxNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LabId)
                    .HasColumnName("LabID")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ManageCustomExcel>(entity =>
            {
                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Manureanalysis>(entity =>
            {
                entity.HasKey(e => e.ManureId);

                entity.ToTable("MANUREANALYSIS");

                entity.Property(e => e.ManureId).HasColumnName("ManureID");

                entity.Property(e => e.DomesticPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DomesticSpecialItemId).HasColumnName("DomesticSpecialItemID");

                entity.Property(e => e.IntSpecialItemId).HasColumnName("IntSpecialItemID");

                entity.Property(e => e.InternationalPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ManureCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ManureDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ManureValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.DomesticSpecialItem)
                    .WithMany(p => p.ManureanalysisDomesticSpecialItem)
                    .HasForeignKey(d => d.DomesticSpecialItemId)
                    .HasConstraintName("FK_MANUREANALYSIS_SPECIALITEMS");

                entity.HasOne(d => d.IntSpecialItem)
                    .WithMany(p => p.ManureanalysisIntSpecialItem)
                    .HasForeignKey(d => d.IntSpecialItemId)
                    .HasConstraintName("FK_MANUREANALYSIS_SPECIALITEMS1");
            });

            modelBuilder.Entity<Maturity>(entity =>
            {
                entity.ToTable("MATURITY");

                entity.Property(e => e.MaturityId).HasColumnName("MaturityID");

                entity.Property(e => e.Cname)
                    .HasColumnName("CName")
                    .HasMaxLength(50);

                entity.Property(e => e.Cvalue)
                    .HasColumnName("CValue")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.ToTable("MEDIA");

                entity.Property(e => e.MediaId).HasColumnName("MediaID");

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MediaDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MediaName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MediaPath)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MediaType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Memodetails>(entity =>
            {
                entity.HasKey(e => e.MemoId);

                entity.ToTable("MEMODETAILS");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(500);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.MenulinkId);

                entity.ToTable("MENU");

                entity.Property(e => e.MenulinkId)
                    .HasColumnName("MenulinkID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.LinkPath).HasMaxLength(100);

                entity.Property(e => e.MenuName).HasMaxLength(50);

                entity.Property(e => e.ModifiedDt).HasColumnType("datetime");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.Menulink)
                    .WithOne(p => p.InverseMenulink)
                    .HasForeignKey<Menu>(d => d.MenulinkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MENU_MENU");
            });

            modelBuilder.Entity<Microbial>(entity =>
            {
                entity.ToTable("MICROBIAL");

                entity.HasIndex(e => new { e.Mold, e.Yeast, e.Fusarium, e.Aspergill, e.Penicill, e.Mucor, e.Thizopus, e.Cladospor, e.MicrobialId, e.ResultsId })
                    .HasName("IX_RESULTID")
                    .IsUnique();

                entity.Property(e => e.MicrobialId).HasColumnName("MicrobialID");

                entity.Property(e => e.Absidia).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.Alternaria).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.Aspergill).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.Cladospor).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.Fusarium).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.LmoldId).HasColumnName("LMoldID");

                entity.Property(e => e.Mold).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Mucor).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.Penicill).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.Property(e => e.Scopulariopsis).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.Thizopus).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.Yeast).HasColumnType("decimal(10, 0)");

                entity.HasOne(d => d.Results)
                    .WithMany(p => p.Microbial)
                    .HasForeignKey(d => d.ResultsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MICROBIAL_RESULTS");
            });

            modelBuilder.Entity<Minerals>(entity =>
            {
                entity.ToTable("MINERALS");

                entity.HasIndex(e => new { e.Ca, e.P, e.Mg, e.K, e.S, e.Na, e.Cl, e.Fe, e.Zn, e.Cu, e.Mn, e.Mo, e.Se, e.Co, e.I, e.ResultsId })
                    .HasName("IX_RESULTID")
                    .IsUnique();

                entity.Property(e => e.MineralsId).HasColumnName("MineralsID");

                entity.Property(e => e.Al).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Al1)
                    .HasColumnName("Al_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.As).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.As1)
                    .HasColumnName("As_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Ba).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Ba1)
                    .HasColumnName("Ba_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Bo).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Bo1)
                    .HasColumnName("Bo_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Ca)
                    .HasColumnName("CA")
                    .HasColumnType("numeric(7, 4)");

                entity.Property(e => e.Ca1)
                    .HasColumnName("CA_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Cd).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Cd1)
                    .HasColumnName("Cd_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Cl).HasColumnType("numeric(7, 4)");

                entity.Property(e => e.Cl1)
                    .HasColumnName("Cl_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Co).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Co1)
                    .HasColumnName("Co_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Cr).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Cr1)
                    .HasColumnName("Cr_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Cu).HasColumnType("numeric(10, 4)");

                entity.Property(e => e.Cu1)
                    .HasColumnName("Cu_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Fe).HasColumnType("numeric(10, 4)");

                entity.Property(e => e.Fe1)
                    .HasColumnName("Fe_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Hg).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Hg1)
                    .HasColumnName("Hg_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.I).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.I1)
                    .HasColumnName("I_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.K).HasColumnType("numeric(7, 4)");

                entity.Property(e => e.K1)
                    .HasColumnName("K_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Mg).HasColumnType("numeric(7, 4)");

                entity.Property(e => e.Mg1)
                    .HasColumnName("Mg_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Mn).HasColumnType("numeric(10, 4)");

                entity.Property(e => e.Mn1)
                    .HasColumnName("Mn_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Mo).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Mo1)
                    .HasColumnName("Mo_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Na).HasColumnType("numeric(7, 4)");

                entity.Property(e => e.Na1)
                    .HasColumnName("Na_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.P).HasColumnType("numeric(7, 4)");

                entity.Property(e => e.P1)
                    .HasColumnName("P_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Pb).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Pb1)
                    .HasColumnName("Pb_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.Property(e => e.S).HasColumnType("numeric(7, 4)");

                entity.Property(e => e.S1)
                    .HasColumnName("S_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Sb).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Sb1)
                    .HasColumnName("Sb_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Se).HasColumnType("numeric(6, 2)");

                entity.Property(e => e.Se1)
                    .HasColumnName("Se_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Ti).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Ti1)
                    .HasColumnName("Ti_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Zn).HasColumnType("numeric(10, 4)");

                entity.Property(e => e.Zn1)
                    .HasColumnName("Zn_1")
                    .HasColumnType("numeric(7, 2)");
            });

            modelBuilder.Entity<MobAccounts>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("MOB_ACCOUNTS");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccountCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MobAccountusers>(entity =>
            {
                entity.ToTable("MOB_ACCOUNTUSERS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<MobAffiliatesamples>(entity =>
            {
                entity.HasKey(e => e.AffiliateSampleId);

                entity.ToTable("MOB_AFFILIATESAMPLES");

                entity.Property(e => e.AffiliateSampleId).HasColumnName("AffiliateSampleID");

                entity.Property(e => e.AffiliateId).HasColumnName("AffiliateID");

                entity.Property(e => e.SampleEntryId).HasColumnName("SampleEntryID");
            });

            modelBuilder.Entity<MobBarcode>(entity =>
            {
                entity.HasKey(e => e.BarCodeId);

                entity.ToTable("Mob_Barcode");

                entity.Property(e => e.BarCodeId).HasColumnName("BarCodeID");

                entity.Property(e => e.Affiliate)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.BagId)
                    .IsRequired()
                    .HasColumnName("BagID")
                    .HasMaxLength(15);

                entity.Property(e => e.BarCodeNo).HasMaxLength(15);

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommercialName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FarmerCity)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PlantedBusinessEnterprise)
                    .IsRequired()
                    .HasColumnName("Planted_Business_Enterprise")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RowId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Territory)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MobCopyto>(entity =>
            {
                entity.HasKey(e => e.CopyToId);

                entity.ToTable("MOB_COPYTO");

                entity.Property(e => e.CopyToId).HasColumnName("CopyToID");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MobCopytousers>(entity =>
            {
                entity.HasKey(e => e.MobCopyToUserId);

                entity.ToTable("MOB_COPYTOUSERS");

                entity.Property(e => e.MobCopyToUserId).HasColumnName("MobCopyToUserID");

                entity.Property(e => e.CopyToId).HasColumnName("CopyToID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<MobFailedadssamples>(entity =>
            {
                entity.HasKey(e => e.FailSampleId);

                entity.ToTable("MOB_FAILEDADSSAMPLES");

                entity.Property(e => e.FailSampleId).HasColumnName("FailSampleID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.SampleId)
                    .HasColumnName("SampleID")
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MobPackagemappings>(entity =>
            {
                entity.HasKey(e => e.PackageMappingId);

                entity.ToTable("MOB_PACKAGEMAPPINGS");

                entity.Property(e => e.PackageMappingId).HasColumnName("PackageMappingID");

                entity.Property(e => e.PackageMasterName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PackageName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MobSampleAccountMapping>(entity =>
            {
                entity.ToTable("Mob_SampleAccountMapping");

                entity.Property(e => e.MobSampleAccountMappingId).HasColumnName("Mob_SampleAccountMappingId");

                entity.Property(e => e.AccountCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.SampleEntryId).HasColumnName("SampleEntryID");

                entity.HasOne(d => d.SampleEntry)
                    .WithMany(p => p.MobSampleAccountMapping)
                    .HasForeignKey(d => d.SampleEntryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mob_SampleAccountMapping_MOB_SAMPLEENTRY");
            });

            modelBuilder.Entity<MobSamplebags>(entity =>
            {
                entity.HasKey(e => e.BagId);

                entity.ToTable("MOB_SAMPLEBAGS");

                entity.Property(e => e.BagId).HasColumnName("BagID");

                entity.Property(e => e.BagBarcodeNumber).HasMaxLength(8);

                entity.Property(e => e.BagNumber).HasMaxLength(6);

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.MobSamplebags)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_MOB_SAMPLEBAGS_aspnet_Users");
            });

            modelBuilder.Entity<MobSampleentry>(entity =>
            {
                entity.HasKey(e => e.SampleEntryId);

                entity.ToTable("MOB_SAMPLEENTRY");

                entity.Property(e => e.SampleEntryId).HasColumnName("SampleEntryID");

                entity.Property(e => e.AdditionalFee).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.Adssubmission).HasColumnName("ADSSubmission");

                entity.Property(e => e.AmountofSample)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ArrivalDate).HasColumnType("datetime");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CollectedDate).HasColumnType("datetime");

                entity.Property(e => e.CompletedDate).HasColumnType("datetime");

                entity.Property(e => e.CopyTo1Report)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CopyTo2Report)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CopyTo3Report)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CopyTo4Report)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.Cutting)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstimatedDryMatter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FarmName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeedCodeId).HasColumnName("FeedCodeID");

                entity.Property(e => e.FeedName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrindSize).HasMaxLength(20);

                entity.Property(e => e.LabNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Processing).HasMaxLength(100);

                entity.Property(e => e.ReceivingConditionsId).HasColumnName("ReceivingConditionsID");

                entity.Property(e => e.SampleDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SampleId)
                    .HasColumnName("SampleID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SampledDate).HasColumnType("datetime");

                entity.Property(e => e.SequentialNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingTracker).HasMaxLength(500);

                entity.Property(e => e.SourceGroupId).HasColumnName("SourceGroupID");

                entity.Property(e => e.SourceGroupOptionId).HasColumnName("SourceGroupOptionID");

                entity.Property(e => e.StatusTypeId).HasColumnName("StatusTypeID");

                entity.Property(e => e.StorageSystemId).HasColumnName("StorageSystemID");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.Treatment).HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserMemo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.MobSampleentry)
                    .HasForeignKey(d => d.StatusTypeId)
                    .HasConstraintName("FK_MOB_SAMPLEENTRY_STATUSTYPE");
            });

            modelBuilder.Entity<MobSamplenotifications>(entity =>
            {
                entity.HasKey(e => e.NotificationId);

                entity.ToTable("MOB_SAMPLENOTIFICATIONS");

                entity.Property(e => e.NotificationId).HasColumnName("NotificationID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.SampleId)
                    .HasColumnName("SampleID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampleMessage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MobSamplenotifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MOB_SAMPLENOTIFICATIONS_aspnet_Users");
            });

            modelBuilder.Entity<MobSamplesubmissions>(entity =>
            {
                entity.ToTable("MOB_SAMPLESUBMISSIONS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NirClassId).HasColumnName("NirClassID");

                entity.Property(e => e.NirOptionId).HasColumnName("NirOptionID");

                entity.Property(e => e.SampleEntryId).HasColumnName("SampleEntryID");

                entity.Property(e => e.WetChemistryId).HasColumnName("WetChemistryID");

                entity.HasOne(d => d.NirClass)
                    .WithMany(p => p.MobSamplesubmissions)
                    .HasForeignKey(d => d.NirClassId)
                    .HasConstraintName("FK_SAMPLESUBMISSIONS_NIRCLASS");

                entity.HasOne(d => d.NirOption)
                    .WithMany(p => p.MobSamplesubmissions)
                    .HasForeignKey(d => d.NirOptionId)
                    .HasConstraintName("FK_MOB_SAMPLESUBMISSIONS_NIROPTIONS");

                entity.HasOne(d => d.SampleEntry)
                    .WithMany(p => p.MobSamplesubmissions)
                    .HasForeignKey(d => d.SampleEntryId)
                    .HasConstraintName("FK_SAMPLESUBMISSIONS_SAMPLEENTRY");

                entity.HasOne(d => d.WetChemistry)
                    .WithMany(p => p.MobSamplesubmissions)
                    .HasForeignKey(d => d.WetChemistryId)
                    .HasConstraintName("FK_MOB_SAMPLESUBMISSIONS_WETCHEMISTRY");
            });

            modelBuilder.Entity<MobSamplesubmissionsPackages>(entity =>
            {
                entity.ToTable("MOB_SAMPLESUBMISSIONS_PACKAGES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PackageId).HasColumnName("PackageID");

                entity.Property(e => e.SampleEntryId).HasColumnName("SampleEntryID");

                entity.HasOne(d => d.SampleEntry)
                    .WithMany(p => p.MobSamplesubmissionsPackages)
                    .HasForeignKey(d => d.SampleEntryId)
                    .HasConstraintName("FK_MOB_SAMPLESUBMISSIONS_PACKAGES_MOB_SAMPLEENTRY");
            });

            modelBuilder.Entity<MobSourcegroupoptions>(entity =>
            {
                entity.HasKey(e => e.SourceGroupOptionId);

                entity.ToTable("MOB_SOURCEGROUPOPTIONS");

                entity.Property(e => e.SourceGroupOptionId).HasColumnName("SourceGroupOptionID");

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SourceGroupId).HasColumnName("SourceGroupID");

                entity.Property(e => e.SourceGroupOptionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MobSourcegroups>(entity =>
            {
                entity.HasKey(e => e.SourceGroupId);

                entity.ToTable("MOB_SOURCEGROUPS");

                entity.Property(e => e.SourceGroupId).HasColumnName("SourceGroupID");

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SourceGroupName).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<MobSourceharvests>(entity =>
            {
                entity.HasKey(e => e.SourceHarvestId);

                entity.ToTable("MOB_SOURCEHARVESTS");

                entity.Property(e => e.SourceHarvestId).HasColumnName("SourceHarvestID");

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SourceGroupId).HasColumnName("SourceGroupID");

                entity.Property(e => e.SourceHarvestDate).HasColumnType("datetime");

                entity.HasOne(d => d.SourceGroup)
                    .WithMany(p => p.MobSourceharvests)
                    .HasForeignKey(d => d.SourceGroupId)
                    .HasConstraintName("FK_MOB_SOURCEHARVESTS_MOB_SOURCEGROUPS");
            });

            modelBuilder.Entity<MobUserdevices>(entity =>
            {
                entity.HasKey(e => e.UserDeviceId);

                entity.ToTable("MOB_USERDEVICES");

                entity.Property(e => e.UserDeviceId).HasColumnName("UserDeviceID");

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeviceId).HasColumnName("DeviceID");

                entity.Property(e => e.DeviceName).HasMaxLength(500);

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Osversion)
                    .HasColumnName("OSVersion")
                    .HasMaxLength(100);

                entity.Property(e => e.UniqueDeviceId).HasColumnName("UniqueDeviceID");

                entity.Property(e => e.UpdatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Mycotoxins>(entity =>
            {
                entity.HasKey(e => e.MycotoxinId);

                entity.ToTable("MYCOTOXINS");

                entity.Property(e => e.MycotoxinId).HasColumnName("MycotoxinID");

                entity.Property(e => e.DomesticPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DomesticSpecialItemId).HasColumnName("DomesticSpecialItemID");

                entity.Property(e => e.IntSpecialItemId).HasColumnName("IntSpecialItemID");

                entity.Property(e => e.InternationalPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.MycotoxinCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.MycotoxinDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MycotoxinValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.DomesticSpecialItem)
                    .WithMany(p => p.MycotoxinsDomesticSpecialItem)
                    .HasForeignKey(d => d.DomesticSpecialItemId)
                    .HasConstraintName("FK_MYCOTOXINS_SPECIALITEMS");

                entity.HasOne(d => d.IntSpecialItem)
                    .WithMany(p => p.MycotoxinsIntSpecialItem)
                    .HasForeignKey(d => d.IntSpecialItemId)
                    .HasConstraintName("FK_MYCOTOXINS_SPECIALITEMS1");
            });

            modelBuilder.Entity<Ndfd>(entity =>
            {
                entity.ToTable("NDFD");

                entity.HasIndex(e => new { e.NdfdIv12, e.NdfdIv24, e.NdfdIv30, e.NdfdIv48, e.INdf, e.Dmd2, e.NutrecoPd, e.NutrecoIf, e.NdfdIv240, e.ResultsId })
                    .HasName("IX_RESULTID")
                    .IsUnique();

                entity.Property(e => e.Ndfdid).HasColumnName("NDFDID");

                entity.Property(e => e.Dmd2)
                    .HasColumnName("DMD_2")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.INdf)
                    .HasColumnName("iNDF")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.NdfdIv12)
                    .HasColumnName("NDFD_IV_12")
                    .HasColumnType("numeric(6, 3)");

                entity.Property(e => e.NdfdIv120)
                    .HasColumnName("NDFD_IV_120")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NdfdIv18)
                    .HasColumnName("NDFD_IV_18")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NdfdIv2)
                    .HasColumnName("NDFD_IV_2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NdfdIv24)
                    .HasColumnName("NDFD_IV_24")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.NdfdIv240)
                    .HasColumnName("NDFD_IV_240")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NdfdIv2406)
                    .HasColumnName("NDFD_IV_240_6")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NdfdIv246)
                    .HasColumnName("NDFD_IV_24_6")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NdfdIv30)
                    .HasColumnName("NDFD_IV_30")
                    .HasColumnType("numeric(5, 3)");

                entity.Property(e => e.NdfdIv306)
                    .HasColumnName("NDFD_IV_30_6")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NdfdIv4)
                    .HasColumnName("NDFD_IV_4")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NdfdIv48)
                    .HasColumnName("NDFD_IV_48")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.NdfdIv6)
                    .HasColumnName("NDFD_IV_6")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NdfdIv72)
                    .HasColumnName("NDFD_IV_72")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NdfdIv8)
                    .HasColumnName("NDFD_IV_8")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NdfdIv96)
                    .HasColumnName("NDFD_IV_96")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NutrecoIf)
                    .HasColumnName("Nutreco_IF")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.NutrecoPd)
                    .HasColumnName("Nutreco_PD")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.HasOne(d => d.Results)
                    .WithMany(p => p.Ndfd)
                    .HasForeignKey(d => d.ResultsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NDFD_RESULTS");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("NEWS");

                entity.Property(e => e.NewsId).HasColumnName("NewsID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.NewsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_NEWS_aspnet_Users");

                entity.HasOne(d => d.ModifedByNavigation)
                    .WithMany(p => p.NewsModifedByNavigation)
                    .HasForeignKey(d => d.ModifedBy)
                    .HasConstraintName("FK_NEWS_aspnet_Users1");
            });

            modelBuilder.Entity<Newsmedia>(entity =>
            {
                entity.ToTable("NEWSMEDIA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MediaId).HasColumnName("MediaID");

                entity.Property(e => e.NewsId).HasColumnName("NewsID");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Newsmedia)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK_NEWSMEDIA_NEWS");
            });

            modelBuilder.Entity<Nirclass>(entity =>
            {
                entity.ToTable("NIRCLASS");

                entity.Property(e => e.NirClassId).HasColumnName("NirClassID");

                entity.Property(e => e.DomesticPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.InternationalPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NirClassDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NirClassName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NirClassNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nirdata>(entity =>
            {
                entity.ToTable("NIRDATA");

                entity.HasIndex(e => new { e.Gh, e.NSp, e.NButyric, e.NTitAc, e.NANdf, e.NNdfdIv30, e.NNdfdIv240, e.NIvsd74, e.NAsh, e.NNitrate, e.NTdon, e.NNdfom, e.NNdfomR, e.NPr, e.NNdr, e.Batch, e.Code, e.NirDataId })
                    .HasName("IX_BATCHCODE")
                    .IsUnique();

                entity.Property(e => e.NirDataId).HasColumnName("NirDataID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.Eq)
                    .HasColumnName("EQ")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Gh)
                    .HasColumnName("GH")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Mn)
                    .HasColumnName("MN")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NANdf)
                    .HasColumnName("N_aNDF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NAcetic)
                    .HasColumnName("N_Acetic")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NAdf)
                    .HasColumnName("N_ADF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NAdicp)
                    .HasColumnName("N_ADICP")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NAsh)
                    .HasColumnName("N_Ash")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NButyric)
                    .HasColumnName("N_Butyric")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NC12)
                    .HasColumnName("N_C12")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NC130)
                    .HasColumnName("N_C13_0")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NC140)
                    .HasColumnName("N_C14_0")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NC16)
                    .HasColumnName("N_C16")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NC161)
                    .HasColumnName("N_C16_1")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NC170)
                    .HasColumnName("N_C17_0")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NC18)
                    .HasColumnName("N_C18")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NC181)
                    .HasColumnName("N_C18_1")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NC182)
                    .HasColumnName("N_C18_2")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NC183)
                    .HasColumnName("N_C18_3")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NC200)
                    .HasColumnName("N_C20_0")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NC220)
                    .HasColumnName("N_C22_0")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NCa)
                    .HasColumnName("N_CA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NCf)
                    .HasColumnName("N_CF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NCl)
                    .HasColumnName("N_CL")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NCp)
                    .HasColumnName("N_CP")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NDmRes)
                    .HasColumnName("N_DM_Res")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NDmd2)
                    .HasColumnName("N_DMD_2")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NDp)
                    .HasColumnName("N_DP")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NFatEe)
                    .HasColumnName("N_Fat_EE")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NFe)
                    .HasColumnName("N_Fe")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.NINdf)
                    .HasColumnName("N_iNDF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NIsoButyric)
                    .HasColumnName("N_Iso_Butyric")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NIvsd72)
                    .HasColumnName("N_IVSD_7_2")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NIvsd74)
                    .HasColumnName("N_IVSD_7_4")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NK)
                    .HasColumnName("N_K")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NLactic)
                    .HasColumnName("N_Lactic")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NLignin)
                    .HasColumnName("N_Lignin")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NMg)
                    .HasColumnName("N_MG")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNa)
                    .HasColumnName("N_NA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdfdIv12)
                    .HasColumnName("N_NDFD_IV_12")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdfdIv24)
                    .HasColumnName("N_NDFD_IV_24")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdfdIv240)
                    .HasColumnName("N_NDFD_IV_240")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdfdIv30)
                    .HasColumnName("N_NDFD_IV_30")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdfdIv48)
                    .HasColumnName("N_NDFD_IV_48")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdfom)
                    .HasColumnName("N_NDFom")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NNdfomR)
                    .HasColumnName("N_NDFomR")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NNdicp)
                    .HasColumnName("N_NDICP")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdicpns)
                    .HasColumnName("N_NDICPns")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdr)
                    .HasColumnName("N_NDR")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNh3cpe)
                    .HasColumnName("N_NH3CPE")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNitrate)
                    .HasColumnName("N_Nitrate")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NNutrecoIf)
                    .HasColumnName("N_Nutreco_IF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNutrecoPd)
                    .HasColumnName("N_Nutreco_PD")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NP)
                    .HasColumnName("N_P")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NPH)
                    .HasColumnName("N_pH")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.NPl)
                    .HasColumnName("N_PL")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NPr)
                    .HasColumnName("N_PR")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NPropionic)
                    .HasColumnName("N_Propionic")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NS)
                    .HasColumnName("N_S")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NSatFat)
                    .HasColumnName("N_SatFat")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NSolFiber)
                    .HasColumnName("N_Sol_Fiber")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NSp)
                    .HasColumnName("N_SP")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NStarch)
                    .HasColumnName("N_Starch")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NStarchEa)
                    .HasColumnName("N_Starch_EA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NStrepG)
                    .HasColumnName("N_StrepG")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NSugarEsc)
                    .HasColumnName("N_Sugar_ESC")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NTdon)
                    .HasColumnName("N_Tdon")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NTfa)
                    .HasColumnName("N_TFA")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NTitAc)
                    .HasColumnName("N_Tit_Ac")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NTotVfa)
                    .HasColumnName("N_TotVFA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NUnsatFat)
                    .HasColumnName("N_UnsatFat")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NVtox)
                    .HasColumnName("N_Vtox")
                    .HasColumnType("decimal(6, 3)");
            });

            modelBuilder.Entity<NirdataFileimport>(entity =>
            {
                entity.ToTable("NIRDATA_FILEIMPORT");

                entity.Property(e => e.NirDataFileImportId).HasColumnName("NirDataFileImportID");

                entity.Property(e => e.Batch)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Eq)
                    .HasColumnName("EQ")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Gh)
                    .HasColumnName("GH")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Mn)
                    .HasColumnName("MN")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NANdf)
                    .HasColumnName("N_aNDF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NAcetic)
                    .HasColumnName("N_Acetic")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NAdf)
                    .HasColumnName("N_ADF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NAdicp)
                    .HasColumnName("N_ADICP")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NAsh)
                    .HasColumnName("N_Ash")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NButyric)
                    .HasColumnName("N_Butyric")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NCa)
                    .HasColumnName("N_CA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NCf)
                    .HasColumnName("N_CF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NCl)
                    .HasColumnName("N_CL")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NCp)
                    .HasColumnName("N_CP")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NDmRes)
                    .HasColumnName("N_DM_Res")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NDmd2)
                    .HasColumnName("N_DMD_2")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NFatEe)
                    .HasColumnName("N_Fat_EE")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NFe)
                    .HasColumnName("N_Fe")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.NINdf)
                    .HasColumnName("N_iNDF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NIsoButyric)
                    .HasColumnName("N_Iso_Butyric")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NIvsd72)
                    .HasColumnName("N_IVSD_7_2")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NIvsd74)
                    .HasColumnName("N_IVSD_7_4")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NK)
                    .HasColumnName("N_K")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NLactic)
                    .HasColumnName("N_Lactic")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NLignin)
                    .HasColumnName("N_Lignin")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NMg)
                    .HasColumnName("N_MG")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNa)
                    .HasColumnName("N_NA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdfdIv12)
                    .HasColumnName("N_NDFD_IV_12")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdfdIv24)
                    .HasColumnName("N_NDFD_IV_24")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdfdIv30)
                    .HasColumnName("N_NDFD_IV_30")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdfdIv48)
                    .HasColumnName("N_NDFD_IV_48")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdicp)
                    .HasColumnName("N_NDICP")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdicpnnp)
                    .HasColumnName("N_NDICPnnp")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdrom)
                    .HasColumnName("N_NDRom")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNh3pe)
                    .HasColumnName("N_NH3Pe")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNutrecoIf)
                    .HasColumnName("N_Nutreco_IF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNutrecoPd)
                    .HasColumnName("N_Nutreco_PD")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NP)
                    .HasColumnName("N_P")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NPH)
                    .HasColumnName("N_pH")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.NS)
                    .HasColumnName("N_S")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NSolFiber)
                    .HasColumnName("N_Sol_Fiber")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NSp)
                    .HasColumnName("N_SP")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NStarch)
                    .HasColumnName("N_Starch")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NStarchEa)
                    .HasColumnName("N_Starch_EA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NSugarEsc)
                    .HasColumnName("N_Sugar_ESC")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NTfa)
                    .HasColumnName("N_TFA")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NTitAc)
                    .HasColumnName("N_Tit_Ac")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NTotVfa)
                    .HasColumnName("N_TotVFA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");
            });

            modelBuilder.Entity<NirdataMdistNdist>(entity =>
            {
                entity.HasKey(e => e.NirDataNmdistId);

                entity.ToTable("NIRDATA_MDIST_NDIST");

                entity.Property(e => e.NirDataNmdistId).HasColumnName("NirDataNMDistID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.GhMDist)
                    .HasColumnName("GH_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.GhNDist)
                    .HasColumnName("GH_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NANdfMDist)
                    .HasColumnName("N_aNDF_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NANdfNDist)
                    .HasColumnName("N_aNDF_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NAceticMDist)
                    .HasColumnName("N_Acetic_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NAceticNDist)
                    .HasColumnName("N_Acetic_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NAdfMDist)
                    .HasColumnName("N_ADF_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NAdfNDist)
                    .HasColumnName("N_ADF_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NAdicpMDist)
                    .HasColumnName("N_ADICP_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NAdicpNDist)
                    .HasColumnName("N_ADICP_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NAshMDist)
                    .HasColumnName("N_Ash_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NAshNDist)
                    .HasColumnName("N_Ash_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NButyricMDist)
                    .HasColumnName("N_Butyric_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NButyricNDist)
                    .HasColumnName("N_Butyric_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC12MDist)
                    .HasColumnName("N_C12_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC12NDist)
                    .HasColumnName("N_C12_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC130MDist)
                    .HasColumnName("N_C13_0_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC130NDist)
                    .HasColumnName("N_C13_0_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC140MDist)
                    .HasColumnName("N_C14_0_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC140NDist)
                    .HasColumnName("N_C14_0_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC161MDist)
                    .HasColumnName("N_C16_1_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC161NDist)
                    .HasColumnName("N_C16_1_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC16MDist)
                    .HasColumnName("N_C16_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC16NDist)
                    .HasColumnName("N_C16_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC170MDist)
                    .HasColumnName("N_C17_0_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC170NDist)
                    .HasColumnName("N_C17_0_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC181MDist)
                    .HasColumnName("N_C18_1_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC181NDist)
                    .HasColumnName("N_C18_1_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC182MDist)
                    .HasColumnName("N_C18_2_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC182NDist)
                    .HasColumnName("N_C18_2_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC183MDist)
                    .HasColumnName("N_C18_3_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC183NDist)
                    .HasColumnName("N_C18_3_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC18MDist)
                    .HasColumnName("N_C18_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC18NDist)
                    .HasColumnName("N_C18_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC200MDist)
                    .HasColumnName("N_C20_0_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC200NDist)
                    .HasColumnName("N_C20_0_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC220MDist)
                    .HasColumnName("N_C22_0_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NC220NDist)
                    .HasColumnName("N_C22_0_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NCaMDist)
                    .HasColumnName("N_CA_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NCaNDist)
                    .HasColumnName("N_CA_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NCfMDist)
                    .HasColumnName("N_CF_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NCfNDist)
                    .HasColumnName("N_CF_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NClMDist)
                    .HasColumnName("N_CL_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NClNDist)
                    .HasColumnName("N_CL_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NCpMDist)
                    .HasColumnName("N_CP_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NCpNDist)
                    .HasColumnName("N_CP_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NDmResMDist)
                    .HasColumnName("N_DM_Res_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NDmResNDist)
                    .HasColumnName("N_DM_Res_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NDmd2MDist)
                    .HasColumnName("N_DMD_2_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NDmd2NDist)
                    .HasColumnName("N_DMD_2_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NDpMDist)
                    .HasColumnName("N_DP_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NDpNDist)
                    .HasColumnName("N_DP_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NFatEeMDist)
                    .HasColumnName("N_Fat_EE_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NFatEeNDist)
                    .HasColumnName("N_Fat_EE_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NFeMDist)
                    .HasColumnName("N_Fe_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NFeNDist)
                    .HasColumnName("N_Fe_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NINdfMDist)
                    .HasColumnName("N_iNDF_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NINdfNDist)
                    .HasColumnName("N_iNDF_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NIsoButyricMDist)
                    .HasColumnName("N_Iso_Butyric_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NIsoButyricNDist)
                    .HasColumnName("N_Iso_Butyric_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NIvsd72MDist)
                    .HasColumnName("N_IVSD_7_2_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NIvsd72NDist)
                    .HasColumnName("N_IVSD_7_2_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NIvsd74MDist)
                    .HasColumnName("N_IVSD_7_4_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NIvsd74NDist)
                    .HasColumnName("N_IVSD_7_4_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NKMDist)
                    .HasColumnName("N_K_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NKNDist)
                    .HasColumnName("N_K_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NLacticMDist)
                    .HasColumnName("N_Lactic_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NLacticNDist)
                    .HasColumnName("N_Lactic_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NLigninMDist)
                    .HasColumnName("N_Lignin_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NLigninNDist)
                    .HasColumnName("N_Lignin_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NMgMDist)
                    .HasColumnName("N_MG_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NMgNDist)
                    .HasColumnName("N_MG_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNaMDist)
                    .HasColumnName("N_NA_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNaNDist)
                    .HasColumnName("N_NA_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdfdIv12MDist)
                    .HasColumnName("N_NDFD_IV_12_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdfdIv12NDist)
                    .HasColumnName("N_NDFD_IV_12_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdfdIv240MDist)
                    .HasColumnName("N_NDFD_IV_240_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdfdIv240NDist)
                    .HasColumnName("N_NDFD_IV_240_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdfdIv24MDist)
                    .HasColumnName("N_NDFD_IV_24_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdfdIv24NDist)
                    .HasColumnName("N_NDFD_IV_24_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdfdIv30MDist)
                    .HasColumnName("N_NDFD_IV_30_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdfdIv30NDist)
                    .HasColumnName("N_NDFD_IV_30_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdfdIv48MDist)
                    .HasColumnName("N_NDFD_IV_48_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdfdIv48NDist)
                    .HasColumnName("N_NDFD_IV_48_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdfomMDist)
                    .HasColumnName("N_NDFom_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdfomNDist)
                    .HasColumnName("N_NDFom_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdfomRMDist)
                    .HasColumnName("N_NDFomR_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdfomRNDist)
                    .HasColumnName("N_NDFomR_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdicpMDist)
                    .HasColumnName("N_NDICP_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdicpNDist)
                    .HasColumnName("N_NDICP_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdicpnsMDist)
                    .HasColumnName("N_NDICPns_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdicpnsNDist)
                    .HasColumnName("N_NDICPns_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdrMDist)
                    .HasColumnName("N_NDR_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNdrNDist)
                    .HasColumnName("N_NDR_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNh3cpeMDist)
                    .HasColumnName("N_NH3CPE_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNh3cpeNDist)
                    .HasColumnName("N_NH3CPE_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNitrateMDist)
                    .HasColumnName("N_Nitrate_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNitrateNDist)
                    .HasColumnName("N_Nitrate_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNutrecoIfMDist)
                    .HasColumnName("N_Nutreco_IF_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNutrecoIfNDist)
                    .HasColumnName("N_Nutreco_IF_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNutrecoPdMDist)
                    .HasColumnName("N_Nutreco_PD_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NNutrecoPdNDist)
                    .HasColumnName("N_Nutreco_PD_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NPHMDist)
                    .HasColumnName("N_pH_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NPHNDist)
                    .HasColumnName("N_pH_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NPMDist)
                    .HasColumnName("N_P_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NPNDist)
                    .HasColumnName("N_P_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NPlMDist)
                    .HasColumnName("N_PL_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NPlNDist)
                    .HasColumnName("N_PL_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NPrMDist)
                    .HasColumnName("N_PR_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NPrNDist)
                    .HasColumnName("N_PR_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NPropionicMDist)
                    .HasColumnName("N_Propionic_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NPropionicNDist)
                    .HasColumnName("N_Propionic_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NSMDist)
                    .HasColumnName("N_S_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NSNDist)
                    .HasColumnName("N_S_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NSatFatMDist)
                    .HasColumnName("N_SatFat_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NSatFatNDist)
                    .HasColumnName("N_SatFat_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NSolFiberMDist)
                    .HasColumnName("N_Sol_Fiber_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NSolFiberNDist)
                    .HasColumnName("N_Sol_Fiber_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NSpMDist)
                    .HasColumnName("N_SP_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NSpNDist)
                    .HasColumnName("N_SP_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NStarchEaMDist)
                    .HasColumnName("N_Starch_EA_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NStarchEaNDist)
                    .HasColumnName("N_Starch_EA_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NStarchMDist)
                    .HasColumnName("N_Starch_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NStarchNDist)
                    .HasColumnName("N_Starch_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NStrepGMDist)
                    .HasColumnName("N_StrepG_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NStrepGNDist)
                    .HasColumnName("N_StrepG_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NSugarMDist)
                    .HasColumnName("N_Sugar_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NSugarNDist)
                    .HasColumnName("N_Sugar_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NTdonMDist)
                    .HasColumnName("N_Tdon_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NTdonNDist)
                    .HasColumnName("N_Tdon_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NTfaMDist)
                    .HasColumnName("N_TFA_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NTfaNDist)
                    .HasColumnName("N_TFA_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NTitAcMDist)
                    .HasColumnName("N_Tit_Ac_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NTitAcNDist)
                    .HasColumnName("N_Tit_Ac_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NTotVfaMDist)
                    .HasColumnName("N_TotVFA_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NTotVfaNDist)
                    .HasColumnName("N_TotVFA_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NUnsatFatMDist)
                    .HasColumnName("N_UnsatFat_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NUnsatFatNDist)
                    .HasColumnName("N_UnsatFat_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NVtoxMDist)
                    .HasColumnName("N_Vtox_M_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NVtoxNDist)
                    .HasColumnName("N_Vtox_N_Dist")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NirDataId).HasColumnName("NirDataID");
            });

            modelBuilder.Entity<Nirequations>(entity =>
            {
                entity.HasKey(e => e.NirequationId);

                entity.ToTable("NIREQUATIONS");

                entity.Property(e => e.NirequationId)
                    .HasColumnName("NIREquationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Equation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShortCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Niroptions>(entity =>
            {
                entity.HasKey(e => e.NirOptionId);

                entity.ToTable("NIROPTIONS");

                entity.Property(e => e.NirOptionId).HasColumnName("NirOptionID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DomesticPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.InternationalPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.NirOptionCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NirOptionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.HasKey(e => e.NoteId);

                entity.ToTable("NOTES");

                entity.HasIndex(e => new { e.Note, e.NoteId })
                    .HasName("_dta_index_NOTES_8_1796201449__K1_2");

                entity.Property(e => e.NoteId).HasColumnName("NoteID");

                entity.Property(e => e.Note).HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<PackageInfo>(entity =>
            {
                entity.HasKey(e => e.IdColumn);

                entity.Property(e => e.IdColumn).HasColumnName("ID_column");

                entity.Property(e => e.AgClassId).HasColumnName("AgClassID");

                entity.Property(e => e.ChemClassId).HasColumnName("ChemClassID");

                entity.Property(e => e.NirClassId).HasColumnName("NirClassID");

                entity.Property(e => e.PackageName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Planttissueanalysis>(entity =>
            {
                entity.HasKey(e => e.PlantTissueId);

                entity.ToTable("PLANTTISSUEANALYSIS");

                entity.Property(e => e.PlantTissueId).HasColumnName("PlantTissueID");

                entity.Property(e => e.DomesticPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DomesticSpecialItemId).HasColumnName("DomesticSpecialItemID");

                entity.Property(e => e.IntSpecialItemId).HasColumnName("IntSpecialItemID");

                entity.Property(e => e.InternationalPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PlantTissueCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PlantTissueDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PlantTissueValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.DomesticSpecialItem)
                    .WithMany(p => p.PlanttissueanalysisDomesticSpecialItem)
                    .HasForeignKey(d => d.DomesticSpecialItemId)
                    .HasConstraintName("FK_PLANTTISSUEANALYSIS_SPECIALITEMS");

                entity.HasOne(d => d.IntSpecialItem)
                    .WithMany(p => p.PlanttissueanalysisIntSpecialItem)
                    .HasForeignKey(d => d.IntSpecialItemId)
                    .HasConstraintName("FK_PLANTTISSUEANALYSIS_SPECIALITEMS1");
            });

            modelBuilder.Entity<PrcPricing>(entity =>
            {
                entity.HasKey(e => e.PricingId);

                entity.ToTable("PrcPRICING");

                entity.Property(e => e.PricingId).HasColumnName("PricingID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DomesticPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.InternationPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.PackageDetail)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PackageName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TestTypeId).HasColumnName("TestTypeID");
            });

            modelBuilder.Entity<PrcTesttype>(entity =>
            {
                entity.HasKey(e => e.TestTypeId);

                entity.ToTable("PrcTESTTYPE");

                entity.Property(e => e.TestTypeId).HasColumnName("TestTypeID");

                entity.Property(e => e.TestDesription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TestType)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Processing>(entity =>
            {
                entity.ToTable("PROCESSING");

                entity.Property(e => e.ProcessingId).HasColumnName("ProcessingID");

                entity.Property(e => e.Cname)
                    .HasColumnName("CName")
                    .HasMaxLength(50);

                entity.Property(e => e.Cvalue)
                    .HasColumnName("CValue")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Processlog>(entity =>
            {
                entity.ToTable("PROCESSLOG");

                entity.Property(e => e.ProcessLogId).HasColumnName("ProcessLogID");

                entity.Property(e => e.ProcessDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProcessDescription).HasMaxLength(150);

                entity.Property(e => e.ProcessError).HasMaxLength(500);

                entity.Property(e => e.ProcessName).HasMaxLength(50);
            });

            modelBuilder.Entity<Prodname>(entity =>
            {
                entity.ToTable("PRODNAME");

                entity.Property(e => e.ProdNameId).HasColumnName("ProdNameID");

                entity.Property(e => e.Cname)
                    .HasColumnName("CName")
                    .HasMaxLength(50);

                entity.Property(e => e.Cvalue)
                    .HasColumnName("CValue")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Proteins>(entity =>
            {
                entity.ToTable("PROTEINS");

                entity.HasIndex(e => new { e.Cp, e.Sp, e.Adicp, e.Ndicp, e.Nh3cpe, e.ResultsId })
                    .HasName("IX_RESULTID")
                    .IsUnique();

                entity.Property(e => e.ProteinsId).HasColumnName("ProteinsID");

                entity.Property(e => e.Adicp)
                    .HasColumnName("ADICP")
                    .HasColumnType("numeric(6, 3)");

                entity.Property(e => e.Cp)
                    .HasColumnName("CP")
                    .HasColumnType("numeric(7, 3)");

                entity.Property(e => e.Ndicp)
                    .HasColumnName("NDICP")
                    .HasColumnType("numeric(7, 4)");

                entity.Property(e => e.Nh3cpe)
                    .HasColumnName("NH3CPE")
                    .HasColumnType("numeric(6, 3)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.Property(e => e.Sp)
                    .HasColumnName("SP")
                    .HasColumnType("numeric(7, 3)");
            });

            modelBuilder.Entity<Proximate>(entity =>
            {
                entity.ToTable("PROXIMATE");

                entity.Property(e => e.ProximateId).HasColumnName("ProximateID");

                entity.Property(e => e.DomesticPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DomesticSpecialItemId).HasColumnName("DomesticSpecialItemID");

                entity.Property(e => e.IntSpecialItemId).HasColumnName("IntSpecialItemID");

                entity.Property(e => e.InternationalPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ProximateCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ProximateDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProximateValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.DomesticSpecialItem)
                    .WithMany(p => p.ProximateDomesticSpecialItem)
                    .HasForeignKey(d => d.DomesticSpecialItemId)
                    .HasConstraintName("FK_PROXIMATE_SPECIALITEMS");

                entity.HasOne(d => d.IntSpecialItem)
                    .WithMany(p => p.ProximateIntSpecialItem)
                    .HasForeignKey(d => d.IntSpecialItemId)
                    .HasConstraintName("FK_PROXIMATE_SPECIALITEMS1");
            });

            modelBuilder.Entity<Qualitative>(entity =>
            {
                entity.ToTable("QUALITATIVE");

                entity.HasIndex(e => new { e.No3nppm, e.Ph, e.Csps, e.PsSieve1, e.PsSieve2, e.PsSieve3, e.ResultsId })
                    .HasName("IX_RESULTID")
                    .IsUnique();

                entity.Property(e => e.QualitativeId).HasColumnName("QualitativeID");

                entity.Property(e => e.AverageParticleSize).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Csps)
                    .HasColumnName("CSPS")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.CumulativeBottomPan).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.CumulativeLower).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.CumulativeMiddle).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.CumulativeUpper).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.No3nppm)
                    .HasColumnName("NO3Nppm")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Ph)
                    .HasColumnName("ph")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.PsSieve1)
                    .HasColumnName("PS_Sieve1")
                    .HasColumnType("decimal(5, 1)");

                entity.Property(e => e.PsSieve2)
                    .HasColumnName("PS_Sieve2")
                    .HasColumnType("decimal(5, 1)");

                entity.Property(e => e.PsSieve3)
                    .HasColumnName("PS_Sieve3")
                    .HasColumnType("decimal(5, 1)");

                entity.Property(e => e.PsSieve4)
                    .HasColumnName("PS_Sieve4")
                    .HasColumnType("decimal(5, 1)");

                entity.Property(e => e.RemainingBottomPan).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.RemainingLower).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.RemainingMiddle).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.RemainingUpper).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.Property(e => e.StandardDeviation).HasColumnType("decimal(5, 3)");

                entity.HasOne(d => d.Results)
                    .WithMany(p => p.Qualitative)
                    .HasForeignKey(d => d.ResultsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QUALITATIVE_RESULTS");
            });

            modelBuilder.Entity<RangeFeedCodes>(entity =>
            {
                entity.HasKey(e => e.FeedCodeId);

                entity.ToTable("RANGE_FEED_CODES");

                entity.Property(e => e.Condition)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FeedType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeedTypeSearch)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsRangeResult).HasColumnName("isRangeResult");

                entity.Property(e => e.IsSampleDesc).HasColumnName("isSampleDesc");

                entity.Property(e => e.SampleDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SqlCondition)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SqlJoin)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RangeFeedCodesNir>(entity =>
            {
                entity.HasKey(e => e.FeedCodeId);

                entity.ToTable("RANGE_FEED_CODES_NIR");

                entity.Property(e => e.Condition)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FeedType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeedTypeSearch)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsRangeResult).HasColumnName("isRangeResult");

                entity.Property(e => e.IsSampleDesc).HasColumnName("isSampleDesc");

                entity.Property(e => e.SampleDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SqlCondition)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SqlJoin)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RangeResult>(entity =>
            {
                entity.ToTable("RANGE_RESULT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ColAvg)
                    .HasColumnName("Col_Avg")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ColBottom)
                    .HasColumnName("Col_Bottom")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ColMax)
                    .HasColumnName("Col_Max")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ColMin)
                    .HasColumnName("Col_Min")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ColStd)
                    .HasColumnName("Col_Std")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ColTop)
                    .HasColumnName("Col_Top")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Designator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DmHigh).HasColumnName("DM_High");

                entity.Property(e => e.DmLow).HasColumnName("DM_Low");

                entity.Property(e => e.FeedType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampleDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SqlCondition)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SqlJoin)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Std2).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.TableName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RangeResultIFerm>(entity =>
            {
                entity.ToTable("RANGE_RESULT_I_Ferm");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ColAvg)
                    .HasColumnName("Col_Avg")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ColBottom)
                    .HasColumnName("Col_Bottom")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ColMax)
                    .HasColumnName("Col_Max")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ColMin)
                    .HasColumnName("Col_Min")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ColStd)
                    .HasColumnName("Col_Std")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ColTop)
                    .HasColumnName("Col_Top")
                    .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Designator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DmHigh).HasColumnName("DM_High");

                entity.Property(e => e.DmLow).HasColumnName("DM_Low");

                entity.Property(e => e.FeedType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampleDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SqlCondition)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SqlJoin)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Std2).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.TableName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RangeResultNewLive>(entity =>
            {
                entity.ToTable("RANGE_RESULT_NEW_LIVE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ColAvg)
                    .HasColumnName("Col_Avg")
                    .HasColumnType("decimal(20, 2)");

                entity.Property(e => e.ColBottom)
                    .HasColumnName("Col_Bottom")
                    .HasColumnType("decimal(20, 2)");

                entity.Property(e => e.ColMax)
                    .HasColumnName("Col_Max")
                    .HasColumnType("decimal(20, 2)");

                entity.Property(e => e.ColMin)
                    .HasColumnName("Col_Min")
                    .HasColumnType("decimal(20, 2)");

                entity.Property(e => e.ColStd)
                    .HasColumnName("Col_Std")
                    .HasColumnType("decimal(20, 2)");

                entity.Property(e => e.ColTop)
                    .HasColumnName("Col_Top")
                    .HasColumnType("decimal(20, 2)");

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Designator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DmHigh).HasColumnName("DM_High");

                entity.Property(e => e.DmLow).HasColumnName("DM_Low");

                entity.Property(e => e.FeedType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampleDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SqlCondition)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SqlJoin)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Std2).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.TableName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RangeResultNutrient>(entity =>
            {
                entity.ToTable("RANGE_RESULT_NUTRIENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ColAvg).HasColumnName("Col_Avg");

                entity.Property(e => e.ColBottom).HasColumnName("Col_Bottom");

                entity.Property(e => e.ColMax).HasColumnName("Col_Max");

                entity.Property(e => e.ColMin).HasColumnName("Col_Min");

                entity.Property(e => e.ColStd).HasColumnName("Col_Std");

                entity.Property(e => e.ColTop).HasColumnName("Col_Top");

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Designator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DmHigh).HasColumnName("DM_High");

                entity.Property(e => e.DmLow).HasColumnName("DM_Low");

                entity.Property(e => e.FeedType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampleDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SqlCondition)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SqlJoin)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Std2).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.TableName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RangeTables>(entity =>
            {
                entity.HasKey(e => e.TableId);

                entity.ToTable("RANGE_TABLES");

                entity.Property(e => e.TableId).HasColumnName("TableID");

                entity.Property(e => e.IsRangeResult).HasColumnName("isRangeResult");

                entity.Property(e => e.TableDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TablePrimaryKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RangeTablesColumns>(entity =>
            {
                entity.HasKey(e => e.ResultsTableColumnId);

                entity.ToTable("RANGE_TABLES_COLUMNS");

                entity.Property(e => e.ResultsTableColumnId).HasColumnName("ResultsTableColumnID");

                entity.Property(e => e.ColumnDescription).HasMaxLength(255);

                entity.Property(e => e.ColumnName).HasMaxLength(255);

                entity.Property(e => e.IsRangeResult).HasColumnName("isRangeResult");

                entity.Property(e => e.TableId).HasColumnName("TableID");
            });

            modelBuilder.Entity<RationUseraccess>(entity =>
            {
                entity.ToTable("RATION_USERACCESS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastAccess).HasColumnType("datetime");

                entity.Property(e => e.MethodName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RationUseraccess)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RATION_USERACCESS_aspnet_Users");
            });

            modelBuilder.Entity<Rawdata>(entity =>
            {
                entity.ToTable("RAWDATA");

                entity.Property(e => e.RawDataId)
                    .HasColumnName("RawDataID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdfBag)
                    .HasColumnName("ADF_BAG")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.AdfBagsm)
                    .HasColumnName("ADF_BAGSM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.AdfBagtr)
                    .HasColumnName("ADF_BAGTR")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.AdfPc)
                    .HasColumnName("ADF_PC")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.AshCru)
                    .HasColumnName("ASH_CRU")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.AshCrusm)
                    .HasColumnName("ASH_CRUSM")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.AshSm)
                    .HasColumnName("ASH_SM")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.CalculatedAdf)
                    .HasColumnName("CalculatedADF")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.CalculatedAdin)
                    .HasColumnName("CalculatedADIN")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.CalculatedAsh).HasColumnType("decimal(8, 4)");

                entity.Property(e => e.CalculatedCp)
                    .HasColumnName("CalculatedCP")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.CalculatedFat).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.CalculatedLignin).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.CalculatedNdf)
                    .HasColumnName("CalculatedNDF")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.CalculatedNdin)
                    .HasColumnName("CalculatedNDIN")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.CalculatedStarch).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.FatCru)
                    .HasColumnName("FAT_CRU")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.FatCrusm)
                    .HasColumnName("FAT_CRUSM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.FatSm)
                    .HasColumnName("FAT_SM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Hygro).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.LigCruash)
                    .HasColumnName("LIG_CRUASH")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.LigCrusm)
                    .HasColumnName("LIG_CRUSM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.LigSm)
                    .HasColumnName("LIG_SM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.NdfBag)
                    .HasColumnName("NDF_BAG")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.NdfBagsm)
                    .HasColumnName("NDF_BAGSM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.NdfBagtr)
                    .HasColumnName("NDF_BAGTR")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.NdfPc)
                    .HasColumnName("NDF_PC")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Pro1Pc)
                    .HasColumnName("PRO1_PC")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Pro1Sm)
                    .HasColumnName("PRO1_SM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Ps1)
                    .HasColumnName("PS_1")
                    .HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Ps2)
                    .HasColumnName("PS_2")
                    .HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Ps3)
                    .HasColumnName("PS_3")
                    .HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Ps4)
                    .HasColumnName("PS_4")
                    .HasColumnType("decimal(5, 1)");

                entity.Property(e => e.SamplesId).HasColumnName("SamplesID");

                entity.Property(e => e.SproBag)
                    .HasColumnName("SPRO_BAG")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.SproBagsm)
                    .HasColumnName("SPRO_BAGSM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.SproPc)
                    .HasColumnName("SPRO_PC")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.SproSm)
                    .HasColumnName("SPRO_SM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.StrchBl)
                    .HasColumnName("STRCH_BL")
                    .HasColumnType("decimal(7, 0)");

                entity.Property(e => e.StrchPc)
                    .HasColumnName("STRCH_PC")
                    .HasColumnType("decimal(7, 0)");

                entity.Property(e => e.StrchWt)
                    .HasColumnName("STRCH_WT")
                    .HasColumnType("decimal(7, 4)");

                entity.HasOne(d => d.RawData)
                    .WithOne(p => p.InverseRawData)
                    .HasForeignKey<Rawdata>(d => d.RawDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RAWDATA_RAWDATA");
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.ToTable("REGIONS");

                entity.Property(e => e.RegionsId).HasColumnName("RegionsID");

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RegionsName).HasMaxLength(50);
            });

            modelBuilder.Entity<Regionstates>(entity =>
            {
                entity.HasKey(e => e.RegionStateId);

                entity.ToTable("REGIONSTATES");

                entity.Property(e => e.RegionStateId).HasColumnName("RegionStateID");

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RegionsId).HasColumnName("RegionsID");

                entity.Property(e => e.RegionsStateDescription).HasMaxLength(50);

                entity.Property(e => e.RegionsStateName).HasMaxLength(50);
            });

            modelBuilder.Entity<ReportFormPreferences>(entity =>
            {
                entity.HasKey(e => e.PreferenceId);

                entity.ToTable("REPORT_FORM_PREFERENCES");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ReportForm)
                    .HasColumnName("Report_Form")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReportingAccounts>(entity =>
            {
                entity.ToTable("REPORTING_ACCOUNTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.ReportingAccounts)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REPORTING_ACCOUNTS_LANGUAGES");
            });

            modelBuilder.Entity<ReportingColumns>(entity =>
            {
                entity.HasKey(e => e.CustomPreferenceColumnId);

                entity.ToTable("REPORTING_COLUMNS");

                entity.Property(e => e.CustomPreferenceColumnId).HasColumnName("CustomPreferenceColumnID");

                entity.Property(e => e.ColumnName).HasMaxLength(255);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<ReportingCustompreference>(entity =>
            {
                entity.HasKey(e => e.CustomPreferenceId);

                entity.ToTable("REPORTING_CUSTOMPREFERENCE");

                entity.Property(e => e.CustomPreferenceId)
                    .HasColumnName("CustomPreferenceID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ReportName).HasMaxLength(100);

                entity.HasOne(d => d.CustomPreference)
                    .WithOne(p => p.InverseCustomPreference)
                    .HasForeignKey<ReportingCustompreference>(d => d.CustomPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REPORTING_CUSTOMPREFERENCE_REPORTING_CUSTOMPREFERENCE");
            });

            modelBuilder.Entity<ReportingCustomPreferenceDetails>(entity =>
            {
                entity.HasKey(e => e.CustomPreferenceDetailsId);

                entity.ToTable("REPORTING_CUSTOM_PREFERENCE_DETAILS");

                entity.Property(e => e.CustomPreferenceDetailsId).HasColumnName("CustomPreferenceDetailsID");

                entity.Property(e => e.CustomPreferenceColumnId).HasColumnName("CustomPreferenceColumnID");

                entity.Property(e => e.CustomPreferenceId).HasColumnName("CustomPreferenceID");

                entity.HasOne(d => d.CustomPreference)
                    .WithMany(p => p.ReportingCustomPreferenceDetails)
                    .HasForeignKey(d => d.CustomPreferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REPORTING_CUSTOM_PREFERENCE_DETAILS_REPORTING_CUSTOMPREFERENCE");
            });

            modelBuilder.Entity<ReportingFields>(entity =>
            {
                entity.HasKey(e => e.FieldId);

                entity.ToTable("REPORTING_FIELDS");

                entity.Property(e => e.FieldId).HasColumnName("FieldID");

                entity.Property(e => e.KeyName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReportingLingualFields>(entity =>
            {
                entity.ToTable("REPORTING_LINGUAL_FIELDS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldId).HasColumnName("FieldID");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.ReportingLingualFields)
                    .HasForeignKey(d => d.FieldId)
                    .HasConstraintName("FK_REPORTING_LINGUAL_FIELDS_REPORTING_FIELDS");
            });

            modelBuilder.Entity<ReportingQueue>(entity =>
            {
                entity.ToTable("REPORTING_QUEUE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BatchCodes)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CopyToName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FarmName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReportName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReportPreference)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TransmissionMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReportingTempPrinting>(entity =>
            {
                entity.ToTable("REPORTING_TEMP_PRINTING");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LabId)
                    .IsRequired()
                    .HasColumnName("LabID")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MailFor)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ReportName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SamplesId).HasColumnName("SamplesID");
            });

            modelBuilder.Entity<ReportPreference>(entity =>
            {
                entity.HasKey(e => e.ReportPrefId);

                entity.ToTable("REPORT_PREFERENCE");

                entity.Property(e => e.Columns).IsUnicode(false);

                entity.Property(e => e.ReportName).HasMaxLength(100);
            });

            modelBuilder.Entity<ReportPreferenceMapping>(entity =>
            {
                entity.HasKey(e => e.ReportPrefMappingId);

                entity.ToTable("REPORT_PREFERENCE_MAPPING");

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ColumnTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Results>(entity =>
            {
                entity.ToTable("RESULTS");

                entity.HasIndex(e => new { e.ResultsId, e.Active })
                    .HasName("IX_ACTIVE");

                entity.HasIndex(e => new { e.ResultsId, e.SamplesId, e.Active })
                    .HasName("IX_SamplesID");

                entity.HasIndex(e => new { e.MajorRevision, e.MinorRevision, e.Active, e.ResultsId, e.SamplesId })
                    .HasName("_dta_index_RESULTS_8_660197402__K23_K1_K2_20_21")
                    .IsUnique();

                entity.HasIndex(e => new { e.ResultsId, e.SamplesId, e.MajorRevision, e.MinorRevision, e.Active })
                    .HasName("IX_RESULTID");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.AminoAcidsId).HasColumnName("AminoAcidsID");

                entity.Property(e => e.Ashid).HasColumnName("ASHID");

                entity.Property(e => e.CalculationId).HasColumnName("CalculationID");

                entity.Property(e => e.Choid).HasColumnName("CHOID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dmid).HasColumnName("DMID");

                entity.Property(e => e.FatId).HasColumnName("FatID");

                entity.Property(e => e.FermentationId).HasColumnName("FermentationID");

                entity.Property(e => e.FibersId).HasColumnName("FibersID");

                entity.Property(e => e.Ivsdid).HasColumnName("IVSDID");

                entity.Property(e => e.MicrobialId).HasColumnName("MicrobialID");

                entity.Property(e => e.MicronId).HasColumnName("MicronID");

                entity.Property(e => e.MineralsId).HasColumnName("MineralsID");

                entity.Property(e => e.Ndfdid).HasColumnName("NDFDID");

                entity.Property(e => e.NirDataId).HasColumnName("NirDataID");

                entity.Property(e => e.ProteinsId).HasColumnName("ProteinsID");

                entity.Property(e => e.QualitativeId).HasColumnName("QualitativeID");

                entity.Property(e => e.SamplesId).HasColumnName("SamplesID");

                entity.Property(e => e.ToxinsId).HasColumnName("ToxinsID");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(50);

                entity.Property(e => e.WaterId).HasColumnName("WaterID");
            });

            modelBuilder.Entity<Rupreport>(entity =>
            {
                entity.ToTable("RUPReport");

                entity.Property(e => e.RupreportId).HasColumnName("RUPReport_ID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.AmmoniaCp)
                    .HasColumnName("Ammonia_CP")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.AmmoniaDm)
                    .HasColumnName("Ammonia_DM")
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DryMatter)
                    .HasColumnType("decimal(5, 1)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdpCp)
                    .HasColumnName("IDP_CP")
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdpDm)
                    .HasColumnName("IDP_DM")
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProteinAsRecieved)
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProteinDmbasis)
                    .HasColumnName("ProteinDMBasis")
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RdpCp)
                    .HasColumnName("RDP_CP")
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RdpDm)
                    .HasColumnName("RDP_DM")
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RuDpCp)
                    .HasColumnName("RuDP_CP")
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RuDpDm)
                    .HasColumnName("RuDP_DM")
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SamplesId).HasColumnName("SamplesID");

                entity.Property(e => e.SpCp)
                    .HasColumnName("SP_CP")
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SpDm)
                    .HasColumnName("SP_DM")
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalTractDpCp)
                    .HasColumnName("TotalTractDP_CP")
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalTractDpDm)
                    .HasColumnName("TotalTractDP_DM")
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Sampleaditionalinformation>(entity =>
            {
                entity.ToTable("SAMPLEADITIONALINFORMATION");

                entity.Property(e => e.SampleAditionalInformationId).HasColumnName("SampleAditionalInformationID");

                entity.Property(e => e.AmountReceived)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CuttingInterval)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrinderType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrinderUsed)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrindingTechnician)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LotSize)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfCoresAndBales)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlantingDate).HasColumnType("datetime");

                entity.Property(e => e.Po)
                    .HasColumnName("PO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Postage).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampleCondition)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampleEntryId).HasColumnName("SampleEntryID");

                entity.Property(e => e.SampleGround)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampleingDevice)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SamplerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScreenSize)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SourceLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SourceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SpilitingMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StorageWeeks)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.SampleEntry)
                    .WithMany(p => p.Sampleaditionalinformation)
                    .HasForeignKey(d => d.SampleEntryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SAMPLEADITIONALINFORMATION_SAMPLEADITIONALINFORMATION");
            });

            modelBuilder.Entity<Samplenotes>(entity =>
            {
                entity.ToTable("SAMPLENOTES");

                entity.HasIndex(e => new { e.NoteId, e.SampleId })
                    .HasName("IX_SAMPLEID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NoteId).HasColumnName("NoteID");

                entity.Property(e => e.SampleId).HasColumnName("SampleID");

                entity.HasOne(d => d.Note)
                    .WithMany(p => p.Samplenotes)
                    .HasForeignKey(d => d.NoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SAMPLENOTES_NOTES");

                entity.HasOne(d => d.Sample)
                    .WithMany(p => p.Samplenotes)
                    .HasForeignKey(d => d.SampleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SAMPLENOTES_SAMPLES");
            });

            modelBuilder.Entity<SampleprepCylinder>(entity =>
            {
                entity.ToTable("SAMPLEPREP_CYLINDER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CylinderId)
                    .HasColumnName("CylinderID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CylinderWeight).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");
            });

            modelBuilder.Entity<SampleprepLogins>(entity =>
            {
                entity.ToTable("SAMPLEPREP_LOGINS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogonName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SampleprepPan>(entity =>
            {
                entity.ToTable("SAMPLEPREP_PAN");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.PanId)
                    .IsRequired()
                    .HasColumnName("PanID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PanWeight).HasColumnType("decimal(10, 3)");
            });

            modelBuilder.Entity<SampleprepSamples>(entity =>
            {
                entity.HasKey(e => e.SampleId);

                entity.ToTable("SAMPLEPREP_SAMPLES");

                entity.Property(e => e.SampleId).HasColumnName("SampleID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Dm2Vesselid).HasColumnName("DM2_VESSELID");

                entity.Property(e => e.DmVesselid).HasColumnName("DM_VESSELID");

                entity.Property(e => e.LabId).HasColumnName("LabID");

                entity.Property(e => e.Lahf).HasColumnName("LAHF");

                entity.Property(e => e.Lboron).HasColumnName("LBORON");

                entity.Property(e => e.Lcsps).HasColumnName("LCSPS");

                entity.Property(e => e.Lfap).HasColumnName("LFAP");

                entity.Property(e => e.Lferm).HasColumnName("LFERM");

                entity.Property(e => e.Lfermplus).HasColumnName("LFERMPLUS");

                entity.Property(e => e.Linvitro).HasColumnName("LINVITRO");

                entity.Property(e => e.Lmicronsize).HasColumnName("LMICRONSIZE");

                entity.Property(e => e.Lmoldid).HasColumnName("LMOLDID");

                entity.Property(e => e.Lmoldyeast).HasColumnName("LMOLDYEAST");

                entity.Property(e => e.Lmoly).HasColumnName("LMOLY");

                entity.Property(e => e.Lmycotoxinbag).HasColumnName("LMYCOTOXINBAG");

                entity.Property(e => e.Lnpn).HasColumnName("LNPN");

                entity.Property(e => e.LogonName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Lparticlesize).HasColumnName("LPARTICLESIZE");

                entity.Property(e => e.LpeNdf).HasColumnName("LpeNDF");

                entity.Property(e => e.Lprussic).HasColumnName("LPRUSSIC");

                entity.Property(e => e.Lsalmonella).HasColumnName("LSALMONELLA");

                entity.Property(e => e.Lsavebag).HasColumnName("LSAVEBAG");

                entity.Property(e => e.Lstarch2).HasColumnName("LSTARCH2");

                entity.Property(e => e.Lstarch24).HasColumnName("LSTARCH24");

                entity.Property(e => e.Lstarch7).HasColumnName("LSTARCH7");

                entity.Property(e => e.Lvitamins).HasColumnName("LVITAMINS");

                entity.Property(e => e.NirclassId).HasColumnName("NIRClassID");

                entity.Property(e => e.NirequationId).HasColumnName("NIREquationID");

                entity.Property(e => e.Retained).HasColumnName("RETAINED");

                entity.Property(e => e.Wet).HasColumnName("WET");

                entity.HasOne(d => d.Dm2Vessel)
                    .WithMany(p => p.SampleprepSamplesDm2Vessel)
                    .HasForeignKey(d => d.Dm2Vesselid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SAMPLEPREP_SAMPLES_SAMPLEPREP_STANDARDVESSEL_WGT1");

                entity.HasOne(d => d.DmVessel)
                    .WithMany(p => p.SampleprepSamplesDmVessel)
                    .HasForeignKey(d => d.DmVesselid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SAMPLEPREP_SAMPLES_SAMPLEPREP_STANDARDVESSEL_WGT");

                entity.HasOne(d => d.Nirequation)
                    .WithMany(p => p.SampleprepSamples)
                    .HasForeignKey(d => d.NirequationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SAMPLEPREP_SAMPLES_NIREQUATIONS1");
            });

            modelBuilder.Entity<SampleprepStandardvesselWgt>(entity =>
            {
                entity.ToTable("SAMPLEPREP_STANDARDVESSEL_WGT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.VesselId)
                    .HasColumnName("VesselID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VesselWeight).HasColumnType("decimal(10, 3)");
            });

            modelBuilder.Entity<SampleprepVialPrintLog>(entity =>
            {
                entity.HasKey(e => e.VialPrintLogId);

                entity.ToTable("SAMPLEPREP_VialPrintLog");

                entity.Property(e => e.VialPrintLogId).HasColumnName("VialPrintLogID");

                entity.Property(e => e.LabId)
                    .HasColumnName("LabID")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.PrintedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Samples>(entity =>
            {
                entity.ToTable("SAMPLES");

                entity.HasIndex(e => e.OldSampleId)
                    .HasName("IX_OldSampleID");

                entity.HasIndex(e => e.ReturnDate)
                    .HasName("IX_RETURNDATE");

                entity.HasIndex(e => new { e.SamplesId, e.Batch, e.Code })
                    .HasName("IX_BATCHCODE")
                    .IsUnique();

                entity.HasIndex(e => new { e.SamplesId, e.ReturnDate, e.FeedCodeId })
                    .HasName("IX_FFEDCODE");

                entity.HasIndex(e => new { e.Batch, e.Code, e.FarmName, e.SampleDesc, e.FeedType, e.ArrivalDate, e.ProcessDate, e.AccountCode })
                    .HasName("IX_ACCOUNTCODE");

                entity.HasIndex(e => new { e.SamplesId, e.Batch, e.Code, e.NirClassId, e.ChemClassId, e.AccountCode, e.FarmName, e.SampleDesc, e.ArrivalDate, e.SampledDate, e.ProcessDate, e.FeedType })
                    .HasName("IX_FEEDTYPE");

                entity.HasIndex(e => new { e.Lcap, e.Ldrycow, e.Lfa, e.Lurease, e.Ltitrate, e.Laflat, e.Ldon, e.Lt2, e.Lmold, e.Agclass, e.Lno3, e.Lsulfur, e.Lchloride, e.Ltoxin, e.ArrivalDate, e.SampledDate, e.ProcessDate, e.Lnir, e.Lbq, e.Lndf30, e.OldSampleId, e.NirClassId, e.ChemClassId, e.FarmName, e.SampleDesc, e.Cutting, e.SamplesId, e.Batch, e.AccountCode, e.FeedType, e.EqtypeId, e.Code })
                    .HasName("_dta_index_SAMPLES_8_1156199169__K1_K2_K9_K14_K13_K3_4_5_6_10_12_16_19_20_22_26_27_28_30_31_39_44_45_49_51_54_55_61_63_64_65_72")
                    .IsUnique();

                entity.Property(e => e.SamplesId).HasColumnName("SamplesID");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Aflat)
                    .HasColumnName("AFLAT")
                    .HasColumnType("decimal(2, 1)");

                entity.Property(e => e.Agclass).HasColumnName("AGCLASS");

                entity.Property(e => e.AmountDue).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ArrivalDate).HasColumnType("datetime");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.ChemClassId)
                    .HasColumnName("ChemClassID")
                    .HasColumnType("decimal(2, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EqtypeId).HasColumnName("EQTypeID");

                entity.Property(e => e.FarmName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeedCodeId).HasColumnName("FeedCodeID");

                entity.Property(e => e.FeedType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LAdf).HasColumnName("L_ADF");

                entity.Property(e => e.LAsh).HasColumnName("L_ASH");

                entity.Property(e => e.LCa).HasColumnName("L_CA");

                entity.Property(e => e.LCp).HasColumnName("L_CP");

                entity.Property(e => e.LFat).HasColumnName("L_FAT");

                entity.Property(e => e.LHdP).HasColumnName("L_HD_P");

                entity.Property(e => e.LHyg).HasColumnName("L_HYG");

                entity.Property(e => e.LIsP).HasColumnName("L_IS_P");

                entity.Property(e => e.LK).HasColumnName("L_K");

                entity.Property(e => e.LLig).HasColumnName("L_LIG");

                entity.Property(e => e.LMg).HasColumnName("L_MG");

                entity.Property(e => e.LNStarch).HasColumnName("L_N_STARCH");

                entity.Property(e => e.LNdf).HasColumnName("L_NDF");

                entity.Property(e => e.LP).HasColumnName("L_P");

                entity.Property(e => e.LSta).HasColumnName("L_STA");

                entity.Property(e => e.Ladf).HasColumnName("LADF");

                entity.Property(e => e.Ladin).HasColumnName("LADIN");

                entity.Property(e => e.Laflat).HasColumnName("LAFLAT");

                entity.Property(e => e.Lammonia).HasColumnName("LAMMONIA");

                entity.Property(e => e.Lash).HasColumnName("LASH");

                entity.Property(e => e.Lbyprod).HasColumnName("LBYPROD");

                entity.Property(e => e.Lcap).HasColumnName("LCAP");

                entity.Property(e => e.Lcfiber).HasColumnName("LCFIBER");

                entity.Property(e => e.Lchloride).HasColumnName("LCHLORIDE");

                entity.Property(e => e.Lcho).HasColumnName("LCHO");

                entity.Property(e => e.Lcornell).HasColumnName("LCORNELL");

                entity.Property(e => e.Ldas).HasColumnName("LDAS");

                entity.Property(e => e.Ldon).HasColumnName("LDON");

                entity.Property(e => e.Ldrycow).HasColumnName("LDRYCOW");

                entity.Property(e => e.Lfa).HasColumnName("LFA");

                entity.Property(e => e.Lfat).HasColumnName("LFAT");

                entity.Property(e => e.Lht2).HasColumnName("LHT2");

                entity.Property(e => e.Llact).HasColumnName("LLACT");

                entity.Property(e => e.Llignin).HasColumnName("LLIGNIN");

                entity.Property(e => e.Lmacro).HasColumnName("LMACRO");

                entity.Property(e => e.Lmoisture).HasColumnName("LMOISTURE");

                entity.Property(e => e.Lmold).HasColumnName("LMold");

                entity.Property(e => e.Lndf).HasColumnName("LNDF");

                entity.Property(e => e.Lndfs).HasColumnName("LNDFS");

                entity.Property(e => e.Lndin).HasColumnName("LNDIN");

                entity.Property(e => e.Lneo).HasColumnName("LNEO");

                entity.Property(e => e.Lno3).HasColumnName("LNO3");

                entity.Property(e => e.Lnpn).HasColumnName("LNPN");

                entity.Property(e => e.Losu).HasColumnName("LOSU");

                entity.Property(e => e.Lpepsin).HasColumnName("LPEPSIN");

                entity.Property(e => e.Lprotein).HasColumnName("LPROTEIN");

                entity.Property(e => e.Lrbean).HasColumnName("LRBEAN");

                entity.Property(e => e.Lsalt).HasColumnName("LSALT");

                entity.Property(e => e.Lselenium).HasColumnName("LSELENIUM");

                entity.Property(e => e.Lsize).HasColumnName("LSIZE");

                entity.Property(e => e.Lsolpro).HasColumnName("LSOLPRO");

                entity.Property(e => e.Lstarch).HasColumnName("LSTARCH");

                entity.Property(e => e.Lsugar).HasColumnName("LSUGAR");

                entity.Property(e => e.Lsulfur).HasColumnName("LSULFUR");

                entity.Property(e => e.Lt2).HasColumnName("LT2");

                entity.Property(e => e.Ltitrate).HasColumnName("LTITRATE");

                entity.Property(e => e.Ltoxin).HasColumnName("LTOXIN");

                entity.Property(e => e.Ltrace).HasColumnName("LTRACE");

                entity.Property(e => e.Luip).HasColumnName("LUIP");

                entity.Property(e => e.Lurease).HasColumnName("LUREASE");

                entity.Property(e => e.Lzeral).HasColumnName("LZERAL");

                entity.Property(e => e.NirClassId)
                    .HasColumnName("NirClassID")
                    .HasColumnType("decimal(1, 0)");

                entity.Property(e => e.OldSampleId).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.ProcessDate).HasColumnType("datetime");

                entity.Property(e => e.RegionStateId).HasColumnName("RegionStateID");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.SampleDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampledDate).HasColumnType("datetime");

                entity.Property(e => e.Wewt).HasColumnType("decimal(4, 4)");
            });

            modelBuilder.Entity<Samplescopyto>(entity =>
            {
                entity.HasKey(e => e.SamplesAccountId);

                entity.ToTable("SAMPLESCOPYTO");

                entity.HasIndex(e => e.SampleId)
                    .HasName("_dta_index_SAMPLESCOPYTO_8_662293419__K2");

                entity.HasIndex(e => new { e.AccountId, e.SampleId })
                    .HasName("IX_SAMPLEID");

                entity.HasIndex(e => new { e.SampleId, e.AccountId })
                    .HasName("_dta_index_SAMPLESCOPYTO_8_662293419__K2_K3");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");
            });

            modelBuilder.Entity<Samplesdrymatterdata>(entity =>
            {
                entity.HasKey(e => e.SampleDryMatterId);

                entity.ToTable("SAMPLESDRYMATTERDATA");

                entity.Property(e => e.SampleDryMatterId).HasColumnName("SampleDryMatterID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dm2Dry)
                    .HasColumnName("DM2_DRY")
                    .HasColumnType("decimal(10, 5)");

                entity.Property(e => e.Dm2Pan)
                    .HasColumnName("DM2_PAN")
                    .HasColumnType("decimal(10, 5)");

                entity.Property(e => e.Dm2Pansm)
                    .HasColumnName("DM2_PANSM")
                    .HasColumnType("decimal(10, 5)");

                entity.Property(e => e.Dm3Dry)
                    .HasColumnName("DM3_DRY")
                    .HasColumnType("decimal(10, 5)");

                entity.Property(e => e.Dm3Pan)
                    .HasColumnName("DM3_PAN")
                    .HasColumnType("decimal(10, 5)");

                entity.Property(e => e.Dm3Pansm)
                    .HasColumnName("DM3_PANSM")
                    .HasColumnType("decimal(10, 5)");

                entity.Property(e => e.DmDry)
                    .HasColumnName("DM_DRY")
                    .HasColumnType("decimal(10, 5)");

                entity.Property(e => e.DmPan)
                    .HasColumnName("DM_PAN")
                    .HasColumnType("decimal(10, 5)");

                entity.Property(e => e.DmPansm)
                    .HasColumnName("DM_PANSM")
                    .HasColumnType("decimal(10, 5)");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ph)
                    .HasColumnName("PH")
                    .HasColumnType("decimal(10, 5)");
            });

            modelBuilder.Entity<SampleSourceGroup>(entity =>
            {
                entity.HasOne(d => d.SourceGroup)
                    .WithMany(p => p.SampleSourceGroup)
                    .HasForeignKey(d => d.SourceGroupId)
                    .HasConstraintName("FK_SampleSourceGroup_MOB_SOURCEGROUPS");

                entity.HasOne(d => d.SourceGroupOption)
                    .WithMany(p => p.SampleSourceGroup)
                    .HasForeignKey(d => d.SourceGroupOptionId)
                    .HasConstraintName("FK_SampleSourceGroup_MOB_SOURCEGROUPOPTIONS");
            });

            modelBuilder.Entity<Samplestatus>(entity =>
            {
                entity.HasKey(e => e.SamplesStatusId);

                entity.ToTable("SAMPLESTATUS");

                entity.HasIndex(e => new { e.SamplesId, e.StatusId })
                    .HasName("IX_STATUSID");

                entity.Property(e => e.SamplesStatusId).HasColumnName("SamplesStatusID");

                entity.Property(e => e.SamplesId).HasColumnName("SamplesID");

                entity.Property(e => e.StatusDate).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<SamplesWinlabTest>(entity =>
            {
                entity.HasKey(e => e.SampleId);

                entity.ToTable("Samples_WinlabTest");

                entity.Property(e => e.SampleId).HasColumnName("SampleID");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Aflat)
                    .HasColumnName("AFLAT")
                    .HasColumnType("decimal(2, 1)");

                entity.Property(e => e.Agclass).HasColumnName("AGCLASS");

                entity.Property(e => e.AmountDue).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ArrivalDate).HasColumnType("datetime");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.ChemClassId)
                    .HasColumnName("ChemClassID")
                    .HasColumnType("decimal(2, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EqtypeId).HasColumnName("EQTypeID");

                entity.Property(e => e.FarmName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeedCodeId).HasColumnName("FeedCodeID");

                entity.Property(e => e.FeedType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LAdf).HasColumnName("L_ADF");

                entity.Property(e => e.LAsh).HasColumnName("L_ASH");

                entity.Property(e => e.LCa).HasColumnName("L_CA");

                entity.Property(e => e.LCp).HasColumnName("L_CP");

                entity.Property(e => e.LFat).HasColumnName("L_FAT");

                entity.Property(e => e.LHdP).HasColumnName("L_HD_P");

                entity.Property(e => e.LHyg).HasColumnName("L_HYG");

                entity.Property(e => e.LIsP).HasColumnName("L_IS_P");

                entity.Property(e => e.LK).HasColumnName("L_K");

                entity.Property(e => e.LLig).HasColumnName("L_LIG");

                entity.Property(e => e.LMg).HasColumnName("L_MG");

                entity.Property(e => e.LNStarch).HasColumnName("L_N_STARCH");

                entity.Property(e => e.LNdf).HasColumnName("L_NDF");

                entity.Property(e => e.LP).HasColumnName("L_P");

                entity.Property(e => e.LSta).HasColumnName("L_STA");

                entity.Property(e => e.Ladf).HasColumnName("LADF");

                entity.Property(e => e.Ladin).HasColumnName("LADIN");

                entity.Property(e => e.Laflat).HasColumnName("LAFLAT");

                entity.Property(e => e.Lammonia).HasColumnName("LAMMONIA");

                entity.Property(e => e.Lash).HasColumnName("LASH");

                entity.Property(e => e.Lbyprod).HasColumnName("LBYPROD");

                entity.Property(e => e.Lcap).HasColumnName("LCAP");

                entity.Property(e => e.Lcfiber).HasColumnName("LCFIBER");

                entity.Property(e => e.Lchloride).HasColumnName("LCHLORIDE");

                entity.Property(e => e.Lcho).HasColumnName("LCHO");

                entity.Property(e => e.Lcornell).HasColumnName("LCORNELL");

                entity.Property(e => e.Ldas).HasColumnName("LDAS");

                entity.Property(e => e.Ldon).HasColumnName("LDON");

                entity.Property(e => e.Ldrycow).HasColumnName("LDRYCOW");

                entity.Property(e => e.Lfa).HasColumnName("LFA");

                entity.Property(e => e.Lfat).HasColumnName("LFAT");

                entity.Property(e => e.Lht2).HasColumnName("LHT2");

                entity.Property(e => e.Llact).HasColumnName("LLACT");

                entity.Property(e => e.Llignin).HasColumnName("LLIGNIN");

                entity.Property(e => e.Lmacro).HasColumnName("LMACRO");

                entity.Property(e => e.Lmoisture).HasColumnName("LMOISTURE");

                entity.Property(e => e.Lmold).HasColumnName("LMold");

                entity.Property(e => e.Lndf).HasColumnName("LNDF");

                entity.Property(e => e.Lndfs).HasColumnName("LNDFS");

                entity.Property(e => e.Lndin).HasColumnName("LNDIN");

                entity.Property(e => e.Lneo).HasColumnName("LNEO");

                entity.Property(e => e.Lno3).HasColumnName("LNO3");

                entity.Property(e => e.Lnpn).HasColumnName("LNPN");

                entity.Property(e => e.Losu).HasColumnName("LOSU");

                entity.Property(e => e.Lpepsin).HasColumnName("LPEPSIN");

                entity.Property(e => e.Lprotein).HasColumnName("LPROTEIN");

                entity.Property(e => e.Lrbean).HasColumnName("LRBEAN");

                entity.Property(e => e.Lsalt).HasColumnName("LSALT");

                entity.Property(e => e.Lselenium).HasColumnName("LSELENIUM");

                entity.Property(e => e.Lsize).HasColumnName("LSIZE");

                entity.Property(e => e.Lsolpro).HasColumnName("LSOLPRO");

                entity.Property(e => e.Lstarch).HasColumnName("LSTARCH");

                entity.Property(e => e.Lsugar).HasColumnName("LSUGAR");

                entity.Property(e => e.Lsulfur).HasColumnName("LSULFUR");

                entity.Property(e => e.Lt2).HasColumnName("LT2");

                entity.Property(e => e.Ltitrate).HasColumnName("LTITRATE");

                entity.Property(e => e.Ltoxin).HasColumnName("LTOXIN");

                entity.Property(e => e.Ltrace).HasColumnName("LTRACE");

                entity.Property(e => e.Luip).HasColumnName("LUIP");

                entity.Property(e => e.Lurease).HasColumnName("LUREASE");

                entity.Property(e => e.Lzeral).HasColumnName("LZERAL");

                entity.Property(e => e.NirClassId)
                    .HasColumnName("NirClassID")
                    .HasColumnType("decimal(1, 0)");

                entity.Property(e => e.OldSampleId).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.ProcessDate).HasColumnType("datetime");

                entity.Property(e => e.RegionStateId).HasColumnName("RegionStateID");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.SampleDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampledDate).HasColumnType("datetime");

                entity.Property(e => e.Wewt).HasColumnType("decimal(4, 4)");
            });

            modelBuilder.Entity<SampleUserNotes>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Sample)
                    .WithMany(p => p.SampleUserNotes)
                    .HasForeignKey(d => d.SampleId)
                    .HasConstraintName("FK_SampleUserNotes_SAMPLES");
            });

            modelBuilder.Entity<SatelliteChemLog>(entity =>
            {
                entity.Property(e => e.SatelliteChemLogId).ValueGeneratedNever();

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.SamplesId).HasColumnName("SamplesID");
            });

            modelBuilder.Entity<Slider>(entity =>
            {
                entity.ToTable("SLIDER");

                entity.Property(e => e.SliderId).HasColumnName("SliderID");

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.MediaId).HasColumnName("MediaID");

                entity.Property(e => e.ModifiedDt).HasColumnType("datetime");

                entity.Property(e => e.SliderLink).HasMaxLength(500);

                entity.Property(e => e.SliderTitle).HasMaxLength(100);
            });

            modelBuilder.Entity<SmConfig>(entity =>
            {
                entity.ToTable("SM_Config");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsSmdown).HasColumnName("isSMDown");
            });

            modelBuilder.Entity<SmCustomFields>(entity =>
            {
                entity.ToTable("SM_CustomFields");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SamplesId).HasColumnName("SamplesID");
            });

            modelBuilder.Entity<SmFullUpdateLog>(entity =>
            {
                entity.ToTable("SM_FullUpdateLog");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.JsonData).HasColumnName("JSonData");

                entity.Property(e => e.SamplesId).HasColumnName("SamplesID");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SmImportPreference>(entity =>
            {
                entity.HasKey(e => e.ImportPreferenceId);

                entity.ToTable("SM_ImportPreference");

                entity.Property(e => e.ImportPreferenceId).HasColumnName("ImportPreferenceID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ImportTypeId).HasColumnName("ImportTypeID");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.UserDetailsId).HasColumnName("UserDetailsID");
            });

            modelBuilder.Entity<SmLabIdAuthenticate>(entity =>
            {
                entity.ToTable("Sm_LabIdAuthenticate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.PassKey)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SmLanguage>(entity =>
            {
                entity.ToTable("SM_Language");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<SmMobjson>(entity =>
            {
                entity.ToTable("SM_MOBJSON");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batch)
                    .HasColumnName("BATCH")
                    .HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasColumnType("decimal(3, 0)");

                entity.Property(e => e.Jsondata).HasColumnName("JSONData");
            });

            modelBuilder.Entity<SmSamples>(entity =>
            {
                entity.HasKey(e => e.Sampleid);

                entity.ToTable("SM_SAMPLES");

                entity.Property(e => e.Sampleid).HasColumnName("SAMPLEID");

                entity.Property(e => e.Account)
                    .HasColumnName("ACCOUNT")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Acetic)
                    .HasColumnName("ACETIC")
                    .HasColumnType("decimal(8, 3)");

                entity.Property(e => e.Address1)
                    .HasColumnName("ADDRESS1")
                    .HasColumnType("char(35)");

                entity.Property(e => e.Address2)
                    .HasColumnName("ADDRESS2")
                    .HasColumnType("char(35)");

                entity.Property(e => e.Adf2Bag)
                    .HasColumnName("ADF2_BAG")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Adf2Bagsm)
                    .HasColumnName("ADF2_BAGSM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Adf2Bagtr)
                    .HasColumnName("ADF2_BAGTR")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.AdfBag)
                    .HasColumnName("ADF_BAG")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.AdfBagsm)
                    .HasColumnName("ADF_BAGSM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.AdfBagtr)
                    .HasColumnName("ADF_BAGTR")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.AdfPc)
                    .HasColumnName("ADF_PC")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.AdfPcsm)
                    .HasColumnName("ADF_PCSM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.AdfproSm)
                    .HasColumnName("ADFPRO_SM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Aflat)
                    .HasColumnName("AFLAT")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Agclass)
                    .HasColumnName("AGCLASS")
                    .HasColumnType("decimal(1, 0)");

                entity.Property(e => e.Alldone).HasColumnName("ALLDONE");

                entity.Property(e => e.AmmoniaPc)
                    .HasColumnName("AMMONIA_PC")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.AmmoniaSm)
                    .HasColumnName("AMMONIA_SM")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Arrival)
                    .HasColumnName("ARRIVAL")
                    .HasColumnType("date");

                entity.Property(e => e.AshCru)
                    .HasColumnName("ASH_CRU")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.AshCrusm)
                    .HasColumnName("ASH_CRUSM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.AshSm)
                    .HasColumnName("ASH_SM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Batch)
                    .HasColumnName("BATCH")
                    .HasColumnType("decimal(5, 0)");

                entity.Property(e => e.BillCode)
                    .HasColumnName("BILL_CODE")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Billed)
                    .HasColumnName("BILLED")
                    .HasColumnType("date");

                entity.Property(e => e.Billto).HasColumnName("BILLTO");

                entity.Property(e => e.Butyric)
                    .HasColumnName("BUTYRIC")
                    .HasColumnType("decimal(8, 3)");

                entity.Property(e => e.Ca)
                    .HasColumnName("CA")
                    .HasColumnType("decimal(8, 3)");

                entity.Property(e => e.Citystzip)
                    .HasColumnName("CITYSTZIP")
                    .HasColumnType("char(35)");

                entity.Property(e => e.ClPc)
                    .HasColumnName("CL_PC")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.ClSm)
                    .HasColumnName("CL_SM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Class)
                    .HasColumnName("CLASS")
                    .HasColumnType("decimal(2, 0)");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasColumnType("decimal(3, 0)");

                entity.Property(e => e.Codeset)
                    .HasColumnName("CODESET")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Comments)
                    .HasColumnName("COMMENTS")
                    .HasMaxLength(500);

                entity.Property(e => e.CopyTo).HasColumnName("COPY_TO");

                entity.Property(e => e.Ctfee)
                    .HasColumnName("CTFEE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Cu)
                    .HasColumnName("CU")
                    .HasColumnType("decimal(8, 3)");

                entity.Property(e => e.Cutting)
                    .HasColumnName("CUTTING")
                    .HasColumnType("decimal(1, 0)");

                entity.Property(e => e.Das)
                    .HasColumnName("DAS")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Describe)
                    .HasColumnName("DESCRIBE")
                    .HasColumnType("char(35)");

                entity.Property(e => e.Dm2Dry)
                    .HasColumnName("DM2_DRY")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Dm2Pan)
                    .HasColumnName("DM2_PAN")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Dm2Pansm)
                    .HasColumnName("DM2_PANSM")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.DmDry)
                    .HasColumnName("DM_DRY")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.DmPan)
                    .HasColumnName("DM_PAN")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.DmPansm)
                    .HasColumnName("DM_PANSM")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Don)
                    .HasColumnName("DON")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Due)
                    .HasColumnName("DUE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Energy)
                    .HasColumnName("ENERGY")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Ethanol)
                    .HasColumnName("ETHANOL")
                    .HasColumnType("decimal(5, 0)");

                entity.Property(e => e.FarmId)
                    .HasColumnName("FARM_ID")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Farmname)
                    .HasColumnName("FARMNAME")
                    .HasColumnType("char(30)");

                entity.Property(e => e.FatCru)
                    .HasColumnName("FAT_CRU")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.FatCrusm)
                    .HasColumnName("FAT_CRUSM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.FatSm)
                    .HasColumnName("FAT_SM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Fe)
                    .HasColumnName("FE")
                    .HasColumnType("decimal(8, 3)");

                entity.Property(e => e.FeedType)
                    .HasColumnName("FEED_TYPE")
                    .HasColumnType("char(3)");

                entity.Property(e => e.GlucPc)
                    .HasColumnName("GLUC_PC")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.GlucWt)
                    .HasColumnName("GLUC_WT")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.HdmDry)
                    .HasColumnName("HDM_DRY")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.HdmPan)
                    .HasColumnName("HDM_PAN")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.HdmPansm)
                    .HasColumnName("HDM_PANSM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Hfee)
                    .HasColumnName("HFEE")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Hrvtyr)
                    .HasColumnName("HRVTYR")
                    .HasColumnType("decimal(4, 0)");

                entity.Property(e => e.Ht2)
                    .HasColumnName("HT2")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Idcode)
                    .HasColumnName("IDCODE")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Invoiceno)
                    .HasColumnName("INVOICENO")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Isobutyric)
                    .HasColumnName("ISOBUTYRIC")
                    .HasColumnType("decimal(8, 3)");

                entity.Property(e => e.K).HasColumnType("decimal(8, 3)");

                entity.Property(e => e.KernelH)
                    .HasColumnName("KERNEL_H")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.LAdf).HasColumnName("L_ADF");

                entity.Property(e => e.LAsh).HasColumnName("L_ASH");

                entity.Property(e => e.LCa).HasColumnName("L_CA");

                entity.Property(e => e.LCp).HasColumnName("L_CP");

                entity.Property(e => e.LFat).HasColumnName("L_FAT");

                entity.Property(e => e.LHdP).HasColumnName("L_HD_P");

                entity.Property(e => e.LHyg).HasColumnName("L_HYG");

                entity.Property(e => e.LIsP).HasColumnName("L_IS_P");

                entity.Property(e => e.LK).HasColumnName("L_K");

                entity.Property(e => e.LLig).HasColumnName("L_LIG");

                entity.Property(e => e.LMg).HasColumnName("L_MG");

                entity.Property(e => e.LNStarch).HasColumnName("L_N_STARCH");

                entity.Property(e => e.LNdf).HasColumnName("L_NDF");

                entity.Property(e => e.LP).HasColumnName("L_P");

                entity.Property(e => e.LSta).HasColumnName("L_STA");

                entity.Property(e => e.LacWt)
                    .HasColumnName("LAC_WT")
                    .HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Lactic)
                    .HasColumnName("LACTIC")
                    .HasColumnType("decimal(5, 0)");

                entity.Property(e => e.LacticMl)
                    .HasColumnName("LACTIC_ML")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Ladf).HasColumnName("LADF");

                entity.Property(e => e.Ladin).HasColumnName("LADIN");

                entity.Property(e => e.Laflat).HasColumnName("LAFLAT");

                entity.Property(e => e.Lammonia).HasColumnName("LAMMONIA");

                entity.Property(e => e.Lash).HasColumnName("LASH");

                entity.Property(e => e.Lbq).HasColumnName("LBQ");

                entity.Property(e => e.Lbyprod).HasColumnName("LBYPROD");

                entity.Property(e => e.Lcap).HasColumnName("LCAP");

                entity.Property(e => e.Lcfiber).HasColumnName("LCFIBER");

                entity.Property(e => e.Lchloride).HasColumnName("LCHLORIDE");

                entity.Property(e => e.Lcho).HasColumnName("LCHO");

                entity.Property(e => e.Lcornell).HasColumnName("LCORNELL");

                entity.Property(e => e.Ldas).HasColumnName("LDAS");

                entity.Property(e => e.Ldon).HasColumnName("LDON");

                entity.Property(e => e.Ldrycow).HasColumnName("LDRYCOW");

                entity.Property(e => e.Lfa).HasColumnName("LFA");

                entity.Property(e => e.Lfat).HasColumnName("LFAT");

                entity.Property(e => e.Lht2).HasColumnName("LHT2");

                entity.Property(e => e.Lig2Cruas)
                    .HasColumnName("LIG2_CRUAS")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Lig2Crusm)
                    .HasColumnName("LIG2_CRUSM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Lig2Sm)
                    .HasColumnName("LIG2_SM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.LigAdf)
                    .HasColumnName("LIG_ADF")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.LigCruash)
                    .HasColumnName("LIG_CRUASH")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.LigCrusm)
                    .HasColumnName("LIG_CRUSM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.LigSm)
                    .HasColumnName("LIG_SM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Linvndf).HasColumnName("LINVNDF");

                entity.Property(e => e.Llact).HasColumnName("LLACT");

                entity.Property(e => e.Llignin).HasColumnName("LLIGNIN");

                entity.Property(e => e.Lmacro).HasColumnName("LMACRO");

                entity.Property(e => e.Lmoisture).HasColumnName("LMOISTURE");

                entity.Property(e => e.Lmold).HasColumnName("LMOLD");

                entity.Property(e => e.Lndf).HasColumnName("LNDF");

                entity.Property(e => e.Lndf30).HasColumnName("LNDF30");

                entity.Property(e => e.Lndfs).HasColumnName("LNDFS");

                entity.Property(e => e.Lndin).HasColumnName("LNDIN");

                entity.Property(e => e.Lneo).HasColumnName("LNEO");

                entity.Property(e => e.Lnir).HasColumnName("LNIR");

                entity.Property(e => e.Lno3).HasColumnName("LNO3");

                entity.Property(e => e.Lnpn).HasColumnName("LNPN");

                entity.Property(e => e.Losu).HasColumnName("LOSU");

                entity.Property(e => e.Lpepsin).HasColumnName("LPEPSIN");

                entity.Property(e => e.Lprotein).HasColumnName("LPROTEIN");

                entity.Property(e => e.Lrbean).HasColumnName("LRBEAN");

                entity.Property(e => e.Lsalt).HasColumnName("LSALT");

                entity.Property(e => e.Lselenium).HasColumnName("LSELENIUM");

                entity.Property(e => e.Lsize).HasColumnName("LSIZE");

                entity.Property(e => e.Lsolpro).HasColumnName("LSOLPRO");

                entity.Property(e => e.Lstarch).HasColumnName("LSTARCH");

                entity.Property(e => e.Lsugar).HasColumnName("LSUGAR");

                entity.Property(e => e.Lsulfur).HasColumnName("LSULFUR");

                entity.Property(e => e.Lt2).HasColumnName("LT2");

                entity.Property(e => e.Ltitrate).HasColumnName("LTITRATE");

                entity.Property(e => e.Ltoxin).HasColumnName("LTOXIN");

                entity.Property(e => e.Ltrace).HasColumnName("LTRACE");

                entity.Property(e => e.Luip).HasColumnName("LUIP");

                entity.Property(e => e.Lurease).HasColumnName("LUREASE");

                entity.Property(e => e.Lzeral).HasColumnName("LZERAL");

                entity.Property(e => e.Mdwt)
                    .HasColumnName("MDWT")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Mg)
                    .HasColumnName("MG")
                    .HasColumnType("decimal(8, 3)");

                entity.Property(e => e.MinSm)
                    .HasColumnName("MIN_SM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Mn)
                    .HasColumnName("MN")
                    .HasColumnType("decimal(8, 3)");

                entity.Property(e => e.MoD1)
                    .HasColumnName("MO_D1")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.MoD2)
                    .HasColumnName("MO_D2")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.MoD3)
                    .HasColumnName("MO_D3")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.MoD4)
                    .HasColumnName("MO_D4")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.MoP1)
                    .HasColumnName("MO_P1")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.MoP2)
                    .HasColumnName("MO_P2")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.MoP3)
                    .HasColumnName("MO_P3")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.MoP4)
                    .HasColumnName("MO_P4")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Mold)
                    .HasColumnName("MOLD")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.NAdf)
                    .HasColumnName("N_ADF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NAsh)
                    .HasColumnName("N_ASH")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NCa)
                    .HasColumnName("N_CA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NCp)
                    .HasColumnName("N_CP")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NFat)
                    .HasColumnName("N_FAT")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NHdP)
                    .HasColumnName("N_HD_P")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NHyg)
                    .HasColumnName("N_HYG")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NIsP)
                    .HasColumnName("N_IS_P")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NK)
                    .HasColumnName("N_K")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NLig)
                    .HasColumnName("N_LIG")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NMg)
                    .HasColumnName("N_MG")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NNdf)
                    .HasColumnName("N_NDF")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NP)
                    .HasColumnName("N_P")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NSta)
                    .HasColumnName("N_STA")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Na)
                    .HasColumnName("NA")
                    .HasColumnType("decimal(8, 3)");

                entity.Property(e => e.NaOh)
                    .HasColumnName("NA_OH")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.NaclSm)
                    .HasColumnName("NACL_SM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NaclTt)
                    .HasColumnName("NACL_TT")
                    .HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasColumnType("char(30)");

                entity.Property(e => e.Name1)
                    .HasColumnName("NAME1")
                    .HasColumnType("char(30)");

                entity.Property(e => e.Ndacruc)
                    .HasColumnName("NDACRUC")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Ndacrucf)
                    .HasColumnName("NDACRUCF")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Ndafilt)
                    .HasColumnName("NDAFILT")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Ndawt)
                    .HasColumnName("NDAWT")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Ndf2Bag)
                    .HasColumnName("NDF2_BAG")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Ndf2Bagsm)
                    .HasColumnName("NDF2_BAGSM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Ndf2Bagtr)
                    .HasColumnName("NDF2_BAGTR")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.NdfBag)
                    .HasColumnName("NDF_BAG")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.NdfBagsm)
                    .HasColumnName("NDF_BAGSM")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.NdfBagtr)
                    .HasColumnName("NDF_BAGTR")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.NdfPc)
                    .HasColumnName("NDF_PC")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NdfproSm)
                    .HasColumnName("NDFPRO_SM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Ndinwt)
                    .HasColumnName("NDINWT")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Neo)
                    .HasColumnName("NEO")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Nir)
                    .HasColumnName("NIR")
                    .HasColumnType("decimal(1, 0)");

                entity.Property(e => e.No3Pc)
                    .HasColumnName("NO3_PC")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.No3Sm)
                    .HasColumnName("NO3_SM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.NpnPc)
                    .HasColumnName("NPN_PC")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.NpnSm)
                    .HasColumnName("NPN_SM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Paid).HasColumnName("PAID");

                entity.Property(e => e.Ph)
                    .HasColumnName("PH")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Pho)
                    .HasColumnName("PHO")
                    .HasColumnType("decimal(8, 3)");

                entity.Property(e => e.Postage)
                    .HasColumnName("POSTAGE")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Pro1Pc)
                    .HasColumnName("PRO1_PC")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Pro1Sm)
                    .HasColumnName("PRO1_SM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Pro2Pc)
                    .HasColumnName("PRO2_PC")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Pro2Sm)
                    .HasColumnName("PRO2_SM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Pro3Pc)
                    .HasColumnName("PRO3_PC")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Pro3Sm)
                    .HasColumnName("PRO3_SM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Process)
                    .HasColumnName("PROCESS")
                    .HasColumnType("date");

                entity.Property(e => e.Proprionic)
                    .HasColumnName("PROPRIONIC")
                    .HasColumnType("decimal(8, 3)");

                entity.Property(e => e.Ps1)
                    .HasColumnName("PS_1")
                    .HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Ps2)
                    .HasColumnName("PS_2")
                    .HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Ps3)
                    .HasColumnName("PS_3")
                    .HasColumnType("decimal(5, 1)");

                entity.Property(e => e.Receipt)
                    .HasColumnName("RECEIPT")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Reckcode)
                    .HasColumnName("RECKCODE")
                    .HasColumnType("char(7)");

                entity.Property(e => e.Release).HasColumnName("RELEASE");

                entity.Property(e => e.Return)
                    .HasColumnName("RETURN")
                    .HasColumnType("date");

                entity.Property(e => e.RumenBuf)
                    .HasColumnName("RUMEN_BUF")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.SFl)
                    .HasColumnName("S_FL")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.SFlpr)
                    .HasColumnName("S_FLPR")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.SSm)
                    .HasColumnName("S_SM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Sampled)
                    .HasColumnName("SAMPLED")
                    .HasColumnType("date");

                entity.Property(e => e.Special).HasColumnName("SPECIAL");

                entity.Property(e => e.Spr2Bag)
                    .HasColumnName("SPR2_BAG")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Spr2Bagsm)
                    .HasColumnName("SPR2_BAGSM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Spr2Bgsmd)
                    .HasColumnName("SPR2_BGSMD")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Spr2Pc)
                    .HasColumnName("SPR2_PC")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Spr2Sm)
                    .HasColumnName("SPR2_SM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.SproBag)
                    .HasColumnName("SPRO_BAG")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.SproBagsm)
                    .HasColumnName("SPRO_BAGSM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.SproBgsmd)
                    .HasColumnName("SPRO_BGSMD")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.SproPc)
                    .HasColumnName("SPRO_PC")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.SproSm)
                    .HasColumnName("SPRO_SM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.StrchBl)
                    .HasColumnName("STRCH_BL")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.StrchPc)
                    .HasColumnName("STRCH_PC")
                    .HasColumnType("decimal(6, 0)");

                entity.Property(e => e.StrchPc2)
                    .HasColumnName("STRCH_PC2")
                    .HasColumnType("decimal(6, 0)");

                entity.Property(e => e.StrchWt)
                    .HasColumnName("STRCH_WT")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.StrchWt2)
                    .HasColumnName("STRCH_WT2")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.Switch).HasColumnName("SWITCH");

                entity.Property(e => e.T2).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Tempbool).HasColumnName("TEMPBOOL");

                entity.Property(e => e.Tvfa)
                    .HasColumnName("TVFA")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.UipPc)
                    .HasColumnName("UIP_PC")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.UipSm)
                    .HasColumnName("UIP_SM")
                    .HasColumnType("decimal(6, 4)");

                entity.Property(e => e.ValAflat)
                    .HasColumnName("VAL_AFLAT")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ValDon)
                    .HasColumnName("VAL_DON")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.VfaMl)
                    .HasColumnName("VFA_ML")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Wet).HasColumnName("WET");

                entity.Property(e => e.WetSilage)
                    .HasColumnName("WET_SILAGE")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Wewt)
                    .HasColumnName("WEWT")
                    .HasColumnType("decimal(7, 4)");

                entity.Property(e => e.WsSugar)
                    .HasColumnName("WS_SUGAR")
                    .HasColumnType("decimal(6, 1)");

                entity.Property(e => e.Yeast)
                    .HasColumnName("YEAST")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Zeral)
                    .HasColumnName("ZERAL")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Zn)
                    .HasColumnName("ZN")
                    .HasColumnType("decimal(8, 3)");
            });

            modelBuilder.Entity<SmSampleTranslation>(entity =>
            {
                entity.ToTable("SM_SampleTranslation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SamplesId).HasColumnName("SamplesID");
            });

            modelBuilder.Entity<SmTranslationFields>(entity =>
            {
                entity.ToTable("SM_TranslationFields");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FieldDescription)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Specialitems>(entity =>
            {
                entity.HasKey(e => e.SpecialItemId);

                entity.ToTable("SPECIALITEMS");

                entity.Property(e => e.SpecialItemId).HasColumnName("SpecialItemID");

                entity.Property(e => e.Amount).HasColumnType("smallmoney");

                entity.Property(e => e.SpecialItem)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Srctype>(entity =>
            {
                entity.ToTable("SRCTYPE");

                entity.Property(e => e.SrcTypeId).HasColumnName("SrcTypeID");

                entity.Property(e => e.Cname)
                    .HasColumnName("CName")
                    .HasMaxLength(50);

                entity.Property(e => e.Cvalue)
                    .HasColumnName("CValue")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Starchdigestibility>(entity =>
            {
                entity.ToTable("STARCHDIGESTIBILITY");

                entity.Property(e => e.StarchDigestibilityId).HasColumnName("StarchDigestibilityID");

                entity.Property(e => e.DomesticPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DomesticSpecialItemId).HasColumnName("DomesticSpecialItemID");

                entity.Property(e => e.IntSpecialItemId).HasColumnName("IntSpecialItemID");

                entity.Property(e => e.InternationalPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.StarchDigestibilityCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.StarchDigestibilityDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StarchDigestibilityValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.DomesticSpecialItem)
                    .WithMany(p => p.StarchdigestibilityDomesticSpecialItem)
                    .HasForeignKey(d => d.DomesticSpecialItemId)
                    .HasConstraintName("FK_STARCHDIGESTIBILITY_SPECIALITEMS");

                entity.HasOne(d => d.IntSpecialItem)
                    .WithMany(p => p.StarchdigestibilityIntSpecialItem)
                    .HasForeignKey(d => d.IntSpecialItemId)
                    .HasConstraintName("FK_STARCHDIGESTIBILITY_SPECIALITEMS1");
            });

            modelBuilder.Entity<Statustype>(entity =>
            {
                entity.ToTable("STATUSTYPE");

                entity.Property(e => e.StatusTypeId).HasColumnName("StatusTypeID");

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.TypeDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.ToTable("STORAGE");

                entity.Property(e => e.StorageId).HasColumnName("StorageID");

                entity.Property(e => e.Cname)
                    .HasColumnName("CName")
                    .HasMaxLength(50);

                entity.Property(e => e.Cvalue)
                    .HasColumnName("CValue")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Storageconditions>(entity =>
            {
                entity.ToTable("STORAGECONDITIONS");

                entity.Property(e => e.StorageConditionsId).HasColumnName("StorageConditionsID");

                entity.Property(e => e.Cname)
                    .HasColumnName("CName")
                    .HasMaxLength(50);

                entity.Property(e => e.Cvalue)
                    .HasColumnName("CValue")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sulfurimportlog>(entity =>
            {
                entity.HasKey(e => e.SulfurImportId);

                entity.ToTable("SULFURIMPORTLOG");

                entity.Property(e => e.SulfurImportId).HasColumnName("SulfurImportID");

                entity.Property(e => e.ActionName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SFl)
                    .HasColumnName("S_FL")
                    .HasColumnType("decimal(9, 7)");

                entity.Property(e => e.TableName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TagLabels>(entity =>
            {
                entity.HasKey(e => e.TagLabelId);

                entity.ToTable("TAG_LABELS");

                entity.Property(e => e.TagLabelId).HasColumnName("TagLabelID");

                entity.Property(e => e.TagLabel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TagMap)
                    .HasColumnName("Tag_Map")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TagProductId).HasColumnName("TagProductID");

                entity.Property(e => e.TagUnit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TagValueMax).HasColumnType("numeric(7, 3)");

                entity.Property(e => e.TagValueMin).HasColumnType("numeric(7, 3)");
            });

            modelBuilder.Entity<TagProducts>(entity =>
            {
                entity.HasKey(e => e.TagProductId);

                entity.ToTable("TAG_PRODUCTS");

                entity.Property(e => e.TagProductId).HasColumnName("TagProductID");

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.TagMemo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TagProduct)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDt).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblLinkNetUserToSamplesResultsSep02>(entity =>
            {
                entity.HasKey(e => e.NetUserResultsLinkId);

                entity.Property(e => e.NetUserResultsLinkId).HasColumnName("NetUserResultsLinkID");

                entity.Property(e => e.NetUserAccountLink)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.SamplesResultsAccountLink)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.UserDaysToView)
                    .HasColumnType("decimal(4, 0)")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TempBatchlog>(entity =>
            {
                entity.HasKey(e => e.Batchlogid);

                entity.ToTable("TEMP_BATCHLOG");

                entity.Property(e => e.Batchlogid).HasColumnName("BATCHLOGID");

                entity.Property(e => e.Batch)
                    .HasColumnName("BATCH")
                    .HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Batchdate)
                    .HasColumnName("BATCHDATE")
                    .HasColumnType("date");

                entity.Property(e => e.Describe)
                    .HasColumnName("DESCRIBE")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Lab)
                    .HasColumnName("LAB")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Nextcode)
                    .HasColumnName("NEXTCODE")
                    .HasColumnType("decimal(3, 0)");
            });

            modelBuilder.Entity<TempCompletedsamples>(entity =>
            {
                entity.ToTable("TEMP_COMPLETEDSAMPLES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Agclass).HasColumnName("AGCLASS");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.ChemClassId).HasColumnName("ChemClassID");

                entity.Property(e => e.Code).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.LabId)
                    .HasColumnName("LabID")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NirclassId).HasColumnName("NIRClassID");
            });

            modelBuilder.Entity<TempMinerals>(entity =>
            {
                entity.HasKey(e => e.MineralsId);

                entity.ToTable("TEMP_MINERALS");

                entity.Property(e => e.MineralsId).HasColumnName("MineralsID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Al).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Al1)
                    .HasColumnName("Al_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.As).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.As1)
                    .HasColumnName("As_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Ba).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Ba1)
                    .HasColumnName("Ba_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Bo).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Bo1)
                    .HasColumnName("Bo_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Ca)
                    .HasColumnName("CA")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Ca1)
                    .HasColumnName("CA_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Cd).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Cd1)
                    .HasColumnName("Cd_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Cl).HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Cl1)
                    .HasColumnName("Cl_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Co).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Co1)
                    .HasColumnName("Co_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Cr).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Cr1)
                    .HasColumnName("Cr_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Cu).HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Cu1)
                    .HasColumnName("Cu_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Fe).HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Fe1)
                    .HasColumnName("Fe_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Hg).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Hg1)
                    .HasColumnName("Hg_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.I).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.I1)
                    .HasColumnName("I_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.K).HasColumnType("numeric(7, 2)");

                entity.Property(e => e.K1)
                    .HasColumnName("K_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Mg).HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Mg1)
                    .HasColumnName("Mg_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Mn).HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Mn1)
                    .HasColumnName("Mn_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Mo).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Mo1)
                    .HasColumnName("Mo_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Na).HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Na1)
                    .HasColumnName("Na_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.P).HasColumnType("numeric(7, 2)");

                entity.Property(e => e.P1)
                    .HasColumnName("P_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Pb).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Pb1)
                    .HasColumnName("Pb_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.Property(e => e.S).HasColumnType("numeric(7, 2)");

                entity.Property(e => e.S1)
                    .HasColumnName("S_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Sb).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Sb1)
                    .HasColumnName("Sb_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Se).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Se1)
                    .HasColumnName("Se_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Ti).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Ti1)
                    .HasColumnName("Ti_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Zn).HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Zn1)
                    .HasColumnName("Zn_1")
                    .HasColumnType("numeric(7, 2)");
            });

            modelBuilder.Entity<TmrFecalMappings>(entity =>
            {
                entity.ToTable("TMR_FECAL_MAPPINGS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecal)
                    .IsRequired()
                    .HasColumnName("FECAL")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Tmr)
                    .IsRequired()
                    .HasColumnName("TMR")
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Toxins>(entity =>
            {
                entity.ToTable("TOXINS");

                entity.HasIndex(e => new { e.Atox, e.Atoxb1, e.Atoxb2, e.Atoxg1, e.Atoxg2, e.Vtox, e.Don3ac, e.Don15ac, e.T2tox, e.Ztox, e.Ftoxb1, e.Ftoxb2, e.Ftoxb3, e.ResultsId })
                    .HasName("IX_RESULTID")
                    .IsUnique();

                entity.Property(e => e.ToxinsId).HasColumnName("ToxinsID");

                entity.Property(e => e.Atox).HasColumnType("decimal(6, 1)");

                entity.Property(e => e.Atoxb1).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Atoxb2).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Atoxg1).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Atoxg2).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Don15ac)
                    .HasColumnName("DON_15Ac")
                    .HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Don15acNonDetect).HasColumnName("DON_15AcNonDetect");

                entity.Property(e => e.Don3ac)
                    .HasColumnName("DON_3Ac")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Don3acNonDetect).HasColumnName("DON_3AcNonDetect");

                entity.Property(e => e.Ftoxb1).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.Ftoxb2).HasColumnType("decimal(7, 4)");

                entity.Property(e => e.Ftoxb3).HasColumnType("decimal(7, 3)");

                entity.Property(e => e.Ht2).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Ochratoxin).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.Property(e => e.T2tox).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.ToxinLabId)
                    .HasColumnName("ToxinLabID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Vtox).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Ztox).HasColumnType("decimal(4, 1)");

                entity.HasOne(d => d.Results)
                    .WithMany(p => p.Toxins)
                    .HasForeignKey(d => d.ResultsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TOXINS_RESULTS");
            });

            modelBuilder.Entity<TRangeFeedCodes>(entity =>
            {
                entity.HasKey(e => e.FeedCodeId);

                entity.ToTable("T_RANGE_FEED_CODES");

                entity.Property(e => e.Condition)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FeedType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeedTypeSearch)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsRangeResult).HasColumnName("isRangeResult");

                entity.Property(e => e.IsSampleDesc).HasColumnName("isSampleDesc");

                entity.Property(e => e.SampleDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SqlCondition)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SqlJoin)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TRangeResult>(entity =>
            {
                entity.ToTable("T_RANGE_RESULT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ColAvg).HasColumnName("Col_Avg");

                entity.Property(e => e.ColBottom).HasColumnName("Col_Bottom");

                entity.Property(e => e.ColMax).HasColumnName("Col_Max");

                entity.Property(e => e.ColMin).HasColumnName("Col_Min");

                entity.Property(e => e.ColStd).HasColumnName("Col_Std");

                entity.Property(e => e.ColTop).HasColumnName("Col_Top");

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Designator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DmHigh).HasColumnName("DM_High");

                entity.Property(e => e.DmLow).HasColumnName("DM_Low");

                entity.Property(e => e.FeedType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SampleDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SqlCondition)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SqlJoin)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Std2).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.TableName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UnitSystem>(entity =>
            {
                entity.ToTable("UNIT_SYSTEM");

                entity.Property(e => e.UnitSystemId).HasColumnName("UnitSystemID");

                entity.Property(e => e.UnitSystem1)
                    .IsRequired()
                    .HasColumnName("UnitSystem")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UpdateMinerals>(entity =>
            {
                entity.HasKey(e => e.MineralsId);

                entity.ToTable("UPDATE_MINERALS");

                entity.Property(e => e.MineralsId).HasColumnName("MineralsID");

                entity.Property(e => e.Al).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Al1)
                    .HasColumnName("Al_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.As).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.As1)
                    .HasColumnName("As_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Ba).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Ba1)
                    .HasColumnName("Ba_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Bo).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Bo1)
                    .HasColumnName("Bo_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Ca)
                    .HasColumnName("CA")
                    .HasColumnType("numeric(7, 4)");

                entity.Property(e => e.Ca1)
                    .HasColumnName("CA_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Cd).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Cd1)
                    .HasColumnName("Cd_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Cl).HasColumnType("numeric(7, 4)");

                entity.Property(e => e.Cl1)
                    .HasColumnName("Cl_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Co).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Co1)
                    .HasColumnName("Co_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Cr).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Cr1)
                    .HasColumnName("Cr_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Cu).HasColumnType("numeric(10, 4)");

                entity.Property(e => e.Cu1)
                    .HasColumnName("Cu_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Fe).HasColumnType("numeric(10, 4)");

                entity.Property(e => e.Fe1)
                    .HasColumnName("Fe_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Hg).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Hg1)
                    .HasColumnName("Hg_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.I).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.I1)
                    .HasColumnName("I_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.K).HasColumnType("numeric(7, 4)");

                entity.Property(e => e.K1)
                    .HasColumnName("K_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Mg).HasColumnType("numeric(7, 4)");

                entity.Property(e => e.Mg1)
                    .HasColumnName("Mg_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Mn).HasColumnType("numeric(10, 4)");

                entity.Property(e => e.Mn1)
                    .HasColumnName("Mn_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Mo).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Mo1)
                    .HasColumnName("Mo_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Na).HasColumnType("numeric(7, 4)");

                entity.Property(e => e.Na1)
                    .HasColumnName("Na_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.P).HasColumnType("numeric(7, 4)");

                entity.Property(e => e.P1)
                    .HasColumnName("P_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Pb).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Pb1)
                    .HasColumnName("Pb_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.Property(e => e.S).HasColumnType("numeric(7, 4)");

                entity.Property(e => e.S1)
                    .HasColumnName("S_1")
                    .HasColumnType("numeric(7, 2)");

                entity.Property(e => e.Sb).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Sb1)
                    .HasColumnName("Sb_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Se).HasColumnType("numeric(6, 2)");

                entity.Property(e => e.Se1)
                    .HasColumnName("Se_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Ti).HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Ti1)
                    .HasColumnName("Ti_1")
                    .HasColumnType("numeric(6, 1)");

                entity.Property(e => e.Zn).HasColumnType("numeric(10, 4)");

                entity.Property(e => e.Zn1)
                    .HasColumnName("Zn_1")
                    .HasColumnType("numeric(7, 2)");
            });

            modelBuilder.Entity<Useraccountpref>(entity =>
            {
                entity.ToTable("USERACCOUNTPREF");

                entity.Property(e => e.UserAccountPrefId).HasColumnName("UserAccountPrefID");

                entity.Property(e => e.AccountPrefId).HasColumnName("AccountPrefID");

                entity.HasOne(d => d.AccountPref)
                    .WithMany(p => p.Useraccountpref)
                    .HasForeignKey(d => d.AccountPrefId)
                    .HasConstraintName("FK_USERACCOUNTPREF_ACCOUNTPREF");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Useraccountpref)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_USERACCOUNTPREF_aspnet_Users");
            });

            modelBuilder.Entity<Useraccounts>(entity =>
            {
                entity.HasKey(e => e.UserAccountId);

                entity.ToTable("USERACCOUNTS");

                entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Userdetails>(entity =>
            {
                entity.ToTable("USERDETAILS");

                entity.Property(e => e.UserDetailsId).HasColumnName("UserDetailsID");

                entity.Property(e => e.AccountCode).HasMaxLength(50);

                entity.Property(e => e.Address1)
                    .HasColumnName("Address_1")
                    .HasMaxLength(150);

                entity.Property(e => e.Address2)
                    .HasColumnName("Address_2")
                    .HasMaxLength(150);

                entity.Property(e => e.Address3)
                    .HasColumnName("Address_3")
                    .HasMaxLength(150);

                entity.Property(e => e.AddressTypeId).HasColumnName("AddressTypeID");

                entity.Property(e => e.Affilated).HasMaxLength(100);

                entity.Property(e => e.BusinessName).HasMaxLength(50);

                entity.Property(e => e.CellPhone).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CopyTo).HasMaxLength(200);

                entity.Property(e => e.CountryCode).HasMaxLength(50);

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Fax)
                    .HasColumnName("FAX")
                    .HasMaxLength(50);

                entity.Property(e => e.FaxAnyTime)
                    .HasColumnName("Fax_AnyTime")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.ModifiedDt).HasColumnType("datetime");

                entity.Property(e => e.Municipality).HasMaxLength(50);

                entity.Property(e => e.OfflineLimit).HasDefaultValueSql("((0))");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasMaxLength(50);

                entity.Property(e => e.ReportForm)
                    .HasColumnName("Report_Form")
                    .HasMaxLength(150);

                entity.Property(e => e.WinLabName).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userdetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_USERDETAILS_aspnet_Users");
            });

            modelBuilder.Entity<Valactaexceldata>(entity =>
            {
                entity.HasKey(e => e.CopyToName);

                entity.ToTable("VALACTAEXCELDATA");

                entity.Property(e => e.CopyToName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AdrPrv)
                    .HasColumnName("ADR_PRV")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdrPrvAbbr)
                    .HasColumnName("ADR_PRV_ABBR")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactType)
                    .HasColumnName("CONTACT_TYPE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CtcId)
                    .HasColumnName("CTC_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CtcNo).HasColumnName("CTC_NO");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasColumnName("END_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.FarmName)
                    .HasColumnName("FARM_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HrdId).HasColumnName("HRD_ID");

                entity.Property(e => e.HrdPrvAbbr)
                    .HasColumnName("HRD_PRV_ABBR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lang)
                    .HasColumnName("LANG")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MailAddr1)
                    .HasColumnName("MAIL_ADDR_1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MailAddr2)
                    .HasColumnName("MAIL_ADDR_2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PstlCd)
                    .HasColumnName("PSTL_CD")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasColumnName("SURNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ValDmParameters>(entity =>
            {
                entity.HasKey(e => e.ValidateBatchId);

                entity.ToTable("VAL_DM_PARAMETERS");

                entity.Property(e => e.ValidateBatchId).HasColumnName("ValidateBatchID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FromCode).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StdDev).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ToCode).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.UseBias).HasColumnName("UseBIAS");
            });

            modelBuilder.Entity<ValDmRawdata>(entity =>
            {
                entity.HasKey(e => e.DmRawid);

                entity.ToTable("VAL_DM_RAWDATA");

                entity.Property(e => e.DmRawid).HasColumnName("DM_RAWID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Dm1Final)
                    .HasColumnName("DM1_FINAL")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Dm2Dry)
                    .HasColumnName("DM2_DRY")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Dm2Final)
                    .HasColumnName("DM2_FINAL")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Dm2Pan)
                    .HasColumnName("DM2_PAN")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Dm2Pansm)
                    .HasColumnName("DM2_PANSM")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Dm3Dry)
                    .HasColumnName("DM3_DRY")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Dm3Final)
                    .HasColumnName("DM3_FINAL")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Dm3Pan)
                    .HasColumnName("DM3_PAN")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Dm3Pansm)
                    .HasColumnName("DM3_PANSM")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.DmDry)
                    .HasColumnName("DM_DRY")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.DmPan)
                    .HasColumnName("DM_PAN")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.DmPansm)
                    .HasColumnName("DM_PANSM")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.HygroChem)
                    .HasColumnName("HYGRO_CHEM")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.HygroNir)
                    .HasColumnName("HYGRO_NIR")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.StdDev).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<ValDmRawdataTemp>(entity =>
            {
                entity.HasKey(e => e.DmRawTempid);

                entity.ToTable("VAL_DM_RAWDATA_TEMP");

                entity.Property(e => e.DmRawTempid).HasColumnName("DM_RAW_TEMPID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Code).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.Dm2Dry)
                    .HasColumnName("DM2_DRY")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Dm2Pan)
                    .HasColumnName("DM2_PAN")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Dm2Pansm)
                    .HasColumnName("DM2_PANSM")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Dm3Dry)
                    .HasColumnName("DM3_DRY")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Dm3Pan)
                    .HasColumnName("DM3_PAN")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Dm3Pansm)
                    .HasColumnName("DM3_PANSM")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.DmDry)
                    .HasColumnName("DM_DRY")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.DmPan)
                    .HasColumnName("DM_PAN")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.DmPansm)
                    .HasColumnName("DM_PANSM")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.HygroChem)
                    .HasColumnName("HYGRO_CHEM")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.HygroNir)
                    .HasColumnName("HYGRO_NIR")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.StdDev).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<ValDmValidData>(entity =>
            {
                entity.HasKey(e => e.DmValidId);

                entity.ToTable("VAL_DM_VALID_DATA");

                entity.Property(e => e.DmValidId).HasColumnName("DM_VALID_ID");

                entity.Property(e => e.CreatedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DmOutput)
                    .HasColumnName("DM_Output")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DmRawid).HasColumnName("DM_RAWID");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDmrecheck).HasColumnName("IsDMRecheck");

                entity.Property(e => e.IsDmvalid).HasColumnName("IsDMValid");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReviewerNotes)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ValMethodExceptions>(entity =>
            {
                entity.HasKey(e => e.ExceptionId);

                entity.ToTable("VAL_METHOD_EXCEPTIONS");

                entity.Property(e => e.ExceptionId).HasColumnName("ExceptionID");

                entity.Property(e => e.ExceptionMethodTypeId).HasColumnName("ExceptionMethodTypeID");

                entity.Property(e => e.ExceptionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptoinCase)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Output)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.ExceptionMethodType)
                    .WithMany(p => p.ValMethodExceptions)
                    .HasForeignKey(d => d.ExceptionMethodTypeId)
                    .HasConstraintName("FK_VAL_METHOD_EXCEPTIONS_VAL_METHODS");
            });

            modelBuilder.Entity<ValMethods>(entity =>
            {
                entity.HasKey(e => e.MethodId);

                entity.ToTable("VAL_METHODS");

                entity.Property(e => e.MethodId).HasColumnName("MethodID");

                entity.Property(e => e.MethodType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ValMethodTypes>(entity =>
            {
                entity.HasKey(e => e.MethodTypeId);

                entity.ToTable("VAL_METHOD_TYPES");

                entity.Property(e => e.MethodTypeId).HasColumnName("MethodTypeID");

                entity.Property(e => e.MethodId).HasColumnName("MethodID");

                entity.Property(e => e.MethodJoin).IsUnicode(false);

                entity.Property(e => e.MethodType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ValNaParameters>(entity =>
            {
                entity.HasKey(e => e.ValidateBatchId);

                entity.ToTable("VAL_NA_PARAMETERS");

                entity.Property(e => e.ValidateBatchId).HasColumnName("ValidateBatchID");

                entity.Property(e => e.Batch).HasColumnType("decimal(5, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FromCode).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StdDev).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ToCode).HasColumnType("decimal(3, 0)");

                entity.Property(e => e.UseBias).HasColumnName("UseBIAS");
            });

            modelBuilder.Entity<Water>(entity =>
            {
                entity.ToTable("WATER");

                entity.Property(e => e.WaterId).HasColumnName("WaterID");

                entity.Property(e => e.Alkalinity)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Bo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ca)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CaCo3)
                    .HasColumnName("CaCO3")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Chlorides)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CopyTo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Cu)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ecoli)
                    .HasColumnName("EColi")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fe)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.K)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Mg)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Mn)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Mo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Na)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nitrates)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NitratesNitrogen)
                    .HasColumnName("Nitrates_Nitrogen")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.P)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PH)
                    .HasColumnName("pH")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReportFor)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ResultsId).HasColumnName("ResultsID");

                entity.Property(e => e.Se)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SulfSulf)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SulfateSulfur)
                    .HasColumnName("Sulfate_Sulfur")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tds)
                    .HasColumnName("TDS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TotCol)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WaterSource)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zinc)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Results)
                    .WithMany(p => p.Water)
                    .HasForeignKey(d => d.ResultsId)
                    .HasConstraintName("FK_WATER_RESULTS");
            });

            modelBuilder.Entity<Wateranalysis>(entity =>
            {
                entity.ToTable("WATERANALYSIS");

                entity.Property(e => e.WaterAnalysisId).HasColumnName("WaterAnalysisID");

                entity.Property(e => e.DomesticPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.DomesticSpecialItemId).HasColumnName("DomesticSpecialItemID");

                entity.Property(e => e.IntSpecialItemId).HasColumnName("IntSpecialItemID");

                entity.Property(e => e.InternationalPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.WaterAnalysisCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.WaterAnalysisDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.WaterAnalysisValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.DomesticSpecialItem)
                    .WithMany(p => p.WateranalysisDomesticSpecialItem)
                    .HasForeignKey(d => d.DomesticSpecialItemId)
                    .HasConstraintName("FK_WATERANALYSIS_SPECIALITEMS");

                entity.HasOne(d => d.IntSpecialItem)
                    .WithMany(p => p.WateranalysisIntSpecialItem)
                    .HasForeignKey(d => d.IntSpecialItemId)
                    .HasConstraintName("FK_WATERANALYSIS_SPECIALITEMS1");
            });

            modelBuilder.Entity<Waterlevels>(entity =>
            {
                entity.ToTable("WATERLEVELS");

                entity.Property(e => e.WaterLevelsId).HasColumnName("WaterLevelsID");

                entity.Property(e => e.CattleLevels)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ColumnDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DrinkingWater)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FarmSurveyAvg)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wetchemistry>(entity =>
            {
                entity.ToTable("WETCHEMISTRY");

                entity.Property(e => e.WetChemistryId).HasColumnName("WetChemistryID");

                entity.Property(e => e.DomesticPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.InternationalPrice).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.WetChemistryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.WetChemistryDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.WetChemistryValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Accountaddress> Accountaddress { get; set; }
        public virtual DbSet<Accountcopytos> Accountcopytos { get; set; }
        public virtual DbSet<Accountpref> Accountpref { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Addresstype> Addresstype { get; set; }
        public virtual DbSet<Affiliatelabs> Affiliatelabs { get; set; }
        public virtual DbSet<Aminoacidanalysis> Aminoacidanalysis { get; set; }
        public virtual DbSet<Analysisoptions> Analysisoptions { get; set; }
        public virtual DbSet<Appearance> Appearance { get; set; }
        public virtual DbSet<Ash> Ash { get; set; }
        public virtual DbSet<AspnetApplications> AspnetApplications { get; set; }
        public virtual DbSet<AspnetMembership> AspnetMembership { get; set; }
        public virtual DbSet<AspnetPaths> AspnetPaths { get; set; }
        public virtual DbSet<AspnetPersonalizationAllUsers> AspnetPersonalizationAllUsers { get; set; }
        public virtual DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUser { get; set; }
        public virtual DbSet<AspnetProfile> AspnetProfile { get; set; }
        public virtual DbSet<AspnetRoles> AspnetRoles { get; set; }
        public virtual DbSet<AspnetSchemaVersions> AspnetSchemaVersions { get; set; }
        public virtual DbSet<AspnetUsers> AspnetUsers { get; set; }
        public virtual DbSet<AspnetUsersInRoles> AspnetUsersInRoles { get; set; }
        public virtual DbSet<AspnetWebEventEvents> AspnetWebEventEvents { get; set; }
        public virtual DbSet<Billitems> Billitems { get; set; }
        public virtual DbSet<Billtoaccounts> Billtoaccounts { get; set; }
        public virtual DbSet<Blurb> Blurb { get; set; }
        public virtual DbSet<Calculation> Calculation { get; set; }
        public virtual DbSet<Chemclass> Chemclass { get; set; }
        public virtual DbSet<Cho> Cho { get; set; }
        public virtual DbSet<Clientphotos> Clientphotos { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Cmsmedia> Cmsmedia { get; set; }
        public virtual DbSet<Cmspageml> Cmspageml { get; set; }
        public virtual DbSet<Cobrandaccounts> Cobrandaccounts { get; set; }
        public virtual DbSet<CobrandReportExceptions> CobrandReportExceptions { get; set; }
        public virtual DbSet<Cobrands> Cobrands { get; set; }
        public virtual DbSet<Completedsamples> Completedsamples { get; set; }
        public virtual DbSet<Components> Components { get; set; }
        public virtual DbSet<Condition> Condition { get; set; }
        public virtual DbSet<Contactus> Contactus { get; set; }
        public virtual DbSet<Contentlabel> Contentlabel { get; set; }
        public virtual DbSet<Contentlabelml> Contentlabelml { get; set; }
        public virtual DbSet<Copyto> Copyto { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CvasConfig> CvasConfig { get; set; }
        public virtual DbSet<Dm> Dm { get; set; }
        public virtual DbSet<ElmahError> ElmahError { get; set; }
        public virtual DbSet<Emailsamplesdetails> Emailsamplesdetails { get; set; }
        public virtual DbSet<Emailsamplesmapdetails> Emailsamplesmapdetails { get; set; }
        public virtual DbSet<Energytype> Energytype { get; set; }
        public virtual DbSet<Failedimport> Failedimport { get; set; }
        public virtual DbSet<Failedresults> Failedresults { get; set; }
        public virtual DbSet<Failedsamples> Failedsamples { get; set; }
        public virtual DbSet<FarmFeedCodes> FarmFeedCodes { get; set; }
        public virtual DbSet<Fat> Fat { get; set; }
        public virtual DbSet<Feedcodes> Feedcodes { get; set; }
        public virtual DbSet<FeedTypeAvgStdDev> FeedTypeAvgStdDev { get; set; }
        public virtual DbSet<Fermentation> Fermentation { get; set; }
        public virtual DbSet<Fertilization> Fertilization { get; set; }
        public virtual DbSet<Fibers> Fibers { get; set; }
        public virtual DbSet<FinalResults> FinalResults { get; set; }
        public virtual DbSet<IAnDfom> IAnDfom { get; set; }
        public virtual DbSet<ICsps> ICsps { get; set; }
        public virtual DbSet<IFattyacid> IFattyacid { get; set; }
        public virtual DbSet<IFattyacidOld> IFattyacidOld { get; set; }
        public virtual DbSet<IFermAnyalysys> IFermAnyalysys { get; set; }
        public virtual DbSet<IFermentation> IFermentation { get; set; }
        public virtual DbSet<IIntranetsubmission> IIntranetsubmission { get; set; }
        public virtual DbSet<ILogbook> ILogbook { get; set; }
        public virtual DbSet<IManure> IManure { get; set; }
        public virtual DbSet<IManureAmmonia> IManureAmmonia { get; set; }
        public virtual DbSet<IManureCa> IManureCa { get; set; }
        public virtual DbSet<IManureCl> IManureCl { get; set; }
        public virtual DbSet<IManureCu> IManureCu { get; set; }
        public virtual DbSet<IManureDensity> IManureDensity { get; set; }
        public virtual DbSet<IManureFe> IManureFe { get; set; }
        public virtual DbSet<IManureK> IManureK { get; set; }
        public virtual DbSet<IManureMg> IManureMg { get; set; }
        public virtual DbSet<IManureMineralsIcp> IManureMineralsIcp { get; set; }
        public virtual DbSet<IManureMn> IManureMn { get; set; }
        public virtual DbSet<IManureNa> IManureNa { get; set; }
        public virtual DbSet<IManureNitrogen> IManureNitrogen { get; set; }
        public virtual DbSet<IManurep> IManurep { get; set; }
        public virtual DbSet<IManurepH> IManurepH { get; set; }
        public virtual DbSet<IManureS> IManureS { get; set; }
        public virtual DbSet<IManureTotalSolids> IManureTotalSolids { get; set; }
        public virtual DbSet<IManureVolatilesSolids> IManureVolatilesSolids { get; set; }
        public virtual DbSet<IManureWep> IManureWep { get; set; }
        public virtual DbSet<IManureZn> IManureZn { get; set; }
        public virtual DbSet<IMoldIdentification> IMoldIdentification { get; set; }
        public virtual DbSet<IMoldIdentificationDetails> IMoldIdentificationDetails { get; set; }
        public virtual DbSet<IMoldsMaster> IMoldsMaster { get; set; }
        public virtual DbSet<INdfddata> INdfddata { get; set; }
        public virtual DbSet<INdfdinvitro> INdfdinvitro { get; set; }
        public virtual DbSet<INirdata> INirdata { get; set; }
        public virtual DbSet<Insitu> Insitu { get; set; }
        public virtual DbSet<INutrecoData> INutrecoData { get; set; }
        public virtual DbSet<Invitro> Invitro { get; set; }
        public virtual DbSet<Invitrodigestibility> Invitrodigestibility { get; set; }
        public virtual DbSet<IParticlesizeanalysis> IParticlesizeanalysis { get; set; }
        public virtual DbSet<IPdi> IPdi { get; set; }
        public virtual DbSet<Irrigation> Irrigation { get; set; }
        public virtual DbSet<Irrigationtype> Irrigationtype { get; set; }
        public virtual DbSet<IStEqLookup> IStEqLookup { get; set; }
        public virtual DbSet<ITimePoint> ITimePoint { get; set; }
        public virtual DbSet<ITmrfecal> ITmrfecal { get; set; }
        public virtual DbSet<IToxin> IToxin { get; set; }
        public virtual DbSet<IToxinlabs> IToxinlabs { get; set; }
        public virtual DbSet<IToxinmethod> IToxinmethod { get; set; }
        public virtual DbSet<IToxinnondetect> IToxinnondetect { get; set; }
        public virtual DbSet<Ivsd> Ivsd { get; set; }
        public virtual DbSet<Lablocations> Lablocations { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<LcodeNamesInfo> LcodeNamesInfo { get; set; }
        public virtual DbSet<Linkedaccounts> Linkedaccounts { get; set; }
        public virtual DbSet<LogFaxes> LogFaxes { get; set; }
        public virtual DbSet<ManageCustomExcel> ManageCustomExcel { get; set; }
        public virtual DbSet<Manureanalysis> Manureanalysis { get; set; }
        public virtual DbSet<Maturity> Maturity { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Memodetails> Memodetails { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Microbial> Microbial { get; set; }
        public virtual DbSet<Minerals> Minerals { get; set; }
        public virtual DbSet<MobAccounts> MobAccounts { get; set; }
        public virtual DbSet<MobAccountusers> MobAccountusers { get; set; }
        public virtual DbSet<MobAffiliatesamples> MobAffiliatesamples { get; set; }
        public virtual DbSet<MobBarcode> MobBarcode { get; set; }
        public virtual DbSet<MobCopyto> MobCopyto { get; set; }
        public virtual DbSet<MobCopytousers> MobCopytousers { get; set; }
        public virtual DbSet<MobFailedadssamples> MobFailedadssamples { get; set; }
        public virtual DbSet<MobPackagemappings> MobPackagemappings { get; set; }
        public virtual DbSet<MobSampleAccountMapping> MobSampleAccountMapping { get; set; }
        public virtual DbSet<MobSamplebags> MobSamplebags { get; set; }
        public virtual DbSet<MobSampleentry> MobSampleentry { get; set; }
        public virtual DbSet<MobSamplenotifications> MobSamplenotifications { get; set; }
        public virtual DbSet<MobSamplesubmissions> MobSamplesubmissions { get; set; }
        public virtual DbSet<MobSamplesubmissionsPackages> MobSamplesubmissionsPackages { get; set; }
        public virtual DbSet<MobSourcegroupoptions> MobSourcegroupoptions { get; set; }
        public virtual DbSet<MobSourcegroups> MobSourcegroups { get; set; }
        public virtual DbSet<MobSourceharvests> MobSourceharvests { get; set; }
        public virtual DbSet<MobUserdevices> MobUserdevices { get; set; }
        public virtual DbSet<Mycotoxins> Mycotoxins { get; set; }
        public virtual DbSet<Ndfd> Ndfd { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Newsmedia> Newsmedia { get; set; }
        public virtual DbSet<Nirclass> Nirclass { get; set; }
        public virtual DbSet<Nirdata> Nirdata { get; set; }
        public virtual DbSet<NirdataFileimport> NirdataFileimport { get; set; }
        public virtual DbSet<NirdataMdistNdist> NirdataMdistNdist { get; set; }
        public virtual DbSet<Nirequations> Nirequations { get; set; }
        public virtual DbSet<Niroptions> Niroptions { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<PackageInfo> PackageInfo { get; set; }
        public virtual DbSet<Planttissueanalysis> Planttissueanalysis { get; set; }
        public virtual DbSet<PrcPricing> PrcPricing { get; set; }
        public virtual DbSet<PrcTesttype> PrcTesttype { get; set; }
        public virtual DbSet<Processing> Processing { get; set; }
        public virtual DbSet<Processlog> Processlog { get; set; }
        public virtual DbSet<Prodname> Prodname { get; set; }
        public virtual DbSet<Proteins> Proteins { get; set; }
        public virtual DbSet<Proximate> Proximate { get; set; }
        public virtual DbSet<Qualitative> Qualitative { get; set; }
        public virtual DbSet<RangeFeedCodes> RangeFeedCodes { get; set; }
        public virtual DbSet<RangeFeedCodesNir> RangeFeedCodesNir { get; set; }
        public virtual DbSet<RangeResult> RangeResult { get; set; }
        public virtual DbSet<RangeResultIFerm> RangeResultIFerm { get; set; }
        public virtual DbSet<RangeResultNewLive> RangeResultNewLive { get; set; }
        public virtual DbSet<RangeResultNutrient> RangeResultNutrient { get; set; }
        public virtual DbSet<RangeTables> RangeTables { get; set; }
        public virtual DbSet<RangeTablesColumns> RangeTablesColumns { get; set; }
        public virtual DbSet<RationUseraccess> RationUseraccess { get; set; }
        public virtual DbSet<Rawdata> Rawdata { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Regionstates> Regionstates { get; set; }
        public virtual DbSet<ReportFormPreferences> ReportFormPreferences { get; set; }
        public virtual DbSet<ReportingAccounts> ReportingAccounts { get; set; }
        public virtual DbSet<ReportingColumns> ReportingColumns { get; set; }
        public virtual DbSet<ReportingCustompreference> ReportingCustompreference { get; set; }
        public virtual DbSet<ReportingCustomPreferenceDetails> ReportingCustomPreferenceDetails { get; set; }
        public virtual DbSet<ReportingFields> ReportingFields { get; set; }
        public virtual DbSet<ReportingLingualFields> ReportingLingualFields { get; set; }
        public virtual DbSet<ReportingQueue> ReportingQueue { get; set; }
        public virtual DbSet<ReportingTempPrinting> ReportingTempPrinting { get; set; }
        public virtual DbSet<ReportPreference> ReportPreference { get; set; }
        public virtual DbSet<ReportPreferenceMapping> ReportPreferenceMapping { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Rupreport> Rupreport { get; set; }
        public virtual DbSet<Sampleaditionalinformation> Sampleaditionalinformation { get; set; }
        public virtual DbSet<Samplenotes> Samplenotes { get; set; }
        public virtual DbSet<SampleprepCylinder> SampleprepCylinder { get; set; }
        public virtual DbSet<SampleprepLogins> SampleprepLogins { get; set; }
        public virtual DbSet<SampleprepPan> SampleprepPan { get; set; }
        public virtual DbSet<SampleprepSamples> SampleprepSamples { get; set; }
        public virtual DbSet<SampleprepStandardvesselWgt> SampleprepStandardvesselWgt { get; set; }
        public virtual DbSet<SampleprepVialPrintLog> SampleprepVialPrintLog { get; set; }
        public virtual DbSet<Samples> Samples { get; set; }
        public virtual DbSet<Samplescopyto> Samplescopyto { get; set; }
        public virtual DbSet<Samplesdrymatterdata> Samplesdrymatterdata { get; set; }
        public virtual DbSet<SampleSourceGroup> SampleSourceGroup { get; set; }
        public virtual DbSet<Samplestatus> Samplestatus { get; set; }
        public virtual DbSet<SamplesWinlabTest> SamplesWinlabTest { get; set; }
        public virtual DbSet<SampleUserNotes> SampleUserNotes { get; set; }
        public virtual DbSet<SatelliteChemLog> SatelliteChemLog { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<SmConfig> SmConfig { get; set; }
        public virtual DbSet<SmCustomFields> SmCustomFields { get; set; }
        public virtual DbSet<SmFullUpdateLog> SmFullUpdateLog { get; set; }
        public virtual DbSet<SmImportPreference> SmImportPreference { get; set; }
        public virtual DbSet<SmLabIdAuthenticate> SmLabIdAuthenticate { get; set; }
        public virtual DbSet<SmLanguage> SmLanguage { get; set; }
        public virtual DbSet<SmMobjson> SmMobjson { get; set; }
        public virtual DbSet<SmSamples> SmSamples { get; set; }
        public virtual DbSet<SmSampleTranslation> SmSampleTranslation { get; set; }
        public virtual DbSet<SmTranslationFields> SmTranslationFields { get; set; }
        public virtual DbSet<Specialitems> Specialitems { get; set; }
        public virtual DbSet<Srctype> Srctype { get; set; }
        public virtual DbSet<Starchdigestibility> Starchdigestibility { get; set; }
        public virtual DbSet<Statustype> Statustype { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<Storageconditions> Storageconditions { get; set; }
        public virtual DbSet<Sulfurimportlog> Sulfurimportlog { get; set; }
        public virtual DbSet<TagLabels> TagLabels { get; set; }
        public virtual DbSet<TagProducts> TagProducts { get; set; }
        public virtual DbSet<TblLinkNetUserToSamplesResultsSep02> TblLinkNetUserToSamplesResultsSep02 { get; set; }
        public virtual DbSet<TempBatchlog> TempBatchlog { get; set; }
        public virtual DbSet<TempCompletedsamples> TempCompletedsamples { get; set; }
        public virtual DbSet<TempMinerals> TempMinerals { get; set; }
        public virtual DbSet<TmrFecalMappings> TmrFecalMappings { get; set; }
        public virtual DbSet<Toxins> Toxins { get; set; }
        public virtual DbSet<TRangeFeedCodes> TRangeFeedCodes { get; set; }
        public virtual DbSet<TRangeResult> TRangeResult { get; set; }
        public virtual DbSet<UnitSystem> UnitSystem { get; set; }
        public virtual DbSet<UpdateMinerals> UpdateMinerals { get; set; }
        public virtual DbSet<Useraccountpref> Useraccountpref { get; set; }
        public virtual DbSet<Useraccounts> Useraccounts { get; set; }
        public virtual DbSet<Userdetails> Userdetails { get; set; }
        public virtual DbSet<Valactaexceldata> Valactaexceldata { get; set; }
        public virtual DbSet<ValDmParameters> ValDmParameters { get; set; }
        public virtual DbSet<ValDmRawdata> ValDmRawdata { get; set; }
        public virtual DbSet<ValDmRawdataTemp> ValDmRawdataTemp { get; set; }
        public virtual DbSet<ValDmValidData> ValDmValidData { get; set; }
        public virtual DbSet<ValMethodExceptions> ValMethodExceptions { get; set; }
        public virtual DbSet<ValMethods> ValMethods { get; set; }
        public virtual DbSet<ValMethodTypes> ValMethodTypes { get; set; }
        public virtual DbSet<ValNaParameters> ValNaParameters { get; set; }
        public virtual DbSet<Water> Water { get; set; }
        public virtual DbSet<Wateranalysis> Wateranalysis { get; set; }
        public virtual DbSet<Waterlevels> Waterlevels { get; set; }
        public virtual DbSet<Wetchemistry> Wetchemistry { get; set; }

    }
}
