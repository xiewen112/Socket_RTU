﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socket_RTU
{
    
    public partial class setting : Form
    {

        public setting()
        {
            InitializeComponent();
        }

        private void setting_Load(object sender, EventArgs e)
        {


        }

        private void rtu_cmdQuery_TextChanged(object sender, EventArgs e)
        {
        

        }

        private void rtu_cmdLogout_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            CmdData.cmd_query = rtu_cmdQuery.Text.ToString();
            CmdData.cmd_logout = rtu_cmdLogout.Text.ToString();
            Close();
        }
    }
}
