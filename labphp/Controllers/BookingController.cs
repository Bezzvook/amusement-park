using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmusementPark.Features;
using AmusementPark.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmusementPark.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationContext db;
        public BookingController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Get(string link)
        {
            if (link != null)
            {
                Client client = db.Clients.FirstOrDefault(p => p.Link == link);
                if (client != null)
                    client.Bookings = db.Booking.ToList();
                    return View(client);
            }
            return Redirect("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBookingAsync(Booking booking)
        {
            booking.Checked = false;
            booking.Accepted = false;

            if (db.Clients.Any(ph => ph.Email == booking.Client.Email))
            {
                booking.Client = db.Clients.FirstOrDefault(p => p.Email == booking.Client.Email);
            }

            else
            {
                string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                Random random = new Random();

                char[] chars = new char[36];
                for (int i = 0; i < 36; i++)
                {
                    chars[i] = validChars[random.Next(0, validChars.Length)];
                }

                booking.Client.Link = new string(chars);
            }

            db.Booking.Add(booking);
            db.SaveChanges();

            ViewBag.Name = booking.FullName;

            string l = "https://localhost:5001/Booking/Get/" + booking.Client.Link;
            await GmailData.SendEmailAsync(booking.Client.Email, "Бронирование", new string(booking.FullName + ", спасибо за бронирование!\nСсылка на Ваш кабинет: " + l));
            return View();
        }
    }
}
