using MovieRankingApp.Models;

namespace MovieRankingApp.ViewModels.Interfaces
{
    public interface IMovieListViewModel
    {
        bool IsModified { get; set; }
        MovieList Model { get; set; }
        string MovieGenre { get; set; }
        long MovieId { get; set; }
        string MovieName { get; set; }
        string MovieReleaseDate { get; set; }
        long MovieTotalScore { get; set; }
        long SmolTotalScore { get; set; }
        long TolTotalScore { get; set; }
    }
}