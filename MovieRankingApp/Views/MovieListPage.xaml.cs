﻿using Microsoft.EntityFrameworkCore;
using MovieRankingApp.Models;
using MovieRankingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovieRankingApp.Views
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class MovieListPage : Page
    {
        public MovieListPage()
        {
            InitializeComponent();
            //var context = new MovieListViewModel();
            //this.DataContext = context;
            //MovieListDataGrid.ItemsSource = context.movieList;


        }

        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            //context = new MovieRankingDatabaseContext();
            //context.MovieLists.Load();
            //this.DataContext = context.MovieLists.Local;
            //MovieListDataGrid.ItemsSource = context.MovieLists.Local;

        }
    }
}
