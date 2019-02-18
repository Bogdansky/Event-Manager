using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test_Task.Models.Event
{
    [Serializable]
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Дата мероприятия")]
        public DateTime Date { get; set; }
        
        [Display(Name="Количество участников")]
        public int UserAmount { get; set; }

        public string UserId { get; set; }

        public ICollection<Field> AdditionalInfo { get; set; }
        public ICollection<EventUser> SignedUsers { get; set; }

        public Event()
        {
            AdditionalInfo = new List<Field>();
            SignedUsers = new List<EventUser>();
        }
    }
}   