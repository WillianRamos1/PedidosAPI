using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosAPI.Models
{
    public class Pagamento
    {
        [NotMapped]
        [Required]
        public string NomeCartao { get; set; }

        [NotMapped]
        [Required]
        [CreditCard(ErrorMessage = "Verifique os dados do Cartão de Crédito")]
        public string NumeroCartao { get; set; }

        [NotMapped]
        [Required]
        public int CVV { get; set; }

        [NotMapped]
        [Required]
        [RegularExpression(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})", ErrorMessage = "O CPF precisa estar no formato Correto")]
        public long CPF { get; set; }

        [NotMapped]
        [Required]
        public DateTime DataVencimento { get; set; }

        public Pedido Pedido { get; set; }
    }
}
