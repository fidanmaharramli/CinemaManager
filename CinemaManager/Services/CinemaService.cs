using System;
using System.Collections.Generic;
using System.Text;
using CinemaManager.Entities;
using CinemaManager.Data;
using Microsoft.EntityFrameworkCore;
namespace CinemaManager.Services;
public class CinemaService
{
    private readonly AppDbContext _context;
    public CinemaService(AppDbContext context)
    {
        _context = context;
    }
    public void AddMovie(Movie movie)
    {
        if (_context.Movies.Any(x => x.Id == movie.Id))
        {
            Console.WriteLine("Bu Id ile film artiq movcuddur.");
            return;
        }
        _context.Movies.Add(movie);
        _context.SaveChanges();
        Console.WriteLine("Film ugurla elave edildi.");
    }
    public void ShowAllMovies()
    {
        var movies = _context.Movies.ToList();
        if (movies.Count == 0)
        {
            Console.WriteLine("Film yoxdur.");
            return;
        }
        foreach (var movie in movies)
        {
            Console.WriteLine(movie);
        }
    }
    public Movie? FindMovieById(int id)
    {
        return _context.Movies.FirstOrDefault(x => x.Id == id);
    }
    public void DeleteMovie(int id)
    {
        Movie? movie = FindMovieById(id);
        if (movie == null)
        {
            Console.WriteLine("Film tapilmadi.");
            return;
        }
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        Console.WriteLine("Film ugurla silindi.");
    }
    public void AddCustomer(Customer customer)
    {
        if (_context.Customers.Any(x => x.Id == customer.Id))
        {
            Console.WriteLine("Bu Id ile musteri artiq movcuddur.");
            return;
        }
        _context.Customers.Add(customer);
        _context.SaveChanges();
        Console.WriteLine("Musteri ugurla elave edildi.");
    }
    public void ShowAllCustomers()
    {
        var customers = _context.Customers.ToList();
        if (customers.Count == 0)
        {
            Console.WriteLine("Musteri yoxdur.");
            return;
        }
        foreach (var customer in customers)
        {
            Console.WriteLine(customer);
        }
    }
    public Customer? FindCustomerById(int id)
    {
        return _context.Customers.FirstOrDefault(x => x.Id == id);
    }
    public Ticket? FindTicketById(int id)
    {
        return _context.Tickets.FirstOrDefault(x => x.Id == id);
    }
    public void BuyTicket(Ticket ticket)
    {
        Movie? movie = FindMovieById(ticket.MovieId);
        Customer? customer = FindCustomerById(ticket.CustomerId);
        if (movie == null)
        {
            Console.WriteLine("Film tapilmadi.");
            return;
        }
        if (customer == null)
        {
            Console.WriteLine("Musteri tapilmadi.");
            return;
        }
        if (customer.Age < movie.AgeLimit)
        {
            Console.WriteLine("Musterinin yasi bu film ucun uygun deyil.");
            return;
        }
        if (ticket.Price <= 0)
        {
            Console.WriteLine("Qiymet sifirdan boyuk olmalidir.");
            return;
        }
        bool seatIsTaken = _context.Tickets.Any(x =>
            x.MovieId == ticket.MovieId &&
            x.SeatNumber == ticket.SeatNumber);

        if (seatIsTaken)
        {
            Console.WriteLine("Bu yer artiq tutulub.");
            return;
        }
        if (_context.Tickets.Any(x => x.Id == ticket.Id))
        {
            Console.WriteLine("Bu Id ile bilet artiq movcuddur.");
            return;
        }
        _context.Tickets.Add(ticket);
        _context.SaveChanges();
        Console.WriteLine("Bilet ugurla alindi.");
    }
    public void CancelTicket(int id)
    {
        Ticket? ticket = FindTicketById(id);
        if (ticket == null)
        {
            Console.WriteLine("Bilet tapilmadi.");
            return;
        }
        _context.Tickets.Remove(ticket);
        _context.SaveChanges();
        Console.WriteLine("Bilet ugurla legv edildi.");
    }
    public void ShowAllTickets()
    {
        var tickets = _context.Tickets.ToList();
        if (tickets.Count == 0)
        {
            Console.WriteLine("Bilet yoxdur.");
            return;
        }
        foreach (var ticket in tickets)
        {
            Console.WriteLine(ticket);
        }
    }
    public void ShowMovieTickets(int movieId)
    {
        Movie? movie = FindMovieById(movieId);
        if (movie == null)
        {
            Console.WriteLine("Film tapilmadi.");
            return;
        }
        var movieTickets = _context.Tickets
            .Where(x => x.MovieId == movieId).ToList();
        if (movieTickets.Count == 0)
        {
            Console.WriteLine("Bu film ucun bilet yoxdur.");
            return;
        }
        Console.WriteLine($"Film: {movie.Title}");
        foreach (var ticket in movieTickets)
        {
            Customer? customer = FindCustomerById(ticket.CustomerId);
            Console.WriteLine($"Bilet Id: {ticket.Id} | " +
                $"Musteri: {customer?.Name} | " +$"Yer: {ticket.SeatNumber} | " +
                $"Qiymet: {ticket.Price}");
        }
    }
}
