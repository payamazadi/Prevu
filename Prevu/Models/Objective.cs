//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prevu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Objective
    {
        public Objective()
        {
            this.Asks1 = new HashSet<Ask>();
        }
    
        public int ObjectiveId { get; set; }
        public int IssueId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public Nullable<System.DateTime> TargetDate { get; set; }
        public string Name { get; set; }
        public int ObjectiveStatusId { get; set; }
        public Nullable<int> OwnerId { get; set; }
        public string Notes { get; set; }
    
        public virtual Issue Issue { get; set; }
        public virtual ObjectiveStatus ObjectiveStatus { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual ICollection<Ask> Asks1 { get; set; }
    }
}
