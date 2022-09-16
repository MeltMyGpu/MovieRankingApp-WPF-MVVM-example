using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRankingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieRankingApp.ViewModels
{
    public class MovieListViewModel
    {
        private MovieRankingDatabaseContext _databaseContext;
        private MovieList _movieList;
        public MovieListViewModel()
        {
            _databaseContext = new MovieRankingDatabaseContext();
            _movieList = new MovieList();
            // Replace with DependacyInjection
        }

        private void GetList() // issues here loading invidual products
        {
            _databaseContext.MovieLists.Load();
            _movieList = _databaseContext.MovieLists.Local;
        }
        //public long MovieId 
        //{
        //    get { return MovieId; }
        //    set
        //    {
        //        if (MovieId != value)
        //        {
        //            MovieId = value;
        //            //OnPropertyChanged("MovieId");
        //        }
        //    }
        //}
        //public string MovieName
        //{
        //    get { return MovieName; }
        //    set
        //    {
        //        if (MovieName != value)
        //        {
        //            MovieName = value;
        //            //OnPropertyChanged("MovieName");
        //        }
        //    }
        //}
        //public string MovieGenre
        //{
        //    get { return MovieGenre; }
        //    set
        //    {
        //        if (MovieGenre != value)
        //        {
        //            MovieGenre = value;
        //            //OnPropertyChanged("MovieId");
        //        }
        //    }
        //}
        //public string MovieReleaseDate
        //{
        //    get { return MovieReleaseDate; }
        //    set
        //    {
        //        if(MovieReleaseDate != value)
        //        {
        //            MovieReleaseDate = value;
        //            //prop change event call
        //        }
        //    }
        //}
        //public long MovieTotalScore
        //{
        //    get { return MovieTotalScore; }
        //}

        //public virtual SmolScore? SmolScore { get; set; }
        //public virtual TolScore? TolScore { get; set; }

        // End Region
        // Region Private Helpers


    }
}
