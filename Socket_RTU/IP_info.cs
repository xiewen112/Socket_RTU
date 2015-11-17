using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Management;
using System.Runtime.InteropServices;


namespace Socket_RTU
{
    class IP_info
    {
        private string myip;
        private int myport = 2997;
        private void GetIP_info()
        {
            //string hostName = Dns.GetHostName();//本机名               
            //addressList = Dns.GetHostAddresses(hostName);//会返回所有地址，包括IPv4和IPv6  
            myip = null; 
            IPHostEntry IpEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress ip in IpEntry.AddressList)
            {
                if(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    myip = ip.ToString();
                    break;
                }
            }

            
        }
        public string IPAddress
        {
            get
            {
                GetIP_info();
                return myip;
            }
        }

        public int IP_Port
        {
            get
            {
                return myport;
            }
        }
    }
}
