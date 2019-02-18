using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Test_Task.Models;
using Test_Task.Models.Event;
using Test_Task.Repositories;

namespace Test_Task.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        EventContext db = new EventContext();
        readonly EventRepository eventRepository = new EventRepository();

        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            var userInfo = db.UserInfo.FirstOrDefault(u => u.UserId == id);
            if (userInfo == null)
            {
                TempData["Message"] = "Добавьте своё имя и фамилию";
                return View("About");
            }
            ViewBag.UserInfo = userInfo;
            return View();
        }

        [HttpPost]
        async public Task<RedirectToRouteResult> About(UserInfo info)
        {
            info.UserId = User.Identity.GetUserId();
            db.UserInfo.Add(info);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult CreateEvent()
        {
            return View("CreateEvent");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult CreateEvent(Event eventModel)
        {
            if (ModelState.IsValid)
            { 
                int count = db.Events.Count(e => e.Name == eventModel.Name);
                if (count == 0)
                {
                    eventModel.UserId = User.Identity.GetUserId();
                    db.Events.Add(eventModel);
                    db.SaveChanges();
                    TempData["Message"] = "Событие успешно добавлено";
                }
                else
                {
                    ModelState.AddModelError("Name", "Событие с таким названием уже существует");
                }
            }
            else
            {
                TempData["Message"] = "Введённые данные некорректны";
            }
            return View();
        }

        [HttpGet]
        public ActionResult ShowEvents()
        {
            List<Event> events = eventRepository.GetActualEvents();//db.Events.ToList()
            List<Field> fields = db.Fields.ToList();
            if (events.Count == 0)
            {
                TempData["ResultMessage"] = "В данный момент мероприятий нет";
            }
            else
            {
                var eventUsers = db.EventUsers.ToList();
                ViewBag.Events = events;
                ViewBag.Fields = fields;
            }
            return View("EventsView");
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public ActionResult Subscribe(int eventId)
        {
            Event currentEvent = eventRepository.GetItem(eventId);
            string userId = User.Identity.GetUserId();
            int amount = db.EventUsers.Where(eu => eu.EventId == eventId && eu.UserId == userId).Count();
            if (currentEvent == null)
            {
                return HttpNotFound();
            }
            TempData["ResultMessage"] = DoSub(amount, currentEvent, userId, eventId);
            return RedirectToAction("ShowEvents", "Home");
        }

        private string DoSub(int amount, Event currentEvent, string userId, int eventId)
        {
            if (amount == 0)
            {
                currentEvent.SignedUsers.Add(new EventUser { UserId = userId, EventId = eventId });
                db.SaveChanges();
                return "Подписка успешно оформлена";
            }
            else
            {
                return "Подписка уже оформлена";
            }
        }
    }
}