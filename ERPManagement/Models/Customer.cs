
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
    using System.Collections.Generic;
    
public partial class Customer
{

    public Customer()
    {

        this.CustomizedRDLC = new HashSet<CustomizedRDLC>();

    }


    public int CustomoerId { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string Version { get; set; }

    public int SIerManaged { get; set; }

    public string DBServerName { get; set; }

    public string DBLoginName { get; set; }

    public string DBLoginPassword { get; set; }

    public string DBBizName { get; set; }

    public string DBSysname { get; set; }



    public virtual ICollection<CustomizedRDLC> CustomizedRDLC { get; set; }

}

}
