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
    
    public partial class EventActorAsk
    {
        public int EventActorId { get; set; }
        public int AskId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
    
        public virtual Ask Ask { get; set; }
        public virtual EventActor EventActor { get; set; }
    }
}
