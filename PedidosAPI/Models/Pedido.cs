using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosAPI.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataPedido { get; set; }

        [Required]
        public int StatusPedido { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotalPedido { get; set; }

        [Required]
        public string ClienteNome { get; set; }

        public PedidoItem PedidoItem { get; set; }

        public Pagamento Pagamento { get; set; }
    }
}
