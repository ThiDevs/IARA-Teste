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
        private readonly ICotacaoRepository repository;

        public CotacaoService(ICotacaoRepository repository)
        {
            this.repository = repository;
        }

        //public async Task<Cotacao> GetCotacao(int CotacaoId)
        //{
        //    return await repository.GetCotacao(CotacaoId);
        //}

        public async Task<IEnumerable<Cotacao>> GetCotacaos(int CotacaoId)
        {
            return await repository.GetCotacaos(CotacaoId);
        }

        public async Task<Cotacao> InsertCotacao(Cotacao Cotacao)
        {
            return await repository.InsertCotacao(Cotacao);
        }

        public async Task<Cotacao> UpdateCotacao(Cotacao Cotacao)
        {
            return await repository.UpdateCotacao(Cotacao);
        }
        public async Task<bool> DeleteCotacao(int CotacaoId)
        {
            return await repository.DeleteCotacao(CotacaoId);
        }


    }
}
