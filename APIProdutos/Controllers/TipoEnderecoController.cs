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
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEnderecoController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public ActionResult addTipoEndereco(TipoEndereco tipoEndereco)
        {
            DAOTipoEndereco daoTipoEndereco = new DAOTipoEndereco();
            int intChave = daoTipoEndereco.AddRecord(tipoEndereco.descricao);

            if (intChave > 0)
                return Created("", intChave);
            else
                return BadRequest();
        }

        [HttpGet]
        [Route("")]
        public ActionResult getTipoEndereco()
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

            if (lstTipoEndereco?.Count > 0)
                return Ok(lstTipoEndereco);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult getTipoEndereco(int id)
        {
            TipoEnderecoDTO objRetorno = new TipoEnderecoDTO();
            DAOTipoEndereco daoTipoEndereco = new DAOTipoEndereco();
            List<TipoEnderecoModel> lstTipoEndereco = daoTipoEndereco.GetRecord(id);

            if (lstTipoEndereco?.Count > 0)
            {
                objRetorno.ID = lstTipoEndereco[0].ID;
                objRetorno.Descricao = lstTipoEndereco[0].Descricao;

                return Ok(objRetorno);
            }    
            else
                return NotFound();
        }

        public class TipoEndereco
        {
            public string descricao { get; set; }
        }
    }
}
