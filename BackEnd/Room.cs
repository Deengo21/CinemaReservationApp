using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Server
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int TotalSeats { get; set; }

        public virtual List<Screening> Screenings { get; set; }

        private readonly CinemaContext _dbContext;

        public Room(CinemaContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Metoda pobierająca informacje o sali z bazy danych
        public async Task LoadRoomData(int roomId)
        {
            var room = await _dbContext.Rooms.FindAsync(roomId);

            if (room != null)
            {
                Id = room.RoomId;
                RoomNumber = room.RoomNumber;
                TotalSeats = room.TotalSeats;
                Screenings = room.Screenings;
            }
        }

        // Metoda aktualizująca dostępne miejsca na podstawie rezerwacji
        public async Task UpdateAvailableSeats()
        {
            // Pobierz listę rezerwacji dla danej sali
            var reservations = await _dbContext.Reservations
                .Where(r => r.Screening.RoomId == Id)
                .ToListAsync();

            // Oblicz dostępne miejsca
            int reservedSeatsCount = reservations.Sum(r => (int)r.SeatNumber);
            int availableSeats = TotalSeats - reservedSeatsCount;

            // Aktualizuj dostępne miejsca w obiekcie Room
            TotalSeats = availableSeats;

            // Zapisz zmiany do bazy danych
            await _dbContext.SaveChangesAsync();
        }
    }
}
