using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotSoSmartSaverAPI.ModelsGenerated
{
    public partial class Users
    {
        public string Userid { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "A valid email address has to be entered")]
        public string Useremail { get; set; }

        [Required]
        public string Userpassword { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "User name is too long, maximum lenght is  30")]
        public string Username { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "User last name is too long, maximum lenght is  30")]
        public string Userlastname { get; set; }
        public float? Usermoney { get; set; }
    }
}
