//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prueba_System_Water_C.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Lectura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Lectura()
        {
            this.Tbl_Pago = new HashSet<Tbl_Pago>();
        }
    
        public int Id_Lectura { get; set; }
        public Nullable<int> Lectura { get; set; }
        public Nullable<int> Id_Cliente { get; set; }
        public string Estado_Lectura { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<System.DateTime> Fecha_Registro { get; set; }
        public Nullable<int> Id_Lecturas { get; set; }
        public string Mes { get; set; }
    
        public virtual Tbl_Clientes Tbl_Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Pago> Tbl_Pago { get; set; }
    }
}
