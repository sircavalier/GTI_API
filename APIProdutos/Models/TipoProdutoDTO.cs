using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProdutos.Models
{
    public class TipoProdutoDTO : EntityBaseModel
    {
        public string descricao { get; set; }

        public int? idTipoPai { get; set; }
    }
}
