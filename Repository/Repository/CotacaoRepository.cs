using Dapper;
using IARA_Teste;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Reposiroies
{
    public class CotacaoRepository : ICotacaoRepository
    {
        private readonly IConnectionFactory connection;

        public CotacaoRepository(IConnectionFactory connection)
        {
            this.connection = connection;
        }

        //public async Task<IEnumerable<Cotacao>> Getcotacaoes()
        //{
        //    string sql = "select * from [cotacaoDB].[dbo].[cotacao]";
        //    string sqlcotacaoFriend = "select Name from cotacaoFriends where cotacaoId = @cotacaoId";

        //    IList<Cotacao> listcotacao = new List<Cotacao>();

        //    using (var connectionDb = connection.Connection())
        //    {
        //        connectionDb.Open();

        //        var result = await connectionDb.QueryAsync<dynamic>(sql);

        //        if (result.Any())
        //        {
        //            foreach (var item in result.ToList())
        //            {
        //                var cotacao = new Cotacao((int)item.cotacaoId, (string)item.Name, (string)item.Power);
        //                var resultcotacaoFriend = await connectionDb.QueryAsync<dynamic>(sqlcotacaoFriend,
        //                    new
        //                    {
        //                        cotacaoId = cotacao.cotacaoId
        //                    });
        //                if (result.Any())
        //                {
        //                    foreach (var friend in resultcotacaoFriend.ToList())
        //                    {
        //                        cotacao.AddcotacaoFriend((string)friend.Name);
        //                    }
        //                }                    
        //                listcotacao.Add(cotacao);
        //            }
        //        }
        //    }
        //    return listcotacao;
        //}

        //public async Task<Cotacao> Insertcotacao(Cotacao cotacao)
        //{
        //    string sql = "Insert into [cotacaoDB].[dbo].[cotacao] ([cotacaoId],[Name],[Power]) values (@cotacaoId, @Name, @Power)";

        //    using (var connectionDb = connection.Connection())
        //    {
        //        connectionDb.Open();

        //        var cotacaoResult = await connectionDb.ExecuteAsync(sql,
        //            new
        //            {
        //                cotacaoId = cotacao.cotacaoId,
        //                Name = cotacao.Name,
        //                Power = cotacao.Power
        //            });

        //        if (cotacao.cotacaoFriend.Any())
        //        {
        //            string sqlcotacaoFriend = "Insert into [cotacaoDB].[dbo].[cotacaoFriends] ([cotacaoId],[Name]) values (@cotacaoId, @Name)";

        //            foreach (var friend in cotacao.cotacaoFriend)
        //            {
        //                var cotacaoFriendResult = await connectionDb.ExecuteAsync(sqlcotacaoFriend,
        //                new
        //                {
        //                    cotacaoId = cotacao.cotacaoId,
        //                    Name = friend
        //                });
        //            }
        //        }

        //        return cotacao;
        //    }
        //}

        //public async Task<Cotacao> Updatecotacao(Cotacao cotacao)
        //{
        //    string sql = "UPDATE [cotacaoDB].[dbo].[cotacao] SET[Name] = @Name, [Power]= @Power WHERE [cotacaoId] = @cotacaoId;";

        //    using (var connectionDb = connection.Connection())
        //    {
        //        connectionDb.Open();

        //        //var cotacaoResult = await connectionDb.ExecuteAsync(sql,
        //        //    new
        //        //    {
        //        //        cotacaoId = cotacao.cotacaoId,
        //        //        Name = cotacao.Name,
        //        //        Power = cotacao.Power
        //        //    });

        //        //return cotacao;

        //    }
        //}

        //public async Task<Cotacao> Getcotacao(int cotacaoId)
        //{
        //    string sql = "select * from [cotacaoDB].[dbo].[cotacao] where [cotacaoId] = @cotacaoId";
        //    string sqlcotacaoFriend = "select Name from cotacaoFriends where cotacaoId = @cotacaoId";

        //    IList<Cotacao> listcotacao = new List<Cotacao>();

        //    using (var connectionDb = connection.Connection())
        //    {
        //        connectionDb.Open();

        //        var result = await connectionDb.QueryFirstOrDefaultAsync<Cotacao>(sql,
        //            new
        //            {
        //                cotacaoId = cotacaoId
        //            });

        //        if (result != null)
        //        {
        //            var resultcotacaoFriend = await connectionDb.QueryAsync<dynamic>(sqlcotacaoFriend,
        //                   new
        //                   {
        //                       cotacaoId = result.cotacaoId
        //                   });

        //            foreach (var friend in resultcotacaoFriend.ToList())
        //            {
        //                result.AddcotacaoFriend((string)friend.Name);
        //            }
        //        }

        //        return result;
        //    }
        //}

        //public async Task<bool> Deletcotacao(int cotacaoId)
        //{
        //    string sql = "Delete [cotacaoDB].[dbo].[cotacao] where [cotacaoId] = @cotacaoId";
        //    string sqlFriendcotacao = "Delete [cotacaoDB].[dbo].[cotacaoFriends] where [cotacaoId] = @cotacaoId";

        //    using (var connectionDb = connection.Connection())
        //    {
        //        connectionDb.Open();

        //        await connectionDb.QueryAsync<cotacao>(sqlFriendcotacao,
        //            new
        //            {
        //                cotacaoId = cotacaoId
        //            });

        //        await connectionDb.QueryAsync<cotacao>(sql,
        //            new
        //            {
        //                cotacaoId = cotacaoId
        //            });

        //        return true;
        //    }
        //}

        public async Task<IEnumerable<Cotacao>> GetCotacaos(int cotacaoId)
        {

            string sqlcotacao = $"Select * From Cotacao {(cotacaoId > 0 ? $"Where IdCotacao = {cotacaoId}" : "")}";

            IList<Cotacao> listcotacao = new List<Cotacao>();
            using (var connectionDb = connection.Connection())
            {
                connectionDb.Open();

                var result = await connectionDb.QueryAsync<Cotacao>(sqlcotacao);

                if (result.Any())
                {
                    foreach (var cotacao in result.ToList())
                    {
                        string sqlcotacaoItem = $"Select * From CotacaoItem {(cotacao.IdCotacao > 0 ? $"Where IdCotacao = {cotacao.IdCotacao}" : "")}";
                        cotacao.cotacaoItens = new List<CotacaoItem>();

                        var resultcotacaoItem = await connectionDb.QueryAsync<CotacaoItem>(sqlcotacaoItem);

                        if (result.Any())
                        {
                            foreach (var cotacaoItem in resultcotacaoItem.ToList())
                            {
                                cotacao.cotacaoItens.Add(cotacaoItem);
                            }
                        }
                        listcotacao.Add(cotacao);
                    }
                }
            }
            return listcotacao;
        }

        public async Task<Cotacao> InsertCotacao(Cotacao cotacao)
        {

            string sql = "Insert into cotacao values (@CNPJComprador, @CNPJFornecedor, @NumeroCotacao, @DataCotacao, @DataEntregaCotacao, @CEP, @Logradouro, @Complemento, @Bairro, @UF, @Observacao) SELECT @@IDENTITY as Id";

            using (var connectionDb = connection.Connection())
            {
                connectionDb.Open();

                var cotacaoResult = await connectionDb.ExecuteReaderAsync(sql,
                    new
                    {
                        CNPJComprador = cotacao.CNPJComprador,
                        CNPJFornecedor = cotacao.CNPJFornecedor,
                        NumeroCotacao = cotacao.NumeroCotacao,
                        DataCotacao = cotacao.DataCotacao,
                        DataEntregaCotacao = cotacao.DataEntregaCotacao,
                        CEP = cotacao.CEP,
                        Logradouro = cotacao.Logradouro,
                        Complemento = cotacao.Complemento,
                        Bairro = cotacao.Bairro,
                        UF = cotacao.UF,
                        Observacao = cotacao.Observacao
                    });

                int idCotacao = 0;
                while (cotacaoResult.Read())
                {
                    idCotacao = Convert.ToInt32(cotacaoResult.GetValue(0));
                    cotacao.IdCotacao = idCotacao;
                }
                connectionDb.Close();

                foreach (var cotacaoItem in cotacao.cotacaoItens)
                {
                    sql = "Insert into cotacaoItem values (@IdCotacao, @Descricao, @NumeroItem, @Preco, @Quantidade, @Marca, @Unidade)";
                    connectionDb.Open();
                    connectionDb.ExecuteReader(sql,
                   new
                   {
                       IdCotacao = cotacao.IdCotacao,
                       Descricao = cotacaoItem.Descricao,
                       NumeroItem = cotacaoItem.NumeroItem,
                       Preco = cotacaoItem.Preco,
                       Quantidade = cotacaoItem.Quantidade,
                       Marca = cotacaoItem.Marca,
                       Unidade = cotacaoItem.Unidade,
                   });
                    connectionDb.Close();

                }

                return cotacao;
            }
        }

        public async Task<Cotacao> UpdateCotacao(Cotacao cotacao)
        {

            string sql = "Update cotacao set CNPJComprador = @CNPJComprador, CNPJFornecedor = @CNPJFornecedor, NumeroCotacao = @NumeroCotacao, DataCotacao = @DataCotacao, " +
                "DataEntregaCotacao = @DataEntregaCotacao, CEP = @CEP, Logradouro = @Logradouro, Complemento = @Complemento, Bairro = @Bairro, UF = @UF, Observacao = @Observacao Where" +
                $"IdCotacao = {cotacao.IdCotacao}";

            using (var connectionDb = connection.Connection())
            {
                connectionDb.Open();

                var cotacaoResult = await connectionDb.ExecuteReaderAsync(sql,
                    new
                    {
                        CNPJComprador = cotacao.CNPJComprador,
                        CNPJFornecedor = cotacao.CNPJFornecedor,
                        NumeroCotacao = cotacao.NumeroCotacao,
                        DataCotacao = cotacao.DataCotacao,
                        DataEntregaCotacao = cotacao.DataEntregaCotacao,
                        CEP = cotacao.CEP,
                        Logradouro = cotacao.Logradouro,
                        Complemento = cotacao.Complemento,
                        Bairro = cotacao.Bairro,
                        UF = cotacao.UF,
                        Observacao = cotacao.Observacao
                    });

                connectionDb.Close();

                return cotacao;
            }
        }

        public async Task<bool> DeleteCotacao(int cotacaoId)
        {
            string sql = "Delete Cotacao Where" +
               $" IdCotacao = {cotacaoId}";

            using (var connectionDb = connection.Connection())
            {
                connectionDb.Open();

                var cotacaoResult = await connectionDb.ExecuteAsync(sql);

                connectionDb.Close();

                return cotacaoResult == 1;
            }

        }

    }
}
