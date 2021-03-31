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

        private readonly ICotacaoService cotacaoService;
        private readonly IMapper mapper;


        public CotacaoController(ICotacaoService cotacaoService, IMapper mapper)
        {
            this.cotacaoService = cotacaoService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CotacaoModel>> GetAsync(int id = 0)
        {
            await cotacaoService.GetCotacaos(id);
            return Enumerable.Range(1, 5).Select(index => new CotacaoModel
            {
                NumeroCotacao = 0
            })
          .ToArray();
        }

        [HttpPut]
        public async Task<bool> PutAsync(Cotacao cotacao)
        {
            cotacao = await cotacaoService.InsertCotacao(cotacao);
            return cotacao.IdCotacao > 0;
        }

        [HttpPost]
        public async Task<bool> PosttAsync(Cotacao cotacao)
        {
            if (cotacao.IdCotacao < 0)
                cotacao = await cotacaoService.InsertCotacao(cotacao);
            else
                cotacao = await cotacaoService.UpdateCotacao(cotacao);


            return cotacao.IdCotacao > 0;
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(int idCotacao)
        {
            if (idCotacao > 0)
                return await cotacaoService.DeleteCotacao(idCotacao);

            return false;
        }



    }
}
