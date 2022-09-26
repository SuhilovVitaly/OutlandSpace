using System;
using System.Drawing;
using System.Windows.Forms;

namespace OutlandSpace.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ClientSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Left, Screen.PrimaryScreen.WorkingArea.Top);

            MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            WindowState = FormWindowState.Maximized;

            UpdateStyles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Location = new Point(0, 0);

            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            Size = Screen.PrimaryScreen.Bounds.Size;
        }

        private void cmdCloseGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdStartNewGame_Click(object sender, EventArgs e)
        {
            Global.Game.StartGameSession();
        }
    }
}
