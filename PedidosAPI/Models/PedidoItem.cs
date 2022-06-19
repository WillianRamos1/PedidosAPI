using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosAPI.Models
{
    public class PedidoItem
    {
        [Key]
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }

        [Required]
        public string NomeProduto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorPedidoItem { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public Pedido Pedido { get; set; }
    }
}
