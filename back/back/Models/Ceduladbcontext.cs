using back.Models;
using Microsoft.EntityFrameworkCore;

namespace back.Models
{
    public class CeduladbContext : DbContext
    {
        public CeduladbContext(DbContextOptions<CeduladbContext> options)
            : base(options)
        {
        }

        public DbSet<Cedula> Cedulas { get; set; }

       
    }
}