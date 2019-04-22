using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using FlightSimulator.ViewModels.Windows;
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
using System.Windows.Shapes;

namespace FlightSimulator.Views.Windows
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {

        private SettingsWindowViewModel vm;
        public Setting()
        {

            InitializeComponent();
            vm = new SettingsWindowViewModel(new ApplicationSettingsModel());
            this.DataContext = vm;

            
        }
    }
}
