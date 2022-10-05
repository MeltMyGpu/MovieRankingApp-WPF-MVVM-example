using MovieRankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieRankingApp.ViewModels;
/*
 TODO
- test using a static property to hold the selected item from one view for loading it in another
- Test storing navigation URI's in public propertys and adjusting them based on interaction, by having
  interactions bound to properties that change the main frames bound URI
- Extract interface
- Add to service collection
 */
public class MainWindowViewModel : ObservableObject, IMainWindowViewModel
{
    /// <summary>
    /// Starts the Main pages frame display, and sets selected model to blank placeholder
    /// </summary>
    public MainWindowViewModel()
    {
        _mainFrameDisplayUri = "../Views/MoiveListPage.xmal";
        _selectedModel = new();
    }


    #region Data Binding Properties and fields
    
    /// <summary>
    /// Frame within main window binds its source to this, allowing for 
    /// buttons binded to commands to change the uri and therefore hange page
    /// </summary>
    private string _mainFrameDisplayUri;
    public string MainFrameDisplayUri
    {
        get => _mainFrameDisplayUri;
    }

    /// <summary>
    /// Holds the curretly selected model from the dataGrid, will be used 
    /// to load the relevant row from the database to the Detailed view
    /// </summary>
    private MovieListViewModel _selectedModel;
    public MovieListViewModel SelectedModel
    {
        get => _selectedModel;
        set
        {
            _selectedModel = value;
        }
    }

    #endregion
    
    #region Command Bindings 

    /// <summary>
    /// Allows for Navigation to DetailedViewPage.
    /// </summary>
    public ICommand NavigateToSecondView
    {
        get => new DelegateCommand(ChangeToDetailedFramePage);
    }

    private void ChangeToDetailedFramePage() // Require uri for page to be added when page is added.
    {
        _mainFrameDisplayUri = "DetailedViewPageUri";
    }



    #endregion
}
