using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Task.Models.Event
{
    [Serializable]
    public class Field
    {
        public int FieldId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }

        public int? EventId { get; set; }

        public Event Event { get; set; }

        public Field()
        {
            Title = "undefined";
            Value = "undefined";
        }

        public Field(string title, object value)
        {
            Title = title;
            Value = value.ToString();
        }
    }
}