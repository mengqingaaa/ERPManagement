﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ERPManagement.Models
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class ERPMCModelContainer : DbContext
{
    public ERPMCModelContainer()
        : base("name=ERPMCModelContainer")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Customer> CustomerSet { get; set; }

    public virtual DbSet<CustomizedRDLC> CustomizedRDLCSet { get; set; }

    public virtual DbSet<FuncMenu> FuncMenuSet { get; set; }

    public virtual DbSet<AdminMenu> AdminMenuSet { get; set; }

    public virtual DbSet<ModifiedRDLC> ModifiedRDLCSet { get; set; }

    public virtual DbSet<SqlExecution> SqlExecutionSet { get; set; }

    public virtual DbSet<Log> LogSet { get; set; }

}

}

