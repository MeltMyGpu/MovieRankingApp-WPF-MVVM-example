using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieRankingApp.ViewModels
{
    public class DelegateCommand : ICommand
    {
        /*
        This is what commands in the view are bound to.
        TO DO:
        - Implement CanExecute
         */

        private readonly Action Action;

        public event EventHandler? CanExecuteChanged;
        
        public DelegateCommand(Action action)
        {
            Action = action;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Action();
        }
    }
}
