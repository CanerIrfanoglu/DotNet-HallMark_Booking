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

        public virtual DbSet<booking> bookings { get; set; }
        public virtual DbSet<room> rooms { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<booking>()
                .Property(e => e.eventName)
                .IsUnicode(false);

            modelBuilder.Entity<room>()
                .Property(e => e.roomName)
                .IsUnicode(false);

            modelBuilder.Entity<room>()
                .Property(e => e.roomLocation)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.aNumber)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.upwd)
                .IsUnicode(false);
        }
    }
}
