using IARA_Teste;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface ICotacaoRepository
    {
        Task<IEnumerable<Cotacao>> GetCotacaos(int cotacaoId);
        Task<Cotacao> InsertCotacao(Cotacao cotacao);
        Task<Cotacao> UpdateCotacao(Cotacao cotacao);
        Task<bool> DeleteCotacao(int heroId);
        //Task<Cotacao> GetCotacao(Guid heroId);
    }
}
