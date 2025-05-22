using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerEstrella
{
    public partial class FrmEstrella : Form
    {
        private Estrella objEstrella = new Estrella();
        public FrmEstrella()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void FrmEstrella_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    objEstrella.Mover("arriba");
                    break;
                case Keys.Down:
                    objEstrella.Mover("abajo");
                    break;
                case Keys.Left:
                    objEstrella.Mover("izquierda");
                    break;
                case Keys.Right:
                    objEstrella.Mover("derecha");
                    break;
                case Keys.R:
                    objEstrella.Rotar("horario");
                    break;
                case Keys.L:
                    objEstrella.Rotar("antihorario");
                    break;
            }
            objEstrella.PlotShape(picCanvas);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            objEstrella.ReadData(trackBar1);
            objEstrella.PlotShape(picCanvas);
            this.ActiveControl = null;
        }

        private void trackBar1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void trackBar1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
