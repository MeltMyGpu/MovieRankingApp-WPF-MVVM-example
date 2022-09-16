using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Threading.Tasks;
using MovieRankingApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace MovieRankingApp.ViewModels
{
    public class MovieListViewModel : ObservableObject
    {
        private MovieRankingDatabaseContext _databaseContext;
        public List<MovieList> _movies = new List<MovieList>();
        public MovieListViewModel()
        {
            _databaseContext = new MovieRankingDatabaseContext();
            GetMovieList();
            
            // Replace with DependacyInjection
        }

        private void GetMovieList()
        {
            _databaseContext.MovieLists.Load();
            if (_databaseContext.MovieLists == null)
            {
                return;
            }
            _movies.Clear();
            foreach (var m in _databaseContext.MovieLists)
            {
                _movies.Add(m);
            }

        }

    }
}
