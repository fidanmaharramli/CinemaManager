using CinemaManager.Data;
using CinemaManager.Entities;
using CinemaManager.Services;
using AppDbContext context = new();
//context.Database.EnsureDeleted(); 
context.Database.EnsureCreated(); 

CinemaService service = new(context);
Console.Title = " Cinema Manager ";
bool isRunning = true;
ShowWelcome();
while (isRunning)
{
    ShowMenu();
    Console.Write("  Seciminizi daxil edin: ");
    string? choice = Console.ReadLine();
    Console.Clear();
    switch (choice)
    {
        case "1":
            AddMovie();
            break;

        case "2":
            ShowAllMovies();
            break;

        case "3":
            FindMovie();
            break;

        case "4":
            DeleteMovie();
            break;

        case "5":
            AddCustomer();
            break;

        case "6":
            ShowAllCustomers();
            break;

        case "7":
            FindCustomer();
            break;

        case "8":
            BuyTicket();
            break;

        case "9":
            ShowAllTickets();
            break;

        case "10":
            FindTicket();
            break;

        case "11":
            CancelTicket();
            break;

        case "12":
            ShowMovieTickets();
            break;

        case "0":
            isRunning = false;
            ShowExitMessage();
            break;

        default:
            ShowError("Yanlis secim etdiniz.");
            break;
    }
    if (isRunning)
    {
        Pause();
        Console.Clear();
    }
}
// ==================================================
// WELCOME
// ==================================================
void ShowWelcome()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine();
    Console.WriteLine("╔══════════════════════════════════════════════════╗");
    Console.WriteLine("║                                                  ║");
    Console.WriteLine("║               CINEMA MANAGER                     ║");
    Console.WriteLine("║                                                  ║");
    Console.WriteLine("║           Film ve bilet sistemi                  ║");
    Console.WriteLine("║                                                  ║");
    Console.WriteLine("╚══════════════════════════════════════════════════╝");
    Console.ResetColor();
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("        Cinema Manager-e xos gelmisiniz! 🎬");
    Console.ResetColor();
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("        Baslamaq ucun Enter basin...");
    Console.ResetColor();
    Console.ReadLine();
    Console.Clear();
}
// ==================================================
// MENU
// ==================================================   
void ShowMenu()
{
    Console.ForegroundColor = ConsoleColor.Magenta;

    Console.WriteLine();
    Console.WriteLine("╔══════════════════════════════════════════════════╗");
    Console.WriteLine("║               CINEMA MANAGER                     ║");
    Console.WriteLine("╠══════════════════════════════════════════════════╣");
    Console.WriteLine("║                                                  ║");
    Console.WriteLine("║     FILMLER                                      ║");
    Console.WriteLine("║                                                  ║");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("║   1.  Film elave et                              ║");
    Console.WriteLine("║   2.  Butun filmleri goster                      ║");
    Console.WriteLine("║   3.  Id ile film tap                            ║");
    Console.WriteLine("║   4.  Film sil                                   ║");
    Console.WriteLine("║                                                  ║");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("║     MUSTERILER                                   ║");
    Console.WriteLine("║                                                  ║");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("║   5.  Musteri elave et                           ║");
    Console.WriteLine("║   6.  Butun musterileri goster                   ║");
    Console.WriteLine("║   7.  Id ile musteri tap                         ║");
    Console.WriteLine("║                                                  ║");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("║     BILETLER                                     ║");
    Console.WriteLine("║                                                  ║");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("║   8.  Bilet al                                   ║");
    Console.WriteLine("║   9.  Butun biletleri goster                     ║");
    Console.WriteLine("║   10. Id ile bilet tap                           ║");
    Console.WriteLine("║   11. Bileti legv et                             ║");
    Console.WriteLine("║   12. Filmin biletlerini goster                  ║");
    Console.WriteLine("║                                                  ║");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("║   0.  Cixis                                      ║");
    Console.WriteLine("║                                                  ║");
    Console.WriteLine("╚══════════════════════════════════════════════════╝");
    Console.ResetColor();
    Console.WriteLine();
}
// ==================================================
// MOVIE
// ==================================================
void AddMovie()
{
    ShowTitle("  FILM ELAVE ET");
    Console.Write("Film Id: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        ShowError("Id duzgun daxil edilmeyib.");
        return;
    }
    Console.Write("Film adi: ");
    string? title = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(title))
    {
        ShowError("Film adi bos ola bilmez.");
        return;
    }
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("╭──────────────────────────────╮");
    Console.WriteLine("│          JANRLAR             │");
    Console.WriteLine("├──────────────────────────────┤");
    Console.ResetColor();
    Console.WriteLine("│ 1. Comedy                    │");
    Console.WriteLine("│ 2. Drama                     │");
    Console.WriteLine("│ 3. Action                    │");
    Console.WriteLine("│ 4. Horror                    │");
    Console.WriteLine("│ 5. Romance                   │");
    Console.WriteLine("│ 6. SciFi                     │");
    Console.WriteLine("│ 7. Documentary               │");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("╰──────────────────────────────╯");
    Console.ResetColor();
    Console.Write("Janr secin: ");
    if (!int.TryParse(Console.ReadLine(), out int genreNumber) ||
        !Enum.IsDefined(typeof(Genre), genreNumber))
    {
        ShowError("Yanlis janr secildi.");
        return;
    }
    Genre genre = (Genre)genreNumber;
    Console.Write("Muddet (deqiqe): ");
    if (!int.TryParse(Console.ReadLine(), out int duration))
    {
        ShowError("Muddet duzgun daxil edilmeyib.");
        return;
    }
    if (duration <= 0)
    {
        ShowError("Muddet sifirdan boyuk olmalidir.");
        return;
    }
    Console.Write("Yas limiti: ");
    if (!int.TryParse(Console.ReadLine(), out int ageLimit))
    {
        ShowError("Yas limiti duzgun daxil edilmeyib.");
        return;
    }
    if (ageLimit < 0)
    {
        ShowError("Yas limiti menfi ola bilmez.");
        return;
    }
    Movie movie = new(id,title,genre,duration,ageLimit);
    service.AddMovie(movie);
    ShowSuccess("Film ugurla elave edildi.");
}
void ShowAllMovies()
{
    ShowTitle("BUTUN FILMLER");
    var movies = context.Movies.ToList();
    if (movies.Count == 0)
    {
        ShowError("Film yoxdur.");
        return;
    }
    foreach (var movie in movies)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("╭──────────────────────────────────────────────╮");
        Console.ResetColor();
        Console.WriteLine($"│ Id         : {movie.Id,-31}                 │");
        Console.WriteLine($"│ Ad         : {movie.Title,-31}              │");
        Console.WriteLine($"│ Janr       : {movie.Genre,-31}              │");
        Console.WriteLine($"│ Muddet     : {(movie.Duration +"deqiqe"),31}│");
        Console.WriteLine($"│ Yas limiti : {(movie.AgeLimit + "+"),-31}   │");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("╰──────────────────────────────────────────────╯");
        Console.ResetColor();
        Console.WriteLine();
    }
}
void FindMovie()
{
    ShowTitle("  FILM AXTAR");
    Console.Write("Film Id: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        ShowError("Id duzgun daxil edilmeyib.");
        return;
    }
    Movie? movie = service.FindMovieById(id);
    if (movie == null)
    {
        ShowError("Film tapilmadi.");
        return;
    }
    ShowSuccess("Film tapildi. ");
    Console.WriteLine();
    Console.WriteLine(movie);
}
void DeleteMovie()
{
    ShowTitle("  FILM SIL");
   Console.Write("Silmek istediyiniz film Id: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        ShowError("Id duzgun daxil edilmeyib.");
        return;
    }
    Movie? movie = service.FindMovieById(id);
    if (movie == null)
    {
        ShowError("Film tapilmadi.");
        return;
    }
    Console.WriteLine();
    Console.WriteLine($"Film: {movie.Title}");
    Console.WriteLine();
    Console.Write("Silmeye eminsiniz? (beli/xeyr): ");
    string? answer = Console.ReadLine();
    if (answer?.ToLower() != "beli")
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Silme emeliyyati legv edildi.");
        Console.ResetColor();
        return;
    }
    service.DeleteMovie(id);
    ShowSuccess("Film ugurla silindi.");
}
// ==================================================
// CUSTOMER
// ==================================================
void AddCustomer()
{
    ShowTitle("  MUSTERI ELAVE ET");

    Console.Write("Musteri Id: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        ShowError("Id duzgun daxil edilmeyib.");
        return;
    }

    Console.Write("Musteri adi: ");
    string? name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
        ShowError("Musteri adi bos ola bilmez.");
        return;
    }

    Console.Write("Musterinin yasi: ");

    if (!int.TryParse(Console.ReadLine(), out int age))
    {
        ShowError("Yas duzgun daxil edilmeyib.");
        return;
    }

    if (age <= 0)
    {
        ShowError("Yas sifirdan boyuk olmalidir.");
        return;
    }

    Customer customer = new(id,name,age);
    service.AddCustomer(customer);
    ShowSuccess("Musteri ugurla elave edildi. ");
}
void ShowAllCustomers()
{
    ShowTitle("  BUTUN MUSTERILER");

    var customers = context.Customers.ToList();

    if (customers.Count == 0)
    {
        ShowError("Musteri yoxdur.");
        return;
    }

    foreach (var customer in customers)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.WriteLine(" ╭──────────────────────────────────────────────╮");
        Console.ResetColor();
        Console.WriteLine($"│ Id  : {customer.Id,-36}                      │");
        Console.WriteLine($"│ Ad  : {customer.Name,-36}                    │");
        Console.WriteLine($"│ Yas : {customer.Age,-36}                     │");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" ╰──────────────────────────────────────────────╯");
        Console.ResetColor();
        Console.WriteLine();
    }
}
void FindCustomer()
{
    ShowTitle("  MUSTERI AXTAR");

    Console.Write("Musteri Id: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        ShowError("Id duzgun daxil edilmeyib.");
        return;
    }

    Customer? customer = service.FindCustomerById(id);

    if (customer == null)
    {
        ShowError("Musteri tapilmadi.");
        return;
    }

    ShowSuccess("Musteri tapildi. ");

    Console.WriteLine();
    Console.WriteLine(customer);
}
// ==================================================
// TICKET
// ==================================================

void BuyTicket()
{
    ShowTitle("  BILET AL");

    Console.Write("Bilet Id: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        ShowError("Id duzgun daxil edilmeyib.");
        return;
    }

    Console.Write("Film Id: ");

    if (!int.TryParse(Console.ReadLine(), out int movieId))
    {
        ShowError("Film Id duzgun daxil edilmeyib.");
        return;
    }

    Console.Write("Musteri Id: ");

    if (!int.TryParse(Console.ReadLine(), out int customerId))
    {
        ShowError("Musteri Id duzgun daxil edilmeyib.");
        return;
    }

    Console.Write("Yer nomresi: ");

    string? seatNumber = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(seatNumber))
    {
        ShowError("Yer nomresi bos ola bilmez.");
        return;
    }

    Console.Write("Bilet qiymeti: ");

    if (!decimal.TryParse(Console.ReadLine(), out decimal price))
    {
        ShowError("Qiymet duzgun daxil edilmeyib.");
        return;
    }

    if (price <= 0)
    {
        ShowError("Qiymet sifirdan boyuk olmalidir.");
        return;
    }

    Ticket ticket = new(id,movieId,customerId,seatNumber,price);
    service.BuyTicket(ticket);
    ShowSuccess("Bilet ugurla alindi. ");
}
void ShowAllTickets()
{
    ShowTitle(" BUTUN BILETLER");

    var tickets = context.Tickets.ToList();

    if (tickets.Count == 0)
    {
        ShowError("Bilet yoxdur.");
        return;
    }
    foreach (var ticket in tickets)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.WriteLine(" ╭──────────────────────────────────────────────╮");
        Console.ResetColor();
        Console.WriteLine($"│ Bilet Id   : {ticket.Id,-31}                 │");
        Console.WriteLine($"│ Film Id    : {ticket.MovieId,-31}            │");
        Console.WriteLine($"│ Musteri Id : {ticket.CustomerId,-31}         │");
        Console.WriteLine($"│ Yer        : {ticket.SeatNumber,-31}         │");
        Console.WriteLine($"│ Qiymet     : {ticket.Price,-31}              │");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" ╰──────────────────────────────────────────────╯");
        Console.ResetColor();
        Console.WriteLine();
    }
}
void FindTicket()
{
    ShowTitle("  BILET AXTAR");

    Console.Write("Bilet Id: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        ShowError("Id duzgun daxil edilmeyib.");
        return;
    }

    Ticket? ticket = service.FindTicketById(id);

    if (ticket == null)
    {
        ShowError("Bilet tapilmadi.");
        return;
    }

    ShowSuccess("Bilet tapildi. ");

    Console.WriteLine();
    Console.WriteLine(ticket);
}

void CancelTicket()
{
    ShowTitle("  BILET LEGVI");

    Console.Write("Legv etmek istediyiniz bilet Id: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        ShowError("Id duzgun daxil edilmeyib.");
        return;
    }

    Ticket? ticket = service.FindTicketById(id);

    if (ticket == null)
    {
        ShowError("Bilet tapilmadi.");
        return;
    }

    Console.WriteLine();
    Console.WriteLine($"Bilet Id : {ticket.Id}");
    Console.WriteLine($"Yer      : {ticket.SeatNumber}");
    Console.WriteLine();

    Console.Write("Bileti legv etmek isteyirsiniz? (beli/xeyr): ");

    string? answer = Console.ReadLine();

    if (answer?.ToLower() != "beli")
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Legv emeliyyati dayandirildi.");
        Console.ResetColor();
        return;
    }

    service.CancelTicket(id);

    ShowSuccess("Bilet ugurla legv edildi. ");
}

void ShowMovieTickets()
{
    ShowTitle("  FILMIN BILETLERI");

    Console.Write("Film Id: ");

    if (!int.TryParse(Console.ReadLine(), out int movieId))
    {
        ShowError("Film Id duzgun daxil edilmeyib.");
        return;
    }

    Movie? movie = service.FindMovieById(movieId);

    if (movie == null)
    {
        ShowError("Film tapilmadi.");
        return;
    }

    var tickets = context.Tickets
        .Where(x => x.MovieId == movieId)
        .ToList();

    Console.WriteLine($"Film: {movie.Title}");
    Console.WriteLine();

    if (tickets.Count == 0)
    {
        ShowError("Bu film ucun bilet yoxdur.");
        return;
    }

    foreach (var ticket in tickets)
    {
        Customer? customer = service.FindCustomerById(ticket.CustomerId);

        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.WriteLine(" ╭──────────────────────────────────────────────╮");
        Console.ResetColor();
        Console.WriteLine($"│ Bilet Id : {ticket.Id,-32}                   │");
        Console.WriteLine($"│ Musteri  : {customer?.Name,-32}              │");
        Console.WriteLine($"│ Yer      : {ticket.SeatNumber,-32}           │");
        Console.WriteLine($"│ Qiymet   : {ticket.Price,-32}                │");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" ╰──────────────────────────────────────────────╯");
        Console.ResetColor();
        Console.WriteLine();
    }
}
// ==================================================
// UI
// ==================================================
void ShowTitle(string title)
{
    Console.ForegroundColor = ConsoleColor.Magenta;

    Console.WriteLine();
    Console.WriteLine("╔══════════════════════════════════════════════════╗");
    Console.WriteLine($" ║ {title,-48} ║");
    Console.WriteLine("╚══════════════════════════════════════════════════╝");
    Console.ResetColor();
    Console.WriteLine();
}
void ShowSuccess(string message)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine();
    Console.WriteLine($"╭─── ✓ {message}");
    Console.WriteLine(" ╰──────────────────────────────────────────────");

    Console.ResetColor();
}
void ShowError(string message)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine();
    Console.WriteLine($"╭─── ✗ {message}");
    Console.WriteLine(" ╰──────────────────────────────────────────────");
    Console.ResetColor();
}
void Pause()
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("  Davam etmek ucun Enter basin...");
    Console.ResetColor();
    Console.ReadLine();
}
void ShowExitMessage()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine();
    Console.WriteLine("╔══════════════════════════════════════════════════╗");
    Console.WriteLine("║                                                  ║");
    Console.WriteLine("║           Cinema Manager baglandi                ║");
    Console.WriteLine("║                                                  ║");
    Console.WriteLine("║              Bir daha gel!                       ║");
    Console.WriteLine("║                                                  ║");
    Console.WriteLine("╚══════════════════════════════════════════════════╝");
    Console.ResetColor();
}