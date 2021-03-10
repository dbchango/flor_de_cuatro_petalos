using System;
using System.Windows.Forms;

namespace Rosa4Petalos
{
    public partial class frm_Rosa : Form
    {

        CFlor objFlor = new CFlor();

        public frm_Rosa()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (objFlor.ReadData(txtA))
            {
                objFlor.GraphAxis(picCanvas);
                objFlor.draw(picCanvas,listX,listY);
                //objFlor.PrintData(listX,listY);
            }
            
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            picCanvas.Refresh();
            listX.Items.Clear();
            listY.Items.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
