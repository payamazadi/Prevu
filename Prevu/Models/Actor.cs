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
    
    public partial class Actor
    {
        public Actor()
        {
            this.ActorIssueOpinions = new HashSet<ActorIssueOpinion>();
            this.AskActors = new HashSet<AskActor>();
            this.EventActors = new HashSet<EventActor>();
            this.OpportunityActors = new HashSet<OpportunityActor>();
            this.ParentActors = new HashSet<Actor>();
            this.ChildActors = new HashSet<Actor>();
        }
    
        public int ActorId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public string Name { get; set; }
        public Nullable<int> ActorTypeId { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> GlobalInfluence { get; set; }
    
        public virtual ICollection<ActorIssueOpinion> ActorIssueOpinions { get; set; }
        public virtual ICollection<AskActor> AskActors { get; set; }
        public virtual ActorType ActorType { get; set; }
        public virtual ICollection<EventActor> EventActors { get; set; }
        public virtual ICollection<OpportunityActor> OpportunityActors { get; set; }
        public virtual ICollection<Actor> ParentActors { get; set; }
        public virtual ICollection<Actor> ChildActors { get; set; }
    }
}
