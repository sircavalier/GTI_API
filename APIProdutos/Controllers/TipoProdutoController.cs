﻿using APIProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProdutos.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class TipoProdutoController : ControllerBase
    {
        private static List<TipoProdutoDTO> lstProdutos = new List<TipoProdutoDTO>();

        [HttpPost]
        [Route("")]
        public ActionResult inserirProduto([FromBody] TipoProdutoDTO tipoProdutoModel)
        {
            lstProdutos.Add(new TipoProdutoDTO()
            {
                ID = tipoProdutoModel.ID,
                descricao = tipoProdutoModel.descricao,
                idTipoPai = tipoProdutoModel.idTipoPai
            });

            return Created(@"http://localhost:62613/api/tipoproduto/" + tipoProdutoModel.ID.ToString().Trim(), tipoProdutoModel.ID);
        }

        [HttpGet]
        [Route("")]
        public ActionResult consultarProduto()
        {
            return Ok(lstProdutos);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult consultarProdutoCodigo(int id)
        {
            return Ok(lstProdutos[id - 1]);
        }

        [HttpPut]
        [Route("")]
        public ActionResult AlterarProduto()
        {
            return NoContent();
        }

    }
}
