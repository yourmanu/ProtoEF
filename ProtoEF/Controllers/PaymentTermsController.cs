using Microsoft.AspNetCore.Mvc;
using ProtoEF.Data;
using ProtoEF.Models;
using ProtoEF.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoEF.Controllers
{
    public class PaymentTermsController : Controller
    {
        private ApplicationDbContext _db;

        public PaymentTermsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var paymentTerm = _db.PaymentTerms.OrderBy(t=>t.CreditDays).ToList();
            return View(paymentTerm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentTerm paymentTerm)
        {
            if (!ModelState.IsValid)
                return View(paymentTerm);

            _db.PaymentTerms.Add(paymentTerm);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            var paymentTerm = _db.PaymentTerms.SingleOrDefault(c => c.PaymentTermId == Id);
            return View(paymentTerm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, PaymentTerm paymentTerm)
        {
            if (!ModelState.IsValid)
                return View(paymentTerm);

            if (Id != paymentTerm.PaymentTermId)
                return NotFound();

            _db.PaymentTerms.Update(paymentTerm);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // todo: Ask confirmation when delete
        public async Task<IActionResult> Delete(int Id)
        {
            var paymentTerm = _db.PaymentTerms.SingleOrDefault(v => v.PaymentTermId == Id);
            if (paymentTerm == null)
                return NotFound();

            _db.PaymentTerms.Remove(paymentTerm);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}