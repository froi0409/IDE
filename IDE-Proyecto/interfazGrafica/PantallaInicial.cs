using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE_Proyecto.interfazGrafica
{
    public partial class PantallaInicial : Form
    {
        public PantallaInicial()
        {
            InitializeComponent();
        }

        private void PantallaInicial_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreacionDeProyecto cdp = new CreacionDeProyecto("Archivo");
            cdp.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreacionDeProyecto cdp = new CreacionDeProyecto("Proyecto");
            cdp.Visible = true;
            this.Visible = false;
        }

        private void btnAbrirA_Click(object sender, EventArgs e)
        {
            
        }

        private void CrearIDE(String tipo)
        {
            
        }
    }
}
