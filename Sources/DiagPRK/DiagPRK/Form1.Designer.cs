namespace DiagPRK
{
    partial class DiagRPK
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiagRPK));
            this._GetFrom = new System.Windows.Forms.TextBox();
            this._command = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._SendPack = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CommandList = new System.Windows.Forms.ListBox();
            this._ClearList = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._par13 = new System.Windows.Forms.ComboBox();
            this._par12 = new System.Windows.Forms.ComboBox();
            this._par11 = new System.Windows.Forms.ComboBox();
            this._par10 = new System.Windows.Forms.ComboBox();
            this._par9 = new System.Windows.Forms.ComboBox();
            this._par8 = new System.Windows.Forms.ComboBox();
            this._par7 = new System.Windows.Forms.ComboBox();
            this._par6 = new System.Windows.Forms.ComboBox();
            this._par5 = new System.Windows.Forms.ComboBox();
            this._par4 = new System.Windows.Forms.ComboBox();
            this._par3 = new System.Windows.Forms.ComboBox();
            this._par2 = new System.Windows.Forms.ComboBox();
            this._par1 = new System.Windows.Forms.ComboBox();
            this._rbutton1 = new System.Windows.Forms.RadioButton();
            this._rbutton2 = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.grParams = new System.Windows.Forms.GroupBox();
            this._Progress = new System.Windows.Forms.ProgressBar();
            this.Com_35 = new System.Windows.Forms.Button();
            this.Com_133 = new System.Windows.Forms.Button();
            this.Com_171 = new System.Windows.Forms.Button();
            this.Com_236 = new System.Windows.Forms.Button();
            this.Com_31 = new System.Windows.Forms.Button();
            this.Com_170 = new System.Windows.Forms.Button();
            this.Com_235 = new System.Windows.Forms.Button();
            this.Com_132 = new System.Windows.Forms.Button();
            this.Com_217 = new System.Windows.Forms.Button();
            this.Com_34 = new System.Windows.Forms.Button();
            this.Com_118 = new System.Windows.Forms.Button();
            this.Com_117 = new System.Windows.Forms.Button();
            this.Com_130 = new System.Windows.Forms.Button();
            this.Com_103 = new System.Windows.Forms.Button();
            this.Com_100 = new System.Windows.Forms.Button();
            this.Com_102 = new System.Windows.Forms.Button();
            this.Com_5 = new System.Windows.Forms.Button();
            this.Com_27 = new System.Windows.Forms.Button();
            this.Com_22 = new System.Windows.Forms.Button();
            this.Com_18 = new System.Windows.Forms.Button();
            this.Com_33 = new System.Windows.Forms.Button();
            this.Com_21 = new System.Windows.Forms.Button();
            this.Com_30 = new System.Windows.Forms.Button();
            this.Com_26 = new System.Windows.Forms.Button();
            this.Com_20 = new System.Windows.Forms.Button();
            this.Com_29 = new System.Windows.Forms.Button();
            this.Com_17 = new System.Windows.Forms.Button();
            this.Com_10 = new System.Windows.Forms.Button();
            this.Com_233 = new System.Windows.Forms.Button();
            this.Com_12 = new System.Windows.Forms.Button();
            this.Com_158 = new System.Windows.Forms.Button();
            this.Com_25 = new System.Windows.Forms.Button();
            this.Com_131 = new System.Windows.Forms.Button();
            this.Com_9 = new System.Windows.Forms.Button();
            this.Com_116 = new System.Windows.Forms.Button();
            this.Com_155 = new System.Windows.Forms.Button();
            this.Com_32 = new System.Windows.Forms.Button();
            this.Com_19 = new System.Windows.Forms.Button();
            this.Com_28 = new System.Windows.Forms.Button();
            this.Com_11 = new System.Windows.Forms.Button();
            this.Com_24 = new System.Windows.Forms.Button();
            this.Com_40 = new System.Windows.Forms.Button();
            this.gbCommand = new System.Windows.Forms.GroupBox();
            this._SendTo = new System.Windows.Forms.TextBox();
            this.grParams.SuspendLayout();
            this.gbCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // _GetFrom
            // 
            this._GetFrom.Location = new System.Drawing.Point(273, 26);
            this._GetFrom.MaxLength = 2;
            this._GetFrom.Name = "_GetFrom";
            this._GetFrom.Size = new System.Drawing.Size(40, 20);
            this._GetFrom.TabIndex = 5;
            this._GetFrom.TextChanged += new System.EventHandler(this.TextBoxValidator);
            this._GetFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbPortKeyPress);
            // 
            // _command
            // 
            this._command.Location = new System.Drawing.Point(72, 75);
            this._command.Name = "_command";
            this._command.ReadOnly = true;
            this._command.Size = new System.Drawing.Size(246, 20);
            this._command.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "SendTo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "GetFrom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Command";
            // 
            // _SendPack
            // 
            this._SendPack.Location = new System.Drawing.Point(12, 137);
            this._SendPack.Name = "_SendPack";
            this._SendPack.Size = new System.Drawing.Size(278, 57);
            this._SendPack.TabIndex = 11;
            this._SendPack.Text = "Send";
            this._SendPack.UseVisualStyleBackColor = true;
            this._SendPack.Click += new System.EventHandler(this._SendPack_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Command List:";
            // 
            // CommandList
            // 
            this.CommandList.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CommandList.FormattingEnabled = true;
            this.CommandList.Location = new System.Drawing.Point(319, 10);
            this.CommandList.MinimumSize = new System.Drawing.Size(256, 420);
            this.CommandList.Name = "CommandList";
            this.CommandList.Size = new System.Drawing.Size(347, 537);
            this.CommandList.TabIndex = 18;
            // 
            // _ClearList
            // 
            this._ClearList.Location = new System.Drawing.Point(573, 553);
            this._ClearList.Name = "_ClearList";
            this._ClearList.Size = new System.Drawing.Size(93, 29);
            this._ClearList.TabIndex = 19;
            this._ClearList.Text = "Clear List";
            this._ClearList.UseVisualStyleBackColor = true;
            this._ClearList.Click += new System.EventHandler(this._ClearList_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "Parameters:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(276, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 116;
            this.label18.Text = "Par13";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(232, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 115;
            this.label17.Text = "Par12";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(188, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 114;
            this.label16.Text = "Par11";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(144, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 113;
            this.label15.Text = "Par10";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(99, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 112;
            this.label14.Text = "Par9";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(55, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 111;
            this.label13.Text = "Par8";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 110;
            this.label12.Text = "Par7";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(231, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 109;
            this.label11.Text = "Par6";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(188, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 108;
            this.label10.Text = "Par5";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(144, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 107;
            this.label9.Text = "Par4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(99, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 106;
            this.label8.Text = "Par3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 105;
            this.label7.Text = "Par2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 104;
            this.label6.Text = "Par1";
            // 
            // _par13
            // 
            this._par13.DropDownHeight = 116;
            this._par13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._par13.FormattingEnabled = true;
            this._par13.IntegralHeight = false;
            this._par13.Location = new System.Drawing.Point(279, 80);
            this._par13.MaxDropDownItems = 5;
            this._par13.MaxLength = 2;
            this._par13.Name = "_par13";
            this._par13.Size = new System.Drawing.Size(38, 21);
            this._par13.TabIndex = 103;
            // 
            // _par12
            // 
            this._par12.DropDownHeight = 116;
            this._par12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._par12.FormattingEnabled = true;
            this._par12.IntegralHeight = false;
            this._par12.Location = new System.Drawing.Point(235, 80);
            this._par12.MaxDropDownItems = 5;
            this._par12.MaxLength = 2;
            this._par12.Name = "_par12";
            this._par12.Size = new System.Drawing.Size(38, 21);
            this._par12.TabIndex = 102;
            this._par12.TextChanged += new System.EventHandler(this.ParamTextChanged);
            // 
            // _par11
            // 
            this._par11.DropDownHeight = 116;
            this._par11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._par11.FormattingEnabled = true;
            this._par11.IntegralHeight = false;
            this._par11.Location = new System.Drawing.Point(191, 80);
            this._par11.MaxDropDownItems = 5;
            this._par11.MaxLength = 2;
            this._par11.Name = "_par11";
            this._par11.Size = new System.Drawing.Size(38, 21);
            this._par11.TabIndex = 101;
            this._par11.TextChanged += new System.EventHandler(this.ParamTextChanged);
            // 
            // _par10
            // 
            this._par10.DropDownHeight = 116;
            this._par10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._par10.FormattingEnabled = true;
            this._par10.IntegralHeight = false;
            this._par10.Location = new System.Drawing.Point(147, 80);
            this._par10.MaxDropDownItems = 5;
            this._par10.MaxLength = 2;
            this._par10.Name = "_par10";
            this._par10.Size = new System.Drawing.Size(38, 21);
            this._par10.TabIndex = 100;
            this._par10.TextChanged += new System.EventHandler(this.ParamTextChanged);
            // 
            // _par9
            // 
            this._par9.DropDownHeight = 116;
            this._par9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._par9.FormattingEnabled = true;
            this._par9.IntegralHeight = false;
            this._par9.Location = new System.Drawing.Point(102, 80);
            this._par9.MaxDropDownItems = 5;
            this._par9.MaxLength = 2;
            this._par9.Name = "_par9";
            this._par9.Size = new System.Drawing.Size(38, 21);
            this._par9.TabIndex = 99;
            this._par9.TextChanged += new System.EventHandler(this.ParamTextChanged);
            // 
            // _par8
            // 
            this._par8.DropDownHeight = 116;
            this._par8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._par8.FormattingEnabled = true;
            this._par8.IntegralHeight = false;
            this._par8.Location = new System.Drawing.Point(58, 80);
            this._par8.MaxDropDownItems = 5;
            this._par8.MaxLength = 2;
            this._par8.Name = "_par8";
            this._par8.Size = new System.Drawing.Size(38, 21);
            this._par8.TabIndex = 98;
            this._par8.TextChanged += new System.EventHandler(this.ParamTextChanged);
            // 
            // _par7
            // 
            this._par7.DropDownHeight = 116;
            this._par7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._par7.FormattingEnabled = true;
            this._par7.IntegralHeight = false;
            this._par7.Location = new System.Drawing.Point(14, 80);
            this._par7.MaxDropDownItems = 5;
            this._par7.MaxLength = 2;
            this._par7.Name = "_par7";
            this._par7.Size = new System.Drawing.Size(38, 21);
            this._par7.TabIndex = 97;
            this._par7.TextChanged += new System.EventHandler(this.ParamTextChanged);
            // 
            // _par6
            // 
            this._par6.DropDownHeight = 116;
            this._par6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._par6.FormattingEnabled = true;
            this._par6.IntegralHeight = false;
            this._par6.Location = new System.Drawing.Point(234, 29);
            this._par6.MaxDropDownItems = 5;
            this._par6.MaxLength = 2;
            this._par6.Name = "_par6";
            this._par6.Size = new System.Drawing.Size(38, 21);
            this._par6.TabIndex = 96;
            this._par6.TextChanged += new System.EventHandler(this.ParamTextChanged);
            // 
            // _par5
            // 
            this._par5.DropDownHeight = 116;
            this._par5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._par5.FormattingEnabled = true;
            this._par5.IntegralHeight = false;
            this._par5.Location = new System.Drawing.Point(190, 29);
            this._par5.MaxDropDownItems = 5;
            this._par5.MaxLength = 2;
            this._par5.Name = "_par5";
            this._par5.Size = new System.Drawing.Size(38, 21);
            this._par5.TabIndex = 95;
            this._par5.TextChanged += new System.EventHandler(this.ParamTextChanged);
            // 
            // _par4
            // 
            this._par4.DropDownHeight = 116;
            this._par4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._par4.FormattingEnabled = true;
            this._par4.IntegralHeight = false;
            this._par4.Location = new System.Drawing.Point(146, 29);
            this._par4.MaxDropDownItems = 5;
            this._par4.MaxLength = 2;
            this._par4.Name = "_par4";
            this._par4.Size = new System.Drawing.Size(38, 21);
            this._par4.TabIndex = 94;
            this._par4.TextChanged += new System.EventHandler(this.ParamTextChanged);
            // 
            // _par3
            // 
            this._par3.DropDownHeight = 116;
            this._par3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._par3.FormattingEnabled = true;
            this._par3.IntegralHeight = false;
            this._par3.Location = new System.Drawing.Point(102, 29);
            this._par3.MaxDropDownItems = 5;
            this._par3.MaxLength = 2;
            this._par3.Name = "_par3";
            this._par3.Size = new System.Drawing.Size(38, 21);
            this._par3.TabIndex = 93;
            this._par3.TextChanged += new System.EventHandler(this.ParamTextChanged);
            // 
            // _par2
            // 
            this._par2.DropDownHeight = 116;
            this._par2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._par2.FormattingEnabled = true;
            this._par2.IntegralHeight = false;
            this._par2.Location = new System.Drawing.Point(58, 29);
            this._par2.MaxDropDownItems = 5;
            this._par2.MaxLength = 2;
            this._par2.Name = "_par2";
            this._par2.Size = new System.Drawing.Size(38, 21);
            this._par2.TabIndex = 92;
            this._par2.TextChanged += new System.EventHandler(this.ParamTextChanged);
            // 
            // _par1
            // 
            this._par1.DropDownHeight = 116;
            this._par1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._par1.DropDownWidth = 10;
            this._par1.FormattingEnabled = true;
            this._par1.IntegralHeight = false;
            this._par1.Location = new System.Drawing.Point(14, 29);
            this._par1.MaxDropDownItems = 5;
            this._par1.MaxLength = 2;
            this._par1.Name = "_par1";
            this._par1.Size = new System.Drawing.Size(38, 21);
            this._par1.TabIndex = 91;
            this._par1.TextChanged += new System.EventHandler(this.ParamTextChanged);
            // 
            // _rbutton1
            // 
            this._rbutton1.AutoSize = true;
            this._rbutton1.Checked = true;
            this._rbutton1.Location = new System.Drawing.Point(130, 114);
            this._rbutton1.Name = "_rbutton1";
            this._rbutton1.Size = new System.Drawing.Size(31, 17);
            this._rbutton1.TabIndex = 117;
            this._rbutton1.TabStop = true;
            this._rbutton1.Text = "1";
            this._rbutton1.UseVisualStyleBackColor = true;
            // 
            // _rbutton2
            // 
            this._rbutton2.AutoSize = true;
            this._rbutton2.Location = new System.Drawing.Point(242, 114);
            this._rbutton2.Name = "_rbutton2";
            this._rbutton2.Size = new System.Drawing.Size(31, 17);
            this._rbutton2.TabIndex = 118;
            this._rbutton2.Text = "2";
            this._rbutton2.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 116);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 13);
            this.label19.TabIndex = 119;
            this.label19.Text = "Number of adapters";
            // 
            // grParams
            // 
            this.grParams.Controls.Add(this.label18);
            this.grParams.Controls.Add(this.label17);
            this.grParams.Controls.Add(this.label16);
            this.grParams.Controls.Add(this.label15);
            this.grParams.Controls.Add(this.label14);
            this.grParams.Controls.Add(this.label13);
            this.grParams.Controls.Add(this.label12);
            this.grParams.Controls.Add(this.label11);
            this.grParams.Controls.Add(this.label10);
            this.grParams.Controls.Add(this.label9);
            this.grParams.Controls.Add(this.label8);
            this.grParams.Controls.Add(this.label7);
            this.grParams.Controls.Add(this.label6);
            this.grParams.Controls.Add(this._par13);
            this.grParams.Controls.Add(this._par1);
            this.grParams.Controls.Add(this._par12);
            this.grParams.Controls.Add(this._par2);
            this.grParams.Controls.Add(this._par11);
            this.grParams.Controls.Add(this._par3);
            this.grParams.Controls.Add(this._par10);
            this.grParams.Controls.Add(this._par4);
            this.grParams.Controls.Add(this._par9);
            this.grParams.Controls.Add(this._par5);
            this.grParams.Controls.Add(this._par8);
            this.grParams.Controls.Add(this._par6);
            this.grParams.Controls.Add(this._par7);
            this.grParams.Location = new System.Drawing.Point(1, 459);
            this.grParams.Name = "grParams";
            this.grParams.Size = new System.Drawing.Size(317, 109);
            this.grParams.TabIndex = 120;
            this.grParams.TabStop = false;
            // 
            // _Progress
            // 
            this._Progress.BackColor = System.Drawing.Color.Silver;
            this._Progress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this._Progress.Location = new System.Drawing.Point(1, 588);
            this._Progress.Name = "_Progress";
            this._Progress.Size = new System.Drawing.Size(665, 28);
            this._Progress.TabIndex = 163;
            // 
            // Com_35
            // 
            this.Com_35.Location = new System.Drawing.Point(199, 105);
            this.Com_35.Name = "Com_35";
            this.Com_35.Size = new System.Drawing.Size(43, 23);
            this.Com_35.TabIndex = 162;
            this.Com_35.Text = "35";
            this.Com_35.UseVisualStyleBackColor = true;
            // 
            // Com_133
            // 
            this.Com_133.Location = new System.Drawing.Point(150, 165);
            this.Com_133.Name = "Com_133";
            this.Com_133.Size = new System.Drawing.Size(43, 23);
            this.Com_133.TabIndex = 161;
            this.Com_133.Text = "133";
            this.Com_133.UseVisualStyleBackColor = true;
            // 
            // Com_171
            // 
            this.Com_171.Location = new System.Drawing.Point(52, 194);
            this.Com_171.Name = "Com_171";
            this.Com_171.Size = new System.Drawing.Size(43, 23);
            this.Com_171.TabIndex = 160;
            this.Com_171.Text = "171";
            this.Com_171.UseVisualStyleBackColor = true;
            // 
            // Com_236
            // 
            this.Com_236.Location = new System.Drawing.Point(246, 194);
            this.Com_236.Name = "Com_236";
            this.Com_236.Size = new System.Drawing.Size(43, 23);
            this.Com_236.TabIndex = 159;
            this.Com_236.Text = "236";
            this.Com_236.UseVisualStyleBackColor = true;
            // 
            // Com_31
            // 
            this.Com_31.Location = new System.Drawing.Point(5, 105);
            this.Com_31.Name = "Com_31";
            this.Com_31.Size = new System.Drawing.Size(43, 23);
            this.Com_31.TabIndex = 158;
            this.Com_31.Text = "31";
            this.Com_31.UseVisualStyleBackColor = true;
            this.Com_31.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_170
            // 
            this.Com_170.Location = new System.Drawing.Point(5, 194);
            this.Com_170.Name = "Com_170";
            this.Com_170.Size = new System.Drawing.Size(43, 23);
            this.Com_170.TabIndex = 157;
            this.Com_170.Text = "170";
            this.Com_170.UseVisualStyleBackColor = true;
            // 
            // Com_235
            // 
            this.Com_235.Location = new System.Drawing.Point(199, 194);
            this.Com_235.Name = "Com_235";
            this.Com_235.Size = new System.Drawing.Size(43, 23);
            this.Com_235.TabIndex = 156;
            this.Com_235.Text = "235";
            this.Com_235.UseVisualStyleBackColor = true;
            // 
            // Com_132
            // 
            this.Com_132.Location = new System.Drawing.Point(101, 165);
            this.Com_132.Name = "Com_132";
            this.Com_132.Size = new System.Drawing.Size(43, 23);
            this.Com_132.TabIndex = 154;
            this.Com_132.Text = "132";
            this.Com_132.UseVisualStyleBackColor = true;
            // 
            // Com_217
            // 
            this.Com_217.Location = new System.Drawing.Point(101, 194);
            this.Com_217.Name = "Com_217";
            this.Com_217.Size = new System.Drawing.Size(43, 23);
            this.Com_217.TabIndex = 153;
            this.Com_217.Text = "217";
            this.Com_217.UseVisualStyleBackColor = true;
            // 
            // Com_34
            // 
            this.Com_34.Location = new System.Drawing.Point(150, 105);
            this.Com_34.Name = "Com_34";
            this.Com_34.Size = new System.Drawing.Size(43, 23);
            this.Com_34.TabIndex = 152;
            this.Com_34.Text = "34";
            this.Com_34.UseVisualStyleBackColor = true;
            this.Com_34.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_118
            // 
            this.Com_118.Location = new System.Drawing.Point(246, 136);
            this.Com_118.Name = "Com_118";
            this.Com_118.Size = new System.Drawing.Size(43, 23);
            this.Com_118.TabIndex = 151;
            this.Com_118.Text = "118";
            this.Com_118.UseVisualStyleBackColor = true;
            // 
            // Com_117
            // 
            this.Com_117.Location = new System.Drawing.Point(199, 136);
            this.Com_117.Name = "Com_117";
            this.Com_117.Size = new System.Drawing.Size(43, 23);
            this.Com_117.TabIndex = 149;
            this.Com_117.Text = "117";
            this.Com_117.UseVisualStyleBackColor = true;
            // 
            // Com_130
            // 
            this.Com_130.Location = new System.Drawing.Point(5, 165);
            this.Com_130.Name = "Com_130";
            this.Com_130.Size = new System.Drawing.Size(43, 23);
            this.Com_130.TabIndex = 147;
            this.Com_130.Text = "130";
            this.Com_130.UseVisualStyleBackColor = true;
            // 
            // Com_103
            // 
            this.Com_103.Location = new System.Drawing.Point(101, 136);
            this.Com_103.Name = "Com_103";
            this.Com_103.Size = new System.Drawing.Size(43, 23);
            this.Com_103.TabIndex = 145;
            this.Com_103.Text = "103";
            this.Com_103.UseVisualStyleBackColor = true;
            // 
            // Com_100
            // 
            this.Com_100.Location = new System.Drawing.Point(5, 136);
            this.Com_100.Name = "Com_100";
            this.Com_100.Size = new System.Drawing.Size(43, 23);
            this.Com_100.TabIndex = 144;
            this.Com_100.Text = "100";
            this.Com_100.UseVisualStyleBackColor = true;
            // 
            // Com_102
            // 
            this.Com_102.Location = new System.Drawing.Point(52, 136);
            this.Com_102.Name = "Com_102";
            this.Com_102.Size = new System.Drawing.Size(43, 23);
            this.Com_102.TabIndex = 143;
            this.Com_102.Text = "102";
            this.Com_102.UseVisualStyleBackColor = true;
            // 
            // Com_5
            // 
            this.Com_5.Location = new System.Drawing.Point(5, 18);
            this.Com_5.Name = "Com_5";
            this.Com_5.Size = new System.Drawing.Size(43, 23);
            this.Com_5.TabIndex = 141;
            this.Com_5.Tag = "";
            this.Com_5.Text = "5";
            this.Com_5.UseVisualStyleBackColor = true;
            this.Com_5.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_27
            // 
            this.Com_27.Location = new System.Drawing.Point(101, 76);
            this.Com_27.Name = "Com_27";
            this.Com_27.Size = new System.Drawing.Size(43, 23);
            this.Com_27.TabIndex = 140;
            this.Com_27.Text = "27";
            this.Com_27.UseVisualStyleBackColor = true;
            this.Com_27.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_22
            // 
            this.Com_22.Location = new System.Drawing.Point(199, 47);
            this.Com_22.Name = "Com_22";
            this.Com_22.Size = new System.Drawing.Size(43, 23);
            this.Com_22.TabIndex = 137;
            this.Com_22.Text = "22";
            this.Com_22.UseVisualStyleBackColor = true;
            this.Com_22.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_18
            // 
            this.Com_18.Location = new System.Drawing.Point(5, 47);
            this.Com_18.Name = "Com_18";
            this.Com_18.Size = new System.Drawing.Size(43, 23);
            this.Com_18.TabIndex = 135;
            this.Com_18.Text = "18";
            this.Com_18.UseVisualStyleBackColor = true;
            this.Com_18.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_33
            // 
            this.Com_33.Location = new System.Drawing.Point(101, 105);
            this.Com_33.Name = "Com_33";
            this.Com_33.Size = new System.Drawing.Size(43, 23);
            this.Com_33.TabIndex = 133;
            this.Com_33.Text = "33";
            this.Com_33.UseVisualStyleBackColor = true;
            this.Com_33.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_21
            // 
            this.Com_21.Location = new System.Drawing.Point(150, 47);
            this.Com_21.Name = "Com_21";
            this.Com_21.Size = new System.Drawing.Size(43, 23);
            this.Com_21.TabIndex = 132;
            this.Com_21.Text = "21";
            this.Com_21.UseVisualStyleBackColor = true;
            this.Com_21.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_30
            // 
            this.Com_30.Location = new System.Drawing.Point(246, 76);
            this.Com_30.Name = "Com_30";
            this.Com_30.Size = new System.Drawing.Size(43, 23);
            this.Com_30.TabIndex = 131;
            this.Com_30.Text = "30";
            this.Com_30.UseVisualStyleBackColor = true;
            this.Com_30.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_26
            // 
            this.Com_26.Location = new System.Drawing.Point(52, 76);
            this.Com_26.Name = "Com_26";
            this.Com_26.Size = new System.Drawing.Size(43, 23);
            this.Com_26.TabIndex = 130;
            this.Com_26.Text = "26";
            this.Com_26.UseVisualStyleBackColor = true;
            this.Com_26.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_20
            // 
            this.Com_20.Location = new System.Drawing.Point(101, 47);
            this.Com_20.Name = "Com_20";
            this.Com_20.Size = new System.Drawing.Size(43, 23);
            this.Com_20.TabIndex = 129;
            this.Com_20.Text = "20";
            this.Com_20.UseVisualStyleBackColor = true;
            this.Com_20.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_29
            // 
            this.Com_29.Location = new System.Drawing.Point(199, 76);
            this.Com_29.Name = "Com_29";
            this.Com_29.Size = new System.Drawing.Size(43, 23);
            this.Com_29.TabIndex = 128;
            this.Com_29.Text = "29";
            this.Com_29.UseVisualStyleBackColor = true;
            this.Com_29.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_17
            // 
            this.Com_17.Location = new System.Drawing.Point(246, 18);
            this.Com_17.Name = "Com_17";
            this.Com_17.Size = new System.Drawing.Size(43, 23);
            this.Com_17.TabIndex = 126;
            this.Com_17.Text = "17";
            this.Com_17.UseVisualStyleBackColor = true;
            this.Com_17.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_10
            // 
            this.Com_10.Location = new System.Drawing.Point(101, 18);
            this.Com_10.Name = "Com_10";
            this.Com_10.Size = new System.Drawing.Size(43, 23);
            this.Com_10.TabIndex = 125;
            this.Com_10.Text = "10";
            this.Com_10.UseVisualStyleBackColor = true;
            this.Com_10.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_233
            // 
            this.Com_233.Location = new System.Drawing.Point(150, 194);
            this.Com_233.Name = "Com_233";
            this.Com_233.Size = new System.Drawing.Size(43, 23);
            this.Com_233.TabIndex = 155;
            this.Com_233.Text = "233";
            this.Com_233.UseVisualStyleBackColor = true;
            // 
            // Com_12
            // 
            this.Com_12.Location = new System.Drawing.Point(199, 18);
            this.Com_12.Name = "Com_12";
            this.Com_12.Size = new System.Drawing.Size(43, 23);
            this.Com_12.TabIndex = 124;
            this.Com_12.Text = "12";
            this.Com_12.UseVisualStyleBackColor = true;
            this.Com_12.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_158
            // 
            this.Com_158.Location = new System.Drawing.Point(246, 165);
            this.Com_158.Name = "Com_158";
            this.Com_158.Size = new System.Drawing.Size(43, 23);
            this.Com_158.TabIndex = 150;
            this.Com_158.Text = "158";
            this.Com_158.UseVisualStyleBackColor = true;
            // 
            // Com_25
            // 
            this.Com_25.Location = new System.Drawing.Point(5, 76);
            this.Com_25.Name = "Com_25";
            this.Com_25.Size = new System.Drawing.Size(43, 23);
            this.Com_25.TabIndex = 123;
            this.Com_25.Text = "25";
            this.Com_25.UseVisualStyleBackColor = true;
            this.Com_25.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_131
            // 
            this.Com_131.Location = new System.Drawing.Point(52, 165);
            this.Com_131.Name = "Com_131";
            this.Com_131.Size = new System.Drawing.Size(43, 23);
            this.Com_131.TabIndex = 148;
            this.Com_131.Text = "131";
            this.Com_131.UseVisualStyleBackColor = true;
            // 
            // Com_9
            // 
            this.Com_9.Location = new System.Drawing.Point(52, 18);
            this.Com_9.Name = "Com_9";
            this.Com_9.Size = new System.Drawing.Size(43, 23);
            this.Com_9.TabIndex = 122;
            this.Com_9.Text = "9";
            this.Com_9.UseVisualStyleBackColor = true;
            this.Com_9.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_116
            // 
            this.Com_116.Location = new System.Drawing.Point(150, 136);
            this.Com_116.Name = "Com_116";
            this.Com_116.Size = new System.Drawing.Size(43, 23);
            this.Com_116.TabIndex = 146;
            this.Com_116.Text = "116";
            this.Com_116.UseVisualStyleBackColor = true;
            // 
            // Com_155
            // 
            this.Com_155.Location = new System.Drawing.Point(199, 165);
            this.Com_155.Name = "Com_155";
            this.Com_155.Size = new System.Drawing.Size(43, 23);
            this.Com_155.TabIndex = 121;
            this.Com_155.Text = "155";
            this.Com_155.UseVisualStyleBackColor = true;
            this.Com_155.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_32
            // 
            this.Com_32.Location = new System.Drawing.Point(52, 105);
            this.Com_32.Name = "Com_32";
            this.Com_32.Size = new System.Drawing.Size(43, 23);
            this.Com_32.TabIndex = 142;
            this.Com_32.Text = "32";
            this.Com_32.UseVisualStyleBackColor = true;
            this.Com_32.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_19
            // 
            this.Com_19.Location = new System.Drawing.Point(52, 47);
            this.Com_19.Name = "Com_19";
            this.Com_19.Size = new System.Drawing.Size(43, 23);
            this.Com_19.TabIndex = 136;
            this.Com_19.Text = "19";
            this.Com_19.UseVisualStyleBackColor = true;
            this.Com_19.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_28
            // 
            this.Com_28.Location = new System.Drawing.Point(150, 76);
            this.Com_28.Name = "Com_28";
            this.Com_28.Size = new System.Drawing.Size(43, 23);
            this.Com_28.TabIndex = 139;
            this.Com_28.Text = "28";
            this.Com_28.UseVisualStyleBackColor = true;
            this.Com_28.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_11
            // 
            this.Com_11.Location = new System.Drawing.Point(150, 18);
            this.Com_11.Name = "Com_11";
            this.Com_11.Size = new System.Drawing.Size(43, 23);
            this.Com_11.TabIndex = 127;
            this.Com_11.Text = "11";
            this.Com_11.UseVisualStyleBackColor = true;
            this.Com_11.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_24
            // 
            this.Com_24.Location = new System.Drawing.Point(246, 47);
            this.Com_24.Name = "Com_24";
            this.Com_24.Size = new System.Drawing.Size(43, 23);
            this.Com_24.TabIndex = 138;
            this.Com_24.Text = "24";
            this.Com_24.UseVisualStyleBackColor = true;
            this.Com_24.Click += new System.EventHandler(this.Com_Click);
            // 
            // Com_40
            // 
            this.Com_40.Location = new System.Drawing.Point(246, 105);
            this.Com_40.Name = "Com_40";
            this.Com_40.Size = new System.Drawing.Size(43, 23);
            this.Com_40.TabIndex = 134;
            this.Com_40.Text = "40";
            this.Com_40.UseVisualStyleBackColor = true;
            // 
            // gbCommand
            // 
            this.gbCommand.Controls.Add(this.Com_35);
            this.gbCommand.Controls.Add(this.Com_133);
            this.gbCommand.Controls.Add(this.Com_171);
            this.gbCommand.Controls.Add(this.Com_236);
            this.gbCommand.Controls.Add(this.Com_31);
            this.gbCommand.Controls.Add(this.Com_170);
            this.gbCommand.Controls.Add(this.Com_235);
            this.gbCommand.Controls.Add(this.Com_132);
            this.gbCommand.Controls.Add(this.Com_217);
            this.gbCommand.Controls.Add(this.Com_34);
            this.gbCommand.Controls.Add(this.Com_118);
            this.gbCommand.Controls.Add(this.Com_117);
            this.gbCommand.Controls.Add(this.Com_130);
            this.gbCommand.Controls.Add(this.Com_103);
            this.gbCommand.Controls.Add(this.Com_100);
            this.gbCommand.Controls.Add(this.Com_102);
            this.gbCommand.Controls.Add(this.Com_5);
            this.gbCommand.Controls.Add(this.Com_27);
            this.gbCommand.Controls.Add(this.Com_22);
            this.gbCommand.Controls.Add(this.Com_18);
            this.gbCommand.Controls.Add(this.Com_33);
            this.gbCommand.Controls.Add(this.Com_21);
            this.gbCommand.Controls.Add(this.Com_30);
            this.gbCommand.Controls.Add(this.Com_26);
            this.gbCommand.Controls.Add(this.Com_20);
            this.gbCommand.Controls.Add(this.Com_29);
            this.gbCommand.Controls.Add(this.Com_17);
            this.gbCommand.Controls.Add(this.Com_10);
            this.gbCommand.Controls.Add(this.Com_233);
            this.gbCommand.Controls.Add(this.Com_12);
            this.gbCommand.Controls.Add(this.Com_158);
            this.gbCommand.Controls.Add(this.Com_25);
            this.gbCommand.Controls.Add(this.Com_131);
            this.gbCommand.Controls.Add(this.Com_9);
            this.gbCommand.Controls.Add(this.Com_116);
            this.gbCommand.Controls.Add(this.Com_155);
            this.gbCommand.Controls.Add(this.Com_32);
            this.gbCommand.Controls.Add(this.Com_19);
            this.gbCommand.Controls.Add(this.Com_28);
            this.gbCommand.Controls.Add(this.Com_11);
            this.gbCommand.Controls.Add(this.Com_24);
            this.gbCommand.Controls.Add(this.Com_40);
            this.gbCommand.Location = new System.Drawing.Point(1, 213);
            this.gbCommand.Name = "gbCommand";
            this.gbCommand.Size = new System.Drawing.Size(317, 227);
            this.gbCommand.TabIndex = 164;
            this.gbCommand.TabStop = false;
            // 
            // _SendTo
            // 
            this._SendTo.Location = new System.Drawing.Point(72, 26);
            this._SendTo.MaxLength = 2;
            this._SendTo.Name = "_SendTo";
            this._SendTo.Size = new System.Drawing.Size(40, 20);
            this._SendTo.TabIndex = 4;
            this._SendTo.TextChanged += new System.EventHandler(this._SendTo_TextChanged);
            this._SendTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbPortKeyPress);
            // 
            // DiagRPK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(678, 617);
            this.Controls.Add(this.gbCommand);
            this.Controls.Add(this._Progress);
            this.Controls.Add(this.grParams);
            this.Controls.Add(this.label19);
            this.Controls.Add(this._rbutton2);
            this.Controls.Add(this._rbutton1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._ClearList);
            this.Controls.Add(this.CommandList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._SendPack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._command);
            this.Controls.Add(this._GetFrom);
            this.Controls.Add(this._SendTo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(694, 655);
            this.MinimumSize = new System.Drawing.Size(694, 655);
            this.Name = "DiagRPK";
            this.Text = "DiagRPK";
            this.grParams.ResumeLayout(false);
            this.grParams.PerformLayout();
            this.gbCommand.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _GetFrom;
        private System.Windows.Forms.TextBox _command;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _SendPack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox CommandList;
        private System.Windows.Forms.Button _ClearList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox _par13;
        private System.Windows.Forms.ComboBox _par12;
        private System.Windows.Forms.ComboBox _par11;
        private System.Windows.Forms.ComboBox _par10;
        private System.Windows.Forms.ComboBox _par9;
        private System.Windows.Forms.ComboBox _par8;
        private System.Windows.Forms.ComboBox _par7;
        private System.Windows.Forms.ComboBox _par6;
        private System.Windows.Forms.ComboBox _par5;
        private System.Windows.Forms.ComboBox _par4;
        private System.Windows.Forms.ComboBox _par3;
        private System.Windows.Forms.ComboBox _par2;
        private System.Windows.Forms.ComboBox _par1;
        const string _free = "3";
        const string zero = "0";
        private void Flag_reset()
        {
            this.Com_5.Tag = false;
            this.Com_9.Tag = false;
            this.Com_10.Tag = false;
            this.Com_11.Tag = false;
            this.Com_12.Tag = false;
            this.Com_17.Tag = false;
            this.Com_18.Tag = false;
            this.Com_19.Tag = false;
            this.Com_20.Tag = false;
            this.Com_21.Tag = false;
            this.Com_22.Tag = false;
            this.Com_24.Tag = false;
            this.Com_25.Tag = false;
            this.Com_26.Tag = false;
            this.Com_27.Tag = false;
            this.Com_28.Tag = false;
            this.Com_29.Tag = false;
            this.Com_30.Tag = false;
            this.Com_31.Tag = false;
            this.Com_32.Tag = false;
            this.Com_33.Tag = false;
            this.Com_40.Tag = false;
            this.Com_100.Tag = false;
            this.Com_102.Tag = false;
            this.Com_103.Tag = false;
            this.Com_116.Tag = false;
            this.Com_117.Tag = false;
            this.Com_118.Tag = false;
            this.Com_131.Tag = false;
            this.Com_155.Tag = false;
            this.Com_158.Tag = false;
            this.Com_170.Tag = false;
            this.Com_217.Tag = false;
            this.Com_233.Tag = false;
            this.Com_235.Tag = false;
            this.Com_236.Tag = false;
            this.Com_130.Tag = false;
            this.Com_132.Tag = false;
            this.Com_133.Tag = false;
            this.Com_171.Tag = false;
            this.Com_34.Tag = false;
            this.Com_35.Tag = false;
        }
        private void Par_reset()
        {
            _par1.Items.Clear();
            _par2.Items.Clear();
            _par3.Items.Clear();
            _par4.Items.Clear();
            _par5.Items.Clear();
            _par6.Items.Clear();
            _par7.Items.Clear();
            _par8.Items.Clear();
            _par9.Items.Clear();
            _par10.Items.Clear();
            _par11.Items.Clear();
            _par12.Items.Clear();
            _par13.Items.Clear();
        }
        private void Par_reset1()
        {
            _par2.Items.Clear();
            _par3.Items.Clear();
            _par4.Items.Clear();
            _par5.Items.Clear();
            _par6.Items.Clear();
            _par7.Items.Clear();
            _par8.Items.Clear();
            _par9.Items.Clear();
            _par10.Items.Clear();
            _par11.Items.Clear();
            _par12.Items.Clear();
            _par13.Items.Clear();
        }
        private System.Windows.Forms.RadioButton _rbutton1;
        private System.Windows.Forms.RadioButton _rbutton2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox grParams;
        private System.Windows.Forms.ProgressBar _Progress;
        private System.Windows.Forms.Button Com_35;
        private System.Windows.Forms.Button Com_133;
        private System.Windows.Forms.Button Com_171;
        private System.Windows.Forms.Button Com_236;
        private System.Windows.Forms.Button Com_31;
        private System.Windows.Forms.Button Com_170;
        private System.Windows.Forms.Button Com_235;
        private System.Windows.Forms.Button Com_132;
        private System.Windows.Forms.Button Com_217;
        private System.Windows.Forms.Button Com_34;
        private System.Windows.Forms.Button Com_118;
        private System.Windows.Forms.Button Com_117;
        private System.Windows.Forms.Button Com_130;
        private System.Windows.Forms.Button Com_103;
        private System.Windows.Forms.Button Com_100;
        private System.Windows.Forms.Button Com_102;
        private System.Windows.Forms.Button Com_5;
        private System.Windows.Forms.Button Com_27;
        private System.Windows.Forms.Button Com_22;
        private System.Windows.Forms.Button Com_18;
        private System.Windows.Forms.Button Com_33;
        private System.Windows.Forms.Button Com_21;
        private System.Windows.Forms.Button Com_30;
        private System.Windows.Forms.Button Com_26;
        private System.Windows.Forms.Button Com_20;
        private System.Windows.Forms.Button Com_29;
        private System.Windows.Forms.Button Com_17;
        private System.Windows.Forms.Button Com_10;
        private System.Windows.Forms.Button Com_233;
        private System.Windows.Forms.Button Com_12;
        private System.Windows.Forms.Button Com_158;
        private System.Windows.Forms.Button Com_25;
        private System.Windows.Forms.Button Com_131;
        private System.Windows.Forms.Button Com_9;
        private System.Windows.Forms.Button Com_116;
        private System.Windows.Forms.Button Com_155;
        private System.Windows.Forms.Button Com_32;
        private System.Windows.Forms.Button Com_19;
        private System.Windows.Forms.Button Com_28;
        private System.Windows.Forms.Button Com_11;
        private System.Windows.Forms.Button Com_24;
        private System.Windows.Forms.Button Com_40;
        private System.Windows.Forms.GroupBox gbCommand;
        private System.Windows.Forms.TextBox _SendTo;
    }
}

