using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RegistrationPage.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("MyDbConnection")
        {

        }

       public DbSet<Registration> Registrations { get; set; }   
    }
}