using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Socket_RTU
{
    public partial class Form1 : Form
    {
        //socket
        private static Socket socketserver;
        private IPEndPoint ServerInfo;//存放服务器的IP和端口信息
        private Thread thread = null;
        private Socket[] ClientSocket;//为客户端建立的SOCKET连接
        private int ClientNumb;//存放客户端数量
        private byte[] MsgBuffer;//存放消息数据
        private int trySend = 0;

        //command
        private string cmd_query;
        private string cmd_logout;

        //setting window
        private setting s_form;

        public Form1()
        {
            InitializeComponent();
            IP_info ip = new IP_info();
            this.server_ip.Text = ip.IPAddress;
            this.server_port.Text = ip.IP_Port.ToString();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_listen_Click(object sender, EventArgs e)
        {
            try { 

                Socket_Server setSocket = new Socket_Server(server_ip.Text.ToString(), Convert.ToInt32(server_port.Text));
                socketserver = setSocket.ini_socket();
                this.txtBox_display.Text += "监听端口成功 \r\n";
                ClientSocket = new Socket[65535];
                //MsgBuffer = new byte[65535];
                ClientNumb = 0;

                //start a new thread for recieve
                thread = new Thread(new ThreadStart(WatchConnection));
                thread.Start();
                this.btn_close.Enabled = true;
                this.btn_listen.Enabled = false;

            }
            catch (Exception ex)
            {
                if(socketserver != null)
                {
                    socketserver.Close();
                }
                this.btn_listen.Enabled = true;
                this.btn_close.Enabled = false;
                txtBox_display.Text += ex.Message.ToString() + "\r\n";
                Console.WriteLine(ex.Message.ToString());

            }
        }

        private void WatchConnection()
        {
            while (true)
            {
                try
                {
                    //wait for Client connect
                    ClientSocket[ClientNumb] = socketserver.Accept();


                    Thread thread = new Thread(new ParameterizedThreadStart(ServerRecMsg));
                    thread.IsBackground = true;
                    thread.Start(ClientSocket[ClientNumb]);
                    ClientNumb++;

                }catch(System.Exception ex)
                {
                    stop_socket();
                    Console.WriteLine("{0}",ex);
                    break;
                }
                
                
              
            }
        }
        private void ServerRecMsg(object socketClientPara)
        {
            Socket RT_socketServer = socketClientPara as Socket;
            IPEndPoint clientipe = (IPEndPoint)RT_socketServer.RemoteEndPoint;
            int list_index = 0;
            trySend = 0;
            string client_ip_port = clientipe.Address.ToString() + ":" + clientipe.Port.ToString();
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.txtBox_display.Text += "------------- " + DateTime.Now.ToString() + " -------------" + "\r\n";
                    lock (this.list_client)
                    this.list_client.BeginUpdate();
                    list_index = this.list_client.Items.Add(client_ip_port);
                    this.list_client.EndUpdate();
                });
                while (true)
                {
                    byte[] arrServerRecMsg = new byte[1024 * 1024];
                    int length = RT_socketServer.Receive(arrServerRecMsg);
                    string strSRecMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, length);
                    if(strSRecMsg.Length > 0 && RT_socketServer.Connected == true)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            
                            this.txtBox_display.Text += " Client-->" + strSRecMsg + "\r\n";
                        });

                        if (btn_auto.Text == "关闭应答" && strSRecMsg.Length > 10)
                        {
                            
                           autoSendCmd(RT_socketServer, strSRecMsg);

                        }
                        else if (btn_auto.Text == "自动应答")
                        {


                        }
                        

                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.txtBox_display.Text += "Client disconnected" + strSRecMsg + "\r\n";
                            lock (this.list_client)
                            this.list_client.BeginUpdate();
                            this.list_client.Items.RemoveAt(list_index);
                            this.list_client.EndUpdate();

                        });
                        Thread.Sleep(500);
                        RT_socketServer.Close();
                        break;
                    }         

                }
            }catch(System.Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    txtBox_display.Text += "ServerRecMsg: " + ex.Message.ToString() + "\r\n";
                    
                    lock (this.list_client)
                    this.list_client.BeginUpdate();
                    this.list_client.Items.RemoveAt(list_index);
                    this.list_client.EndUpdate();
                });
                
                Console.WriteLine(ex.Message.ToString());
            }

        }

        //parse string
        private void autoSendCmd(object socket_a, string rcvMsg)
        {
            try{
                Socket socketsc = socket_a as Socket;
                CmdData cmddata = new CmdData();
                

                RTU_DataParse dataparse = new RTU_DataParse();
                byte[] SendMsg_Query = Encoding.UTF8.GetBytes(cmddata.cmd_generator("QUERY"));
                byte[] SendMsg_Logout = Encoding.UTF8.GetBytes(cmddata.GetCmd_Logout());



                ////judge the RTU login string

                dataparse.ParseData(rcvMsg);
                Thread.Sleep(100);
                if (dataparse.CMD_TYPE == "RTU_LOGIN")
                {
                    //dataparse.CMD_TYPE = "LOGIN_SUCCESS";

                    Console.WriteLine(dataparse.ADDRESS);
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.txtBox_display.Text += "Server-->" + cmddata.GetCmd_Query() + "\r\n";

                        this.txt_parseDisplay.Text += "----------- " + DateTime.Now.ToString() + "----------- " + "\r\n";
                        this.txt_parseDisplay.Text += "编号：" + dataparse.ADDRESS + "\r\n";
                        this.txt_parseDisplay.Text += "系统时间：" + dataparse.RTU_SYS_TIME + "\r\n";
                        this.txt_parseDisplay.Text += "工作状态：" + dataparse.WORK_STATE + "\r\n";
                        this.txt_parseDisplay.Text += "信号强度：" + dataparse.SIGNAL_S + "\r\n";

                    });

                    socketsc.Send(SendMsg_Query);
                }
                else if (dataparse.CMD_TYPE == "RTU_DATA")
                {

                    this.Invoke((MethodInvoker)delegate
                    {
                        this.txtBox_display.Text += "Server-->" + cmddata.GetCmd_Query() + "\r\n";

                        foreach(string str in dataparse.FD_DATA)
                        {
                            this.txt_parseDisplay.Text += "通道" + str.Substring(0,4) + "\r\n";
                            this.txt_parseDisplay.Text += "采集时间:" + dataparse.timeReform(str.Substring(4,12)).ToString() + "\r\n";
                            this.txt_parseDisplay.Text += "数据:" + str.Substring(16) + "\r\n";
                        }
                        
                    });

                    socketsc.Send(SendMsg_Query);
                } else if (dataparse.CMD_TYPE == "RTU_REQUIRE_LOGOUT")
                {
                    trySend++;
                    if (trySend < 4) {
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.txtBox_display.Text += "Server-->" + "RTU主动要求断网" + "\r\n";
                            this.txtBox_display.Text += "Server-->" + "第" + trySend + "尝试重新发送参数" + "\r\n";

                        });
                        socketsc.Send(SendMsg_Query);
                    }

                    
                }

                else if (dataparse.CMD_TYPE == "CMD_ERROR--RTU_DATA_EMPTY")
                {
                    socketsc.Send(SendMsg_Logout);

                    //socketsc.Dispose();
                }
                else if (dataparse.CMD_TYPE == "RTU_LOGOUT")
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.txtBox_display.Text += "-----RTU数据传输完毕-----\r\n";
                        this.txtBox_display.Text += "-----RTU 登出， 断开连接-----\r\n";
                    });
                    //socketsc.Dispose();
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.txtBox_display.Text += "不能识别参数:" + rcvMsg + "\r\n";
                    });
                    
                }

            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.txtBox_display.Text += "AutoSend: " + ex.Message.ToString()+ "\r\n";
                });
            }
            


        }

        private void 命令管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(s_form == null)
            {
                s_form = new setting();
                s_form.Show();
               
            }
            else if (s_form.IsDisposed)
            {
                s_form = new setting();
                s_form.Show();
            }
            else
            {
                s_form.Activate();
                Console.WriteLine("窗口打开 {0}", s_form.ToString());
            }



        }


        private void btn_auto_Click(object sender, EventArgs e)
        {

           // Console.WriteLine("{0}", );

            if(btn_auto.Text == "自动应答")
            {
                btn_auto.Text = "关闭应答";

            }else if(btn_auto.Text == "关闭应答")
            {
                btn_auto.Text = "自动应答";

            }
           
        }
        private void stop_socket()
        {
            socketserver.Close();

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            if (socketserver != null)
            {
               
                byte[] SendMsg_CloseSoc = Encoding.UTF8.GetBytes("Server closed");
                foreach (Socket soc in ClientSocket)
                {
                    if (!soc.Poll(10, SelectMode.SelectRead))
                    {
                        soc.Send(SendMsg_CloseSoc);
                        soc.Disconnect(false);
                        
                    }

                    
                }
                
                socketserver.Close();
                this.btn_listen.Enabled = true;
                this.btn_close.Enabled = false;
                this.txtBox_display.Text += "Socket服务已经关闭 \r\n";
               
                
            }
            else
            {
                this.txtBox_display.Text += "Socket服务未开启 \r\n";
            }

        }

        private void list_client_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 解析数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Base_container_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Menu_LogSavePath_Click(object sender, EventArgs e)
        {
            //选择文件夹
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            MessageBox.Show(fbd.SelectedPath);
        }
    }
}
