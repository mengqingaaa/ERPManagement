
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
    
public partial class CustomizedRDLC
{

    public CustomizedRDLC()
    {

        this.ModifiedRDLC = new HashSet<ModifiedRDLC>();

    }


    public int CustomizedRDLCId { get; set; }

    public string PrintId { get; set; }

    public string Name { get; set; }

    public string Version { get; set; }

    public int CustomoerId { get; set; }



    public virtual Customer Customer { get; set; }

    public virtual ICollection<ModifiedRDLC> ModifiedRDLC { get; set; }

}

}
