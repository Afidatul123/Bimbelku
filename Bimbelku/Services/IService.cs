using Bimbelku.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bimbelku.Services
{
    public interface IService
    {
        //Materi 
        List<Materi> AllMateri();
        Materi MateriById(string id);
        bool CreateMateri(Materi datamateri, IFormFile filemateri);
        bool UpdateMateri(Materi dtmateri);
        bool DeleteMateri(string id);

        //Soal
        List<Soal> AllSoal();
        Soal SoalById(int id);
        bool CreateSoal(Soal datasoal, IFormFile filesoal);
        bool UpdateSoal(Soal dtsoal);
        bool DeleteSoal(int id);

        //User
        List<User> AllUser();
        User UserByUsername(string username);
        User UserByUsernameAndPAss(string username, string password);
        bool CreateUser(User datauser);

        //Roles 
        List<Roles> AllRole();
        Roles RoleById(string id);

    }
}
