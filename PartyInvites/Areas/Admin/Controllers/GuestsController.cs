using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
using PartyInvites.Models;
using PartyInvites.Areas.Admin.ViewModels;

namespace PartyInvites.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")] //only a logged in admin can use controller
    public class GuestsController : Controller
    {
        // GET: Admin/Guests
        public ActionResult Index()
        {
            return View(new GuestsIndex
                {
                    Guests = Database.Session.Query<Guest>().ToList()
                });
        }

        //GET: Add new guests
        public ActionResult New()
        {//must initialize Roles here
            return View(new GuestsNew 
            {
                Roles = Database.Session.Query<RoleNames>().Select(role => new RoleCheckbox
                {
                    Id = role.Id,
                    IsChecked = false,
                    Role = role.Role
                }).ToList()
            });
        }

        //POST : Add new guests
        [HttpPost]
        public ActionResult New(GuestsNew form)
        {
            var guest = new Guest();

            SyncRoles(form.Roles, guest.Role);
            guest.Name = form.Name;
            guest.PasswordHash = form.Password;
            guest.Email = form.Email;
            Database.Session.Save(guest);

            return RedirectToAction("index");
           
        }

        private void SyncRoles(IList<RoleCheckbox> checkboxes, IList<RoleNames> roles)
        {
            var selectedRoles = new List<RoleNames>();
            foreach (var role in Database.Session.Query<RoleNames>())
            {
                var checkbox = checkboxes.Single(c => c.Id == role.Id);
                checkbox.Role = role.Role;

                if (checkbox.IsChecked)
                    selectedRoles.Add(role);
            }
            foreach (var toAdd in selectedRoles.Where(t => !roles.Contains(t)))
                roles.Add(toAdd);

            foreach (var toRemove in roles.Where(t => !selectedRoles.Contains(t)).ToList())
                roles.Remove(toRemove);
        }
    }
}