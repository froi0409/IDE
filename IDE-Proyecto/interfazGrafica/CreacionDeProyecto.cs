using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IDE_Proyecto.interfazGrafica
{
    using archivos;
    public partial class CreacionDeProyecto : Form
    {
        private String tipoDeCreacion;
        private PantallaInicial pantallaInicial;

        public CreacionDeProyecto(String tipoDeCreacion, PantallaInicial pantallaInicial)
        {
            InitializeComponent();
            this.tipoDeCreacion = tipoDeCreacion;
            this.pantallaInicial = pantallaInicial;
            InicializacionDeLabels();
        }

        private void InicializacionDeLabels()
        {
            //Con las siguientes condiciones inicializamos el texto de los labels del form
            //Tambien inicializamos la visibilidad del checkbox
            if (tipoDeCreacion.Equals("Proyecto"))
            {
                lblTitulo.Text = "Creación de Proyecto";
                lblNombre.Text = "Nombre del Proyecto";
                lblUbicacion.Text = "Ubicación de la Carpeta del Proyecto";
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
            FolderBrowserDialog fbd = new FolderBrowserDialog(); //Clase que nos sirve para la selección de la carpeta
            DialogResult result = fbd.ShowDialog(); //Abrimos el menú que nos permite elegir la carpeta
            if(result == DialogResult.OK) //Condición que comprueba si el resultado del Dialog del fbd es OK
            {
                txtRuta.Text = fbd.SelectedPath; // Agregamos la ruta que tendrá el Archivo o Proyecto
            }
        }

        private void CreacionDeProyecto_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text.Length < 1) //Condición que nos permite saber si el textbox del nombre está vacio
            {
                MessageBox.Show("El nombre del " + tipoDeCreacion + "es muy corto");
            } 
            else if (txtRuta.Text.Length < 1) //Condición que nos permite saber si el textbox de la ruta está vacio
            {
                MessageBox.Show("Favor de ingresar la ubicación que el " + tipoDeCreacion + " tendrá");
            }
            else 
            {

                //Condiciones que nos permiten saber si la ruta ingresada en el textbox es válida
                if (!Directory.Exists(txtRuta.Text))
                {
                    MessageBox.Show("La carpeta seleccionada no existe\nFavor seleccionar una carpeta válida");
                }
                else
                {

                    //Condición que nos permite crear un archivo o un proyecto, según lo haya indicado el usuario
                    if (tipoDeCreacion.Equals("Proyecto"))
                    {

                        FileProyecto proyecto = new FileProyecto();
                        Directory.CreateDirectory(txtRuta.Text + @"\" + txtNombre.Text); //Crea la carpeta del proyecto

                        if(checkBox1.Checked == true)//Condición que crea un archivo de código fuente, únicamente si el checkbox está chequeado
                        {
                            proyecto.ListaCodigoFuente.Add(new FileCodigoFuente("Inicio"));
                        }

                        IDE ide = new IDE(proyecto, txtNombre.Text, tipoDeCreacion); //CREACIÓN DEL IDE
                        ide.Visible = true;
                        this.Visible = false;

                    }
                    else if (tipoDeCreacion.Equals("Archivo"))
                    {

                    }
                    else //Esta condición no debería ejecutarse nunca, a menos que el proramador no haya enviado bien un parámetro al constructor de la clase
                    {
                        MessageBox.Show("Ha ocurrido un error");
                        Application.Exit();
                    }

                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pantallaInicial.Visible = true;
            this.Visible = false;
        }

        private void CreacionDeProyecto_FormClosed(object sender, FormClosedEventArgs e)
        {
            pantallaInicial.Visible = true;
            this.Visible = false;
        }
    }
}
