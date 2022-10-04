using MovieRankingApp.Models;
using System.Windows.Input;

namespace MovieRankingApp.ViewModels
{
    public interface IMainWindowViewModel
    {
        string MainFrameDisplayUri { get; }
        ICommand NavigateToSecondView { get; }
        MovieListViewModel SelectedModel { get; set; }
    }
}