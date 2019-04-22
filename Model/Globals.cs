using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public static class Globals
    {
        public static ITelnetClient telnetClient = new ConnectTelnetClient();
        public static Boolean connected = false;


    }
}
