using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcLoginRegistration.Models
{
    public class AccountDbContext:DbContext
    {
        public DbSet<CUserAccount> userAccounts { get; set; }
    }
}