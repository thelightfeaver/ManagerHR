﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagerHR.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBRHEntities1 : DbContext
    {
        public DBRHEntities1()
            : base("name=DBRHEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cargo> cargo { get; set; }
        public virtual DbSet<departamento> departamento { get; set; }
        public virtual DbSet<empleado> empleado { get; set; }
        public virtual DbSet<licencia> licencia { get; set; }
        public virtual DbSet<permiso> permiso { get; set; }
        public virtual DbSet<salida> salida { get; set; }
        public virtual DbSet<vacaciones> vacaciones { get; set; }
    }
}
