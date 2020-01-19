namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picOut = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelX = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.labelY = new System.Windows.Forms.Label();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.labelScale = new System.Windows.Forms.Label();
            this.timerScaleShow = new System.Windows.Forms.Timer(this.components);
            this.labelG = new System.Windows.Forms.Label();
            this.textBoxG = new System.Windows.Forms.TextBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.labelA = new System.Windows.Forms.Label();
            this.labelAlpha = new System.Windows.Forms.Label();
            this.textBoxAlpha = new System.Windows.Forms.TextBox();
            this.textBoxH = new System.Windows.Forms.TextBox();
            this.labelH = new System.Windows.Forms.Label();
            this.textBoxK = new System.Windows.Forms.TextBox();
            this.labelK = new System.Windows.Forms.Label();
            this.labelIaHeader = new System.Windows.Forms.Label();
            this.textBoxIa = new System.Windows.Forms.TextBox();
            this.labelPulses = new System.Windows.Forms.Label();
            this.labelPulsesOut = new System.Windows.Forms.Label();
            this.buttonClean = new System.Windows.Forms.Button();
            this.textBoxAlphaAdd = new System.Windows.Forms.TextBox();
            this.labelAlphaAdd = new System.Windows.Forms.Label();
            this.textBoxHAdd = new System.Windows.Forms.TextBox();
            this.labelHAdd = new System.Windows.Forms.Label();
            this.checkBoxShowAdd = new System.Windows.Forms.CheckBox();
            this.listBoxGType = new System.Windows.Forms.ListBox();
            this.listBoxGArg = new System.Windows.Forms.ListBox();
            this.textBoxGArgK = new System.Windows.Forms.TextBox();
            this.textBoxT = new System.Windows.Forms.TextBox();
            this.labelT = new System.Windows.Forms.Label();
            this.textBoxDT0 = new System.Windows.Forms.TextBox();
            this.labelDT0 = new System.Windows.Forms.Label();
            this.timerPrint = new System.Windows.Forms.Timer(this.components);
            this.labelPulsesTimes = new System.Windows.Forms.Label();
            this.labelPulsesS = new System.Windows.Forms.Label();
            this.labelGConst = new System.Windows.Forms.Label();
            this.textBoxGConst = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picOut)).BeginInit();
            this.SuspendLayout();
            // 
            // picOut
            // 
            this.picOut.Location = new System.Drawing.Point(13, 13);
            this.picOut.Name = "picOut";
            this.picOut.Size = new System.Drawing.Size(500, 500);
            this.picOut.TabIndex = 0;
            this.picOut.TabStop = false;
            this.picOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picOut_MouseDown);
            this.picOut.MouseEnter += new System.EventHandler(this.picOut_MouseEnter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(528, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Начать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(539, 43);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 2;
            this.labelX.Text = "X";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(542, 60);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(72, 20);
            this.textBoxX.TabIndex = 3;
            this.textBoxX.Text = "10";
            this.textBoxX.TextChanged += new System.EventHandler(this.textBoxX_TextChanged_1);
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(542, 87);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 13);
            this.labelY.TabIndex = 4;
            this.labelY.Text = "Y";
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(542, 104);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(72, 20);
            this.textBoxY.TabIndex = 5;
            this.textBoxY.Text = "-20";
            this.textBoxY.TextChanged += new System.EventHandler(this.textBoxY_TextChanged);
            // 
            // labelScale
            // 
            this.labelScale.AutoEllipsis = true;
            this.labelScale.AutoSize = true;
            this.labelScale.BackColor = System.Drawing.Color.Transparent;
            this.labelScale.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.labelScale.Location = new System.Drawing.Point(13, 13);
            this.labelScale.Name = "labelScale";
            this.labelScale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelScale.Size = new System.Drawing.Size(18, 13);
            this.labelScale.TabIndex = 11;
            this.labelScale.Text = "x1";
            this.labelScale.Visible = false;
            // 
            // timerScaleShow
            // 
            this.timerScaleShow.Interval = 3000;
            this.timerScaleShow.Tick += new System.EventHandler(this.scaleHide);
            // 
            // labelG
            // 
            this.labelG.AutoSize = true;
            this.labelG.Location = new System.Drawing.Point(531, 160);
            this.labelG.Name = "labelG";
            this.labelG.Size = new System.Drawing.Size(83, 26);
            this.labelG.TabIndex = 12;
            this.labelG.Text = "Возмущающее\r\nвоздействие";
            // 
            // textBoxG
            // 
            this.textBoxG.Location = new System.Drawing.Point(542, 190);
            this.textBoxG.Name = "textBoxG";
            this.textBoxG.Size = new System.Drawing.Size(72, 20);
            this.textBoxG.TabIndex = 13;
            this.textBoxG.Text = "-1";
            this.textBoxG.TextChanged += new System.EventHandler(this.textBoxG_TextChanged);
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(542, 243);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(72, 20);
            this.textBoxA.TabIndex = 15;
            this.textBoxA.Text = "10";
            this.textBoxA.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(531, 213);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(80, 26);
            this.labelA.TabIndex = 14;
            this.labelA.Text = "Управляющее\r\nвоздействие";
            // 
            // labelAlpha
            // 
            this.labelAlpha.AutoSize = true;
            this.labelAlpha.Location = new System.Drawing.Point(545, 270);
            this.labelAlpha.Name = "labelAlpha";
            this.labelAlpha.Size = new System.Drawing.Size(14, 13);
            this.labelAlpha.TabIndex = 16;
            this.labelAlpha.Text = "α";
            // 
            // textBoxAlpha
            // 
            this.textBoxAlpha.Location = new System.Drawing.Point(542, 287);
            this.textBoxAlpha.Name = "textBoxAlpha";
            this.textBoxAlpha.Size = new System.Drawing.Size(72, 20);
            this.textBoxAlpha.TabIndex = 17;
            this.textBoxAlpha.Text = "200";
            this.textBoxAlpha.TextChanged += new System.EventHandler(this.textBoxAlpha_TextChanged);
            // 
            // textBoxH
            // 
            this.textBoxH.Location = new System.Drawing.Point(542, 326);
            this.textBoxH.Name = "textBoxH";
            this.textBoxH.Size = new System.Drawing.Size(72, 20);
            this.textBoxH.TabIndex = 19;
            this.textBoxH.Text = "20";
            this.textBoxH.TextChanged += new System.EventHandler(this.textBoxH_TextChanged);
            // 
            // labelH
            // 
            this.labelH.AutoSize = true;
            this.labelH.Location = new System.Drawing.Point(545, 310);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(13, 13);
            this.labelH.TabIndex = 18;
            this.labelH.Text = "h";
            // 
            // textBoxK
            // 
            this.textBoxK.Location = new System.Drawing.Point(542, 365);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.Size = new System.Drawing.Size(72, 20);
            this.textBoxK.TabIndex = 21;
            this.textBoxK.Text = "0,7";
            this.textBoxK.TextChanged += new System.EventHandler(this.textBoxK_TextChanged);
            // 
            // labelK
            // 
            this.labelK.AutoSize = true;
            this.labelK.Location = new System.Drawing.Point(545, 349);
            this.labelK.Name = "labelK";
            this.labelK.Size = new System.Drawing.Size(13, 13);
            this.labelK.TabIndex = 20;
            this.labelK.Text = "k";
            // 
            // labelIaHeader
            // 
            this.labelIaHeader.AutoSize = true;
            this.labelIaHeader.Location = new System.Drawing.Point(531, 388);
            this.labelIaHeader.Name = "labelIaHeader";
            this.labelIaHeader.Size = new System.Drawing.Size(63, 13);
            this.labelIaHeader.TabIndex = 23;
            this.labelIaHeader.Text = "Период (с):";
            // 
            // textBoxIa
            // 
            this.textBoxIa.BackColor = System.Drawing.SystemColors.Menu;
            this.textBoxIa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIa.Location = new System.Drawing.Point(542, 404);
            this.textBoxIa.Name = "textBoxIa";
            this.textBoxIa.ReadOnly = true;
            this.textBoxIa.Size = new System.Drawing.Size(72, 13);
            this.textBoxIa.TabIndex = 24;
            this.textBoxIa.Text = "0";
            // 
            // labelPulses
            // 
            this.labelPulses.AutoSize = true;
            this.labelPulses.Location = new System.Drawing.Point(534, 424);
            this.labelPulses.Name = "labelPulses";
            this.labelPulses.Size = new System.Drawing.Size(63, 13);
            this.labelPulses.TabIndex = 25;
            this.labelPulses.Text = "Включения";
            // 
            // labelPulsesOut
            // 
            this.labelPulsesOut.AutoSize = true;
            this.labelPulsesOut.Location = new System.Drawing.Point(542, 441);
            this.labelPulsesOut.Name = "labelPulsesOut";
            this.labelPulsesOut.Size = new System.Drawing.Size(40, 13);
            this.labelPulsesOut.TabIndex = 26;
            this.labelPulsesOut.Text = "+: ? -:?";
            // 
            // buttonClean
            // 
            this.buttonClean.Location = new System.Drawing.Point(493, 493);
            this.buttonClean.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(20, 20);
            this.buttonClean.TabIndex = 27;
            this.buttonClean.Text = "↺";
            this.buttonClean.UseVisualStyleBackColor = true;
            this.buttonClean.Visible = false;
            this.buttonClean.Click += new System.EventHandler(this.buttonClean_Click);
            // 
            // textBoxAlphaAdd
            // 
            this.textBoxAlphaAdd.Location = new System.Drawing.Point(627, 287);
            this.textBoxAlphaAdd.Name = "textBoxAlphaAdd";
            this.textBoxAlphaAdd.Size = new System.Drawing.Size(72, 20);
            this.textBoxAlphaAdd.TabIndex = 29;
            this.textBoxAlphaAdd.Text = "200";
            this.textBoxAlphaAdd.TextChanged += new System.EventHandler(this.textBoxAlphaAdd_TextChanged);
            // 
            // labelAlphaAdd
            // 
            this.labelAlphaAdd.AutoSize = true;
            this.labelAlphaAdd.Location = new System.Drawing.Point(630, 270);
            this.labelAlphaAdd.Name = "labelAlphaAdd";
            this.labelAlphaAdd.Size = new System.Drawing.Size(17, 13);
            this.labelAlphaAdd.TabIndex = 28;
            this.labelAlphaAdd.Text = "α-";
            // 
            // textBoxHAdd
            // 
            this.textBoxHAdd.Location = new System.Drawing.Point(627, 326);
            this.textBoxHAdd.Name = "textBoxHAdd";
            this.textBoxHAdd.Size = new System.Drawing.Size(72, 20);
            this.textBoxHAdd.TabIndex = 31;
            this.textBoxHAdd.Text = "20";
            this.textBoxHAdd.TextChanged += new System.EventHandler(this.textBoxHAdd_TextChanged);
            // 
            // labelHAdd
            // 
            this.labelHAdd.AutoSize = true;
            this.labelHAdd.Location = new System.Drawing.Point(630, 310);
            this.labelHAdd.Name = "labelHAdd";
            this.labelHAdd.Size = new System.Drawing.Size(16, 13);
            this.labelHAdd.TabIndex = 30;
            this.labelHAdd.Text = "h-";
            // 
            // checkBoxShowAdd
            // 
            this.checkBoxShowAdd.AutoSize = true;
            this.checkBoxShowAdd.Location = new System.Drawing.Point(537, 496);
            this.checkBoxShowAdd.Name = "checkBoxShowAdd";
            this.checkBoxShowAdd.Size = new System.Drawing.Size(65, 17);
            this.checkBoxShowAdd.TabIndex = 32;
            this.checkBoxShowAdd.Text = "Больше";
            this.checkBoxShowAdd.UseVisualStyleBackColor = true;
            this.checkBoxShowAdd.CheckedChanged += new System.EventHandler(this.checkBoxShowAdd_CheckedChanged);
            // 
            // listBoxGType
            // 
            this.listBoxGType.FormattingEnabled = true;
            this.listBoxGType.Items.AddRange(new object[] {
            "-",
            "*sin",
            "*cos",
            "*sin²",
            "*cos²",
            "*"});
            this.listBoxGType.Location = new System.Drawing.Point(620, 190);
            this.listBoxGType.Name = "listBoxGType";
            this.listBoxGType.Size = new System.Drawing.Size(47, 56);
            this.listBoxGType.TabIndex = 33;
            this.listBoxGType.SelectedIndexChanged += new System.EventHandler(this.listBoxGType_SelectedIndexChanged);
            // 
            // listBoxGArg
            // 
            this.listBoxGArg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxGArg.FormattingEnabled = true;
            this.listBoxGArg.Items.AddRange(new object[] {
            "x*",
            "y*",
            "t*"});
            this.listBoxGArg.Location = new System.Drawing.Point(667, 190);
            this.listBoxGArg.Name = "listBoxGArg";
            this.listBoxGArg.Size = new System.Drawing.Size(16, 39);
            this.listBoxGArg.TabIndex = 34;
            this.listBoxGArg.Visible = false;
            this.listBoxGArg.SelectedIndexChanged += new System.EventHandler(this.listBoxGArg_SelectedIndexChanged);
            // 
            // textBoxGArgK
            // 
            this.textBoxGArgK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxGArgK.Location = new System.Drawing.Point(682, 190);
            this.textBoxGArgK.Name = "textBoxGArgK";
            this.textBoxGArgK.Size = new System.Drawing.Size(19, 13);
            this.textBoxGArgK.TabIndex = 35;
            this.textBoxGArgK.Text = "1";
            this.textBoxGArgK.Visible = false;
            this.textBoxGArgK.TextChanged += new System.EventHandler(this.textBoxGArgK_TextChanged);
            // 
            // textBoxT
            // 
            this.textBoxT.Location = new System.Drawing.Point(627, 104);
            this.textBoxT.Name = "textBoxT";
            this.textBoxT.Size = new System.Drawing.Size(72, 20);
            this.textBoxT.TabIndex = 37;
            this.textBoxT.Text = "0";
            this.textBoxT.TextChanged += new System.EventHandler(this.textBoxT_TextChanged);
            // 
            // labelT
            // 
            this.labelT.AutoSize = true;
            this.labelT.Location = new System.Drawing.Point(624, 87);
            this.labelT.Name = "labelT";
            this.labelT.Size = new System.Drawing.Size(10, 13);
            this.labelT.TabIndex = 36;
            this.labelT.Text = "t";
            // 
            // textBoxDT0
            // 
            this.textBoxDT0.Location = new System.Drawing.Point(627, 60);
            this.textBoxDT0.Name = "textBoxDT0";
            this.textBoxDT0.Size = new System.Drawing.Size(72, 20);
            this.textBoxDT0.TabIndex = 39;
            this.textBoxDT0.Text = "0,05";
            this.textBoxDT0.TextChanged += new System.EventHandler(this.textBoxDT0_TextChanged);
            // 
            // labelDT0
            // 
            this.labelDT0.AutoSize = true;
            this.labelDT0.Location = new System.Drawing.Point(624, 43);
            this.labelDT0.Name = "labelDT0";
            this.labelDT0.Size = new System.Drawing.Size(16, 13);
            this.labelDT0.TabIndex = 38;
            this.labelDT0.Text = "dt";
            // 
            // timerPrint
            // 
            this.timerPrint.Interval = 33;
            this.timerPrint.Tick += new System.EventHandler(this.timerPrint_Tick);
            // 
            // labelPulsesTimes
            // 
            this.labelPulsesTimes.AutoSize = true;
            this.labelPulsesTimes.Location = new System.Drawing.Point(542, 454);
            this.labelPulsesTimes.Name = "labelPulsesTimes";
            this.labelPulsesTimes.Size = new System.Drawing.Size(28, 26);
            this.labelPulsesTimes.TabIndex = 40;
            this.labelPulsesTimes.Text = "+t=?\r\n-t=?";
            // 
            // labelPulsesS
            // 
            this.labelPulsesS.AutoSize = true;
            this.labelPulsesS.Location = new System.Drawing.Point(617, 454);
            this.labelPulsesS.Name = "labelPulsesS";
            this.labelPulsesS.Size = new System.Drawing.Size(32, 26);
            this.labelPulsesS.TabIndex = 41;
            this.labelPulsesS.Text = "+S=?\r\n-S=?";
            // 
            // labelGConst
            // 
            this.labelGConst.AutoSize = true;
            this.labelGConst.Location = new System.Drawing.Point(624, 160);
            this.labelGConst.Name = "labelGConst";
            this.labelGConst.Size = new System.Drawing.Size(39, 13);
            this.labelGConst.TabIndex = 42;
            this.labelGConst.Text = "+const";
            // 
            // textBoxGConst
            // 
            this.textBoxGConst.Location = new System.Drawing.Point(667, 157);
            this.textBoxGConst.Name = "textBoxGConst";
            this.textBoxGConst.Size = new System.Drawing.Size(34, 20);
            this.textBoxGConst.TabIndex = 43;
            this.textBoxGConst.Text = "0";
            this.textBoxGConst.TextChanged += new System.EventHandler(this.textBoxGConst_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(620, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 23);
            this.button2.TabIndex = 44;
            this.button2.Text = "Область";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 525);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxGConst);
            this.Controls.Add(this.labelGConst);
            this.Controls.Add(this.labelPulsesS);
            this.Controls.Add(this.labelPulsesTimes);
            this.Controls.Add(this.textBoxDT0);
            this.Controls.Add(this.labelDT0);
            this.Controls.Add(this.textBoxT);
            this.Controls.Add(this.labelT);
            this.Controls.Add(this.textBoxGArgK);
            this.Controls.Add(this.listBoxGArg);
            this.Controls.Add(this.listBoxGType);
            this.Controls.Add(this.checkBoxShowAdd);
            this.Controls.Add(this.textBoxHAdd);
            this.Controls.Add(this.labelHAdd);
            this.Controls.Add(this.textBoxAlphaAdd);
            this.Controls.Add(this.labelAlphaAdd);
            this.Controls.Add(this.buttonClean);
            this.Controls.Add(this.labelPulsesOut);
            this.Controls.Add(this.labelPulses);
            this.Controls.Add(this.textBoxIa);
            this.Controls.Add(this.labelIaHeader);
            this.Controls.Add(this.textBoxK);
            this.Controls.Add(this.labelK);
            this.Controls.Add(this.textBoxH);
            this.Controls.Add(this.labelH);
            this.Controls.Add(this.textBoxAlpha);
            this.Controls.Add(this.labelAlpha);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.labelA);
            this.Controls.Add(this.textBoxG);
            this.Controls.Add(this.labelG);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picOut);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.Timer timerScaleShow;
        private System.Windows.Forms.Label labelG;
        private System.Windows.Forms.TextBox textBoxG;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Label labelAlpha;
        private System.Windows.Forms.TextBox textBoxAlpha;
        private System.Windows.Forms.TextBox textBoxH;
        private System.Windows.Forms.Label labelH;
        private System.Windows.Forms.TextBox textBoxK;
        private System.Windows.Forms.Label labelK;
        private System.Windows.Forms.Label labelIaHeader;
        private System.Windows.Forms.Label labelPulses;
        private System.Windows.Forms.Button buttonClean;
        private System.Windows.Forms.TextBox textBoxAlphaAdd;
        private System.Windows.Forms.Label labelAlphaAdd;
        private System.Windows.Forms.TextBox textBoxHAdd;
        private System.Windows.Forms.Label labelHAdd;
        private System.Windows.Forms.CheckBox checkBoxShowAdd;
        private System.Windows.Forms.ListBox listBoxGType;
        private System.Windows.Forms.ListBox listBoxGArg;
        private System.Windows.Forms.TextBox textBoxGArgK;
        private System.Windows.Forms.Label labelT;
        private System.Windows.Forms.TextBox textBoxDT0;
        private System.Windows.Forms.Label labelDT0;
        public System.Windows.Forms.PictureBox picOut;
        public System.Windows.Forms.TextBox textBoxX;
        public System.Windows.Forms.TextBox textBoxY;
        public System.Windows.Forms.TextBox textBoxT;
        public System.Windows.Forms.TextBox textBoxIa;
        public System.Windows.Forms.Label labelPulsesOut;
        private System.Windows.Forms.Timer timerPrint;
        private System.Windows.Forms.Label labelPulsesTimes;
        private System.Windows.Forms.Label labelPulsesS;
        private System.Windows.Forms.Label labelGConst;
        private System.Windows.Forms.TextBox textBoxGConst;
        private System.Windows.Forms.Button button2;
    }
}

