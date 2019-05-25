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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void MenuEmpleados_Click(object sender, RoutedEventArgs e)
        {
            w_Empleados ventanaEmpleado = new w_Empleados();
            ventanaEmpleado.ShowDialog();
        }

        private void MenuSalir_Click(object sender, RoutedEventArgs e)
        {
                this.Close();          
        }

        private void MenuTurnos_Click(object sender, RoutedEventArgs e)
        {
            w_Turno ventanaTurno = new w_Turno();
            ventanaTurno.ShowDialog();
        }
        private void MenuPermisos_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuAnticipos_Click(object sender, RoutedEventArgs e)
        {
            w_Anticipos ventanaAnticipos = new w_Anticipos();
            ventanaAnticipos.ShowDialog();
        }
    }
}
