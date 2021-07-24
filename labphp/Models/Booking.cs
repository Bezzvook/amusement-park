using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите имя пользователя")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [StringLength(12, ErrorMessage = "Номер телефона состоять из 12 цифр")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Введите время бронирования")]
        public DateTime? BookingDate { get; set; }

        [Required(ErrorMessage = "Введите количество билетов для взрослых")]
        public int? AdultTickets { get; set; }

        [Required(ErrorMessage = "Введите количество билетов для детей")]
        public int? ChildTickets { get; set; }

        public Status Status { get; set; }

        public Subscription Subscription { get; set; }
        public int SubscriptionId { get; set; }

        public Client Client { get; set; }
        public int ClientId { get; set; }
    }

    public enum Status
    {
        [Display(Name = "Ожидает подтверждения")]
        Submitted,
        [Display(Name = "Подтверждено")]
        Approved,
        [Display(Name = "Отменено")]
        Rejected
    }
}
