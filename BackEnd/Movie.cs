using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Server
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsAvailable { get; set; }

        public virtual List<Screening> Screenings { get; set; }

        private readonly CinemaContext _dbContext;

        public Movie(CinemaContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Metoda pobierająca informacje o filmie z bazy danych
        public async Task LoadMovieData(int movieId)
        {
            var movie = await _dbContext.Movies.FindAsync(movieId);

            if (movie != null)
            {
                Id = movie.MovieId;
                Title = movie.Title;
                IsAvailable = movie.IsAvailable;
            }
        }

        // Metoda aktualizująca dostępność filmu na podstawie rezerwacji
        public async Task UpdateAvailability()
        {
            // Pobierz listę rezerwacji dla danego filmu
            var reservations = await _dbContext.Reservations
                .Where(r => r.Screening.MovieId == Id)
                .ToListAsync();

            // Zapisz zmiany do bazy danych
            await _dbContext.SaveChangesAsync();
        }
    }
}
