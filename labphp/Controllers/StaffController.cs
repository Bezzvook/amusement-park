using AmusementPark.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AmusementPark.Controllers
{
    [Authorize]
    public class StaffController : Controller
    {
        private readonly ApplicationContext db;
        public StaffController(ApplicationContext context)
        {
            db = context;
            StaticData.names.Clear();
            StaticData.namesAttractions.Clear();
            StaticData.namesServices.Clear();
            foreach (var item in db.Subscriptions)
            {
                StaticData.names.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            foreach (var item in db.Attractions)
            {
                StaticData.namesAttractions.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            foreach (var item in db.Services)
            {
                StaticData.namesServices.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            StaticData.Attractions = db.Attractions.ToList();
            StaticData.Services = db.Services.ToList();
        }
        public IActionResult Index()
        {
            List<Booking> bookings = db.Booking.ToList();
            foreach (var item in bookings)
            {
                item.Client = db.Clients.FirstOrDefault(p => p.Id == item.ClientId);
            }
            return View(bookings.OrderByDescending(p => p.Id));
        }
        //Отмена бронирования с админ панели
        [HttpGet]
        [ActionName("Reject")]
        public IActionResult ConfirmReject(int? id)
        {
            if (id != null)
            {
                Booking booking = db.Booking.FirstOrDefault(p => p.Id == id);
                if (booking != null)
                    return View(booking);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Reject(int? id)
        {
            if (id != null)
            {
                Booking booking = db.Booking.FirstOrDefault(p => p.Id == id);
                if (booking != null)
                {
                    Client client = db.Clients.FirstOrDefault(p => p.Id == booking.ClientId);
                    booking.Status = Status.Rejected;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Staff");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                Booking booking = db.Booking.FirstOrDefault(p => p.Id == id);
                if (booking != null)
                {
                    booking.Client = db.Clients.FirstOrDefault(p => p.Id == booking.ClientId);
                    return View(booking);
                }
            }
            return RedirectToAction("Index", "Home");
        }
        //Отмена бронирования с админ панели
        [HttpGet]
        [ActionName("Approve")]
        public IActionResult ConfirmApprove(int? id)
        {
            if (id != null)
            {
                Booking booking = db.Booking.FirstOrDefault(p => p.Id == id);
                if (booking != null)
                    return View(booking);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Approve(int? id)
        {
            if (id != null)
            {
                Booking booking = db.Booking.FirstOrDefault(p => p.Id == id);
                if (booking != null)
                {
                    Client client = db.Clients.FirstOrDefault(p => p.Id == booking.ClientId);
                    booking.Status = Status.Approved;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Staff");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        //Редактор абонементов
        public IActionResult SubscriptionEdit()
        {
            List<SubscriptionsList> subscriptionsLists = db.Subscriptions.Select(subscription => new SubscriptionsList
            {
                Subscription = subscription,
                Attractions = subscription.SubscriptionAttractions.Select(subAtt => subAtt.Attraction).ToList(),
                Services = subscription.SubscriptionServices.Select(subServ => subServ.Service).ToList(),
            }).ToList();
            return View(subscriptionsLists);
        }

        public IActionResult CreateSubscription()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSubscription(Subscription s)
        {
            db.Subscriptions.Add(s);
            db.SaveChanges();
            return RedirectToAction("SubscriptionEdit", "Staff");
        }


        public IActionResult CreateAttraction()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAttraction(Attraction s)
        {
            db.Attractions.Add(s);
            db.SaveChanges();
            return RedirectToAction("SubscriptionEdit", "Staff");
        }

        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateService(Service s)
        {
            db.Services.Add(s);
            db.SaveChanges();
            return RedirectToAction("SubscriptionEdit", "Staff");
        }

        [HttpGet]
        [ActionName("AddAttraction")]
        public IActionResult AddNewAttraction()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAttraction(SubscriptionAttraction subscriptionAttraction)
        {
            if (subscriptionAttraction != null)
            {
                db.SubscriptionAttractions.Add(subscriptionAttraction);
                db.SaveChanges();
                return RedirectToAction("Index", "Staff");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(SubscriptionService subscriptionService)
        {
            if (subscriptionService != null)
            {
                db.SubscriptionServices.Add(subscriptionService);
                db.SaveChanges();
                return RedirectToAction("Index", "Staff");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}