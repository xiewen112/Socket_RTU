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

        //command
        private string cmd_query;
        private string cmd_logout;

        //setting window
        private setting s_form;

        public Form1()
        {
            InitializeComponent();
            
            
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

            }
            catch (Exception ex)
            {
                txtBox_display.Text = ex.Message.ToString() + "\r\n";
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void WatchConnection()
        {
            while (true)
            {
                //wait for Client connect
                ClientSocket[ClientNumb] = socketserver.Accept();
                //ClientSocket[ClientNumb].BeginReceive(MsgBuffer, 0,
                //                                       MsgBuffer.Length,
                //                                       SocketFlags.None,
                //                                       new AsyncCallback(ReceiveCallback), 
                //                                       ClientSocket[ClientNumb]
                //                                       );
                this.Invoke((MethodInvoker)delegate
                {
                    lock(this.list_client)
                    this.list_client.BeginUpdate();
                    this.list_client.Items.Add("客户端连接成功");
                    this.list_client.EndUpdate();
                });
                Thread thread = new Thread(new ParameterizedThreadStart(ServerRecMsg));
                thread.IsBackground = true;
                thread.Start(ClientSocket[ClientNumb]);
                ClientNumb++;
            }
        }
        private void ServerRecMsg(object socketClientPara)
        {
            Socket RT_socketServer = socketClientPara as Socket;
            try
            {
                while (true)
                {
                    byte[] arrServerRecMsg = new byte[1024 * 1024];
                    int length = RT_socketServer.Receive(arrServerRecMsg);
                    string strSRecMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, length);
                    if(strSRecMsg.Length > 0)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.txtBox_display.Text += "Client-->：" + strSRecMsg + "\r\n";
                        });

                        if (btn_auto.Text == "停止")
                        {
                            
                           autoSendCmd(RT_socketServer, strSRecMsg);

                        }
                        else if (btn_auto.Text == "自动收发")
                        {
                           

                        }
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.txtBox_display.Text += "Client disconnected" + strSRecMsg + "\r\n";
                        });
                    }

                   // byte[] arrSendMsg = Encoding.UTF8.GetBytes("Hello client");
                   // RT_socketServer.Send(arrSendMsg);

                  
                    


                }
            }catch(System.Exception ex)
            {

            }

        }

        private void autoSendCmd(object socket_a, string rcvMsg)
        {
            Socket socketServer = socket_a as Socket;
            String rcv_login_Status = rcvMsg.Substring(rcvMsg.Length - 10, 4);
            String rtu_empty_flag = "680700070068E0111111122104B416";
            byte[] SendMsg_Query = Encoding.UTF8.GetBytes(CmdData.cmd_query);
            byte[] SendMsg_Logout = Encoding.UTF8.GetBytes(CmdData.cmd_logout);

            //Console.WriteLine("{0} 截取字符", rcv_login_Status);

            ////judge the RTU login string
            //if (rcv_login_Status == "637E")
            //{
                //socketServer.Send(SendMsg_Query);
                //this.Invoke((MethodInvoker)delegate
                //{
                //    this.txtBox_display.Text += "Client<--：" + CmdData.cmd_query + "\r\n";
                //});
           // }
            //else if(rcvMsg != rtu_empty_flag)
            //{
            //    socketServer.Send(SendMsg_Query);
            //    this.Invoke((MethodInvoker)delegate
            //    {
            //        this.txtBox_display.Text += "Client<--：" + CmdData.cmd_query + "\r\n";
            //    });
            //}else if(rcvMsg == rtu_empty_flag)
            //{
            //    socketServer.Send(SendMsg_Logout);
            //    this.Invoke((MethodInvoker)delegate
            //    {
            //        this.txtBox_display.Text += "Client<--：" + CmdData.cmd_logout + "\r\n";
            //    });
            //}


        }

        private void 命令管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(s_form == null)
            {
                s_form = new setting();
                s_form.Show();
            }
            else
            {
                s_form.Activate();
            }
             
        }

        private void btn_auto_Click(object sender, EventArgs e)
        {
            if(btn_auto.Text == "自动收发")
            {
                btn_auto.Text = "停止";

            }else if(btn_auto.Text == "停止")
            {
                btn_auto.Text = "自动收发";

            }
            //Socket sockrev = null;
            //int client_index;
            //if (list_client.Items.Count > 0 && list_client.SelectedIndices[0] >= 0)
            //{
            //    client_index = list_client.SelectedIndices[0];
            //    if (CmdData.cmd_query != null && CmdData.cmd_logout != null)
            //    {
            //        if (ClientSocket[client_index] != null)
            //        {
            //            sockrev = ClientSocket[ClientNumb - 1];
            //            byte[] arrsServerSendMsg = Encoding.UTF8.GetBytes(CmdData.cmd_query);
            //            //发送数据
            //            sockrev.Send(arrsServerSendMsg);
            //            this.txtBox_display.Text += "Client<--" + CmdData.cmd_query + "\r\n";
            //        }
            //        else
            //        {
            //            txtBox_display.Text += "用户连接失效\r\n";

            //        }
            //    }
            //    else
            //    {
            //        txtBox_display.Text += "发送指令未配置，请配置指令\r\n";
            //    }
            //}
            //else
            //{
            //    this.txtBox_display.Text += "用户连接失效\r\n";
            //}
        }
    }
}
