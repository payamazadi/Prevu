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
    
    public partial class ActorType
    {
        public ActorType()
        {
            this.Actors = new HashSet<Actor>();
        }
    
        public int ActorTypeId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Actor> Actors { get; set; }
    }
}