using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Server
{
    public class Screening
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public DateTime DateTime { get; set; }
        public int DurationMinutes { get; set; }
        public int RoomNumber { get; set; }

        public virtual Movie Movie { get; set; }

        private readonly CinemaContext _dbContext;

        public Screening(CinemaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ScreeningDetailsDTO> ScreeningDetails()
        {
            // Pobierz szczegóły seansu
            var screeningDetails = await _dbContext.Screenings
                .Include(s => s.Movie)
                .Where(s => s.ScreeningId == Id)
                .Select(s => new ScreeningDetailsDTO
                {
                    MovieTitle = s.Movie.Title,
                    DateTime = s.Date,
                    DurationMinutes = s.Duration,
                    RoomNumber = s.RoomNumber
                })
                .FirstOrDefaultAsync();

            return screeningDetails;
        }

        public async Task<ReservedSeatsDTO> UpdateReservedSeats()
        {
            // Pobierz informacje o zarezerwowanych miejscach dla danego seansu
            var reservedSeatsInfo = await _dbContext.Reservations
                .Where(r => r.ScreeningId == Id)
                .GroupBy(r => r.SeatNumber)
                .Select(g => new ReservedSeatsDTO
                {
                    SeatNumber = (int)g.Key,
                    ReservedCount = g.Count()
                })
                .ToListAsync();

            // Znajdź całkowitą liczbę miejsc w sali
            var totalSeats = await _dbContext.Rooms
                .Where(r => r.RoomNumber == RoomNumber)
                .Select(r => r.TotalSeats)
                .FirstOrDefaultAsync();

            // Oblicz liczbę wolnych miejsc
            var availableSeats = totalSeats - reservedSeatsInfo.Sum(r => r.ReservedCount);

            // Utwórz DTO z informacjami o zarezerwowanych i dostępnych miejscach
            var result = new ReservedSeatsDTO
            {
                ReservedSeatsInfo = reservedSeatsInfo,
                AvailableSeats = availableSeats
            };

            return result;
        }
    }

    public class ScreeningDetailsDTO
    {
        public string MovieTitle { get; set; }
        public DateTime DateTime { get; set; }
        public int DurationMinutes { get; set; }
        public int RoomNumber { get; set; }
    }

    public class ReservedSeatsDTO
    {
        public int SeatNumber { get; set; }
        public int ReservedCount { get; set; }
        public int AvailableSeats { get; set; }
        public List<ReservedSeatsDTO> ReservedSeatsInfo { get; set; }
    }
}

