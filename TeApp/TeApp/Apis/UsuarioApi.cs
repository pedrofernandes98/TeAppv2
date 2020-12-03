using System.Collections.Generic;
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

        public async Task<ResultApiModel<UsuarioModel>> GetUsuario(int idResponsavel, int idCrianca)
        {
            try
            {
                var result = await this.GetAsync<UsuarioModel>(this._baseAddress.AbsoluteUri + $"?idResponsavel={idResponsavel}&idCrianca={idCrianca}");
                return new ResultApiModel<UsuarioModel>(result);
            }
            catch (HttpResponseException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    return new ResultApiModel<UsuarioModel>(e.Errors);

                return new ResultApiModel<UsuarioModel>(new List<ErrorModel>());
            }
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
                if (e.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    return new ResultApiModel<UserModel>(e.Errors);

                return new ResultApiModel<UserModel>(new List<ErrorModel>());
            }
        }

        public async Task<ResultApiModel<UserModel>> UpdateUsuario(UsuarioUpdateModel usuario)
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
