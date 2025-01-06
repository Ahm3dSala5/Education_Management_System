using System.Net;

namespace EMS.Core.Response
{
    public class Result<T>
    {
        public Result()
        {

        }

        public Result(T _data, string _message = null)
        {
            this.Succeeded = true;
            this.Data = _data;
            this.Message = _message;
        }

        public Result(string _message)
        {
            this.Succeeded = false;
            this.Message = _message;
        }

        public Result(string _message,bool _succeeded)
        {
            this.Succeeded = _succeeded;
            this.Message = _message;
        }
        
        public HttpStatusCode StatusCode { set; get; }
        public T Data { set; get; }
        public object Meta { set; get; }
        public List<string> Errors { set; get; }
        public bool Succeeded { set; get; }
        public string Message { set; get; }
    }
}
