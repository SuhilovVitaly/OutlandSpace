using System.Windows.Forms;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.UI.Screens
{
    public partial class WindowTacticalMap : Form
    {
        public WindowTacticalMap()
        {
            InitializeComponent();

            if (Global.Game is null) return;

            Global.Game.OnStartGame += Event_StartGameSession;
        }

        private void Event_StartGameSession(IGameTurnSnapshot snapshot)
        {
            
        }
    }
}
