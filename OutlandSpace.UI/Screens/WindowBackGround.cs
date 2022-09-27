using System.Drawing;
using System.Windows.Forms;

namespace OutlandSpace.UI.Screens
{
    public sealed partial class WindowBackGround : Form
    {
        public WindowBackGround()
        {
            InitializeComponent();

            Location = new Point(0, 0);

            ShowInTaskbar = true;
            ShowIcon = false;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void WindowBackGround_Load(object sender, System.EventArgs e)
        {
            Global.Orchestration.Initialization();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Global.Orchestration.ShowScreen("WindowAbout");
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            Global.Orchestration.ShowScreen("WindowMenu");
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            Global.Orchestration.ShowScreen("WindowMenu", false);
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            Global.Game.ResumeSession();
        }
    }
}
