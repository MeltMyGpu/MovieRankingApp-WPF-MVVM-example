using System;
using System.Collections.Generic;

namespace MovieRankingApp.Models
{
    public partial class TolScore
    {
        public long RatingId { get; set; }
        public long MovieId { get; set; }
        public long ActingScore { get; set; }
        public long CharacterScore { get; set; }
        public long CinematographyScore { get; set; }
        public long VisualEffectsScore { get; set; }
        public long PlotScore { get; set; }
        public long WorldScore { get; set; }

        public virtual MovieList Movie { get; set; } = null!;
    }
}
