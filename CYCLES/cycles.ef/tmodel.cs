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

	public partial class tmodel
    {
		[Display(Name = "Model ID")]
		public int id { get; set; }
		public int year_id { get; set; }
		public int make_id { get; set; }
		[Display(Name = "Model")]
		public string model_na { get; set; }
		[Display(Name = "")]
		public Nullable<int> style_id { get; set; }
    
        public virtual tmake tmake { get; set; }
        public virtual tstyle tstyle { get; set; }
        public virtual tyear tyear { get; set; }
    }
}
