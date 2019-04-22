using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel : BaseNotify
    {
        private AutoPilotModel model;
        private string input = "";
        private String backCol;
        private bool allreadySent = false;

        public AutoPilotViewModel()
        {

        }
       

        public String BackCol
        {
            get
            {
                if (input == "" || allreadySent == true)
                {
                    allreadySent = false;
                    backCol = "White";
                }
                else
                {
                    backCol = "Pink";
                }
                return backCol;
            }
            set
            {
                backCol = value;
                NotifyPropertyChanged("color");
            }

        }
        public string Input
        {
            get
            {
                //if (input != "")
                //{
                    NotifyPropertyChanged("BackCol");
                //}
                return input;
            }
            set
            {
                input = value;
                NotifyPropertyChanged("Input");
                NotifyPropertyChanged("BackCol");
                BackCol = "Pink";
            }
        }
        public AutoPilotViewModel(AutoPilotModel model)
        {
            this.model = model;
          
        }
        #region Commands
        #region ClickCommand
        private ICommand _okCommand;
        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            allreadySent = true;
            NotifyPropertyChanged("BackCol");
            string[] lines = input.Split('\n');
            Thread thread = new Thread(() => {
                foreach (var line in lines)
                {
                    Globals.telnetClient.write(line);
                    System.Threading.Thread.Sleep(2000);
                }
            });
            thread.Start();
        }
        #endregion
        #region ClearCommand
        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new CommandHandler(() => OnClear()));
            }
        }
        private void OnClear()
        {
           
            Input = "";
            BackCol = "White";
        }
        #endregion
        #endregion
    }
}
