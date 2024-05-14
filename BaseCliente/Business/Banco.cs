using BaseCliente.Models;
using BaseCliente.Models.Dto;
using BaseCliente.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;

namespace BaseCliente.Business
{
    public class Banco
    {
        public DataTable BuscarTodosComFiltro(string nome)
        {
            BancoRequestDto bancoRequestDto = new BancoRequestDto();
            bancoRequestDto.Nome = nome;
            bancoRequestDto.IdBanco = "";

            string jsonCliente = JsonConvert.SerializeObject(bancoRequestDto);
            HttpContent content = new StringContent(jsonCliente, Encoding.UTF8, "application/json");

            var apiService = new ApiService();
            var httpClient = apiService.GetHttpClient();

            DataTable dtBancos = new DataTable();
            HttpResponseMessage response = httpClient.PostAsync("banco/buscarTodosComFiltro", content).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                dtBancos = response.Content.ReadAsAsync<DataTable>().GetAwaiter().GetResult();
            }
            else
            {
                throw new Exception($"Falha na chamada à API: {response.StatusCode}");
            }
            return dtBancos;
        }

        internal void Alterar(string idBanco, string nome)
        {
            BancoRequestDto bancoRequestDto = new BancoRequestDto();
            bancoRequestDto.Nome = nome;
            bancoRequestDto.IdBanco = "";

            string jsonCliente = JsonConvert.SerializeObject(bancoRequestDto);
            HttpContent content = new StringContent(jsonCliente, Encoding.UTF8, "application/json");

            var apiService = new ApiService();
            var httpClient = apiService.GetHttpClient();

            HttpResponseMessage response = httpClient.PostAsync("banco/alterar", content).GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Falha na chamada à API: {response.StatusCode}");
            }
        }

        internal CwBanco BuscarPorId(int idaBanco)
        {
            var apiService = new ApiService();
            var httpClient = apiService.GetHttpClient();

            CwBanco cwBanco = null;

            var url = string.Format("banco/buscarPorId/{0}", idaBanco);

            HttpResponseMessage response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                cwBanco = response.Content.ReadAsAsync<CwBanco>().GetAwaiter().GetResult();
            }
            else
            {
                throw new Exception($"Falha na chamada à API: {response.StatusCode}");
            }
            return cwBanco;
        }

        internal List<CwBanco> BuscarTodos()
        {
            var apiService = new ApiService();
            var httpClient = apiService.GetHttpClient();

            List<CwBanco> lstBancos = new List<CwBanco>();
            HttpResponseMessage response = httpClient.GetAsync("banco/buscarTodos").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                lstBancos = response.Content.ReadAsAsync<List<CwBanco>>().GetAwaiter().GetResult();
            }
            else
            {
                throw new Exception($"Falha na chamada à API: {response.StatusCode}");
            }
            return lstBancos;
        }

        internal void Excluir(string idBanco)
        {
            var apiService = new ApiService();
            var httpClient = apiService.GetHttpClient();

            var url = string.Format("banco/excluir/{0}", idBanco);

            HttpResponseMessage response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Falha na chamada à API: {response.StatusCode}");
            }
        }

        internal int Inserir(string nome)
        {
            BancoRequestDto bancoRequestDto = new BancoRequestDto();
            bancoRequestDto.Nome = nome;
            bancoRequestDto.IdBanco = "";

            string jsonCliente = JsonConvert.SerializeObject(bancoRequestDto);
            HttpContent content = new StringContent(jsonCliente, Encoding.UTF8, "application/json");

            var apiService = new ApiService();
            var httpClient = apiService.GetHttpClient();

            CwCliente cwCliente = new CwCliente();
            HttpResponseMessage response = httpClient.PostAsync("banco/inserir", content).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                cwCliente = response.Content.ReadAsAsync<CwCliente>().GetAwaiter().GetResult();
            }
            else
            {
                throw new Exception($"Falha na chamada à API: {response.StatusCode}");
            }
            return cwCliente.Id;
        }
    }
}