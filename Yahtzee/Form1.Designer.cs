namespace Yahtzee
{
    partial class Yahtzee
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BTN_Roll = new System.Windows.Forms.Button();
            this.PCB_Dice1 = new System.Windows.Forms.PictureBox();
            this.PCB_Dice2 = new System.Windows.Forms.PictureBox();
            this.PCB_Dice3 = new System.Windows.Forms.PictureBox();
            this.PCB_Dice4 = new System.Windows.Forms.PictureBox();
            this.PCB_Dice5 = new System.Windows.Forms.PictureBox();
            this.CKB_DiceKeeper1 = new System.Windows.Forms.CheckBox();
            this.CKB_DiceKeeper2 = new System.Windows.Forms.CheckBox();
            this.CKB_DiceKeeper3 = new System.Windows.Forms.CheckBox();
            this.CKB_DiceKeeper4 = new System.Windows.Forms.CheckBox();
            this.CKB_DiceKeeper5 = new System.Windows.Forms.CheckBox();
            this.DGV_ScoreBoard = new System.Windows.Forms.DataGridView();
            this.datagrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.PCB_Dice1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCB_Dice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCB_Dice3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCB_Dice4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCB_Dice5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ScoreBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Roll
            // 
            this.BTN_Roll.Location = new System.Drawing.Point(244, 352);
            this.BTN_Roll.Name = "BTN_Roll";
            this.BTN_Roll.Size = new System.Drawing.Size(100, 52);
            this.BTN_Roll.TabIndex = 1;
            this.BTN_Roll.Text = "Roll";
            this.BTN_Roll.UseVisualStyleBackColor = true;
            this.BTN_Roll.Click += new System.EventHandler(this.BTN_Roll_Click);
            // 
            // PCB_Dice1
            // 
            this.PCB_Dice1.Location = new System.Drawing.Point(32, 115);
            this.PCB_Dice1.Name = "PCB_Dice1";
            this.PCB_Dice1.Size = new System.Drawing.Size(100, 100);
            this.PCB_Dice1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCB_Dice1.TabIndex = 2;
            this.PCB_Dice1.TabStop = false;
            // 
            // PCB_Dice2
            // 
            this.PCB_Dice2.Location = new System.Drawing.Point(138, 115);
            this.PCB_Dice2.Name = "PCB_Dice2";
            this.PCB_Dice2.Size = new System.Drawing.Size(100, 100);
            this.PCB_Dice2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCB_Dice2.TabIndex = 3;
            this.PCB_Dice2.TabStop = false;
            // 
            // PCB_Dice3
            // 
            this.PCB_Dice3.Location = new System.Drawing.Point(244, 115);
            this.PCB_Dice3.Name = "PCB_Dice3";
            this.PCB_Dice3.Size = new System.Drawing.Size(100, 100);
            this.PCB_Dice3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCB_Dice3.TabIndex = 4;
            this.PCB_Dice3.TabStop = false;
            // 
            // PCB_Dice4
            // 
            this.PCB_Dice4.Location = new System.Drawing.Point(350, 115);
            this.PCB_Dice4.Name = "PCB_Dice4";
            this.PCB_Dice4.Size = new System.Drawing.Size(100, 100);
            this.PCB_Dice4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCB_Dice4.TabIndex = 5;
            this.PCB_Dice4.TabStop = false;
            // 
            // PCB_Dice5
            // 
            this.PCB_Dice5.Location = new System.Drawing.Point(456, 115);
            this.PCB_Dice5.Name = "PCB_Dice5";
            this.PCB_Dice5.Size = new System.Drawing.Size(100, 100);
            this.PCB_Dice5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCB_Dice5.TabIndex = 6;
            this.PCB_Dice5.TabStop = false;
            // 
            // CKB_DiceKeeper1
            // 
            this.CKB_DiceKeeper1.Appearance = System.Windows.Forms.Appearance.Button;
            this.CKB_DiceKeeper1.AutoSize = true;
            this.CKB_DiceKeeper1.Location = new System.Drawing.Point(54, 221);
            this.CKB_DiceKeeper1.Name = "CKB_DiceKeeper1";
            this.CKB_DiceKeeper1.Size = new System.Drawing.Size(43, 25);
            this.CKB_DiceKeeper1.TabIndex = 12;
            this.CKB_DiceKeeper1.Text = "Keep";
            this.CKB_DiceKeeper1.UseVisualStyleBackColor = true;
            this.CKB_DiceKeeper1.CheckedChanged += new System.EventHandler(this.CKB_DiceKeeper1_CheckedChanged);
            // 
            // CKB_DiceKeeper2
            // 
            this.CKB_DiceKeeper2.Appearance = System.Windows.Forms.Appearance.Button;
            this.CKB_DiceKeeper2.AutoSize = true;
            this.CKB_DiceKeeper2.Location = new System.Drawing.Point(164, 221);
            this.CKB_DiceKeeper2.Name = "CKB_DiceKeeper2";
            this.CKB_DiceKeeper2.Size = new System.Drawing.Size(43, 25);
            this.CKB_DiceKeeper2.TabIndex = 13;
            this.CKB_DiceKeeper2.Text = "Keep";
            this.CKB_DiceKeeper2.UseVisualStyleBackColor = true;
            this.CKB_DiceKeeper2.CheckedChanged += new System.EventHandler(this.CKB_DiceKeeper2_CheckedChanged);
            // 
            // CKB_DiceKeeper3
            // 
            this.CKB_DiceKeeper3.Appearance = System.Windows.Forms.Appearance.Button;
            this.CKB_DiceKeeper3.AutoSize = true;
            this.CKB_DiceKeeper3.Location = new System.Drawing.Point(270, 221);
            this.CKB_DiceKeeper3.Name = "CKB_DiceKeeper3";
            this.CKB_DiceKeeper3.Size = new System.Drawing.Size(43, 25);
            this.CKB_DiceKeeper3.TabIndex = 14;
            this.CKB_DiceKeeper3.Text = "Keep";
            this.CKB_DiceKeeper3.UseVisualStyleBackColor = true;
            this.CKB_DiceKeeper3.CheckedChanged += new System.EventHandler(this.CKB_DiceKeeper3_CheckedChanged);
            // 
            // CKB_DiceKeeper4
            // 
            this.CKB_DiceKeeper4.Appearance = System.Windows.Forms.Appearance.Button;
            this.CKB_DiceKeeper4.AutoSize = true;
            this.CKB_DiceKeeper4.Location = new System.Drawing.Point(374, 221);
            this.CKB_DiceKeeper4.Name = "CKB_DiceKeeper4";
            this.CKB_DiceKeeper4.Size = new System.Drawing.Size(43, 25);
            this.CKB_DiceKeeper4.TabIndex = 15;
            this.CKB_DiceKeeper4.Text = "Keep";
            this.CKB_DiceKeeper4.UseVisualStyleBackColor = true;
            this.CKB_DiceKeeper4.CheckedChanged += new System.EventHandler(this.CKB_DiceKeeper4_CheckedChanged);
            // 
            // CKB_DiceKeeper5
            // 
            this.CKB_DiceKeeper5.Appearance = System.Windows.Forms.Appearance.Button;
            this.CKB_DiceKeeper5.AutoSize = true;
            this.CKB_DiceKeeper5.Location = new System.Drawing.Point(485, 221);
            this.CKB_DiceKeeper5.Name = "CKB_DiceKeeper5";
            this.CKB_DiceKeeper5.Size = new System.Drawing.Size(43, 25);
            this.CKB_DiceKeeper5.TabIndex = 16;
            this.CKB_DiceKeeper5.Text = "Keep";
            this.CKB_DiceKeeper5.UseVisualStyleBackColor = true;
            this.CKB_DiceKeeper5.CheckedChanged += new System.EventHandler(this.CKB_DiceKeeper5_CheckedChanged);
            // 
            // DGV_ScoreBoard
            // 
            this.DGV_ScoreBoard.AllowUserToDeleteRows = false;
            this.DGV_ScoreBoard.BackgroundColor = System.Drawing.Color.DarkGreen;
            this.DGV_ScoreBoard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ScoreBoard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.datagrid,
            this.P1,
            this.P2});
            this.DGV_ScoreBoard.Location = new System.Drawing.Point(644, 12);
            this.DGV_ScoreBoard.MultiSelect = false;
            this.DGV_ScoreBoard.Name = "DGV_ScoreBoard";
            this.DGV_ScoreBoard.ReadOnly = true;
            this.DGV_ScoreBoard.RowTemplate.Height = 25;
            this.DGV_ScoreBoard.Size = new System.Drawing.Size(248, 458);
            this.DGV_ScoreBoard.TabIndex = 17;
            // 
            // datagrid
            // 
            this.datagrid.HeaderText = "";
            this.datagrid.Name = "datagrid";
            this.datagrid.ReadOnly = true;
            this.datagrid.Width = 95;
            // 
            // P1
            // 
            this.P1.HeaderText = "Player1";
            this.P1.Name = "P1";
            this.P1.ReadOnly = true;
            this.P1.Width = 50;
            // 
            // P2
            // 
            this.P2.HeaderText = "Player2";
            this.P2.Name = "P2";
            this.P2.ReadOnly = true;
            this.P2.Width = 50;
            // 
            // Yahtzee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(904, 530);
            this.Controls.Add(this.DGV_ScoreBoard);
            this.Controls.Add(this.CKB_DiceKeeper5);
            this.Controls.Add(this.CKB_DiceKeeper4);
            this.Controls.Add(this.CKB_DiceKeeper3);
            this.Controls.Add(this.CKB_DiceKeeper2);
            this.Controls.Add(this.CKB_DiceKeeper1);
            this.Controls.Add(this.PCB_Dice5);
            this.Controls.Add(this.PCB_Dice4);
            this.Controls.Add(this.PCB_Dice3);
            this.Controls.Add(this.PCB_Dice2);
            this.Controls.Add(this.PCB_Dice1);
            this.Controls.Add(this.BTN_Roll);
            this.Name = "Yahtzee";
            this.Text = "Yahtzee";
            this.Load += new System.EventHandler(this.Yahtzee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PCB_Dice1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCB_Dice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCB_Dice3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCB_Dice4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCB_Dice5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ScoreBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BTN_Roll;
        private PictureBox PCB_Dice1;
        private PictureBox PCB_Dice2;
        private PictureBox PCB_Dice3;
        private PictureBox PCB_Dice4;
        private PictureBox PCB_Dice5;
        private CheckBox CKB_DiceKeeper1;
        private CheckBox CKB_DiceKeeper2;
        private CheckBox CKB_DiceKeeper3;
        private CheckBox CKB_DiceKeeper4;
        private CheckBox CKB_DiceKeeper5;
        private DataGridView DGV_ScoreBoard;
        private DataGridViewTextBoxColumn datagrid;
        private DataGridViewTextBoxColumn P1;
        private DataGridViewTextBoxColumn P2;
    }
}