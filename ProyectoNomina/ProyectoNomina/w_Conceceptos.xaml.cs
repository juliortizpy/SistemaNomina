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
    /// Lógica de interacción para w_Conceceptos.xaml
    /// </summary>
    public partial class w_Conceceptos : Window
    {
        NominaEntities1 datos;
        public w_Conceceptos()
        {
            InitializeComponent();
            datos = new NominaEntities1();
        }

        public void CargarGrillaConceptos()
        {
            dgconceptos.ItemsSource = datos.Turno.ToList();
        }

        private void btnagregar_Click(object sender, RoutedEventArgs e)
        {
            Concepto c = new Concepto();
            c.Id_Concepto = int.Parse(txtidconcepto.Text);
            c.Descripcion = txtdescripcion.Text;
            c.Tipo = txttipo.Text;

            datos.Concepto.Add(c);
            datos.SaveChanges();
            CargarGrillaConceptos();

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgconceptos.SelectedItem != null)
            {
                Concepto c = (Concepto)dgconceptos.SelectedItem;
                datos.Concepto.Remove(c);
                datos.SaveChanges();
                CargarGrillaConceptos();
            }
            else
                MessageBox.Show("Debe seleccionar un empleado de la grilla para eliminar!");

        }
    }
}
