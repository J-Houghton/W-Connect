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

namespace W_Connect
{
    /// <summary>
    /// Interaction logic for StrimmerUserControl.xaml
    /// </summary>
    public partial class StrimmerUserControl : UserControl
    {
        public Controller ControllerInstance { get; set; }
        public StrimmerUserControl()
        {
            InitializeComponent();
        }
        public void RefreshData()
        {
            RoadsComboBox.ItemsSource = ControllerInstance.EffectDataDictionary.Keys;
        }
    }
}
