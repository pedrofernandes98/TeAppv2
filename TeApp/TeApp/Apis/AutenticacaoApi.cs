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

        public async Task<BaseResultApiModel> LoginResponsavel(AutenticacaoModel autenticacao)
        {
            try
            {
                await this.PostAsync<object>(this._baseAddress.AbsoluteUri, autenticacao);
                return new BaseResultApiModel();
            }
            catch (HttpResponseException e)
            {
                return new BaseResultApiModel(e.Errors);
            }
        }
    }
}
