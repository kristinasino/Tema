//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NunitTemaTests
{
    using System;
    using System.Collections.Generic;
    
    public partial class Perdoruesit
    {
        public string PerdoruesID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string Emer { get; set; }
        public string Mbiemer { get; set; }
        public Nullable<int> Mosha { get; set; }
        public string Gjinia { get; set; }
        public Nullable<int> Telefon { get; set; }
        public string Email { get; set; }
    
        public virtual Rolet Rolet { get; set; }
    }
}
