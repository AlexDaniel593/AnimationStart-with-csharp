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
    public partial class FrmIndex : Form
    {
        public FrmIndex()
        {
            InitializeComponent();
        }

        private void OpenForm(Form formulario)
        {
            panelContenedor.Controls.Clear();     // Limpiar contenido anterior
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void estrella1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmEstrellaMultiple());
        }

        private void estrella2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmEstrella());
        }
    }
}
