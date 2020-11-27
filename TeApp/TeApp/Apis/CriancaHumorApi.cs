using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TeApp.Excepetions;
using TeApp.Models;
using TeApp.Models.CriancaHumor;

namespace TeApp.Apis
{
    public class CriancaHumorApi : BaseApi
    {
        public CriancaHumorApi(HttpClient httpClient) : base(httpClient, "https://teapp-api-netcore.azurewebsites.net/api/v1/humor-criancas")
        {
        }

        public async Task<ResultApiModel<List<CriancaHumorModel>>> GetHumores(int idCrianca)
        {
            try
            {
                var result = await this.GetAsync<List<CriancaHumorModel>>(this._baseAddress.AbsoluteUri + $"?idCrianca={idCrianca}");
                return new ResultApiModel<List<CriancaHumorModel>>(result);
            }
            catch (HttpResponseException e)
            {
                return new ResultApiModel<List<CriancaHumorModel>>(e.Errors);
            }
        }

        public async Task<BaseResultApiModel> InsertCriancaHumor(CriancaHumorInsertModel criancaHumor)
        {
            try
            {
                var result = await this.PostAsync<object>(this._baseAddress.AbsoluteUri, criancaHumor);
                return new BaseResultApiModel();
            }
            catch (HttpResponseException e)
            {
                return new BaseResultApiModel(e.Errors);
            }
        }

        public async Task<BaseResultApiModel> UpdateCriancaHumorComentario(CriancaHumorUpdateObservacaoModel criancaHumor)
        {
            try
            {
                var result = await this.PutAsync<object>(this._baseAddress.AbsoluteUri, criancaHumor);
                return new BaseResultApiModel();
            }
            catch (HttpResponseException e)
            {
                return new BaseResultApiModel(e.Errors);
            }
        }
    }
}
