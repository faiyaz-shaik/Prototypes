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
    
    public partial class p_node
    {
        public int id { get; set; }
        public int id_state { get; set; }
        public int id_type { get; set; }
        public int version { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Nullable<bool> cat { get; set; }
        public Nullable<bool> key_res { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> updated_date { get; set; }
        public string notes { get; set; }
        public int id_origin { get; set; }
        public string origin_key { get; set; }
        public string search_keys { get; set; }
        public string search_types { get; set; }
        public string search_rights { get; set; }
        public string search_rights_display { get; set; }
        public string search_authentication { get; set; }
        public string search_url { get; set; }
        public string search_holdings { get; set; }
        public string search_provider { get; set; }
        public string search_author { get; set; }
        public string search_editor { get; set; }
        public bool alerted_flag { get; set; }
        public short order_value { get; set; }
        public bool is_la { get; set; }
        public Nullable<int> portal_bitmap { get; set; }
        public Nullable<int> key_bitmap { get; set; }
        public string search_alt_title { get; set; }
    }
}
