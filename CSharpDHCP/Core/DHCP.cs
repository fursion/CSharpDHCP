using System;
using System.Net;
using System.Net.Sockets;
namespace CSharpDHCP.Core
{
    public class DHCP
    {
        #region DHCP Events
        public delegate void RDEventHandler(byte[] Data, IPEndPoint ReIPEndPoint);
        public event RDEventHandler DataRD;
        public delegate void ErrEventHandler(string Msg);
        #endregion
        #region DHCP Server Config
        public IPAddress ServerIPAddress;
        public int ClientCount;
        #endregion

        private DHCPUDP _DHCP_LISTEN;
        public void StartDHCPServer()
        {
            _DHCP_LISTEN=new DHCPUDP();
        }
    }

}