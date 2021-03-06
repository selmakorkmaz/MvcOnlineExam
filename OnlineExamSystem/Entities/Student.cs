//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineExamSystem.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.Registirations = new HashSet<Registiration>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> AccessLevel { get; set; }
        public Nullable<System.DateTime> EntryData { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PassHash { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registiration> Registirations { get; set; }
    }
}
