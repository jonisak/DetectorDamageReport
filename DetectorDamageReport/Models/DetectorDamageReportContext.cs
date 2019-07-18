using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DetectorDamageReport.Models
{
    public partial class DetectorDamageReportContext : DbContext
    {
        public DetectorDamageReportContext()
        {
        }

        public DetectorDamageReportContext(DbContextOptions<DetectorDamageReportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alert> Alert { get; set; }
        public virtual DbSet<Axle> Axle { get; set; }
        public virtual DbSet<DeviceType> DeviceType { get; set; }
        public virtual DbSet<HotBoxHotWheelMeasureWheelData> HotBoxHotWheelMeasureWheelData { get; set; }
        public virtual DbSet<MeasurementValue> MeasurementValue { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Train> Train { get; set; }
        public virtual DbSet<TrainOperator> TrainOperator { get; set; }
        public virtual DbSet<TrainOperatorUser> TrainOperatorUser { get; set; }
        public virtual DbSet<Traindirection> Traindirection { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<Wheel> Wheel { get; set; }
        public virtual DbSet<WheelDamageMeasureDataAxle> WheelDamageMeasureDataAxle { get; set; }
        public virtual DbSet<WheelDamageMeasureDataVehicle> WheelDamageMeasureDataVehicle { get; set; }
        public virtual DbSet<WheelDamageMeasureDataWheel> WheelDamageMeasureDataWheel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=DetectorDamageReport;ConnectRetryCount=0;User Id=DetectorDamageReport;Password=JanBanan76!");
                optionsBuilder.UseLazyLoadingProxies(true);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Alert>(entity =>
            {
                entity.Property(e => e.AlarmCode)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.AlarmLevel)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DecriptionText)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.MeasurementType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Axle)
                    .WithMany(p => p.Alert)
                    .HasForeignKey(d => d.AxleId)
                    .HasConstraintName("FK_Alert_Axle");

                entity.HasOne(d => d.Train)
                    .WithMany(p => p.Alert)
                    .HasForeignKey(d => d.TrainId)
                    .HasConstraintName("FK_Alert_Train");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Alert)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK_Alert_Vehicle");

                entity.HasOne(d => d.Wheel)
                    .WithMany(p => p.Alert)
                    .HasForeignKey(d => d.WheelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Alert_Wheel");
            });

            modelBuilder.Entity<Axle>(entity =>
            {
                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Axle)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK_Axle_Vehicle");
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.Property(e => e.DeviceTypeId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<HotBoxHotWheelMeasureWheelData>(entity =>
            {
                entity.HasOne(d => d.MeasurementValue)
                    .WithMany(p => p.HotBoxHotWheelMeasureWheelData)
                    .HasForeignKey(d => d.MeasurementValueId)
                    .HasConstraintName("FK_HotBoxHotWheelMeasureWheelData_MeasurementValue");
            });

            modelBuilder.Entity<MeasurementValue>(entity =>
            {
                entity.Property(e => e.HardwareVersion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SoftwareVersion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Vendor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Axle)
                    .WithMany(p => p.MeasurementValue)
                    .HasForeignKey(d => d.AxleId)
                    .HasConstraintName("FK_MeasurementValue_Axle");

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.MeasurementValue)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeasurementValue_DeviceType");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.MeasurementValue)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK_MeasurementValue_Vehicle");

                entity.HasOne(d => d.Wheel)
                    .WithMany(p => p.MeasurementValue)
                    .HasForeignKey(d => d.WheelId)
                    .HasConstraintName("FK_MeasurementValue_Wheel");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.MessageId).ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ImportedTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.LocationId)
                    .IsRequired()
                    .HasColumnName("LocationID")
                    .HasMaxLength(255);

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SendTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.SoftwareVersion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Track)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Vendor)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.Property(e => e.TrainNumber).HasMaxLength(50);

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Train)
                    .HasForeignKey(d => d.MessageId)
                    .HasConstraintName("FK_Train_Message");

                entity.HasOne(d => d.TrainDirection)
                    .WithMany(p => p.Train)
                    .HasForeignKey(d => d.TrainDirectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Train_Traindirection");

                entity.HasOne(d => d.TrainOperator)
                    .WithMany(p => p.Train)
                    .HasForeignKey(d => d.TrainOperatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Train_TrainOperator");
            });

            modelBuilder.Entity<TrainOperator>(entity =>
            {
                entity.Property(e => e.TrainOperatorId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TrainOperatorUser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TrainOperatorId });

                entity.Property(e => e.UserId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.TrainOperator)
                    .WithMany(p => p.TrainOperatorUser)
                    .HasForeignKey(d => d.TrainOperatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrainOperatorUser_TrainOperator");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TrainOperatorUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrainOperatorUser_User");
            });

            modelBuilder.Entity<Traindirection>(entity =>
            {
                entity.Property(e => e.TrainDirectionId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.VehicleNumber).HasMaxLength(255);

                entity.HasOne(d => d.Train)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.TrainId)
                    .HasConstraintName("FK_Vehicle_Train");
            });

            modelBuilder.Entity<Wheel>(entity =>
            {
                entity.HasOne(d => d.Axle)
                    .WithMany(p => p.Wheel)
                    .HasForeignKey(d => d.AxleId)
                    .HasConstraintName("FK_Wheel_Axle");
            });

            modelBuilder.Entity<WheelDamageMeasureDataAxle>(entity =>
            {
                entity.Property(e => e.WheelDamageMeasureDataAxleId).ValueGeneratedNever();

                entity.HasOne(d => d.MeasurementValue)
                    .WithMany(p => p.WheelDamageMeasureDataAxle)
                    .HasForeignKey(d => d.MeasurementValueId)
                    .HasConstraintName("FK_WheelDamageMeasureDataAxle_MeasurementValue");
            });

            modelBuilder.Entity<WheelDamageMeasureDataVehicle>(entity =>
            {
                entity.HasOne(d => d.MeasurementValue)
                    .WithMany(p => p.WheelDamageMeasureDataVehicle)
                    .HasForeignKey(d => d.MeasurementValueId)
                    .HasConstraintName("FK_WheelDamageMeasureDataVehicle_MeasurementValue");
            });

            modelBuilder.Entity<WheelDamageMeasureDataWheel>(entity =>
            {
                entity.HasOne(d => d.MeasurementValue)
                    .WithMany(p => p.WheelDamageMeasureDataWheel)
                    .HasForeignKey(d => d.MeasurementValueId)
                    .HasConstraintName("FK_WheelDamageMeasureDataWheel_MeasurementValue");
            });
        }
    }
}
