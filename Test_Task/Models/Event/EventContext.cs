using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Test_Task.Models.Event;

namespace Test_Task.Models.Event
{
    public class EventContext : DbContext
    {
        public EventContext() : base("DefaultConnection") { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasKey<string>(u => u.Id);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            base.OnModelCreating(modelBuilder);
        }
    }
}