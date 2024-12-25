using System.Net;

namespace EMS.Core.ResponseHandler
{
    public class ResponseHandler
    {
        public Response<T> Create<T>(T _data ,object meta = null)
        {
            return new Response<T>()
            {
                Data = _data,
                Succeeded = true,
                Status = HttpStatusCode.Created ,
                Message = "Created"
            };
        }

        public Response<T> Delete<T>(string _message = null)
        {
            return new Response<T>()
            {
                Succeeded = true,
                Status = HttpStatusCode.OK,
                Message = _message is null ? "Deleted" : _message
            };
        }

        public Response<T> Success<T>(T _data,object _meta = null)
        {
            return new Response<T>()
            {
                Succeeded = true,
                Status = HttpStatusCode.OK,
                Data = _data,
                Meta = _meta
            };
        }

        public Response<T> Unauhorized<T>(string _message = null)
        {
            return new Response<T>()
            {
                Succeeded = true,
                Status = HttpStatusCode.Unauthorized,
                Message = _message
            };
        }

        public Response<T> BadRequest<T>(string _message = null)
        {
            return new Response<T>()
            {
                Succeeded = false,
                Status = HttpStatusCode.BadRequest,
                Message = _message is null ? "BadRequest" : _message
            };
        }

        public Response<T> UnprocessableEntity<T>(string _message = null)
        {
            return new Response<T>()
            {
                Succeeded = false,
                Status = HttpStatusCode.UnprocessableEntity,
                Message = _message is null ? "UnprocessableEntity" : _message
            };
        }

        public Response<T> NotFound<T>(string _message = null)
        {
            return new Response<T>()
            {
                Succeeded = false,
                Status = HttpStatusCode.NotFound,
                Message = _message is null ? "NotFound" : _message
            };
        }
    }
}
