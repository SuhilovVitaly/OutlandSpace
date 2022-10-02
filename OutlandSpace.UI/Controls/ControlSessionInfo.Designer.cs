
namespace OutlandSpace.UI.Controls
{
    partial class ControlSessionInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSessionTurn = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSessionStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSessionTurn
            // 
            this.lblSessionTurn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSessionTurn.Location = new System.Drawing.Point(45, 20);
            this.lblSessionTurn.Name = "lblSessionTurn";
            this.lblSessionTurn.Size = new System.Drawing.Size(52, 17);
            this.lblSessionTurn.TabIndex = 7;
            this.lblSessionTurn.Text = "0";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(3, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Turn:";
            // 
            // lblSessionStatus
            // 
            this.lblSessionStatus.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSessionStatus.Location = new System.Drawing.Point(45, 3);
            this.lblSessionStatus.Name = "lblSessionStatus";
            this.lblSessionStatus.Size = new System.Drawing.Size(52, 17);
            this.lblSessionStatus.TabIndex = 5;
            this.lblSessionStatus.Text = "Paused";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Status:";
            // 
            // ControlSessionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lblSessionTurn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSessionStatus);
            this.Controls.Add(this.label1);
            this.Name = "ControlSessionInfo";
            this.Size = new System.Drawing.Size(200, 66);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSessionTurn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSessionStatus;
        private System.Windows.Forms.Label label1;
    }
}
