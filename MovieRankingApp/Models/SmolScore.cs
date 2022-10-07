using System;
using System.Collections.Generic;

namespace MovieRankingApp.Models
{
    public partial class SmolScore
    {
        public long ScoreId { get; set; }
        public long MovieId { get; set; }
        public long ActingScore { get; set; }
        public long CharacterScore { get; set; }
        public long CinematographyScore { get; set; }
        public long EffectScore { get; set; }
        public long PlotScore { get; set; }
        public long WorldScore { get; set; }
        public long TotalScore { get; set; }

        public virtual MovieList Movie { get; set; } = null!;
    }
}
