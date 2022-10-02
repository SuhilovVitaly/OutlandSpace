
namespace OutlandSpace.UI.Screens
{
    partial class WindowMenu
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
            this.button4 = new System.Windows.Forms.Button();
            this.cmdCloseGame = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cmdStartNewGame = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DimGray;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button4.Location = new System.Drawing.Point(15, 130);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(188, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "About";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // cmdCloseGame
            // 
            this.cmdCloseGame.BackColor = System.Drawing.Color.DimGray;
            this.cmdCloseGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdCloseGame.FlatAppearance.BorderSize = 0;
            this.cmdCloseGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCloseGame.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCloseGame.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cmdCloseGame.Location = new System.Drawing.Point(15, 197);
            this.cmdCloseGame.Name = "cmdCloseGame";
            this.cmdCloseGame.Size = new System.Drawing.Size(188, 23);
            this.cmdCloseGame.TabIndex = 5;
            this.cmdCloseGame.Text = "Exit";
            this.cmdCloseGame.UseVisualStyleBackColor = false;
            this.cmdCloseGame.Click += new System.EventHandler(this.cmdCloseGame_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DimGray;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button3.Location = new System.Drawing.Point(15, 91);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(188, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Settings";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // cmdStartNewGame
            // 
            this.cmdStartNewGame.BackColor = System.Drawing.Color.DimGray;
            this.cmdStartNewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdStartNewGame.FlatAppearance.BorderSize = 0;
            this.cmdStartNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdStartNewGame.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStartNewGame.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cmdStartNewGame.Location = new System.Drawing.Point(15, 14);
            this.cmdStartNewGame.Name = "cmdStartNewGame";
            this.cmdStartNewGame.Size = new System.Drawing.Size(188, 23);
            this.cmdStartNewGame.TabIndex = 6;
            this.cmdStartNewGame.Text = "Start new game";
            this.cmdStartNewGame.UseVisualStyleBackColor = false;
            this.cmdStartNewGame.Click += new System.EventHandler(this.cmdStartNewGame_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DimGray;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Location = new System.Drawing.Point(15, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Load game";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdStartNewGame);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.cmdCloseGame);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 236);
            this.panel1.TabIndex = 10;
            // 
            // WindowMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(240, 261);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowMenu";
            this.Text = "WindowMenu";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button cmdCloseGame;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button cmdStartNewGame;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
    }
}