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
            this.lbl_score.BackColor = System.Drawing.Color.DimGray;
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
            this.lbl_level.BackColor = System.Drawing.Color.DimGray;
            this.lbl_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_level.ForeColor = System.Drawing.Color.OldLace;
            this.lbl_level.Location = new System.Drawing.Point(733, 13);
            this.lbl_level.Name = "lbl_level";
            this.lbl_level.Size = new System.Drawing.Size(23, 16);
            this.lbl_level.TabIndex = 1;
            this.lbl_level.Text = "00";
            // 
            // BreakOutGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.lbl_level);
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
    }
}

