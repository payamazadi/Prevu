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
    
    public partial class ActorIssueOpinion
    {
        public int ActorId { get; set; }
        public int IssueId { get; set; }
        public Nullable<int> OpinionId { get; set; }
        public System.DateTime DateModified { get; set; }
    
        public virtual Actor Actor { get; set; }
        public virtual Issue Issue { get; set; }
        public virtual Opinion Opinion { get; set; }
    }
}
