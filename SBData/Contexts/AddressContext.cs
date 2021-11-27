using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBData.Entities;

namespace SBData.Contexts
{
    public class AddressContext : DbContext
    {

        public AddressContext(DbContextOptions<AddressContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Address> Addresses { get; set; }


    }
}