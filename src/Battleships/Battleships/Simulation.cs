//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Battleships
{
    using System;
    using System.Collections.Generic;
    
    public partial class Simulation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Simulation()
        {
            this.Games = new HashSet<Game>();
        }
    
        public System.Guid SimulationId { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> SimulationDate { get; set; }
        public Nullable<int> TimeTakenMS { get; set; }
        public Nullable<int> AIType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Game> Games { get; set; }
    }
}