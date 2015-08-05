using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyInvites.Areas.Admin.ViewModels
{
    
    public class GuestsIndex
        {
            //this grabs the user entity defined in Models namespace
            public IEnumerable<Guest> Guests { get; set; }
        }

    public class GuestsNew
    {
        [Required, MaxLength(128)]
        public string Name { get; set; }

        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}