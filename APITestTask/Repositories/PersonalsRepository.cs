using APITestTask.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APITestTask.Repositories
{
    public class PersonalsRepository : IPersonalsRepository
    {
        private readonly PersonalsContext _context;

        public PersonalsRepository(PersonalsContext context)
        {
            _context = context;
        }
        public async Task<Personal> Create(Personal personal)
        {
            personal.DateOpen = DateTime.Now;
            personal.DateClose = new DateTime();
            _context.Personals.Add(personal);
            await _context.SaveChangesAsync();
            return personal;
        }

        public async Task Delete(int id, Personal personal)
        {
            var personalToDelete = await _context.Personals.FindAsync(id);
             _context.Personals.Remove(personalToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Personal>> Get()
        {
            return await _context.Personals.ToListAsync();
        }

        public async Task<Personal> GetId(int id)
        {
            return await _context.Personals.FindAsync(id);
        }

        public async Task Update(Personal personal)
        {
            _context.Entry(personal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }   
}
