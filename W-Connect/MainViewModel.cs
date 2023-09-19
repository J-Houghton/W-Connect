using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;

namespace W_Connect
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Visibility _fanLightVisibility = Visibility.Collapsed;
        private Visibility _strimmerVisibility = Visibility.Collapsed;

        public Visibility FanLightVisibility
        {
            get { return _fanLightVisibility; }
            set
            {
                if (_fanLightVisibility != value)
                {
                    _fanLightVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        public Visibility StrimmerVisibility
        {
            get { return _strimmerVisibility; }
            set
            {
                if (_strimmerVisibility != value)
                {
                    _strimmerVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ShowFanLightCommand => new RelayCommand(ShowFanLight);
        public ICommand ShowStrimmerCommand => new RelayCommand(ShowStrimmer);

        private void ShowFanLight()
        {
            FanLightVisibility = Visibility.Visible;
            StrimmerVisibility = Visibility.Collapsed;
        }

        private void ShowStrimmer()
        {
            FanLightVisibility = Visibility.Collapsed;
            StrimmerVisibility = Visibility.Visible;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /*private StrimmerController _strimmer;
        private int _roadIndex;
        private int _singleModeIndex;

        public StrimmerController Strimmer
        {
            get => _strimmer;
            set
            {
                _strimmer = value;
                OnPropertyChanged();
            }
        }

        public int RoadIndex
        {
            get => _roadIndex;
            set
            {
                _roadIndex = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentColors));  // Notify that the current colors might have changed.
            }
        }

        public int SingleModeIndex
        {
            get => _singleModeIndex;
            set
            {
                _singleModeIndex = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentColors));  // Notify that the current colors might have changed.
            }
        }

        private List<Color> _currentColors;
        public List<Color> CurrentColors
        {
            get
            {
                if (_strimmer == null) return new List<Color>();

                return _strimmer.roads[_roadIndex].singleMode[_singleModeIndex].colors
                    .Select(rgbList => Color.FromArgb(255, (byte)rgbList[0], (byte)rgbList[1], (byte)rgbList[2]))
                    .ToList();
            }
            set
            {
                if (value != _currentColors)
                {
                    _currentColors = value;
                    OnPropertyChanged(nameof(CurrentColors));
                }
            }
        }

        public void UpdateColor(int colorIndex, List<int> newRgb)
        {
            if (colorIndex >= 0 && colorIndex < CurrentColors.Count)
            {
                _strimmer.roads[_roadIndex].singleMode[_singleModeIndex].colors[colorIndex] = newRgb;
                OnPropertyChanged(nameof(CurrentColors));
            }
        }
        public void RefreshColors()
        {
            OnPropertyChanged(nameof(CurrentColors));
        }*/
    }

}
