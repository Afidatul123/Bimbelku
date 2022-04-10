using Bimbelku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bimbelku.Helper
{
    public class Bantuan
    {
        public static string BuatPrimary()
        {
            Guid primary = Guid.NewGuid();
            return primary.ToString();
        }
        public int KodeOTP()
        {
            Random r = new Random();
            return r.Next(1000, 9999);
        }
        public static User ModelUser(string username, string password, string nama, string email, Roles role)
        {
            return new User
            {
                Username = username,
                Password = password,
                Nama = nama,
                Email = email,
                Roles = role
            };
        }
        public Object ResponAPI(int respon_code, string message, Object data)
        {
            return new
            {
                status = respon_code == 200 ? "SUKSES" : "GAGAL",
                respon_code,
                message,
                data
            };
        }

        // API
        public int CodeOk = 200;

        public int CodeBadRequest = 400;

        public int CodeInternalServerError = 500;

        public string PesanGetSukses(string apa)
        {
            return "Berhasil ambil data " + apa;
        }

        public string PesanTambahSukses(string apa)
        {
            return "Berhasil menambah data " + apa;
        }

        public string PesanUbahSukses(string apa)
        {
            return "Berhasil ubah data " + apa;
        }

        public string PesanHapusSukses(string apa)
        {
            return "Berhasil hapus data " + apa;
        }

        public string PesanTidakDitemukan(string apa)
        {
            return "Data " + apa + " tidak ditemukan";
        }

        public string PesanInputanSalah(string apa)
        {
            return "Inputan untuk data " + apa + " salah";
        }
    }
}
