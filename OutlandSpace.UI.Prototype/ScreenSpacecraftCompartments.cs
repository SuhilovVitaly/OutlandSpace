using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OutlandSpace.UI.Prototype.Paint;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.UI.Prototype
{
    public partial class ScreenSpacecraftCompartments : Form
    {
        private Spacecraft Spacecraft;

        public ScreenSpacecraftCompartments(Spacecraft spacecraft)
        {
            Spacecraft = spacecraft;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            SpacecraftCompartments.Draw(pe.Graphics, Spacecraft);
        }
    }
}
