using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = false;
        public object Result { get; set; }
        public string DisPlayMessage { get; set; } = "";

        public List<APIError> Errors { get; set; } = new();
        public List<APIWarning> Warnings { get; set; } = new();

        public void AddError(string errorMesaage)
        {
            APIError error = new APIError(description: errorMesaage);
            Errors.Add(error);

        }

        public void APIWarning(string warningMesaage)
        {
            APIWarning warning = new APIWarning(description: warningMesaage);

            Warnings.Add(warning);

        }



    }
}
