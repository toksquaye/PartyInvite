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
        {
            return View();
        }

        //POST : Add new guests
        [HttpPost]
        public ActionResult New(GuestsNew form)
        {
            var guest = new Guest();
            guest.Name = form.Name;
            guest.Email = form.Email;
            Database.Session.Save(guest);

            return RedirectToAction("index");
           
        }
    }
}