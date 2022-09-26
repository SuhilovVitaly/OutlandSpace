using System.Collections.Generic;
using System.Windows.Forms;
using OutlandSpace.Controller;
using OutlandSpace.UI.Screens;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.UI
{
    public class UiManager
    {
        private List<Form> _screens;

        public UiManager(GameManager game)
        {
            _screens = new List<Form>
            {
                new Form1(),
                new WindowBackGround()
            };
            game.OnStartGame += Event_StartGame;
        }

        public Form GetScreen(string key)
        {
            foreach (var screen in _screens)
            {
                if (screen is Form1 && key == "Form1") return screen;
                if (screen is WindowBackGround && key == "WindowBackGround") return screen;
            }
            return null;
        }

        private void Event_StartGame(IGameTurnSnapshot snapshot)
        {
            var backGroundScreen = GetScreen("WindowBackGround");
            var menuScreen = GetScreen("Form1");

            backGroundScreen.Visible = true;
            backGroundScreen.Show();
            backGroundScreen.BringToFront();

            menuScreen.Visible = false;
            menuScreen.Hide();
        }
    }
}