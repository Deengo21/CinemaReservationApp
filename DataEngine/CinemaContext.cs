using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace DataEngine
{
    public class CinemaContext : DbContext
    {
        public DbSet<DataSchema.Movie> Movies { get; set; }
        public DbSet<DataSchema.Screening> Screenings { get; set; }
        public DbSet<DataSchema.Reservation> Reservations { get; set; }
        public DbSet<DataSchema.Customer> Customers { get; set; }
        public DbSet<DataSchema.Room> Rooms { get; set; }
        public DbSet<DataSchema.Payment> Payments { get; set; }

        private readonly IConfiguration _configuration;

        public CinemaContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfiguracja tabeli Movies
            modelBuilder.Entity<DataSchema.Movie>()
                .HasKey(m => m.MovieId);

            modelBuilder.Entity<DataSchema.Movie>()
                .Property(m => m.Title)
                .HasColumnName("title")
                .HasMaxLength(50);

            modelBuilder.Entity<DataSchema.Movie>()
                .Property(m => m.Director)
                .HasColumnName("director")
                .HasMaxLength(40);

            modelBuilder.Entity<DataSchema.Movie>()
                .Property(m => m.Length)
                .HasColumnName("length");

            modelBuilder.Entity<DataSchema.Movie>()
                .Property(m => m.FilmGenre)
                .HasColumnName("film_genre")
                .HasMaxLength(20);

            // Konfiguracja tabeli Screening
            modelBuilder.Entity<DataSchema.Screening>()
                .HasKey(s => s.ScreeningId);

            modelBuilder.Entity<DataSchema.Screening>()
                .Property(s => s.Date)
                .HasColumnName("date");

            modelBuilder.Entity<DataSchema.Screening>()
                .Property(s => s.Time)
                .HasColumnName("time");

            // Konfiguracja tabeli Reservations
            modelBuilder.Entity<DataSchema.Reservation>()
                .HasKey(r => r.ReservationId);

            modelBuilder.Entity<DataSchema.Reservation>()
                .HasOne(r => r.Payment)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r => r.PaymentId);

            modelBuilder.Entity<DataSchema.Reservation>()
                .HasOne(r => r.Screening)
                .WithMany(s => s.Reservations)
                .HasForeignKey(r => r.ScreeningId);

            modelBuilder.Entity<DataSchema.Reservation>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Reservations)
                .HasForeignKey(r => r.MovieId);

            modelBuilder.Entity<DataSchema.Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<DataSchema.Reservation>()
                .HasOne(r => r.Room)
                .WithMany(ro => ro.Reservations)
                .HasForeignKey(r => r.RoomId);

            // Konfiguracja tabeli Users
            modelBuilder.Entity<DataSchema.Customer>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<DataSchema.Customer>()
                .Property(u => u.Privilege)
                .HasColumnName("privilege");

            modelBuilder.Entity<DataSchema.Customer>()
                .Property(u => u.Username)
                .HasColumnName("username")
                .HasMaxLength(25);

            modelBuilder.Entity<DataSchema.Customer>()
                .Property(u => u.Password)
                .HasColumnName("password");

            // Konfiguracja tabeli Rooms
            modelBuilder.Entity<DataSchema.Room>()
                .HasKey(ro => ro.RoomId);

            modelBuilder.Entity<DataSchema.Room>()
                .Property(ro => ro.Row)
                .HasColumnName("row");

            modelBuilder.Entity<DataSchema.Room>()
                .Property(ro => ro.Seat)
                .HasColumnName("seat");

            // Konfiguracja tabeli Payments
            modelBuilder.Entity<DataSchema.Payment>()
                .HasKey(p => p.PaymentId);

            modelBuilder.Entity<DataSchema.Payment>()
                .Property(p => p.Cost)
                .HasColumnName("cost");

            modelBuilder.Entity<DataSchema.Payment>()
                .Property(p => p.PaymentMethod)
                .HasColumnName("payment_method")
                .HasMaxLength(20);
        }
    }
}
