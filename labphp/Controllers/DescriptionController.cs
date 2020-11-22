using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmusementPark.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmusementPark.Controllers
{
    public class DescriptionController : Controller
    {
        private readonly ApplicationContext db;
        public DescriptionController(ApplicationContext context)
        {
            db = context;
            StaticData.Attractions = db.Attractions.ToList();
            StaticData.Services = db.Services.ToList();
        }

        public IActionResult Index()
        {
            List<SubscriptionsList> subscriptionsLists = db.Subscriptions.Select(subscription => new SubscriptionsList
            {
                Subscription = subscription,
                Attractions = subscription.SubscriptionAttractions.Select(subAtt => subAtt.Attraction).ToList(),
                Services = subscription.SubscriptionServices.Select(subServ => subServ.Service).ToList(),
            }).ToList();
            return View(subscriptionsLists);
        }
    }
}
