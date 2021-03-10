
using System;
using System.Numerics;
using System.Windows.Forms;
using System.Drawing;

namespace Rosa4Petalos
{
    class CFlor
    {
        static float mA;
        static float xCenter;
        static float yCenter;
        static Graphics mGraph;
        static Pen mPen;
        private float x, y;
        private float SF = 20;

        public CFlor(){
        
        }

        public float genX(float teta)
        {
            return mA * (float)Math.Cos(2*teta*Math.PI/180) * (float)Math.Cos(Math.PI * teta / 180);
        }

        public float genY(float teta)
        {
            return mA * (float)Math.Cos(2 * teta * Math.PI / 180) *  (float)Math.Sin(Math.PI * teta / 180);
        }

        public void draw(PictureBox picCanvas, ListBox lisX, ListBox lisY)
        {
            xCenter = picCanvas.Width/2;
            yCenter = picCanvas.Height/2;
            mGraph = picCanvas.CreateGraphics();
           

            for (float i = 0; i < 360; i += 0.1f)
            {
                x = genX(i) ;
                y = genY(i) ;
                mGraph.FillRectangle(new SolidBrush(Color.Red), new RectangleF(location: new PointF(xCenter + x*SF, yCenter + y *SF), size: new Size(2, 2)));//size grosor
                lisX.Items.Add(x.ToString());
                lisY.Items.Add(y.ToString());

            }            
        }


        public bool ReadData(TextBox txtA)
        {
            try
            {
                mA = float.Parse(txtA.Text);
                if (mA > 8)
                {
                    MessageBox.Show("Fuera de Rango 0-8", "Revisalo");
                    return false;
                }
                if (mA < 0)
                {
                    MessageBox.Show("La entrada debe ser un numero positivo", "Revisalo");
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public void GraphAxis(PictureBox picCanvas)
        {
            mGraph = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Black, 1);
            xCenter = (int)(picCanvas.Width / 2);
            yCenter = (int)(picCanvas.Height / 2);
            mGraph.DrawLine(mPen, 0, yCenter, picCanvas.Width, yCenter);
            mGraph.DrawLine(mPen, xCenter, 0, xCenter, picCanvas.Height);

        }
        public void PrintData(ListBox lisX,ListBox lisY)
        {
            lisX.Text = x.ToString();
            lisY.Text = y.ToString();
        }

    }
}
