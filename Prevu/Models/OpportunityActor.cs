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
    
    public partial class OpportunityActor
    {
        public int OpportunityId { get; set; }
        public int ActorId { get; set; }
        public int AttendanceStatusId { get; set; }
        public System.DateTime DateModified { get; set; }
    
        public virtual Actor Actor { get; set; }
        public virtual AttendanceStatus AttendanceStatu { get; set; }
        public virtual Opportunity Opportunity { get; set; }
    }
}
