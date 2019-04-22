using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        public double Lon
        {
            get { return server.LonModel; }

        }

        public double Lat
        {
            get { return server.LatModel; }
        }
        private InfoServer server;
        public FlightBoardViewModel(InfoServer server1)
        {
            server = server1;
            Globals.telnetClient = new ConnectTelnetClient();
            /*
            server.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "Lat") Lat = server.LatModel;
                else if (e.PropertyName == "Lon") Lon = server.LonModel;
                NotifyPropertyChanged(e.PropertyName);
            };*/

        }
        
        #region Commands
        #region ClickCommand
        private ICommand _settingCommand;
        public ICommand SettingCommand
        {
            get
            {
                return _settingCommand?? (_settingCommand = new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            Window win2 = new Setting();
            win2.Show();
        }
        #endregion

        #region ConnectCommand
        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => OnConnect()));
            }
        }
        private void OnConnect()
        {
            int infoPort = Properties.Settings.Default.FlightInfoPort;
           
            server.Start(infoPort);
          
            string IP = Properties.Settings.Default.FlightServerIP;
            int port = Properties.Settings.Default.FlightCommandPort;
            System.Threading.Thread.Sleep(100000);
            Globals.telnetClient.connect(IP, port);
        }
        #endregion
        #endregion
    }
}
