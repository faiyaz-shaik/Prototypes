//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VLE_DataLoad
{
    using System;
    using System.Collections.Generic;
    
    public partial class Status
    {
        public int Id { get; set; }
        public int VleResourceId { get; set; }
        public int ResourceStatus { get; set; }
        public System.DateTime Date { get; set; }
        public System.Guid User { get; set; }
    
        public virtual VleResource VleResource { get; set; }
    }
}
