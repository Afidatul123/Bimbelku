using Bimbelku.Data;
using Bimbelku.Helper;
using Bimbelku.Models;
using Bimbelku.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bimbelku.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IService _service;
        private readonly EmailService _email;
        private static int _OTP;
        public AccountController(AppDbContext context, IService serv, EmailService email)
        {
            _context = context;
            _service = serv;
            _email = email;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User datauser, int otp)
        {
            if (otp == _OTP){

                Roles rolenya = _context.Tb_Roles.FirstOrDefault(u => u.Id == "2");
                datauser.Roles = rolenya;
                _context.Tb_User.Add(datauser);
                _context.SaveChanges();

                return RedirectToAction("Login");
            } 
            return View(datauser);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User datauser)
        {
            var usernya = _context.Tb_User
                .Where(u => u.Username == datauser.Username
                    && u.Password == datauser.Password)
                .Include(u => u.Roles).FirstOrDefault();

            if (usernya != null)
            {
                var login = new List<Claim>
                {
                    new Claim("Username", usernya.Username),
                    new Claim("Role", usernya.Roles.Name),
                };

                await HttpContext.SignInAsync(
                    new ClaimsPrincipal(
                        new ClaimsIdentity(login, "Cookies", "Username", "Role")
                    )
                );

                if (usernya.Roles.Name == "Admin")
                {
                    return Redirect("/Admin/Home");
                }
                else if (usernya.Roles.Name == ("User"))
                {
                    return Redirect("/User/Home");
                }
                return Redirect("Index");
            }

            if (!string.IsNullOrEmpty(usernya.Username) && !string.IsNullOrEmpty(usernya.Password))
            {
                ViewBag.Pesan = "Pengguna Tidak Ditemukan";
            }

            return View(datauser);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [HttpPost]
        public object KirimOTP(string tujuan)
        {
            var cariEmail = _context.Tb_User.FirstOrDefault(o => o.Email == tujuan);

            if (cariEmail != null) return new { result = false, message = "Email " + tujuan + " sudah terdaftar" };

            Bantuan _bantu = new Bantuan();
            _OTP = _bantu.KodeOTP();

            string subjek = "Confirmation Code For Bimbelku";

            string isi =
                "<h3>Berikut OTP anda </br> Gunakan Kode Ini Untuk Masuk ke akun Bimbelku"
                + _OTP.ToString()
                + "</i></h3>";

            bool cek = _email.KirimEmail(tujuan, subjek, isi); 

            if (cek) return new { result = true, message = "Email berhasil dikirimkan ke " + tujuan };

            return new { result = false, message = "Email " + tujuan + " tidak ditemukan" };
        }
    }
}
