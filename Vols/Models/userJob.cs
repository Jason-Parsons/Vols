//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vols.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class userJob
    {
        public int userJobID { get; set; }
        public int userID { get; set; }
        public int jobID { get; set; }
    
        public virtual job job { get; set; }
        public virtual user user { get; set; }
    }
}
