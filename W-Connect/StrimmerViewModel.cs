using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace W_Connect
{
    public class StrimmerViewModel : INotifyPropertyChanged
    {
        public Controller MainController { get; set; }
        public StrimmerController Controller { get; set; }

        private Road _selectedRoad;
        public Road SelectedRoad
        {
            get { return _selectedRoad; }
            set
            {
                _selectedRoad = value;
                OnPropertyChanged();
            }
        }

        //... Similarly, for selected StrimmerEffect and other properties.

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
