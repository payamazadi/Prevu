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
    
    public partial class Opportunity
    {
        public Opportunity()
        {
            this.OpportunityActors = new HashSet<OpportunityActor>();
            this.Events = new HashSet<Event>();
        }
    
        public int OpportunityId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Name { get; set; }
        public string Importance { get; set; }
        public int EventStatusId { get; set; }
        public string Notes { get; set; }
    
        public virtual ICollection<OpportunityActor> OpportunityActors { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual EventStatus EventStatu { get; set; }
    }
}
