using Client.Services.ClientService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        public IClientService _ClientService { get; }

        public ClientesController(IClientService clientService)
        {
            _ClientService = clientService;
        }
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

        [HttpGet]
        public async Task<ActionResult<List<Clientes>>> GetAllClients()
        {
            return await _ClientService.GetAllClients();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Clientes>> GetSingleClient(int Id)
        {
            //var client = clients.Find(x => x.Id == Id);
            //if (client == null)
            //{
            //    return NotFound("Sorry, this client doesn't exist");
            //}
            //return Ok(client);

            var result = await _ClientService.GetSingleClient(Id);
            if (result == null)
            {
                return NotFound("Client not found");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Clientes>>> AddClient(Clientes client)
        {
            //clients.Add(client);

            //return Ok(clients);

            var result = await _ClientService.AddClient(client);
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<List<Clientes>>> UpdateClient(int Id, Clientes request)
        {
            //var client = clients.Find(x => x.Id == Id);
            //if (client == null)
            //{
            //    return NotFound("Sorry, this client doesn't exist");
            //}

            //client.Nombre = request.Nombre;
            //client.Apellido = request.Apellido;
            //client.Descripcion = request.Descripcion;
            //client.Estatus = request.Estatus;
            //return Ok(clients);

            var result = await _ClientService.UpdateClient(Id, request);
            if(result == null)
            {
                return NotFound("Client not found");
            }

            return Ok(result);
           
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Clientes>>> DeleteClient(int Id)
        {
            //var client = clients.Find(x => x.Id == Id);
            //if (client == null)
            //{
            //    return NotFound("Sorry, this client doesn't exist");
            //}
            //clients.Remove(client);

            var result = await _ClientService.DeleteClient(Id);
            if (result == null)
            {
                return NotFound("Client not found");
            }
            return Ok(result);
        }
    }
}
