using WEB.Models;
using WEB.ViewModels;

namespace WEB.Repositories.Interfaces
{
    public interface IObraRepository
    {
        void NovaObra(Obra obra);
        IEnumerable<Obra> ListaObra();
        Obra ObraPorId(int id);
        void ObraEditar(Obra obra);
        void NovaAvaliacao(Avaliacao avaliacao);
        Avaliacao AvaliacaoId(int id);
        void AvaliacaoEditar(Avaliacao avaliacao);
    }
}
