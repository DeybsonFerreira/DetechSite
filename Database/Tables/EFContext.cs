using Microsoft.EntityFrameworkCore;

namespace Database.Tables
{
    public class EFContext: DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
    }
}
