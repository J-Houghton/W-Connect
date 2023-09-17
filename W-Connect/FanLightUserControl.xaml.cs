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
    /// Interaction logic for FanLightUserControl.xaml
    /// </summary>
    public partial class FanLightUserControl : UserControl
    {
        public Controller ControllerInstance { get; set; }

        public FanLightUserControl()
        {
            InitializeComponent();
        }
/*        public void RefreshData()
        {
            FanSettingsComboBox.ItemsSource = ControllerInstance.FanSettings.Keys;
        }*/
    }
}
