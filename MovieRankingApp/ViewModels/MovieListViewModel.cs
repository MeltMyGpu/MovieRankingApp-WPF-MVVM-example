using MovieRankingApp.ViewModels;
using System;
using System.Collections.Generic;

namespace MovieRankingApp.Models
{
    /// <summary>
    /// The ViewModel for the MovieList model.
    /// </summary>
    public partial class MovieListViewModel : ObservableObject 
    {
        /*
        TO DO:
        - Smol Score Property
        - Tol Score Property
        - MovieTotalScore => Derived from total scores of SScore and TScore.
         */

        /// <summary>
        /// Constructor that creates a MovieList Model wrapped in this ViewModel
        /// </summary>
        /// <param name="model">
        /// The Model data handed by the load, set to 'null' if no data is handed, causing a new blank 'MovieList' to be wrapped.
        /// </param>
        public MovieListViewModel(MovieList model = null) => Model = model ?? new MovieList();

        private MovieList _model;

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
                IsModified = true;
                RaisePropertyChangedEvent();
                // Requires Implementation
            }
        }

        public virtual SmolScore? SmolScore { get; set; }

        public virtual TolScore? TolScore { get; set; }

        /// <summary>
        /// Used to flag that data inside this object has been changed
        /// </summary>
        public bool IsModified { get; set; } 


        public MovieList Model 
        {
            get => _model;
            set
            {
                _model = value;
                //raises propery changed event for all properties
                RaisePropertyChangedEvent(string.Empty);
            }
        }

    }
}
