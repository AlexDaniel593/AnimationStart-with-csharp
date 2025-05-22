using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerEstrella
{
    internal class EstrellaMultiple
    {

        private float mRadio;
        private float offsetX, offsetY;
        private float angulo;
        private Graphics mGraph;
        private const float SF = 5;
        private Pen mPen;

        public EstrellaMultiple()
        {
            mRadio = 0.0f;
            offsetX = 0;
            offsetY = 0;
            angulo = 0;
        }

        public void ReadData(TrackBar trackBar)
        {
            mRadio = trackBar.Value;
        }

        public void InitializeData(PictureBox picCanvas, TrackBar trackBar)
        {
            mRadio = 0.0f;
            offsetX = 0;
            offsetY = 0;
            angulo = 0;
            trackBar.Value = 1;
            picCanvas.Refresh();
        }

        public void Mover(string direccion)
        {
            float paso = 10;

            switch (direccion)
            {
                case "arriba": offsetY -= paso; break;
                case "abajo": offsetY += paso; break;
                case "izquierda": offsetX -= paso; break;
                case "derecha": offsetX += paso; break;
            }
        }

        public void Rotar(string sentido)
        {
            float paso = 10;
            if (sentido == "horario")
                angulo += paso;
            else if (sentido == "antihorario")
                angulo -= paso;
        }

        public void PlotShape(PictureBox picCanvas)
        {
            picCanvas.Refresh();
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.BlueViolet, 1);

            float scaledRadius = mRadio * SF;
            PointF center = new PointF(picCanvas.Width / 2f + offsetX, picCanvas.Height / 2f + offsetY);

            PointF[] outerPoints = new PointF[5];
            PointF[] innerPoints = new PointF[5];

            double angleRad = -Math.PI / 2 + angulo * Math.PI / 180.0; 
            double step = Math.PI * 2 / 5;

            // Puntos externos
            for (int i = 0; i < 5; i++)
            {
                float x = center.X + scaledRadius * (float)Math.Cos(angleRad);
                float y = center.Y + scaledRadius * (float)Math.Sin(angleRad);
                outerPoints[i] = new PointF(x, y);
                angleRad += step;
            }

            // Reiniciar para los puntos internos
            angleRad = -Math.PI / 2 + step / 2 + angulo * Math.PI / 180.0;
            float innerRadius = scaledRadius * 0.5f; // Escala interna

            for (int i = 0; i < 5; i++)
            {
                float x = center.X + innerRadius * (float)Math.Cos(angleRad);
                float y = center.Y + innerRadius * (float)Math.Sin(angleRad);
                innerPoints[i] = new PointF(x, y);
                angleRad += step;
            }

            // Dibujo estrella externa
            for (int i = 0; i < 5; i++)
            {
                mGraph.DrawLine(mPen, outerPoints[i], innerPoints[i]);
                mGraph.DrawLine(mPen, innerPoints[i], outerPoints[(i + 1) % 5]);
            }

            // Dibujo líneas internas 
            for (int i = 0; i < 5; i++)
            {
                mGraph.DrawLine(mPen, center, outerPoints[i]);
                mGraph.DrawLine(mPen, outerPoints[i], outerPoints[(i + 2) % 5]);
                mGraph.DrawLine(mPen, outerPoints[i], innerPoints[(i + 2) % 5]);
            }
        }


    }
}
