using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlandSpace.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.ClientSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Left, Screen.PrimaryScreen.WorkingArea.Top);

            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;

            UpdateStyles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Location = new Point(0, 0);

            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            Size = Screen.PrimaryScreen.Bounds.Size;

            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //this.WindowState = FormWindowState.Maximized;

            //BringToTop();

            //FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //Left = Top = 0;
            // Width = Screen.PrimaryScreen.WorkingArea.Width;
            // Height = Screen.PrimaryScreen.WorkingArea.Height;


            //this.TopMost = true;
            //Screen currentScreen = Screen.FromHandle(this.Handle);
            //this.Size = new System.Drawing.Size(currentScreen.Bounds.Width, currentScreen.Bounds.Height);

            //TopMost = true;

            //this.Focus();

            //TopMost = false;

        }

        private void cmdCloseGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void BringToTop()
        {
            //Checks if the method is called from UI thread or not
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(BringToTop));
            }
            else
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                //Keeps the current topmost status of form
                bool top = TopMost;
                //Brings the form to top
                TopMost = true;
                //Set form's topmost status back to whatever it was
                TopMost = top;
            }
        }
    }
}
