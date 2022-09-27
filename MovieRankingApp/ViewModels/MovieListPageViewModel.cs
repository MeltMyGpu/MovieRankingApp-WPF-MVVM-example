using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRankingApp.Models;
using MovieRankingApp.Models.Interfaces;
using MovieRankingApp.ViewModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;

namespace MovieRankingApp.ViewModels
{


    /* TODO or Important.
Current switch towards Dependency injection may require re-writting of code using _databaseContext
*/

    public class MovieListPageViewModel : ObservableObject, IMovieListPageViewModel
    {
        private IMovieRankingDatabaseContext _databaseContext;

        public List<MovieListViewModel> movieList { get; set; }

        private MovieListViewModel _selectedMovieList = new();
        public MovieListViewModel SelectedMovieList
        {
            get => _selectedMovieList;
            set
            {
                _selectedMovieList = value;
            }
        }

        /// <summary>
        /// Initates class via a call to 'GetMovieList'
        /// This ensures that the class will alwasy load the data from database.
        /// </summary>
        /// <param name="databaseContext"></param>
        public MovieListPageViewModel(IMovieRankingDatabaseContext databaseContext)
        {
            this.movieList = new List<MovieListViewModel>();
            this._databaseContext = databaseContext;
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
                foreach (var Movie in _databaseContext.MovieLists.ToList())
                {
                    movieList.Add(new MovieListViewModel
                        (
                        Movie,
                        _databaseContext.TolScores.Local.FirstOrDefault(x => x.MovieId == Movie.MovieId)?.MovieId ?? 0L,
                        _databaseContext.SmolScores.Local.FirstOrDefault(x => x.MovieId == Movie.MovieId)?.MovieId ?? 0L
                        )
                        );
                }

            }
        }


        // Wont be needed on this view, kept here as code storage //
        public ICommand UpdateMovieListDbCommand { get => new DelegateCommand(UpdateMovieListDb); }

        private void UpdateMovieListDb()
        {
            using (_databaseContext = new MovieRankingDatabaseContext())
            {
                foreach (var ModifiedMoive in movieList.Where(x => x.IsModified == true).Select(x => x.Model))
                {
                    _databaseContext.MovieLists.Update(ModifiedMoive);
                    _databaseContext.DoSaveChanges();
                }

            }
        }
    }
}
