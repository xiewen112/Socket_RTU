using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;


namespace Socket_RTU
{
    class Socket_Server
    {
        private string input_ip;
        private int input_port;
        private int listenVol = 10;

        public Socket_Server (string input_ip, int input_port, int listenVol = 10)
        {
            this.input_ip = input_ip;
            this.input_port = input_port;
            this.listenVol = listenVol;
        }

        public Socket ini_socket()
        {
            Socket serverSocket;
            IPAddress ip = IPAddress.Parse(input_ip);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, input_port));
            serverSocket.Listen(listenVol);
            Console.WriteLine("启动监听{0}成功", serverSocket.LocalEndPoint.ToString());

            return serverSocket;

  
            
        }

        public string getIPAddress()
        {
            return input_ip;
        }
        public int getPort()
        {
            return input_port;
        }
        public int getListenVol()
        {
            return listenVol;
        }


    }
}
