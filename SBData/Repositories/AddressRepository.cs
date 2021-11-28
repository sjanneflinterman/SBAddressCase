using SBData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBData.Contexts;

namespace SBData.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressContext _context;

        public AddressRepository(AddressContext addressContext)
        {
            _context = addressContext;
        }

        public async Task<Address> Create(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return address;
        }

        public async Task Delete(int id)
        {
            var address = await Get(id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Address>> Get()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> Get(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public IQueryable<Address> GetQueryable()
        {
            return _context.Addresses.AsQueryable();
        }

        public async Task Update(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
