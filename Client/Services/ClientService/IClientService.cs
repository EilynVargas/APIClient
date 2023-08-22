namespace Client.Services.ClientService
{
    public interface IClientService
    {
        Task<List<Clientes>> GetAllClients();
        Task<Clientes?> GetSingleClient(int Id);
        Task<List<Clientes>> AddClient(Clientes client);
        Task<List<Clientes>?> UpdateClient(int Id, Clientes request);
        Task<List<Clientes>?> DeleteClient(int Id);

    }
}
