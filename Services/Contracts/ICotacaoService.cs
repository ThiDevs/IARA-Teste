using IARA_Teste;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICotacaoService 
    {
        Task<IEnumerable<CotacaoModel>> GetCotacaos(Guid CotacaoModelId);
        Task<CotacaoModel> InsertCotacao(CotacaoModel CotacaoModel);
        Task<CotacaoModel> UpdateCotacao(CotacaoModel CotacaoModel);
        //Task<CotacaoModel> GetCotacao(Guid CotacaoModelId);
        Task<bool> DeleteCotacao(Guid CotacaoModelId);
    }
}
