using APITestTask.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APITestTask.Repositories
{
    public interface IPersonalsRepository
    {
        Task<IEnumerable<Personal>> Get();
        Task<Personal> GetId(int id);
        //Task<Personal> Create(Personal personal);
        Task Update(Personal personal);
        Task Delete(int id, Personal personal);
    }

    
}
