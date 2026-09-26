using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
namespace CinemaManager.Entities;
public class Ticket
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int CustomerId { get; set; }
    public string SeatNumber { get; set; }
    public decimal Price { get; set; }
    public Ticket(int id,int movieId,int customerId,string seatNumber,decimal price)
    {
        Id = id;
        MovieId = movieId;
        CustomerId = customerId;
        SeatNumber = seatNumber;
        Price = price;
    }
    public override string ToString()
    {
        return $"Ticket Id: {Id}, Movie Id: {MovieId}, Customer Id: {CustomerId}, Seat: {SeatNumber}, Price: {Price}";
    }
}
