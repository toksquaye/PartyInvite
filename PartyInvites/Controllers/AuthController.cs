using PartyInvites.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NHibernate.Linq;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AuthLogin form, string returnUrl)
        {
            var guest = Database.Session.Query<Guest>().FirstOrDefault(g => g.Name == form.Name);

            //this is to prevent timing attacks during login
            //the time to check for a user that isn't in the db and the time
            //that checks for a user that is in the db is now similar
            //if (user == null)
                //SimpleBlog.Models.User.FakeHash();

            if (guest == null)
                ModelState.AddModelError("Name", "Invalid Name Entered");

            if (!ModelState.IsValid) //if validation check fails
                return View(form);  //give user form back



            //tell asp.net a person is who he says he is. letting asp know what user is logged in
            FormsAuthentication.SetAuthCookie(guest.Name, true);

            //return guest to the page they were trying to go before the logged on
            if (!string.IsNullOrWhiteSpace(returnUrl))
                return Redirect(returnUrl);

            return RedirectToRoute("rsvp");
            
        }
    }
}