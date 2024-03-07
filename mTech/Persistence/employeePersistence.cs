using Microsoft.EntityFrameworkCore;
using mTech.Models;

namespace mTech.Persistence

{
    public class EmployeePersistence : DbContext 
    { 
    
        public EmployeePersistence(DbContextOptions<EmployeePersistence> options) : base(options) { }
        
        public DbSet<Employee> Employee { get; set; }
    
    }

  
}
