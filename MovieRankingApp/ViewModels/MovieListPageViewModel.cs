using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRankingApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;

namespace MovieRankingApp.ViewModels
{
    public class MovieListPageViewModel : ObservableObject
    {
        private MovieRankingDatabaseContext _databaseContext = new();

        public List<MovieListViewModel> movieList {get; set;}

        private MovieListViewModel _selectedMovieList = new();
        public MovieListViewModel SelectedMovieList {
             get => _selectedMovieList;
             set 
             {
                _selectedMovieList = value;
             }
            }
       

        public MovieListPageViewModel()
        {
            movieList = new List<MovieListViewModel>();
            GetMovieList();
        }


        /// <summary>
        /// Gets all movies entries from the MovieList DbTable.
        /// loads models into a MovieListViewModel
        /// </summary>
        private void GetMovieList()
        {
            using (_databaseContext)
            {
                _databaseContext.TolScores.Load();
                _databaseContext.SmolScores.Load();
                foreach(var Movie in _databaseContext.MovieLists.ToList())
                {
                    movieList.Add( new MovieListViewModel
                        (
                        Movie, 
                        _databaseContext.TolScores.Local.FirstOrDefault(x => x.MovieId == Movie.MovieId)?.MovieId ?? 0L,
                        _databaseContext.SmolScores.Local.FirstOrDefault(x => x.MovieId == Movie.MovieId)?.MovieId ?? 0L
                        )
                        );             
                }

            }
        }

        public ICommand UpdateMovieListDbCommand { get { return new DelegateCommand(UpdateMovieListDb); } }

        private void UpdateMovieListDb()
        {
            using (_databaseContext = new MovieRankingDatabaseContext())
            {
                foreach(var ModifiedMoive in movieList.Where(x => x.IsModified == true).Select(x => x.Model))
                {
                    _databaseContext.MovieLists.Update(ModifiedMoive);
                    _databaseContext.SaveChanges();
                }

            }
        }
    }
}
