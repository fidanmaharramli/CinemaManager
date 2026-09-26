using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
namespace CinemaManager.Entities;
public class Movie
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Title { get; set; }
    public Genre Genre { get; set; }
    public int Duration { get; set; }
    public int AgeLimit { get; set; }
    public Movie(int id, string title, Genre genre, int duration, int ageLimit)
    {
        Id = id;
        Title = title;
        Genre = genre;
        Duration = duration;
        AgeLimit = ageLimit;
    }
    public override string ToString()
    {
        return $"Id: {Id}, Title: {Title}, Genre: {Genre}, Duration: {Duration} min, Age Limit: {AgeLimit}+";
    }
}
