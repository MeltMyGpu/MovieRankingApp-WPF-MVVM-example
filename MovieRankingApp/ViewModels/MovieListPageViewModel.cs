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


        public MovieListPageViewModel()
        {
            movieList = new List<MovieListViewModel>();
            GetMovieList();
            // Replace with DependacyInjection
        }

        /// <summary>
        /// Gets all movies entries from the MovieList DbTable.
        /// loads models into a MovieListViewModel
        /// </summary>
        private void GetMovieList()
        {
            using (_databaseContext)
            {
                var TempListHolder = _databaseContext.MovieLists.ToList();

                if (TempListHolder == null)
                    return;

                movieList.Clear();
                foreach (var Movie in TempListHolder)
                {
                    movieList.Add(new MovieListViewModel(Movie));
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
