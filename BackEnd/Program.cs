using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BackEnd;
using DataEngine;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CinemaReservationApp
{
    class Program
    {
        public static CinemaContext Context { get; set; }

        static async Task Main(string[] args)
        {
           
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=C:\\USERS\\KAROL\\DESKTOP\\CINEMARESERVATIONAPP\\CINEMARESERVATIONAPP\\DATAENGINE\\BD123.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            //Context = new CinemaContext(builder.Options);

            // Menu główne
            using (var context = new CinemaContext(builder.Options))
            {
                while (true)
                {
                    Console.WriteLine("Witaj w aplikacji rezerwacji biletów w kinie!");
                    Console.WriteLine("Wybierz opcję:");
                    Console.WriteLine("1. Zaloguj się jako administrator");
                    Console.WriteLine("2. Zaloguj się jako klient");
                    Console.WriteLine("3. Wyjdź z aplikacji");

                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            await AdminLogin(context);
                            break;
                        case "2":
                            await CustomerLogin(context);
                            break;
                        case "3":
                            Console.WriteLine("Do widzenia!");
                            return;
                        default:
                            Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                            break;
                    }
                }
            }
        }

        static async Task AdminLogin(CinemaContext dbContext)
        {
            Console.WriteLine("Logowanie jako administrator");
            Console.Write("Podaj adres e-mail: ");
            var email = Console.ReadLine();
            Console.Write("Podaj hasło: ");
            var password = Console.ReadLine();

            var admin = new Admin(dbContext);
            try
            {
                await admin.Login(email, password);
                Console.WriteLine("Zalogowano pomyślnie jako administrator.");
                await AdminOperations(admin);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd logowania jako administrator: {ex.Message}");
            }
        }

        static async Task AdminOperations(Admin admin)
        {
            while (true)
            {
                Console.WriteLine("Wybierz operację:");
                Console.WriteLine("1. Zarządzanie kontami użytkowników");
                Console.WriteLine("2. Zarządzanie filmami");
                Console.WriteLine("3. Zarządzanie seansami");
                Console.WriteLine("4. Generowanie raportu");
                Console.WriteLine("5. Wyloguj");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await admin.ManageAccounts();
                        break;
                    case "2":
                        await admin.ManageMovies();
                        break;
                    case "3":
                        await admin.ManageScreenings();
                        break;
                    case "4":
                        await admin.GenerateReport();
                        break;
                    case "5":
                        Console.WriteLine("Wylogowano.");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }

        static async Task CustomerLogin(CinemaContext dbContext)
        {
            Console.WriteLine("1. Zaloguj się");
            Console.WriteLine("2. Zarejestruj się");
            Console.Write("Wybierz opcję: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await LoginCustomer(dbContext);
                    break;
                case "2":
                    await RegisterCustomer(dbContext);
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór.");
                    break;
            }
        }

        static async Task LoginCustomer(CinemaContext dbContext)
        {
            Console.WriteLine("Logowanie jako klient");
            Console.Write("Podaj adres e-mail: ");
            var email = Console.ReadLine();
            Console.Write("Podaj hasło: ");
            var password = Console.ReadLine();

            var customer = new Customer(dbContext);
            try
            {
                await customer.Login(email, password);
                Console.WriteLine("Zalogowano pomyślnie jako klient.");
                await CustomerOperations(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd logowania jako klient: {ex.Message}");
            }
        }

        static async Task RegisterCustomer(CinemaContext dbContext)
        {
            Console.WriteLine("Rejestracja nowego użytkownika");
            Console.Write("Podaj imię: ");
            var name = Console.ReadLine();
            Console.Write("Podaj adres e-mail: ");
            var email = Console.ReadLine();
            Console.Write("Podaj hasło: ");
            var password = Console.ReadLine();

            var customer = new Customer(dbContext);
            try
            {
                await customer.Register(name, email, password);
                Console.WriteLine("Konto zostało pomyślnie zarejestrowane.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas rejestracji: {ex.Message}");
            }
        }

        static async Task CustomerOperations(Customer customer)
        {
            while (true)
            {
                Console.WriteLine("Wybierz operację:");
                Console.WriteLine("1. Przeglądaj filmy");
                Console.WriteLine("2. Rezerwacja biletów");
                Console.WriteLine("3. Wyświetl historię rezerwacji");
                Console.WriteLine("4. Wyloguj");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await BrowseMovies(customer);
                        break;
                    case "2":
                        await BookTicket(customer);
                        break;
                    case "3":
                        await ViewReservationHistory(customer);
                        break;
                    case "4":
                        Console.WriteLine("Wylogowano.");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }

        static async Task BrowseMovies(Customer customer)
        {
            var list = Context.Movies.ToList();
            var availableMovies = await customer.BrowseMovies(list, Context);
            if (availableMovies.Any())
            {
                Console.WriteLine("Dostępne filmy:");
                foreach (var movie in availableMovies)
                {
                    Console.WriteLine($"{movie.MovieId}. {movie.Title}");
                }
            }
            else
            {
                Console.WriteLine("Brak dostępnych filmów.");
            }
        }

        static async Task BookTicket(Customer customer)
        {
            Console.Write("Podaj identyfikator filmu: ");
            var movieId = int.Parse(Console.ReadLine());
            Console.Write("Podaj datę i godzinę rezerwacji (np. 2022-12-31T18:00): ");
            var reservationDateTime = DateTime.Parse(Console.ReadLine());

            try
            {
                var x = new Reservation(Context);
                await x.BookTicket(customer.Id, movieId, reservationDateTime);
                Console.WriteLine("Bilet zarezerwowano pomyślnie.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas rezerwacji biletu: {ex.Message}");
            }
        }

        static async Task ViewReservationHistory(Customer customer)
        {
            var reservations = await customer.ViewHistory();
            if (reservations.Any())
            {
                Console.WriteLine("Historia rezerwacji:");
                foreach (var reservation in reservations)
                {
                    Console.WriteLine($"Film: {reservation.Movie.Title}");
                }
            }
            else
            {
                Console.WriteLine("Brak historii rezerwacji.");
            }
        }
    }
}