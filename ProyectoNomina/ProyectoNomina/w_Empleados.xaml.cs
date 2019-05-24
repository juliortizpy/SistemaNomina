using Microsoft.Win32;
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
    /// Lógica de interacción para w_Empleados.xaml
    /// </summary>
    public partial class w_Empleados : Window
    {
        NominaEntities datos;
        public w_Empleados()
        {
            InitializeComponent();
            datos = new NominaEntities();
        }

        public void CargarGrillaEmpleados()
        {
            dgEmpleados.ItemsSource = datos.Empleado.ToList();
        }
        private void DgEmpleados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dgEmpleados.SelectedItems != null)
            {
                Empleado a = (Empleado)dgEmpleados.SelectedItem;
                txtId.Text = a.Id_Empleado.ToString();
                txtNombre.Text = a.Nombres.ToString();
                txtApellido.Text = a.Apellidos.ToString();
                txtNroDocumento.Text = a.Nro_Documento.ToString();
                txtDireccion.Text = a.Direccion.ToString();
                txtNroTelefono.Text = a.Nro_Telefono.ToString();
                txtSalarioBasico.Text = a.Salario_Basico.ToString();
                dpFechaNacimiento.Text = a.Fecha_Nacimiento.ToString();
                dpFechaIncorporacion.Text = a.Fecha_Incorporacion.ToString();
                //Cargamos la imagen
                if (a.Imagen_Perfil != null) { 
                String stringPath = a.Imagen_Perfil;
                Uri imageUri = new Uri(stringPath);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                imgPhoto.Source = imageBitmap;
                }
            }

        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtNroDocumento.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtNroTelefono.Text = string.Empty;
            txtSalarioBasico.Text = string.Empty;
            imgPhoto.Source = null;
            dpFechaIncorporacion.SelectedDate = null;
            dpFechaNacimiento.SelectedDate = null;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmpleados.SelectedItem != null)
            {
                Empleado a = (Empleado)dgEmpleados.SelectedItem;
                datos.Empleado.Remove(a);
                datos.SaveChanges();
                CargarGrillaEmpleados();
            }
            else
                MessageBox.Show("Debe seleccionar un empleado de la grilla para eliminar!");
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmpleados.SelectedItem != null)
            {
                Empleado emple = (Empleado)dgEmpleados.SelectedItem;
                emple.Nombres = txtNombre.Text;
                emple.Apellidos = txtApellido.Text;
                emple.Nro_Documento = txtNroDocumento.Text;
                emple.Direccion = txtDireccion.Text;
                emple.Nro_Telefono = txtNroTelefono.Text;
                DateTime? selectedDate = dpFechaNacimiento.SelectedDate;
                if (selectedDate.HasValue)
                {
                    //string formatted = selectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    emple.Fecha_Nacimiento = selectedDate.Value;
                }
                DateTime? selectedDate2 = dpFechaIncorporacion.SelectedDate;
                if (selectedDate2.HasValue)
                {
                    //string formatted = selectedDate2.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    emple.Fecha_Incorporacion = selectedDate2.Value;
                }
                emple.Salario_Basico = int.Parse(txtSalarioBasico.Text);
                if (emple.Imagen_Perfil != null) { 
                emple.Imagen_Perfil = imgPhoto.Source.ToString();
                }
                //Le ponemos una banderita de que se modicaron datos en la entidad..
                datos.Entry(emple).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();
                CargarGrillaEmpleados();
            }
            else
                MessageBox.Show("Debe seleccionar un Empleado de la grilla para modificar!");
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Empleado emple = new Empleado();
            emple.Nombres = txtNombre.Text;
            emple.Apellidos = txtApellido.Text;
            emple.Nro_Documento = txtNroDocumento.Text;
            emple.Direccion = txtDireccion.Text;
            emple.Nro_Telefono = txtNroTelefono.Text;
            DateTime? selectedDate = dpFechaNacimiento.SelectedDate;
            if (selectedDate.HasValue)
            {
                //string formatted = selectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                emple.Fecha_Nacimiento = selectedDate.Value;
            }
            DateTime? selectedDate2 = dpFechaIncorporacion.SelectedDate;
            if (selectedDate2.HasValue)
            {
               // string formatted = selectedDate2.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                emple.Fecha_Incorporacion = selectedDate2.Value;
            }
            emple.Salario_Basico = int.Parse(txtSalarioBasico.Text);
            if (emple.Imagen_Perfil != null)
            {
                emple.Imagen_Perfil = imgPhoto.Source.ToString();
            }
            datos.Empleado.Add(emple);
            datos.SaveChanges();
            CargarGrillaEmpleados();
        }

        private void BtnImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }

        }

        private void DgEmpleados_Loaded(object sender, RoutedEventArgs e)
        {
            CargarGrillaEmpleados();
        }
    }
}
