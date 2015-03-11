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
    
    public partial class Event
    {
        public Event()
        {
            this.EventActors = new HashSet<EventActor>();
        }
    
        public int EventId { get; set; }
        public int OpportunityId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Name { get; set; }
        public Nullable<int> Priority { get; set; }
        public int EventStatusId { get; set; }
        public string Notes { get; set; }
        public Nullable<int> OwnerId { get; set; }
    
        public virtual ICollection<EventActor> EventActors { get; set; }
        public virtual Opportunity Opportunity { get; set; }
        public virtual EventStatu EventStatu { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
