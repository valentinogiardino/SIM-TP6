using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulacion_TP1.Clases;
using Simulacion_TP1.Controlador;

namespace Simulacion_TP1
{
    public partial class Pantalla : Form
    {

        private Gestor gestor;

        public Gestor Gestor { get => gestor; set => gestor = value; }

        //Constructor
        public Pantalla()
        {
            InitializeComponent();
            this.gestor = new Gestor(this); //Se guarda una referencia al gestor. El gestor tambien contendra una referencia a la pantalla. Esto permite la comunicacion
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Pantalla_Load(object sender, EventArgs e)
        {
            txtUniformeA.Text = 8.7.ToString();
            txtUniformeB.Text = 15.2.ToString();
            txtMedia.Text = 16.7.ToString();
            txtDesviacion.Text = 5.ToString();
            txtLambdaMatricula.Text = 2.886.ToString();
            txtLambdaRenovacion.Text = 4.846.ToString();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        public void cargarTabla()
        {
            List<FilaMuestra> fila = gestor.generarTablaSimulacion();    //Se le delega al gestor la generacion de la tabla
            dataGridView1.DataSource = fila;
            dataGridView1.Refresh();


            dataGridView2.DataSource = gestor.GestorAtentados.GestorRungeKutta.TablaProximaLlegada;
            dataGridView2.Refresh();

            dataGridView3.DataSource = gestor.GestorAtentados.GestorRungeKutta.TablaDuracionBloqueoLlegada;
            dataGridView3.Refresh();

            dataGridView4.DataSource = gestor.GestorAtentados.GestorRungeKutta.TablaDuracionBloqueoServidor;
            dataGridView4.Refresh();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            int cantidadHoras = int.Parse(txtCantidadHoras.Text);
            int horaDesde = int.Parse(txtHoraDesde.Text);


            double a_matricula = double.Parse(txtUniformeA.Text);
            double b_matricula = double.Parse(txtUniformeB.Text);
            double media_renovacion = double.Parse(txtMedia.Text);
            double desviacion_renovacion = double.Parse(txtDesviacion.Text);
            double lambdaMatricula = double.Parse(txtLambdaMatricula.Text);
            double lambdaRenovacion = double.Parse(txtLambdaRenovacion.Text);

            this.gestor.tomarDatos(cantidadHoras, horaDesde, a_matricula, b_matricula, media_renovacion, desviacion_renovacion, lambdaMatricula, lambdaRenovacion);

            cargarTabla();
        }
    }
}
