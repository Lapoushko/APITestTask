using APITestTask.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace APITestTask.Repositories
{
    public class PersonalsRepositoryAccount : IPersonalsRepositoryAccount
    {
        private readonly PersonalsContext _context;

        public PersonalsRepositoryAccount(PersonalsContext context)
        {
            _context = context;
        }

        public async Task<PersonalAccount> Create(PersonalAccount personal)
        {
            personal.DateOpen = DateTime.Now;
            personal.DateClose = new DateTime();
            _context.PersonalAccount.Add(personal);
            await _context.SaveChangesAsync();
            return personal;
        }

        public async Task Delete(int id, PersonalAccount personal)
        {
            var personalToDelete = await _context.PersonalAccount.FindAsync(id);
            _context.PersonalAccount.Remove(personalToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PersonalAccount>> Get()
        { 
           return await _context.PersonalAccount.ToListAsync();           
        }

        public async Task<PersonalAccount> GetId(int id)
        {
            return await _context.PersonalAccount.FindAsync(id);
        }

        public async Task Update(PersonalAccount personal)
        {
            _context.Entry(personal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
