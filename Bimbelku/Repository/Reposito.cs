using Bimbelku.Data;
using Bimbelku.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bimbelku.Repository
{
    public class Reposito : IRepository
    {
        private readonly AppDbContext _data;
        public Reposito(AppDbContext data)
        {
            _data = data;
        }

        //User
        public async Task<User> UserByUsernameAsync(string username)
        {
            return await _data.Tb_User.Include(user => user.Roles).FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> UserByUsernameAndPassAsync(string username, string password)
        {
            return await _data.Tb_User.Include(user => user.Roles).FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

        }

        public async Task<List<User>> AllUserAsync()
        {
            return await _data.Tb_User.Include(user => user.Roles).ToListAsync();
        }

        public async Task<bool> CreateUserAsync(User datauser)
        {
            _data.Tb_User.Add(datauser);
            await _data.SaveChangesAsync();
            return true;
        }

        //Roles
        public async Task<List<Roles>> AllRolesAsync()
        {
            return await _data.Tb_Roles.ToListAsync();
        }

        public async Task<Roles> RolesByIdAsync(string id)
        {
            return await _data.Tb_Roles.FirstOrDefaultAsync(role => role.Id == id);
        }

        //Materi
        public async Task<bool> CreateMateriAsync(Materi datamateri)
        {
            _data.Tb_Materi.Add(datamateri);
            await _data.SaveChangesAsync();
            return true;
        }

        public async Task<List<Materi>> AllMateriAsync()
        {
            return await _data.Tb_Materi.ToListAsync();
        }

        public async Task<bool> UpdateMateriAsync(Materi datamateri)
        {
            _data.Tb_Materi.Update(datamateri);
            await _data.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMateriAsync(Materi datamateri)
        {
            _data.Tb_Materi.Remove(datamateri);
            await _data.SaveChangesAsync();
            return true;
        }
        public async Task<Materi> MateriByIdAsync(string id)
        {
            return await _data.Tb_Materi.FirstOrDefaultAsync(m => m.Id == id);
        }

        //Soal
        public async Task<bool> CreateSoalAsync(Soal datasoal)
        {
            _data.Tb_Soal.Add(datasoal);
            await _data.SaveChangesAsync();
            return true;
        }

        public async Task<List<Soal>> AllSoalAsync()
        {
            return await _data.Tb_Soal.ToListAsync();
        }

        public async Task<Soal> SoalByIdAsync(int Id)
        {
            return await _data.Tb_Soal.FirstOrDefaultAsync(s => s.Id == Id);
        }

        public async Task<bool> UpdateSoalAsync(Soal datasoal)
        {
            _data.Tb_Soal.Update(datasoal);
            await _data.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSoalAsync(Soal dtsoal)
        {
            _data.Tb_Soal.Remove(dtsoal);
            await _data.SaveChangesAsync();
            return true;
        }
    }
}
