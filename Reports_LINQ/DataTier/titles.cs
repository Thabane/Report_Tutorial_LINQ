//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataTier
{
    using System;
    using System.Collections.Generic;
    
    public partial class titles
    {
        public titles()
        {
            this.sales = new HashSet<sales>();
            this.titleauthor = new HashSet<titleauthor>();
        }
    
        public string title_id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string pub_id { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<decimal> advance { get; set; }
        public Nullable<int> royalty { get; set; }
        public Nullable<int> ytd_sales { get; set; }
        public string notes { get; set; }
        public System.DateTime pubdate { get; set; }
    
        public virtual publishers publishers { get; set; }
        public virtual ICollection<sales> sales { get; set; }
        public virtual ICollection<titleauthor> titleauthor { get; set; }
        public virtual roysched roysched { get; set; }
    }
}