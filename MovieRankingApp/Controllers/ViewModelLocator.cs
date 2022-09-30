using MovieRankingApp.ViewModels.Interfaces;
using MovieRankingApp.ViewModels;
using MovieRankingApp;
using MovieRankingApp.StartUpHelpers.Interfaces;

namespace MovieRankingApp.Controllers
{
    public class ViewModelLocator
    {
        public IMovieListPageViewModel? MovieListPageViewModel
        {
            // get => App.AppHost!.Services.GetService(TypeOf(MovieListPageViewModel)); 
            // GetRequiredService<MovieListPageViewModel>()
            get => (IMovieListPageViewModel?)App.AppHost!.Services.GetService(typeof(IMovieListPageViewModel));
        }
    }
}