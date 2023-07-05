using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcceptanceOfSwitchRequest> AcceptanceOfSwitchRequests { get; set; }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<Battery> Batteries { get; set; }

    public virtual DbSet<BatteryPosition> BatteryPositions { get; set; }

    public virtual DbSet<CompletionOfMaintenance> CompletionOfMaintenances { get; set; }

    public virtual DbSet<MaintenanceItem> MaintenanceItems { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Performance> Performances { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffInSwitchStation> StaffInSwitchStations { get; set; }

    public virtual DbSet<StaffInformation> StaffInformations { get; set; }

    public virtual DbSet<SwitchRecord> SwitchRecords { get; set; }

    public virtual DbSet<SwitchRequest> SwitchRequests { get; set; }

    public virtual DbSet<SwitchStation> SwitchStations { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleParameter> VehicleParameters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=8.130.71.216)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCLCDB)));User ID=C##CAR;password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("C##CAR")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<AcceptanceOfSwitchRequest>(entity =>
        {
            entity.HasKey(e => e.SwitchRequestId).HasName("SYS_C007762");

            entity.ToTable("ACCEPTANCE_OF_SWITCH_REQUESTS");

            entity.Property(e => e.SwitchRequestId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SWITCH_REQUEST_ID");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMPLOYEE_ID");

            entity.HasOne(d => d.Employee).WithMany(p => p.AcceptanceOfSwitchRequests)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ACCEPTANCE_OF_SWITCH_REQUESTS_EMPLOYEE");

            entity.HasOne(d => d.SwitchRequest).WithOne(p => p.AcceptanceOfSwitchRequest)
                .HasForeignKey<AcceptanceOfSwitchRequest>(d => d.SwitchRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ACCEPTANCE_OF_SWITCH_REQUESTS_SWITCH_REQUEST");
        });

        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.AnnouncementId).HasName("SYS_C007701");

            entity.ToTable("ANNOUNCEMENT");

            entity.Property(e => e.AnnouncementId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ANNOUNCEMENT_ID");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CONTENT_");
            entity.Property(e => e.PublishTime)
                .HasPrecision(6)
                .HasColumnName("PUBLISH_TIME");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TITLE");
        });

        modelBuilder.Entity<Battery>(entity =>
        {
            entity.HasKey(e => e.BatteryId).HasName("SYS_C007698");

            entity.ToTable("BATTERY");

            entity.Property(e => e.BatteryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BATTERY_ID");
            entity.Property(e => e.AvailableStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0'")
                .HasColumnName("AVAILABLE_STATUS");
            entity.Property(e => e.BatteryLife)
                .HasColumnType("FLOAT")
                .HasColumnName("BATTERY_LIFE");
            entity.Property(e => e.BatteryModel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BATTERY_MODEL");
            entity.Property(e => e.CurrentCapacity)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CURRENT_CAPACITY");
            entity.Property(e => e.ManufacturingDate)
                .HasPrecision(6)
                .HasColumnName("MANUFACTURING_DATE");
            entity.Property(e => e.TotalCapacity)
                .HasDefaultValueSql("100")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TOTAL_CAPACITY");
        });

        modelBuilder.Entity<BatteryPosition>(entity =>
        {
            entity.HasKey(e => e.BatteryId).HasName("SYS_C007742");

            entity.ToTable("BATTERY_POSITION");

            entity.Property(e => e.BatteryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BATTERY_ID");
            entity.Property(e => e.PositionStatus)
                .HasDefaultValueSql("0")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("POSITION_STATUS");
            entity.Property(e => e.SwitchStationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SWITCH_STATION_ID");
            entity.Property(e => e.VehicleId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VEHICLE_ID");

            entity.HasOne(d => d.Battery).WithOne(p => p.BatteryPosition)
                .HasForeignKey<BatteryPosition>(d => d.BatteryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BATTERY_POSITION_BATTERY");

            entity.HasOne(d => d.SwitchStation).WithMany(p => p.BatteryPositions)
                .HasForeignKey(d => d.SwitchStationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BATTERY_POSITION_SWITCH_STATION");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.BatteryPositions)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BATTERY_POSITION_VEHICLE");
        });

        modelBuilder.Entity<CompletionOfMaintenance>(entity =>
        {
            entity.HasKey(e => e.MaintenanceId).HasName("SYS_C007759");

            entity.ToTable("COMPLETION_OF_MAINTENANCE");

            entity.Property(e => e.MaintenanceId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MAINTENANCE_ID");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMPLOYEE_ID");

            entity.HasOne(d => d.Employee).WithMany(p => p.CompletionOfMaintenances)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COMPLETION_OF_MAINTENANCE_EMPLOYEE");
        });

        modelBuilder.Entity<MaintenanceItem>(entity =>
        {
            entity.HasKey(e => e.MaintenanceItemId).HasName("SYS_C007737");

            entity.ToTable("MAINTENANCE_ITEMS");

            entity.HasIndex(e => e.MaintenanceLocation, "SYS_C007738").IsUnique();

            entity.Property(e => e.MaintenanceItemId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MAINTENANCE_ITEM_ID");
            entity.Property(e => e.Evaluation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EVALUATION_");
            entity.Property(e => e.MaintenanceLocation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MAINTENANCE_LOCATION");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0'")
                .IsFixedLength()
                .HasColumnName("ORDER_STATUS");
            entity.Property(e => e.OrderSubmissionTime)
                .HasPrecision(6)
                .HasColumnName("ORDER_SUBMISSION_TIME");
            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("REMARKS");
            entity.Property(e => e.ServiceTime)
                .HasPrecision(6)
                .HasColumnName("SERVICE_TIME");
            entity.Property(e => e.VehicleId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VEHICLE_ID");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.MaintenanceItems)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MAINTENANCE_ITEMS_VEHICLE");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("SYS_C007729");

            entity.ToTable("OWNERS");

            entity.Property(e => e.OwnerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OWNER_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Avatar)
                .HasColumnType("BLOB")
                .HasColumnName("AVATAR");
            entity.Property(e => e.Birthday)
                .HasPrecision(6)
                .HasColumnName("BIRTHDAY");
            entity.Property(e => e.CreationTime)
                .HasPrecision(6)
                .HasColumnName("CREATION_TIME");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GENDER");
            entity.Property(e => e.OwnerNickname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OWNER_NICKNAME");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD_");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("'+86'")
                .HasColumnName("PHONE_NUMBER");
        });

        modelBuilder.Entity<Performance>(entity =>
        {
            entity.HasKey(e => e.PerformanceId).HasName("SYS_C007712");

            entity.ToTable("PERFORMANCES");

            entity.Property(e => e.PerformanceId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PERFORMANCE_ID");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.PositiveRating)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("POSITIVE_RATING");
            entity.Property(e => e.ServiceCount)
                .HasDefaultValueSql("0")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("SERVICE_COUNT");
            entity.Property(e => e.TotalPerformance)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TOTAL_PERFORMANCE");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("SYS_C007752");

            entity.ToTable("STAFF");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.Avatar)
                .HasColumnType("BLOB")
                .HasColumnName("AVATAR");
            entity.Property(e => e.CreationTime)
                .HasPrecision(6)
                .HasColumnName("CREATION_TIME");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GENDER");
            entity.Property(e => e.IdCardNum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_CARD_NUM");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME_");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD_");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("'+86'")
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("'-'")
                .HasColumnName("POSITION_");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.IdCardNumNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.IdCardNum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STAFF_ID_CARD_NUMBER");
        });

        modelBuilder.Entity<StaffInSwitchStation>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("SYS_C007755");

            entity.ToTable("STAFF_IN_SWITCH_STATION");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.SwitchStationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SWITCH_STATION_ID");

            entity.HasOne(d => d.Employee).WithOne(p => p.StaffInSwitchStation)
                .HasForeignKey<StaffInSwitchStation>(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STAFF_IN_SWITCH_STATION_EMPLOYEE");

            entity.HasOne(d => d.SwitchStation).WithMany(p => p.StaffInSwitchStations)
                .HasForeignKey(d => d.SwitchStationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STAFF_IN_SWITCH_STATION_SWITCH_STATION");
        });

        modelBuilder.Entity<StaffInformation>(entity =>
        {
            entity.HasKey(e => e.IdentityNumber).HasName("SYS_C007723");

            entity.ToTable("STAFF_INFORMATION");

            entity.Property(e => e.IdentityNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IDENTITY_NUMBER");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GENDER");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME_");
        });

        modelBuilder.Entity<SwitchRecord>(entity =>
        {
            entity.HasKey(e => e.SwitchServiceId).HasName("SYS_C007709");

            entity.ToTable("SWITCH_RECORDS");

            entity.Property(e => e.SwitchServiceId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SWITCH_SERVICE_ID");
            entity.Property(e => e.BatterySource)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BATTERY_SOURCE");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.Evaluation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EVALUATION_");
            entity.Property(e => e.SwappedBatteryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SWAPPED_BATTERY_ID");
            entity.Property(e => e.SwappedOutBatteryDestination)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SWAPPED_OUT_BATTERY_DESTINATION");
            entity.Property(e => e.SwappedOutBatteryId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SWAPPED_OUT_BATTERY_ID");
            entity.Property(e => e.SwitchTime)
                .HasPrecision(6)
                .HasColumnName("SWITCH_TIME");
            entity.Property(e => e.VehicleId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VEHICLE_ID");
        });

        modelBuilder.Entity<SwitchRequest>(entity =>
        {
            entity.HasKey(e => e.SwitchRequestId).HasName("SYS_C007689");

            entity.ToTable("SWITCH_REQUESTS");

            entity.Property(e => e.SwitchRequestId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SWITCH_REQUEST_ID");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("REMARKS");
            entity.Property(e => e.RequestTime)
                .HasPrecision(6)
                .HasColumnName("REQUEST_TIME");
            entity.Property(e => e.VehicleId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VEHICLE_ID");
        });

        modelBuilder.Entity<SwitchStation>(entity =>
        {
            entity.HasKey(e => e.SwitchStationId).HasName("SYS_C007718");

            entity.ToTable("SWITCH_STATIONS");

            entity.HasIndex(e => e.Longitude, "SYS_C007719").IsUnique();

            entity.HasIndex(e => e.Latitude, "SYS_C007720").IsUnique();

            entity.Property(e => e.SwitchStationId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SWITCH_STATION_ID");
            entity.Property(e => e.AvailableBatteryCount)
                .HasDefaultValueSql("0\n")
                .HasColumnType("NUMBER(38)")
                .HasColumnName("AVAILABLE_BATTERY_COUNT");
            entity.Property(e => e.AvailableStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("AVAILABLE_STATUS");
            entity.Property(e => e.BatteryCapacity)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("BATTERY_CAPACITY");
            entity.Property(e => e.FaultStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FAULT_STATUS");
            entity.Property(e => e.Latitude)
                .HasColumnType("NUMBER")
                .HasColumnName("LATITUDE");
            entity.Property(e => e.Longitude)
                .HasColumnType("NUMBER")
                .HasColumnName("LONGITUDE");
            entity.Property(e => e.StationName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STATION_NAME");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("SYS_C007733");

            entity.ToTable("VEHICLES");

            entity.Property(e => e.VehicleId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VEHICLE_ID");
            entity.Property(e => e.OwnerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OWNER_ID");
            entity.Property(e => e.PurchaseDate)
                .HasPrecision(6)
                .HasColumnName("PURCHASE_DATE");
            entity.Property(e => e.VehicleModel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VEHICLE_MODEL");

            entity.HasOne(d => d.Owner).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VEHICLES_OWNER");
        });

        modelBuilder.Entity<VehicleParameter>(entity =>
        {
            entity.HasKey(e => e.VehicleModel).HasName("SYS_C007693");

            entity.ToTable("VEHICLE_PARAMETERS");

            entity.Property(e => e.VehicleModel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VEHICLE_MODEL");
            entity.Property(e => e.GearType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GEAR_TYPE");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MANUFACTURER");
            entity.Property(e => e.MaxSpeed)
                .HasColumnType("NUMBER")
                .HasColumnName("MAX_SPEED");
            entity.Property(e => e.WarrantyPeriod)
                .HasPrecision(6)
                .HasColumnName("WARRANTY_PERIOD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
