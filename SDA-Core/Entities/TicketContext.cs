using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace SDA_Core.Entities
{
    public partial class TicketContext : DbContext
    {
        public TicketContext()
        {
        }

        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityDefinition> ActivityDefinitions { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Bu> buses { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<IdDefinition> IdDefinitions { get; set; }
        public virtual DbSet<IdSetting> IdSettings { get; set; }
        public virtual DbSet<Licence> Licences { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Lookup> Lookups { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<ObjectState> ObjectStates { get; set; }
        public virtual DbSet<ObjectStateDefinition> ObjectStateDefinitions { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public virtual DbSet<OrganizationUnitDefinition> OrganizationUnitDefinitions { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Preference> Preferences { get; set; }
        public virtual DbSet<Pricing> Pricings { get; set; }
        public virtual DbSet<Refund> Refunds { get; set; }
        public virtual DbSet<Relation> Relations { get; set; }
        public virtual DbSet<RoleMapper> RoleMappers { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<SeatArrangement> SeatArrangements { get; set; }
        public virtual DbSet<Temporary> Temporaries { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<TripTransaction> TripTransactions { get; set; }
        public virtual DbSet<TypeList> TypeLists { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserPrivilege> UserPrivileges { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<VoucherConsignee> VoucherConsignees { get; set; }
        public virtual DbSet<VwActivity> VwActivities { get; set; }
        public virtual DbSet<VwAttendantList> VwAttendantLists { get; set; }
        public virtual DbSet<VwBu> VwBus { get; set; }
        public virtual DbSet<VwDocumentBrowser> VwDocumentBrowsers { get; set; }
        public virtual DbSet<VwGeneralReportsView> VwGeneralReportsViews { get; set; }
        public virtual DbSet<VwLineItemObject> VwLineItemObjects { get; set; }
        public virtual DbSet<VwOrgUnitDefinition> VwOrgUnitDefinitions { get; set; }
        public virtual DbSet<VwPersonAddress> VwPersonAddresses { get; set; }
        public virtual DbSet<VwRelation> VwRelations { get; set; }
        public virtual DbSet<VwTrip> VwTrips { get; set; }
        public virtual DbSet<VwTripInfo> VwTripInfos { get; set; }
        public virtual DbSet<VwTripTransaction> VwTripTransactions { get; set; }
        public virtual DbSet<VwVoucherActivity> VwVoucherActivities { get; set; }
        public virtual DbSet<VwVoucherDetailView> VwVoucherDetailViews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                        .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("TicketEntities"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Activity", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.ActivityDefinition).HasColumnName("activityDefinition");

                entity.Property(e => e.Device)
                    .HasMaxLength(26)
                    .HasColumnName("device");

                entity.Property(e => e.EndTimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("endTimeStamp");

                entity.Property(e => e.OrganizationUnitDefinition)
                    .HasMaxLength(26)
                    .HasColumnName("organizationUnitDefinition");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("reference");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.StartTimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("startTimeStamp");

                entity.Property(e => e.User)
                    .HasMaxLength(26)
                    .HasColumnName("user");

                entity.HasOne(d => d.ActivityDefinitionNavigation)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.ActivityDefinition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_ActivityDefinition");

                entity.HasOne(d => d.OrganizationUnitDefinitionNavigation)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.OrganizationUnitDefinition)
                    .HasConstraintName("FK_Activity_OrganizationUnitDefinition");
            });

            modelBuilder.Entity<ActivityDefinition>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("ActivityDefinition", "BUS");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Module).HasColumnName("module");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.HasOne(d => d.ModuleNavigation)
                    .WithMany(p => p.ActivityDefinitions)
                    .HasForeignKey(d => d.Module)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityDefinition_Module");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Address", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("reference");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("type");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Lookup");
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Attachment", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("category");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("reference");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("type");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(265)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<Bu>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Bus", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.PlateNumber)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("plateNumber");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.SideNumber)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("sideNumber");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("type");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Bus)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bus_Preference");
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Configuration", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("attribute");

                entity.Property(e => e.CurrentValue)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("currentValue");

                entity.Property(e => e.Preference)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("preference");

                entity.Property(e => e.Reference).HasColumnName("reference");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Device", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("name");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("type");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Device_Lookup");
            });

            modelBuilder.Entity<IdDefinition>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("IdDefinition", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Prefix)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("prefix");

                entity.Property(e => e.PrefixSeparator)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("prefixSeparator");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Suffix)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("suffix");

                entity.Property(e => e.SuffixSeparator)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("suffixSeparator");
            });

            modelBuilder.Entity<IdSetting>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("IdSetting", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.CurrentValue).HasColumnName("currentValue");

                entity.Property(e => e.IdDefinition)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("idDefinition");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("reference");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.StartFrom).HasColumnName("startFrom");

                entity.HasOne(d => d.IdDefinitionNavigation)
                    .WithMany(p => p.IdSettings)
                    .HasForeignKey(d => d.IdDefinition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdSetting_IdDefinition");

                entity.HasOne(d => d.ReferenceNavigation)
                    .WithMany(p => p.IdSettings)
                    .HasForeignKey(d => d.Reference)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdSetting_TypeList");
            });

            modelBuilder.Entity<Licence>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Licence", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Licence1)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("licence");

                entity.Property(e => e.Reference).HasColumnName("reference");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.HasOne(d => d.ReferenceNavigation)
                    .WithMany(p => p.Licences)
                    .HasForeignKey(d => d.Reference)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Licence_Module");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("LineItem", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Discount)
                    .HasColumnType("money")
                    .HasColumnName("discount");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("quantity");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("money")
                    .HasColumnName("totalAmount");

                entity.Property(e => e.Trip)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("trip");

                entity.Property(e => e.UnitAmount)
                    .HasColumnType("money")
                    .HasColumnName("unitAmount");

                entity.Property(e => e.Voucher)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("voucher");

                entity.HasOne(d => d.VoucherNavigation)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.Voucher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LineItem_Voucher");
            });

            modelBuilder.Entity<Lookup>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Lookup", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Module", "BUS");

                entity.Property(e => e.Code)
                    .ValueGeneratedNever()
                    .HasColumnName("code");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Parent)
                    .HasMaxLength(26)
                    .HasColumnName("parent");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");
            });

            modelBuilder.Entity<ObjectState>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("ObjectState", "BUS");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.ObjectStateDefinition).HasColumnName("objectStateDefinition");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("reference");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.HasOne(d => d.ObjectStateDefinitionNavigation)
                    .WithMany(p => p.ObjectStates)
                    .HasForeignKey(d => d.ObjectStateDefinition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ObjectState_ObjectStateDefinition");
            });

            modelBuilder.Entity<ObjectStateDefinition>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("ObjectStateDefinition", "BUS");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Color)
                    .HasMaxLength(26)
                    .HasColumnName("color");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Type)
                    .HasMaxLength(26)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Organization", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.BrandName).HasColumnName("brandName");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Preference)
                    .HasMaxLength(26)
                    .HasColumnName("preference");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.TradeName)
                    .IsRequired()
                    .HasColumnName("tradeName");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("type");

                entity.HasOne(d => d.PreferenceNavigation)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.Preference)
                    .HasConstraintName("FK_Organization_Preference");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Organization_TypeList");
            });

            modelBuilder.Entity<OrganizationUnit>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("OrganizationUnit", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.OrganizationUnitDefinition)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("organizationUnitDefinition");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("reference");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.HasOne(d => d.OrganizationUnitDefinitionNavigation)
                    .WithMany(p => p.OrganizationUnits)
                    .HasForeignKey(d => d.OrganizationUnitDefinition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganizationUnit_OrganizationUnitDefinition");
            });

            modelBuilder.Entity<OrganizationUnitDefinition>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("OrganizationUnitDefinition", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Abbrivation)
                    .HasMaxLength(26)
                    .HasColumnName("abbrivation");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Parent)
                    .HasMaxLength(26)
                    .HasColumnName("parent");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Specialization)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("specialization");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("type");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.OrganizationUnitDefinitions)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganizationUnitDefinition_Lookup");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Person", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("gender");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastName)
                    .HasMaxLength(26)
                    .HasColumnName("lastName");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("middleName");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("position");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("title");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("type");

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.PersonGenderNavigations)
                    .HasForeignKey(d => d.Gender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_LookupGender");

                entity.HasOne(d => d.PositionNavigation)
                    .WithMany(p => p.PersonPositionNavigations)
                    .HasForeignKey(d => d.Position)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_LookupPosition");

                entity.HasOne(d => d.TitleNavigation)
                    .WithMany(p => p.PersonTitleNavigations)
                    .HasForeignKey(d => d.Title)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_Lookup");
            });

            modelBuilder.Entity<Preference>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Preference", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.Index).HasColumnName("index");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Parent)
                    .HasMaxLength(26)
                    .HasColumnName("parent");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("type");

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Pricing>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Pricing", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("discount");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("reference");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.UnitAmount)
                    .HasColumnType("money")
                    .HasColumnName("unitAmount");
            });

            modelBuilder.Entity<Refund>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Refund", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Amount)
                    .HasColumnType("money")
                    .HasColumnName("amount");

                entity.Property(e => e.Percent).HasColumnName("percent");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("reference");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Relation>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Relation", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("reference");

                entity.Property(e => e.Referring)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("referring");

                entity.Property(e => e.RelationLevel)
                    .HasMaxLength(26)
                    .HasColumnName("relationLevel");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<RoleMapper>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("RoleMapper", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expiryDate");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("role");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("user");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.RoleMappers)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleMapper_OrganizationUnitDefinition");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.RoleMappers)
                    .HasForeignKey(d => d.User)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleMapper_User");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Route", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("destination");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("source");

                entity.Property(e => e.TimeLength)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("timeLength");

                entity.HasOne(d => d.DestinationNavigation)
                    .WithMany(p => p.RouteDestinationNavigations)
                    .HasForeignKey(d => d.Destination)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Route_Lookup");

                entity.HasOne(d => d.SourceNavigation)
                    .WithMany(p => p.RouteSourceNavigations)
                    .HasForeignKey(d => d.Source)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Route_Lookup1");
            });

            modelBuilder.Entity<SeatArrangement>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_SearArrangement");

                entity.ToTable("SeatArrangement", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("name");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("reference");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("type");

                entity.Property(e => e.X).HasColumnName("x");

                entity.Property(e => e.Y).HasColumnName("y");

                entity.HasOne(d => d.ReferenceNavigation)
                    .WithMany(p => p.SeatArrangements)
                    .HasForeignKey(d => d.Reference)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SearArrangement_Bus");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.SeatArrangements)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SearArrangement_Lookup");
            });

            modelBuilder.Entity<Temporary>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Temporary", "BUS");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Reference)
                    .HasMaxLength(26)
                    .HasColumnName("reference");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Trip", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Bus)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("bus");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastActivity)
                    .HasMaxLength(26)
                    .HasColumnName("lastActivity");

                entity.Property(e => e.ObjectState).HasColumnName("objectState");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Route)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("route");

                entity.HasOne(d => d.BusNavigation)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.Bus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trip_Bus");

                entity.HasOne(d => d.ObjectStateNavigation)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.ObjectState)
                    .HasConstraintName("FK_Trip_ObjectStateDefinition");

                entity.HasOne(d => d.RouteNavigation)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.Route)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trip_Route");
            });

            modelBuilder.Entity<TripTransaction>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("TripTransaction", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.LineItem)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("lineItem");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Seat)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("seat");

                entity.HasOne(d => d.LineItemNavigation)
                    .WithMany(p => p.TripTransactions)
                    .HasForeignKey(d => d.LineItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TripTransaction_LineItem");
            });

            modelBuilder.Entity<TypeList>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("TypeList", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("category");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Remark).HasColumnName("remark");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("User", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LoggedInStatus).HasColumnName("loggedInStatus");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("password");

                entity.Property(e => e.Person)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("person");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("userName");

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Person");
            });

            modelBuilder.Entity<UserPrivilege>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("UserPrivilege", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.ActivityDefinition).HasColumnName("activityDefinition");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("role");

                entity.HasOne(d => d.ActivityDefinitionNavigation)
                    .WithMany(p => p.UserPrivileges)
                    .HasForeignKey(d => d.ActivityDefinition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPrivilege_ActivityDefinition");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Voucher", "BUS");

                entity.Property(e => e.Code)
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Consignee).HasColumnName("consignee");

                entity.Property(e => e.GrandTotal)
                    .HasColumnType("money")
                    .HasColumnName("grandTotal");

                entity.Property(e => e.IsChild).HasColumnName("isChild");

                entity.Property(e => e.IsIssued).HasColumnName("isIssued");

                entity.Property(e => e.IsVoid).HasColumnName("isVoid");

                entity.Property(e => e.IssuedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("issuedDate");

                entity.Property(e => e.LastActivity)
                    .HasMaxLength(26)
                    .HasColumnName("lastActivity");

                entity.Property(e => e.LastObjectState)
                    .HasMaxLength(26)
                    .HasColumnName("lastObjectState");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.Type)
                    .HasMaxLength(26)
                    .HasColumnName("type");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK_Voucher_Lookup");
            });

            modelBuilder.Entity<VoucherConsignee>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_voucherConsignee");

                entity.ToTable("VoucherConsignee", "BUS");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("middleName");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("mobile");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");
            });

            modelBuilder.Entity<VwActivity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Activity", "BUS");

                entity.Property(e => e.ActivityDefinition).HasColumnName("activityDefinition");

                entity.Property(e => e.ActivityDefinitionDesc)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("activityDefinitionDesc");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Device)
                    .HasMaxLength(26)
                    .HasColumnName("device");

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasMaxLength(26);

                entity.Property(e => e.EndTimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("endTimeStamp");

                entity.Property(e => e.OrganizationUnitDefinition)
                    .HasMaxLength(26)
                    .HasColumnName("organizationUnitDefinition");

                entity.Property(e => e.OrganizationUnitDefnDesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("organizationUnitDefnDesc");

                entity.Property(e => e.Person)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("person");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("reference");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.StartTimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("startTimeStamp");

                entity.Property(e => e.User)
                    .HasMaxLength(26)
                    .HasColumnName("user");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("user_name");
            });

            modelBuilder.Entity<VwAttendantList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_AttendantList", "BUS");

                entity.Property(e => e.BusCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("busCode");

                entity.Property(e => e.ConsigneeCode).HasColumnName("consigneeCode");

                entity.Property(e => e.ConsigneeFirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("consigneeFirstName");

                entity.Property(e => e.ConsigneeLastName)
                    .HasMaxLength(50)
                    .HasColumnName("consigneeLastName");

                entity.Property(e => e.ConsigneeMiddleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("consigneeMiddleName");

                entity.Property(e => e.ConsigneeMobile)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("consigneeMobile");

                entity.Property(e => e.IssuedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("issuedDate");

                entity.Property(e => e.RouteCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("routeCode");

                entity.Property(e => e.SeatCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("seatCode");

                entity.Property(e => e.SeatName)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("seatName");

                entity.Property(e => e.TripCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("tripCode");

                entity.Property(e => e.TripDate)
                    .HasColumnType("datetime")
                    .HasColumnName("tripDate");

                entity.Property(e => e.VoucherCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("voucherCode");
            });

            modelBuilder.Entity<VwBu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Bus", "BUS");

                entity.Property(e => e.Capacity)
                    .IsRequired()
                    .HasColumnName("capacity");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.PlateNumber)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("plateNumber");

                entity.Property(e => e.SideNumber)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("sideNumber");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<VwDocumentBrowser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_DocumentBrowser", "BUS");

                entity.Property(e => e.ActivityDefCode).HasColumnName("activityDefCode");

                entity.Property(e => e.ActivityDefDesc)
                    .HasMaxLength(26)
                    .HasColumnName("activityDefDesc");

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(26)
                    .HasColumnName("branchCode");

                entity.Property(e => e.BranchDesc)
                    .HasMaxLength(100)
                    .HasColumnName("branchDesc");

                entity.Property(e => e.ConsigneeCode).HasColumnName("consigneeCode");

                entity.Property(e => e.ConsigneeFirstName)
                    .HasMaxLength(50)
                    .HasColumnName("consigneeFirstName");

                entity.Property(e => e.ConsigneeLastName)
                    .HasMaxLength(50)
                    .HasColumnName("consigneeLastName");

                entity.Property(e => e.ConsigneeMiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("consigneeMiddleName");

                entity.Property(e => e.ConsigneeMobile)
                    .HasMaxLength(26)
                    .HasColumnName("consigneeMobile");

                entity.Property(e => e.DeviceCode)
                    .HasMaxLength(26)
                    .HasColumnName("deviceCode");

                entity.Property(e => e.DeviceDesc)
                    .HasMaxLength(26)
                    .HasColumnName("deviceDesc");

                entity.Property(e => e.GrandTotal)
                    .HasColumnType("money")
                    .HasColumnName("grandTotal");

                entity.Property(e => e.IsIssued).HasColumnName("isIssued");

                entity.Property(e => e.IsVoid).HasColumnName("isVoid");

                entity.Property(e => e.IssuedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("issuedDate");

                entity.Property(e => e.LastActCode)
                    .HasMaxLength(26)
                    .HasColumnName("lastActCode");

                entity.Property(e => e.LastObjectStateCode)
                    .HasMaxLength(26)
                    .HasColumnName("lastObjectStateCode");

                entity.Property(e => e.OsdCode).HasColumnName("osdCode");

                entity.Property(e => e.OsdColor)
                    .HasMaxLength(26)
                    .HasColumnName("osdColor");

                entity.Property(e => e.OsdDesc)
                    .HasMaxLength(50)
                    .HasColumnName("osdDesc");

                entity.Property(e => e.Type)
                    .HasMaxLength(26)
                    .HasColumnName("type");

                entity.Property(e => e.TypeDesc).HasColumnName("typeDesc");

                entity.Property(e => e.UserCode)
                    .HasMaxLength(26)
                    .HasColumnName("userCode");

                entity.Property(e => e.UserName)
                    .HasMaxLength(15)
                    .HasColumnName("userName");

                entity.Property(e => e.VoucherCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("voucherCode");
            });

            modelBuilder.Entity<VwGeneralReportsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_GeneralReportsView", "BUS");

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("branchCode");

                entity.Property(e => e.BranchDesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("branchDesc");

                entity.Property(e => e.BusCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("busCode");

                entity.Property(e => e.BusType)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("busType");

                entity.Property(e => e.ChildrenDiscountAmount)
                    .HasColumnType("money")
                    .HasColumnName("childrenDiscountAmount");

                entity.Property(e => e.ChildrenDiscountPercent).HasColumnName("childrenDiscountPercent");

                entity.Property(e => e.Consignee).HasColumnName("consignee");

                entity.Property(e => e.Discount)
                    .HasColumnType("money")
                    .HasColumnName("discount");

                entity.Property(e => e.GrandTotal)
                    .HasColumnType("money")
                    .HasColumnName("grandTotal");

                entity.Property(e => e.IsPassangerChild).HasColumnName("isPassangerChild");

                entity.Property(e => e.IsVoid).HasColumnName("isVoid");

                entity.Property(e => e.IssuedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("issuedDate");

                entity.Property(e => e.LastObjectState)
                    .HasMaxLength(26)
                    .HasColumnName("lastObjectState");

                entity.Property(e => e.LineItemCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("lineItemCode");

                entity.Property(e => e.PlateNumber)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("plateNumber");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("quantity");

                entity.Property(e => e.RedundType)
                    .HasMaxLength(26)
                    .HasColumnName("redundType");

                entity.Property(e => e.Reference)
                    .HasMaxLength(26)
                    .HasColumnName("reference");

                entity.Property(e => e.RefundAmount)
                    .HasColumnType("money")
                    .HasColumnName("refundAmount");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .HasColumnName("remark");

                entity.Property(e => e.RouteCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("routeCode");

                entity.Property(e => e.RouteDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("routeDesc");

                entity.Property(e => e.RouteDestination)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("routeDestination");

                entity.Property(e => e.RouteSrc)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("routeSrc");

                entity.Property(e => e.SideNumber)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("sideNumber");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("money")
                    .HasColumnName("totalAmount");

                entity.Property(e => e.TripCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("tripCode");

                entity.Property(e => e.TripDate)
                    .HasColumnType("datetime")
                    .HasColumnName("tripDate");

                entity.Property(e => e.UnitAmount)
                    .HasColumnType("money")
                    .HasColumnName("unitAmount");

                entity.Property(e => e.VoucherCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("voucherCode");

                entity.Property(e => e.VoucherType)
                    .HasMaxLength(26)
                    .HasColumnName("voucherType");
            });

            modelBuilder.Entity<VwLineItemObject>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_LineItemObjects", "BUS");

                entity.Property(e => e.BusCode)
                    .HasMaxLength(26)
                    .HasColumnName("busCode");

                entity.Property(e => e.BusDesc)
                    .HasMaxLength(100)
                    .HasColumnName("busDesc");

                entity.Property(e => e.Discount)
                    .HasColumnType("money")
                    .HasColumnName("discount");

                entity.Property(e => e.LineItemCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("lineItemCode");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("quantity");

                entity.Property(e => e.RouteCode)
                    .HasMaxLength(26)
                    .HasColumnName("routeCode");

                entity.Property(e => e.RouteDesc)
                    .HasMaxLength(50)
                    .HasColumnName("routeDesc");

                entity.Property(e => e.SeatCode)
                    .HasMaxLength(26)
                    .HasColumnName("seatCode");

                entity.Property(e => e.SeatName)
                    .HasMaxLength(26)
                    .HasColumnName("seatName");

                entity.Property(e => e.TripCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("tripCode");

                entity.Property(e => e.UnitAmount)
                    .HasColumnType("money")
                    .HasColumnName("unitAmount");

                entity.Property(e => e.VoucherCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("voucherCode");
            });

            modelBuilder.Entity<VwOrgUnitDefinition>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_OrgUnitDefinition", "BUS");

                entity.Property(e => e.Abbrivation)
                    .HasMaxLength(26)
                    .HasColumnName("abbrivation");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Parent)
                    .HasMaxLength(26)
                    .HasColumnName("parent");

                entity.Property(e => e.SpecializationCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("specializationCode");

                entity.Property(e => e.SpecializationDesc)
                    .IsRequired()
                    .HasColumnName("specializationDesc");

                entity.Property(e => e.TypeCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("typeCode");

                entity.Property(e => e.TypeDesc)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("typeDesc");
            });

            modelBuilder.Entity<VwPersonAddress>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_PersonAddress", "BUS");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("firstName");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("fullName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(26)
                    .HasColumnName("lastName");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("middleName");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("title");

                entity.Property(e => e.TitleDesc).HasColumnName("titleDesc");

                entity.Property(e => e.TypeCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("typeCode");

                entity.Property(e => e.TypeDesc).HasColumnName("typeDesc");
            });

            modelBuilder.Entity<VwRelation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Relation", "BUS");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.PersonName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("personName");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("reference");

                entity.Property(e => e.Referring)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("referring");

                entity.Property(e => e.RelationLevel)
                    .HasMaxLength(26)
                    .HasColumnName("relationLevel");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<VwTrip>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Trip", "BUS");

                entity.Property(e => e.BusCapacity).HasColumnName("busCapacity");

                entity.Property(e => e.BusCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("busCode");

                entity.Property(e => e.BusDesc)
                    .HasMaxLength(100)
                    .HasColumnName("busDesc");

                entity.Property(e => e.BusTypeCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("busTypeCode");

                entity.Property(e => e.BusTypeDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("busTypeDesc");

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("discount");

                entity.Property(e => e.PlateNumber)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("plateNumber");

                entity.Property(e => e.RouteCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("routeCode");

                entity.Property(e => e.RouteDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("routeDesc");

                entity.Property(e => e.SideNumber)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("sideNumber");

                entity.Property(e => e.TripCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("tripCode");

                entity.Property(e => e.TripDate)
                    .HasColumnType("datetime")
                    .HasColumnName("tripDate");

                entity.Property(e => e.UnitAmount)
                    .HasColumnType("money")
                    .HasColumnName("unitAmount");
            });

            modelBuilder.Entity<VwTripInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_TripInfo", "BUS");

                entity.Property(e => e.BusCapacity).HasColumnName("busCapacity");

                entity.Property(e => e.BusCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("busCode");

                entity.Property(e => e.BusDesc)
                    .HasMaxLength(100)
                    .HasColumnName("busDesc");

                entity.Property(e => e.BusTypeCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("busTypeCode");

                entity.Property(e => e.BusTypeDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("busTypeDesc");

                entity.Property(e => e.ObjectState).HasColumnName("objectState");

                entity.Property(e => e.PlateNumber)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("plateNumber");

                entity.Property(e => e.RouteCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("routeCode");

                entity.Property(e => e.RouteDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("routeDesc");

                entity.Property(e => e.RouteUnitAmount)
                    .HasColumnType("money")
                    .HasColumnName("routeUnitAmount");

                entity.Property(e => e.SideNumber)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("sideNumber");

                entity.Property(e => e.TimeLength)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("timeLength");

                entity.Property(e => e.TripCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("tripCode");

                entity.Property(e => e.TripDate)
                    .HasColumnType("datetime")
                    .HasColumnName("tripDate");

                entity.Property(e => e.TripDiscount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tripDiscount");

                entity.Property(e => e.TripIsActive).HasColumnName("tripIsActive");

                entity.Property(e => e.TripUnitAmount)
                    .HasColumnType("money")
                    .HasColumnName("tripUnitAmount");
            });

            modelBuilder.Entity<VwTripTransaction>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_TripTransaction", "BUS");

                entity.Property(e => e.Bus)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("bus");

                entity.Property(e => e.LineItem)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("lineItem");

                entity.Property(e => e.Seat)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("seat");

                entity.Property(e => e.TripCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("tripCode");

                entity.Property(e => e.TripTransactionCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("tripTransactionCode");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<VwVoucherActivity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_VoucherActivity", "BUS");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("code");

                entity.Property(e => e.GrandTotal)
                    .HasColumnType("money")
                    .HasColumnName("grandTotal");

                entity.Property(e => e.IsVoid).HasColumnName("isVoid");

                entity.Property(e => e.IssuedDate)
                    .HasMaxLength(4000)
                    .HasColumnName("issuedDate");

                entity.Property(e => e.User)
                    .HasMaxLength(26)
                    .HasColumnName("user");
            });

            modelBuilder.Entity<VwVoucherDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_VoucherDetailView", "BUS");

                entity.Property(e => e.ActivityDefCode).HasColumnName("activityDefCode");

                entity.Property(e => e.ActivityDefDesc)
                    .HasMaxLength(26)
                    .HasColumnName("activityDefDesc");

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(26)
                    .HasColumnName("branchCode");

                entity.Property(e => e.BranchDesc)
                    .HasMaxLength(100)
                    .HasColumnName("branchDesc");

                entity.Property(e => e.BusCode)
                    .HasMaxLength(26)
                    .HasColumnName("busCode");

                entity.Property(e => e.BusDesc)
                    .HasMaxLength(100)
                    .HasColumnName("busDesc");

                entity.Property(e => e.ConsigneeCode).HasColumnName("consigneeCode");

                entity.Property(e => e.ConsigneeFirstName)
                    .HasMaxLength(50)
                    .HasColumnName("consigneeFirstName");

                entity.Property(e => e.ConsigneeLastName)
                    .HasMaxLength(50)
                    .HasColumnName("consigneeLastName");

                entity.Property(e => e.ConsigneeMiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("consigneeMiddleName");

                entity.Property(e => e.ConsigneeMobile)
                    .HasMaxLength(26)
                    .HasColumnName("consigneeMobile");

                entity.Property(e => e.DeviceCode)
                    .HasMaxLength(26)
                    .HasColumnName("deviceCode");

                entity.Property(e => e.DeviceDesc)
                    .HasMaxLength(26)
                    .HasColumnName("deviceDesc");

                entity.Property(e => e.Discount)
                    .HasColumnType("money")
                    .HasColumnName("discount");

                entity.Property(e => e.GrandTotal)
                    .HasColumnType("money")
                    .HasColumnName("grandTotal");

                entity.Property(e => e.IsIssued).HasColumnName("isIssued");

                entity.Property(e => e.IsVoid).HasColumnName("isVoid");

                entity.Property(e => e.IssuedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("issuedDate");

                entity.Property(e => e.LastActCode)
                    .HasMaxLength(26)
                    .HasColumnName("lastActCode");

                entity.Property(e => e.LastObjectStateCode)
                    .HasMaxLength(26)
                    .HasColumnName("lastObjectStateCode");

                entity.Property(e => e.LineItemCode)
                    .HasMaxLength(26)
                    .HasColumnName("lineItemCode");

                entity.Property(e => e.OsdCode).HasColumnName("osdCode");

                entity.Property(e => e.OsdColor)
                    .HasMaxLength(26)
                    .HasColumnName("osdColor");

                entity.Property(e => e.OsdDesc)
                    .HasMaxLength(50)
                    .HasColumnName("osdDesc");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("quantity");

                entity.Property(e => e.RouteCode)
                    .HasMaxLength(26)
                    .HasColumnName("routeCode");

                entity.Property(e => e.RouteDesc)
                    .HasMaxLength(50)
                    .HasColumnName("routeDesc");

                entity.Property(e => e.SeatCode)
                    .HasMaxLength(26)
                    .HasColumnName("seatCode");

                entity.Property(e => e.SeatName)
                    .HasMaxLength(26)
                    .HasColumnName("seatName");

                entity.Property(e => e.TripCode)
                    .HasMaxLength(26)
                    .HasColumnName("tripCode");

                entity.Property(e => e.Type)
                    .HasMaxLength(26)
                    .HasColumnName("type");

                entity.Property(e => e.TypeDesc).HasColumnName("typeDesc");

                entity.Property(e => e.UnitAmount)
                    .HasColumnType("money")
                    .HasColumnName("unitAmount");

                entity.Property(e => e.UserCode)
                    .HasMaxLength(26)
                    .HasColumnName("userCode");

                entity.Property(e => e.UserName)
                    .HasMaxLength(15)
                    .HasColumnName("userName");

                entity.Property(e => e.VoucherCode)
                    .IsRequired()
                    .HasMaxLength(26)
                    .HasColumnName("voucherCode");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
