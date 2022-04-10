using Bimbelku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bimbelku.Repository
{
    public interface IRepository
    {
        //Materi
        Task<bool> CreateMateriAsync(Materi datamateri);
        Task<List<Materi>> AllMateriAsync();
        Task<Materi> MateriByIdAsync(string id);
        Task<bool> UpdateMateriAsync(Materi datamateri);
        Task<bool> DeleteMateriAsync(Materi datamateri);

        //Soal
        Task<bool> CreateSoalAsync(Soal datasoal);
        Task<List<Soal>> AllSoalAsync();
        Task<Soal> SoalByIdAsync(int Id);
        Task<bool> UpdateSoalAsync(Soal datasoal);
        Task<bool> DeleteSoalAsync(Soal dtsoal);

        //User
        Task<List<User>> AllUserAsync();
        Task<bool> CreateUserAsync(User datauser);
        Task<User> UserByUsernameAsync(string username);
        Task<User> UserByUsernameAndPassAsync(string username, string password);

        //Roles
        Task<List<Roles>> AllRolesAsync();
        Task<Roles> RolesByIdAsync(string id);
    }
}
