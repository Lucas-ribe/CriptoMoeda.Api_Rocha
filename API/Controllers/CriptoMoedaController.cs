using Application.Context;
using AutoMapper;
using criptomoeda.api.Dtos;
using Domain.Models;
using Domain.Services;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CriptoMoeda.Api.Controllers
{
    [Route("[controller]")]
    public class CriptoMoedaController : ControllerBase
    {
        private readonly HistoricoContext _context;
        private readonly ICriptoMoedaService criptoMoedaService;
        private readonly IMapper mapper;

        public CriptoMoedaController(ICriptoMoedaService criptoMoedaService, IMapper mapper, HistoricoContext context)
        {
            this.criptoMoedaService = criptoMoedaService ??
                throw new ArgumentNullException(nameof(criptoMoedaService));

            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            _context = context;
        }

        /// <summary>
        ///     Dados das últimas 24 horas de negociações de uma criptomoeda especifica.
        /// </summary>
        /// <param name="siglaMoeda">
        ///     Sigla da criptomoeda que deseja obter dados.
        /// </param>
        [ProducesResponseType(typeof(NegociacoesDoDiaGetResult), 200)]
        /// <response code="400"> Dados inválidos</response>
        /// <response code="500">Erro interno.</response>
        [HttpGet("ObterDadosNegociacoesDoDia")]
        public async Task<IActionResult> ObterDadosNegociacoesDoDiaAsync(string siglaMoeda)
        {
            var resultado = await criptoMoedaService.
                ObterDadosNegociacoesDoDiaAsync(siglaMoeda);

            return Ok(mapper.Map<NegociacoesDoDiaGetResult>(resultado));
        }

        /// <summary>
        ///     Consulta dados das últimas 24 horas de negociações de uma criptomoeda especifica e armazena o historico de pesquisa.
        /// </summary>
        /// <param name="siglaMoeda">
        ///     Sigla da criptomoeda que deseja obter dados.
        /// </param>
        [ProducesResponseType(typeof(HistoricoDTO), 200)]
        /// <response code="400"> Dados inválidos</response>
        /// <response code="500">Erro interno.</response>
        [HttpPost("SalvarHistorico")]
        public async Task<IActionResult> HistoricoDeConsultas(string siglaMoeda)
        {
            var resultado = await criptoMoedaService.SalvarHistorico(siglaMoeda);
            return Ok(mapper.Map<HistoricoDTO>(resultado));
        }

        /// <summary>
        ///     Historico de pesquisa de uma criptomoedas.
        /// </summary>
        /// <param name="siglaMoeda">
        ///     Sigla da criptomoeda que deseja obter dados.
        /// </param>
        [ProducesResponseType(typeof(IEnumerable<HistoricoDTO>), 200)]
        /// <response code="500">Erro interno.</response>
        [HttpGet("ObterHistorico")]
        public async Task<IActionResult> Historico(string siglaMoeda)
        {
            var resultado = await criptoMoedaService.Historico(siglaMoeda);

            return Ok(mapper.Map<IEnumerable<HistoricoDTO>>(resultado));
        }

        /// <summary>
        ///     Registros de todas as criptomoedas que foram consultadas.
        /// </summary>
        [ProducesResponseType(typeof(IEnumerable<HistoricoDTO>), 200)]
        /// <response code="500">Erro interno.</response>
        [HttpGet("ObterRegistro")]
        public async Task<IActionResult> Registro(string siglaMoeda)
        {
            var resultado = await criptoMoedaService.Registro(siglaMoeda);

            return Ok(mapper.Map<HistoricoDTO>(resultado));
        }

    }
}
