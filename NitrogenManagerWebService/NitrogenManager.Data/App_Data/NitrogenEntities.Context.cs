﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NitrogenManager.Data.WebService.App_Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NitrogenEntities : DbContext
    {
        public NitrogenEntities()
            : base("name=NitrogenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<JobPositions> JobPositions { get; set; }
        public virtual DbSet<Places> Places { get; set; }
        public virtual DbSet<ProductGroups> ProductGroups { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Storages> Storages { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
    }
}
