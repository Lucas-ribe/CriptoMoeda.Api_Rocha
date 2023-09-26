using Domain.Models;

namespace Domain.Services
{
    public interface ICriptoMoedaService
    {
        /// <summary>
        ///     Dados das últimas 24 horas de negociações de uma criptomoeda especifica.
        /// </summary>
        /// <param name="siglaMoeda">Sigla da criptomoeda que deseja obter dados.</param>
        /// <returns>
        ///     Informações com o resumo das últimas 24 horas de negociações.
        /// </returns>
        Task<NegociacoesDoDia> ObterDadosNegociacoesDoDiaAsync(string siglaMoeda);
        Task<HistoricoDeNegociacoes> SalvarHistorico(string siglaMoeda);
        Task<IEnumerable<HistoricoDeNegociacoes>> Historico(string siglaMoeda);
        Task<RegistroDeNegociacoes> Registro(string siglaMoeda);
    }
}
