
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
    
public partial class ModifiedRDLC
{

    public ModifiedRDLC()
    {

        this.CustomizedRDLC = new HashSet<CustomizedRDLC>();

    }


    public int ModifiedRDLCId { get; set; }

    public string PrintId { get; set; }

    public string Version { get; set; }



    public virtual ICollection<CustomizedRDLC> CustomizedRDLC { get; set; }

}

}