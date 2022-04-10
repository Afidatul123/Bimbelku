using Bimbelku.Helper;
using Bimbelku.Models;
using Bimbelku.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bimbelku.Controllers.Api
{
    [Route("Api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IService _service;
        private Bantuan _bantu = new();

        private object _respon;
        private object _objek;

        private string StMateri = "Materi";
        ///private string StSoal = "Soal";
        private string StUser = "User";
        private string StRoles = "Roles";
        public HomeController(IService s)
        {
            _service = s;
        }
        [Route("Materi")]
        public IActionResult Materi()
        {
            _objek = _service.AllMateri();

            _respon = _bantu.ResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(StMateri), _objek);
            return Ok(_respon);
        }
        [Route("Materi")]
        [HttpPost]
        public IActionResult TambahBlog(Materi datamateri, IFormFile filemateri)
        {
            if (ModelState.IsValid)
            {
                _service.CreateMateri(datamateri, filemateri);

                _respon = _bantu.ResponAPI(_bantu.CodeOk, _bantu.PesanTambahSukses(StMateri), datamateri);
                return Ok(_respon);
            }
            _respon = _bantu.ResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(StMateri), null);
            return Ok(_respon);
        }

        //User
        [Route("User")]
        public IActionResult Users()
        {
            _objek = _service.AllUser();
            _respon = _bantu.ResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(StUser), _objek);
            return Ok(_respon);
        }
        //Roles
        [Route("Roles")]
        public IActionResult Roles()
        {
            _objek = _service.AllRole();

            _respon = _bantu.ResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(StRoles), _objek);
            return Ok(_respon);
        }

    }
}
