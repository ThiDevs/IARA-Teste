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
        public async Task<IEnumerable<Cotacao>> GetAsync(int id = 0)
        {
            return (await cotacaoService.GetCotacaos(id)).ToList();
        }

        [HttpPut]
        public async Task<bool> PutAsync(Cotacao cotacao)
        {
            var methods = new Methods();
            if (!(methods.Validar(cotacao)))
                return false;

            methods.BuscarCep(cotacao);

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
