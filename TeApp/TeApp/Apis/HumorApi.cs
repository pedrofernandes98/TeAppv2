using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TeApp.Excepetions;
using TeApp.Models;
using TeApp.Models.Humor;

namespace TeApp.Apis
{
    public class HumorApi : BaseApi
    {
        public HumorApi(HttpClient httpClient) : base(httpClient, "https://teapp-api-netcore.azurewebsites.net/api/v1/emocoes")
        {
        }

        public async Task<ResultApiModel<List<HumorModel>>> GetHumores()
        {
            try
            {
                var result = await this.GetAsync<List<HumorModel>>(this._baseAddress.AbsoluteUri);
                return new ResultApiModel<List<HumorModel>>(result);
            }
            catch (HttpResponseException e)
            {
                return new ResultApiModel<List<HumorModel>>(e.Errors);
            }
        }
    }
}
