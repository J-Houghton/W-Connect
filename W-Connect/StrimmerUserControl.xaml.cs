﻿using System;
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
using Xceed.Wpf.Toolkit;
/*if (Checkbox1.IsChecked == true)
{
    string effectNameFromCheckbox = *//* get corresponding name from strimmer based on Checkbox1 *//*;
    SelectEffectInComboBox(effectNameFromCheckbox);
}
else if (Checkbox2.IsChecked == true)
{
    string effectNameFromCheckbox = *//* get corresponding name from strimmer based on Checkbox2 *//*;
    SelectEffectInComboBox(effectNameFromCheckbox);
}
// ... and so on for all your checkboxes*/

namespace W_Connect
{
    /// <summary>
    /// Interaction logic for StrimmerUserControl.xaml
    /// </summary>
    public partial class StrimmerUserControl : UserControl
    {
        private int state = -1;
        public int State
        {
            set
            {
                state = value;
            }
        }
        public List<ColorPicker> colorPickers; 
        public Controller ControllerInstance { get; set; }
        public StrimmerUserControl()
        {
            colorPickers = new List<ColorPicker>
            {
                ColorPicker1, ColorPicker2, ColorPicker3,
                ColorPicker4, ColorPicker5, ColorPicker6
            };
            //ColorPicker1.SelectedColor = Color.FromArgb(255, 0, 0, 255);
            //this.DataContext = ControllerInstance.strimmer;
            InitializeComponent();
        }
        public void RefreshData()
        {
            EffectsComboBox.ItemsSource = ControllerInstance.EffectDataDictionary.Keys;
        }
        public void UpdateColorPickers(int roadNum, int effectNum) //effectNumber = singleMode[0-2] size 3 
        {
            //StrimmerEffect effect = ControllerInstance.EffectDataDictionary["StrimerLightEfferct-" + ControllerInstance.strimmerController.roads[0].singleMode[0].name];
            StrimmerEffect effect = ControllerInstance.strimmerController.roads[roadNum].singleMode[effectNum];
            if (effect != null)
            {
                ColorPicker1.SelectedColor = Color.FromArgb(255, (byte)effect.colors[0][0], (byte)effect.colors[0][1], (byte)effect.colors[0][2]);
                ColorPicker2.SelectedColor = Color.FromArgb(255, (byte)effect.colors[1][0], (byte)effect.colors[1][1], (byte)effect.colors[1][2]);
                ColorPicker3.SelectedColor = Color.FromArgb(255, (byte)effect.colors[2][0], (byte)effect.colors[2][1], (byte)effect.colors[2][2]);
                ColorPicker4.SelectedColor = Color.FromArgb(255, (byte)effect.colors[3][0], (byte)effect.colors[3][1], (byte)effect.colors[3][2]);
                ColorPicker5.SelectedColor = Color.FromArgb(255, (byte)effect.colors[4][0], (byte)effect.colors[4][1], (byte)effect.colors[4][2]);
                ColorPicker6.SelectedColor = Color.FromArgb(255, (byte)effect.colors[5][0], (byte)effect.colors[5][1], (byte)effect.colors[5][2]);
            }
            //ColorPicker1.SelectedColor = Color.FromArgb(255, (byte)ControllerInstance.strimmer.roads[0].singleMode[0].colors[0][0], (byte)ControllerInstance.strimmer.roads[0].singleMode[0].colors[0][1], (byte)ControllerInstance.strimmer.roads[0].singleMode[0].colors[0][2]);
        }

        private void UpdateLightAndColorNumBasedOnRoads(string selectRoad)
        {
            switch(selectRoad)
            {
                case "24":
                    LightToggleCheckBox5.Visibility = Visibility.Visible;
                    LightToggleCheckBox6.Visibility = Visibility.Visible;
                    ColorPicker5.Visibility = Visibility.Visible;
                    ColorPicker6.Visibility = Visibility.Visible;
                    break;
                case "2x8":
                    LightToggleCheckBox5.Visibility = Visibility.Collapsed;
                    LightToggleCheckBox6.Visibility = Visibility.Collapsed;
                    ColorPicker5.Visibility = Visibility.Collapsed;
                    ColorPicker6.Visibility = Visibility.Collapsed;
                    break;
                case "3x8":
                    LightToggleCheckBox5.Visibility = Visibility.Visible;
                    LightToggleCheckBox6.Visibility = Visibility.Visible;
                    ColorPicker5.Visibility = Visibility.Visible;
                    ColorPicker6.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            } 
        }
        private void UpdateColorPickersBasedOnEffect()
        {
            if (ControllerInstance?.EffectDataDictionary == null) return;
            string selectedKey = EffectsComboBox.SelectedItem.ToString();
            if (selectedKey == null) return;

            if (ControllerInstance.EffectDataDictionary.TryGetValue(selectedKey, out StrimmerEffect effect))
            {
                for (int i = 0; i < colorPickers.Count; i++)
                {
                    colorPickers[i].Visibility = (i < effect.colors.Count) ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }

        private void EffectsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //UpdateColorPickersBasedOnEffect();
        }
        private void _24PinButton_Click(object sender, RoutedEventArgs e)
        {
            if (_24Selector.Visibility == Visibility.Collapsed)
            {
                _24Selector.Visibility = Visibility.Visible;
                _2x8Selector.Visibility = Visibility.Collapsed;
                _3x8Selector.Visibility = Visibility.Collapsed;
                state = 0;
                UpdateLightAndColorNumBasedOnRoads("24");
                UpdateColorPickers(0, 0);
            }
            else if (_24Selector.Visibility == Visibility.Visible)
            {
                _24Selector.Visibility = Visibility.Collapsed;
            }
        }
        private void _2x8PinButton_Click(object sender, RoutedEventArgs e)
        {
            if (_2x8Selector.Visibility == Visibility.Collapsed)
            {
                _2x8Selector.Visibility = Visibility.Visible;
                _24Selector.Visibility = Visibility.Collapsed;
                _3x8Selector.Visibility = Visibility.Collapsed;
                state = 1;
                UpdateLightAndColorNumBasedOnRoads("2x8");
                UpdateColorPickers(1, 0);
            }
            else if (_2x8Selector.Visibility == Visibility.Visible)
            {
                _2x8Selector.Visibility = Visibility.Collapsed;
            }
        }
        private void _3x8PinButton_Click(object sender, RoutedEventArgs e)
        {
            if (_3x8Selector.Visibility == Visibility.Collapsed)
            {
                _3x8Selector.Visibility = Visibility.Visible;
                _2x8Selector.Visibility = Visibility.Collapsed;
                _24Selector.Visibility = Visibility.Collapsed;
                state = 2;
                UpdateLightAndColorNumBasedOnRoads("3x8");
                UpdateColorPickers(2, 0);
            }
            else if (_3x8Selector.Visibility == Visibility.Visible)
            {
                _3x8Selector.Visibility = Visibility.Collapsed;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_ControllerCheckbox.IsChecked ?? false == true)
            {
                int r, g, b;

                ControllerInstance.strimmerController.roads[state].singleMode[0].colors[0] = new List<int> { ColorPicker1.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[1].colors[0] = new List<int> { ColorPicker1.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[2].colors[0] = new List<int> { ColorPicker1.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[3].colors[0] = new List<int> { ColorPicker1.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[4].colors[0] = new List<int> { ColorPicker1.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[5].colors[0] = new List<int> { ColorPicker1.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };

                ControllerInstance.strimmerController.roads[state].singleMode[0].colors[1] = new List<int> { ColorPicker2.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[1].colors[1] = new List<int> { ColorPicker2.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[2].colors[1] = new List<int> { ColorPicker2.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[3].colors[1] = new List<int> { ColorPicker2.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[4].colors[1] = new List<int> { ColorPicker2.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[5].colors[1] = new List<int> { ColorPicker2.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };


                ControllerInstance.strimmerController.roads[state].singleMode[0].colors[2] = new List<int> { ColorPicker3.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[1].colors[2] = new List<int> { ColorPicker3.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[2].colors[2] = new List<int> { ColorPicker3.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[3].colors[2] = new List<int> { ColorPicker3.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[4].colors[2] = new List<int> { ColorPicker3.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[5].colors[2] = new List<int> { ColorPicker3.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };

                ControllerInstance.strimmerController.roads[state].singleMode[0].colors[3] = new List<int> { ColorPicker4.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[1].colors[3] = new List<int> { ColorPicker4.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[2].colors[3] = new List<int> { ColorPicker4.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[3].colors[3] = new List<int> { ColorPicker4.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[4].colors[3] = new List<int> { ColorPicker4.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[5].colors[3] = new List<int> { ColorPicker4.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };

                ControllerInstance.strimmerController.roads[state].singleMode[0].colors[4] = new List<int> { ColorPicker5.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[1].colors[4] = new List<int> { ColorPicker5.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[2].colors[4] = new List<int> { ColorPicker5.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[3].colors[4] = new List<int> { ColorPicker5.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[4].colors[4] = new List<int> { ColorPicker5.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[5].colors[4] = new List<int> { ColorPicker5.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };

                ControllerInstance.strimmerController.roads[state].singleMode[0].colors[4] = new List<int> { ColorPicker6.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[1].colors[4] = new List<int> { ColorPicker6.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[2].colors[4] = new List<int> { ColorPicker6.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[3].colors[4] = new List<int> { ColorPicker6.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[4].colors[4] = new List<int> { ColorPicker6.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
                ControllerInstance.strimmerController.roads[state].singleMode[5].colors[4] = new List<int> { ColorPicker6.SelectedColor.Value.R, ColorPicker1.SelectedColor.Value.G, ColorPicker1.SelectedColor.Value.B };
            } 
        }
        private void UpdateCheckedBoxes(CheckBox changedCheckBox)
        {
            // Count the number of checked CheckBox controls in the CheckBoxPanel.
            int checkedCount = CheckBoxPanel.Children.OfType<CheckBox>().Count(cb => cb.IsChecked == true && cb.Visibility == Visibility.Visible);
            
            if (checkedCount > 1)
            {
                if (changedCheckBox.IsChecked == true)
                {
                    string name = changedCheckBox.Name;
                    if (name.Length > 18)
                    {
                        string numberAsString = name.Substring(19);
                        if (int.TryParse(numberAsString, out int number))
                        {
                            if (state != -1)
                            {
                                UpdateColorPickers(state, number - 1);
                            }
                        }
                    }
                }
            }
            else if (checkedCount == 1)
            {
                try
                {
                    CheckBox checkedBox = CheckBoxPanel.Children.OfType<CheckBox>().First(cb => cb.IsChecked == true);
                    string name = checkedBox.Name;
                    if (name.Length > 18)
                    {
                        string numberAsString = name.Substring(19);
                        if (int.TryParse(numberAsString, out int number))
                        {
                            if (state != -1)
                            {
                                UpdateColorPickers(state, number - 1);
                            }
                        }
                    }
                } catch (Exception ex)
                {

                }
                
            }
        }

        private void LightToggleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateCheckedBoxes(sender as CheckBox);
        }

        private void LightToggleCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateCheckedBoxes(sender as CheckBox);
        }
        //fix state, better handle save button click, layout fix, file name, change strimmer effect, combobox, change control, last saved, save chagnes 
    }
}
