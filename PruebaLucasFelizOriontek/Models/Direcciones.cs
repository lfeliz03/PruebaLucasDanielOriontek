//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaLucasFelizOriontek.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Direcciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Direcciones()
        {
            this.DireccionesClientes = new HashSet<DireccionesClientes>();
        }
    
        public int IdDireccion { get; set; }
        public string Direccion { get; set; }
        public Nullable<bool> Inactivo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DireccionesClientes> DireccionesClientes { get; set; }
    }
}
