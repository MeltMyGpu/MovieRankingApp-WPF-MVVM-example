using Microsoft.EntityFrameworkCore;
using System;

namespace MovieRankingApp.Models.Interfaces
{
    public interface IMovieRankingDatabaseContext : IDisposable
    {
        DbSet<MovieList> MovieLists { get; set; }
        DbSet<SmolScore> SmolScores { get; set; }
        DbSet<TolScore> TolScores { get; set; }

        void DoSaveChanges();
    }
}