namespace BreakOut_Prototype
{
    partial class BreakOutGame
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pic_canvas = new System.Windows.Forms.PictureBox();
            this.lbl_score = new System.Windows.Forms.Label();
            this.lbl_level = new System.Windows.Forms.Label();
            this.lbl_retry = new System.Windows.Forms.Label();
            this.lbl_quit = new System.Windows.Forms.Label();
            this.lbl_score02 = new System.Windows.Forms.Label();
            this.lbl_nl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 16;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pic_canvas
            // 
            this.pic_canvas.BackColor = System.Drawing.Color.Transparent;
            this.pic_canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_canvas.Location = new System.Drawing.Point(0, 0);
            this.pic_canvas.Name = "pic_canvas";
            this.pic_canvas.Size = new System.Drawing.Size(784, 461);
            this.pic_canvas.TabIndex = 0;
            this.pic_canvas.TabStop = false;
            // 
            // lbl_score
            // 
            this.lbl_score.AutoSize = true;
            this.lbl_score.BackColor = System.Drawing.Color.Transparent;
            this.lbl_score.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_score.ForeColor = System.Drawing.Color.OldLace;
            this.lbl_score.Location = new System.Drawing.Point(13, 13);
            this.lbl_score.Name = "lbl_score";
            this.lbl_score.Size = new System.Drawing.Size(39, 16);
            this.lbl_score.TabIndex = 1;
            this.lbl_score.Text = "0000";
            // 
            // lbl_level
            // 
            this.lbl_level.AutoSize = true;
            this.lbl_level.BackColor = System.Drawing.Color.Transparent;
            this.lbl_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_level.ForeColor = System.Drawing.Color.OldLace;
            this.lbl_level.Location = new System.Drawing.Point(733, 13);
            this.lbl_level.Name = "lbl_level";
            this.lbl_level.Size = new System.Drawing.Size(23, 16);
            this.lbl_level.TabIndex = 1;
            this.lbl_level.Text = "00";
            // 
            // lbl_retry
            // 
            this.lbl_retry.AutoSize = true;
            this.lbl_retry.BackColor = System.Drawing.Color.Transparent;
            this.lbl_retry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_retry.Font = new System.Drawing.Font("MS PGothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_retry.ForeColor = System.Drawing.Color.Black;
            this.lbl_retry.Location = new System.Drawing.Point(339, 225);
            this.lbl_retry.Name = "lbl_retry";
            this.lbl_retry.Size = new System.Drawing.Size(98, 27);
            this.lbl_retry.TabIndex = 1;
            this.lbl_retry.Text = "RETRY";
            this.lbl_retry.Visible = false;
            this.lbl_retry.Click += new System.EventHandler(this.lbl_retry_Click);
            // 
            // lbl_quit
            // 
            this.lbl_quit.AutoSize = true;
            this.lbl_quit.BackColor = System.Drawing.Color.Transparent;
            this.lbl_quit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_quit.Font = new System.Drawing.Font("MS PGothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_quit.ForeColor = System.Drawing.Color.Black;
            this.lbl_quit.Location = new System.Drawing.Point(348, 300);
            this.lbl_quit.Name = "lbl_quit";
            this.lbl_quit.Size = new System.Drawing.Size(75, 27);
            this.lbl_quit.TabIndex = 1;
            this.lbl_quit.Text = "QUIT";
            this.lbl_quit.Visible = false;
            this.lbl_quit.Click += new System.EventHandler(this.lbl_quit_Click);
            // 
            // lbl_score02
            // 
            this.lbl_score02.AutoSize = true;
            this.lbl_score02.BackColor = System.Drawing.Color.Transparent;
            this.lbl_score02.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_score02.Font = new System.Drawing.Font("MS PGothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_score02.ForeColor = System.Drawing.Color.Black;
            this.lbl_score02.Location = new System.Drawing.Point(322, 144);
            this.lbl_score02.Name = "lbl_score02";
            this.lbl_score02.Size = new System.Drawing.Size(126, 27);
            this.lbl_score02.TabIndex = 1;
            this.lbl_score02.Text = "SOCRE : ";
            this.lbl_score02.Visible = false;
            this.lbl_score02.Click += new System.EventHandler(this.lbl_retry_Click);
            // 
            // lbl_nl
            // 
            this.lbl_nl.AutoSize = true;
            this.lbl_nl.BackColor = System.Drawing.Color.Transparent;
            this.lbl_nl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_nl.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_nl.ForeColor = System.Drawing.Color.Black;
            this.lbl_nl.Location = new System.Drawing.Point(299, 225);
            this.lbl_nl.Name = "lbl_nl";
            this.lbl_nl.Size = new System.Drawing.Size(171, 27);
            this.lbl_nl.TabIndex = 1;
            this.lbl_nl.Text = "NEXT LEVEL";
            this.lbl_nl.Visible = false;
            this.lbl_nl.Click += new System.EventHandler(this.lbl_nl_Click);
            // 
            // BreakOutGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.lbl_level);
            this.Controls.Add(this.lbl_quit);
            this.Controls.Add(this.lbl_score02);
            this.Controls.Add(this.lbl_retry);
            this.Controls.Add(this.lbl_nl);
            this.Controls.Add(this.lbl_score);
            this.Controls.Add(this.pic_canvas);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BreakOutGame";
            this.Text = "BreakOut Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BreakOutGame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BreakOutGame_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pic_canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pic_canvas;
        private System.Windows.Forms.Label lbl_score;
        private System.Windows.Forms.Label lbl_level;
        private System.Windows.Forms.Label lbl_retry;
        private System.Windows.Forms.Label lbl_quit;
        private System.Windows.Forms.Label lbl_score02;
        private System.Windows.Forms.Label lbl_nl;
    }
}

