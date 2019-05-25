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
    /// Lógica de interacción para w_Anticipos.xaml
    /// </summary>
    public partial class w_Anticipos : Window
    {
        NominaEntities1 datos;
        public w_Anticipos()
        {
            InitializeComponent();
            datos = new NominaEntities1();
        }

        private void CargarDatosGrilla()
        {
            try
            {
                dgAnticipos.ItemsSource = datos.Anticipo.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgAnticipos_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatosGrilla();
        }

        private void BtnAprobar_Click(object sender, RoutedEventArgs e)
        {
            if (dgAnticipos.SelectedItem != null)
            {
                Anticipo a = (Anticipo)dgAnticipos.SelectedItem;
                if (a.Estado == "Pendiente")
                {
                    a.Estado = "Aprobado";
                    MessageBox.Show("Se Aprobo el Anticipo");
                }
                else
                    MessageBox.Show("El Anticipo ya esta procesado");
                datos.SaveChanges();
                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un Anticipo para procesarlo!");
        }

        private void BtnRechazar_Click(object sender, RoutedEventArgs e)
        {
            if (dgAnticipos.SelectedItem != null)
            {
                Anticipo a = (Anticipo)dgAnticipos.SelectedItem;
                if (a.Estado == "Pendiente")
                {
                    a.Estado = "Rechazado";
                    MessageBox.Show("Se Rechazo el Anticipo");
                }
                else
                    MessageBox.Show("El Anticipo ya esta procesado");
                datos.SaveChanges();
                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un Anticipo para procesarlo!");
        }
    }
}
