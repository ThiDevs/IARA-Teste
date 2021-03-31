using IARA_Teste;
using Microsoft.Extensions.Caching.Memory;
using Repository.Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CotacaoService : ICotacaoService
    {
        private readonly IMemoryCache memoryCache;
        private readonly ICotacaoRepository repository;

        public CotacaoService(ICotacaoRepository repository, IMemoryCache memoryCache)
        {
            this.repository = repository;
            this.memoryCache = memoryCache;
        }

        //public async Task<CotacaoModel> GetCotacao(Guid CotacaoId)
        //{
        //    return await repository.GetCotacao(CotacaoId);
        //}

        public async Task<IEnumerable<CotacaoModel>> GetCotacaos(Guid CotacaoModelId)
        {
            return await repository.GetCotacaos(CotacaoModelId);
        }

        public async Task<CotacaoModel> InsertCotacao(CotacaoModel Cotacao)
        {
          

            return await repository.InsertCotacao(Cotacao);
        }

        public async Task<CotacaoModel> UpdateCotacao(CotacaoModel Cotacao)
        {
            return await repository.UpdateCotacao(Cotacao);
        }

        public async Task<bool> DeleteCotacao(Guid CotacaoId)
        {
            return await repository.DeleteCotacao(CotacaoId);
        }

        
    }
}
