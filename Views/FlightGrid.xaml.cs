using FlightSimulator.Model;
using FlightSimulator.ViewModels;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for FlightGrid.xaml
    /// </summary>
    public partial class FlightGrid : UserControl
    {
        private FlightBoardViewModel vm_flightBoard;

        public FlightGrid()
        {
            InitializeComponent();
            vm_flightBoard = new FlightBoardViewModel(new InfoServer());
            this.DataContext = vm_flightBoard;
            vm_flightBoard.PropertyChanged += Vm_PropertyChanged;

        }
        

        public void setVM(FlightBoardViewModel vm_f)
        {
            vm_flightBoard = vm_f;
            
        }
       
        ObservableDataSource<Point> planeLocations = null;

        private void FlightBoard_Loaded(object sender, RoutedEventArgs e)
        {
            planeLocations = new ObservableDataSource<Point>();
            // Set identity mapping of point in collection to point on plot
            planeLocations.SetXYMapping(p => p);

            plotter.AddLineGraph(planeLocations, 2, "Route");
        }

        private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Lat") || e.PropertyName.Equals("Lon"))
            {
                Point p1 = new Point(vm_flightBoard.Lat,vm_flightBoard.Lon); // Fill here!
                planeLocations.AppendAsync(Dispatcher, p1);
            }
        }

    }
}

