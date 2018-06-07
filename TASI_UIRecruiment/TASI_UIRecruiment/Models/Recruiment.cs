using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TASI_UIRecruiment.Models
{
    public class Recruiment
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }

    }
    public class RecruimentDBContext : DbContext
    {
        public DbSet<Recruiment> Recruiment { get; set; }
    }
}