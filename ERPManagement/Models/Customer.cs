
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
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