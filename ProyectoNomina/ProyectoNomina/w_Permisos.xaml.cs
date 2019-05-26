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
    /// Lógica de interacción para Permisos.xaml
    /// </summary>
    public partial class Permisos : Window
    {

        //Creamos el objeto 
        NominaEntities1 datos;
        public Permisos()
        {
            InitializeComponent();
            //Se instancia el objeto conexion
            datos = new NominaEntities1();
        }

        private void CargarPermisos()
        {
            try
            {
                dgPermisos.ItemsSource = datos.Permisos.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void btnAprobar_Click(object sender, RoutedEventArgs e)
        {
            if (dgPermisos.SelectedItem != null)
            {
                Permisos a = (Permisos)dgPermisos.SelectedItem;
                if (a.Estado == "Pendiente")
                {
                    a.Estado = "Aprobado";
                    MessageBox.Show("Permiso Aprobado!");
                }
                
                datos.SaveChanges();
                CargarPermisos();
            }
            else
                MessageBox.Show("Debe seleccionar un Permiso!");
        }

        private void btnRechazar_Click(object sender, RoutedEventArgs e)
        {
            if (dgPermisos.SelectedItem != null)
            {
                Permisos a = (Permisos)dgPermisos.SelectedItem;
                if (a.Estado == "Pendiente")
                {
                    a.Estado = "Rechazado";
                    MessageBox.Show("Permiso rechazado!");
                }
                datos.SaveChanges();
                CargarPermisos();
            }
            else
                MessageBox.Show("Debe seleccionar un Permiso!");
        }

        private void dgPermisos_Loaded(object sender, RoutedEventArgs e)
        {
            CargarPermisos();
        }
    }
}
