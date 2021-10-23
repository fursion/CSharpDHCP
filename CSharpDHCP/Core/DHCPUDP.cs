using System;
using System.Net;
using System.Net.Sockets;
namespace CSharpDHCP.Core
{
    public class DHCPUDP
    {

        /// <summary>
        /// 服务端DHCP协议监听端口
        /// </summary>
        private const int _LISTEN_SERVER_PORT = 67;
        /// <summary>
        /// 服务端DHCP回复端口
        /// </summary>
        private const int _LISTEN_CLIENT_PORT = 68;
        private UdpClient _LISTEN;
        public UDPState uDPState;
        public DHCPUDP()
        {
            try
            {
                IPAddress iPAddress = IPAddress.Parse("0.0.0.0");
                var serverIPEndPoint = new IPEndPoint(iPAddress, _LISTEN_SERVER_PORT);
                _LISTEN = new UdpClient(serverIPEndPoint);
                uDPState = new UDPState()
                {
                    endPoint = serverIPEndPoint,
                    udpClient = _LISTEN
                };
                StartListening();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

        }
        public void StartListening()
        {
                try
                {
                    uDPState.udpClient.BeginReceive(ReceiveData, uDPState);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                } 
        }
        public void ReceiveData(IAsyncResult ar)
        {
            IPEndPoint endPoint;
            try
            {
                if (ar == null)
                    return;
                UDPState udps = (UDPState)ar.AsyncState;
                UdpClient udp = udps.udpClient;
                endPoint = udps.endPoint;
                Byte[] receivebyte = udp.EndReceive(ar, ref endPoint);
                System.Console.WriteLine(receivebyte);
                print(receivebyte);
                udp.BeginReceive(ReceiveData, uDPState);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

        }
        private void print(byte[] bs){
            
            string s="";
            foreach(var item in bs){
                s=s+$" {item}";
            }
            System.Console.WriteLine(s);
        }
        public void StopListen()
        {

        }
        /// <summary>
        /// 计算可用的IP地址
        /// </summary>
        public void ComputeIPAddress()
        {

        }
        public struct UDPState
        {
            public IPEndPoint endPoint;
            public UdpClient udpClient;
        }
    }
}

