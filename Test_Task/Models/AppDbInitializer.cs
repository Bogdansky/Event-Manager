﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Test_Task.Models.Event;

namespace Test_Task.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<EventContext>
    {
        protected override void Seed(EventContext db)
        {
            base.Seed(db);
        }
    }
}