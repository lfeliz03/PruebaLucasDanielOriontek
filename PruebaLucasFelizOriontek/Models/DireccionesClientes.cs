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
    
    public partial class DireccionesClientes
    {
        public int IdDireccionCliente { get; set; }
        public int IdCliente { get; set; }
        public int IdDireccion { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Direcciones Direcciones { get; set; }
    }
}
