using FlightSimulator.Model;
using FlightSimulator.Model.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class ManualViewModel: BaseNotify
    {
        private VirtualJoystickEventArgs model;
        private string rudder;
        private string throttle;
        private double aileron;
        private double elevator;

        public ManualViewModel(VirtualJoystickEventArgs mod)
        {
            this.model = mod;
        }

        public double Aileron { get
            {
                return model.Aileron;
            }
            set
            {
                this.aileron = value;
                this.model.Aileron = value;
                NotifyPropertyChanged("Aileron");
                if (Globals.connected)
                {
                    string command;
                    command = "set controls/flight/aileron " + value;
                    
                    Globals.telnetClient.write(command);
                }
            }
        }
        public double Elevator { get {
                return model.Elevator;
            }
            set
            {
                this.elevator = value;
                this.model.Elevator = value;
                NotifyPropertyChanged("Elevator");

                string command;
                command = "set controls/flight/elevator " + value;
                if (Globals.connected)
                {
                    Globals.telnetClient.write(command);

                }
            }
        }
        public string Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
               
                rudder = value.ToString();
                NotifyPropertyChanged("rudder");

                string command;
                command = "set controls/flight/rudder " + rudder;
                if (Globals.connected)
                {
                    Globals.telnetClient.write(command);
                }

            }
        }
        public string Throttle
        {
            get
            {
                return throttle;
            }
            set
            {

                throttle = value.ToString();
                NotifyPropertyChanged("throttle");

                string command;
                command = "set controls/flight/throttle " +throttle;
                if (Globals.connected)
                {
                    Globals.telnetClient.write(command);
                }
            }
        }
      
    }
}
