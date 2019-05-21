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

        public virtual DbSet<Axle> Axle { get; set; }
        public virtual DbSet<DeviceType> DeviceType { get; set; }
        public virtual DbSet<HotBoxHotWheelMeasureWheelData> HotBoxHotWheelMeasureWheelData { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<TrainOperator> TrainOperator { get; set; }
        public virtual DbSet<Traindirection> Traindirection { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<Wheel> Wheel { get; set; }
        public virtual DbSet<WheelDamageMeasureDataVehicle> WheelDamageMeasureDataVehicle { get; set; }
        public virtual DbSet<WheelDamageMeasureDataWheel> WheelDamageMeasureDataWheel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=DetectorDamageReport;ConnectRetryCount=0;User Id=DetectorDamageReport;Password=JanBanan76!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Axle>(entity =>
            {
                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Axle)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
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
                entity.HasOne(d => d.Wheel)
                    .WithMany(p => p.HotBoxHotWheelMeasureWheelData)
                    .HasForeignKey(d => d.WheelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HotBoxHotWheelMeasureWheelData_Wheel");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.MessageId).ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LocationId)
                    .IsRequired()
                    .HasColumnName("LocationID")
                    .HasMaxLength(255);

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SendTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Track)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.TrainNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.TrainDirection)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.TrainDirectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Traindirection");

                entity.HasOne(d => d.TrainOperator)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.TrainOperatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_TrainOperator");
            });

            modelBuilder.Entity<TrainOperator>(entity =>
            {
                entity.Property(e => e.TrainOperatorId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
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

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Message");
            });

            modelBuilder.Entity<Wheel>(entity =>
            {
                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.Wheel)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wheel_DeviceType");
            });

            modelBuilder.Entity<WheelDamageMeasureDataVehicle>(entity =>
            {
                entity.Property(e => e.WheelDamageMeasureDataVehicleId).ValueGeneratedNever();

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.WheelDamageMeasureDataVehicle)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WheelDamageMeasureDataVehicle_Vehicle");
            });

            modelBuilder.Entity<WheelDamageMeasureDataWheel>(entity =>
            {
                entity.HasOne(d => d.Wheel)
                    .WithMany(p => p.WheelDamageMeasureDataWheel)
                    .HasForeignKey(d => d.WheelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WheelDamageMeasureDataWheel_Wheel");
            });
        }
    }
}
