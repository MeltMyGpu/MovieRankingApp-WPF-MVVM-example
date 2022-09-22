﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieRankingApp.ViewModels
{
    public class DelegateCommand : ICommand 
    {
        public event EventHandler? CanExecuteChanged;

        public readonly Action _action;
        public DelegateCommand(Action action) => _action = action;

        public bool CanExecute(object? parameter) //Implement properly
        {
            return true;
        }

        public void Execute(object? parameter) => _action();

    }
}
