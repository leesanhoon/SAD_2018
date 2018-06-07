using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TASI_UIHumanResource.Models
{
    public class HumanResource
    {
        public int id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
    }
    public class HumanResourceDBContext : DbContext
    {
        public DbSet<HumanResource> HumanResources { get; set; }
    }
}