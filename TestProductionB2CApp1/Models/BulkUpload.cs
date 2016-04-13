using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestProductionB2CApp1.Models
{
    public class BulkUpload
    {
        [Required]
        [DisplayName("Applications")]
        public string Applications { get; set; }
        [DisplayName("Security Roles")]
        public string SecurityRoles { get; set; }
        [DisplayName("Permission Groups")]
        public string PermissionGroups { get; set; }
    }
}