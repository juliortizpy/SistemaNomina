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
    /// Lógica de interacción para w_vacaciones.xaml
    /// </summary>
    public partial class w_vacaciones : Window
    {

        NominaEntities1 datos;
        public w_vacaciones()
        {
            InitializeComponent();
            datos = new NominaEntities1();
        }


        private void Visualizar()
        {
            try
            {

                dgVacaciones.ItemsSource = datos.Vacaciones.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Visualizar();

        }
    }
}
