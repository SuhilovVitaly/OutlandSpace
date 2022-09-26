using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OutlandSpace.Controller;
using OutlandSpace.UI.Screens;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.UI
{
    public class UiManager
    {
        private readonly List<Form> _screens;

        public UiManager(GameManager game)
        {
            _screens = new List<Form>
            {
                new WindowBackGround(),
                new WindowMenu(),
                new WindowAbout(),
                new WindowTacticalMap()
            };
            game.OnStartGame += Event_StartGame;
        }

        public void Initialization()
        {
            var windowTacticalScreen = GetScreen("WindowTacticalMap");

            windowTacticalScreen.Size = Screen.PrimaryScreen.Bounds.Size;

            ShowScreen("WindowMenu");
        }

        public void ShowScreen(string key, bool isShowSingleScreen = true)
        {
            var backGroundScreen = GetScreen("WindowBackGround") as WindowBackGround;

            var screen = GetScreen(key);

            screen.TopLevel = false;

            if (backGroundScreen == null) return;

            if (isShowSingleScreen)
            {
                backGroundScreen.pnlContainer.Controls.Add(screen);

                backGroundScreen.pnlContainer.Size = new Size(screen.Width, screen.Height);
                backGroundScreen.pnlContainer.Left = (backGroundScreen.Width - screen.Width) / 2;
                backGroundScreen.pnlContainer.Top = (backGroundScreen.Height - screen.Height) / 2;

                foreach (Control pnlContainerControl in backGroundScreen.pnlContainer.Controls)
                {
                    if (pnlContainerControl.Name != key)
                    {
                        pnlContainerControl.Visible = false;
                    }
                    else
                    {
                        pnlContainerControl.Location = new Point(0, 0);

                        pnlContainerControl.Visible = true;
                        
                        pnlContainerControl.BringToFront();
                    }
                }
            }
            else
            {
                backGroundScreen.pnlContainer.Controls.Add(screen);

                foreach (Control pnlContainerControl in backGroundScreen.pnlContainer.Controls)
                {
                    

                    if (pnlContainerControl.Name != key) continue;

                    pnlContainerControl.Size = new Size(screen.Width, screen.Height);
                    pnlContainerControl.Left = (backGroundScreen.Width - screen.Width) / 2;
                    pnlContainerControl.Top = (backGroundScreen.Height - screen.Height) / 2;
                    pnlContainerControl.Visible = true;

                    pnlContainerControl.BringToFront();
                    pnlContainerControl.Invalidate();
                }
            }

            screen.Show();
        }

        public Form GetScreen(string key)
        {
            foreach (var screen in _screens)
            {
                switch (screen)
                {
                    case WindowBackGround _ when key == "WindowBackGround":
                        return screen;
                    case WindowMenu _ when key == "WindowMenu":
                        return screen;
                    case WindowAbout _ when key == "WindowAbout":
                        return screen;
                    case WindowTacticalMap _ when key == "WindowTacticalMap":
                        return screen;
                }
            }
            return null;
        }

        private void Event_StartGame(IGameTurnSnapshot snapshot)
        {
            ShowScreen("WindowTacticalMap");
        }
    }
}