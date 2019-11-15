namespace RC403ZhangChenYang
{
    partial class wuziqi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wuziqi));
            this.shubiaoPos = new System.Windows.Forms.GroupBox();
            this.shubiaoY = new System.Windows.Forms.Label();
            this.shubiaoX = new System.Windows.Forms.Label();
            this.wanjiaxinxi = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.baiziplayLabel = new System.Windows.Forms.Label();
            this.heiziplayLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.skinButtom1 = new CCWin.SkinControl.SkinButtom();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.skinButtom2 = new CCWin.SkinControl.SkinButtom();
            this.skinButtom3 = new CCWin.SkinControl.SkinButtom();
            this.Groap = new System.Windows.Forms.PictureBox();
            this.shubiaoPos.SuspendLayout();
            this.wanjiaxinxi.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Groap)).BeginInit();
            this.SuspendLayout();
            // 
            // shubiaoPos
            // 
            this.shubiaoPos.Controls.Add(this.shubiaoY);
            this.shubiaoPos.Controls.Add(this.shubiaoX);
            this.shubiaoPos.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shubiaoPos.Location = new System.Drawing.Point(18, 551);
            this.shubiaoPos.Name = "shubiaoPos";
            this.shubiaoPos.Size = new System.Drawing.Size(183, 91);
            this.shubiaoPos.TabIndex = 1;
            this.shubiaoPos.TabStop = false;
            this.shubiaoPos.Text = "鼠标位置(X：行,Y：列)";
            // 
            // shubiaoY
            // 
            this.shubiaoY.AutoSize = true;
            this.shubiaoY.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shubiaoY.Location = new System.Drawing.Point(17, 61);
            this.shubiaoY.Name = "shubiaoY";
            this.shubiaoY.Size = new System.Drawing.Size(38, 19);
            this.shubiaoY.TabIndex = 1;
            this.shubiaoY.Text = "Y：";
            // 
            // shubiaoX
            // 
            this.shubiaoX.AutoSize = true;
            this.shubiaoX.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shubiaoX.Location = new System.Drawing.Point(17, 26);
            this.shubiaoX.Name = "shubiaoX";
            this.shubiaoX.Size = new System.Drawing.Size(38, 19);
            this.shubiaoX.TabIndex = 0;
            this.shubiaoX.Text = "X：";
            // 
            // wanjiaxinxi
            // 
            this.wanjiaxinxi.Controls.Add(this.radioButton2);
            this.wanjiaxinxi.Controls.Add(this.radioButton1);
            this.wanjiaxinxi.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wanjiaxinxi.Location = new System.Drawing.Point(18, 108);
            this.wanjiaxinxi.Name = "wanjiaxinxi";
            this.wanjiaxinxi.Size = new System.Drawing.Size(183, 91);
            this.wanjiaxinxi.TabIndex = 2;
            this.wanjiaxinxi.TabStop = false;
            this.wanjiaxinxi.Text = "先手信息";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButton2.Location = new System.Drawing.Point(21, 53);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 23);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "电脑";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.ForeColor = System.Drawing.Color.Purple;
            this.radioButton1.Location = new System.Drawing.Point(21, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(65, 23);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "玩家";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.baiziplayLabel);
            this.groupBox1.Controls.Add(this.heiziplayLabel);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(18, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 114);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "玩家信息";
            // 
            // baiziplayLabel
            // 
            this.baiziplayLabel.AutoSize = true;
            this.baiziplayLabel.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baiziplayLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.baiziplayLabel.Location = new System.Drawing.Point(52, 70);
            this.baiziplayLabel.Name = "baiziplayLabel";
            this.baiziplayLabel.Size = new System.Drawing.Size(103, 35);
            this.baiziplayLabel.TabIndex = 3;
            this.baiziplayLabel.Text = ":电脑";
            // 
            // heiziplayLabel
            // 
            this.heiziplayLabel.AutoSize = true;
            this.heiziplayLabel.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.heiziplayLabel.ForeColor = System.Drawing.Color.Purple;
            this.heiziplayLabel.Location = new System.Drawing.Point(52, 20);
            this.heiziplayLabel.Name = "heiziplayLabel";
            this.heiziplayLabel.Size = new System.Drawing.Size(103, 35);
            this.heiziplayLabel.TabIndex = 2;
            this.heiziplayLabel.Text = ":玩家";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RC403ZhangChenYang.Properties.Resources.baiqi;
            this.pictureBox2.Location = new System.Drawing.Point(8, 70);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RC403ZhangChenYang.Properties.Resources.heiqi;
            this.pictureBox1.Location = new System.Drawing.Point(8, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // skinButtom1
            // 
            this.skinButtom1.BackColor = System.Drawing.Color.Transparent;
            this.skinButtom1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButtom1.DownBack = null;
            this.skinButtom1.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButtom1.Location = new System.Drawing.Point(18, 313);
            this.skinButtom1.MouseBack = null;
            this.skinButtom1.Name = "skinButtom1";
            this.skinButtom1.NormlBack = null;
            this.skinButtom1.Size = new System.Drawing.Size(183, 52);
            this.skinButtom1.TabIndex = 4;
            this.skinButtom1.Text = "开 始";
            this.skinButtom1.UseVisualStyleBackColor = false;
            this.skinButtom1.Click += new System.EventHandler(this.skinButtom1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(18, 387);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 164);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "历史记录";
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(5, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(174, 126);
            this.listBox1.TabIndex = 1;
            // 
            // skinButtom2
            // 
            this.skinButtom2.BackColor = System.Drawing.Color.Transparent;
            this.skinButtom2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButtom2.DownBack = null;
            this.skinButtom2.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButtom2.Location = new System.Drawing.Point(15, 77);
            this.skinButtom2.Margin = new System.Windows.Forms.Padding(0);
            this.skinButtom2.MouseBack = null;
            this.skinButtom2.Name = "skinButtom2";
            this.skinButtom2.NormlBack = null;
            this.skinButtom2.Size = new System.Drawing.Size(120, 30);
            this.skinButtom2.TabIndex = 6;
            this.skinButtom2.Text = "重新开始";
            this.skinButtom2.UseVisualStyleBackColor = false;
            this.skinButtom2.Visible = false;
            this.skinButtom2.Click += new System.EventHandler(this.skinButtom2_Click);
            // 
            // skinButtom3
            // 
            this.skinButtom3.BackColor = System.Drawing.Color.Transparent;
            this.skinButtom3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButtom3.DownBack = null;
            this.skinButtom3.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButtom3.Location = new System.Drawing.Point(135, 77);
            this.skinButtom3.Margin = new System.Windows.Forms.Padding(0);
            this.skinButtom3.MouseBack = null;
            this.skinButtom3.Name = "skinButtom3";
            this.skinButtom3.NormlBack = null;
            this.skinButtom3.Size = new System.Drawing.Size(69, 30);
            this.skinButtom3.TabIndex = 7;
            this.skinButtom3.Text = "悔棋";
            this.skinButtom3.UseVisualStyleBackColor = false;
            this.skinButtom3.Visible = false;
            this.skinButtom3.Click += new System.EventHandler(this.skinButtom3_Click);
            // 
            // Groap
            // 
            this.Groap.BackColor = System.Drawing.Color.Tan;
            this.Groap.Location = new System.Drawing.Point(207, 108);
            this.Groap.Margin = new System.Windows.Forms.Padding(0);
            this.Groap.Name = "Groap";
            this.Groap.Size = new System.Drawing.Size(537, 535);
            this.Groap.TabIndex = 0;
            this.Groap.TabStop = false;
            this.Groap.Paint += new System.Windows.Forms.PaintEventHandler(this.Groap_Paint);
            this.Groap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Groap_MouseDown);
            this.Groap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Groap_MouseMove);
            // 
            // wuziqi
            // 
            this.BackColor = System.Drawing.Color.Tan;
            this.BackgroundImage = global::RC403ZhangChenYang.Properties.Resources.wuzhiqi;
            this.ClientSize = new System.Drawing.Size(758, 645);
            this.CloseDownBack = global::RC403ZhangChenYang.Properties.Resources.btn_close_down;
            this.CloseMouseBack = global::RC403ZhangChenYang.Properties.Resources.btn_close_highlight;
            this.CloseNormlBack = global::RC403ZhangChenYang.Properties.Resources.btn_close_disable;
            this.Controls.Add(this.skinButtom3);
            this.Controls.Add(this.skinButtom2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.skinButtom1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.wanjiaxinxi);
            this.Controls.Add(this.shubiaoPos);
            this.Controls.Add(this.Groap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaxDownBack = global::RC403ZhangChenYang.Properties.Resources.btn_max_down;
            this.MaximumSize = new System.Drawing.Size(1024, 645);
            this.MaxMouseBack = global::RC403ZhangChenYang.Properties.Resources.btn_max_highlight;
            this.MaxNormlBack = global::RC403ZhangChenYang.Properties.Resources.btn_max_normal;
            this.MiniDownBack = global::RC403ZhangChenYang.Properties.Resources.btn_mini_down;
            this.MiniMouseBack = global::RC403ZhangChenYang.Properties.Resources.btn_mini_highlight;
            this.MinimumSize = new System.Drawing.Size(758, 645);
            this.MiniNormlBack = global::RC403ZhangChenYang.Properties.Resources.btn_mini_normal;
            this.Name = "wuziqi";
            this.Text = "星夜&永恒-无禁手五子棋";
            this.Load += new System.EventHandler(this.wuziqi_Load);
            this.shubiaoPos.ResumeLayout(false);
            this.shubiaoPos.PerformLayout();
            this.wanjiaxinxi.ResumeLayout(false);
            this.wanjiaxinxi.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Groap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox shubiaoPos;
        private System.Windows.Forms.Label shubiaoY;
        private System.Windows.Forms.Label shubiaoX;
        private System.Windows.Forms.GroupBox wanjiaxinxi;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label baiziplayLabel;
        private System.Windows.Forms.Label heiziplayLabel;
        private CCWin.SkinControl.SkinButtom skinButtom1;
        private System.Windows.Forms.GroupBox groupBox2;
        private CCWin.SkinControl.SkinButtom skinButtom2;
        private System.Windows.Forms.ListBox listBox1;
        private CCWin.SkinControl.SkinButtom skinButtom3;
        private System.Windows.Forms.PictureBox Groap;

    }
}