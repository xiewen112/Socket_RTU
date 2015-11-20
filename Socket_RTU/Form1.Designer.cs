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
            this.Menu_LogSavePath = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.命令生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解析数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.list_client = new System.Windows.Forms.ListBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_auto = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ckB_IsSaveLog = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Base_container = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_parseDisplay = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Base_container)).BeginInit();
            this.Base_container.Panel1.SuspendLayout();
            this.Base_container.Panel2.SuspendLayout();
            this.Base_container.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务端IP地址:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口:";
            // 
            // server_ip
            // 
            this.server_ip.Location = new System.Drawing.Point(97, 16);
            this.server_ip.Name = "server_ip";
            this.server_ip.Size = new System.Drawing.Size(100, 21);
            this.server_ip.TabIndex = 2;
            this.server_ip.Text = "192.168.1.109";
            // 
            // server_port
            // 
            this.server_port.Location = new System.Drawing.Point(97, 43);
            this.server_port.Name = "server_port";
            this.server_port.Size = new System.Drawing.Size(100, 21);
            this.server_port.TabIndex = 3;
            this.server_port.Text = "2997";
            // 
            // btn_listen
            // 
            this.btn_listen.Location = new System.Drawing.Point(8, 70);
            this.btn_listen.Name = "btn_listen";
            this.btn_listen.Size = new System.Drawing.Size(75, 23);
            this.btn_listen.TabIndex = 4;
            this.btn_listen.Text = "监听";
            this.btn_listen.UseVisualStyleBackColor = true;
            this.btn_listen.Click += new System.EventHandler(this.btn_listen_Click);
            // 
            // txtBox_display
            // 
            this.txtBox_display.Location = new System.Drawing.Point(8, 3);
            this.txtBox_display.Name = "txtBox_display";
            this.txtBox_display.Size = new System.Drawing.Size(448, 320);
            this.txtBox_display.TabIndex = 5;
            this.txtBox_display.Text = "";
            this.txtBox_display.WordWrap = false;
            this.txtBox_display.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.分析ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(776, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.命令管理ToolStripMenuItem,
            this.Menu_LogSavePath});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 命令管理ToolStripMenuItem
            // 
            this.命令管理ToolStripMenuItem.Name = "命令管理ToolStripMenuItem";
            this.命令管理ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.命令管理ToolStripMenuItem.Text = "命令管理";
            this.命令管理ToolStripMenuItem.Click += new System.EventHandler(this.命令管理ToolStripMenuItem_Click);
            // 
            // Menu_LogSavePath
            // 
            this.Menu_LogSavePath.Name = "Menu_LogSavePath";
            this.Menu_LogSavePath.Size = new System.Drawing.Size(152, 22);
            this.Menu_LogSavePath.Text = "日志保存地址";
            this.Menu_LogSavePath.Click += new System.EventHandler(this.Menu_LogSavePath_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.命令生成ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 命令生成ToolStripMenuItem
            // 
            this.命令生成ToolStripMenuItem.Name = "命令生成ToolStripMenuItem";
            this.命令生成ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.命令生成ToolStripMenuItem.Text = "命令生成";
            // 
            // 分析ToolStripMenuItem
            // 
            this.分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.解析数据ToolStripMenuItem,
            this.导出ToolStripMenuItem});
            this.分析ToolStripMenuItem.Name = "分析ToolStripMenuItem";
            this.分析ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.分析ToolStripMenuItem.Text = "分析";
            // 
            // 解析数据ToolStripMenuItem
            // 
            this.解析数据ToolStripMenuItem.Name = "解析数据ToolStripMenuItem";
            this.解析数据ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.解析数据ToolStripMenuItem.Text = "解析数据";
            this.解析数据ToolStripMenuItem.Click += new System.EventHandler(this.解析数据ToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.导出ToolStripMenuItem.Text = "导出";
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
            this.list_client.Location = new System.Drawing.Point(203, 22);
            this.list_client.Name = "list_client";
            this.list_client.Size = new System.Drawing.Size(253, 100);
            this.list_client.TabIndex = 7;
            this.list_client.SelectedIndexChanged += new System.EventHandler(this.list_client_SelectedIndexChanged);
            // 
            // btn_close
            // 
            this.btn_close.Enabled = false;
            this.btn_close.Location = new System.Drawing.Point(97, 70);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 8;
            this.btn_close.Text = "断开";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_auto
            // 
            this.btn_auto.Location = new System.Drawing.Point(8, 99);
            this.btn_auto.Name = "btn_auto";
            this.btn_auto.Size = new System.Drawing.Size(75, 23);
            this.btn_auto.TabIndex = 9;
            this.btn_auto.Text = "自动应答";
            this.btn_auto.UseVisualStyleBackColor = true;
            this.btn_auto.Click += new System.EventHandler(this.btn_auto_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(4, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.ckB_IsSaveLog);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.list_client);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btn_auto);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btn_close);
            this.splitContainer1.Panel1.Controls.Add(this.server_ip);
            this.splitContainer1.Panel1.Controls.Add(this.btn_listen);
            this.splitContainer1.Panel1.Controls.Add(this.server_port);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtBox_display);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(460, 457);
            this.splitContainer1.SplitterDistance = 127;
            this.splitContainer1.TabIndex = 10;
            // 
            // ckB_IsSaveLog
            // 
            this.ckB_IsSaveLog.AutoSize = true;
            this.ckB_IsSaveLog.Location = new System.Drawing.Point(97, 100);
            this.ckB_IsSaveLog.Name = "ckB_IsSaveLog";
            this.ckB_IsSaveLog.Size = new System.Drawing.Size(72, 16);
            this.ckB_IsSaveLog.TabIndex = 12;
            this.ckB_IsSaveLog.Text = "写入日志";
            this.ckB_IsSaveLog.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "当前连接：";
            // 
            // Base_container
            // 
            this.Base_container.IsSplitterFixed = true;
            this.Base_container.Location = new System.Drawing.Point(12, 28);
            this.Base_container.Name = "Base_container";
            // 
            // Base_container.Panel1
            // 
            this.Base_container.Panel1.Controls.Add(this.splitContainer1);
            // 
            // Base_container.Panel2
            // 
            this.Base_container.Panel2.Controls.Add(this.label3);
            this.Base_container.Panel2.Controls.Add(this.txt_parseDisplay);
            this.Base_container.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.Base_container_Panel2_Paint);
            this.Base_container.Size = new System.Drawing.Size(750, 463);
            this.Base_container.SplitterDistance = 463;
            this.Base_container.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "解析数据：";
            // 
            // txt_parseDisplay
            // 
            this.txt_parseDisplay.Location = new System.Drawing.Point(3, 25);
            this.txt_parseDisplay.Name = "txt_parseDisplay";
            this.txt_parseDisplay.Size = new System.Drawing.Size(277, 432);
            this.txt_parseDisplay.TabIndex = 11;
            this.txt_parseDisplay.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 507);
            this.Controls.Add(this.Base_container);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Base_container.Panel1.ResumeLayout(false);
            this.Base_container.Panel2.ResumeLayout(false);
            this.Base_container.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Base_container)).EndInit();
            this.Base_container.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem 分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 解析数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer Base_container;
        private System.Windows.Forms.RichTextBox txt_parseDisplay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 命令生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Menu_LogSavePath;
        private System.Windows.Forms.CheckBox ckB_IsSaveLog;
    }
}

