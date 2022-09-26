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
        //public List<TolScoreViewModel> tolScores {get; set;}
        //public List<SmolScoreViewModel> smolScores {get; set;}


        public MovieListPageViewModel()
        {
            movieList = new List<MovieListViewModel>();
            //tolScores = new List<TolScoreViewModel>();
            //smolScores = new List<SmolScoreViewModel>();
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
                // I know this is messy as fuck, but it works, leave me alone.
                _databaseContext.TolScores.Load();
                _databaseContext.SmolScores.Load();
                foreach(var Movie in _databaseContext.MovieLists.ToList())
                {
                    movieList.Add( new MovieListViewModel
                        // Now causes a stack overflow on assignment --> not sure why
                        (
                        Movie, 
                        _databaseContext.TolScores.Local.FirstOrDefault(x => x.MovieId == Movie.MovieId)?.MovieId ?? 0L,
                        _databaseContext.SmolScores.Local.FirstOrDefault(x => x.MovieId == Movie.MovieId)?.MovieId ?? 0L
                        )
                        );
                    // var Tscore = _databaseContext.TolScores.Local.Where(x => x.MovieId == Movie.MovieId).Select(x => x.TotalScore);
                    // var Tscore = _databaseContext.TolScores.Local.FirstOrDefault(x => x.MovieId == Movie.MovieId)?.TotalScore ?? 0;
                    
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
