using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    /*
     * This class holds the client
     */
    public static class Globals
    {
        //public static ITelnetClient telnetClient = new ConnectTelnetClient();
        #region Singleton
        private static ITelnetClient m_telnetClient = null;
        public static ITelnetClient telnetClient
        {
            get
            {
                if (m_telnetClient == null)
                {
                    m_telnetClient = new ConnectTelnetClient();
                }
                return m_telnetClient;
            }
        }
        #endregion
    }
}