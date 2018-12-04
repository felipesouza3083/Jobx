using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Jobx.Servicos.Upload
{
    public class CustomMultipartFormDataStreamProvider: MultipartFormDataStreamProvider
    {
        private string _extensao;

        public CustomMultipartFormDataStreamProvider
            (string path, string extensao) 
            : base(path)
        {
            _extensao = extensao;
        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            return Guid.NewGuid().ToString() + _extensao;
        }
    }
}