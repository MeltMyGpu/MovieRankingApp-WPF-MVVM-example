using System;
using MovieRankingApp.StartUpHelpers.Interfaces;
namespace MovieRankingApp.StartUpHelpers;


/// <summary>
/// A generic abstract factory used for Dependecy injection.
/// Takes in generic delagate and returns its execution opon calling 'Create'
/// </summary>
/// <typeparam name="T"></typeparam>
public class AbstractFactory<T> : IAbstractFactory<T>
{
    private readonly Func<T> _factory;

    public AbstractFactory(Func<T> factory)
    {
        this._factory = factory;
    }

    public T Create()
    {
        return _factory();
    }
}