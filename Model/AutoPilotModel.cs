using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class AutoPilotModel
    {
        private ConsoleColor backgroud;
        public ConsoleColor BackgroundCol
        {
            get { return backgroud; }
            set { backgroud = value; }
        }
        public AutoPilotModel()
        {
            backgroud = ConsoleColor.Red;
        }
    }
}
