using SBData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBData.Repositories
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> Get();
        Task<Address> Get(int id);
        Task<Address> Create(Address address);
        Task Update (Address address);
        Task Delete(int id);
    }
}
