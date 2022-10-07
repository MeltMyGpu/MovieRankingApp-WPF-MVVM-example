using MovieRankingApp.ViewModels.Interfaces;
using MovieRankingApp.ViewModels;
using MovieRankingApp;
using MovieRankingApp.StartUpHelpers.Interfaces;
using System.IO;
using System;

namespace MovieRankingApp.Controllers;

/// <summary>
/// This class provides viewModels to elements that require them via binding to the propeties of the class.
/// Used to ensure Dependecys are at runtime depending on request.
/// </summary>
public class ViewModelLocator 
{
    public static IMovieListPageViewModel? MovieListPageViewModel
    {
        get => (MovieListPageViewModel?)App.AppHost!.Services.GetService(typeof(IMovieListPageViewModel));
    }
    
    public static IMainWindowViewModel? MainWindowViewModel
    {
        get => (MainWindowViewModel?)App.AppHost!.Services.GetService(typeof(IMainWindowViewModel));
    }

 
    
}