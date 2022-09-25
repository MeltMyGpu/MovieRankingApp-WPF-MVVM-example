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
        - Score Weightinh
         */

        /// <summary>
        /// Constructor that creates a MovieList Model wrapped in this ViewModel
        /// </summary>
        /// <param name="model">
        /// The Model data handed by the load, set to 'null' if no data is handed, causing a new blank 'MovieList' to be wrapped.
        /// </param>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MovieListViewModel(MovieList? model = null, TolScoreViewModel? TolScore = null, SmolScoreViewModel? SmolScore = null)
        {
            _smolScore = SmolScore ?? new SmolScoreViewModel();
            _tolScore = TolScore ?? new TolScoreViewModel();
            Model = model ?? new MovieList();
        }

        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private MovieList _model;
        private SmolScoreViewModel _smolScore;
        private TolScoreViewModel _tolScore;
        //private readonly TolScoreViewModel _tolScoreViewModel;
        //private SmolScoreViewModel _smolScoreViewModel;

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
                _model.MovieTotalScore = (_smolScore.TotalScore + _tolScore.TotalScore) / 2;
                RaisePropertyChangedEvent();
            }
        }

        public long SmolScore
        { 
            get => _smolScore.TotalScore;
        }

        public long TolScore 
        { 
            get => _tolScore.TotalScore;
        }
    }
}
