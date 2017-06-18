using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;

namespace AuthenticationUser.Models
{
    [MetadataType(typeof(AllUserMetaData))]
    public partial class All_User
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="ConformPassword")]
        [Compare("Password")]//this field used for compare the fields
        public string ConformPassword { get; set; }
    }
    public class AllUserMetaData
    {

        public int Id { get; set; }
        [Required(ErrorMessage="Name Should Not Be Empty")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]//this field for showing pswd like ***
        [Display(Name = "Password")]//this field for Display the name which you want
        public string Password { get; set; }
        [Required(ErrorMessage="Email Id Must Not Be Empty.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        //[EmailAddress(ErrorMessage="Invalid Email Address.")]// this EmailAddress Attribute given by vs in 4.5 and above version
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> AddedDate { get; set; }
        
    }
}