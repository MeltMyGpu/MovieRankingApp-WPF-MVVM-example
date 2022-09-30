

using System;
using Microsoft.Extensions.DependencyInjection;
using MovieRankingApp.StartUpHelpers.Interfaces;

namespace MovieRankingApp.StartUpHelpers;

/// <summary>
/// Class to Handle extentions to our services
/// </summary>
public static class ServiceExtentions
{
    /// <summary>
    /// Static method that sets up the use of the AbstractFactory in our service host.
    /// Using this allows the injection to pass in a factory which returns our desired viewmodel
    /// </summary>
    /// <typeparam name="TViewModelInterface"> generic of passed intergace</typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    /// <param name="services"></param>
    public static void AddViewModelFactory<TViewModelInterface, TViewModel>(this IServiceCollection services)
    where TViewModelInterface : class // indicates the interface is of type class
    where TViewModel : class, TViewModelInterface // indicates of type class, and implements the interface
    {
        System.Console.WriteLine("Resolved");
        services.AddTransient<TViewModelInterface, TViewModel>(); // adds generics to service package
        services.AddTransient<Func<TViewModelInterface>>(x => () => x.GetService<TViewModelInterface>()!);
        services.AddSingleton<IAbstractFactory<TViewModelInterface>, AbstractFactory<TViewModelInterface>>(); // adds factory to sevice package
    }

    
}