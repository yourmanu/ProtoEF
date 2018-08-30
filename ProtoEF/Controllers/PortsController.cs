using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProtoEF.Data;
using ProtoEF.Models;
using ProtoEF.ViewModels;

namespace ProtoEF.Controllers
{
    public class PortsController : Controller
    {
        private ApplicationDbContext _db;
        public PortsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            VMPort ports = new VMPort();
                ports.Ports=_db.Ports.ToList();
                //ports.PortTypes = new List<PortType>
                //{
                //    new PortType { PortTypeId = "S", PortTypeName = "Sea Port" },
                //    new PortType { PortTypeId = "A", PortTypeName = "Air Port" }
                //};
            return View(ports);
        }

        public IActionResult Create()
        {
            var vm = new VMPort();
            //vm.PortTypes = new List<PortType>
            //    {
            //        new PortType { PortTypeId = "S", PortTypeName = "Sea Port" },
            //        new PortType { PortTypeId = "A", PortTypeName = "Air Port" }
            //    };
            return View(vm);
            //return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Port port)
        {
            if (!ModelState.IsValid)
                return View(port);

            _db.Ports.Add(port);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            VMPort vmport = new VMPort();
            vmport.Ports = _db.Ports.Where(v => v.PortId == Id);
            //vmport.PortTypes = new List<PortType>
            //    {
            //        new PortType { PortTypeId = "S", PortTypeName = "Sea Port" },
            //        new PortType { PortTypeId = "A", PortTypeName = "Air Port" }
            //    };

            return View(vmport);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id,Port port)
        {
            if (!ModelState.IsValid)
                return View(port);

            if (Id != port.PortId)
                return NotFound();

            _db.Ports.Update(port);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        // todo: Ask confirmation when delete
        public async Task<IActionResult> Delete(int Id)
        {
            var port = _db.Ports.SingleOrDefault(v => v.PortId == Id);
            if (port == null)
                return NotFound();

            _db.Ports.Remove(port);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}