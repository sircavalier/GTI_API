using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIProdutos.Models;
using GITDAO;
using GITDAO.Entity.Cliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProdutos.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("document/{cpfcnpj}")]
        public ActionResult GetClienteByCPFCNPJ(string cpfcnpj)
        {
            List<TipoEnderecoDTO> objRetorno = new List<TipoEnderecoDTO>();
            DAOTipoEndereco daoTipoEndereco = new DAOTipoEndereco();
            List<TipoEnderecoModel> lstTipoEndereco = daoTipoEndereco.GetRecord();

            foreach (TipoEnderecoModel item in lstTipoEndereco)
                objRetorno.Add(new TipoEnderecoDTO()
                {
                    ID = item.ID,
                    Descricao = item.Descricao
                });

            return Ok(lstTipoEndereco);
        }
    }
}
