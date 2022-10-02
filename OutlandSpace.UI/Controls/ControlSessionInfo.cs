using log4net;
using OutlandSpace.UI.Tools;
using OutlandSpace.Universe.Engine.Session;
using System.Reflection;

namespace OutlandSpace.UI.Controls
{
    public partial class ControlSessionInfo : BaseRenderControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public ControlSessionInfo()
        {
            InitializeComponent();

            if (Global.Game == null) return;

            Global.Game.OnStartGame += Event_StartGame;
            Global.Game.OnEndTurn += Event_EndTurn;
        }

        private void Event_EndTurn(IGameTurnSnapshot session)
        {
            Logger.Debug($"Refresh game information for turn '{session.Turn}'.");

            this.PerformSafely(RefreshControl, session);
        }

        private void Event_StartGame(IGameTurnSnapshot session)
        {
            Logger.Debug($"Game with id = '{session.Id} started.");

            this.PerformSafely(RefreshControl, session);
        }

        public void RefreshControl(IGameTurnSnapshot session)
        {
            if (session is null) return;

            lblSessionTurn.Text = @"" + session.Turn + "";
            lblSessionStatus.Text = @"" + ((session.IsPause) ? "Paused" : "Runned");
        }
    }
}
