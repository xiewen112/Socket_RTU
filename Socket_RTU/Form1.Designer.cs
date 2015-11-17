namespace Socket_RTU
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.server_ip = new System.Windows.Forms.TextBox();
            this.server_port = new System.Windows.Forms.TextBox();
            this.btn_listen = new System.Windows.Forms.Button();
            this.txtBox_display = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.命令管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.list_client = new System.Windows.Forms.ListBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_auto = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务端IP地址:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口:";
            // 
            // server_ip
            // 
            IP_info ipaddress = new IP_info();
            this.server_ip.Location = new System.Drawing.Point(101, 40);
            this.server_ip.Name = "server_ip";
            this.server_ip.Size = new System.Drawing.Size(100, 21);
            this.server_ip.TabIndex = 2;
            this.server_ip.Text = ipaddress.IPAddress;
            // 
            // server_port
            // 
            this.server_port.Location = new System.Drawing.Point(101, 70);
            this.server_port.Name = "server_port";
            this.server_port.Size = new System.Drawing.Size(100, 21);
            this.server_port.TabIndex = 3;
            this.server_port.Text = ipaddress.IP_Port.ToString();
            // 
            // btn_listen
            // 
            this.btn_listen.Location = new System.Drawing.Point(45, 97);
            this.btn_listen.Name = "btn_listen";
            this.btn_listen.Size = new System.Drawing.Size(75, 23);
            this.btn_listen.TabIndex = 4;
            this.btn_listen.Text = "监听";
            this.btn_listen.UseVisualStyleBackColor = true;
            this.btn_listen.Click += new System.EventHandler(this.btn_listen_Click);
            // 
            // txtBox_display
            // 
            this.txtBox_display.Location = new System.Drawing.Point(14, 227);
            this.txtBox_display.Name = "txtBox_display";
            this.txtBox_display.Size = new System.Drawing.Size(468, 211);
            this.txtBox_display.TabIndex = 5;
            this.txtBox_display.Text = "";
            this.txtBox_display.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(502, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.命令管理ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 命令管理ToolStripMenuItem
            // 
            this.命令管理ToolStripMenuItem.Name = "命令管理ToolStripMenuItem";
            this.命令管理ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.命令管理ToolStripMenuItem.Text = "命令管理";
            this.命令管理ToolStripMenuItem.Click += new System.EventHandler(this.命令管理ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // list_client
            // 
            this.list_client.FormattingEnabled = true;
            this.list_client.ItemHeight = 12;
            this.list_client.Location = new System.Drawing.Point(207, 28);
            this.list_client.Name = "list_client";
            this.list_client.Size = new System.Drawing.Size(263, 88);
            this.list_client.TabIndex = 7;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(126, 97);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 8;
            this.btn_close.Text = "断开";
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // btn_auto
            // 
            this.btn_auto.Location = new System.Drawing.Point(45, 143);
            this.btn_auto.Name = "btn_auto";
            this.btn_auto.Size = new System.Drawing.Size(75, 23);
            this.btn_auto.TabIndex = 9;
            this.btn_auto.Text = "自动收发";
            this.btn_auto.UseVisualStyleBackColor = true;
            this.btn_auto.Click += new System.EventHandler(this.btn_auto_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 462);
            this.Controls.Add(this.btn_auto);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.list_client);
            this.Controls.Add(this.txtBox_display);
            this.Controls.Add(this.btn_listen);
            this.Controls.Add(this.server_port);
            this.Controls.Add(this.server_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox server_ip;
        private System.Windows.Forms.TextBox server_port;
        private System.Windows.Forms.Button btn_listen;
        private System.Windows.Forms.RichTextBox txtBox_display;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 命令管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ListBox list_client;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_auto;
    }
}

