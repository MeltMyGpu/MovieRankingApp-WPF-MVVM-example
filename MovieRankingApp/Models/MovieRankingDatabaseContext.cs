using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MovieRankingApp.Models
{
    public partial class MovieRankingDatabaseContext : DbContext
    {
        public MovieRankingDatabaseContext()
        {
        }

        public MovieRankingDatabaseContext(DbContextOptions<MovieRankingDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MovieList> MovieLists { get; set; } = null!;
        public virtual DbSet<SmolScore> SmolScores { get; set; } = null!;
        public virtual DbSet<TolScore> TolScores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=E:\\Code\\Project libary\\C#\\TestingForPettime\\MovieRankingApp\\MovieRankingDatabase.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieList>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.ToTable("MovieList");

                entity.HasIndex(e => e.MovieId, "IX_MovieList_MovieId")
                    .IsUnique();
            });

            modelBuilder.Entity<SmolScore>(entity =>
            {
                entity.HasKey(e => e.ScoreId);

                entity.ToTable("SmolScore");

                entity.HasIndex(e => e.MovieId, "IX_SmolScore_MovieId")
                    .IsUnique();

                entity.HasIndex(e => e.ScoreId, "IX_SmolScore_ScoreId")
                    .IsUnique();

                entity.HasOne(d => d.Movie)
                    .WithOne(p => p.SmolScore)
                    .HasForeignKey<SmolScore>(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TolScore>(entity =>
            {
                entity.HasKey(e => e.RatingId);

                entity.ToTable("TolScore");

                entity.HasIndex(e => e.MovieId, "IX_TolScore_MovieId")
                    .IsUnique();

                entity.HasIndex(e => e.RatingId, "IX_TolScore_RatingId")
                    .IsUnique();

                entity.HasOne(d => d.Movie)
                    .WithOne(p => p.TolScore)
                    .HasForeignKey<TolScore>(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
