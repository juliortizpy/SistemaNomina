//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoNomina
{
    using System;
    using System.Collections.Generic;
    
    public partial class Anticipo
    {
        public int Id_Anticipo { get; set; }
        public int Empleado_Id { get; set; }
        public int Monto_Solicitado { get; set; }
        public int Monto_Aprobado { get; set; }
        public System.DateTime Fecha_Solicitud { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> Fecha_Definicion { get; set; }
        public string Observaciones { get; set; }
    
        public virtual Empleado Empleado { get; set; }
    }
}
