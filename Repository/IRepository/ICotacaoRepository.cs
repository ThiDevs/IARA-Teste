using IARA_Teste;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface ICotacaoRepository
    {
        Task<IEnumerable<CotacaoModel>> GetCotacaos(Guid cotacaoId);
        Task<CotacaoModel> InsertCotacao(CotacaoModel cotacao);
        Task<CotacaoModel> UpdateCotacao(CotacaoModel cotacao);
        Task<bool> DeleteCotacao(Guid heroId);
        //Task<CotacaoModel> GetCotacao(Guid heroId);
    }
}
