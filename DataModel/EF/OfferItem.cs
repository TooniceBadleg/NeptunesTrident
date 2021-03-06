//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class OfferItem
    {
        public int Id { get; set; }
        public int IdOffer { get; set; }
        public Nullable<int> IdZone { get; set; }
        public int IdFish { get; set; }
        public Nullable<int> IdFishCategory { get; set; }
        public Nullable<bool> IsFarmed { get; set; }
        public Nullable<double> Qty { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public string ProductImage { get; set; }
        public byte[] ProductImageBin { get; set; }
        public string Note { get; set; }
        public Nullable<int> IdFishCondition { get; set; }
        public Nullable<System.DateTime> CatchTime { get; set; }
        public Nullable<System.DateTime> FreezeTime { get; set; }
        public int IdCreated { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<int> IdUpdated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    
        public virtual DirFish DirFish { get; set; }
        public virtual DirFishCategory DirFishCategory { get; set; }
        public virtual DirFishCondition DirFishCondition { get; set; }
        public virtual DirFishingZone DirFishingZone { get; set; }
        public virtual Offer Offer { get; set; }
    }
}
