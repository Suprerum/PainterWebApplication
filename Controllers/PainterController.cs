using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PainterWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace PainterWebApplication.Controllers
{
    public class PainterController:Controller
    {
        public ApplicationContext db;

        public PainterController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Painters.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
           return View();
        }

        [HttpGet]
        public IActionResult Remove()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Clear()
        {
            var all = from c in db.Painters select c;
            db.Painters.RemoveRange(all);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Surname")] Painter painter)
        {
            if (ModelState.IsValid)
            {
                db.Add(painter);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(painter);
        }

        [HttpPost]
        public IActionResult Remove(int? id)
        {
            if (id == null)
            {
                RedirectToAction("Index");
            }
            var painter = db.Painters.Find(id);
            db.Painters.Remove(painter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
