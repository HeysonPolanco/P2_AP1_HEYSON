using P2_AP1_Heyson.Models;
using Microsoft.EntityFrameworkCore;

namespace P2_AP1_Heyson.DAL;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }
    public DbSet<Registro> Personas { get; set; }
}
