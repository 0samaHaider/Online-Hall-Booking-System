//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace qwerty.Models
{
    using System;
    using System.Collections.Generic;
    using qwerty.Models;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class User
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
         [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter Email")]

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile Number")]

        public string Mobile { get; set; }
        public string Select_Venue { get; set; }
        public string Status { get; set; }
    }
}