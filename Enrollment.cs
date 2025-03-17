using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Enrollment
    {
        public int Id { get; set; }  // Auto-increment ID
        public int UserId { get; set; }  // Foreign key linking to User
        public string? CourseName { get; set; }  // Course Name
       

        public User? User { get; set; }  // Navigation property
    }
}