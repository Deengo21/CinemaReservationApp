using DataEngine;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BackEnd
{
    public class Employee
    {
        private readonly CinemaContext _dbContext;
        public Employee(CinemaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Login(string email, string password)
        {

            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Email == email);

            if (employee == null || !VerifyPassword(password, employee.PasswordHash))
            {
                throw new Exception("Nieprawidłowy adres e-mail lub hasło.");
            }
        }

        public async Task ManageReservations()
        {
            // Pobierz listę wszystkich rezerwacji do zarządzania
            var reservations = await _dbContext.Reservations
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .ToListAsync();

            foreach (var reservation in reservations)
            {
                Console.WriteLine($"Rezerwacja ID: {reservation.ReservationId}");
                Console.WriteLine($"Klient: {reservation.UserId}");
                Console.WriteLine($"Film: {reservation.Movie.Title}");
                Console.WriteLine($"Data rezerwacji: {reservation.ReservationDateTime}");
                Console.WriteLine($"Status: {reservation.IsAvailable}");
                Console.WriteLine("------------------------------");
            }


            Console.Write("Podaj ID rezerwacji do edycji statusu: ");
            if (int.TryParse(Console.ReadLine(), out int reservationId))
            {
                var selectedReservation = reservations.FirstOrDefault(r => r.ReservationId == reservationId);
                if (selectedReservation != null)
                {
                    Console.Write("Nowy status (np. Potwierdzona, Anulowana): ");
                    bool newStatus = false;
                    selectedReservation.IsAvailable = newStatus;

                    // Zapisz zmiany do bazy danych
                    await _dbContext.SaveChangesAsync();
                    Console.WriteLine("Status rezerwacji został zaktualizowany.");
                }
                else
                {
                    Console.WriteLine("Rezerwacja o podanym ID nie istnieje.");
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowy format ID rezerwacji.");
            }
        }


        //public async Task<List<Screening>> BrowseMovieScreenings(List<Screening> upcomingScreenings)
        //{
        //    // Pobierz listę nadchodzących seansów filmowych
        //    var upcomingScreenings = await _dbContext.Screenings
        //        .Where(ms => ms.Date > DateTime.Now)
        //        .ToListAsync();

        //    return upcomingScreenings;
        //}

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {

            string enteredPasswordHash = HashPassword(enteredPassword);
            return enteredPasswordHash == storedHash;
        }

        private string HashPassword(string password)
        {

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
