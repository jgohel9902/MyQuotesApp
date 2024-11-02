using FavouriteQuotesApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FavouriteQuotesApp.Controllers
{
    public class QuoteController : Controller
    {
        private readonly QuotesDbContext _context;
        public QuoteController(QuotesDbContext context)
        {
            _context = context;
        }
        public IActionResult Items()
        {
            var quotes = _context.Quotes.OrderByDescending(q => q.Rating).ToList();
            return View(quotes);
        }
        public IActionResult Details(int id)
        {
            var quote = _context.Quotes.Find(id);
            if (quote == null) return NotFound();
            return View(quote);
        }

        
        public IActionResult Add() => View();

        
        [HttpPost]
        public IActionResult Add(Quote quote)
        {
            if (ModelState.IsValid)
            {
                _context.Quotes.Add(quote);
                _context.SaveChanges();
                return RedirectToAction("Items");
            }
            return View(quote);
        }

        
        public IActionResult Edit(int id)
        {
            var quote = _context.Quotes.Find(id);
            if (quote == null) return NotFound();
            return View(quote);
        }

        
        [HttpPost]
        public IActionResult Edit(Quote quote)
        {
            if (ModelState.IsValid)
            {
                _context.Quotes.Update(quote);
                _context.SaveChanges();
                return RedirectToAction("Items");
            }
            return View(quote);
        }
    }
}
