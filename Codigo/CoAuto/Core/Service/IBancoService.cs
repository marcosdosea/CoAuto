using Core.DTO;

namespace Core.Service;
    public interface IBancoService
    {
        uint Create(Banco banco);
        void Delete(uint id);
        void Edit(Banco banco);
        Banco Get(uint id);
        IEnumerable<Banco> GetAll();
        IEnumerable<BancoDTO> GetByNome(string nome);

}
