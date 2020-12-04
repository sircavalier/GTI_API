using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIProdutos.Models;
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
            return Ok(new ClienteModel() { CPF_CNPJ = "12345678901", Nome = "Lorem Ypsum" });
        }
    }
}
