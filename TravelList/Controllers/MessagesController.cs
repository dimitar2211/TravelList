using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelList.Models;

namespace TravelList.Controllers
{
    public class MessageController : Controller
    {
        private static List<Message> messages = new List<Message>();

        public IActionResult Index()
        {
            messages = messages
                .Where(m => m.CreatedAt > DateTime.Now.AddHours(-24))
                .ToList();

            return View("~/Views/Messages/Index.cshtml", messages);

        }

        [HttpPost]
        public IActionResult SendMessage(string name, string content)
        {
            if (!string.IsNullOrEmpty(content))
            {
                messages.Add(new Message
                {
                    Name = string.IsNullOrEmpty(name) ? "Anonymous" : name,
                    Content = content,
                    CreatedAt = DateTime.Now,
                    Likes = 0
                });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult LikeMessage(int messageId)
        {
            if (messageId >= 0 && messageId < messages.Count)
            {
                messages[messageId].Likes++;
            }

            return RedirectToAction("Index");
        }
    }
}
