using System;
using System.Linq;
using MovieRankingApp.Models.Interfaces;
using MovieRankingApp.ViewModels.Interfaces;

namespace MovieRankingApp.ViewModels;

public class DetailedPageViewModel
{
    /*
    TODO:
    - Change calls to async or move calls external
    - Interface
    */
    public DetailedPageViewModel(IMainWindowViewModel mainWinViewModel, IMovieRankingDatabaseContext dbContext)
    {
        this._DbContext = dbContext;
        this._MainWindowViewModel = mainWinViewModel;
    }

    private IMainWindowViewModel _MainWindowViewModel;
    private IMovieRankingDatabaseContext _DbContext;
    public SmolScoreViewModel SmolScoreModel{ get; set; }
    public TolScoreViewModel TolScoreModel { get; set; }
    public MovieListViewModel MovieModel { get; set; }

    private void CheckIfCreatingNewEntry()
    {
        if( _MainWindowViewModel.SelectedModel.MovieName == null)
        {
            LoadNewAdditionStart();
        }
    }

    private void LoadNewAdditionStart()
    {
        SmolScoreModel = new SmolScoreViewModel(new Models.SmolScore()
        {
            ActingScore = 0,
            CharacterScore = 0,
            CinematographyScore = 0,
            EffectScore = 0,
            PlotScore = 0,
            WorldScore = 0,
            TotalScore = 0
        });
        TolScoreModel = new TolScoreViewModel(new Models.TolScore()
        {
            ActingScore = 0,
            CharacterScore = 0,
            CinematographyScore = 0,
            VisualEffectsScore = 0,
            PlotScore = 0,
            WorldScore = 0,
            TotalScore = 0
        });
        MovieModel = new MovieListViewModel(new Models.MovieList()
        {
            MovieName = "REQUIRED",
            MovieGenre = "REQUIRED",
            MovieReleaseDate = "00/00/0000",
            MovieTotalScore = 0
        });
    }

    private void LoadSpecificModels()
    {
        MovieModel = _MainWindowViewModel.SelectedModel;
        TolScoreModel = new TolScoreViewModel(_DbContext.TolScores.ToList().FirstOrDefault(x => x.MovieId == MovieModel.MovieId));
        SmolScoreModel = new SmolScoreViewModel(_DbContext.SmolScores.ToList().FirstOrDefault(x => x.MovieId == MovieModel.MovieId));
    }
}