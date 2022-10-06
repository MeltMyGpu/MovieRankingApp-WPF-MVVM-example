# MovieRankingApp-WPF-MVVM-example
<sub> **Implements:** <br/> *_Hand-cranked MVVM <br/> WPF <br/> Entity Framework <br/> SQLite <br/> MS Dependency injection_* </sub>


## Project overview

This project was designed as a precurssor to 
a larger project,and was used to learn the 
stack listed at the top of this read-me. <br/> 
<br/>
The app is simple in design, it allows a user 
to perform CRUD operations on an Multi-Table SQLite
database, adding movie and between one and two 
user ratings in different catagories, based on 
different aspects of the movie. A total user 
score is then calulated for each user,
weighted based on the overall importance of each
catagory, then a movie total score is created 
from the avarage of these scores.


# Project structure breakdown

## User interface : navigation
The application consists of one window, `MainWindow`  
which contains a frame that displays one of the two pages,
`MovieListViewPage` or `DetailedViewPage`. <br/>
Navigation between these pages is handled by binding the 
frames uri to a property on the singelton `MainWindowViewModel`, 
`MainFrameDisplayUri`. The viewModel will default this property
to return the movieList view, and `ICommand` properties on the 
viewModel delegate to private helper methods that change the value 
of the field `_mainFrameDisplayUri` to the URI's of other views.<br/>
<br/>
Handling navigation this way presented the problem of getting an instance
of the correct viewModel for each page from the serviceHost(`AppHost`) 
this issue was annoyibg to solve, since all other viewModels should be 
trainsent. <br/>
To solve this, `ViewModelLocator` has been added as 
a application resource in `App.xaml`, each pages dataContext is bound
to a static property of this class, that returns an instance of the 
required viewModel from `AppHost`. While this approach has its issues,
I have been unable to find a different approach that works as well thus far. <br/>
<br/>
Its also worth mentioning that `MainWindowViewModel` contains the propery 
`SelectedModel` which is bound to the selected entry of `MoveListViewPage`'s 
data grid. This is for the purpose of passing said selected entry to  
`DetailedViewPage`, as the state of this property is used to determine 
if the page shoudld be loaded in edit mode (with the other tables realted to 
the movie loaded from the database), or in new entry mode (with 
fresh default models loaded). <br/>
<br/>
