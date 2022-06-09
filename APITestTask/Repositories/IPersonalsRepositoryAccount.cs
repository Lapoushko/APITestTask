using APITestTask.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using static APITestTask.Model.Personal;

namespace APITestTask.Repositories
{
    public interface IPersonalsRepositoryAccount
    {
        Task<IEnumerable<PersonalAccount>> Get();
        Task<PersonalAccount> GetId(int id);
        Task<PersonalAccount> Create(PersonalAccount personal);
        Task Update(PersonalAccount personal);
        Task Delete(int id, PersonalAccount personal);
    }
}
