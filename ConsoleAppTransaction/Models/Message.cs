using System;

namespace ConsoleAppTransaction.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string ExchangeCompra { get; set; }
        public string ExchangeVenda { get; set; }
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal QuantidadeCompra { get; set; }
        public decimal QuantidadeVenda { get; set; }
        public decimal QuantidadeCalculadaCompra { get; set; }
        public decimal QuantidadeCalculadaVenda { get; set; }
        public string Symbol { get; set; }
        public string MoedaCompra { get; set; }
        public string MoedaVenda { get; set; }
        public DateTime Data { get; set; }
    }
}
