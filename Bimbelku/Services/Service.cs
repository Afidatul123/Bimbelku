using Bimbelku.Helper;
using Bimbelku.Models;
using Bimbelku.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bimbelku.Services
{
    public class Service : IService
    {
        private readonly IRepository _repo;
        private readonly FileService _file;
        public Service(IRepository r, FileService f)
        {
            _repo = r;
            _file = f;
        }

        public List<Materi> AllMateri()
        {
            return _repo.AllMateriAsync().Result;
        }

        public List<Roles> AllRole()
        {
            return _repo.AllRolesAsync().Result;
        }

        public List<Soal> AllSoal()
        {
            return _repo.AllSoalAsync().Result;
        }

        public List<User> AllUser()
        {
            return _repo.AllUserAsync().Result;
        }

        public bool CreateMateri(Materi datamateri, IFormFile filemateri)
        {
            datamateri.Id = Bantuan.BuatPrimary();
            datamateri.FileMateri = _file.AddFile(filemateri).Result;
            return _repo.CreateMateriAsync(datamateri).Result;
        }

        public bool CreateSoal(Soal datasoal, IFormFile filesoal)
        {
            datasoal.FileSoal = _file.AddFile(filesoal).Result;
            return _repo.CreateSoalAsync(datasoal).Result;

        }

        public bool CreateUser(User datauser)
        {
            return _repo.CreateUserAsync(datauser).Result;
        }

        public bool DeleteMateri(string id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSoal(int id)
        {
            throw new NotImplementedException();
        }

        public Materi MateriById(string id)
        {
            return _repo.MateriByIdAsync(id).Result;
        }

        public Roles RoleById(string id)
        {
            return _repo.RolesByIdAsync(id).Result;
        }

        public Soal SoalById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMateri(Materi dtmateri)
        {
            _repo.UpdateMateriAsync(dtmateri);
            return true;
        }

        public bool UpdateSoal(Soal dtsoal)
        {
            _repo.UpdateSoalAsync(dtsoal);
            return true;
        }

        public User UserByUsername(string username)
        {
            return _repo.UserByUsernameAsync(username).Result;
        }

        public User UserByUsernameAndPAss(string username, string password)
        {
            return _repo.UserByUsernameAndPassAsync(username, password).Result;
        }

    }
}
