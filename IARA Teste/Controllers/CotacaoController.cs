using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IARA_Teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CotacaoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CotacaoController> _logger;

        private readonly ICotacaoService cotacaoService;
        private readonly IMapper mapper;


        public CotacaoController(ICotacaoService cotacaoService, IMapper mapper,ILogger<CotacaoController> logger)
        {
            this.cotacaoService = cotacaoService;
            this.mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<CotacaoModel>> GetAsync(string id = "0")
        {

            await cotacaoService.GetCotacaos(Guid.Parse(id));


            return Enumerable.Range(1, 5).Select(index => new CotacaoModel
            {
                NumeroCotacao = 0
            })
          .ToArray();


        }
    }
}
