using Microsoft.AspNetCore.Mvc;
using ProtoEF.Data;
using ProtoEF.Models;
using ProtoEF.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoEF.Controllers
{
    public class CountriesController : Controller
    {
        private ApplicationDbContext _db;

        public CountriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var countries = _db.Countries.ToList();
            return View(countries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Country country)
        {
            if (!ModelState.IsValid)
                return View(country);

            _db.Countries.Add(country);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            var country = _db.Countries.SingleOrDefault(c => c.CountryId == Id);
            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, Country country)
        {
            if (!ModelState.IsValid)
                return View(country);

            if (Id != country.CountryId)
                return NotFound();

            _db.Countries.Update(country);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // todo: Ask confirmation when delete
        public async Task<IActionResult> Delete(int Id)
        {
            var country = _db.Countries.SingleOrDefault(v => v.CountryId == Id);
            if (country == null)
                return NotFound();

            _db.Countries.Remove(country);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}