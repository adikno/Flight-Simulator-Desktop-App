using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.EventArgs
{
    public class VirtualJoystickEventArgs : INotifyPropertyChanged
    {

        private double aileron;
        private double elevator;
        public event PropertyChangedEventHandler PropertyChanged;

        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = value;
                NotifyPropertyChanged("Aileron");
            }
        }
        public double Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                elevator= value;
                NotifyPropertyChanged("Elevator");
            }
        }

        private void NotifyPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
