namespace criptomoeda.api.Dtos
{
    public class HistoricoDTO
    {
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
