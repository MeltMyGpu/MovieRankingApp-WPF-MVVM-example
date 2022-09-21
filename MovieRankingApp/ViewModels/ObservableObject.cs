using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRankingApp.ViewModels
{
    // All view models bound to the view should implement this, even if the values dont change 
    // from the viewmodel.
    // This allows updated messages to be passed to the view.

    // TO DO:
    // could be expanded to ensure property name exists for the given class.

    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        // only requirement of the interface.

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
