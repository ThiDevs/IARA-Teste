using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IARA_Teste
{
    public class Methods
    {

        public Methods() { }


        public bool Validar(Cotacao cotacao) {

            if (string.IsNullOrEmpty(cotacao.CNPJComprador))
                throw new Exception("CNPJComprador não pode ser em branco");
            if (string.IsNullOrEmpty(cotacao.CNPJFornecedor))
                throw new Exception("CNPJFornecedor não pode ser em branco");
            if (cotacao.NumeroCotacao <= 0)
                throw new Exception("NumeroCotacao não pode ser menor que 0");
            if (cotacao.DataCotacao <= DateTime.MinValue)
                throw new Exception("DataCotacao não pode ser em branco");
            if (cotacao.DataEntregaCotacao <= DateTime.MinValue)
                throw new Exception("DataEntregaCotacao não pode ser em branco");
            if (string.IsNullOrEmpty(cotacao.CEP))
                throw new Exception("CEP não pode ser em branco");

            return true;
        }

        public Cotacao BuscarCep(Cotacao cotacao)
        {

            if (string.IsNullOrEmpty(cotacao.Logradouro) && string.IsNullOrEmpty(cotacao.Bairro) && string.IsNullOrEmpty(cotacao.UF)) {

                var url = $"https://viacep.com.br/ws/{cotacao.CEP}/json/";
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);

                var cep = (CepModel) JsonConvert.DeserializeObject(response.Content, typeof(CepModel));

                cotacao.Logradouro = cep.Logradouro;
                cotacao.Bairro = cep.Bairro;
                cotacao.UF = cep.Uf;
            }

            return cotacao;
        }


    }
}
