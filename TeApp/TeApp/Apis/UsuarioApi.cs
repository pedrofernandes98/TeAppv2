using System.Net.Http;
using System.Threading.Tasks;
using TeApp.Excepetions;
using TeApp.Models;
using TeApp.Models.Usuario;

namespace TeApp.Apis
{
    public class UsuarioApi : BaseApi
    {
        public UsuarioApi(HttpClient httpClient) : base(httpClient, "https://teapp-api-netcore.azurewebsites.net/api/v1/usuarios")
        {
        }

        public async Task<ResultApiModel<UserModel>> InsertUsuario(UsuarioInsertModel usuario)
        {
            try
            {
                var result = await this.PostAsync<UserModel>(this._baseAddress.AbsoluteUri, usuario);
                return new ResultApiModel<UserModel>(result);
            }
            catch (HttpResponseException e)
            {
                return new ResultApiModel<UserModel>(e.Errors);
            }
        }

        public async Task<ResultApiModel<UserModel>> UpdateUsuario(UsuarioInsertModel usuario)
        {
            try
            {
                var result = await this.PutAsync<UserModel>(this._baseAddress.AbsoluteUri, usuario);
                return new ResultApiModel<UserModel>(result);
            }
            catch (HttpResponseException e)
            {
                return new ResultApiModel<UserModel>(e.Errors);
            }
        }
    }
}
