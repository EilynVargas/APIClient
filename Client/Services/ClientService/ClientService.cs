using Client.Data;
using Client.Model;
using Microsoft.EntityFrameworkCore;

namespace Client.Services.ClientService
{
    public class ClientService : IClientService
    {
        //private static List<Clientes> clients = new List<Clientes>
        //    {
        //        new Clientes {
        //            Id = 1,
        //            Nombre="Eilyn",
        //            Apellido="Vargas",
        //            Descripcion="Product x",
        //            FechaCreacion = DateTime.Now,
        //            Estatus = true
        //        },
        //        new Clientes {
        //            Id = 2,
        //            Nombre="Jhon",
        //            Apellido="Medina",
        //            Descripcion="Product y",
        //            FechaCreacion = DateTime.Now,
        //            Estatus = false
        //        }
        //    };
        private readonly AppDbContext _context;

        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Clientes>> AddClient(Clientes client)
        {
            _context._Clientes.Add(client);
            await _context.SaveChangesAsync();
            return await _context._Clientes.ToListAsync();
        }

        public async Task<List<Clientes>?> DeleteClient(int Id)
        {
            var client = await _context._Clientes.FindAsync(Id);
            if (client == null)
            {
                return null;
            }
            _context._Clientes.Remove(client);
            await _context.SaveChangesAsync();
            return await _context._Clientes.ToListAsync();
        }

        public async Task<List<Clientes>> GetAllClients()
        {
            var clients = await _context._Clientes.ToListAsync();
            return clients;
        }

        public async Task<Clientes?> GetSingleClient(int Id)
        {
            var client = await _context._Clientes.FindAsync(Id);
            if (client == null)
            {
                return null;
            }
            return client;
        }

        public async Task<List<Clientes>?> UpdateClient(int Id, Clientes request)
        {
            var client = await _context._Clientes.FindAsync(Id);
            if (client == null)
            {
                return null;
            }

            client.Nombre = request.Nombre;
            client.Apellido = request.Apellido;
            client.Descripcion = request.Descripcion;
            client.Estatus = request.Estatus;

            await _context.SaveChangesAsync();
            return await _context._Clientes.ToListAsync();
        }
    }
}
