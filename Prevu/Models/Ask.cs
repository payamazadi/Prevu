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
    
    public partial class Ask
    {
        public Ask()
        {
            this.AskActors = new HashSet<AskActor>();
            this.EventActorAsks = new HashSet<EventActorAsk>();
        }
    
        public int AskId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public Nullable<System.DateTime> TargetDate { get; set; }
        public Nullable<int> OwnerId { get; set; }
        public Nullable<int> AskStatusId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public int ObjectiveId { get; set; }
    
        public virtual ICollection<AskActor> AskActors { get; set; }
        public virtual ICollection<EventActorAsk> EventActorAsks { get; set; }
        public virtual AskStatus AskStatus { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Objective Objective { get; set; }
    }
}
