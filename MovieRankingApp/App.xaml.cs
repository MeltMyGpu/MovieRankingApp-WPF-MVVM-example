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

namespace MovieRankingApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // start of dependency injection
        // Still need to implement some form of resolver based on loaded page? 
        // controller containing all VM's that has propeties returning an instance of service provided MV ?
        // bind page DataContext to property from this static resource?
        private ServiceProvider _serviceProvider;
        public App()
        {
           ServiceCollection services = new ServiceCollection();
           ConfigureServices(services);
           _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
           services.AddDbContext<MovieRankingDatabaseContext>(options =>
           {
               options.UseSqlite("DataSource=E:\\Code\\Project libary\\C#\\TestingForPettime\\MovieRankingApp\\MovieRankingDatabase.db");
           });
            services.AddScoped<IMovieListPageViewModel, MovieListPageViewModel>();
            services.AddSingleton<MainWindow>();
        }


    }
}
