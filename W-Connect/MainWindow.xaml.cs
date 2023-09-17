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
using System.IO;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Data.Entity.Core.Common.CommandTrees;

namespace W_Connect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;
        private StrimmerViewModel viewModel;
        public MainWindow()
        {
            controller = new Controller();
//            this.SizeChanged += OnWindowSizeChanged;
            InitializeComponent();
            viewModel = new StrimmerViewModel { MainController = controller };
            this.DataContext = viewModel;
        }
        private void RoadsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRoad = RoadsComboBox.SelectedItem as Road;
            if (selectedRoad != null)
            {
                foreach (var effect in selectedRoad.singleMode)
                {
                    for (int i = 0; i < effect.colors.Count; i++)
                    {
                        var rgbInput = new TextBox { Name = $"RGBInput{i}", Width = 100, Height = 25 };
                        StrimmerPanel.Children.Add(rgbInput);
                    }
                }
            }
        }
        /*        protected void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
                {
                    sizeLabel.Content = "New Height: " + e.NewSize.Height + "New Width: " +e.NewSize.Width + "Old Height: " + e.PreviousSize.Height + "Old Width: " + e.PreviousSize.Width;
                    double newWindowHeight = e.NewSize.Height;
                    double newWindowWidth = e.NewSize.Width;
                    double prevWindowHeight = e.PreviousSize.Height;
                    double prevWindowWidth = e.PreviousSize.Width;
                }*/

        private void FanLightsButton_Click(object sender, RoutedEventArgs e)
        {
            FanLightsPanel.Visibility = Visibility.Visible;
            StrimmerPanel.Visibility = Visibility.Collapsed;
        }

        private void StrimmerButton_Click(object sender, RoutedEventArgs e)
        {
            FanLightsPanel.Visibility = Visibility.Collapsed;
            StrimmerPanel.Visibility = Visibility.Visible;
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Backup files (*.backup)|*.backup"; // Filter to show only .backup files

            if (openFileDialog.ShowDialog() == true)
            {
                TextBlock textBlock = (TextBlock)fileNameLabel.Content;
                textBlock.Text = openFileDialog.FileName;

                if (System.IO.Path.GetExtension(openFileDialog.FileName).ToLower() == ".backup")
                {
                    string baseFileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);

                    // Concatenate "WConnect" to the file name
                    string newFileName = baseFileName + "WConnect.sqlite";

                    string directoryPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                    string newFilePath = System.IO.Path.Combine(directoryPath, newFileName);

                    // Check if file already exists. If yes, you can decide to overwrite or skip.
                    if (File.Exists(newFilePath))
                    {
                        MessageBox.Show("A file with the name " + newFileName + " already exists. Overwriting it.");
                        File.Delete(newFilePath);
                    }
                    // Copy the .backup file to the new .sqlite file
                    File.Copy(openFileDialog.FileName, newFilePath);
                    controller.SqliteFilePath = newFilePath;
                    controller.ImportData();
                    viewModel.MainController = controller;
                    RoadsComboBox.Items.Refresh();
                    string x = "";
                    // If you want to move instead of copying, you can use:
                    // File.Move(openFileDialog.FileName, newFilePath);
                }
                else
                {
                    MessageBox.Show("Selected file is not a valid .backup file.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

       

    }
}
