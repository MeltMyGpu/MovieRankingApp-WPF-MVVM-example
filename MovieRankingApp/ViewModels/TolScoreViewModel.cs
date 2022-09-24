using MovieRankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRankingApp.ViewModels
{
    public class TolScoreViewModel : ObservableObject
    {

        public TolScoreViewModel(TolScore? model = null) => _model = model ?? new TolScore(); 
        private TolScore _model;

        public bool IsModified { get; set; }

        public TolScore Model
        {
            get => _model;
            set
            {
                _model = value;
                RaisePropertyChangedEvent(string.Empty);
            }
        }

        public long ScoreId
        {
            get => _model.ScoreId;
            set
            {
                _model.ScoreId = value;
                RaisePropertyChangedEvent();
                IsModified = true;
            }
        }

        public long MovieId
        {
            get => _model.MovieId;
            set
            {
                _model.MovieId = value;
                RaisePropertyChangedEvent();
                IsModified = true;
            }
        }

        public long ActingScore
        {
            get => _model.ActingScore;
            set
            {
                _model.ActingScore = value;
                RaisePropertyChangedEvent();
                IsModified = true;
            }
        }

        public long CharacterScore
        {
            get => _model.CharacterScore;
            set
            {
                _model.CharacterScore = value;
                RaisePropertyChangedEvent();
                IsModified = true;
            }
        }

        public long CinematographyScore
        {
            get => _model.CinematographyScore;
            set
            {
                _model.CinematographyScore = value;
                RaisePropertyChangedEvent();
                IsModified = true;
            }
        }

        public long EffectScore
        {
            get => _model.VisualEffectsScore;
            set
            {
                _model.VisualEffectsScore = value;
                RaisePropertyChangedEvent();
                IsModified = true;
            }
        }

        public long PlotScore
        {
            get => _model.PlotScore;
            set
            {
                _model.PlotScore = value;
                RaisePropertyChangedEvent();
                IsModified = true;
            }
        }

        public long WorldScore
        {
            get => _model.WorldScore;
            set
            {
                _model.WorldScore = value;
                RaisePropertyChangedEvent();
                IsModified = true;
            }
        }

        public long TotalScore
        {
            get => _model.TotalScore;
            set => _model.TotalScore = (ActingScore + CharacterScore + CinematographyScore + EffectScore + PlotScore + WorldScore);
        }
    }
}
