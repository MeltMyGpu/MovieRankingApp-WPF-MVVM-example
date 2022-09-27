using MovieRankingApp.ViewModels.Interfaces;
using MovieRankingApp.ViewModels;
using MovieRankingApp;

namespace MovieRankingApp.Controllers
{
    public class ViewModelLocator
    {
        public MovieListPageViewModel MovieListPageViewModel
        {
            get => (MovieListPageViewModel)App.serviceProvider.GetService(typeof(MovieListPageViewModel));
            // GetRequiredService<MovieListPageViewModel>()
            
        }
    }
}