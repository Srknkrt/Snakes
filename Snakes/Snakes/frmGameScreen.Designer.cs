
namespace Snakes
{
    partial class frmGameScreen
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
            this.pcbArea = new System.Windows.Forms.PictureBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.tGameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.tPaused = new System.Windows.Forms.Timer(this.components);
            this.mstOptions = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.pcbArea)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbArea
            // 
            this.pcbArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pcbArea.Location = new System.Drawing.Point(2, 27);
            this.pcbArea.Name = "pcbArea";
            this.pcbArea.Size = new System.Drawing.Size(806, 436);
            this.pcbArea.TabIndex = 0;
            this.pcbArea.TabStop = false;
            this.pcbArea.Paint += new System.Windows.Forms.PaintEventHandler(this.pcbArea_Paint);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblScore.Location = new System.Drawing.Point(595, 4);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(55, 20);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "Score:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDescription.Location = new System.Drawing.Point(329, 205);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(0, 20);
            this.lblDescription.TabIndex = 3;
            // 
            // tPaused
            // 
            this.tPaused.Interval = 1000;
            this.tPaused.Tick += new System.EventHandler(this.tPaused_Tick);
            // 
            // mstOptions
            // 
            this.mstOptions.BackColor = System.Drawing.SystemColors.MenuBar;
            this.mstOptions.Location = new System.Drawing.Point(0, 0);
            this.mstOptions.Name = "mstOptions";
            this.mstOptions.Size = new System.Drawing.Size(812, 24);
            this.mstOptions.TabIndex = 4;
            this.mstOptions.Text = "menuStrip1";
            // 
            // frmGameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(812, 471);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.mstOptions);
            this.Controls.Add(this.pcbArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGameScreen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snakes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGameScreen_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGameScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmGameScreen_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcbArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbArea;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer tGameTimer;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Timer tPaused;
        private System.Windows.Forms.MenuStrip mstOptions;
    }
}