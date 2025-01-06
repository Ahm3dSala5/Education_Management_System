using System.Net;
using EMS.Core.Response;

namespace EMS.Core.Response
{
    public class ResultHandler
    {
        public Result<T> Create<T>(T _data ,object meta = null)
        {
            return new Result<T>()
            {
                Data = _data,
                Succeeded = true,
                StatusCode = HttpStatusCode.Created ,
                Message = "Created"
            };
        }

        public Result<T> Delete<T>(string _message = null)
        {
            return new Result<T>()
            {
                Succeeded = true,
                StatusCode = HttpStatusCode.OK,
                Message = _message is null ? "Deleted" : _message
            };
        }

        public Result<T> Success<T>(T _data, object _meta = null,ICollection<T> listData = null)
        {
            return new Result<T>()
            {
                Succeeded = true,
                StatusCode = HttpStatusCode.OK,
                Data = _data,
                Meta = _meta
            };
        }

        public Result<T> Unauhorized<T>(string _message = null)
        {
            return new Result<T>()
            {
                Succeeded = true,
                StatusCode = HttpStatusCode.Unauthorized,
                Message = _message
            };
        }

        public Result<T> BadRequest<T>(string _message = null)
        {
            return new Result<T>()
            {
                Succeeded = false,
                StatusCode = HttpStatusCode.BadRequest,
                Message = _message is null ? "BadRequest" : _message
            };
        }

        public Result<T> UnprocessableEntity<T>(string _message = null)
        {
            return new Result<T>()
            {
                Succeeded = false,
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Message = _message is null ? "UnprocessableEntity" : _message
            };
        }

        public Result<T> NotFound<T>(string _message = null)
        {
            return new Result<T>()
            {
                Succeeded = false,
                StatusCode = HttpStatusCode.NotFound,
                Message = _message is null ? "NotFound" : _message
            };
        }
    }
}
