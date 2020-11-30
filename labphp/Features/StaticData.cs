using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AmusementPark.Models
{
    public class StaticData
    {
        public static List<SelectListItem> names = new List<SelectListItem>();
        public static List<SelectListItem> namesAttractions = new List<SelectListItem>();
        public static List<SelectListItem> namesServices = new List<SelectListItem>();
        public static List<Attraction> Attractions = new List<Attraction>();
        public static List<Service> Services = new List<Service>();
        public static string getRandom()
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            char[] chars = new char[36];
            for (int i = 0; i < 36; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
    }

    public static class temp
    {
        public static string DisplayName(this Enum value)
        {
            Type enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);
            MemberInfo member = enumType.GetMember(enumValue)[0];

            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            var outString = ((DisplayAttribute)attrs[0]).Name;

            if (((DisplayAttribute)attrs[0]).ResourceType != null)
            {
                outString = ((DisplayAttribute)attrs[0]).GetName();
            }

            return outString;
        }
    }
}
