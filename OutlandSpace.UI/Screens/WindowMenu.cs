using System;
using System.Drawing;
using System.Windows.Forms;

namespace OutlandSpace.UI.Screens
{
    public partial class WindowMenu : Form
    {
        public WindowMenu()
        {
            InitializeComponent();
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
