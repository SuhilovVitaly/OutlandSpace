using System;
using System.Drawing;
using System.Windows.Forms;

namespace OutlandSpace.UI.Prototype.Paint
{
    public class DialogButton
    {
        public Rectangle ButtonSurface { get; }
        private readonly int Position;

        private const int BaseInterval = 4;
        private const int ButtonBorder = 2;
        private const int ButtonHeight = 24;

        private static readonly Color MainTopTitleColor = Color.FromArgb(35, 60, 90);
        private static readonly Color BackColorActive = Color.FromArgb(15, 15, 15);
        private static readonly Color ControlSurfaceColor = Color.FromArgb(15, 25, 35);
        private static readonly Color LeftTopTitleColor = Color.FromArgb(235, 25, 85);
        private static readonly Color ForeColor = Color.FromArgb(90, 155, 210);

        private Control Parent;

        private bool _isActive;
        private readonly string Text;

        public DialogButton(Control parent)
        {
            Parent = parent;

            parent.Click += Event_Click;
            parent.MouseMove += Event_MouseMove;
        }

        public DialogButton(Rectangle buttonSurface, int position, Form parent) : this(parent)
        {
            Position = position;
            Text = $@"Text example for Button {Position}";
            ButtonSurface = new Rectangle(buttonSurface.Left, buttonSurface.Top + Position * (ButtonHeight + BaseInterval), buttonSurface.Width, buttonSurface.Height);// buttonSurface;
        }

        private void Event_MouseMove(object sender, MouseEventArgs e)
        {
            var cursorPosition = e.Location;

            bool isNeedRefreshParent = _isActive;

            if (ButtonSurface.Contains(cursorPosition))
            {
                _isActive = true;
            }
            else
            {
                _isActive = false;
            }

            if (isNeedRefreshParent != _isActive)
            {
                //if (_isActive)
                //{
                //    Cursor.Current = Cursors.Hand;
                //}
                //else
                //{
                //    Cursor.Current = Cursors.Default;
                //}
                //Cursor.Current = Cursors.Hand;

                Parent.Refresh();
            }
        }

        private void Event_Click(object? sender, EventArgs e)
        {
            var cursorPosition = Parent.PointToClient(Cursor.Position);

            if (!ButtonSurface.Contains(cursorPosition)) return;

            Application.Exit();
            //MessageBox.Show($@"Control position is {Position}");
        }

        public void Draw(Graphics graphics)
        {
            var buttonSurface = new Rectangle(ButtonSurface.Left, ButtonSurface.Top, ButtonSurface.Width, ButtonSurface.Height);
            var buttonPointerSurface = new Rectangle(buttonSurface.Left + ButtonBorder,
                buttonSurface.Top + ButtonBorder, 30, buttonSurface.Height - 2 * ButtonBorder);

            var buttonWorkSurface = new Rectangle(
                buttonSurface.Left + 2 * ButtonBorder + 30,
                buttonSurface.Top + ButtonBorder,
                buttonSurface.Width - buttonPointerSurface.Width - 3 * ButtonBorder,
                buttonSurface.Height - 2 * ButtonBorder);

            var buttonActiveSurface = new Rectangle(
                buttonSurface.Left + BaseInterval / 2,
                buttonSurface.Top + ButtonHeight + BaseInterval / 2,
                buttonSurface.Width - BaseInterval,
                BaseInterval / 2
            );

            var textLocation = new Point(buttonWorkSurface.Left + 20, buttonWorkSurface.Top + 2);
            var iconLocation = new Point(buttonPointerSurface.Left + 12, buttonPointerSurface.Top + 5);

            // Border
            graphics.FillRectangle(new SolidBrush(MainTopTitleColor), buttonSurface);

            // Active icon
            if (_isActive)
            {
                // Pointer
                graphics.FillRectangle(new SolidBrush(BackColorActive), buttonPointerSurface);

                DrawSelectedIcon(graphics, iconLocation, LeftTopTitleColor);

                // Work space
                graphics.FillRectangle(new SolidBrush(BackColorActive), buttonWorkSurface);

                // Underline
                graphics.FillRectangle(new SolidBrush(LeftTopTitleColor), buttonActiveSurface);

                DrawText(graphics, textLocation, Text, LeftTopTitleColor);
            }
            else
            {
                // Pointer
                graphics.FillRectangle(new SolidBrush(ControlSurfaceColor), buttonPointerSurface);

                // Work space
                graphics.FillRectangle(new SolidBrush(ControlSurfaceColor), buttonWorkSurface);

                DrawText(graphics, textLocation, Text, ForeColor);
            }
        }

        private static void DrawText(Graphics graphics, Point location, string text, Color foreColor)
        {
            var drawFont = new Font("Arial", 10, FontStyle.Bold);
            var drawBrush = new SolidBrush(foreColor);
            var drawFormat = new StringFormat();

            graphics.DrawString(text, drawFont, drawBrush, location, drawFormat);
        }

        public void DrawSelectedIcon(Graphics graphics, Point location, Color foreColor)
        {
            graphics.FillPolygon(new SolidBrush(foreColor), new[]
            {
                new PointF(location.X, location.Y),
                new PointF(location.X + 8, location.Y + 5),
                new PointF(location.X, location.Y + 10)
            });
        }
    }
}