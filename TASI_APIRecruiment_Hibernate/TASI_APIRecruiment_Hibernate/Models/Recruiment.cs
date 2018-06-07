using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TASI_APIRecruiment_Hibernate.Models
{
    public class Recruiment
    {
        public virtual int Id { get; set; }
        public virtual string Fullname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Status { get; set; }

    }
}