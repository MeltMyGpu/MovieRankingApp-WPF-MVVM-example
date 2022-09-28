using MovieRankingApp.ViewModels.Interfaces;
using MovieRankingApp.ViewModels;
using MovieRankingApp;

namespace MovieRankingApp.Controllers
{
    public class ViewModelLocator
    {
        public static IMovieListPageViewModel? MovieListPageViewModel
        {
            // get => App.AppHost!.Services.GetService(TypeOf(MovieListPageViewModel)); 
            // GetRequiredService<MovieListPageViewModel>()
            get;
        }
    }
}