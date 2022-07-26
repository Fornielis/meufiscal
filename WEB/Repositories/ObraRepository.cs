using Microsoft.Extensions.Options;
using WEB.Context;
using WEB.Models;
using WEB.Repositories.Interfaces;

namespace WEB.Repositories
{
    public class ObraRepository: IObraRepository
    {
        private readonly AppDbContext _context;
        private readonly Configuracao _configuracao;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ObraRepository(AppDbContext context, IOptions<Configuracao> configuracao, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _configuracao = configuracao.Value;
            _hostingEnvironment = hostingEnvironment;
        }

        public void AvaliacaoEditar(Avaliacao avaliacao)
        {
            Obra obra = ObraPorId(avaliacao.ObraId);
            obra.Risco = avaliacao.Risco;

            _context.Obras.Update(obra);
            _context.SaveChanges();

            _context.Avaliacoes.Update(avaliacao);
            _context.SaveChanges();
        }

        public Avaliacao AvaliacaoId(int id)
        {
            Avaliacao avaliacao = _context.Avaliacoes.FirstOrDefault(i => i.ObraId == id);
            return avaliacao;
        }

        public IEnumerable<Obra> ListaObra()
        {
            return _context.Obras;
        }

        public void NovaAvaliacao(Avaliacao avaliacao)
        {
            Obra obra = ObraPorId(avaliacao.ObraId);
            obra.Risco = avaliacao.Risco;

            _context.Obras.Update(obra);
            _context.SaveChanges();

            _context.Avaliacoes.Add(avaliacao);
            _context.SaveChanges();
        }

        public void NovaObra(Obra obra)
        {
            obra.Estatus = "CAMPO";
            _context.Add(obra); 
            _context.SaveChanges();
        }

        public void ObraEditar(Obra obra)
        {
            _context.Obras.Update(obra);
            _context.SaveChanges();
        }

        public Obra ObraPorId(int id)
        {
            Obra obra = _context.Obras.FirstOrDefault(o => o.Id == id);
            return obra;
        }
    }
}
