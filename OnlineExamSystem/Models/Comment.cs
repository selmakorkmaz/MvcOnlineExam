//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int ResponseId { get; set; }
        public string Response { get; set; }
        public int ArticleId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string FullName { get; set; }
        public Nullable<int> Like { get; set; }
    
        public virtual Article Article { get; set; }
    }
}
