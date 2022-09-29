using ExemploDeActionFilter.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ExemploDeActionFilter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [TypeFilter(typeof(FiltroDeAcessoInterno))] // Este é o filtro que barra tudo que é acesso externo por meio do FiltroDeAcessoInterno
    [ApiExplorerSettings(IgnoreApi = true)] // Este atributo faz a API não aparecer no swagger
    public class SomenteAcessoInternoController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Você está acessando um controller privado por IP!";
        }
    }
}
