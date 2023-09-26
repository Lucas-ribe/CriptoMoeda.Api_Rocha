using Application.Context;
using AutoMapper;
using Domain.Adapters;
using Domain.Models;
using Domain.Services;


namespace Application
{
    public class CriptoMoedaService : ICriptoMoedaService
    {
        private readonly IMercadoBitcoinAdapter mercadoBitcoinAdapter;
        private readonly HistoricoContext _context;
        private readonly IMapper _mapper;

        public CriptoMoedaService(IMercadoBitcoinAdapter mercadoBitcoinAdapter, HistoricoContext context, IMapper mapper)
        {
            this.mercadoBitcoinAdapter = mercadoBitcoinAdapter ??
                throw new ArgumentNullException(nameof(mercadoBitcoinAdapter));

            _context = context;
            _mapper = mapper;
        }
        public async Task<NegociacoesDoDia> ObterDadosNegociacoesDoDiaAsync(string siglaMoeda)
        {
            if (string.IsNullOrWhiteSpace(siglaMoeda))
            {
                throw new Exception("Sigla escolhida não é valida.");
            }

            return await mercadoBitcoinAdapter.ObterDadosNegociacoesDoDiaAsync(siglaMoeda);
        }
        public async Task<HistoricoDeNegociacoes> SalvarHistorico(string siglaMoeda)
        {
            var dados = await ObterDadosNegociacoesDoDiaAsync(siglaMoeda);

            var historico = _mapper.Map<HistoricoDeNegociacoes>(dados);

            historico.Sigla = siglaMoeda.ToUpper();

            _context.Add(historico);
            _context.SaveChanges();

            var registro = _context.RegistroDeNegociacoes.Where(x => x.Sigla == siglaMoeda.ToUpper()).SingleOrDefault();

            if (registro == null)
            {
                registro = _mapper.Map<RegistroDeNegociacoes>(dados);

                registro.Sigla = siglaMoeda.ToUpper();

                _context.RegistroDeNegociacoes.Add(registro);
            }
            else
            {
                _context.RegistroDeNegociacoes.Entry(registro).Property(x => x.Sigla).CurrentValue = siglaMoeda.ToUpper();
                _context.RegistroDeNegociacoes.Entry(registro).Property(x => x.MaiorPreco).CurrentValue = dados.MaiorPreco;
                _context.RegistroDeNegociacoes.Entry(registro).Property(x => x.MenorPreco).CurrentValue = dados.MenorPreco;
                _context.RegistroDeNegociacoes.Entry(registro).Property(x => x.QuantidadeNegociada).CurrentValue = dados.QuantidadeNegociada;
                _context.RegistroDeNegociacoes.Entry(registro).Property(x => x.PrecoUnitario).CurrentValue = dados.PrecoUnitario;
                _context.RegistroDeNegociacoes.Entry(registro).Property(x => x.MaiorPrecoOfertado).CurrentValue = dados.MaiorPrecoOfertado;
                _context.RegistroDeNegociacoes.Entry(registro).Property(x => x.MenorPrecoOfertado).CurrentValue = dados.MenorPrecoOfertado;
                _context.RegistroDeNegociacoes.Entry(registro).Property(x => x.DataHora).CurrentValue = dados.DataHora;
               
            }
            _context.SaveChanges();

            return historico;
        }

        public async Task<IEnumerable<HistoricoDeNegociacoes>> Historico(string siglaMoeda)
        {
            return _context.HistoricoDeNegociacoes.Where(x => x.Sigla == siglaMoeda.ToUpper()).ToList();
        }
        
        public async Task<RegistroDeNegociacoes> Registro(string siglaMoeda)
        {
            return _context.RegistroDeNegociacoes.Where(x => x.Sigla == siglaMoeda.ToUpper()).SingleOrDefault();
        }
    }
}