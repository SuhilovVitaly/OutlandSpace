using System.Windows.Forms;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.UI.Screens
{
    public partial class WindowDialog : Form
    {
        private IGameTurnSnapshot _snapshot;

        public WindowDialog(IGameTurnSnapshot snapshot)
        {
            InitializeComponent();

            _snapshot = snapshot;

            RefreshControl(_snapshot);
        }

        private void RefreshControl(IGameTurnSnapshot snapshot)
        {
            lblDialogId.Text = _snapshot.Interaction.RootDialog.Id;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Global.Game.ResumeSession();
            Close();
        }

        private void WindowDialog_Load(object sender, System.EventArgs e)
        {
            
        }
    }
}
