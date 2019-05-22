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
        NominaEntities datos;
        public Permisos()
        {
            InitializeComponent();
            //Se instancia el objeto conexion
            datos = new NominaEntities();
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

    
    }
}
