using Microsoft.EntityFrameworkCore;
using MOTTHRU.API.Domain.Entities;

namespace MOTTHRU.API.Infrastructure.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<UsuarioEntity> usuario { get; set; }
    }
}