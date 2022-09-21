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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public class MovieListViewModel : ObservableObject
    {
        private MovieRankingDatabaseContext _databaseContext;
        public List<MovieList> _movies = new List<MovieList>();
        public MovieListViewModel()
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
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

        #region Derived model propertys
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
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream

=======
        }

        public virtual SmolScore? SmolScore { get; set; }

        public virtual TolScore? TolScore { get; set; }
        #endregion

        #region ViewModel Properties


        /// <summary>
        /// Used to flag that data inside this object has been changed
        /// </summary>
        /// 
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
>>>>>>> Stashed changes
        }
        #endregion
    }
}
