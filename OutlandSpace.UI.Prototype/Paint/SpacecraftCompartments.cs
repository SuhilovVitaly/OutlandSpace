using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using OutlandSpace.Universe.Entities.CelestialObjects;
using OutlandSpace.Universe.Entities.Equipment.Compartments;

namespace OutlandSpace.UI.Prototype.Paint
{
    public static class SpacecraftCompartments
    {
        private const int Width = 800;
        private const int Height = 450;
        private const int CellSize = 50;

        private static Color GridColor = Color.FromArgb(30, 45, 65);

        public static void Draw(Graphics graphics, Spacecraft spacecraft)
        {
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), new Rectangle(0, 0, Width, Height));

            DrawGrid(graphics);

            foreach (var compartment in spacecraft.Compartments)
            {
                DrawCompartment(graphics, compartment);
            }
            
        }

        private static void DrawGrid(Graphics graphics)
        {
            for (var i = 0; i < 30; i++)
            {
                graphics.DrawLine(new Pen(GridColor), new Point(i * CellSize, 0), new Point(i * CellSize, Height - 50));
            }

            for (var i = 0; i < 16; i++)
            {
                graphics.DrawLine(new Pen(GridColor), new Point(0, i * CellSize), new Point(Width, i * CellSize));
            }
        }

        private static void DrawCompartment(Graphics graphics, ICompartment compartment)
        {
            var pointLeftTop = new Point(compartment.X * CellSize, compartment.Y * CellSize);

            // Draw Background
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(230, 230, 230)), 
                new Rectangle(
                    pointLeftTop.X,
                    pointLeftTop.Y,
                    compartment.Width * CellSize,
                    compartment.Height * CellSize));

            var gridColor = Color.FromArgb(180, 180, 180);

            // Draw Grid
            for (var i = 0; i < compartment.Width; i++)
            {
                graphics.DrawLine(new Pen(gridColor), new Point((compartment.X + i) * CellSize, (compartment.Y + 0) * CellSize), new Point((compartment.X + i) * CellSize, (compartment.Y + compartment.Height) * CellSize));
            }

            for (var i = 0; i < compartment.Height; i++)
            {
                graphics.DrawLine(new Pen(gridColor), new Point((compartment.X + 0) * CellSize, (compartment.Y + i) * CellSize), new Point((compartment.X + compartment.Width) * CellSize, (compartment.Y + i) * CellSize));
            }

            // Draw walls
            graphics.DrawRectangle(new Pen(Color.Black, 4), new Rectangle(pointLeftTop.X, pointLeftTop.Y, (compartment.Width) * CellSize, (compartment.Height) * CellSize));

        }
    }
}
