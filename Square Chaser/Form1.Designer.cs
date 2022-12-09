namespace Square_Chaser
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.player1scoreOutput = new System.Windows.Forms.Label();
            this.player2scoreOutput = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.winLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // player1scoreOutput
            // 
            this.player1scoreOutput.AutoSize = true;
            this.player1scoreOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1scoreOutput.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.player1scoreOutput.Location = new System.Drawing.Point(237, 9);
            this.player1scoreOutput.Name = "player1scoreOutput";
            this.player1scoreOutput.Size = new System.Drawing.Size(20, 24);
            this.player1scoreOutput.TabIndex = 3;
            this.player1scoreOutput.Text = "0";
            this.player1scoreOutput.DoubleClick += new System.EventHandler(this.player1scoreLabel_DoubleClick);
            // 
            // player2scoreOutput
            // 
            this.player2scoreOutput.AutoSize = true;
            this.player2scoreOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2scoreOutput.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.player2scoreOutput.Location = new System.Drawing.Point(332, 9);
            this.player2scoreOutput.Name = "player2scoreOutput";
            this.player2scoreOutput.Size = new System.Drawing.Size(20, 24);
            this.player2scoreOutput.TabIndex = 4;
            this.player2scoreOutput.Text = "0";
            this.player2scoreOutput.DoubleClick += new System.EventHandler(this.player2scoreLabel_DoubleClick);
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // winLabel
            // 
            this.winLabel.AutoSize = true;
            this.winLabel.BackColor = System.Drawing.Color.Black;
            this.winLabel.Location = new System.Drawing.Point(238, 156);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(0, 13);
            this.winLabel.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.winLabel);
            this.Controls.Add(this.player2scoreOutput);
            this.Controls.Add(this.player1scoreOutput);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label player1scoreOutput;
        private System.Windows.Forms.Label player2scoreOutput;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label winLabel;
    }
}

