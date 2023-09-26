using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("RegistroAtualizadoMoedas")]
    public class RegistroDeNegociacoes
    {
        public RegistroDeNegociacoes()
        {
        }
        public RegistroDeNegociacoes(
            string sigla,
            decimal maiorPreco,
            decimal menorPreco,
            decimal quantidadeNegociada,
            decimal precoUnitario,
            decimal maiorPrecoOfertado,
            decimal menorPrecoOfertado,
            DateTime dataHora
            )
        {
            Sigla = sigla;
            MaiorPreco = maiorPreco;
            MenorPreco = menorPreco;
            QuantidadeNegociada = quantidadeNegociada;
            PrecoUnitario = precoUnitario;
            MaiorPrecoOfertado = maiorPrecoOfertado;
            MenorPrecoOfertado = menorPrecoOfertado;
            DataHora = dataHora;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Sigla { get; set; }
        public decimal MaiorPreco { get; set; }
        public decimal MenorPreco { get; set; }
        public decimal QuantidadeNegociada { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal MaiorPrecoOfertado { get; set; }
        public decimal MenorPrecoOfertado { get; set; }
        public DateTime DataHora { get; set; }
    }
}
