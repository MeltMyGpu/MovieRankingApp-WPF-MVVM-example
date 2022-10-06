using MovieRankingApp.Models;
using System.Windows.Input;

namespace MovieRankingApp.ViewModels
{
    public interface IMainWindowViewModel
    {
        string MainFrameDisplayUri { get; }
        bool CurrentlyEditing { get; set; }
        ICommand NavigateToEditDetailedView { get; }
        ICommand NavigateToAddDeatailedView { get; }
        MovieListViewModel SelectedModel { get; set; }
    }
}