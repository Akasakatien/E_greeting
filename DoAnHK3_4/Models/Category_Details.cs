//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnHK3_4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Category_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category_Details()
        {
            this.Greetings = new HashSet<Greeting>();
        }
        [DisplayName("Category Details ID")]
        public int id { get; set; }
        [DisplayName("Category Details Name")]
        [Required(ErrorMessage = "Please Input CategoryDetails Name")]
        [RegularExpression("^[A-Z]([a-zA-Z]|\\.| |-|\')+$", ErrorMessage = "Can't have numer in CategoryDetails Name")]
        public string name { get; set; }
        public Nullable<int> categoryID { get; set; }
        [DisplayName("Date Of Event")]
        public Nullable<System.DateTime> dateOfEvent { get; set; }
        public string status { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Greeting> Greetings { get; set; }
    }
}