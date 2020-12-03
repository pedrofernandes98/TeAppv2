using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TeApp.Excepetions;
using TeApp.Models;
using TeApp.Models.Autenticacao;

namespace TeApp.Apis
{
    public class AutenticacaoApi : BaseApi
    {
        public AutenticacaoApi(HttpClient httpClient) : base(httpClient, "https://teapp-api-netcore.azurewebsites.net/api/v1/autenticacoes")
        {
        }

        public async Task<ResultApiModel<UserModel>> LoginResponsavel(AutenticacaoModel autenticacao)
        {
            try
            {
                var resultado = await this.PostAsync<UserModel>(this._baseAddress.AbsoluteUri, autenticacao);
                return new ResultApiModel<UserModel>(resultado);
            }
            catch (HttpResponseException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    return new ResultApiModel<UserModel>(e.Errors);

                return new ResultApiModel<UserModel>(new List<ErrorModel>());
            }
        }
    }
}
