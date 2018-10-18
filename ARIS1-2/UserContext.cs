using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ARIS1_2
{
    class UserContext : DbContext
    {
        public UserContext() : base("DbConnection")
        { }


        public DbSet<Clinic> Clinics { get; set; }
    }
}
