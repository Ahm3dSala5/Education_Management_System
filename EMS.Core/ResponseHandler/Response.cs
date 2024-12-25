using System.Net;

namespace EMS.Core.ResponseHandler
{
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(T _data, string _message = null)
        {
            this.Succeeded = true;
            this.Data = _data;
            this.Message = _message;
        }

        public Response(string _message)
        {
            this.Succeeded = false;
            this.Message = _message;
        }

        public Response(string _message,bool _succeeded)
        {
            this.Succeeded = _succeeded;
            this.Message = _message;
        }
        
        public HttpStatusCode Status { set; get; }
        public T Data { set; get; }
        public object Meta { set; get; }
        public List<string> Errors { set; get; }
        public bool Succeeded { set; get; }
        public string Message { set; get; }
    }
}
