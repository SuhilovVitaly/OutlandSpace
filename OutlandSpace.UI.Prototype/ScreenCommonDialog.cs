using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using OutlandSpace.UI.Prototype.Paint;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;


namespace OutlandSpace.UI.Prototype
{
    public partial class ScreenCommonDialog : Form
    {
        private static readonly Color BackgroundColor = Color.FromArgb(30, 45, 65);
        private static readonly Color LeftTopTitleColor = Color.FromArgb(235, 25, 85);
        private static readonly Color MainTopTitleColor = Color.FromArgb(35, 60, 90);
        private static readonly Color ControlSurfaceColor = Color.FromArgb(15, 25, 35);

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
        private static readonly Rectangle TextSurface = new Rectangle(ControlSurface.Left, ControlSurface.Top, 350, ControlSurface.Height);
        private static readonly Rectangle ButtonSurface = new Rectangle(TopTitle.Left, FullWorkScreenSurface.Height + FullWorkScreenSurface.Top + BaseInterval, FullWorkScreenSurface.Width, ButtonHeight);

        private readonly IGameTurnSnapshot _snapshot;
        private readonly IDialog _dialog;
        private readonly List<DialogButton> _buttonsCollection = new List<DialogButton>();

        public ScreenCommonDialog(IGameTurnSnapshot snapshot, IDialog dialog)
        {
            InitializeComponent();

            _snapshot = snapshot;
            _dialog = dialog;

            Size = new Size(ScreenWidth, ScreenHeight + dialog.Exits.Count * (ButtonHeight + BaseInterval));

            var position = 0;

            foreach (var dialogExit in dialog.Exits)
            {
                _buttonsCollection.Add(new DialogButton(ButtonSurface, position, dialogExit, this));
                position++;
            }

        }

        private bool isStaticResourcesLoaded;
        private Image backgroundImage;

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (isStaticResourcesLoaded == false)
            {
                backgroundImage = new Bitmap(@"G:\Outland-Resources\DefaultBackground.png");
                isStaticResourcesLoaded = true;
            }

            // get the graphics object to use to draw
            var g = pe.Graphics;

            // Background
            g.FillRectangle(new SolidBrush(BackgroundColor), 0, 0, Width, Height);

            g.FillRectangle(new SolidBrush(LeftTopTitleColor), LeftTopTitle);

            g.FillRectangle(new SolidBrush(MainTopTitleColor), MainTopTitle);

            g.FillRectangle(new SolidBrush(MainTopTitleColor), MainBorderSurface);

            g.FillRectangle(new SolidBrush(ControlSurfaceColor), ControlSurface);

            g.DrawImage(backgroundImage, ControlSurface);

            var blackTextArea = new Rectangle(TextSurface.Left, TextSurface.Top, 300, TextSurface.Height);
            g.FillRectangle(new SolidBrush(Color.Black), blackTextArea);

            var transparentTextArea = new Rectangle(
                blackTextArea.Right, 
                blackTextArea.Top, 
                ControlSurface.Width - blackTextArea.Width,
                blackTextArea.Height);

            var brush = new LinearGradientBrush(transparentTextArea, Color.Black, Color.Transparent, LinearGradientMode.Horizontal);

            g.FillRectangle(brush, transparentTextArea);

            var drawFont = new Font("Arial", 10, FontStyle.Bold);
            var drawBrush = new SolidBrush(Color.AliceBlue);
            var drawFormat = new StringFormat();

            var textArea = new Rectangle(
                blackTextArea.Left + BaseMargin,
                blackTextArea.Top + BaseMargin,
                blackTextArea.Width - 2 * BaseMargin,
                blackTextArea.Height - 2 * BaseMargin);

            g.DrawString(_dialog.Text.Replace("<BR>", @"\r\n"), drawFont, drawBrush, textArea, drawFormat);

            foreach (var dialogButton in _buttonsCollection)
            {
                dialogButton.Draw(g);
            }
        }
    }
}
