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
    
    public partial class ResourceRelation
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public int RelationId { get; set; }
        public int RelationType { get; set; }
    
        public virtual VleResource VleResource { get; set; }
        public virtual VleResource VleResource1 { get; set; }
    }
}
