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
    
    public partial class ScormResource
    {
        public int Id { get; set; }
        public string FolderName { get; set; }
        public string CompletionTime { get; set; }
    
        public virtual BlobResource BlobResource { get; set; }
    }
}
