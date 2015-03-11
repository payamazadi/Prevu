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
    
    public partial class Issue
    {
        public Issue()
        {
            this.ActorIssueOpinions = new HashSet<ActorIssueOpinion>();
            this.Objectives = new HashSet<Objective>();
        }
    
        public int IssueId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Active { get; set; }
        public bool InPurview { get; set; }
        public Nullable<int> OwnerId { get; set; }
        public string Notes { get; set; }
    
        public virtual ICollection<ActorIssueOpinion> ActorIssueOpinions { get; set; }
        public virtual ICollection<Objective> Objectives { get; set; }
        public virtual Staff Staff { get; set; }
    }
}