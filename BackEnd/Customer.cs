using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataEngine;
using static DataEngine.DataSchema;
using System.Linq;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsVerified { get; set; }

    // Inicjalizacja kontekstu bazy danych
    private readonly CinemaContext _dbContext;

    public Customer(CinemaContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Register(string name, string email, string password)
    {
        // Sprawdź, czy istnieje już konto z podanym adresem e-mail
        if (await _dbContext.Customers.AnyAsync(c => c.Email == email))
        {
            throw new Exception("Konto o podanym adresie e-mail już istnieje.");
        }

        // Generuj unikalny token weryfikacyjny
        var verificationToken = Guid.NewGuid().ToString();

        // Zabezpiecz hasło przed zapisaniem do bazy danych
        string passwordHash = HashPassword(password);

        // Zapisz dane do bazy danych
        var newCustomer = new Customer(_dbContext);
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            IsVerified = false;
        };

        //_dbContext.Customers.Add(newCustomer);
        await _dbContext.SaveChangesAsync();

        // Wyślij e-mail weryfikacyjny
        await SendVerificationEmail(email, verificationToken);
    }

    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }

    private async Task SendVerificationEmail(string email, string verificationToken)
    {
        var smtpClient = new SmtpClient("your-smtp-server.com")
        {
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("your-email@example.com", "your-email-password"),
            Port = 587,
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("your-email@example.com"),
            Subject = "Potwierdzenie rejestracji",
            Body = $"Aby potwierdzić rejestrację, kliknij poniższy link:\n\n" +
                   $"https://your-app-url.com/verify?email={email}&token={verificationToken}",
            IsBodyHtml = false
        };

        mailMessage.To.Add(email);

        await smtpClient.SendMailAsync(mailMessage);
    }

    public async Task Login(string email, string password)
    {
        //Znajdź użytkownika o podanym adresie e-mail
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Email == email);

       // Sprawdź, czy użytkownik istnieje i czy hasło jest poprawne
        if (customer == null || !VerifyPassword(password, customer.PasswordHash))
        {
            throw new Exception("Nieprawidłowy adres e-mail lub hasło.");
        }

        //Sprawdź, czy konto zostało zweryfikowane
        if (!customer.IsVerified)
        {
            throw new Exception("Konto nie zostało jeszcze zweryfikowane. Sprawdź e-mail w celu potwierdzenia rejestracji.");
        }


    }
   

    public async Task BookTicket(int movieId, DateTime dateTime)
    {
        // Sprawdź, czy film o podanym identyfikatorze istnieje i jest dostępny
        var selectedMovie = await _dbContext.Movies
            .FirstOrDefaultAsync(m => m.MovieId == movieId && m.IsAvailable);

        if (selectedMovie == null)
        {
            throw new Exception("Film o podanym identyfikatorze nie istnieje lub nie jest dostępny.");
        }
        

      
        var reservation = new Reservation(_dbContext)
        {
            MovieId = selectedMovie.MovieId,
            CustomerId = this.Id, 
            ReservationDateTime = dateTime
            
        };

        //_dbContext.Reservations.Add(reservation);
        await _dbContext.SaveChangesAsync();
    }

    public CinemaContext Get_dbContext()
    {
        return _dbContext;
    }

    public async Task<List<Movie>> BrowseMovies(List<Movie> availableMovies, CinemaContext _dbContext)
    {
        //Pobierz listę dostępnych filmów z bazy danych
       availableMovies = _dbContext.Movies
          .Where(m => m.IsAvailable)
          .ToList();

        return availableMovies;
    }

    public async Task<List<DataSchema.Reservation>> ViewHistory()
    {
        // Pobierz historię rezerwacji bieżącego użytkownika
        
       var reservations = await _dbContext.Reservations
            .Where(r => r.UserId == this.Id)
            .Include(r => r.Movie)
            .ToListAsync();
        return reservations;
  
    }


    public bool VerifyPassword(string enteredPassword, string storedHash)
    {
        string enteredPasswordHash = HashPassword(enteredPassword);
        return enteredPasswordHash == storedHash;
    }
}