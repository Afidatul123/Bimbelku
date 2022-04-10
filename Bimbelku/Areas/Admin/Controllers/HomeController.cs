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
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IService _service;
        public HomeController(IService s)
        {
            _service = s;
        }
        public IActionResult Index()
        {
            var datamateri = _service.AllMateri();
            return View(datamateri);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Materi data, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                _service.CreateMateri(data, file);
                return RedirectToAction("Index");
            }
            return View(data);
        }

        public IActionResult Edit(string id)
        {
            var caridata = _service.MateriById(id);
            if (caridata != null)
            {
                return View(caridata); 
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Materi datamateri)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateMateri(datamateri);
                return RedirectToAction("Index");
            }
            return View(datamateri);
        }

        public IActionResult Delete(string id)
        {
            _service.DeleteMateri(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(string id)
        {
            var datamateri = _service.MateriById(id);
            return View(datamateri);
        }

        public IActionResult Tampil()
        {
            var semuadata = new UserDashboard();
            semuadata.user = _service.AllUser();
            semuadata.roles = _service.AllRole();

            return View(semuadata);
        }
    }
}
