using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DoctorApp.DM;

namespace DoctorApp.DAL
{
    public class DocAppContext : DbContext
    {
        public DocAppContext() : base("name= DocAppConnectionString")
        {
           
        }

       

        public DbSet<Specialized> Specialized { get; set; }
        public DbSet<Country> Countries { get; set; } 
        public DbSet<DoctorRegistration>DoctorRegistrations { get; set; } 
        
    }
    
}
