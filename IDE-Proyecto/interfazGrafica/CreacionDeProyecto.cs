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
    public partial class CreacionDeProyecto : Form
    {
        private String tipoDeCreacion;

        public CreacionDeProyecto(String tipoDeCreacion)
        {
            InitializeComponent();
            this.tipoDeCreacion = tipoDeCreacion;
            InicializacionDeLabels();
        }

        private void InicializacionDeLabels()
        {
            if (tipoDeCreacion.Equals("Proyecto"))
            {
                lblTitulo.Text = "Creación de Proyecto";
                lblNombre.Text = "Nombre del Proyecto";
                lblUbicacion.Text = "Ubicación del Proyecto";
                checkBox1.Visible = true;
            }
            else if (tipoDeCreacion.Equals("Archivo"))
            {
                lblTitulo.Text = "Creación del Archivo";
                lblNombre.Text = "Nombre del Archivo";
                lblUbicacion.Text = "Ubicación del Archivo";
                checkBox1.Visible = false;
            }
            else
            {
                MessageBox.Show("Hubo un error al crear el " + tipoDeCreacion);
            }
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {

        }

        private void CreacionDeProyecto_Load(object sender, EventArgs e)
        {

        }

        private void CreacionDeProyecto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
