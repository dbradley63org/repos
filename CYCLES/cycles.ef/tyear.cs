//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cycles.ef
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

    public partial class tyear
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tyear()
        {
            this.tmodels = new HashSet<tmodel>();
        }
    
        public int id { get; set; }

		[Display(Name ="Year")]
        public int yr { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tmodel> tmodels { get; set; }
    }
}
