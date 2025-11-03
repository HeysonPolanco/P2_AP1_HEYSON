using Microsoft.EntityFrameworkCore;
using P2_AP1_Heyson.DAL;
using P2_AP1_Heyson.Models;
using System.Linq.Expressions;

namespace P2_AP1_Heyson.Services;

public class RegistroServices
{
    public class RegistroService(IDbContextFactory<Context> DbFactory)
    {
        public async Task<bool> Guardar(Registro registro)
        {
            if (!await Existe(registro.RegistroId))
            {
                return await Insertar(registro);
            }
            else
            {
                return await Modificar(registro);
            }
        }
        private async Task<bool> Existe(int registroId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Registros
                .AnyAsync(P => P.RegistroId == registroId);
        }
        private async Task<bool> Insertar(Registro registro)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Registros.Add(registro);
            return await context.SaveChangesAsync() > 0;        
        }

        private async Task<bool> Modificar(Registro registro)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Update(registro);
            return await context
                .SaveChangesAsync() > 0;
        }
        public async Task<List<Registro>> Listar(Expression<Func<Registro, bool>>? criterio = null)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Registros
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}