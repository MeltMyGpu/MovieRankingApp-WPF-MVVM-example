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
        public List<TolScoreViewModel> tolScores {get; set;}
        public List<SmolScoreViewModel> smolScores {get; set;}


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
                //_databaseContext.TolScores.Local.ToList()/*.ForEach(x => tolScores.Add(new TolScoreViewModel(x)))*/;
                //var ss = _databaseContext.SmolScores.Local.ToList()/*.ForEach(x => smolScores.Add(new SmolScoreViewModel(x)))*/;    
                foreach(var Movie in _databaseContext.MovieLists.ToList())
                {
                    long ts = 0;
                    long ss = 0;
                    if (_databaseContext.TolScores.ToList().Count >= Movie.MovieId)
                    {
                        ts = tolScores.FirstOrDefault(x => x == x).TotalScore;
                    }
                    if (smolScores.FirstOrDefault(x => x.MovieId == Movie.MovieId) != null)
                    {
                        ss = smolScores.FirstOrDefault(x => x.MovieId == Movie.MovieId).TotalScore;
                    }
                    
                    
                    MovieListViewModel ConstructionMovieList = new
                        (
                        Movie, ts, ss
                        );
                }

<<<<<<< Updated upstream
                movieList.Clear();
                foreach (var Movie in TempListHolder)
                {
                    movieList.Add(new MovieListViewModel(Movie));
                }
                
=======
 
>>>>>>> Stashed changes
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
