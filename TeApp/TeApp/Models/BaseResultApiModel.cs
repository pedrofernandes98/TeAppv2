using System.Collections.Generic;

namespace TeApp.Models
{
    public class BaseResultApiModel
    {
        public bool Success { get; set; }
        public List<ErrorModel> Errors { get; set; }

        public BaseResultApiModel(List<ErrorModel> errors)
        {
            this.Success = false;
            this.Errors = errors;
        }

        public BaseResultApiModel()
        {
            this.Success = true;
            this.Errors = new List<ErrorModel>();
        }
    }
}
