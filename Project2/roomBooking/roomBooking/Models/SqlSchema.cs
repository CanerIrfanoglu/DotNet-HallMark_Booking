namespace roomBooking
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SqlSchema : DbContext
    {
        public SqlSchema()
            : base("name=SqlSchema")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<booking> bookings { get; set; }
        public virtual DbSet<room> rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.bookings)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.userID);

            modelBuilder.Entity<booking>()
                .Property(e => e.eventName)
                .IsUnicode(false);

            modelBuilder.Entity<room>()
                .Property(e => e.roomName)
                .IsUnicode(false);

            modelBuilder.Entity<room>()
                .Property(e => e.roomLocation)
                .IsUnicode(false);
        }
    }
}
