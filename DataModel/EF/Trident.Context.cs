﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TridentEntities : DbContext
    {
        public TridentEntities()
            : base("name=TridentEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AuditLogin> AuditLogin { get; set; }
        public virtual DbSet<AuditUser> AuditUser { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<DirFish> DirFish { get; set; }
        public virtual DbSet<DirFishCategory> DirFishCategory { get; set; }
        public virtual DbSet<DirFishCondition> DirFishCondition { get; set; }
        public virtual DbSet<DirFishingZone> DirFishingZone { get; set; }
        public virtual DbSet<DirFishType> DirFishType { get; set; }
        public virtual DbSet<DirPaymentMethod> DirPaymentMethod { get; set; }
        public virtual DbSet<DirPortType> DirPortType { get; set; }
        public virtual DbSet<DirShipType> DirShipType { get; set; }
        public virtual DbSet<DirUsrType> DirUsrType { get; set; }
        public virtual DbSet<OfferItem> OfferItem { get; set; }
        public virtual DbSet<Port> Port { get; set; }
        public virtual DbSet<Prs> Prs { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Ship> Ship { get; set; }
        public virtual DbSet<Usr> Usr { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
    }
}
