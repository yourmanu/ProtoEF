using Microsoft.AspNetCore.Mvc;
using ProtoEF.Data;
using ProtoEF.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoEF.Controllers
{
    public class VesselsController : Controller
    {
        private ApplicationDbContext _db;

        public VesselsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var vessels = _db.Vessels.ToList();
            return View(vessels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vessel vessel)
        {
            if (!ModelState.IsValid)
                return View(vessel);

            _db.Vessels.Add(vessel);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            var vessel = _db.Vessels.SingleOrDefault(v => v.VesselId == Id);
            return View(vessel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, Vessel vessel)
        {
            if (!ModelState.IsValid)
                return View(vessel);

            if (Id != vessel.VesselId)
                return NotFound();

            _db.Vessels.Update(vessel);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // todo: Ask confirmation when delete
        public async Task<IActionResult> Delete(int Id)
        {
            var vessel = _db.Vessels.SingleOrDefault(v => v.VesselId == Id);
            if (vessel == null)
                return NotFound();

            _db.Vessels.Remove(vessel);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}