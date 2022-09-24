using System;
using System.Collections.Generic;

namespace MovieRankingApp.Models
{
    public partial class MovieList
    {
        public long MovieId { get; set; }
        public string MovieName { get; set; } = null!;
        public string MovieGenre { get; set; } = null!;
        public string MovieReleaseDate { get; set; } = null!;
        public long MovieTotalScore { get; set; }

        public virtual SmolScore SmolScore { get; set; }
        public virtual TolScore TolScore { get; set; } 
    }
}
