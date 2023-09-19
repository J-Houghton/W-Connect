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
using Xceed.Wpf.Toolkit;

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

        private void SetColor(Color? c, byte red, byte green, byte blue)
        {
            c = Color.FromArgb(255, red, green, blue);
        }

        private void OnMenuUserDataImported(object sender, EventArgs e)
        {
            strimmerUserControlInstance.RefreshData();

            strimmerUserControlInstance._24Selector.Visibility = Visibility.Visible;

            strimmerUserControlInstance.LightToggleCheckBox1.IsChecked = true;
            strimmerUserControlInstance.LightToggleCheckBox2.IsChecked = true;
            strimmerUserControlInstance.LightToggleCheckBox3.IsChecked = true;
            strimmerUserControlInstance.LightToggleCheckBox4.IsChecked = true;
            strimmerUserControlInstance.LightToggleCheckBox5.IsChecked = true;
            strimmerUserControlInstance.LightToggleCheckBox6.IsChecked = true;

            string effectToSelect = strimmerUserControlInstance.ControllerInstance.strimmerController.roads[0].singleMode[0].name;
            foreach (var item in strimmerUserControlInstance.EffectsComboBox.Items)
            {
                if (item.ToString().Contains(effectToSelect))
                {
                    strimmerUserControlInstance.EffectsComboBox.SelectedItem = item;
                    break;
                }
            }
            strimmerUserControlInstance.UpdateColorPickers();
            //(DataContext as MainViewModel)?.RefreshColors();
            int colorsCount = strimmerUserControlInstance.ControllerInstance.strimmerController.roads[0].singleMode[0].colors.Count;
            /*strimmerUserControlInstance.ColorPicker1.SelectedColor = Color.FromArgb(255, (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[0][0], (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[0][1], (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[0][2]);
            strimmerUserControlInstance.ColorPicker2.SelectedColor = Color.FromArgb(255, (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[1][0], (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[1][1], (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[1][2]);
            strimmerUserControlInstance.ColorPicker3.SelectedColor = Color.FromArgb(255, (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[2][0], (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[2][1], (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[2][2]);
            strimmerUserControlInstance.ColorPicker4.SelectedColor = Color.FromArgb(255, (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[3][0], (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[3][1], (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[3][2]);
            strimmerUserControlInstance.ColorPicker5.SelectedColor = Color.FromArgb(255, (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[4][0], (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[4][1], (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[4][2]);
            strimmerUserControlInstance.ColorPicker6.SelectedColor = Color.FromArgb(255, (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[5][0], (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[5][1], (byte)strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors[5][2]);*/

            /*
                        foreach (List<int> rgb in strimmerUserControlInstance.ControllerInstance.strimmer.roads[0].singleMode[0].colors)
                        {
                            if (colorsCount >= 0)
                            {
                                strimmerUserControlInstance.colorPickers[colorsCount - 1].SelectedColor = Color.FromArgb(255, (byte)rgb[0], (byte)rgb[1], (byte)rgb[2]);
                            }
                            colorsCount--;
                        }*/


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
