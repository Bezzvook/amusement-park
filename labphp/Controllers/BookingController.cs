using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AmusementPark.Features;
using AmusementPark.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AmusementPark.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationContext db;
        public BookingController(ApplicationContext context)
        {
            db = context;

            StaticData.names.Clear();
            foreach (var item in db.Subscriptions)
            {
                StaticData.names.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        //Бронирование
        [HttpPost]
        public async Task<IActionResult> AddBookingAsync(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            else
            {
                if (booking.BookingDate < DateTime.Now)
                {
                    ViewBag.dataError = "Некорректная дата";
                    return View("Index");
                }
                booking.Status = Status.Submitted;

                if (db.Clients.Any(ph => ph.Email == booking.Client.Email))
                {
                    booking.Client = db.Clients.FirstOrDefault(p => p.Email == booking.Client.Email);
                }

                else
                {
                    booking.Client.Link = StaticData.getRandom();
                }
                await GmailData.SendEmailAsync(booking.Client.Email, "Бронирование", new string(booking.FullName
                    + ", спасибо за бронирование!\nСсылка на Ваш кабинет: " + "https://localhost:5001/Booking/Get/" + booking.Client.Link));

                ViewBag.name = booking.FullName;
                db.Booking.Add(booking);
                db.SaveChanges();
                return View();
            }
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

        //Личный кабинет
        public IActionResult Get(string id)
        {
            if (id != null)
            {
                Client client = db.Clients.FirstOrDefault(p => p.Link == id);
                if (client != null)
                {
                    client.Bookings = db.Booking.Where(h => h.Client.Link == id).OrderByDescending(a => a.Id).ToList();
                    return View(client);
                }
            }
            return RedirectToAction("Index","Home");
        }

        //Отмена бронирования с личного кабинета
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
                    return Redirect("https://localhost:5001/Booking/Get/" + booking.Client.Link);
                }
            }
            return RedirectToAction("Index", "Home");
        }
        //Отмена бронирования с личного кабинета
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
                    booking.Status = Status.Rejected;
                    db.SaveChanges();
                    return Redirect("https://localhost:5001/Booking/Get/" + booking.Client.Link);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
