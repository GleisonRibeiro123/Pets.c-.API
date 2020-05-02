using Pets.Core.Query.Amizade.Requests;
using Pets.Core.Query.Contracts.Amizade.Results;
using Pets.Core.Query.Contracts.Pet.Results;
using Pets.Core.Query.Contracts.Usuario.Results;
using Pets.Core.Query.Pet.Requests;
using Pets.Core.Query.Usuario.Handlers;
using Pets.Core.Query.Usuario.Requests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pets.Core.Application.Client.Client
{
    public class PetsCoreClient
    {
        private readonly IHttpClientFactory httpClientFactory;

        public PetsCoreClient(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }
        #region Amizade
        public async Task<List<FindAmizadeResult>> FindAmizadeAsync(FindAmizadeRequest request)
        {
            return await this.httpClientFactory.PostAsync<List<FindAmizadeResult>>("api/amizade/find", request);
        }
        public async Task<List<FindSolicitacaoResult>> FindSolicitacaoAsync(FindSolicitacaoRequest request)
        {
            return await this.httpClientFactory.PostAsync<List<FindSolicitacaoResult>>("api/amizade/findsolicitacao", request);
        }
        public async Task<ResponderSolicitacaoResult> ResponderSolicitacaoAsync(ResponderSolicitacaoRequest request)
        {
            return await this.httpClientFactory.PostAsync<ResponderSolicitacaoResult>("api/amizade/respondersolicitacao", request);
        }
        public async Task<SolicitarAmizadeResult> SolicitarAmizadeAsync(SolicitarAmizadeRequest request)
        {
            return await this.httpClientFactory.PostAsync<SolicitarAmizadeResult>("api/amizade/solicitar", request);
        }
        #endregion
        #region Usuario
        public async Task<List<FindUsuarioResult>> FindUsuarioAsync(FindUsuarioRequest request)
        {
            return await this.httpClientFactory.PostAsync<List<FindUsuarioResult>>("api/usuario/find", request);
        }
        public async Task<GetUsuarioResult> GetUsuarioAsync(GetUsuarioRequest request)
        {
            return await this.httpClientFactory.PostAsync<GetUsuarioResult>("api/usuario/get", request);
        }
        public async Task<AdicionarUsuarioResult> AdicionarUsuarioAsync(AdicionarUsuarioRequest request)
        {
            return await this.httpClientFactory.PostAsync<AdicionarUsuarioResult>("api/usuario/adicionar", request);
        }
        #endregion
        #region Usuario
        public async Task<List<FindPetResult>> FindPetAsync(FindPetRequest request)
        {
            return await this.httpClientFactory.PostAsync<List<FindPetResult>>("api/pet/find", request);
        }
        public async Task<GetPetResult> AdicionarUsuarioAsync(GetPetRequest request)
        {
            return await this.httpClientFactory.PostAsync<GetPetResult>("api/pet/get", request);
        }
        public async Task<AdicionarPetResult> AdicionarPetAsync(AdicionarPetRequest request)
        {
            return await this.httpClientFactory.PostAsync<AdicionarPetResult>("api/pet/adicionar", request);
        }
        public async Task<AdicionarPetImagemResult> AdicionarPetImagemAsync(AdicionarPetImagemRequest request)
        {
            return await this.httpClientFactory.PostAsync<AdicionarPetImagemResult>("api/pet/adicionarimagem", request);
        }
        #endregion
    }
}