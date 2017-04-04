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
    
    public partial class Usr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usr()
        {
            this.AuditLogin = new HashSet<AuditLogin>();
            this.AuditUser = new HashSet<AuditUser>();
            this.Offer = new HashSet<Offer>();
        }
    
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> DateValid { get; set; }
        public Nullable<System.DateTime> DateRegistration { get; set; }
        public Nullable<int> IdUserType { get; set; }
        public Nullable<int> IdPerson { get; set; }
        public string ConfirmationCode { get; set; }
        public int IdCreated { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<int> IdUpdated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuditLogin> AuditLogin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuditUser> AuditUser { get; set; }
        public virtual DirUsrType DirUsrType { get; set; }
        public virtual Prs Prs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Offer> Offer { get; set; }
    }
}
