using System;
using System.Collections.Generic;
using System.Text;

namespace paneleo.Share.ModelsDto
{
    public class Response<T> where T : class 
    {
        public T DtoObject { get; set; }

        public bool ErrorOccurred => Errors.Count > 0;

        public List<string> Errors { get; set; }

        public Response()
        {
            Errors= new List<string>();
        }

    }
}
