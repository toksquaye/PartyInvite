using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyInvites.Areas.Admin.ViewModels
{
    public class RoleCheckbox
    {//this class is used to list the roles for a guest.
        public int Id { get; set; }
        public bool IsChecked { get; set; }
        public string Role { get; set; }
    }
    
    public class GuestsIndex
        {
            //this grabs the user entity defined in Models namespace
            public IEnumerable<Guest> Guests { get; set; }
        }

    public class GuestsNew
    {
        public IList<RoleCheckbox> Roles { get; set; }

        [Required, MaxLength(128)]
        public string Name { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MaxLength(256), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}