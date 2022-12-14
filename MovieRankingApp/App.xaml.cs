using MovieRankingApp.StartUpHelpers;
using System.Windows;
using MovieRankingApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using MovieRankingApp.Models;
using Microsoft.EntityFrameworkCore;
using MovieRankingApp.ViewModels.Interfaces;
using MovieRankingApp.Models.Interfaces;
using Microsoft.Extensions.Hosting;
using MovieRankingApp.Controllers;

namespace MovieRankingApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    public static IHost? AppHost { get; private set; }

    public App()
    {
        // Configuration of Dependency Injection
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddTransient<IMovieListPageViewModel, MovieListPageViewModel>();
                services.AddDbContext<IMovieRankingDatabaseContext, MovieRankingDatabaseContext>();
                services.AddScoped<IMovieListPageViewModel, MovieListPageViewModel>();
                services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
                services.AddSingleton<ViewModelLocator>();
                services.AddSingleton<MainWindow>();
            })
            .Build();

        /* Application resources must be declared in code as well as in xaml,
        /  just declaring in xaml throw and error when resource is accessed */
        Resources = new ResourceDictionary(); 
        Resources.Add("ViewModelLocator", AppHost.Services.GetRequiredService<ViewModelLocator>());
    }

    protected override async void OnStartup(StartupEventArgs startupArgs)
    {
        
        base.OnStartup(startupArgs);
        await AppHost!.StartAsync(); // ensures the host is started before the app displays
        var StartUpPage = AppHost.Services.GetRequiredService<MainWindow>(); 
        // need to override app entry point to an injected version of main window to ensure dependecys are resolved.
        StartUpPage.Show();
    }


    protected override async void OnExit(ExitEventArgs exitArgs)
    {
        await AppHost!.StopAsync(); // ensures the host is shutdown before the app closes
        base.OnExit(exitArgs);
    }
    // ServiceProvider ServiceProvider {get; set;}

    // protected override void OnStartup(StartupEventArgs e)
    // {
    //     base.OnStartup(e);
    //     ServiceProvider = new ServiceCollection()
    //     .
    // }

    // start of dependency injection
    // Still need to implement some form of resolver based on loaded page? 
    // controller containing all VM's that has propeties returning an instance of service provided MV ?
    // bind page DataContext to property from this static resource?
    //public App()
    //{
    //   this.services = new ServiceCollection();
    //   ConfigureServices(services);
    //   serviceProvider = services.BuildServiceProvider();
    //}
    //public static ServiceProvider serviceProvider {get; private set;}
    //private IServiceCollection services;

    //private void ConfigureServices(IServiceCollection services)
    //{
    //    services.AddScoped<MovieRankingDatabaseContext>();
    //    services.AddScoped<IMovieRankingDatabaseContext, MovieRankingDatabaseContext>(s => s.GetService<MovieRankingDatabaseContext>());
    //    services.AddScoped<IMovieListPageViewModel, MovieListPageViewModel>();
    //    services.AddSingleton<MainWindow>();
    //}


}
