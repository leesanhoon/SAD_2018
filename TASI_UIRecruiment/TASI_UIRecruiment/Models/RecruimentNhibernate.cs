using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TASI_UIRecruiment.Models
{
    public class RecruimentNhibernate
    {
        public int id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
    }
    public class RecruimentNhibernateDBContext : DbContext
    {
        public DbSet<RecruimentNhibernate> RecruimentNhibernate { get; set; }
    }

}