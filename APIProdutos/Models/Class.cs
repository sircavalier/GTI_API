using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProdutos.Models
{
    public class ClienteModel : EntityBaseModel
    {
        public string Nome { get; set; }
        public string CPF_CNPJ { get; set; }
        public string TipoCliente { get; set; }
    }
}
