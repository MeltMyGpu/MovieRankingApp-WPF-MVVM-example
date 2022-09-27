    using MovieRankingApp.Models;
    using System.Collections.Generic;
    using System.Windows.Input;
    
    
    namespace MovieRankingApp.ViewModels.Interfaces
    {
        public interface IMovieListPageViewModel
        {
            List<MovieListViewModel> movieList { get; set; }
            MovieListViewModel SelectedMovieList { get; set; }
            ICommand UpdateMovieListDbCommand { get; }
        }
    }