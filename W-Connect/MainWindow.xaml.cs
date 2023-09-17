using Microsoft.Win32;
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

using System.Security.Principal;
using System.Data.Entity.Core.Common.CommandTrees;

namespace W_Connect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller SharedController;

        public MainWindow()
        {
//            controller = new Controller();
//            this.SizeChanged += OnWindowSizeChanged;
            InitializeComponent();
            DataContext = new MainViewModel();
            SharedController = new Controller();
            menuUserControlInstance.ControllerInstance = SharedController;
            strimmerUserControlInstance.ControllerInstance = SharedController;
            fanLightUserControlInstance.ControllerInstance = SharedController;

            menuUserControlInstance.DataImported += OnMenuUserDataImported;
        }
        private void OnMenuUserDataImported(object sender, EventArgs e)
        {
            strimmerUserControlInstance.RefreshData();
            // Refresh any other user controls or take other actions here.
        }
        /*        protected void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
                {
                    sizeLabel.Content = "New Height: " + e.NewSize.Height + "New Width: " +e.NewSize.Width + "Old Height: " + e.PreviousSize.Height + "Old Width: " + e.PreviousSize.Width;
                    double newWindowHeight = e.NewSize.Height;
                    double newWindowWidth = e.NewSize.Width;
                    double prevWindowHeight = e.PreviousSize.Height;
                    double prevWindowWidth = e.PreviousSize.Width;
                }*/







    }
}
