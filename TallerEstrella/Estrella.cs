using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TallerEstrella
{
   
        internal class Estrella
        {
            private float mRadio;
            private float offsetX, offsetY;
            private float angulo;
            private Graphics mGraph;
            private const float SF = 5;
            private Pen mPen;

            public Estrella()
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
            mPen = new Pen(Color.DeepSkyBlue, 1);

            float rExterno = mRadio * SF;
            float cx = picCanvas.Width / 2 + offsetX;
            float cy = picCanvas.Height / 2 + offsetY;

            List<PointF> verticesExternos = new List<PointF>();
            List<PointF> verticesInternos = new List<PointF>();

            
            float angBase = (float)(Math.PI / 2 + angulo * Math.PI / 180.0);


            for (int i = 0; i < 10; i++)
            {
                float radio = (i % 2 == 0) ? rExterno : rExterno * (float)Math.Sin(Math.PI / 10) / (float)Math.Sin(3 * Math.PI / 10); // proporción dorada
                float ang = angBase + i * (float)(Math.PI / 5); // 36°
                float x = cx + radio * (float)Math.Cos(ang);
                float y = cy - radio * (float)Math.Sin(ang);

                if (i % 2 == 0)
                    verticesExternos.Add(new PointF(x, y));
                else
                    verticesInternos.Add(new PointF(x, y));
            }

            // Dibujar estrella exterior 
            for (int i = 0; i < 5; i++)
            {
                int j = (i + 2) % 5;
                mGraph.DrawLine(mPen, verticesExternos[i], verticesExternos[j]);
            }

            // Dibujar estrella interior conectando los vértices internos
            for (int i = 0; i < 5; i++)
            {
                int j = (i + 2) % 5;
                mGraph.DrawLine(mPen, verticesInternos[i], verticesInternos[j]);
            }
        }

    }

}



