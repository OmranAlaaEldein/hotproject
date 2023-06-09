﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }
        [Required]
        [MaxLength(20)]
        public string LastName { set; get; }

        public string Address { set; get; }


    }
}
