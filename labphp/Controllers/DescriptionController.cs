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
        private ApplicationContext db;
        public DescriptionController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            List<SubscriptionsList> subscriptionsLists = new List<SubscriptionsList>(); //Лист абонементов после выборки
            List<int> indexes = new List<int>(); //Индексы абонементов в БД

            //Заполнение индексов
            foreach (Subscription item in db.Subscriptions.ToList())
            {
                indexes.Add(item.Id);
            }

            //Выборки для каждого абонемента
            for (int i = 0; i < db.Subscriptions.ToList().Count; i++)
            {
                //Список всех аттракционов для каждого абонемента
                var result1 = from sb in db.Subscriptions
                             join al in db.SubscriptionAttractions on sb.Id equals al.SubscriptionId
                             join rd in db.Attractions on al.AttractionId equals rd.Id
                             where sb.Id == indexes[i]
                             select new
                             {
                                 RideName = rd.Name,
                                 RideDescription = rd.Description,
                                 RideMaxSeat = rd.MaxFreeSeat,
                                 RideId = rd.Id
                             };

                //Список всех услуг для каждого абонемента
                var result2 = from sb in db.Subscriptions
                              join sl in db.SubscriptionServices on sb.Id equals sl.SubscriptionId
                              join sv in db.Services on sl.ServiceId equals sv.Id
                              where sb.Id == indexes[i]
                              select new
                              {
                                  ServiceName = sv.Name,
                                  ServiceDescription = sv.Description,
                                  ServiceId = sv.Id
                              };

                //Создания нового абонемента
                subscriptionsLists.Add(new SubscriptionsList()
                    {
                        Subscription = db.Subscriptions.ToList()[i],
                        Attractions = new List<Attraction>(),
                        Services = new List<Service>()
                    });

                //Заполнение списка каждого аттракциона
                foreach (var item in result1)
                {
                    subscriptionsLists[i].Attractions.Add(
                        new Attraction
                        {
                            Id = item.RideId,
                            Name = item.RideName,
                            Description = item.RideDescription,
                            MaxFreeSeat = item.RideMaxSeat
                        });
                }

                //Заполнение списка каждой услуги
                foreach (var item in result2)
                {
                    subscriptionsLists[i].Services.Add(
                        new Service()
                        {
                            Id = item.ServiceId,
                            Name = item.ServiceName,
                            Description = item.ServiceDescription
                        });
                }
            }
            return View(subscriptionsLists);
        }
    }
}
