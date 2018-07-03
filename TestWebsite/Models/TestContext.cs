using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace TestWebsite.Models
{
    public class TestContext : DbContext
    {
        public DbSet<ServiceModel> Services { get; set; }
    }
}