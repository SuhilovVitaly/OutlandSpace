
namespace OutlandSpace.UI.Screens
{
    partial class WindowTacticalMap
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.controlSessionInfo1 = new OutlandSpace.UI.Controls.ControlSessionInfo();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.controlSessionInfo1);
            this.panel1.Location = new System.Drawing.Point(1179, 763);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 66);
            this.panel1.TabIndex = 0;
            // 
            // controlSessionInfo1
            // 
            this.controlSessionInfo1.BackColor = System.Drawing.Color.Black;
            this.controlSessionInfo1.Location = new System.Drawing.Point(3, 3);
            this.controlSessionInfo1.Name = "controlSessionInfo1";
            this.controlSessionInfo1.Size = new System.Drawing.Size(200, 66);
            this.controlSessionInfo1.TabIndex = 0;
            // 
            // WindowTacticalMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1391, 841);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowTacticalMap";
            this.Text = "WindowTacticalMap";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Controls.ControlSessionInfo controlSessionInfo1;
    }
}