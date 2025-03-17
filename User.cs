using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
   public class User
    {
        
      
            public int Id { get; set; }
            public string? UserName { get; set; }
        public string? Email { get; set; }
            public string? Password { get; set; }


        // Establish a relationship with Enrollment table
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();



    }
}
