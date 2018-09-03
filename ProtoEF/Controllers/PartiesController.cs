using Microsoft.AspNetCore.Mvc;
using ProtoEF.Data;
using ProtoEF.Models;
using ProtoEF.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoEF.Controllers
{
    public class PartiesController : Controller
    {
        private ApplicationDbContext _db;

        public PartiesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            VMParty vmParty = new VMParty(_db,false);

            return View(vmParty);
        }

        public IActionResult Create()
        {
            var vmParty = new VMParty(_db);
            return View(vmParty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Party party)
        {
            if (!ModelState.IsValid)
            {
                var vmParty = new VMParty(_db);
                vmParty.Parties = new List<Party> { party};
                

                return View(vmParty);
            }

            _db.Parties.Add(party);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            var vmParty = new VMParty(_db)
            {
                Parties = _db.Parties.Where(v => v.PartyId == Id)
            };

            return View(vmParty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, Party party)
        {
            if (!ModelState.IsValid)
                return View(party);

            if (Id != party.PartyId)
                return NotFound();

            _db.Parties.Update(party);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // todo: Ask confirmation when delete
        public async Task<IActionResult> Delete(int Id)
        {
            var party = _db.Parties.SingleOrDefault(v => v.PartyId == Id);
            if (party == null)
                return NotFound();

            _db.Parties.Remove(party);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int Id)
        {
            var vmParty = new VMParty(_db)
            {
                Parties = _db.Parties.Where(v => v.PartyId == Id)
            };

            return View(vmParty);
        }
    }
}