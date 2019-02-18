using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Test_Task.Models.Event
{
    [Serializable]
    public class UserInfo
    {
        public int Id { get; set; }

        [Display(Name="Имя")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Некорректное имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Некорректная фамилия")]
        public string Surname { get; set; }

        public string UserId { get; set; }
    }
}