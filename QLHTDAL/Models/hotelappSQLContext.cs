using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLHT.DAL.Models
{
    public partial class hotelappSQLContext : DbContext
    {
        public hotelappSQLContext()
        {
        }

        public hotelappSQLContext(DbContextOptions<hotelappSQLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerRegistration> CustomerRegistrations { get; set; }
        public virtual DbSet<CustomerReservation> CustomerReservations { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<ReceiptSurcharge> ReceiptSurcharges { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<Surcharge> Surcharges { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=hotelappSQL;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("customer_customer_PRIMARY")
                    .IsClustered(false);

                entity.ToTable("customer");

                entity.HasIndex(e => e.TypeId, "customer_type_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.IdCard)
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("idCard");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasColumnType("decimal(38, 0)")
                    .HasColumnName("phone");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("customer_customer_ibfk_1");
            });

            modelBuilder.Entity<CustomerRegistration>(entity =>
            {
                entity.HasKey(e => new { e.RegistrationId, e.CustomerId })
                    .HasName("customer_registration_customer_registration_PRIMARY")
                    .IsClustered(false);

                entity.ToTable("customer_registration");

                entity.HasIndex(e => e.CustomerId, "customer_registration_customer_id");

                entity.Property(e => e.RegistrationId).HasColumnName("registration_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerRegistrations)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_registration_customer_registration_ibfk_2");

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.CustomerRegistrations)
                    .HasForeignKey(d => d.RegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_registration_customer_registration_ibfk_1");
            });

            modelBuilder.Entity<CustomerReservation>(entity =>
            {
                entity.HasKey(e => new { e.ReservationId, e.CustomerId })
                    .HasName("customer_reservation_customer_reservation_PRIMARY")
                    .IsClustered(false);

                entity.ToTable("customer_reservation");

                entity.HasIndex(e => e.CustomerId, "customer_reservation_customer_id");

                entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerReservations)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_reservation_customer_reservation_ibfk_2");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.CustomerReservations)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_reservation_customer_reservation_ibfk_1");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("customer_type_customer_type_PRIMARY")
                    .IsClustered(false);

                entity.ToTable("customer_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("receipt_receipt_PRIMARY")
                    .IsClustered(false);

                entity.ToTable("receipt");

                entity.HasIndex(e => e.CustomerId, "receipt_customer_id");

                entity.HasIndex(e => e.RegistrationId, "receipt_registration_id");

                entity.HasIndex(e => e.ReservationId, "receipt_reservation_id");

                entity.HasIndex(e => e.RoomId, "receipt_room_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CheckInTime)
                    .HasColumnType("datetime")
                    .HasColumnName("checkInTime");

                entity.Property(e => e.CheckOutTime)
                    .HasColumnType("datetime")
                    .HasColumnName("checkOutTime");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.RegistrationId).HasColumnName("registration_id");

                entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("receipt_receipt_ibfk_1");

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.RegistrationId)
                    .HasConstraintName("receipt_receipt_ibfk_4");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.ReservationId)
                    .HasConstraintName("receipt_receipt_ibfk_3");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("receipt_receipt_ibfk_2");
            });

            modelBuilder.Entity<ReceiptSurcharge>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ReceiptId, e.SurchargeId })
                    .HasName("receipt_surcharge_receipt_surcharge_PRIMARY")
                    .IsClustered(false);

                entity.ToTable("receipt_surcharge");

                entity.HasIndex(e => e.ReceiptId, "receipt_surcharge_receipt_id");

                entity.HasIndex(e => e.SurchargeId, "receipt_surcharge_surcharge_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");

                entity.Property(e => e.SurchargeId).HasColumnName("surcharge_id");

                entity.HasOne(d => d.Receipt)
                    .WithMany(p => p.ReceiptSurcharges)
                    .HasForeignKey(d => d.ReceiptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("receipt_surcharge_receipt_surcharge_ibfk_1");

                entity.HasOne(d => d.Surcharge)
                    .WithMany(p => p.ReceiptSurcharges)
                    .HasForeignKey(d => d.SurchargeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("receipt_surcharge_receipt_surcharge_ibfk_2");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("registration_registration_PRIMARY")
                    .IsClustered(false);

                entity.ToTable("registration");

                entity.HasIndex(e => e.RoomId, "registration_room_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CheckInTime)
                    .HasColumnType("datetime")
                    .HasColumnName("checkInTime");

                entity.Property(e => e.CheckOutTime)
                    .HasColumnType("datetime")
                    .HasColumnName("checkOutTime");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registration_registration_ibfk_1");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("reservation_reservation_PRIMARY")
                    .IsClustered(false);

                entity.ToTable("reservation");

                entity.HasIndex(e => e.RoomId, "reservation_room_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CheckInTime)
                    .HasColumnType("datetime")
                    .HasColumnName("checkInTime");

                entity.Property(e => e.CheckOutTime)
                    .HasColumnType("datetime")
                    .HasColumnName("checkOutTime");

                entity.Property(e => e.Phone)
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.ReserveBy)
                    .IsRequired()
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("reserveBy");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reservation_reservation_ibfk_1");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("room_room_PRIMARY")
                    .IsClustered(false);

                entity.ToTable("room");

                entity.HasIndex(e => e.CategoryId, "room_category_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("room_room_ibfk_1");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("room_type_room_type_PRIMARY")
                    .IsClustered(false);

                entity.ToTable("room_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Surcharge>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("surcharge_surcharge_PRIMARY")
                    .IsClustered(false);

                entity.ToTable("surcharge");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("description");

                entity.Property(e => e.Ratio).HasColumnName("ratio");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("user_user_PRIMARY")
                    .IsClustered(false);

                entity.ToTable("user");

                entity.HasIndex(e => e.Username, "user_username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Email)
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.JoinedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("joined_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(4000)
                    .HasColumnName("user_role");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
