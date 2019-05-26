using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoNomina
{
    /// <summary>
    /// Lógica de interacción para w_Turno.xaml
    /// </summary>
    public partial class w_Turno : Window
    {
        NominaEntities1 datos;
        public w_Turno()
        {
            InitializeComponent();
            datos = new NominaEntities1();
        }

        public void CargarGrillaTurnos()
        {
            dgturno.ItemsSource = datos.Turno.ToList();
        }

        private void btnagregar_Click(object sender, RoutedEventArgs e)
        {
            Turno tur = new Turno();
            tur.Id_Turno = int.Parse(txtidturno.Text);
            tur.Hora_Entrada = txthoraentrada.Text;
            tur.Hora_Salida = txthorasalida.Text;
            tur.Observaciones = txtobservacion.Text;
            datos.Turno.Add(tur);
            datos.SaveChanges();
            CargarGrillaTurnos();


        }

        private void btnlimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtidturno.Text = string.Empty;
            txthoraentrada.Text = string.Empty;
            txthorasalida.Text = string.Empty;
            txtobservacion.Text = string.Empty;

            datos.SaveChanges();
            CargarGrillaTurnos();
        }
    }
}
