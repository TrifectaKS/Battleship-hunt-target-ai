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
    
    public partial class Shot
    {
        public System.Guid ShotId { get; set; }
        public System.Guid GameId { get; set; }
        public int ShipTypeId { get; set; }
        public int ShotTypeId { get; set; }
        public Nullable<int> OrientationId { get; set; }
        public Nullable<int> DirectionId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Nullable<int> InitialTargetX { get; set; }
        public Nullable<int> InitialTargetY { get; set; }
        public int ShotNumber { get; set; }
        public Nullable<int> TimeTakenMS { get; set; }
        public int AIState { get; set; }
    
        public virtual Game Game { get; set; }
    }
}