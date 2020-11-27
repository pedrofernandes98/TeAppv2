using System;
using System.Collections.Generic;

namespace TeApp.Models
{
    public class ResultApiModel<T> : BaseResultApiModel
    {
        public T Content { get; set; }

        public ResultApiModel(List<ErrorModel> error) : base(error)
        {
        }

        public ResultApiModel(T content) : base()
        {
            this.Content = content;
        }
    }
}
