using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OutlandSpace.UI.Prototype.Paint;


namespace OutlandSpace.UI.Prototype
{
    public partial class ScreenCommonDialog : Form
    {
        private static readonly Color BackgroundColor = Color.FromArgb(20, 35, 45);
        private static readonly Color LeftTopTitleColor = Color.FromArgb(235, 25, 85);
        private static readonly Color MainTopTitleColor = Color.FromArgb(35, 60, 90);
        private static readonly Color ControlSurfaceColor = Color.FromArgb(15, 25, 35);

        private static readonly int Buttons = 3;

        private const int BaseInterval = 4;
        private const int BorderSize = 6;
        private const int BaseMargin = 16;

        private const int ButtonBorder = 2;
        private const int ButtonHeight = 24;

        private const int ScreenWidth = 900;
        private const int ScreenHeight = 450;
        private static readonly Rectangle FullWorkScreenSurface = new Rectangle(BaseMargin, BaseMargin, ScreenWidth - 2 * BaseMargin, ScreenHeight - 2 * BaseMargin);

        private static readonly Rectangle TopTitle = new Rectangle(FullWorkScreenSurface.Left, FullWorkScreenSurface.Top, ScreenWidth - 2 * BaseMargin, BaseMargin);
        private static readonly Rectangle LeftTopTitle = new Rectangle(TopTitle.Left, TopTitle.Top, 54, TopTitle.Height);
        private static readonly Rectangle MainTopTitle = new Rectangle(TopTitle.Left + LeftTopTitle.Width + BaseInterval, TopTitle.Top, TopTitle.Width - LeftTopTitle.Width - BaseInterval, TopTitle.Height);
        private static readonly Rectangle MainBorderSurface = new Rectangle(TopTitle.Left, TopTitle.Top + TopTitle.Height + BaseInterval, TopTitle.Width, FullWorkScreenSurface.Height - TopTitle.Height - BaseInterval);

        private static readonly Rectangle ControlSurface = new Rectangle(MainBorderSurface.Left + BorderSize, MainBorderSurface.Top + BorderSize, MainBorderSurface.Width - 2 * BorderSize, MainBorderSurface.Height - 2 * BorderSize - ButtonHeight);
        private static readonly Rectangle ButtonSurface = new Rectangle(TopTitle.Left, FullWorkScreenSurface.Height + FullWorkScreenSurface.Top + BaseInterval, FullWorkScreenSurface.Width, ButtonHeight);

        private readonly List<DialogButton> _buttonsCollection = new List<DialogButton>();

        public ScreenCommonDialog()
        {
            InitializeComponent();

            Size = new Size(ScreenWidth, ScreenHeight + Buttons * (ButtonHeight + BaseInterval));

            for (var i = 0; i < Buttons; i++)
            {
                _buttonsCollection.Add(new DialogButton(ButtonSurface, i, this));
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // get the graphics object to use to draw
            var g = pe.Graphics;

            // Background
            g.FillRectangle(new SolidBrush(BackgroundColor), 0, 0, Width, Height);

            //g.FillRectangle(new SolidBrush(Color.FromArgb(235, 25, 85)), FullWorkScreenSurface);

            g.FillRectangle(new SolidBrush(LeftTopTitleColor), LeftTopTitle);

            g.FillRectangle(new SolidBrush(MainTopTitleColor), MainTopTitle);

            g.FillRectangle(new SolidBrush(MainTopTitleColor), MainBorderSurface);

            g.FillRectangle(new SolidBrush(ControlSurfaceColor), ControlSurface);

            foreach (var dialogButton in _buttonsCollection)
            {
                dialogButton.Draw(g);
            }
        }
    }
}
