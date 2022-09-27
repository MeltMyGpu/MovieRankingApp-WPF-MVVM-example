using MovieRankingApp.ViewModels;
using System;
using System.Collections.Generic;

namespace MovieRankingApp.Models
{
    public partial class MovieListViewModel : ObservableObject 
    {
        /*
        TO DO:
        - Score Weightinh
         */

        /// <summary>
        /// Constructor that creates a MovieList Model wrapped in this ViewModel
        /// </summary>
        /// <param name="tolScore"> The total score from the TolScore model linked to the movie</param>
        /// <param name="smolScore"> The total score from the SmolScore model linked to the movie</param>
        /// <param name="model">
        /// The Model data handed by the load, set to 'null' if no data is handed, causing a new blank 'MovieList' to be wrapped.
        /// </param>
        public MovieListViewModel(MovieList? model = null, long tolScore = 0L , long smolScore = 0L)
        {
            SmolTotalScore = smolScore;
            TolTotalScore = tolScore;
            Model = model ?? new MovieList();
        }

        private MovieList _model;
        /// <summary> allows altered models to be found quickly with query for saving/ updating database <\summary>
        public bool IsModified { get; set; } // needs to  be hidden from the datagrid 


        public MovieList Model // needs to  be hidden from the datagrid
        {
            get => _model;
            set
            {
                _model = value;
                //raises propery changed event for all properties
                RaisePropertyChangedEvent(string.Empty);
            }
        }

        public long MovieId 
        {
            get => Model.MovieId;
            set
            {
                if (value != Model.MovieId)
                {
                    _model.MovieId = value;
                    IsModified = true;
                    RaisePropertyChangedEvent();
                }
            }
        }
        public string MovieName
        {
            get => Model.MovieName;
            set
            {
                if (Model.MovieName != value)
                {
                    _model.MovieName = value;
                    IsModified = true;
                    RaisePropertyChangedEvent();
                }
            }
        }
        public string MovieGenre 
        { 
            get => Model.MovieGenre;
            set 
            {
                if (Model.MovieGenre != value)
                {
                    Model.MovieGenre = value;
                    IsModified = true;
                    RaisePropertyChangedEvent();
                }
            }
        } 
        public string MovieReleaseDate
        {
            get => Model.MovieReleaseDate;
            set
            {
                if(value != Model.MovieReleaseDate)
                {
                    Model.MovieReleaseDate = value;
                    IsModified = true;
                    RaisePropertyChangedEvent();
                }
            }
        }
        public long MovieTotalScore
        {
            get => Model.MovieTotalScore;
            set
            {
                _model.MovieTotalScore = (SmolTotalScore + TolTotalScore) / 2;
                RaisePropertyChangedEvent();
            }
        }

        private long _smolTotalScore;
        private long _tolTotalScore;
        public long SmolTotalScore
        { 
            get => _smolTotalScore;
            set => _smolTotalScore = value;
        }

        public long TolTotalScore 
        { 
            get => _tolTotalScore;
            set => _tolTotalScore = value;
        }
    }
}
