using IARA_Teste;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICotacaoService 
    {
        Task<IEnumerable<Cotacao>> GetCotacaos(int CotacaoModelId);
        Task<Cotacao> InsertCotacao(Cotacao CotacaoModel);
        Task<Cotacao> UpdateCotacao(Cotacao CotacaoModel);
        //Task<CotacaoModel> GetCotacao(Guid CotacaoModelId);
        Task<bool> DeleteCotacao(int CotacaoModelId);
    }
}
