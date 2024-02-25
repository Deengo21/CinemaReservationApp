using Microsoft.EntityFrameworkCore;
using System.Text;
using DataEngine;
using System.Threading.Tasks;

namespace BackEnd
{
    public class Admin 
    {
        private readonly CinemaContext _dbContext;

        public Admin(CinemaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Login(string email, string password)
        {
            var x = new Customer(_dbContext);
            var admin = await _dbContext.Customers.FirstOrDefaultAsync(a => a.Email == email);


        }

        // Zarządzanie kontami użytkowników
        public async Task ManageAccounts()
        {
            // Wyświetl listę wszystkich użytkowników do zarządzania
            var users = await _dbContext.Customers.ToListAsync();

            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.UserId}, Imię: {user.Username}, Email: {user.Email}");
                Console.WriteLine("------------------------------");
            }
        }

        // Zarządzanie filmami
        public async Task ManageMovies()
        {
            // Wyświetl listę wszystkich filmów do zarządzania
            var movies = await _dbContext.Movies.ToListAsync();


            foreach (var movie in movies)
            {
                Console.WriteLine($"ID: {movie.MovieId}, Tytuł: {movie.Title}, Dostępność: {movie.IsAvailable}");
                Console.WriteLine("------------------------------");
            }
        }

        // Zarządzanie seansami
        public async Task ManageScreenings()
        {
            // Wyświetl listę wszystkich seansów do zarządzania
            var screenings = await _dbContext.Screenings.ToListAsync();


            foreach (var screening in screenings)
            {
                Console.WriteLine($"ID: {screening.ScreeningId}, Film: {screening.Movie.Title}, Data i godzina: {screening.Date}");
                Console.WriteLine("------------------------------");
            }
        }

        // Raportowanie
        public async Task GenerateReport()
        {

            var purchasedSeatsReport = await GeneratePurchasedSeatsReport();
            

            // Wypisz raporty
            Console.WriteLine("Raport wyciągu zakupionych miejsc:");
            Console.WriteLine(purchasedSeatsReport);
            Console.WriteLine("------------------------------");

        }

        private async Task<string> GeneratePurchasedSeatsReport()
        {

            var reservedSeatsInfo = await _dbContext.Reservations
                .GroupBy(r => r.Seat)
                .Select(g => new
                {
                    SeatNumber = g.Key,
                    ReservedCount = g.Count()
                })
                .ToListAsync();

            var reportBuilder = new StringBuilder();
            reportBuilder.AppendLine("Raport wyciągu zakupionych miejsc:");
            foreach (var reservedSeat in reservedSeatsInfo)
            {
                reportBuilder.AppendLine($"Miejsce {reservedSeat.SeatNumber}: {reservedSeat.ReservedCount} zakupionych biletów");
            }

            return reportBuilder.ToString();
        }
    }
}
