using System.Drawing;
using System.Windows.Forms;
using OutlandSpace.Universe.Engine.Session;

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

            if (Global.Game is null) return;

            Global.Game.OnReceivedDialog += Event_ReceivedDialog;
        }

        private void Event_ReceivedDialog(IGameTurnSnapshot snapshot)
        {
            var windowDialog = new WindowDialog(snapshot);

            var result = OpenModalForm(windowDialog);
        }

        private delegate DialogResult RefreshCallback(Form screen);

        private DialogResult OpenModalForm(Form screen)
        {
            Form mainForm = this;

            switch (mainForm.InvokeRequired)
            {
                case true:
                {
                    RefreshCallback d = OpenModalForm;
                    return (DialogResult)mainForm.Invoke(d, screen);
                }
                default:
                    return screen.ShowDialog();
            }
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
