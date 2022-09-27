using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MovieRankingApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using MovieRankingApp.Models;
using Microsoft.EntityFrameworkCore;
using MovieRankingApp.ViewModels.Interfaces;
using MovieRankingApp.Models.Interfaces;
using MovieRankingApp.Models;
namespace MovieRankingApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
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
        public App()
        {
           this.services = new ServiceCollection();
           ConfigureServices(services);
           serviceProvider = services.BuildServiceProvider();
        }
        public static ServiceProvider serviceProvider {get; private set;}
        private IServiceCollection services;

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MovieRankingDatabaseContext>();
            services.AddScoped<IMovieRankingDatabaseContext, MovieRankingDatabaseContext>(s => s.GetService<MovieRankingDatabaseContext>());
            services.AddScoped<IMovieListPageViewModel, MovieListPageViewModel>();
            services.AddSingleton<MainWindow>();
        }


    }
}
