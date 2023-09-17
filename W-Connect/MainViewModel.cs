using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

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
    }

}
