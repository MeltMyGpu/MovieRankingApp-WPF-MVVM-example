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
    public static MovieListPageViewModel? MovieListPageViewModel
    {
        get => (MovieListPageViewModel?)App.AppHost!.Services.GetService(typeof(IMovieListPageViewModel));
    }


    // Currently not in use, may be used to allow for navigation
    public string EditPage
    {
        get => "../Views/"; // needs setting
    }

    public string StartingPage
    {
        get => "../Views/MovieListPage.xmal";
    }
    
}