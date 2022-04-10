using Bimbelku.Models;
using Bimbelku.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bimbelku.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SoalController : Controller
    {
        private readonly IService _service;
        public SoalController(IService s)
        {
            _service = s;
        }
        public IActionResult TampilSoal()
        {
            var datamateri = _service.AllSoal();
            return View(datamateri);
        }

        public IActionResult CreateSoal()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSoal(Soal data, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                _service.CreateSoal(data, file);
                return RedirectToAction("TampilSoal");
            }
            return View(data);
        }

        public IActionResult EditSoal(int id)
        {
            var caridata = _service.SoalById(id);
            if (caridata != null)
            {
                return View(caridata);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult EditSoal(Soal dtsoal)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateSoal(dtsoal);
                return RedirectToAction("TampilSoal");
            }
            return View(dtsoal);
        }

        public IActionResult DeleteSoal(int id)
        {
            _service.DeleteSoal(id);
            return RedirectToAction("TampilSoal");
        }

        public IActionResult DetailsSoal(int id)
        {
            var datamateri = _service.SoalById(id);
            return View(datamateri);
        }
    }
}
