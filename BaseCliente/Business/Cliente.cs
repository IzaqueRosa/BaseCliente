using BaseCliente.Models;
using BaseCliente.Models.Dto;
using BaseCliente.Services;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http;
using System.Text;

namespace BaseCliente.Business
{
    public class Cliente
    {
        public DataTable BuscarTodos(string nome, string idBanco)
        {
            ClienteRequestDto clienteRequestDto = new ClienteRequestDto();
            clienteRequestDto.Nome = nome;
            clienteRequestDto.IdBanco = idBanco;
            clienteRequestDto.Cpf = "";
            clienteRequestDto.IdCliente = "";
            
            string jsonCliente = JsonConvert.SerializeObject(clienteRequestDto);
            HttpContent content = new StringContent(jsonCliente, Encoding.UTF8, "application/json");

            var apiService = new ApiService();
            var httpClient = apiService.GetHttpClient();

            DataTable dtClientes = new DataTable();
            HttpResponseMessage response = httpClient.PostAsync("cliente/buscarTodos", content).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                dtClientes = response.Content.ReadAsAsync<DataTable>().GetAwaiter().GetResult();
            }
            else
            {
                throw new Exception($"Falha na chamada à API: {response.StatusCode}");
            }
            return dtClientes;
        }

        internal CwCliente BuscarPorId(int idCliente)
        {
            var apiService = new ApiService();
            var httpClient = apiService.GetHttpClient();

            CwCliente cwCliente = null;

            var url = string.Format("cliente/buscarPorId/{0}", idCliente);

            HttpResponseMessage response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                cwCliente = response.Content.ReadAsAsync<CwCliente>().GetAwaiter().GetResult();
            }
            else
            {
                throw new Exception($"Falha na chamada à API: {response.StatusCode}");
            }
            return cwCliente;
        }

        internal int Inserir(string nome, string cpf, string idBanco)
        {
            ClienteRequestDto clienteRequestDto = new ClienteRequestDto();
            clienteRequestDto.Nome = nome;
            clienteRequestDto.IdBanco = idBanco;
            clienteRequestDto.Cpf = cpf;
            clienteRequestDto.IdCliente = "";

            string jsonCliente = JsonConvert.SerializeObject(clienteRequestDto);
            HttpContent content = new StringContent(jsonCliente, Encoding.UTF8, "application/json");

            var apiService = new ApiService();
            var httpClient = apiService.GetHttpClient();

            CwCliente cwCliente = new CwCliente();
            HttpResponseMessage response = httpClient.PostAsync("cliente/inserir", content).GetAwaiter().GetResult();
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

        internal void Alterar(string idCliente, string nome, string cpf, string idBanco)
        {
            ClienteRequestDto clienteRequestDto = new ClienteRequestDto();
            clienteRequestDto.Nome = nome;
            clienteRequestDto.IdBanco = idBanco;
            clienteRequestDto.Cpf = cpf;
            clienteRequestDto.IdCliente = idCliente;

            string jsonCliente = JsonConvert.SerializeObject(clienteRequestDto);
            HttpContent content = new StringContent(jsonCliente, Encoding.UTF8, "application/json");

            var apiService = new ApiService();
            var httpClient = apiService.GetHttpClient();

            HttpResponseMessage response = httpClient.PostAsync("cliente/alterar", content).GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Falha na chamada à API: {response.StatusCode}");
            }
        }

        internal void Excluir(string idCliente)
        {
            var apiService = new ApiService();
            var httpClient = apiService.GetHttpClient();

            var url = string.Format("cliente/excluir/{0}", idCliente);

            HttpResponseMessage response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Falha na chamada à API: {response.StatusCode}");
            }
        }
    }
}