//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BootcampWPF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaction()
        {
            this.TransactionItems = new HashSet<TransactionItem>();
        }
    
        public int Id { get; set; }
        public System.DateTimeOffset TransactionDate { get; set; }
        public System.DateTimeOffset CreateDate { get; set; }
        public System.DateTimeOffset UpdateDate { get; set; }
        public System.DateTimeOffset DeleteDate { get; set; }
        public bool IsDelete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionItem> TransactionItems { get; set; }
    }
}
